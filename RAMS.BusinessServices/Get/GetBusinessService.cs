// ***********************************************************************
// Assembly         : RAMS.BusinessServices
// Author           : WaelMohsen
// Created          : 03-04-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-02-2018
// ***********************************************************************
// <copyright file="GetBusinessService.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using NLog;
using RAMS.CrossCutting;
using RAMS.EnterpriseServices.Common.Get;
using RAMS.EnterpriseServices.Establishment.Get;
using RAMS.EnterpriseServices.Laborer.Get;
using RAMS.EnterpriseServices.MyClients.Get;
using RAMS.InfrastructureService.FileTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RAMS.BusinessServices.Get
{
    /// <summary>
    /// Class GetBusinessService.
    /// </summary>
    public class GetBusinessService : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Gets or sets the es get establishment instance.
        /// </summary>
        /// <value>The es get establishment instance.</value>
        private GetEstablishment ESGetEstablishmentInstance { get; set; }

        /// <summary>
        /// Gets or sets the es get laborer instance.
        /// </summary>
        /// <value>The es get laborer instance.</value>
        private GetLaborer ESGetLaborerInstance { get; set; }

        /// <summary>
        /// Gets or sets the es get common instance.
        /// </summary>
        /// <value>The es get common instance.</value>
        private GetCommon ESGetCommonInstance { get; set; }

        /// <summary>
        /// Gets or sets the es get my clients instance.
        /// </summary>
        /// <value>The es get my clients instance.</value>
        private GetMyClients ESGetMyClientsInstance { get; set; }

        /// <summary>Gets the central logger.</summary>
        /// <value>The central logger.</value>
        private static Logger CentralLogger { get; } = LogManager.GetCurrentClassLogger();

        #endregion

        #region"Public Services"

        /// <summary>
        /// Function returns system setting value
        /// Code Review (Done)
        /// </summary>
        /// <param name="targetSetting">The target setting value.</param>
        /// <param name="applicantUserIdNumber"></param>
        /// <returns>System.Int32.</returns>
        public int GetSystemSettings(TypedObjects.SystemSettings targetSetting, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                targetSetting.GetHashCode(), applicantUserIdNumber));

            try
            {
                using (ESGetCommonInstance = new GetCommon())
                {
                    return ESGetCommonInstance.GetSystemSettings(targetSetting);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    targetSetting.GetHashCode(), applicantUserIdNumber));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                         targetSetting.GetHashCode(), applicantUserIdNumber));

                throw;
            }
        }

        /// <summary>
        /// Functions returns standard System Message
        /// Code Review (Done)
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <returns>Message Info.</returns>
        public ResponseMsg GetSystemMessages(string messageCode, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
               messageCode, applicantUserIdNumber));

            try
            {
                using (ESGetCommonInstance = new GetCommon())
                {
                    return ESGetCommonInstance.GetSystemMessage(messageCode);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    messageCode, applicantUserIdNumber));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        messageCode, applicantUserIdNumber));

                throw;
            }
        }

        #endregion

        #region "تقديم بلاغ تغيب"

        /// <summary>
        /// Checks the create run away laborer business rules.
        /// </summary>
        /// <param name="idNumber">The identifier number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <param name="isRequestByEstablishmentAgent">if set to <c>true</c> [This request is created by establishment agent].</param>
        /// <param name="establishmentLaborOfficeId">The establishment labor office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <param name="isConfirmed">Check if Warning Business Rules is confirmed</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.
        /// ActionResults.IsSuccess == True: Then all are True
        /// ActionResults.IsSuccess == False: Check ResultsCode != "ERRORCODE001", If so, Then there are some BR violations
        /// ActionResults.IsSuccess == False: Check ResultsCode == "ERRORCODE001", If so, Then this is the limit for creation. Show Error MSG in Description. Stop Working in Establishment Portal and Continue Working in MyClients
        /// </returns>
        public ActionResults<HashSet<ResponseMsg>> CheckCreateRunAwayLaborerBusinessRules(long? idNumber, long? borderNumber,
              bool isRequestByEstablishmentAgent, int establishmentLaborOfficeId, long establishmentSequenceNumber,
              long applicantUserIdNumber, bool isConfirmed = false)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                idNumber, borderNumber, isRequestByEstablishmentAgent, establishmentLaborOfficeId,
                establishmentSequenceNumber, applicantUserIdNumber, isConfirmed));

            try
            {
                using (ESGetLaborerInstance = new GetLaborer())
                {
                    //=========================================================================================
                    //Call ES
                    var results = ESGetLaborerInstance.CheckCreateRunAwayBusinessRules(idNumber, borderNumber,
                            isRequestByEstablishmentAgent, establishmentLaborOfficeId, establishmentSequenceNumber, isConfirmed);

                    //Initialize return value to Succeeded Business Rules 
                    var returnResults = new ActionResults<HashSet<ResponseMsg>>
                    {
                        IsSuccess = true,
                        Description = MethodBase.GetCurrentMethod().Name,
                        ResultsCode = ResultsCodes.BusinessRulesSucceeded,
                        ResultsList = results
                    };

                    //Check if any Business Rules failed
                    foreach (var currentResult in results.Where(currentResult => !currentResult.IsSuccess))
                    {
                        //Normal Business Rules validations errors happened
                        returnResults.IsSuccess = false;
                        returnResults.ResultsCode = ResultsCodes.BusinessRulesViolationError;

                        //Check if laborer Have Over Number Of RunAway Requests
                        if (currentResult.RuleTypeId == null)
                            continue;

                        if (currentResult.RuleTypeId.Equals(TypedObjects.HaveOverNumberOfRunAwayRequest))
                        {
                            returnResults.Description = currentResult.ResponseText;

                            //Set Warning Violation in Case of MyClients Portal
                            returnResults.ResultsCode = isRequestByEstablishmentAgent
                                ? ResultsCodes.BusinessRulesViolationError
                                : ResultsCodes.BusinessRulesViolationWarning;
                            break;
                        }
                    }

                    return returnResults;
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    idNumber, borderNumber, isRequestByEstablishmentAgent, establishmentLaborOfficeId,
                    establishmentSequenceNumber, applicantUserIdNumber, isConfirmed));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        idNumber, borderNumber, isRequestByEstablishmentAgent, establishmentLaborOfficeId,
                        establishmentSequenceNumber, applicantUserIdNumber, isConfirmed));

                throw;
            }
        }

        /// <summary>
        /// Function checks Establishment business rules to create RunAway request
        /// </summary>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        public HashSet<ResponseMsg> CheckCreateRunAwayEstablishmentBusinessRules(int laborerOfficeId, long sequenceNumber, long applicantUserIdNumber)
        {
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                laborerOfficeId, sequenceNumber, applicantUserIdNumber));

            try
            {
                using (ESGetEstablishmentInstance = new GetEstablishment())
                {
                    return ESGetEstablishmentInstance.CheckCreateRunAwayBusinessRules(laborerOfficeId, sequenceNumber);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                   laborerOfficeId, sequenceNumber, applicantUserIdNumber));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        laborerOfficeId, sequenceNumber, applicantUserIdNumber));

                throw;
            }

        }

        #endregion

        #region "إدارة بلاغ تغيب"

        /// <summary>
        /// Function returns Runaway request based on specific runaway criteria
        /// </summary>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <param name="laborerIdNumber">The laborer identifier number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <returns>RunAwayRetrieveRequestInfo.</returns>
        public RunAwayRetrieveRequestInfo GetRunAwayRequest(long applicantUserIdNumber, int laborerOfficeId, long sequenceNumber, long? laborerIdNumber, long? borderNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                applicantUserIdNumber, laborerOfficeId, sequenceNumber, laborerIdNumber, borderNumber));

            try
            {
                using (ESGetEstablishmentInstance = new GetEstablishment())
                {
                    return ESGetEstablishmentInstance.GetRunAwayRequest(applicantUserIdNumber, laborerOfficeId, sequenceNumber, laborerIdNumber, borderNumber);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    applicantUserIdNumber, laborerOfficeId, sequenceNumber, laborerIdNumber, borderNumber));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        applicantUserIdNumber, laborerOfficeId, sequenceNumber, laborerIdNumber, borderNumber));

                throw;
            }
        }

        /// <summary>
        /// Function returns list of Runaway requests based on specific runaway criteria
        /// </summary>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <param name="queryRecordsCount">The query records count.</param>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <returns>HashSet&lt;RunAwayRetrieveRequestInfo&gt;.</returns>
        public HashSet<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsList(long applicantUserIdNumber, int laborerOfficeId, long sequenceNumber, int queryRecordsCount, int currentPageIndex)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                applicantUserIdNumber, laborerOfficeId, sequenceNumber, queryRecordsCount, currentPageIndex));

            try
            {
                using (ESGetEstablishmentInstance = new GetEstablishment())
                {
                    return ESGetEstablishmentInstance.GetAllRunAwayRequestsList(applicantUserIdNumber, laborerOfficeId, sequenceNumber, queryRecordsCount, currentPageIndex - 1);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                            new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                            MethodBase.GetCurrentMethod(),
                            applicantUserIdNumber, laborerOfficeId, sequenceNumber, queryRecordsCount, currentPageIndex));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        applicantUserIdNumber, laborerOfficeId, sequenceNumber, queryRecordsCount, currentPageIndex));

                throw;
            }
        }

        #endregion

        #region "طلب إثبات كيدية بلاغ تغيب"

        /// <summary>
        /// Function returns Laborer RunAway request by IdNumber (طلب إثبات كيدية بلاغ تغيب)
        /// </summary>
        /// <param name="laborerIdNumber">Laborer ID Number</param>
        /// <param name="borderNumber">Laborer Border Number</param>
        /// <returns>List of available Appointments</returns>
        public ComplaintRetrieveRequestInfo GetLatestRunAwayOrComplaintRequest(long? laborerIdNumber, long? borderNumber)
        {
            //Check Input parameters are valid
            if ((laborerIdNumber.HasValue && borderNumber.HasValue) ||
            (!laborerIdNumber.HasValue && !borderNumber.HasValue) ||
            (laborerIdNumber.HasValue && laborerIdNumber.Value <= 0) ||
            (borderNumber.HasValue && borderNumber.Value <= 0))
            {
                var argumentExceptionInstance = new ArgumentException(MethodBase.GetCurrentMethod().Name);

                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(), laborerIdNumber, borderNumber));

                throw argumentExceptionInstance;
            }

            //=========================================================================================
            //Log calling Information
            var applicantUserIdNumber = laborerIdNumber ?? borderNumber.Value;
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(), laborerIdNumber, borderNumber));

            try
            {
                using (ESGetLaborerInstance = new GetLaborer())
                {
                    return ESGetLaborerInstance.GetLatestRunAwayOrComplaintRequest(laborerIdNumber, borderNumber);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(), laborerIdNumber, borderNumber));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(), laborerIdNumber, borderNumber));
                throw;
            }
        }

        #endregion

        #region "البت في بلاغ التغيب"

        /// <summary>
        /// Gets the region laborer office list. (البت فى بلاغ تغيب)
        /// </summary>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <returns>HashSet&lt;LaborerOfficeInfo&gt;.</returns>
        public HashSet<LaborOfficeInfo> GetRegionLaborerOfficeList(int? laborerOfficeId, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(), laborerOfficeId, applicantUserIdNumber));

            try
            {
                using (ESGetMyClientsInstance = new GetMyClients())
                {
                    return ESGetMyClientsInstance.GetRegionLaborerOfficeList(laborerOfficeId);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(), laborerOfficeId, applicantUserIdNumber));
                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(), laborerOfficeId, applicantUserIdNumber));
                throw;
            }
        }

        /// <summary>
        /// Function returns list of Establishment RunAway requests based on Status (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="filterType">Mandatory. Search filter type.</param>
        /// <param name="searchLaborerOfficeId">Optional. Search Laborer Office</param>
        /// <param name="searchEstablishmentLaborerOfficeId">Optional. Search Establishment Laborer OfficeId</param>
        /// <param name="searchEstablishmentSequenceNumber">Optional. Search Establishment Sequence Number</param>
        /// <param name="queryRecordsCount">Mandatory. Number of records per query</param>
        /// <param name="currentPageIndex">Mandatory. Current Page Index</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <returns>List of available Requests</returns>
        public HashSet<RunAwayApprovalRequestInfo> GetForApprovalRunAwayRequestsList(
            TypedObjects.ComplaintRequestStatus filterType,
            int? searchLaborerOfficeId, int? searchEstablishmentLaborerOfficeId, long? searchEstablishmentSequenceNumber,
            int queryRecordsCount, int currentPageIndex, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber },
                MethodBase.GetCurrentMethod(),
                filterType.GetHashCode(), searchLaborerOfficeId, searchEstablishmentLaborerOfficeId,
                searchEstablishmentSequenceNumber, queryRecordsCount, currentPageIndex, applicantUserIdNumber));

            try
            {
                using (ESGetMyClientsInstance = new GetMyClients())
                {
                    return ESGetMyClientsInstance.GetForApprovalRunAwayRequestsList(
                        filterType, searchLaborerOfficeId,
                        searchEstablishmentLaborerOfficeId, searchEstablishmentSequenceNumber,
                        queryRecordsCount, currentPageIndex - 1);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    filterType.GetHashCode(), searchLaborerOfficeId, searchEstablishmentLaborerOfficeId,
                    searchEstablishmentSequenceNumber, queryRecordsCount, currentPageIndex, applicantUserIdNumber));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        filterType.GetHashCode(), searchLaborerOfficeId, searchEstablishmentLaborerOfficeId,
                        searchEstablishmentSequenceNumber, queryRecordsCount, currentPageIndex, applicantUserIdNumber));

                throw;
            }
        }

        #endregion

        #region "تدقيق بلاغ التغيب "

        /// <summary>
        /// Function returns list of Laborer Office RunAway requests (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="userLaborOfficeId">Mandatory. User laborer Office.</param>
        /// <param name="filterType">Mandatory. Search filter type.</param>
        /// <param name="establishmentLaborerOfficeId">Optional. Establishment Laborer OfficeId</param>
        /// <param name="establishmentSequenceNumber">Optional. Establishment Laborer Office Sequence Number</param>
        /// <param name="laborerIdNumber">&gt;Optional. Laborer ID Number</param>
        /// <param name="laborerBorderNumber">&gt;Optional. Laborer border Number</param>
        /// <param name="requestCode">&gt;Optional. Request Code</param>
        /// <param name="queryRecordsCount">Mandatory. Number of records per query</param>
        /// <param name="currentPageIndex">Mandatory. Current Page Index</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <returns>HashSet&lt;RunAwayReviewRequestsInfo&gt;.</returns>
        public HashSet<RunAwayReviewRequestsInfo> GetForReviewRunAwayRequestsList(
            int userLaborOfficeId, TypedObjects.ComplaintRequestStatus filterType,
            int? establishmentLaborerOfficeId, long? establishmentSequenceNumber,
            long? laborerIdNumber, long? laborerBorderNumber, string requestCode,
            int queryRecordsCount, int currentPageIndex, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                userLaborOfficeId, filterType.GetHashCode(), establishmentLaborerOfficeId, establishmentSequenceNumber,
                laborerIdNumber, laborerBorderNumber, requestCode, queryRecordsCount, currentPageIndex, applicantUserIdNumber));

            try
            {
                using (ESGetMyClientsInstance = new GetMyClients())
                {
                    return ESGetMyClientsInstance.GetForReviewRunAwayRequestsList(
                    userLaborOfficeId, filterType,
                    establishmentLaborerOfficeId, establishmentSequenceNumber,
                    laborerIdNumber, laborerBorderNumber, requestCode,
                    queryRecordsCount, currentPageIndex);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    userLaborOfficeId, filterType.GetHashCode(), establishmentLaborerOfficeId, establishmentSequenceNumber,
                    laborerIdNumber, laborerBorderNumber, requestCode, queryRecordsCount, currentPageIndex, applicantUserIdNumber));
                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        userLaborOfficeId, filterType.GetHashCode(), establishmentLaborerOfficeId, establishmentSequenceNumber,
                        laborerIdNumber, laborerBorderNumber, requestCode, queryRecordsCount, currentPageIndex, applicantUserIdNumber));
                throw;
            }

        }

        #endregion

        #region "File Transfer Methods"

        /// <summary>
        /// Downloads the file.
        /// </summary>
        /// <param name="requestFileName">Name of the request file.</param>
        /// <param name="applicantUserIdNumber">Method Invocation ID Number</param>
        /// <returns>RemoteFileInfo.</returns>
        public RemoteFileInfo DownloadFile(DownloadRequest requestFileName, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatComplexLogValues(new dynamic[] { applicantUserIdNumber }, requestFileName));

            try
            {
                using (var fileTransfer = new GetCommon())
                {
                    return fileTransfer.DownloadFile(requestFileName);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance,
                    Utilities.FormatComplexLogValues(new dynamic[] { applicantUserIdNumber }, requestFileName));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception,
                    Utilities.FormatComplexLogValues(new dynamic[] { applicantUserIdNumber }, requestFileName));
                throw;
            }
        }

        #endregion
    }
}
