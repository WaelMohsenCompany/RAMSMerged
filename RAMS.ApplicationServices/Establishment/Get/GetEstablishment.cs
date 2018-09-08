// ***********************************************************************
// Assembly         : RAMS.ApplicationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 03-08-2018
// ***********************************************************************
// <copyright file="GetEstablishment.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.ComplexTypes;
using MOL.EFDAL.Repository;
using RAMS.CrossCutting;
using System;

namespace RAMS.ApplicationServices.Establishment.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetEstablishment.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class GetEstablishment : BaseDisposeClass
    {
        /// <summary>
        /// Function returns Establishment By LaborOffice And Sequence Number
        /// Code Review (Done)
        /// </summary>
        /// <param name="laborOfficeId">The labor office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>SP_MOL_Establishment_GetByFkLaborOfficeIdSequenceNumber.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public EstablishmentInfo GetEstablishmentByLaborOfficeAndSequenceNumber(int laborOfficeId, long sequenceNumber, UnitOfWork dbUnitOfWork)
        {            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Read setting value from DB 
            return dbUnitOfWork.MOL_Establishment_Repository.
                    GetEstablishmentByLaborOfficeAndSequenceNumber(laborOfficeId, sequenceNumber);
        }

        /// <summary>
        /// نشاط المنشآة ليس من الأنشطة المستثناة من الخدمة
        /// Function checks if Establishment Activity is allowed to use this service
        /// Code Review (Done)
        /// </summary>
        /// <param name="laborOfficeId">The labor office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns><c>true</c> if [is in appendix9] [the specified labor office identifier]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool IsEstablishmentEligibleForRunAwayRequest(int laborOfficeId, long sequenceNumber, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Read setting value from DB 
            return dbUnitOfWork.Lookup_EconomicActivity_Repository
                .IsEligibleForRunAwayRequest(laborOfficeId, sequenceNumber);
        }

        /// <summary>
        /// نشاط المنشآة الفرعي ليس من الأنشطة المستثناة من الخدمة
        /// Function checks if Establishment Activity is allowed to use this service
        /// Code Review (Done)
        /// </summary>
        /// <param name="economicActivityId">Sub Economic Activity Id.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns><c>true</c> if [is in appendix9] [the specified labor office identifier]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool IsActivityEligibleForRunAwayRequest(int? economicActivityId, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (economicActivityId.HasValue)
            {
                //Read setting value from DB 
                return dbUnitOfWork.Lookup_EconomicActivity_Repository
                        .IsEligibleForRunAwayRequest(economicActivityId.Value);
            }

            return false;
        }

        /// <summary>
        /// يجب أن تكون حالة المنشأة "قائمة"
        /// Code Review (Done)
        /// </summary>
        /// <param name="statusId">Name of the status.</param>
        /// <returns><c>true</c> if [is establishment status exist] [the specified labor office identifier]; otherwise, <c>false</c>.</returns>
        public bool IsEstablishmentStatusExist(int? statusId)
        {
            //Check input parameters is valid
            if (statusId.HasValue)
                return statusId == TypedObjects.EstablishmentStatusList.Existent.GetHashCode();

            return false;
        }

        /// <summary>
        /// اشتراك المنشأة في خدمة العنوان الوطني ساري.
        /// Code Review (Done)
        /// </summary>
        /// <param name="expiryDate">WASEL Expiry Date</param>
        /// <param name="statusId">WASEL Status ID</param>
        /// <returns><c>true</c> if [is WASL valid and not expired] [the specified labor office identifier]; otherwise, <c>false</c>.</returns>
        public bool IsWASLValidAndNotExpired(DateTime? expiryDate, int? statusId)
        {
            //Check input parameters is valid
            if (expiryDate.HasValue && statusId.HasValue)
                return (expiryDate.Value.Date > DateTime.Now.Date &&
                    statusId.Value == TypedObjects.StaticValues.WASELStatus.GetHashCode());

            return false;
        }
    }
}
