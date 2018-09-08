// ***********************************************************************
// Assembly         : MOL.EFDAL
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 02-18-2018
// ***********************************************************************
// <copyright file="MOL_Laborer_Repository.cs" company="MOL">
//     Copyright © MOL 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using MOL.EFDAL.Models;
using System.Data.Entity.Migrations;

namespace MOL.EFDAL.Repository
{
    using ComplexTypes;
    using Mol.Entities;
    using System;
    using System.Linq;

    /// <summary>
    /// Class MOL_Laborer_Repository.
    /// </summary>
    /// <seealso cref="MOL_Laborer" />
    public partial class MOL_Laborer_Repository
    {
        #region "Select Methods"

        /// <summary>
        /// Function Gets the non Saudi laborer by IDNumber or BorderNo.
        /// RAMS - Code Review (Done)
        /// </summary>
        /// <param name="laborerIdNumber">The identifier no.</param>
        /// <param name="laborerBorderNumber">The border no.</param>
        /// <returns>The Laborer</returns>
        public LaborerInfo GetNonSaudiLaborerByIdNoOrBorder(long? laborerIdNumber, long? laborerBorderNumber)
        {
            //Define target laborer identifier value
            var laborerIdentifier = (laborerIdNumber ?? laborerBorderNumber).ToString();

            return (
                from laborer in Context.MOL_Laborer
                where
                    laborer.IdNo == laborerIdentifier || laborer.BorderNo == laborerIdentifier

                join establishment in Context.MOL_Establishment on new { ID = laborer.FK_EstablishmentId }
                    equals new { ID = establishment.PK_EstablishmentId } into
                  LaborerEstablishment_Join

                from laborerEstablishmentInfo in LaborerEstablishment_Join.DefaultIfEmpty()
                where
                    laborer.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi &&
                    (laborer.IdNo == laborerIdentifier || laborer.BorderNo == laborerIdentifier)

                select new LaborerInfo
                {
                    Id = laborer.PK_LaborerId,
                    IdNumber = laborerIdNumber,
                    BorderNumber = laborerBorderNumber,
                    FullName = laborer.FirstName.Trim() + " " +
                                laborer.SecondName.Trim() + " " +
                                laborer.ThirdName.Trim() + " " +
                                laborer.FourthName.Trim(),

                    EstablishmentSequenceNumber = laborerEstablishmentInfo.SequenceNumber,
                    EstablishmentLaborOfficeId = laborerEstablishmentInfo.FK_LaborOfficeId,
                    LaborerOfficeId = laborer.FK_LaborOfficeId,
                    LaborerSequenceNumber = laborer.SequenceNumber,
                    LaborerStatusId = laborer.FK_LaborerStatusId,
                    MobileNumber = laborer.Mobile
                }).FirstOrDefault();
        }

        /// <summary>
        /// يجب أن تكون "رخصة العمل أو الإقامة الخاصة بالعامل سارية المفعول"
        /// أو "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
        /// أو لم يمضي على 30 يوما على انتهاء فترة ال 90 يوما لوصول العامل للمملكة"
        /// RAMS Code Review (Done).
        /// </summary>
        /// <param name="laborerIdNumber">Laborer IdNumber</param>
        /// <param name="laborerBorderNumber">Laborer Sequence Number</param>
        /// <param name="allowedDaysToValidateIqammaAndWorkPermit">عدد أيام - رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة </param>
        /// <param name="rule2IsValid">Rule2: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما</param>
        /// <returns>True if all rules are valid. False otherwise.</returns>
        public bool HasValidLaborerWorkPermitAndIqamma(long? laborerIdNumber, long? laborerBorderNumber,
            int allowedDaysToValidateIqammaAndWorkPermit, out bool rule2IsValid)
        {
            //Define target laborer identifier value
            var laborerIdentifier = (laborerIdNumber ?? laborerBorderNumber).ToString();

            //===========================================================================================
            //1- Get laborer Iqamma Expiration Date
            //===========================================================================================
            var initialLaborerInfo =
               (from laborer in this.Context.MOL_Laborer
                where laborer.IdNo == laborerIdentifier || laborer.BorderNo == laborerIdentifier
                select new { laborer.LastWPExpirationDate, laborer.FK_WPId, laborer.KingdomEntryDate }).FirstOrDefault();

            //===========================================================================================
            //2- Get laborer Work Permit Expiration Date
            //===========================================================================================
            var workPermitExpirationDate =
               (from workPermit in this.Context.MOL_WorkPermit
                where workPermit.PK_WPId == initialLaborerInfo.FK_WPId
                select workPermit.ExpirationDate).FirstOrDefault();

            //===========================================================================================
            //Rule1: يجب أن تكون "رخصة العمل أو الإقامة الخاصة بالعامل سارية المفعول            
            //===========================================================================================
            if (initialLaborerInfo?.LastWPExpirationDate != null &&
                (initialLaborerInfo.LastWPExpirationDate > DateTime.Now || workPermitExpirationDate > DateTime.Now))
            {
                rule2IsValid = false;
                return true;
            }

            //===========================================================================================
            //Rule2: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
            //===========================================================================================
            if (initialLaborerInfo?.LastWPExpirationDate != null &&
                initialLaborerInfo.LastWPExpirationDate < DateTime.Now &&
                workPermitExpirationDate < DateTime.Now &&
                initialLaborerInfo.LastWPExpirationDate.Value.AddDays(allowedDaysToValidateIqammaAndWorkPermit) > DateTime.Now)
            {
                rule2IsValid = true;
                return true;
            }

            //===========================================================================================
            //Rule 3: لم يمضي 30 يوما على انتهاء فترة ال 90 يوما لوصول العامل للمملكة
            //===========================================================================================
            if (initialLaborerInfo?.KingdomEntryDate != null &&
                initialLaborerInfo.KingdomEntryDate.Value.AddDays(90).AddDays(allowedDaysToValidateIqammaAndWorkPermit) > DateTime.Now)
            {
                rule2IsValid = true;
                return true;
            }

            //===========================================================================================
            //No expression is valid
            rule2IsValid = false;
            return false;
        }

        #endregion

        #region "Create/Update Methods"

        /// <summary>
        /// Function updates Laborer Status to "Working" or "RunAway"
        /// RAMS
        /// Code Review (Done).
        /// </summary>
        /// <param name="laborerIdNumber">The laborer identifier number.</param>
        /// <param name="laborerBorderNumber">The laborer border number.</param>
        /// <param name="targetStatus">The target status.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ChangeLaborerStatus(long? laborerIdNumber, long? laborerBorderNumber, int targetStatus)
        {
            //Define target laborer identifier value
            var laborerIdentifier = (laborerIdNumber ?? laborerBorderNumber).ToString();

            //Get laborer Info
            var laborerRecord =
                 Context.MOL_Laborer.FirstOrDefault(record => record.FK_SaudiFlagId == (int)SaudiFlagList.NonSaudi &&
                                                              (record.IdNo == laborerIdentifier || record.BorderNo == laborerIdentifier));

            //Update Laborer Status
            if (laborerRecord == null)
                return false;

            laborerRecord.FK_LaborerStatusId = targetStatus;

            Context.MOL_Laborer.AddOrUpdate(laborerRecord);
            var xx = Context.SaveChanges();

            return xx > 0;
        }

        #endregion
    }
}