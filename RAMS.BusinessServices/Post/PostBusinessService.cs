// ***********************************************************************
// Assembly         : RAMS.BusinessServices
// Author           : WaelMohsen
// Created          : 03-04-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-09-2018
// ***********************************************************************
// <copyright file="PostBusinessService.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************
using NLog;
using RAMS.BusinessServices.Get;
using RAMS.CrossCutting;
using RAMS.EnterpriseServices.Common.Post;
using RAMS.EnterpriseServices.Establishment.Get;
using RAMS.EnterpriseServices.Laborer.Get;
using RAMS.EnterpriseServices.RunAway.Post;
using RAMS.InfrastructureService.FileTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RAMS.BusinessServices.Post
{
    /// <summary>
    /// Class PostBusinessService.
    /// </summary>
    public class PostBusinessService
    {
        #region "Private Members"

        /// <summary>
        /// Gets or sets the es post run away instance.
        /// </summary>
        /// <value>The es post run away instance.</value>
        private PostRunAway ESPostRunAwayInstance { get; set; }

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
        /// Gets or sets the bs get business instance.
        /// </summary>
        /// <value>The bs get business instance.</value>
        private GetBusinessService BSGetBusinessInstance { get; set; }

        /// <summary>Gets the central logger.</summary>
        /// <value>The central logger.</value>
        private static Logger CentralLogger { get; } = LogManager.GetCurrentClassLogger();

        #endregion

        #region "تقديم بلاغ تغيب"

        /// <summary>
        /// Function Creates RunAway request at MoL database (تقديم بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.
        /// ActionResults.IsSuccess == True: Then all are True
        /// ActionResults.IsSuccess == False: Check ResultsCode != "ERRORCODE001", If so, Then there are some BR violations
        /// ActionResults.IsSuccess == False: Check ResultsCode == "ERRORCODE001", If so, Then this is the limit for creation. Show Error MSG in Description. Stop Working in Establishment Portal and Continue Working in MyClients
        /// </returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ActionResults<HashSet<ResponseMsg>> CreateRunAwayRequest(RunAwayCreateRequestInfo requestInfo)
        {
            //==================================================================================
            //Check input parameters is valid
            if (requestInfo == null)
            {
                var argumentExceptionInstance = new ArgumentNullException(MethodBase.GetCurrentMethod().Name);
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Fatal(argumentExceptionInstance, argumentExceptionInstance.GetType().Name);

                throw argumentExceptionInstance;
            }

            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatComplexLogValues(
                new dynamic[] { requestInfo.ApplicantUserIdNumber }, requestInfo));

            try
            {
                using (ESPostRunAwayInstance = new PostRunAway())
                using (BSGetBusinessInstance = new GetBusinessService())
                {
                    //============================================================================================
                    //Check Establishment Create RunAway Business Rules 
                    var checkEstablishmentTask = Task<HashSet<ResponseMsg>>.Factory.StartNew(() =>
                        BSGetBusinessInstance.CheckCreateRunAwayEstablishmentBusinessRules(
                        requestInfo.LaborerOfficeId, requestInfo.SequenceNumber, requestInfo.ApplicantUserIdNumber),
                        TaskCreationOptions.PreferFairness);

                    //Check Laborer Create RunAway Business Rules 
                    var checkLaborerTask = Task<ActionResults<HashSet<ResponseMsg>>>.Factory.StartNew(() =>
                         BSGetBusinessInstance.CheckCreateRunAwayLaborerBusinessRules(
                            requestInfo.LaborerIdNumber, requestInfo.LaborerBorderNumber,
                            requestInfo.IsRequestByEstablishmentAgent,
                            requestInfo.LaborerOfficeId, requestInfo.SequenceNumber, requestInfo.ApplicantUserIdNumber, true),
                            TaskCreationOptions.PreferFairness);

                    checkEstablishmentTask.Wait();
                    checkLaborerTask.Wait();

                    var establishmentResults = checkEstablishmentTask.Result;
                    var laborerResults = checkLaborerTask.Result;

                    //============================================================================================
                    //Check if both results are OK
                    if (laborerResults.IsSuccess == false)
                    {
                        //Laborer Have Over Number Of RunAway Requests
                        laborerResults.ResultsList.UnionWith(establishmentResults);
                        return laborerResults;
                    }

                    if (establishmentResults.Any(currentResponse => currentResponse.IsSuccess == false))
                    {
                        laborerResults.IsSuccess = false;
                        laborerResults.ResultsCode = ResultsCodes.BusinessRulesViolationError;
                        laborerResults.ResultsList.UnionWith(establishmentResults);
                        laborerResults.Description = MethodBase.GetCurrentMethod().Name;
                        return laborerResults;
                    }

                    //============================================================================================
                    //Save request to DB
                    var rule2IsValid =
                        laborerResults.ResultsList.Any(currentResponse =>
                            currentResponse.RuleTypeId == TypedObjects.HasInvalidLaborerWorkPermitAndIqammaRule2);

                    var creationTask =
                        Task<ResponseMsg>.Factory.StartNew(() =>
                            ESPostRunAwayInstance.CreateRunAwayRequest(requestInfo, rule2IsValid),
                            TaskCreationOptions.LongRunning);
                    creationTask.Wait();

                    laborerResults.ResultsList.UnionWith(establishmentResults);
                    return new ActionResults<HashSet<ResponseMsg>>
                    {
                        IsSuccess = creationTask.Result.IsSuccess,
                        ResultsCode = creationTask.Result.IsSuccess ?
                            ResultsCodes.ActionTransactionSucceeded : ResultsCodes.ActionTransactionError,
                        Description = creationTask.Result.ResponseText,
                        ResultsList = laborerResults.ResultsList
                    };
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatComplexLogValues(
                    new dynamic[] { requestInfo.ApplicantUserIdNumber, argumentExceptionInstance.GetType().Name }, requestInfo));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatComplexLogValues(
                    new dynamic[] { requestInfo.ApplicantUserIdNumber, exception.GetType().Name }, requestInfo));

                throw;
            }
        }

        #endregion

        #region "إدارة بلاغ تغيب"

        /// <summary>
        /// Function Cancels RunAway request at MoL database (إلغاء بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="isConfirmed">Boolean value explains if MyClients user if confirmed the cancel or not. Default value is false</param>
        /// <returns>List&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ActionResults<HashSet<ResponseMsg>> CancelRunAwayRequest(RunAwayCancelRequestInfo requestInfo, bool isConfirmed = false)
        {
            //==================================================================================
            //Check input parameters is valid
            if (requestInfo == null)
            {
                var argumentExceptionInstance = new ArgumentNullException(MethodBase.GetCurrentMethod().Name);
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Fatal(argumentExceptionInstance, argumentExceptionInstance.GetType().Name);

                throw argumentExceptionInstance;
            }

            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatComplexLogValues(
                new dynamic[] { requestInfo.ApplicantUserIdNumber }, requestInfo));

            try
            {
                using (ESPostRunAwayInstance = new PostRunAway())
                using (ESGetEstablishmentInstance = new GetEstablishment())
                using (ESGetLaborerInstance = new GetLaborer())
                {
                    //============================================================================================
                    //Check Establishment Cancel RunAway Business Rules
                    var checkEstablishmentTask =
                        Task<HashSet<ResponseMsg>>.Factory.StartNew(() =>
                            ESGetEstablishmentInstance.CheckCancelRunAwayBusinessRules(requestInfo.RequestNumber));

                    //Check Laborer Create RunAway Business Rules 
                    var checkLaborerTask = Task<ActionResults<HashSet<ResponseMsg>>>.Factory.StartNew(() =>
                            ESGetLaborerInstance.CheckCancelRunAwayBusinessRules(
                                requestInfo.RequestNumber, requestInfo.ApplicantUserIdNumber == requestInfo.CreatedByIdNumber),
                            TaskCreationOptions.PreferFairness);

                    checkEstablishmentTask.Wait();
                    checkLaborerTask.Wait();

                    var establishmentResults = checkEstablishmentTask.Result;
                    var laborerResults = checkLaborerTask.Result;
                    //============================================================================================
                    //Check if both results are OK
                    if (laborerResults.IsSuccess == false && !isConfirmed)
                    {
                        //Laborer Have Over Number Of RunAway Requests
                        laborerResults.ResultsList.UnionWith(establishmentResults);
                        return laborerResults;
                    }

                    if (establishmentResults.Any(currentResponse => currentResponse.IsSuccess == false))
                    {
                        laborerResults.IsSuccess = false;
                        laborerResults.ResultsCode = ResultsCodes.BusinessRulesViolationError;
                        laborerResults.ResultsList.UnionWith(establishmentResults);
                        laborerResults.Description = MethodBase.GetCurrentMethod().Name;
                        return laborerResults;
                    }
                    //============================================================================================
                    //Save request to DB
                    var cancellationTask =
                        Task<ResponseMsg>.Factory.StartNew(() =>
                            ESPostRunAwayInstance.CancelRunAwayRequest(requestInfo),
                            TaskCreationOptions.LongRunning);

                    cancellationTask.Wait();

                    laborerResults.ResultsList.UnionWith(establishmentResults);
                    return new ActionResults<HashSet<ResponseMsg>>
                    {
                        IsSuccess = cancellationTask.Result.IsSuccess,
                        ResultsCode = cancellationTask.Result.IsSuccess ?
                            ResultsCodes.ActionTransactionSucceeded : ResultsCodes.ActionTransactionError,
                        Description = cancellationTask.Result.ResponseText,
                        ResultsList = isConfirmed ? establishmentResults : laborerResults.ResultsList
                    };
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatComplexLogValues(
                    new dynamic[] { requestInfo.ApplicantUserIdNumber, argumentExceptionInstance.GetType().Name }, requestInfo));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatComplexLogValues(
                    new dynamic[] { requestInfo.ApplicantUserIdNumber, exception.GetType().Name }, requestInfo));

                throw;
            }
        }

        #endregion

        #region "طلب إثبات كيدية بلاغ تغيب"

        /// <summary>
        /// Function Creates Complaint request at MoL database (طلب إثبات كيدية بلاغ تغيب )
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <returns>List&lt;ResponseMsg&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ActionResults<HashSet<ResponseMsg>> CreateRunAwayComplaintRequest(ComplaintCreateRequestInfo requestInfo)
        {
            //==================================================================================
            //Check input parameters is valid
            if (requestInfo == null)
            {
                var argumentExceptionInstance = new ArgumentNullException(MethodBase.GetCurrentMethod().Name);
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Fatal(argumentExceptionInstance, argumentExceptionInstance.GetType().Name);
                throw argumentExceptionInstance;
            }

            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatComplexLogValues(
                new dynamic[] { requestInfo.ApplicantUserIdNumber }, requestInfo));

            try
            {
                using (ESPostRunAwayInstance = new PostRunAway())
                using (ESGetLaborerInstance = new GetLaborer())
                {
                    //============================================================================================
                    //Check Create Complaint Business Rules
                    var results = ESGetLaborerInstance.CheckCreateComplaintBusinessRules(requestInfo.RunAwayRequestId);

                    //============================================================================================
                    //Check if both results are OK
                    if (results.Any(currentResponse => currentResponse.IsSuccess == false))
                    {
                        return new ActionResults<HashSet<ResponseMsg>>
                        {
                            IsSuccess = false,
                            ResultsCode = ResultsCodes.BusinessRulesViolationError,
                            Description = System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ResultsList = results
                        };
                    }

                    //============================================================================================
                    //Save request to DB
                    var creationResult = ESPostRunAwayInstance.CreateRunAwayComplaintRequest(requestInfo);

                    return new ActionResults<HashSet<ResponseMsg>>
                    {
                        IsSuccess = creationResult.IsSuccess,
                        ResultsCode = creationResult.IsSuccess ?
                            ResultsCodes.ActionTransactionSucceeded : ResultsCodes.ActionTransactionError,
                        Description = creationResult.ResponseText,
                        ResultsList = results
                    };
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatComplexLogValues(
                    new dynamic[] { requestInfo.ApplicantUserIdNumber, argumentExceptionInstance.GetType().Name }, requestInfo));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatComplexLogValues(
                    new dynamic[] { requestInfo.ApplicantUserIdNumber, exception.GetType().Name }, requestInfo));

                throw;
            }
        }

        #endregion

        #region "البت في بلاغ التغيب"

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="laborOfficeId">The labor office identifier.</param>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg CreateRunAwayReviewRequest(int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                 runAwayRequestId, applicantUserIdNumber, clientIPAddress));

            try
            {
                //==================================================================================
                using (ESPostRunAwayInstance = new PostRunAway())
                {
                    return ESPostRunAwayInstance.CreateRunAwayReviewRequest(
                        runAwayRequestId, applicantUserIdNumber, clientIPAddress);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    runAwayRequestId, applicantUserIdNumber, clientIPAddress));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        runAwayRequestId, applicantUserIdNumber, clientIPAddress));

                throw;
            }
        }

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg AcceptComplaintRequest(int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                runAwayRequestId, applicantUserIdNumber, clientIPAddress));

            try
            {
                //==================================================================================
                using (ESPostRunAwayInstance = new PostRunAway())
                {
                    return ESPostRunAwayInstance.AcceptComplaintRequest(runAwayRequestId, applicantUserIdNumber, clientIPAddress);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    runAwayRequestId, applicantUserIdNumber, clientIPAddress));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        runAwayRequestId, applicantUserIdNumber, clientIPAddress));

                throw;
            }
        }

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="rejectionReason">The rejection reason.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg RejectComplaintRequest(int runAwayRequestId, string rejectionReason, long applicantUserIdNumber, string clientIPAddress)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                runAwayRequestId, rejectionReason, applicantUserIdNumber, clientIPAddress));

            try
            {
                using (ESPostRunAwayInstance = new PostRunAway())
                {
                    return ESPostRunAwayInstance.RejectComplaintRequest(runAwayRequestId, rejectionReason, applicantUserIdNumber, clientIPAddress);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                       runAwayRequestId, rejectionReason, applicantUserIdNumber, clientIPAddress));

                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        runAwayRequestId, rejectionReason, applicantUserIdNumber, clientIPAddress));

                throw;
            }
        }

        #endregion

        #region "تدقيق بلاغ التغيب "

        /// <summary>
        /// Function updates status of Complaint request to - تم تحديد موعد للمراجعة
        /// تدقيق بلاغ التغيب بمكتب العمل
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="appointmentType">The update context.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg UpdateComplaintRequestByReviewAppointment(
            int runAwayRequestId, long applicantUserIdNumber, TypedObjects.ReviewAppointmentType appointmentType, string clientIPAddress)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                runAwayRequestId, applicantUserIdNumber, appointmentType.GetHashCode(), clientIPAddress));

            try
            {
                //==================================================================================
                using (ESPostRunAwayInstance = new PostRunAway())
                {
                    //1- Update request into DB
                    var result =
                        ESPostRunAwayInstance.UpdateComplaintRequestByReviewAppointment(runAwayRequestId, applicantUserIdNumber, clientIPAddress);

                    //2- Send SMS to Individual and/or Establishment
                    ESPostRunAwayInstance.SendTimeForEstablishmentAndLaborer(appointmentType, runAwayRequestId);

                    return result;
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                            new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                            MethodBase.GetCurrentMethod(),
                           runAwayRequestId, applicantUserIdNumber, appointmentType.GetHashCode(), clientIPAddress));
                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        runAwayRequestId, applicantUserIdNumber, appointmentType.GetHashCode(), clientIPAddress));

                throw;
            }
        }

        /// <summary>
        /// Function Adds review result to Complaint request (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="reviewResults">The review results.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="resultsType">The update context</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg UpdateComplaintRequestByReviewResults(
            int runAwayRequestId, string reviewResults, long applicantUserIdNumber,
            TypedObjects.ReviewResultsType resultsType, string clientIPAddress)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(),
                runAwayRequestId, reviewResults, applicantUserIdNumber, resultsType.GetHashCode(), clientIPAddress));

            try
            {
                //==================================================================================
                using (ESPostRunAwayInstance = new PostRunAway())
                {
                    return ESPostRunAwayInstance.
                        UpdateComplaintRequestWithReviewResults(runAwayRequestId, reviewResults, applicantUserIdNumber, resultsType, clientIPAddress);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance, Utilities.FormatLogValues(
                    new dynamic[] { applicantUserIdNumber, argumentExceptionInstance.GetType().Name },
                    MethodBase.GetCurrentMethod(),
                    runAwayRequestId, reviewResults, applicantUserIdNumber, resultsType.GetHashCode(), clientIPAddress));
                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception, Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber, exception.GetType().Name },
                        MethodBase.GetCurrentMethod(),
                        runAwayRequestId, reviewResults, applicantUserIdNumber, resultsType.GetHashCode(), clientIPAddress));
                throw;
            }
        }

        #endregion

        #region "File Transfer Methods"

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="requestFileInfo">The request file information.</param>
        /// <param name="applicantUserIdNumber"></param>
        /// <returns>DownloadRequest.</returns>
        public DownloadRequest UploadFile(RemoteFileInfo requestFileInfo, long applicantUserIdNumber)
        {
            //=========================================================================================
            //Log calling Information
            CentralLogger.Info(Utilities.FormatLogValues(
                new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(), requestFileInfo.FileName, applicantUserIdNumber));

            try
            {
                using (var fileTransfer = new PostCommon())
                {
                    return fileTransfer.UploadFile(requestFileInfo);
                }
            }
            catch (ArgumentException argumentExceptionInstance)
            {
                //=========================================================================================
                //Log invalid argument parameters
                CentralLogger.Error(argumentExceptionInstance,
                   Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(), requestFileInfo.FileName, applicantUserIdNumber));
                throw;
            }
            catch (Exception exception)
            {
                //=========================================================================================
                //Log Operational Exceptions
                CentralLogger.Fatal(exception,
                    Utilities.FormatLogValues(
                        new dynamic[] { applicantUserIdNumber }, MethodBase.GetCurrentMethod(), requestFileInfo.FileName, applicantUserIdNumber));
                throw;
            }
        }

        #endregion
    }
}


