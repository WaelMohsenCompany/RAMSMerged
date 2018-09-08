// ***********************************************************************
// Assembly         : RAMS.ApplicationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-12-2018
// ***********************************************************************
// <copyright file="GetLaborer.svc.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.ComplexTypes;
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.Common;
using RAMS.CrossCutting;
using System;

namespace RAMS.ApplicationServices.Laborer.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetLaborer.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class GetLaborer : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Get Common System Settings
        /// </summary>
        /// <value>The get common instance.</value>
        private GetCommon GetCommonInstance { get; set; }

        #endregion

        /// <summary>
        /// Method get NonSaudi Laborer information from MoL DB using Laborer ID Number or Border Number
        /// Code Review (Done)
        /// </summary>
        /// <param name="laborerIdNumber">The laborer identifier number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns>LaborerInfo.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public LaborerInfo GetLaborerDetailsFromMoL(long? laborerIdNumber, long? borderNumber, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null ||
                (laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Read laborer info from DB 
            return dbUnitOfWork.MOL_Laborer_Repository.
                GetNonSaudiLaborerByIdNoOrBorder(laborerIdNumber, borderNumber);
        }

        /// <summary>
        /// Function returns Laborer RunAway request by IdNumber (طلب إثبات كيدية بلاغ تغيب)
        /// </summary>
        /// <param name="laborerIdNumber">Laborer ID Number</param>
        /// <param name="borderNumber">Laborer Boarder Number</param>
        /// <param name="systemNumberOfDays">Number of allowed days to create complaint request</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns>List of available Appointments</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public CrossCutting.ComplaintRetrieveRequestInfo GetLatestRunAwayOrComplaintRequest(
            long? laborerIdNumber, long? borderNumber, int systemNumberOfDays, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null ||
                (laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Read setting value from DB 
            var results =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.
                    GetLatestRunAwayOrComplaintRequest(laborerIdNumber, borderNumber, systemNumberOfDays);

            if (results == null)
                return null;

            //Fill Object RunAway Info
            var returnResult = new CrossCutting.ComplaintRetrieveRequestInfo
            {
                RunAwayRequestId = Convert.ToInt32(results.RunAwayRequestId),
                RunAwayRequestNumber = results.RunAwayRequestNumber,
                EstablishmentTitle = results.EstablishmentTitle,
                RunAwayRequestDate = results.RunAwayRequestDate,
                RunAwayRequestStatusId = results.RunAwayRequestStatusId,
                RunAwayRequestStatusName =
                    TypedObjects.GetStatusName(
                        TypedObjects.StatusType.RunAwayRequestStatus, results.RunAwayRequestStatusId),

                //Fill Object Complaint Info
                ComplaintRequestId = results.ComplaintRequestId,
                ComplaintRequestDate = results.ComplaintRequestDate,
                RejectReason = results.RejectReason,
                ComplaintRequestStatusId = results.ComplaintRequestStatusId,
                FilesPaths = results.FilesPaths,
                ComplaintQuestion1 = results.ComplaintQuestion1,
                ComplaintQuestion2 = results.ComplaintQuestion2,
                ComplaintQuestion3 = results.ComplaintQuestion3,
                ComplaintQuestion4 = results.ComplaintQuestion4,
                LaborerMobileNo = results.LaborerMobileNo,
                ComplaintRequestStatusName = TypedObjects.GetStatusName(
                    TypedObjects.StatusType.ComplaintRequestStatus, results.ComplaintRequestStatusId)
            };

            //Return Object to Caller
            return returnResult;
        }

        /// <summary>
        /// حالة العامل الذي يتم نقله يجب أن تكون على رأس العمل
        /// Code Review (Done)
        /// </summary>
        /// <param name="laborerStatus">The laborer Status.</param>
        /// <returns><c>true</c> if [is status working] [the specified identifier number]; otherwise, <c>false</c>.</returns>
        public bool IsStatusWorking(int? laborerStatus)
        {
            if (laborerStatus.HasValue)
                return laborerStatus == TypedObjects.LaborerStatus.Working.GetHashCode();
            else
                return false;
        }

        /// <summary>
        /// يجب أن تكون "رخصة العمل أو الإقامة الخاصة بالعامل سارية المفعول"
        /// أو "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
        /// أو لم يمضي على 30 يوما على انتهاء فترة ال 90 يوما لوصول العامل للمملكة"
        /// </summary>
        /// <param name="laborerIdNumber">Laborer IdNumber</param>
        /// <param name="borderNumber">Laborer Sequence Number</param>
        /// <param name="isRequestByEstablishmentAgent">Is this checking request From EService Portal</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns>True if all rules are valid. False otherwise.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg HasValidLaborerWorkPermitAndIqamma(long? laborerIdNumber, long? borderNumber,
            bool isRequestByEstablishmentAgent, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null ||
                (laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //======================================================================================================================
            //Get allowed number of days to check Rule2
            //Rule2: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
            using (GetCommonInstance = new GetCommon())
            {
                var allowedDaysToValidateIqammaAndWorkPermit =
                  GetCommonInstance.GetSystemSettings(
                   isRequestByEstablishmentAgent ? TypedObjects.SystemSettings.EServiceAllowedDaysToValidateIqammaAndWorkPermit :
                   TypedObjects.SystemSettings.MyClientsAllowedDaysToValidateIqammaAndWorkPermit, dbUnitOfWork);

                //======================================================================================================================
                //Rule2: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما

                //Check rules in database
                return
                    new ResponseMsg
                    {
                        IsSuccess =
                            dbUnitOfWork.MOL_Laborer_Repository.
                                HasValidLaborerWorkPermitAndIqamma(laborerIdNumber, borderNumber,
                                    allowedDaysToValidateIqammaAndWorkPermit, out var rule2IsValid),

                        RuleTypeId = rule2IsValid ? TypedObjects.HasInvalidLaborerWorkPermitAndIqammaRule2 : string.Empty
                    };
            }
        }

        /// <summary>
        /// Function checks if Laborer has already another RunAway request or not
        /// </summary>
        /// <param name="laborerId">Laborer DB Id</param>
        /// <param name="establishmentLaborOfficeId">Establishment LaborOffice Id</param>
        /// <param name="establishmentSequenceNumber">Establishment Sequence Number</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool HaveOpenRunAwayRequest(long laborerId, int establishmentLaborOfficeId,
            long establishmentSequenceNumber, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Read laborer info from DB 
            return dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.
               GetRunAwayRequestsCount(laborerId, establishmentLaborOfficeId, establishmentSequenceNumber) > 0;
        }

        /// <summary>
        /// دد مرات تقديم بلاغ التغيب على عامل معين في فرع منشاة معين من خلال بوابة الخدمات الإلكترونيه
        /// للمنشآت على عدد متغير من المرات (القيمة الافتراضية مرتان فقط).
        /// </summary>
        /// <param name="laborerIdNumber">The laborer identifier number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <param name="establishmentLaborOfficeId">The establishment labor office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool HaveOverNumberOfRunAwayRequest(long? laborerIdNumber, long? borderNumber,
            int establishmentLaborOfficeId, long establishmentSequenceNumber, UnitOfWork dbUnitOfWork)
        {
            if (dbUnitOfWork == null ||
                (laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            using (GetCommonInstance = new GetCommon())
            {
                var allowedNumberOfRunAwayRequest =
                    GetCommonInstance.GetSystemSettings(TypedObjects.SystemSettings.AllowedNumberOfRunAwayRequest, dbUnitOfWork);

                if (allowedNumberOfRunAwayRequest <= 0)
                    return false;

                return
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetTotalRunAwayRequestsCount(laborerIdNumber,
                        borderNumber, establishmentLaborOfficeId, establishmentSequenceNumber) >= allowedNumberOfRunAwayRequest;
            }
        }

        /// <summary>
        /// دد مرات تقديم إلغاء بلاغ التغيب على عامل معين في فرع منشاة معين من خلال بوابة الخدمات الإلكترونيه
        /// للمنشآت على عدد متغير من المرات (القيمة الافتراضية مرتان فقط).
        /// </summary>
        /// <param name="runAwayRequestNumber">The run away request number.</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns><c>true</c> if have over Number of RunAway Cancel Request, <c>false</c> otherwise.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool HaveOverNumberOfRunAwayCancelRequest(string runAwayRequestNumber, UnitOfWork dbUnitOfWork)
        {
            if (dbUnitOfWork == null || string.IsNullOrEmpty(runAwayRequestNumber))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            using (GetCommonInstance = new GetCommon())
            {
                var allowedNumberOfCanceledRunAwayRequest =
                    GetCommonInstance.GetSystemSettings(
                        TypedObjects.SystemSettings.AllowedNumberOfCanceledRunAwayRequest, dbUnitOfWork);

                if (allowedNumberOfCanceledRunAwayRequest <= 0)
                    return false;

                return
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.
                        GetTotalCanceledRunAwayRequestsCount(runAwayRequestNumber) >= allowedNumberOfCanceledRunAwayRequest;
            }
        }

    }
}
