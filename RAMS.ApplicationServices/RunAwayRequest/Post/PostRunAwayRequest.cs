// ***********************************************************************
// Assembly         : RAMS.ApplicationServices
// Author           : WaelMohsen
// Created          : 01-29-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 04-04-2018
// ***********************************************************************
// <copyright file="PostRunAwayRequest.svc.cs" company="Tasleem IT for MLSD">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Mol.ComponentLayer.Search;
using Mol.Entities;
using Mol.Integration.ServiceWrapper.NoteService;
using Mol.Integration.ServiceWrapper.NoteService.NoteServiceReference;
using MOL.EFDAL.Repository;
using RAMS.ApplicationServices.ExReferenceSMSService;
using RAMS.CrossCutting;
using RAMS.InfrastructureService.Get;
using System;
using System.Linq;

namespace RAMS.ApplicationServices.RunAwayRequest.Post
{
    /// <inheritdoc />
    /// <summary>
    /// Class PostRunAwayRequest.
    /// </summary>
    /// <seealso cref="T:RAMS.CrossCutting.BaseDisposeClass" />
    public class PostRunAwayRequest : BaseDisposeClass
    {
        #region "Private Members"

        /// <summary>
        /// Runaway Requester instance
        /// </summary>
        /// <value>The Runaway Requester instance.</value>
        private ExReferenceNICRunAway.NICServiceClient RunawayRequesterInstance { get; set; }

        /// <summary>
        /// Runaway Requester instance
        /// </summary>
        /// <value>The Runaway Requester instance.</value>
        private ExReferenceSMSService.NotificationServiceClient NotificationServiceInstance { get; set; }

        /// <summary>
        /// File Transfer Service Instance
        /// </summary>
        /// <value>The File Transfer instance.</value>
        private InfrastructureService.FileTransfer.FileTransferService FileTransferServiceInstance { get; set; }

        /// <summary>
        /// Message Center instance
        /// </summary>
        /// <value>The message client instance.</value>
        private GetSystemMessages MessageClientInstance { get; set; }

        #endregion

        #region "Private NIC Functions"

        #region "NIC Creation Functions "

        /// <summary>
        /// Wrapper function checks if user can Create a new RunAway Request for target Laborer
        /// </summary>
        /// <param name="laborerIdentifier">Laborer ID Number</param>
        /// <param name="applicantUserIdNumber">Establishment Agent who initiated the request</param>
        /// <param name="runawayDate">RunAway Hijri Data in NIC format (yyyyMMdd)</param>
        /// <param name="createdByIdNumber">The operator who currently opens the session and sends the request (Establishment Agent / MLSD Employee)</param>
        /// <returns>ResponseMsg Result</returns>
        private ResponseMsg ValidateCreateNICRunaway(long laborerIdentifier, long applicantUserIdNumber, int runawayDate, long createdByIdNumber)
        {
            return CreateNICRunaway(true, laborerIdentifier, applicantUserIdNumber, runawayDate, createdByIdNumber);
        }

        /// <summary>
        /// Wrapper function Creates a new RunAway Request for target Laborer
        /// </summary>
        /// <param name="laborerIdentifier">Laborer ID Number</param>
        /// <param name="applicantUserIdNumber">Establishment Agent who initiated the request</param>
        /// <param name="runawayDate">RunAway Hijri Data in NIC format (yyyyMMdd)</param>
        /// <param name="createdByIdNumber">The operator who currently opens the session and sends the request (Establishment Agent / MLSD Employee)</param>
        /// <returns>ResponseMsg Result</returns>
        private ResponseMsg ConfirmCreateNICRunaway(long laborerIdentifier, long applicantUserIdNumber, int runawayDate, long createdByIdNumber)
        {
            return CreateNICRunaway(false, laborerIdentifier, applicantUserIdNumber, runawayDate, createdByIdNumber);
        }

        /// <summary>
        /// Function Checks/Create a new RunAway Request for target Laborer
        /// </summary>
        /// <param name="validate">True to Validate Business Rules only. False to Create the request</param>
        /// <param name="laborerIdentifier">Laborer ID Number</param>
        /// <param name="applicantUserIdNumber">Establishment Agent who initiated the request</param>
        /// <param name="runawayDate">RunAway Hijri Data in NIC format (yyyyMMdd)</param>
        /// <param name="createdByIdNumber">The operator who currently opens the session and sends the request (Establishment Agent / MLSD Employee)</param>
        /// <returns>ResponseMsg Result</returns>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        private ResponseMsg CreateNICRunaway(bool validate, long laborerIdentifier, long applicantUserIdNumber, int runawayDate, long createdByIdNumber)
        {
            //Check Input parameters are valid
            if (laborerIdentifier <= 0 || applicantUserIdNumber <= 0 || runawayDate <= 0 || createdByIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var validCreateResponse = new ResponseMsg();

            using (RunawayRequesterInstance = new ExReferenceNICRunAway.NICServiceClient())
            {
                //Set user name and password for NIC Service
                if (RunawayRequesterInstance.ClientCredentials == null)
                {
                    throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);
                }

                RunawayRequesterInstance.ClientCredentials.UserName.UserName =
                  Utilities.SecureStringToString(Utilities.NICNameInfo);
                RunawayRequesterInstance.ClientCredentials.UserName.Password =
                      Utilities.SecureStringToString(Utilities.NICCicoCicoInfo);

                //Call creation service
                var validCreateResult = RunawayRequesterInstance.CreateRunaway(validate, laborerIdentifier,
                    applicantUserIdNumber, runawayDate, createdByIdNumber);

                validCreateResponse.ResponseText = validCreateResult.Message;
                validCreateResponse.RuleTypeId = "Validation: " + validate;

                //Check if returned NIC is Success Message
                validCreateResponse.IsSuccess = validCreateResult.Code == 0;
            }

            return validCreateResponse;
        }

        #endregion

        #region "NIC Cancellation Function"

        /// <summary>
        /// Wrapper function checks if user can Cancel a RunAway Request for target Laborer
        /// </summary>
        /// <param name="laborerIdentifier">Laborer ID Number</param>
        /// <param name="applicantUserIdNumber">Establishment Agent who initiated the request</param>
        /// <param name="cancelDescription">Cancellation Description</param>
        /// <param name="createdByIdNumber">The operator who currently opens the session and sends the request (Establishment Agent / MLSD Employee)</param>
        /// <returns>ResponseMsg Result</returns>
        private ResponseMsg ValidateCancelNICRunaway(long laborerIdentifier, long applicantUserIdNumber, string cancelDescription, long createdByIdNumber)
        {
            return CancelNICRunaway(true, laborerIdentifier, applicantUserIdNumber, cancelDescription, createdByIdNumber);
        }

        /// <summary>
        /// Wrapper function Cancels a RunAway Request for target Laborer
        /// </summary>
        /// <param name="laborerIdentifier">Laborer ID Number</param>
        /// <param name="applicantUserIdNumber">Establishment Agent who initiated the request</param>
        /// <param name="cancelDescription">Cancellation Description</param>
        /// <param name="createdByIdNumber">The operator who currently opens the session and sends the request (Establishment Agent / MLSD Employee)</param>
        /// <returns>ResponseMsg Result</returns>
        private ResponseMsg ConfirmCancelNICRunaway(long laborerIdentifier, long applicantUserIdNumber, string cancelDescription, long createdByIdNumber)
        {
            return CancelNICRunaway(false, laborerIdentifier, applicantUserIdNumber, cancelDescription, createdByIdNumber);
        }

        /// <summary>
        /// Function Checks/Cancel a new RunAway Request for target Laborer
        /// </summary>
        /// <param name="validate">True to Validate Business Rules only. False to Cancel the request</param>
        /// <param name="laborerIdentifier">Laborer ID Number</param>
        /// <param name="applicantUserIdNumber">Establishment Agent who initiated the request</param>
        /// <param name="cancelDescription">Cancellation Description</param>
        /// <param name="createdByIdNumber">The operator who currently opens the session and sends the request (Establishment Agent / MLSD Employee)</param>
        /// <returns>ResponseMsg Result</returns>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        private ResponseMsg CancelNICRunaway(bool validate, long laborerIdentifier, long applicantUserIdNumber, string cancelDescription, long createdByIdNumber)
        {
            //Check Input parameters are valid
            if (laborerIdentifier <= 0 || cancelDescription.Trim().Length <= 0 || applicantUserIdNumber <= 0 || createdByIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var validCancelResponse = new ResponseMsg();

            using (RunawayRequesterInstance = new ExReferenceNICRunAway.NICServiceClient())
            {
                //Set user name and password for NIC Service
                if (RunawayRequesterInstance.ClientCredentials == null)
                    throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

                RunawayRequesterInstance.ClientCredentials.UserName.UserName =
                  Utilities.SecureStringToString(Utilities.NICNameInfo);
                RunawayRequesterInstance.ClientCredentials.UserName.Password =
                      Utilities.SecureStringToString(Utilities.NICCicoCicoInfo);

                //Call cancel service
                var validCancelResult = RunawayRequesterInstance.CancelRunaway(validate, laborerIdentifier, applicantUserIdNumber, cancelDescription, createdByIdNumber);

                //Check if returned NIC is Success Message
                validCancelResponse.IsSuccess = validCancelResult.Code == 0;

                validCancelResponse.ResponseText = validCancelResult.Message;
                validCancelResponse.RuleTypeId = string.Format("CancelNICRunaway.Validate: {0}", validate);
            }

            return validCancelResponse;
        }

        #endregion

        #endregion

        #region "Public Services"

        #region "تقديم بلاغ تغبب"

        /// <summary>
        /// Function Creates RunAway request at NIC database (تقديم بلاغ تغيب عامل)
        /// </summary>
        /// <param name="laborerIdNumber">The laborer identifier number.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier.</param>
        /// <param name="createdByIdNumber">The created by.</param>
        /// <returns>ResponseMsg.</returns>
        public ResponseMsg ValidateAndCreateNICRequest(long laborerIdNumber, long applicantUserIdNumber, long createdByIdNumber)
        {
            var runawayDate = DateTime.Now;

            var validationResult = ValidateCreateNICRunaway(laborerIdNumber, applicantUserIdNumber, Utilities.ConvertToNICHijriFormate(runawayDate), createdByIdNumber);

            return validationResult.IsSuccess ?
                ConfirmCreateNICRunaway(laborerIdNumber, applicantUserIdNumber, Utilities.ConvertToNICHijriFormate(runawayDate), createdByIdNumber) :
                validationResult;
        }

        /// <summary>
        /// Function Creates RunAway request at MoL database (تقديم بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg CreateRunAwayRequest(RunAwayCreateRequestInfo requestInfo, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || requestInfo == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            //Initialize Instances
            using (FileTransferServiceInstance = new InfrastructureService.FileTransfer.FileTransferService())
            {
                //========================================================
                //1- Create Runaway request object
                var dbRequestInfo = new MOL.EFDAL.ComplexTypes.RunAwayCreateRequestInfo
                {
                    LaborerOfficeId = requestInfo.LaborerOfficeId,
                    SequenceNumber = requestInfo.SequenceNumber,
                    EstablishmentId = requestInfo.EstablishmentId,
                    EstablishmentTitle = requestInfo.EstablishmentTitle,
                    LaborerIdNumber = requestInfo.LaborerIdNumber,
                    LaborerBorderNumber = requestInfo.LaborerBorderNumber,
                    LaborerFullName = requestInfo.LaborerFullName,
                    FilesPaths = requestInfo.FilesPaths,

                    Question1 = requestInfo.CreationQuestion1,
                    Question2 = requestInfo.CreationQuestion2,
                    Question3 = requestInfo.CreationQuestion3,
                    Question4 = requestInfo.CreationQuestion4,

                    IsRequestByEstablishmentAgent = requestInfo.IsRequestByEstablishmentAgent,
                    ApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber,
                    CreatedByIdNumber = requestInfo.CreatedByIdNumber,
                    ClientIPAddress = requestInfo.ClientIPAddress
                };

                //===========================================================================================
                //2- Call EF to create the new request
                var requestNumber =
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.CreateRunAwayRequest(
                        dbRequestInfo, TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode());

                if (requestNumber.Trim().Length > 0)
                {
                    //===========================================================================================
                    //3- Move Files to New Folder, then
                    //4- Call EF to Save Files to DB
                    var newFiles = FileTransferServiceInstance.MoveFile(
                        requestInfo.FilesPaths.ToList(), requestNumber, TypedObjects.RunAwayCreateRequestFileTitle);

                    //Send files paths and request number to save its information to DB
                    var fileResults = dbUnitOfWork.MOL_RAMS_RunAway_Files_Repository.AddFiles(
                      Convert.ToInt32(requestNumber.Split('-')[2]), newFiles.ToArray());

                    //===========================================================================================
                    if (fileResults)
                        return new ResponseMsg
                        {
                            IsSuccess = true,
                            ResponseText = requestNumber
                        };
                }

                return new ResponseMsg
                {
                    IsSuccess = false
                };
            }
        }

        /// <summary>
        /// Function updates the run away request with note information.
        /// </summary>
        /// <param name="runAwayRequestId">Identifier for the request.</param>
        /// <param name="noteId">Identifier for the note.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern.</param>
        /// <returns>A ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <remarks>Wael Mohsen, 2018-04-29.</remarks>
        public static ResponseMsg UpdateRunAwayRequestWithNoteInfo(int runAwayRequestId, int noteId, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || runAwayRequestId <= 0 || noteId <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return new ResponseMsg
            {
                IsSuccess =
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.UpdateRunAwayRequestWithNoteInfo(runAwayRequestId, noteId)
            };
        }

        #endregion

        #region "إلغاء بلاغ تغيب"

        /// <summary>
        /// Function Creates RunAway request at NIC database (إلغاء بلاغ تغيب عامل)
        /// </summary>
        /// <param name="laborerIdentifier">The laborer identifier number.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier.</param>
        /// <param name="cancelReason">The cancel reason.</param>
        /// <param name="createdByIdNumber">The created by.</param>
        /// <returns>ResponseMsg.</returns>
        public ResponseMsg ValidateAndCancelNICRunAway(
           long laborerIdentifier, long applicantUserIdNumber, string cancelReason, long createdByIdNumber)
        {
            var validationResult = ValidateCancelNICRunaway(laborerIdentifier, applicantUserIdNumber, cancelReason, createdByIdNumber);

            return validationResult.IsSuccess ?
                ConfirmCancelNICRunaway(laborerIdentifier, applicantUserIdNumber, cancelReason, createdByIdNumber) :
                validationResult;
        }

        /// <summary>
        /// Function Cancels RunAway request at MoL database (إلغاء بلاغ تغيب عامل)
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg CancelRunAwayRequest(RunAwayCancelRequestInfo requestInfo, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || requestInfo == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            //Initialize Instances
            using (FileTransferServiceInstance = new InfrastructureService.FileTransfer.FileTransferService())
            {
                //========================================================
                //1- Create Runaway request object
                var dbRequestInfo = new MOL.EFDAL.ComplexTypes.RunAwayCancelRequestInfo
                {
                    RequestNumber = requestInfo.RequestNumber,
                    CancelReason = requestInfo.CancelReason,
                    FilesPaths = requestInfo.FilesPaths,
                    CancelQuestion1 = requestInfo.CancelQuestion1,
                    ApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber,
                    CreatedByIdNumber = requestInfo.CreatedByIdNumber,
                    ClientIPAddress = requestInfo.ClientIPAddress
                };

                //===========================================================================================
                //2- Call EF to create the new request
                if (dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.CancelRunAwayRequest(
                    dbRequestInfo, TypedObjects.RunAwayRequestStatus.Canceled.GetHashCode()))
                {
                    //===========================================================================================
                    //3- Move Files to New Folder, then
                    //4- Call EF to Save Files to DB
                    var newFiles = FileTransferServiceInstance.MoveFile(
                        requestInfo.FilesPaths.ToList(), requestInfo.RequestNumber, TypedObjects.RunAwayCancelRequestFileTitle);

                    //Send files paths and request number to save its information to DB
                    var fileResults = dbUnitOfWork.MolRamsCancelRunAwayFilesRepository.AddFiles(
                      Convert.ToInt32(requestInfo.RequestNumber.Split('-')[2]), newFiles.ToArray());

                    //===========================================================================================
                    if (fileResults)
                        return new ResponseMsg
                        {
                            IsSuccess = true,
                            RuleTypeId = System.Reflection.MethodBase.GetCurrentMethod().Name
                        };
                    else
                        return new ResponseMsg
                        {
                            IsSuccess = false,
                            RuleTypeId = System.Reflection.MethodBase.GetCurrentMethod().Name + ".Files Operations"
                        };
                }
                else
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = System.Reflection.MethodBase.GetCurrentMethod().Name
                    };
            }
        }

        #endregion

        #region "طلب إثبات كيدية بلاغ"

        /// <summary>
        /// Function Creates Complaint request at MoL database (طلب إثبات كيدية بلاغ تغيب )
        /// </summary>
        /// <param name="requestInfo">The request information.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg CreateRunAwayComplaintRequest(ComplaintCreateRequestInfo requestInfo, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || requestInfo == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            //Initialize Instances
            using (FileTransferServiceInstance = new InfrastructureService.FileTransfer.FileTransferService())
            {
                //=========================================================================
                //1- Create Runaway request object
                var dbRequestInfo = new MOL.EFDAL.ComplexTypes.ComplaintCreateRequestInfo
                {
                    RunAwayRequestId = requestInfo.RunAwayRequestId,
                    FilesPaths = requestInfo.FilesPaths,

                    ComplaintQuestion1 = requestInfo.ComplaintQuestion1,
                    ComplaintQuestion2 = requestInfo.ComplaintQuestion2,
                    ComplaintQuestion3 = requestInfo.ComplaintQuestion3,
                    ComplaintQuestion4 = requestInfo.ComplaintQuestion4,

                    IsRequestByLaborer = requestInfo.IsRequestByLaborer,
                    ApplicantUserIdNumber = requestInfo.ApplicantUserIdNumber,
                    CreatedByIdNumber = requestInfo.CreatedByIdNumber,

                    LaborerMobileNo = requestInfo.LaborerMobileNo,
                    ClientIPAddress = requestInfo.ClientIPAddress
                };

                //=========================================================================
                // 2- Call EF to create the new request 
                // Initial request status is UnderProcessing
                var complaintId =
                    dbUnitOfWork.MOL_RunAwayComplaints_Repository.CreateRunAwayComplaintRequest(
                        dbRequestInfo, TypedObjects.ComplaintRequestStatus.UnderProcessing.GetHashCode());

                //Check if error happened while creating the complaint request
                if (complaintId <= 0)
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = "CreateRunAwayComplaintRequest"
                    };

                //=========================================================================
                //3- Change Runaway Request status to UnderProcessing
                var results =
                    dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.ChangeRunAwayRequestStatus(
                        requestInfo.RunAwayRequestId,
                        TypedObjects.RunAwayRequestStatus.UnderProcessing.GetHashCode(),
                        requestInfo.CreatedByIdNumber, requestInfo.ApplicantUserIdNumber, requestInfo.ClientIPAddress);

                //Check if error happened while creating the complaint request
                if (!results)
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = "ChangeRunAwayRequestStatus"
                    };

                //=========================================================================
                //4- Move Files to New Folder, then
                //5- Call EF to Save Files to DB
                var newFiles = FileTransferServiceInstance.MoveFile(
                    requestInfo.FilesPaths.ToList(), requestInfo.RequestNumber,
                    TypedObjects.ComplaintCreateRequestFileTitle);

                //Send files paths and request number to save its information to DB
                var fileResults = dbUnitOfWork.MOL_RAMS_Complaint_Files_Repository.AddFiles(complaintId, newFiles.ToArray());

                //=========================================================================
                if (fileResults)
                    return new ResponseMsg
                    {
                        IsSuccess = true,
                        ResponseText = requestInfo.RequestNumber
                    };
                else
                    return new ResponseMsg
                    {
                        IsSuccess = false,
                        RuleTypeId = "MOL_RAMS_Complaint_Files_Repository"
                    };
            }
        }

        #endregion

        #region "البت في بلاغ تغيب"

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg CreateRunAwayReviewRequest(int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || runAwayRequestId <= 0 || applicantUserIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            // 2- Call EF to update the Complaint request status to UnderProcessing
            var results =
                dbUnitOfWork.MOL_RunAwayComplaints_Repository.UpdateRunAwayComplaintStatus(
                    runAwayRequestId,
                    TypedObjects.ComplaintRequestStatus.UnderLaborOfficeProcessing.GetHashCode(),
                    string.Empty,
                    applicantUserIdNumber, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (results)
            {
                return new ResponseMsg
                {
                    IsSuccess = true,
                    RuleTypeId = runAwayRequestId.ToString()
                };
            }
            else
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "CreateRunAwayReviewRequest"
                };
            }
        }

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="rejectionReason">The rejection reason.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg RejectComplaintRequest(
            int runAwayRequestId, string rejectionReason,
            long applicantUserIdNumber, string clientIPAddress, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || runAwayRequestId <= 0 || rejectionReason.Trim().Length <= 0 || applicantUserIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            // 2- Call EF to update the Complaint request status to Rejected
            var results =
                dbUnitOfWork.MOL_RunAwayComplaints_Repository.UpdateRunAwayComplaintStatus(
                    runAwayRequestId,
                    TypedObjects.ComplaintRequestStatus.Rejected.GetHashCode(), rejectionReason,
                    applicantUserIdNumber, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (!results)
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "UpdateRunAwayComplaintStatus"
                };
            }

            //=========================================================================
            // 3- Call EF to update the Runaway request status to Accepted
            results =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.ChangeRunAwayRequestStatus(
                    runAwayRequestId,
                    TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode(),
                    applicantUserIdNumber, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (results)
            {
                return new ResponseMsg
                {
                    IsSuccess = true,
                    RuleTypeId = runAwayRequestId.ToString()
                };
            }
            else
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "RejectComplaintRequest"
                };
            }
        }

        /// <summary>
        /// Function creates Review request at MoL database (البت في بلاغ التغيب)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg AcceptComplaintRequest(int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || runAwayRequestId <= 0 || applicantUserIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            // 2- Call EF to update the Complaint request status to Accepted
            var results =
                dbUnitOfWork.MOL_RunAwayComplaints_Repository.UpdateRunAwayComplaintStatus(
                    runAwayRequestId,
                    TypedObjects.ComplaintRequestStatus.Accepted.GetHashCode(), string.Empty,
                    applicantUserIdNumber, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (!results)
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "UpdateRunAwayComplaintStatus"
                };
            }

            //=========================================================================
            // 3- Call EF to update the Runaway request status to Accepted
            results =
                dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.ChangeRunAwayRequestStatus(
                    runAwayRequestId,
                    TypedObjects.RunAwayRequestStatus.Rejected.GetHashCode(),
                    applicantUserIdNumber, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (results)
            {
                return new ResponseMsg
                {
                    IsSuccess = true,
                    RuleTypeId = runAwayRequestId.ToString()
                };
            }
            else
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "AcceptComplaintRequest"
                };
            }
        }

        /// <summary>
        /// Function Set Establishment Note.
        /// </summary>
        /// <param name="establishmentId">The establishment identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="noteMessage">The note message.</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg SetRunAwayEstablishmentNote(long establishmentId, long applicantUserIdNumber, string noteMessage, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || establishmentId <= 0 || applicantUserIdNumber <= 0 || noteMessage.Trim().Length <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //============================================================================================
            //Search if Establishment has a note on this service
            var searchResults = NoteServiceManager.SearchNotes(
                new NoteSearchCriteria
                {
                    Source = NoteSourceList.Manpower_Complaints,
                    EstablishmentId = establishmentId
                },
                0, 25);

            //============================================================================================
            //Check returned results
            if (searchResults != null && searchResults.ActionResult == Mol.Common.ActionResult.Success &&
                    searchResults.Result != null)
            {
                //Get Complaint Notes Configuration from DB
                var complaintNoteConfiguration =
                     dbUnitOfWork.MOL_RAMS_ComplaintNotes_Repository.GetComplaintNoteByOrder(searchResults.Result.Count + 1);

                //Set Establishment Note
                if (searchResults.Result.Count > 0)
                {
                    #region "Establishment already has the same note"

                    //==============================================================================================
                    //Create and fill new note object
                    var extendedEstablishmentNote = new Mol.ComponentLayer.EstablishmentNote();

                    // ---> Date[0] + Extend from configuration DB                
                    extendedEstablishmentNote.EndDate =
                        searchResults.Result.Notes[0].EndDate.AddDays(complaintNoteConfiguration.NoteDays);

                    //Set Note Applicability ( مستوى الملاحظة )
                    // "1" – على مستوى المنشأة
                    // "2" – على مستوى المنشآت تحت مكتب عمل
                    // "3" – على كل المنشآت
                    extendedEstablishmentNote.FkNoteApplicabilityId = complaintNoteConfiguration.NoteScopeId;

                    //Set note Source (الجهة أو النظام صاحب الملاحظة ) 
                    extendedEstablishmentNote.FkNoteSourceId = NoteSourceList.Manpower_Complaints.GetHashCode();

                    //Note Status (حاله الملاحظة سارية أو منتهية)
                    extendedEstablishmentNote.FkNoteStatusId = 1;

                    //Note Type (نوع الملاحظة)
                    // "1" – ملاحظة تنبيه
                    // "2" – ملاحظة إيقاف
                    extendedEstablishmentNote.FkNoteTypeId = complaintNoteConfiguration.NoteTypeId;

                    //Establishment Id
                    extendedEstablishmentNote.FkEstablishmentId = establishmentId;

                    //Extended Note Number
                    extendedEstablishmentNote.NoteNumber = searchResults.Result.Notes[0].Number;

                    //Extended Note Id
                    extendedEstablishmentNote.PkEstablishmentNoteId = searchResults.Result.Notes[0].NoteId;

                    //==============================================================================================
                    //Extend the note (note Object, نص الملاحظة, المستخدم)
                    var extendingResults = NoteServiceManager.ExtendNote(extendedEstablishmentNote, noteMessage, applicantUserIdNumber.ToString());

                    //Return results to Caller along with note Id
                    if (extendingResults.ActionResult == Mol.Common.ActionResult.Success)
                        return new ResponseMsg
                        {
                            IsSuccess = true,
                            ResponseText = searchResults.Result.Notes[0].NoteId.ToString()
                        };
                    else
                        return new ResponseMsg
                        {
                            IsSuccess = false,
                            RuleTypeId = System.Reflection.MethodBase.GetCurrentMethod().Name + ".ExtendNote"
                        };

                    #endregion
                }
                else
                {
                    #region " Create New Establishment Note "

                    //Fill the services list
                    var noteServicesList = new TList<Mol.ComponentLayer.EstablishmentNoteService>();
                    foreach (var currentService in Enum.GetValues(typeof(NoteService)).Cast<NoteService>())
                    {
                        if (currentService != NoteService.WorkPermit && currentService.EligibleForNote())
                        {
                            noteServicesList.Add(
                                new Mol.ComponentLayer.EstablishmentNoteService
                                {
                                    FkServiceId = currentService.GetHashCode()
                                });
                        }
                    }

                    //==============================================================================================
                    //Create and fill new note object
                    var newEstablishmentNote = new Mol.ComponentLayer.EstablishmentNote();

                    //تاريخ الإدخال
                    newEstablishmentNote.StartDate = DateTime.Now;

                    //تاريخ الإنهاء
                    newEstablishmentNote.EndDate = DateTime.Now.AddDays(complaintNoteConfiguration.NoteDays);

                    //Set Note Applicability ( مستوى الملاحظة )
                    // "1" – على مستوى المنشأة
                    // "2" – على مستوى المنشآت تحت مكتب عمل
                    // "3" – على كل المنشآت
                    newEstablishmentNote.FkNoteApplicabilityId = complaintNoteConfiguration.NoteScopeId;

                    //Set note Source (الجهة أو النظام صاحب الملاحظة ) 
                    newEstablishmentNote.FkNoteSourceId = NoteSourceList.Manpower_Complaints.GetHashCode();

                    //Note Status (حاله الملاحظة سارية أو منتهية)
                    newEstablishmentNote.FkNoteStatusId = 1;

                    //Note Type (نوع الملاحظة)
                    // "1" – ملاحظة تنبيه
                    // "2" – ملاحظة إيقاف
                    newEstablishmentNote.FkNoteTypeId = complaintNoteConfiguration.NoteTypeId;

                    //Establishment Id
                    newEstablishmentNote.FkEstablishmentId = establishmentId;

                    //نص الملاحظة
                    newEstablishmentNote.NoteText = noteMessage;

                    //==============================================================================================
                    //Create the note (note Object, Services list, سبب الملاحظة , المستخدم)
                    var submitResults = NoteServiceManager.SubmitNote(newEstablishmentNote, noteServicesList, noteMessage, applicantUserIdNumber.ToString());

                    //Return results to Caller along with note Id
                    if (submitResults.ActionResult == Mol.Common.ActionResult.Success)
                        return new ResponseMsg
                        {
                            IsSuccess = true,
                            ResponseText = submitResults.Result.ToString()
                        };
                    else
                        return new ResponseMsg
                        {
                            IsSuccess = false,
                            ResponseText = submitResults.ActionResult.ToString(),
                            RuleTypeId = System.Reflection.MethodBase.GetCurrentMethod().Name + ".SubmitNote"
                        };

                    #endregion
                }
            }

            return new ResponseMsg
            {
                IsSuccess = false,
                RuleTypeId = System.Reflection.MethodBase.GetCurrentMethod().Name + ". No records from Search Notes"
            };

        }

        #endregion

        #region "تدقيق بلاغ تغيب"

        /// <summary>
        /// Function updates status of Complaint request to - تم تحديد موعد للمراجعة
        /// تدقيق بلاغ التغيب بمكتب العمل
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg UpdateComplaintRequestByReviewAppointment(
            int runAwayRequestId, long applicantUserIdNumber, string clientIPAddress, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || runAwayRequestId <= 0 || applicantUserIdNumber <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            // 2- Call EF to update the Complaint request status to UnderProcessing
            var results =
                dbUnitOfWork.MOL_RunAwayComplaints_Repository.UpdateRunAwayComplaintStatus(
                    runAwayRequestId,
                    TypedObjects.ComplaintRequestStatus.ReviewAppointmentTime.GetHashCode(),
                    string.Empty,
                    applicantUserIdNumber, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (results)
            {
                return new ResponseMsg
                {
                    IsSuccess = true,
                    RuleTypeId = runAwayRequestId.ToString()
                };
            }
            else
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "CreateRunAwayReviewRequest"
                };
            }
        }

        /// <summary>
        /// Function Adds review result to Complaint request (تدقيق بلاغ التغيب بمكتب العمل)
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="reviewResults">The review results.</param>
        /// <param name="applicantUserIdNumber">The applicant user identifier number.</param>
        /// <param name="resultsType">Review Close Type</param>
        /// <param name="clientIPAddress">Client IP Address</param>
        /// <param name="dbUnitOfWork">Unit of Work Pattern</param>
        /// <returns>ResponseMsg.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public ResponseMsg UpdateComplaintRequestWithReviewResults(
            int runAwayRequestId, string reviewResults, long applicantUserIdNumber,
            TypedObjects.ReviewResultsType resultsType, string clientIPAddress, UnitOfWork dbUnitOfWork)
        {
            //Check input parameters is valid
            if (dbUnitOfWork == null || runAwayRequestId <= 0 || applicantUserIdNumber <= 0 || reviewResults.Trim().Length <= 0)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            //=========================================================================
            // 2- Call EF to update the Complaint request status to UnderProcessing
            var results =
                dbUnitOfWork.MOL_RunAwayComplaints_Repository.UpdateComplaintWithReviewResults(
                    runAwayRequestId,
                    resultsType == TypedObjects.ReviewResultsType.FinalResult ?
                        TypedObjects.ComplaintRequestStatus.RepliedByLaborOffice.GetHashCode() : (int?)null,
                    reviewResults, applicantUserIdNumber, clientIPAddress);

            //Check if error happened while updating the complaint request
            if (results)
            {
                return new ResponseMsg
                {
                    IsSuccess = true,
                    RuleTypeId = runAwayRequestId.ToString()
                };
            }
            else
            {
                return new ResponseMsg
                {
                    IsSuccess = false,
                    RuleTypeId = "CreateRunAwayReviewRequest"
                };
            }
        }

        #endregion

        #region "Send SMS"

        /// <summary>
        /// Sends the SMS.
        /// </summary>
        /// <param name="messageType">Target message Type</param>
        /// <param name="userIdNumber">User Id Number</param>
        /// <param name="runawayRequestId">Target runaway request Id to get user mobile number</param>
        /// <param name="dbUnitOfWork">EFDAL Unit of Work</param>
        /// <param name="messageInput">Optional Params for SMS</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public bool SendEstablishmentSMS(TypedObjects.MessageType messageType,
            long? userIdNumber, int? runawayRequestId,
            UnitOfWork dbUnitOfWork, params dynamic[] messageInput)
        {
            if ((!userIdNumber.HasValue && !runawayRequestId.HasValue) ||
                (userIdNumber.HasValue && userIdNumber.Value <= 0) ||
                (runawayRequestId.HasValue && runawayRequestId.Value <= 0) ||
                dbUnitOfWork == null)
                throw new ArgumentException(System.Reflection.MethodBase.GetCurrentMethod().Name);

            using (MessageClientInstance = new GetSystemMessages())
            {
                //=============================================================================
                // Get User Mobile Number
                if (!userIdNumber.HasValue)
                {
                    userIdNumber = dbUnitOfWork.MOL_LaborerMOIRunaway_Repository.GetApplicantUserIdNumber(runawayRequestId.Value);
                }

                if (!userIdNumber.HasValue)
                    return false;

                var mobileNumber = dbUnitOfWork.MOL_User_Repository.GetUserByIdNo(
                    userIdNumber.Value).MobileNumber;

                if (string.IsNullOrEmpty(mobileNumber))
                    return false;

                //=============================================================================
                // Combine SMS text Message
                var smsMessage = string.Empty;
                switch (messageType)
                {
                    case TypedObjects.MessageType.CreateRunAwayRequest:
                        smsMessage = MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG03, messageInput);
                        break;
                    case TypedObjects.MessageType.CancelRunAwayRequest:
                        smsMessage = MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG24, messageInput);
                        break;
                    case TypedObjects.MessageType.CreateComplaintRequest:
                        smsMessage = MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG32, messageInput);
                        break;
                    case TypedObjects.MessageType.ReviewAppointment:
                        smsMessage = MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG22, messageInput);
                        break;
                    case TypedObjects.MessageType.ApproveCompliantRequestResult:
                        smsMessage = MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG33, messageInput);
                        break;
                }

                //==============================================================================
                //Send SMS to target user
                if (string.IsNullOrEmpty(smsMessage.Trim()))
                    return false;

                using (NotificationServiceInstance = new NotificationServiceClient())
                {
                    if (NotificationServiceInstance.ClientCredentials == null)
                        return false;

                    NotificationServiceInstance.ClientCredentials.UserName.UserName =
                        Utilities.SecureStringToString(Utilities.NICNameInfo);
                    NotificationServiceInstance.ClientCredentials.UserName.Password =
                        Utilities.SecureStringToString(Utilities.NICCicoCicoInfo);

                    return NotificationServiceInstance.SendSms(mobileNumber, smsMessage, SmsType.Normal);
                }
            }
        }

        /// <summary>
        /// Sends the SMS.
        /// </summary>
        /// <param name="messageType">Target message Type</param>
        /// <param name="mobileNumber">Target Mobile Number</param>
        /// <param name="userIdNumber">User Id Number</param>
        /// <param name="complaintRequestId">The laborer Complaint Id</param>
        /// <param name="runAwayRequestId">The runAway Request Id</param>
        /// <param name="dbUnitOfWork">EFDAL Unit of Work</param>
        /// <param name="messageInput">Optional Params for SMS</param>
        /// <returns>True if it succeeds, false if it fails.</returns>
        public bool SendIndividualSMS(TypedObjects.MessageType messageType,
            string mobileNumber, long? userIdNumber, int? complaintRequestId, int? runAwayRequestId,
            UnitOfWork dbUnitOfWork, params dynamic[] messageInput)
        {
            //=====================================================================
            // Get User Mobile Number
            if (string.IsNullOrEmpty(mobileNumber))
            {
                if (userIdNumber != null)
                    mobileNumber =
                        dbUnitOfWork.MOL_User_Repository.GetUserByIdNo(
                            userIdNumber.Value).MobileNumber;

                //=============================================================================
                //if individual has no mobile number in MLSD then he may have mobile number in 
                //Complaint request generated by MyClients
                if (string.IsNullOrEmpty(mobileNumber) && complaintRequestId.HasValue)
                {
                    mobileNumber =
                           dbUnitOfWork.MOL_RunAwayComplaints_Repository.GetLaborerMobileNumberByComplaintId(complaintRequestId.Value);
                }
                else if (string.IsNullOrEmpty(mobileNumber) && runAwayRequestId.HasValue)
                {
                    mobileNumber =
                        dbUnitOfWork.MOL_RunAwayComplaints_Repository.GetLaborerMobileNumberByRunAwayId(
                            runAwayRequestId.Value);
                }

                if (string.IsNullOrEmpty(mobileNumber))
                    //User have no mobile number registered in MLSD
                    return false;
            }

            using (MessageClientInstance = new GetSystemMessages())
            {
                //=============================================================================
                // Combine SMS text Message
                var smsMessage = string.Empty;
                switch (messageType)
                {
                    case TypedObjects.MessageType.CreateRunAwayRequest:
                        smsMessage = MessageClientInstance.GetMessageBody(
                            TypedObjects.RAMSMSG30, messageInput);
                        break;
                    case TypedObjects.MessageType.CancelRunAwayRequest:
                        smsMessage = MessageClientInstance.GetMessageBody(
                           TypedObjects.RAMSMSG31, messageInput);
                        break;
                    case TypedObjects.MessageType.CreateComplaintRequest:
                        smsMessage = MessageClientInstance.GetMessageBody(
                          TypedObjects.RAMSMSG10, messageInput);
                        break;
                    case TypedObjects.MessageType.ReviewAppointment:
                        smsMessage = MessageClientInstance.GetMessageBody(
                           TypedObjects.RAMSMSG22, messageInput);
                        break;
                    case TypedObjects.MessageType.ApproveCompliantRequestResult:
                        smsMessage = MessageClientInstance.GetMessageBody(
                           TypedObjects.RAMSMSG33, messageInput);
                        break;
                }

                //==============================================================================
                //Send SMS to target user
                if (string.IsNullOrEmpty(mobileNumber) || string.IsNullOrEmpty(smsMessage))
                    return false;

                using (NotificationServiceInstance = new NotificationServiceClient())
                {
                    if (NotificationServiceInstance.ClientCredentials == null)
                        return false;

                    NotificationServiceInstance.ClientCredentials.UserName.UserName =
                        Utilities.SecureStringToString(Utilities.NICNameInfo);
                    NotificationServiceInstance.ClientCredentials.UserName.Password =
                        Utilities.SecureStringToString(Utilities.NICCicoCicoInfo);

                    return NotificationServiceInstance.SendSms(mobileNumber, smsMessage, SmsType.Normal);
                }
            }
        }

        #endregion

        #endregion
    }
}
