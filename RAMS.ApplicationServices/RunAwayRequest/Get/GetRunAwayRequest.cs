// ***********************************************************************
// Assembly         : RAMS.ApplicationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-12-2018
// ***********************************************************************
// <copyright file="GetRunAwayRequest.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.Common;
using RAMS.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAMS.ApplicationServices.RunAwayRequest.Get
{
    /// <inheritdoc />
    /// <summary>
    /// Class GetRunAwayRequest.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class GetRunAwayRequest : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Get Common System Settings
        /// </summary>
        /// <value>The get common instance.</value>
        private GetCommon GetCommonInstance { get; set; }

        #endregion

        #region " Business Methods "

        /// <summary>
        /// مضى 15 يوم على تقديم البلاغ
        /// Function checks if the Runaway request exceeded allowed period
        /// Code Review (Done)
        /// </summary>
        /// <param name="runAwayCreationDate">Request Creation Time</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns><c>true</c> if request is beyond allowed cancel period; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool IsRequestBeyondCancelPeriod(DateTime runAwayCreationDate, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Initialize Unit Of Work
            using (GetCommonInstance = new GetCommon())
            {
                //Read setting value from DB 
                var systemNumberOfDays =
                    GetCommonInstance.GetSystemSettings(TypedObjects.SystemSettings.AllowedDaysToCancelRunawayRequest, dbUnitOfWork);

                //Check if Creation Date + System Configuration Days is still larger than Todays' Date
                if (runAwayCreationDate.AddDays(systemNumberOfDays) < DateTime.Now)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// لا يمكن تقديم طلب إثبات كيدية بلاغ تغيب بعد مرور عام على تقديمه من المنشأة ضد العامل، وهذه المدة يمكن تغييرها في إعدادات النظام
        /// Function checks if the runaway request exceeded allowed period
        /// Code Review (Done)
        /// </summary>
        /// <param name="runAwayCreationDate">Request Creation Time</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns><c>true</c> if request is beyond allowed Complaint period; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool IsRequestBeyondComplaintPeriod(DateTime runAwayCreationDate, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Initialize Unit Of Work
            using (GetCommonInstance = new GetCommon())
            {
                //Read setting value from DB 
                var systemNumberOfDays =
                    GetCommonInstance.GetSystemSettings(TypedObjects.SystemSettings.AllowedDaysToComplaintRequest,
                        dbUnitOfWork);

                //Check if Creation Date + System Configuration Days is still larger than Todays' Date
                return runAwayCreationDate.AddDays(systemNumberOfDays) < DateTime.Now;
            }
        }

        /// <summary>
        /// لا يمكن تقديم أكثر من طلب إثبات كيدية لنفس البلاغ
        /// Function Checks if laborer already created a Complaint request for the RunAway request
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>True if Complaint request already created. False otherwise.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool IsRequestHasComplaint(int requestId, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return dbUnitOfWork.MOL_RunAwayComplaints_Repository.IsRequestHasComplaint(requestId);
        }

        /// <summary>
        /// Determines whether [is eligible to cancel] [the specified request identifier].
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="runAwayRequestStatusId">The run away request status identifier.</param>
        /// <param name="dbUnitOfWork">The database unit of work.</param>
        /// <returns><c>true</c> if [is eligible to cancel] [the specified request identifier]; otherwise, <c>false</c>.</returns>
        public bool IsEligibleToCancel(int requestId, int runAwayRequestStatusId, UnitOfWork dbUnitOfWork)
        {
            //Status is Rejected or Canceled
            if (runAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode() ||
                runAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Canceled.GetHashCode())
                return false;

            //Check if Runaway request has a complaint request and its status is Accepted or Rejected, then
            //User can not cancel this request because it has been Accepted or Rejected by MLSD department.
            if (IsRequestHasComplaint(requestId, dbUnitOfWork) &&
                runAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode())
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether [is eligible to cancel] [the specified complaint request identifier].
        /// </summary>
        /// <param name="complaintRequestId">The complaint request identifier.</param>
        /// <param name="runAwayRequestStatusId">The run away request status identifier.</param>
        /// <returns><c>true</c> if [is eligible to cancel] [the specified complaint request identifier]; otherwise, <c>false</c>.</returns>
        public bool IsEligibleToCancel(int? complaintRequestId, int runAwayRequestStatusId)
        {
            //Status is Rejected or Canceled
            if (runAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode() ||
                runAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Canceled.GetHashCode())
                return false;

            //Check if Runaway request has a complaint request and its status is Accepted or Rejected, then
            //User can not cancel this request because it has been Accepted or Rejected by MLSD department.
            if (complaintRequestId.HasValue &&
                runAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode())
                return false;

            return true;
        }

        #endregion

        #region "Get Operations"

        /// <summary>
        /// Function returns list of Establishment RunAway requests
        /// </summary>
        /// <param name="applicantUserIdNumber">The user identifier ID.</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <param name="queryRecordsCount">The query records count.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>List of available Appointments</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public HashSet<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsList(
         long applicantUserIdNumber, int laborOfficeId, long sequenceNumber,
         int queryRecordsCount, int currentPageIndex, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || applicantUserIdNumber <= 0 ||
                laborOfficeId <= 0 || sequenceNumber <= 0 ||
                queryRecordsCount <= 0 || currentPageIndex < 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            using (GetCommonInstance = new GetCommon())
            {
                //====================================================================================
                //Fetching Data is restricted by System settings value
                var numberOfMonths = GetCommonInstance.GetSystemSettings(TypedObjects.SystemSettings.AllowedBackwardSearchMonths, dbUnitOfWork);

                //====================================================================================
                //Get All Runaway requests from Database
                //Read data value from DB 
                var results =
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.
                       GetAllRunAwayRequestsList(
                            applicantUserIdNumber, laborOfficeId, sequenceNumber, numberOfMonths,
                            queryRecordsCount, currentPageIndex);

                //Check if there is returned values
                if (results != null && results.Any())
                {
                    var returnResults = new HashSet<RunAwayRetrieveRequestInfo>();
                    foreach (var currentRow in results)
                    {
                        //Fill Object RunAway Info
                        returnResults.Add(
                            new RunAwayRetrieveRequestInfo
                            {
                                RequestId = Convert.ToInt32(currentRow.RequestId),
                                RequestNumber = currentRow.RequestNumber,
                                EstablishmentTitle = currentRow.EstablishmentTitle,
                                EstablishmentId = currentRow.EstablishmentId.ToString(),
                                RequestDate = currentRow.RequestDate,
                                RunAwayRequestStatusId = currentRow.RunAwayRequestStatusId,

                                RunAwayRequestStatusName =
                                    TypedObjects.GetStatusName(
                                        TypedObjects.StatusType.RunAwayRequestStatus, currentRow.RunAwayRequestStatusId),

                                SequenceNumber = currentRow.SequenceNumber,
                                LaborerBorderNumber = currentRow.LaborerBorderNumber,
                                LaborerFullName = currentRow.LaborerFullName,
                                LaborerIdNumber = currentRow.LaborerIdNumber,
                                FilesPaths = currentRow.FilesPaths.ToHashSet(),
                                LaborerOfficeId = currentRow.LaborerOfficeId,

                                CreationQuestion1 = currentRow.CreationQuestion1,
                                CreationQuestion2 = currentRow.CreationQuestion2,
                                CreationQuestion3 = currentRow.CreationQuestion3,
                                CreationQuestion4 = currentRow.CreationQuestion4,

                                TotalRowsCount = currentRow.TotalRowsCount,
                                IsEligibleToCancel = IsEligibleToCancel(currentRow.ComplaintRequestId, currentRow.RunAwayRequestStatusId)
                            });
                    }

                    //Return Object to Caller
                    return returnResults;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Function returns Establishment RunAway request by IdNumber or BorderNumber
        /// GetRunAwayRequestInfo
        /// </summary>
        /// <param name="applicantUserIdNumber">The user identifier number.</param>
        /// <param name="laborOfficeId">The establishment laborer office number.</param>
        /// <param name="sequenceNumber">The establishment sequence number.</param>
        /// <param name="laborerIdNumber">Laborer ID Number</param>
        /// <param name="borderNumber">Laborer Border Number</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>Target RunAway Request</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public RunAwayRetrieveRequestInfo GetRunAwayRequestInfo(
            long applicantUserIdNumber, int laborOfficeId, long sequenceNumber,
            long? laborerIdNumber, long? borderNumber, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null ||
                applicantUserIdNumber <= 0 || laborOfficeId <= 0 || sequenceNumber <= 0 ||
                (laborerIdNumber.HasValue && borderNumber.HasValue) ||
                (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
                (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
                (borderNumber.HasValue && borderNumber.Value <= 0))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //====================================================================================
            //Get Runaway request from Database
            //Read data value from DB 
            var result =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.
                    GetRunAwayRequestInfo(
                        applicantUserIdNumber, laborOfficeId, sequenceNumber, laborerIdNumber, borderNumber);

            //Check if there is returned values
            if (result != null)
            {
                var returnResults =
                    new RunAwayRetrieveRequestInfo
                    {
                        RequestId = Convert.ToInt32(result.RequestId),
                        RequestNumber = result.RequestNumber,

                        EstablishmentTitle = result.EstablishmentTitle,
                        EstablishmentId = result.EstablishmentId.ToString(),

                        RequestDate = result.RequestDate,
                        RunAwayRequestStatusId = result.RunAwayRequestStatusId,
                        RunAwayRequestStatusName =
                            TypedObjects.GetStatusName(
                                TypedObjects.StatusType.RunAwayRequestStatus, result.RunAwayRequestStatusId),

                        SequenceNumber = result.SequenceNumber,
                        LaborerBorderNumber = result.LaborerBorderNumber,
                        LaborerFullName = result.LaborerFullName,
                        LaborerIdNumber = result.LaborerIdNumber,
                        FilesPaths = result.FilesPaths.ToHashSet(),
                        LaborerOfficeId = result.LaborerOfficeId,

                        CreationQuestion1 = result.CreationQuestion1,
                        CreationQuestion2 = result.CreationQuestion2,
                        CreationQuestion3 = result.CreationQuestion3,
                        CreationQuestion4 = result.CreationQuestion4,

                        IsEligibleToCancel = IsEligibleToCancel(result.ComplaintRequestId, result.RunAwayRequestStatusId)
                    };

                //Return Object to Caller
                return returnResults;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Function returns Establishment RunAway request by Request Number (Code)
        /// GetRunAwayRequestByNumber
        /// </summary>
        /// <param name="requestNumber">The user identifier number.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>Target RunAway Request</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public RunAwayRetrieveRequestInfo GetRunAwayRequestInfo(string requestNumber, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null ||
                (requestNumber.Split('-').Length < 3))
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Split Id from Request Number
            return GetRunAwayRequestInfo(Convert.ToInt32(requestNumber.Split('-')[2]), dbUnitOfWork);
        }

        /// <summary>
        /// Function returns Establishment RunAway request by request Id
        /// Contract Name: GetRunAwayRequestById
        /// </summary>
        /// <param name="requestId">The request Primary Key.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>Target RunAway Request</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public RunAwayRetrieveRequestInfo GetRunAwayRequestInfo(int requestId, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || requestId <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //====================================================================================
            //Get Runaway request from Database
            //Read data value from DB 
            var result =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetRunAwayRequestInfo(requestId);

            //Check if there is returned values
            if (result != null)
            {
                var returnResults =
                    new RunAwayRetrieveRequestInfo
                    {
                        RequestId = Convert.ToInt32(result.RequestId),
                        RequestNumber = result.RequestNumber,
                        EstablishmentTitle = result.EstablishmentTitle,
                        EstablishmentId = result.EstablishmentId.ToString(),
                        RequestDate = result.RequestDate,
                        RunAwayRequestStatusId = result.RunAwayRequestStatusId,

                        RunAwayRequestStatusName =
                            TypedObjects.GetStatusName(
                                TypedObjects.StatusType.RunAwayRequestStatus, result.RunAwayRequestStatusId),

                        SequenceNumber = result.SequenceNumber,
                        LaborerBorderNumber = result.LaborerBorderNumber,
                        LaborerFullName = result.LaborerFullName,
                        LaborerIdNumber = result.LaborerIdNumber,
                        FilesPaths = result.FilesPaths.ToHashSet(),
                        LaborerOfficeId = result.LaborerOfficeId,

                        CreationQuestion1 = result.CreationQuestion1,
                        CreationQuestion2 = result.CreationQuestion2,
                        CreationQuestion3 = result.CreationQuestion3,
                        CreationQuestion4 = result.CreationQuestion4,
                        IsEligibleToCancel = IsEligibleToCancel(result.ComplaintRequestId, result.RunAwayRequestStatusId)
                    };

                //Return Object to Caller
                return returnResults;
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
