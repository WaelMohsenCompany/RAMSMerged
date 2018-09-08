// ***********************************************************************
// Assembly         : RAMS.EnterpriseServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="PostRunAway.svc.cs" company="Tasleem IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.Common;
using RAMS.ApplicationServices.Laborer.Get;
using RAMS.ApplicationServices.RunAwayRequest.Get;
using RAMS.ApplicationServices.RunAwayRequest.Post;
using RAMS.CrossCutting;
using RAMS.InfrastructureService.Get;
using RAMS.OracleIntegrationServices.NICManagement;
using System;
using System.Threading.Tasks;
using ComplaintCreateRequestInfo = RAMS.CrossCutting.ComplaintCreateRequestInfo;
using RunAwayCreateRequestInfo = RAMS.CrossCutting.RunAwayCreateRequestInfo;

namespace RAMS.EnterpriseServices.RunAway.Post
{
    /// <inheritdoc />
    /// <summary>
    /// Class PostRunAway.
    /// </summary>
    public class PostRunAway : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Post RunAway AS Instance
        /// </summary>
        /// <value>The Post Runaway client instance.</value>
        private PostRunAwayRequest PostRunAwayRequestInstance { get; set; }

        /// <summary>
        /// Get RunAway Request Instance
        /// </summary>
        /// <value>RunAway Request Instance.</value>
        private GetRunAwayRequest GetRunAwayRequestInstance { get; set; }

        /// <summary>
        /// Post NIC Operations Instance
        /// </summary>
        /// <value>NIC Operations Instance.</value>
        private PostNIC PostNicInstance { get; set; }

        /// <summary>
        /// Message Center instance
        /// </summary>
        /// <value>The message client instance.</value>
        private GetSystemMessages MessageClientInstance { get; set; }

        /// <summary>
        /// Get Laborer Instance
        /// </summary>
        /// <value>The get laborer instance.</value>
        private GetLaborer GetLaborerInstance { get; set; }

        /// <summary>
        /// Get Common Instance
        /// </summary>
        /// <value>The get Common instance.</value>
        private GetCommon GetCommonInstance { get; set; }

        #endregion

        #region " Public ESB Functions "

        #region "تقديم بلاغ تغيب"

        /// <summary>
        /// Function Creates RunAway request at MoL database (تقديم بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="rule2IsValid">
        /// CR Rule: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
        /// يقوم النظام بتحويل حالة العامل إلى متغيب عن العمل فى إنتظار نقل الخدمة مباشرة
        /// </param>
        /// 
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg CreateRunAwayRequest(RunAwayCreateRequestInfo requestInfo, bool rule2IsValid)
        {
            //==================================================================================
            //Check input parameters is valid
            if (requestInfo == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Check input parameters is valid
            if (requestInfo.CreationQuestion4.Length > 2000)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            ResponseMsg result;
            string requestNumber;

            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (PostNicInstance = new OracleIntegrationServices.NICManagement.PostNIC())
            using (GetLaborerInstance = new GetLaborer())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                // 1- Check with NIC if user can create RunAway Request
                //==================================================================================
                var laborerIdentifier =
                    // ReSharper disable once PossibleInvalidOperationException
                    requestInfo.LaborerIdNumber ?? requestInfo.LaborerBorderNumber.Value;

                result = PostRunAwayRequestInstance.ValidateAndCreateNICRequest(
                    laborerIdentifier, requestInfo.ApplicantUserIdNumber, requestInfo.CreatedByIdNumber);

                if (result.IsSuccess == false)
                {
                    //NIC refused to create a request. Return NIC response to caller
                    return result;
                }

                //==================================================================================
                //2- NIC Approved and created request, Call MoL to Create request
                //==================================================================================
                result = PostRunAwayRequestInstance.CreateRunAwayRequest(requestInfo, dbUnitOfWork);

                if (result.IsSuccess)
                {
                    //store request number to temp variable
                    requestNumber = result.ResponseText;

                    //==================================================================================                            
                    //Get Laborer Info
                    var laborerInfo = GetLaborerInstance.GetLaborerDetailsFromMoL(
                        requestInfo.LaborerIdNumber, requestInfo.LaborerBorderNumber, dbUnitOfWork);

                    //================================================================================== 
                    // Change Laborer Status in NIC to Runner + Waiting Sponsor Transfer    
                    // Special Rule2: "رخصة العمل والإقامة منتهية ولم يمضي على انتهاء الإقامة 30 يوما
                    if (rule2IsValid)
                        PostNicInstance.ChangeLaborerStatus(
                            laborerInfo.LaborerOfficeId,
                            (int)TypedObjects.SaudiFlags.NonSaudi,
                            (int)laborerInfo.LaborerSequenceNumber.Value,
                            TypedObjects.LaborerStatus.RunnerWaitingSponsorTransfer);

                    //================================================================================== 
                    //Set output system message
                    result.ResponseText =
                        MessageClientInstance.GetMessageBody(
                           TypedObjects.RAMSMSG03,
                                TypedObjects.LEFTTORIGHTFLIPPING + requestNumber,
                                TypedObjects.GetStatusName(
                                    TypedObjects.StatusType.RunAwayRequestStatus,
                                    TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode()));

                    //=====================================================================
                    // Send SMS Messages to Agent and Laborer
                    var sendEstablishmentSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendEstablishmentSMS(
                            TypedObjects.MessageType.CreateRunAwayRequest,
                            requestInfo.ApplicantUserIdNumber, null, dbUnitOfWork,
                            TypedObjects.LEFTTORIGHTFLIPPING + requestNumber,
                            TypedObjects.GetStatusName(
                                TypedObjects.StatusType.RunAwayRequestStatus,
                                TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode())));

                    sendEstablishmentSMS.Wait();

                    var sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendIndividualSMS(
                          TypedObjects.MessageType.CreateRunAwayRequest,
                          laborerInfo.MobileNumber, null, null, null, dbUnitOfWork,
                          TypedObjects.LEFTTORIGHTFLIPPING + requestNumber));

                    sendIndividualSMS.Wait();
                    return result;
                }
            }

            //=================================================================================
            //Set output system message to ERROR Message
            result.ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG00);
            return result;
        }

        #endregion

        #region "إدارة بلاغ تغيب"

        /// <summary>
        /// Function Cancels RunAway request at MoL database (إلغاء بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg CancelRunAwayRequest(RunAwayCancelRequestInfo requestInfo)
        {
            //==================================================================================
            //Check input parameters is valid
            if (requestInfo == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Check input parameters is valid
            if (requestInfo.CancelReason.Length > 2000)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            var results = new ResponseMsg();

            using (var dbUnitOfWork = new UnitOfWork())
            using (GetRunAwayRequestInstance = new GetRunAwayRequest())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (MessageClientInstance = new GetSystemMessages())
            using (GetLaborerInstance = new GetLaborer())
            {
                //==================================================================================
                //Get Startup Data
                var fullRequestInfo = GetRunAwayRequestInstance.GetRunAwayRequestInfo(
                    requestInfo.RequestNumber, dbUnitOfWork);

                //==================================================================================
                // 1- Check with NIC if user can create RunAway Request
                //==================================================================================
                var laborerIdentifier =
                    // ReSharper disable once PossibleInvalidOperationException
                    fullRequestInfo.LaborerIdNumber ?? fullRequestInfo.LaborerBorderNumber.Value;

                results = PostRunAwayRequestInstance.ValidateAndCancelNICRunAway(
                    laborerIdentifier, requestInfo.ApplicantUserIdNumber,
                    requestInfo.CancelReason, requestInfo.CreatedByIdNumber);

                if (!results.IsSuccess)
                    return results;

                //==================================================================================
                //2- NIC Approved and canceled the request, Call MoL to cancel the request
                //==================================================================================
                results = PostRunAwayRequestInstance.CancelRunAwayRequest(requestInfo, dbUnitOfWork);

                if (results.IsSuccess)
                {
                    //==================================================================================
                    //4- Change Laborer Status to "متغيب عن العمل" in Oracle DB
                    //==================================================================================                            
                    //Get Laborer Info
                    var laborerInfo = GetLaborerInstance.GetLaborerDetailsFromMoL(
                        fullRequestInfo.LaborerIdNumber, fullRequestInfo.LaborerBorderNumber, dbUnitOfWork);

                    //Set output system message
                    results.ResponseText =
                        MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG24, TypedObjects.LEFTTORIGHTFLIPPING + requestInfo.RequestNumber);

                    //=====================================================================
                    // Send SMS Messages to Agent and Laborer
                    var sendEstablishmentSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendEstablishmentSMS(
                            TypedObjects.MessageType.CancelRunAwayRequest,
                            requestInfo.ApplicantUserIdNumber, null, dbUnitOfWork,
                            TypedObjects.LEFTTORIGHTFLIPPING + requestInfo.RequestNumber));
                    sendEstablishmentSMS.Wait();

                    var sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendIndividualSMS(
                          TypedObjects.MessageType.CancelRunAwayRequest,
                          laborerInfo.MobileNumber, null, null, fullRequestInfo.RequestId, dbUnitOfWork,
                          TypedObjects.LEFTTORIGHTFLIPPING + requestInfo.RequestNumber));

                    sendIndividualSMS.Wait();

                    return results;
                }

                //Set output system message
                results.ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG00);

                return results;
            }
        }

        #endregion

        #region "طلب إثبات كيدية بلاغ تغيب"

        /// <summary>
        /// Function Creates Complaint request at MoL database (طلب إثبات كيدية بلاغ تغيب )
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg CreateRunAwayComplaintRequest(ComplaintCreateRequestInfo requestInfo)
        {
            //==================================================================================
            //Check input parameters is valid
            if (requestInfo == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Check input parameters is valid
            if (requestInfo.ComplaintQuestion4.Length > 2000)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                //1- Call MoL to Create Complaint request                
                var results = PostRunAwayRequestInstance.CreateRunAwayComplaintRequest(requestInfo, dbUnitOfWork);

                //Set output system message
                if (results.IsSuccess)
                {
                    results.ResponseText = MessageClientInstance.GetMessageBody(
                        TypedObjects.RAMSMSG10, TypedObjects.GetStatusName(
                            TypedObjects.StatusType.ComplaintRequestStatus,
                            TypedObjects.ComplaintRequestStatus.UnderProcessing.GetHashCode()));

                    //=====================================================================
                    // Send SMS Messages to Agent and Laborer
                    var sendEstablishmentSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendEstablishmentSMS(
                            TypedObjects.MessageType.CreateComplaintRequest,
                            null, requestInfo.RunAwayRequestId, dbUnitOfWork,
                            TypedObjects.LEFTTORIGHTFLIPPING + requestInfo.RequestNumber));

                    sendEstablishmentSMS.Wait();

                    Task sendIndividualSMS;
                    if (requestInfo.IsRequestByLaborer)
                        sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                            PostRunAwayRequestInstance.SendIndividualSMS(
                                TypedObjects.MessageType.CreateComplaintRequest,
                                null, requestInfo.LaborerIdNumber, null, null, dbUnitOfWork,
                                TypedObjects.GetStatusName(
                                    TypedObjects.StatusType.ComplaintRequestStatus,
                                    TypedObjects.ComplaintRequestStatus.UnderProcessing.GetHashCode())));
                    else
                        sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                            PostRunAwayRequestInstance.SendIndividualSMS(
                                TypedObjects.MessageType.CreateComplaintRequest,
                                requestInfo.LaborerMobileNo, null, null, null, dbUnitOfWork,
                                TypedObjects.GetStatusName(
                                    TypedObjects.StatusType.ComplaintRequestStatus,
                                    TypedObjects.ComplaintRequestStatus.UnderProcessing.GetHashCode())));

                    sendIndividualSMS.Wait();
                }
                else
                    results.ResponseText =
                        MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG00);

                return results;
            }
        }

        #endregion

        #region "البت في بلاغ التغيب"

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg CreateRunAwayReviewRequest(int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress)
        {
            //==================================================================================
            //Check input parameters is valid
            if (runAwayRequestId <= 0 || applicantUserIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new ApplicationServices.RunAwayRequest.Post.PostRunAwayRequest())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                //1- Update Status and Laborer Office for Review
                //==================================================================================
                var results = PostRunAwayRequestInstance.CreateRunAwayReviewRequest(
                    runAwayRequestId, applicantUserIdNumber, clientIPAddress, dbUnitOfWork);

                results.ResponseText = MessageClientInstance.GetMessageBody(results.IsSuccess ?
                    TypedObjects.RAMSMSG17 : TypedObjects.RAMSMSG00);

                return results;
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
            //==================================================================================
            //Check input parameters is valid
            if (runAwayRequestId <= 0 || applicantUserIdNumber <= 0 || rejectionReason.Trim().Length <= 0 || rejectionReason.Length > 2000)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                //Update Status to rejected
                var results = PostRunAwayRequestInstance.
                    RejectComplaintRequest(
                        runAwayRequestId, rejectionReason, applicantUserIdNumber, clientIPAddress, dbUnitOfWork);

                results.ResponseText = MessageClientInstance.GetMessageBody(
                    results.IsSuccess ? TypedObjects.RAMSMSG18 : TypedObjects.RAMSMSG00);

                //=================================================================================
                var requestContactInfo =
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetRequestContactInfo(runAwayRequestId);

                //Send SMS Messages to Agent and Laborer
                var sendEstablishmentSMS = Task<bool>.Factory.StartNew(() =>
                    PostRunAwayRequestInstance.SendEstablishmentSMS(
                        TypedObjects.MessageType.ApproveCompliantRequestResult,
                        requestContactInfo.RunAwayApplicantUserId, null, dbUnitOfWork,
                        TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                        TypedObjects.GetStatusName(
                            TypedObjects.StatusType.RunAwayRequestStatus,
                            TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode())));

                sendEstablishmentSMS.Wait();

                Task sendIndividualSMS;
                if (string.IsNullOrEmpty(requestContactInfo.LaborerMobileNo))
                {
                    sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendIndividualSMS(
                            TypedObjects.MessageType.ApproveCompliantRequestResult,
                            null, requestContactInfo.ComplaintApplicantUserId, null, null, dbUnitOfWork,
                            TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                            TypedObjects.GetStatusName(
                                TypedObjects.StatusType.ComplaintRequestStatus,
                                TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode())));
                }
                else
                {
                    sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                       PostRunAwayRequestInstance.SendIndividualSMS(
                           TypedObjects.MessageType.ApproveCompliantRequestResult,
                           requestContactInfo.LaborerMobileNo, null, null, null, dbUnitOfWork,
                           TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                           TypedObjects.GetStatusName(
                               TypedObjects.StatusType.ComplaintRequestStatus,
                               TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode())));
                }
                sendIndividualSMS.Wait();

                return results;
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
            //==================================================================================
            //Check input parameters is valid
            if (runAwayRequestId <= 0 || applicantUserIdNumber <= 0)
            {
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            //==================================================================================
            //Initialize Service Object(s)
            ResponseMsg results;

            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (GetRunAwayRequestInstance = new GetRunAwayRequest())
            using (GetLaborerInstance = new GetLaborer())
            using (PostNicInstance = new PostNIC())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                //1- Update Status and Laborer Office for Review
                results = PostRunAwayRequestInstance.AcceptComplaintRequest(
                    runAwayRequestId, applicantUserIdNumber, clientIPAddress, dbUnitOfWork);

                //===================================================================================
                if (results.IsSuccess)
                {
                    //==================================================================================
                    //2- Get request Startup data
                    var requestInfo =
                        GetRunAwayRequestInstance.GetRunAwayRequestInfo(runAwayRequestId, dbUnitOfWork);

                    //Get Laborer Info
                    var laborerInfo =
                        GetLaborerInstance.GetLaborerDetailsFromMoL(requestInfo.LaborerIdNumber, requestInfo.LaborerBorderNumber, dbUnitOfWork);

                    //==================================================================================
                    // 2- Change Laborer Status in NIC to Working + Waiting Sponsor Transfer                 
                    results = PostNicInstance.ChangeLaborerStatus(
                        laborerInfo.LaborerOfficeId,
                        (int)TypedObjects.SaudiFlags.NonSaudi,
                        (int)laborerInfo.LaborerSequenceNumber.Value,
                        TypedObjects.LaborerStatus.WorkingWaitingSponsorTransfer);

                    if (results.IsSuccess)
                    {
                        //==================================================================================
                        //5- Set Establishment Note       
                        //////try
                        //////{
                        //////    results = PostRunAwayRequestInstance.SetRunAwayEstablishmentNote(
                        //////          Convert.ToInt64(requestInfo.EstablishmentId.Trim()),
                        //////          applicantUserIdNumber, "ملاحظة بلاغ تغيب", dbUnitOfWork);
                        //////}
                        //////catch (Exception exception)
                        //////{
                        //////    //===============================================================================
                        //////    //Log Operational Exceptions
                        //////    var centralLogger = NLog.LogManager.GetCurrentClassLogger();
                        //////    centralLogger.Fatal(exception, Utilities.FormatComplexLogValues(
                        //////        new dynamic[] { runAwayRequestId, applicantUserIdNumber }, results));

                        //////    results.IsSuccess = true;
                        //////    results.ResponseText = "TOTO Mission, Cancel this try catch";
                        //////}

                        if (results.IsSuccess)
                        {
                            ////////Insert Note ID & Number to Runaway Table
                            //////results =
                            //////    PostRunAwayRequest.UpdateRunAwayRequestWithNoteInfo(
                            //////        requestInfo.RequestId, Convert.ToInt32(results.ResponseText), dbUnitOfWork);

                            ////////Successfully updated the request
                            //////results.ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG19);

                            //=================================================================================
                            var requestContactInfo =
                                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetRequestContactInfo(runAwayRequestId);

                            //Send SMS Messages to Agent and Laborer
                            var sendEstablishmentSMS = Task<bool>.Factory.StartNew(() =>
                                PostRunAwayRequestInstance.SendEstablishmentSMS(
                                    TypedObjects.MessageType.ApproveCompliantRequestResult,
                                    requestContactInfo.RunAwayApplicantUserId, null, dbUnitOfWork,
                                    TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                                    TypedObjects.GetStatusName(
                                        TypedObjects.StatusType.RunAwayRequestStatus,
                                        TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode())));

                            sendEstablishmentSMS.Wait();

                            Task sendIndividualSMS;
                            if (string.IsNullOrEmpty(requestContactInfo.LaborerMobileNo))
                            {
                                sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                                    PostRunAwayRequestInstance.SendIndividualSMS(
                                        TypedObjects.MessageType.ApproveCompliantRequestResult,
                                        null, requestContactInfo.ComplaintApplicantUserId, null, null, dbUnitOfWork,
                                        TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                                        TypedObjects.GetStatusName(
                                            TypedObjects.StatusType.ComplaintRequestStatus,
                                            TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode())));
                            }
                            else
                            {
                                sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                                   PostRunAwayRequestInstance.SendIndividualSMS(
                                       TypedObjects.MessageType.ApproveCompliantRequestResult,
                                       requestContactInfo.LaborerMobileNo, null, null, null, dbUnitOfWork,
                                       TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                                       TypedObjects.GetStatusName(
                                           TypedObjects.StatusType.ComplaintRequestStatus,
                                           TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode())));
                            }
                            sendIndividualSMS.Wait();

                            return results;
                        }
                    }
                }
            }

            //Error Happened
            results.ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG00);
            results.IsSuccess = false;
            return results;
        }

        #endregion

        #region "تدقيق بلاغ التغيب "

        /// <summary>
        /// Function updates status of Complaint request to - تم تحديد موعد للمراجعة
        /// تدقيق بلاغ التغيب بمكتب العمل
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg UpdateComplaintRequestByReviewAppointment(int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress)
        {
            //==================================================================================
            //Check input parameters is valid
            if (runAwayRequestId <= 0 || applicantUserIdNumber <= 0)
            {
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                //1- Update Status and Laborer Office for Review
                var results = PostRunAwayRequestInstance.UpdateComplaintRequestByReviewAppointment(
                    runAwayRequestId, applicantUserIdNumber, clientIPAddress, dbUnitOfWork);

                //===================================================================================
                results.ResponseText =
                    MessageClientInstance.GetMessageBody(results.IsSuccess ? TypedObjects.RAMSMSG20 : TypedObjects.RAMSMSG00);

                return results;
            }
        }

        /// <summary>
        /// Function Adds review result to Complaint request (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="reviewResults">The review results.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="resultsType">Review close type</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public ResponseMsg UpdateComplaintRequestWithReviewResults(
            int runAwayRequestId, string reviewResults, long applicantUserIdNumber,
            TypedObjects.ReviewResultsType resultsType,
            string clientIPAddress)
        {
            //==================================================================================
            //Check input parameters is valid
            if (runAwayRequestId <= 0 || reviewResults.Trim().Length == 0 || applicantUserIdNumber <= 0 || reviewResults.Length > 2000)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //==================================================================================
            //Initialize Service Object(s)
            using (var dbUnitOfWork = new UnitOfWork())
            using (PostRunAwayRequestInstance = new PostRunAwayRequest())
            using (MessageClientInstance = new GetSystemMessages())
            {
                //==================================================================================
                //1- Update Status to (تمت الإفادة من مكتب العمل)
                var results = PostRunAwayRequestInstance.UpdateComplaintRequestWithReviewResults(
                    runAwayRequestId, reviewResults, applicantUserIdNumber, resultsType, clientIPAddress, dbUnitOfWork);

                //===================================================================================
                if (results.IsSuccess)
                {
                    //Successfully updated the request
                    results.ResponseText =
                        resultsType == TypedObjects.ReviewResultsType.FinalResult ?
                            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG21) :
                            MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG29);
                    return results;
                }
                else
                {
                    //Failed to updated the request
                    results.ResponseText = MessageClientInstance.GetMessageBody(TypedObjects.RAMSMSG00);
                    return results;
                }
            }
        }

        /// <summary>
        /// Function sends a message for Establishment and Laborer (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="appointmentType">Review Appointment Type</param>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <returns>True or False.</returns>
        /// <exception cref="System.ArgumentException">Invalid Argument Value Exception.</exception>
        public void SendTimeForEstablishmentAndLaborer(TypedObjects.ReviewAppointmentType appointmentType, int runAwayRequestId)
        {
            using (GetCommonInstance = new GetCommon())
            using (var dbUnitOfWork = new UnitOfWork())
            {
                //=================================================================================
                var requestContactInfo =
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetRequestContactInfo(runAwayRequestId);

                var appointmentDateTime =
                    requestContactInfo.CreatedOn.AddDays(
                        GetCommonInstance.GetSystemSettings(TypedObjects.SystemSettings.MaximumDaysToRunAwayAppointment,
                            dbUnitOfWork));

                if (appointmentType == TypedObjects.ReviewAppointmentType.EstablishmentAppointment ||
                    appointmentType == TypedObjects.ReviewAppointmentType.LaborerAndEstablishmentAppointment)
                {
                    //Send SMS Messages to Agent and Laborer
                    var sendEstablishmentSMS = Task<bool>.Factory.StartNew(() =>
                        PostRunAwayRequestInstance.SendEstablishmentSMS(
                            TypedObjects.MessageType.ReviewAppointment,
                            requestContactInfo.RunAwayApplicantUserId, null, dbUnitOfWork,
                            TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                            appointmentDateTime.ToShortTimeString()));

                    sendEstablishmentSMS.Wait();
                }

                if (appointmentType == TypedObjects.ReviewAppointmentType.LaborerAppointment ||
                    appointmentType == TypedObjects.ReviewAppointmentType.LaborerAndEstablishmentAppointment)
                {
                    Task sendIndividualSMS;
                    if (string.IsNullOrEmpty(requestContactInfo.LaborerMobileNo))
                    {
                        sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                            PostRunAwayRequestInstance.SendIndividualSMS(
                                TypedObjects.MessageType.ApproveCompliantRequestResult,
                                null, requestContactInfo.ComplaintApplicantUserId, null, null, dbUnitOfWork,
                                TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                                appointmentDateTime.ToShortTimeString()));
                    }
                    else
                    {
                        sendIndividualSMS = Task<bool>.Factory.StartNew(() =>
                           PostRunAwayRequestInstance.SendIndividualSMS(
                                TypedObjects.MessageType.ApproveCompliantRequestResult,
                                requestContactInfo.LaborerMobileNo, null, null, null, dbUnitOfWork,
                                TypedObjects.LEFTTORIGHTFLIPPING + requestContactInfo.RequestNumber,
                                appointmentDateTime.ToShortTimeString()));
                    }

                    sendIndividualSMS.Wait();
                }
            }
        }
        #endregion

        #endregion
    }
}
