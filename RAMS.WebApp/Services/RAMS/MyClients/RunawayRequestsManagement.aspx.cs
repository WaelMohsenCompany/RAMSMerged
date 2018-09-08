// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="RunawayRequestsManagement.aspx.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoggingUtilities;
using Mol.Common;
using Mol.Entities;
using RAMS.BusinessServices.Get;
using RAMS.BusinessServices.Post;
using RAMS.CrossCutting;
using RAMS.WebApp.Services.RAMS.Base;
using RAMS.WebApp.Services.RAMS.Models;
using RAMS.WebApp.Services.RAMS.Utility;

namespace RAMS.WebApp.Services.RAMS.MyClients
{
    /// <inheritdoc />
    /// <summary>
    /// Class RunawayRequestsManagement.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public partial class RunawayRequestsManagement : RamsBasePage
    {
        #region Fields and Properties

        #region Fields 

        /// <summary>
        /// get business service
        /// </summary>
        private readonly GetBusinessService _getBusinessService = new GetBusinessService();

        /// <summary>
        /// post business service
        /// </summary>
        private readonly PostBusinessService _postBusinessService = new PostBusinessService();

        #endregion

        #region General

        /// <summary>
        /// Gets or sets the array messages.
        /// </summary>
        /// <value>The array messages.</value>
        protected string[] ErrorMessages { get; set; }

        /// <summary>
        /// Arr Messages
        /// </summary>
        /// <value>The arr messages.</value>
        protected string[] ArrMessages { get; set; }

        #endregion

        #region Business

        /// <summary>
        /// IsRunawayDetailsVisible
        /// </summary>
        /// <value><c>true</c> if this instance is runaway details visible; otherwise, <c>false</c>.</value>
        private bool IsRunawayDetailsVisible
        {
            set => runawayDetailsDiv.Visible = value;
        }

        /// <summary>
        /// IsAllRunawayRequestsVisibles
        /// </summary>
        /// <value><c>true</c> if this instance is all runaway requests visible; otherwise, <c>false</c>.</value>
        private bool IsAllRunawayRequestsVisibles
        {
            set => allRunawayRequestsDiv.Visible = value;
        }

        /// <summary>
        /// is confirmed
        /// </summary>
        /// <value><c>true</c> if this instance is confirmed; otherwise, <c>false</c>.</value>
        private bool IsConfirmed { get; set; }

        #endregion

        #region ViewState

        /// <summary>
        /// Maximum count of files the user can upload
        /// </summary>
        /// <value>The maximum files count.</value>
        protected int MaxFilesCount
        {
            get
            {
                if (ViewState["maxFilesCount"] != null)
                {
                    return Convert.ToInt32(ViewState["maxFilesCount"]);
                }
                return 2;
            }
            set => ViewState["maxFilesCount"] = value;
        }

        /// <summary>
        /// Maximum file size the user can upload in MB
        /// </summary>
        /// <value>The maximum size of the files.</value>
        protected int MaxFilesSize
        {
            get => ViewState["maxFilesSize"] != null ? Convert.ToInt32(ViewState["maxFilesSize"]) : 2;
            set => ViewState["maxFilesSize"] = value;
        }

        /// <summary>
        /// Min Files Size
        /// </summary>
        /// <value>The minimum size of the files.</value>
        protected int MinFilesSize
        {
            get => ViewState["MinFilesSize"] != null ? Convert.ToInt32(ViewState["MinFilesSize"]) : 0;
            set => ViewState["MinFilesSize"] = value;
        }

        #endregion

        #region Enumerations

        /// <summary>
        /// RunAway Search Criteria
        /// </summary>
        protected enum StaticBusinessKeys
        {
            /// <summary>
            /// All run away requests
            /// </summary>
            AllRunAwayRequests,
            /// <summary>
            /// The specific run away request
            /// </summary>
            SpecificRunAwayRequest,
            /// <summary>
            /// The request number command
            /// </summary>
            RequestNumberCommand,
            /// <summary>
            /// The run away files paths field command
            /// </summary>
            RunAwayFilesPathsFieldCommand
        }

        #endregion

        #region Sessions

        /// <summary>
        /// Get All RunAway Requests Session
        /// </summary>
        /// <value>The get all run away requests session key.</value>
        private string GetAllRunAwayRequestsSessionKey
        {
            get
            {
                if (ViewState["GetAllRunAwayRequestsSessionKey"] == null)
                    ViewState["GetAllRunAwayRequestsSessionKey"] = Guid.NewGuid().ToString();
                return ViewState["GetAllRunAwayRequestsSessionKey"] as string;
            }
        }

        /// <summary>
        /// Session for List of case model.
        /// </summary>
        /// <value>The complaints session.</value>
        private List<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsSession
        {
            get => Session[GetAllRunAwayRequestsSessionKey] as List<RunAwayRetrieveRequestInfo>;
            set => Session[GetAllRunAwayRequestsSessionKey] = value;
        }

        /// <summary>
        /// Gets the get run away request session key.
        /// </summary>
        /// <value>The complaints session key.</value>
        private string GetRunAwayRequestSessionKey
        {
            get
            {
                if (ViewState["GetRunAwayRequestSessionKey"] == null)
                    ViewState["GetRunAwayRequestSessionKey"] = Guid.NewGuid().ToString();
                return ViewState["GetRunAwayRequestSessionKey"] as string;
            }
        }

        /// <summary>
        /// Session for List of case model.
        /// </summary>
        /// <value>The complaints session.</value>
        private RunAwayRetrieveRequestInfo GetRunAwayRequestSession
        {
            get => Session[GetRunAwayRequestSessionKey] as RunAwayRetrieveRequestInfo;
            set => Session[GetRunAwayRequestSessionKey] = value;
        }

        /// <summary>
        /// Gets or sets the files session key.
        /// </summary>
        /// <value>The complaints session key.</value>
        protected string FilesSessionKey
        {
            get
            {
                if (ViewState["FilesSessionKey"] == null)
                    ViewState["FilesSessionKey"] = Guid.NewGuid().ToString();
                return ViewState["FilesSessionKey"] as string;
            }
            set => ViewState["FilesSessionKey"] = value;
        }

        /// <summary>
        /// Session for List of case model.
        /// </summary>
        /// <value>The complaints session.</value>
        protected List<FileModel> FilesSession
        {
            get => Session[FilesSessionKey] as List<FileModel>;
            set => Session[FilesSessionKey] = value;
        }

        #endregion

        #endregion

        #region  Methods

        #region General

        /// <summary>
        /// Show Error Message
        /// </summary>
        private void ShowErrorMsg()
        {
            //ClearPage();
            ScriptManager.RegisterStartupScript(Page, GetType(), "ShowErrorMsg", "ShowErrorMsg();", true);
        }

        /// <summary>
        /// Shows the success MSG.
        /// </summary>
        private void ShowSuccessMsg()
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "ShowSuccessMsg", "ShowSuccessMsg();", true);
        }

        /// <summary>
        /// show delete Confirmation message
        /// </summary>
        private void ShowDeleteConfirmationMsg()
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "DeleteConfirmationMsg", "DeleteConfirmationMsg();",
                true);
        }

        #endregion

        #region Business Logic Methods 

        /// <summary>
        /// bind request to UI
        /// </summary>
        /// <param name="result">The result.</param>
        private void BindRunAwayRequest(RunAwayRetrieveRequestInfo result)
        {
            if (result != null && !string.IsNullOrEmpty(ucValidateBusinessUser?.SequenceNo.ToString()) &&
                !string.IsNullOrEmpty(ucValidateBusinessUser.LaborOfficeID.ToString()))
            {
                //Clean Controls 
                laborerReturnDateToWorkCalendar.Clear();
                reasonsCancelationTextBox.Text = "";
                FilesSession = new List<FileModel>();
                requiedFilesGridView.DataSource = null;
                requiedFilesGridView.DataBind();
                AgreementCheckBox.Checked = false;
                //cache result
                GetRunAwayRequestSession = result;
                //bind data 
                runawayRequestNumberLiteral.Text = result.RequestNumber;
                establismentNameLiteral.Text = result.EstablishmentTitle;
                establishmentNumberLiteral.Text = ucValidateBusinessUser.SequenceNo + "-" +
                                                  ucValidateBusinessUser.LaborOfficeID;
                laborNameLiteral.Text = result.LaborerFullName;
                laborIdLiteral.Text = (result.LaborerIdNumber != null &&
                                       !string.IsNullOrEmpty(result.LaborerIdNumber.ToString()))
                    ? result.LaborerIdNumber.ToString()
                    : result.LaborerBorderNumber.ToString();
                runawayDateLiteral.Text = result.RequestDate.ToString("yyyy/MM/dd") + " - " +
                                          Utilities.ConvertToHijriFormate(result.RequestDate);
                runawayTimeLiteral.Text = result.RequestDate.ToShortTimeString().ToString(CultureInfo.InvariantCulture);
                //حالة الطلب   
                runawayStatusLiteral.Text = result.RunAwayRequestStatusName;
                //متى بدأ الوافد العمل لديكم
                LaborerStartWorkDateLiteral.Text =
                    !string.IsNullOrEmpty(result.CreationQuestion1?.ToString())
                        ? result.CreationQuestion1.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(result.CreationQuestion1.Value)
                        : "لا يوجد";
                //متى كانت نهاية العمل
                LaborerEndWorkDateLiteral.Text = !string.IsNullOrEmpty(result.CreationQuestion2?.ToString())
                    ? result.CreationQuestion2.Value.ToString("yyyy/MM/dd") + " - " +
                      Utilities.ConvertToHijriFormate(result.CreationQuestion2.Value)
                    : "لا يوجد";
                //متى تم تسليم آخر راتب للوافد
                LastLaborerSalaryLiteral.Text = !string.IsNullOrEmpty(result.CreationQuestion3?.ToString())
                    ? result.CreationQuestion3.Value.ToString("yyyy/MM/dd") + " - " +
                      Utilities.ConvertToHijriFormate(result.CreationQuestion3.Value)
                    : "لا يوجد";
                //سبب انتهاء العلاقة العمالية
                if (Web.CrossCutting.TypedObjects.IsBase64String(result.CreationQuestion4))
                {
                    reasonEndLaborerRelationShipTextBox.Text = !string.IsNullOrEmpty(result.CreationQuestion4)
                        ? Web.CrossCutting.TypedObjects.Base64Decode(result.CreationQuestion4)
                        : "لا يوجد";
                }
                else
                {
                    reasonEndLaborerRelationShipTextBox.Text = !string.IsNullOrEmpty(result.CreationQuestion4)
                        ? result.CreationQuestion4
                        : "لا يوجد";
                }
                //المرفقات 
                if (result.FilesPaths != null && result.FilesPaths.Any())
                {
                    attachmentsGridView.DataSource = result.FilesPaths.ToList();
                    attachmentsGridView.DataBind();
                }
                else
                {
                    attachmentsGridView.DataSource = null;
                    attachmentsGridView.DataBind();
                }
                //visible hidden delete div 
                if (result.IsEligibleToCancel)
                {
                    runawayDetailsDiv.Visible = true;
                    deleteRunAwayDiv.Visible = true;
                    deleteRunAwayRequestButton.Visible = true;
                    neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                }
                else
                {
                    runawayDetailsDiv.Visible = true;
                    deleteRunAwayDiv.Visible = false;
                }
            }
            ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToRequestDetails", "scrollToRequestDetails()",
                true);
        }

        /// <summary>
        /// bind list of Run Away Reterive Request
        /// </summary>
        /// <param name="getAllRunAwayRequestsListResult">The get all run away requests list result.</param>
        private void BindListOfRunAwayRequest(HashSet<RunAwayRetrieveRequestInfo> getAllRunAwayRequestsListResult)
        {
            if (getAllRunAwayRequestsListResult == null || !getAllRunAwayRequestsListResult.Any()) return;
            //cach data 
            GetAllRunAwayRequestsSession = getAllRunAwayRequestsListResult.ToList();
            // total records 
            var runAwayRetrieveRequestInfo = getAllRunAwayRequestsListResult.FirstOrDefault();
            if (runAwayRetrieveRequestInfo != null)
                runawayRequestsGridView.VirtualItemCount = runAwayRetrieveRequestInfo.TotalRowsCount;
            //Bind 
            runawayRequestsGridView.DataSource = getAllRunAwayRequestsListResult.ToList();
            runawayRequestsGridView.DataBind();
            //hide delete div 
            deleteRunAwayDiv.Visible = false;
            laborDiv.Visible = false;
            allRunawayRequestsDiv.Visible = true;
            runawayDetailsDiv.Visible = false;
        }

        /// <summary>
        /// bind uploaded files to grid
        /// </summary>
        private void BindFilesToGrid()
        {
            if (FilesSession != null && FilesSession.Any())
            {
                requiedFilesGridView.DataSource = FilesSession;
                requiedFilesGridView.DataBind();
            }
            else
            {
                requiedFilesGridView.DataSource = null;
                requiedFilesGridView.DataBind();
            }
        }

        /// <summary>
        /// Load System Setting/Lookups
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool LoadSetting()
        {
            try
            {
                var maxFilesCountSet = GetSystemSettings(TypedObjects.SystemSettings.MaximumNumberOfFiles);
                if (maxFilesCountSet > 0)
                {
                    MaxFilesCount = maxFilesCountSet;
                }
                var maxFilesSizeSet = GetSystemSettings(TypedObjects.SystemSettings.MaximumFileSizeInMega);
                if (maxFilesSizeSet > 0)
                {
                    MaxFilesSize = maxFilesSizeSet;
                }
                var minFilesSizeSet = GetSystemSettings(TypedObjects.SystemSettings.MinimumFileSizeInKilo);
                MinFilesSize = minFilesSizeSet;
                return true;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return false;
            }
        }

        #endregion

        #region  Business Service Methods

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="targetSetting">The target setting.</param>
        /// <returns>System.Int32.</returns>
        private int GetSystemSettings(TypedObjects.SystemSettings targetSetting)
        {
            try
            {
                return CurrentUser.IdNumber != null
                    ? _getBusinessService.GetSystemSettings(targetSetting, ucValidateBusinessUser.RequesterIdNo)
                    : 0;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return 0;
            }
        }

        /// <summary>
        /// Get runaway request .
        /// </summary>
        /// <param name="iqamaNumber">The iqama number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <returns>RunAwayRetrieveRequestInfo.</returns>
        private RunAwayRetrieveRequestInfo GetRunAwayRequest(string iqamaNumber, string borderNumber)
        {
            try
            {
                if (CurrentUser.IdNumber != null)
                {
                    return _getBusinessService.GetRunAwayRequest(ucValidateBusinessUser.RequesterIdNo,
                        int.Parse(ucValidateBusinessUser.LaborOfficeID.ToString()),
                        long.Parse(ucValidateBusinessUser.SequenceNo.ToString()),
                        !string.IsNullOrEmpty(iqamaNumber) ? long.Parse(iqamaNumber) : 0,
                        !string.IsNullOrEmpty(borderNumber) ? long.Parse(borderNumber) : (long?)null);
                }
                return null;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return null;
            }
        }

        /// <summary>
        /// Get All Run Away Requests List
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentPage">The current page.</param>
        /// <returns>HashSet&lt;RunAwayRetrieveRequestInfo&gt;.</returns>
        private HashSet<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsList(int pageSize, int currentPage)
        {
            try
            {
                if (CurrentUser.IdNumber != null)
                {
                    return
                        _getBusinessService.GetAllRunAwayRequestsList(
                            ucValidateBusinessUser.RequesterIdNo,
                            int.Parse(ucValidateBusinessUser.LaborOfficeID.ToString()),
                            long.Parse(ucValidateBusinessUser.SequenceNo.ToString()), pageSize, currentPage);
                }
                return null;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return null;
            }
        }

        /// <summary>
        /// delete runAway request
        /// </summary>
        /// <param name="deleteReason">The delete reason.</param>
        /// <param name="dateTime">The date time.</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        private ActionResults<HashSet<ResponseMsg>> DeleteRunAwayRequest(string deleteReason, string dateTime)
        {
            try
            {
                var idNumber = GetCurrentUser().IdNumber;
                if (idNumber == null) return null;
                return _postBusinessService.CancelRunAwayRequest(new RunAwayCancelRequestInfo
                {
                    CreatedByIdNumber = idNumber.Value,
                    ApplicantUserIdNumber = ucValidateBusinessUser.RequesterIdNo,
                    CancelReason = deleteReason,
                    FilesPaths = FilesSession.Select(f => f.Path).ToHashSet(),
                    RequestNumber = GetRunAwayRequestSession.RequestNumber,
                    CancelQuestion1 = DateTime.Parse(dateTime),
                    ClientIPAddress = GetClientIpAddress()
                }, IsConfirmed);
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return null;
            }
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <returns>ResponseMsg.</returns>
        private ResponseMsg GetSystemMessage(string messageCode)
        {
            var user = GetCurrentUser();
            if (user?.IdNumber != null)
            {
                return _getBusinessService.GetSystemMessages(messageCode, ucValidateBusinessUser.RequesterIdNo);
            }
            return null;
        }

        /// <summary>
        /// Complete Cancel Business
        /// </summary>
        private void CompleteCancelBusiness()
        {
            try
            {
                var errorMessages = new List<string>();
                //check Files Uploded
                if (FilesSession == null || !FilesSession.Any())
                {
                    errorMessages.Add(Web.CrossCutting.TypedObjects.NoFilesFiles);
                }
                //Check Agreement 
                if (!AgreementCheckBox.Checked)
                {
                    errorMessages.Add(Web.CrossCutting.TypedObjects.AgreementFieldMessage);
                }
                if (string.IsNullOrEmpty(reasonsCancelationTextBox.Text) ||
                    reasonsCancelationTextBox.Text.Length > 500)
                {
                    reasonsCancelationTextBox.BorderColor = Color.Red;
                    errorMessages.Add(Web.CrossCutting.TypedObjects.MessageSize);
                }
                //check Questions & Agreement 
                if (string.IsNullOrEmpty(laborerReturnDateToWorkCalendar.GregorianDate) ||
                    string.IsNullOrEmpty(reasonsCancelationTextBox.Text))
                {
                    errorMessages.Add(Web.CrossCutting.TypedObjects.MandatoryFieldMessage);
                }
                else if (!string.IsNullOrEmpty(laborerReturnDateToWorkCalendar.GregorianDate) &&
                    DateTime.Parse(laborerReturnDateToWorkCalendar.GregorianDate) > DateTime.Now)
                {
                    laborerReturnDateToWorkCalendar.BorderColor = Color.Red;
                    errorMessages.Add(Web.CrossCutting.TypedObjects.LaborerReturnDateToWorkCalendarError);
                }
                if (errorMessages.Any())
                {
                    ArrMessages = errorMessages.ToArray();
                    ShowErrorMsg();
                    return;
                }
                if (GetRunAwayRequestSession == null || string.IsNullOrEmpty(reasonsCancelationTextBox.Text)) return;
                try
                {
                    var result =
                        DeleteRunAwayRequest(
                            Web.CrossCutting.TypedObjects.Base64Encode(reasonsCancelationTextBox.Text),
                            laborerReturnDateToWorkCalendar.GregorianDate);
                    if (result != null)
                    {
                        if (!result.IsSuccess)
                        {
                            switch (result.ResultsCode)
                            {
                                case ResultsCodes.BusinessRulesViolationError:
                                    {
                                        ArrMessages =
                                            result.ResultsList.Where(i => !i.IsSuccess)
                                                .Select(i => i.ResponseText)
                                                .ToArray();
                                        ShowErrorMsg();
                                        DeleteConfirmationDiv.Visible = false;
                                        deleteRunAwayDiv.Visible = false;
                                        runawayDetailsDiv.Visible = false;
                                        break;
                                    }
                                case ResultsCodes.BusinessRulesViolationWarning:
                                    {
                                        ArrMessages =
                                            result.ResultsList.Where(i => !i.IsSuccess)
                                                .Select(i => i.ResponseText)
                                                .ToArray();
                                        DeleteConfirmationDiv.Visible = true;
                                        ShowDeleteConfirmationMsg();
                                        deleteRunAwayDiv.Visible = true;
                                        runawayDetailsDiv.Visible = true;
                                        deleteRunAwayRequestButton.Visible = false;
                                        break;
                                    }
                                case ResultsCodes.ActionTransactionError:
                                    {
                                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                                        ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement,
                                            FailureReasons.GeneralEsbException);
                                        ShowErrorMsg();
                                        DeleteConfirmationDiv.Visible = false;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            ArrMessages = new[] { result.Description };
                            ShowSuccessMsg();
                            laborerUserControl.ResetUserControl = true;
                            DeleteConfirmationDiv.Visible = false;
                            deleteRunAwayDiv.Visible = false;
                            runawayDetailsDiv.Visible = false;
                            //Update Grid 
                            if (GetRunAwayRequestSession == null) return;
                            if (GetAllRunAwayRequestsSession == null || !GetAllRunAwayRequestsSession.Any()) return;
                            var currentRequest =
                                GetAllRunAwayRequestsSession.FirstOrDefault(
                                    x => x.RequestNumber == GetRunAwayRequestSession.RequestNumber);
                            if (currentRequest == null) return;
                            GetAllRunAwayRequestsSession.Remove(currentRequest);
                            currentRequest.RunAwayRequestStatusName =
                                TypedObjects.GetStatusName(TypedObjects.StatusType.RunAwayRequestStatus,
                                    TypedObjects.RunAwayRequestStatus.Canceled.GetHashCode());
                            currentRequest.RunAwayRequestStatusId =
                                TypedObjects.RunAwayRequestStatus.Canceled.GetHashCode();
                            currentRequest.IsEligibleToCancel = false;
                            GetAllRunAwayRequestsSession.Add(currentRequest);
                            GetRunAwayRequestSession = null;
                            runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                            runawayRequestsGridView.DataBind();
                        }
                    }
                    else
                    {
                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                        ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement,
                            FailureReasons.GeneralEsbException);
                        ShowErrorMsg();
                    }
                }
                catch
                {
                    ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                    ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement,
                        FailureReasons.GeneralEsbException);
                    ShowErrorMsg();
                    deleteRunAwayDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #endregion

        #region Events

        #region Load

        /// <summary>
        /// Load page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IsCurrentUserHasPrivilege((long)PrivilegeList.CancelLaborRunAwayCreateRequest);
                ucValidateBusinessUser.LoggingService = ServicesList.CancelRunAway;
                ucValidateBusinessUser.OriginalService = ServiceList.CancelRunaway;
                DeleteConfirmationDiv.Visible = false;
                if (IsPostBack) return;
                IsRunawayDetailsVisible = false;
                IsAllRunawayRequestsVisibles = false;
                deleteRunAwayDiv.Visible = false;
                laborDiv.Visible = true;
                runawayDetailsDiv.Visible = false;
                GetAllRunAwayRequestsSession = null;
                GetRunAwayRequestSession = null;
                validateRequesterEstablishmentUsersDiv.Visible = LoadSetting();
                neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                FilesSession = new List<FileModel>();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region Privillages Controls

        /// <summary>
        /// sucess path
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ucValidateBusinessUser_OnRequesterValidated(object sender, EventArgs e)
        {
            try
            {
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
                deleteRunAwayDiv.Visible = false;
                laborDiv.Visible = true;
                RunwayRequestCardDiv.Visible = true;
                selectRunawayDropDownList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// cancel path
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ucValidateBusinessUser_OnRequesterValidatedCanceled(object sender, EventArgs e)
        {
            try
            {
                RunwayRequestCardDiv.Visible = false;
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
                deleteRunAwayDiv.Visible = false;
                laborDiv.Visible = false;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region طريقة البحث 

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void selectRunawayDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var control = (DropDownList)sender;
                if (string.IsNullOrEmpty(control.SelectedItem.Value)) return;
                // عامل معين 
                if (control.SelectedItem.Value == StaticBusinessKeys.SpecificRunAwayRequest.ToString())
                {
                    laborDiv.Visible = true;
                    allRunawayRequestsDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                    deleteRunAwayDiv.Visible = false;
                    GetAllRunAwayRequestsSession = null;
                    GetRunAwayRequestSession = null;
                }
                else
                {
                    #region كل الطلبات

                    laborDiv.Visible = false;
                    GetAllRunAwayRequestsSession = null;
                    GetRunAwayRequestSession = null;
                    var result = GetAllRunAwayRequestsList(runawayRequestsGridView.PageSize, 1);
                    if (result != null)
                    {
                        BindListOfRunAwayRequest(result);
                    }
                    else
                    {
                        var message = GetSystemMessage(TypedObjects.RAMSMSG01);
                        ArrMessages = new[] { message.ResponseText };
                        ShowErrorMsg();
                        allRunawayRequestsDiv.Visible = true;
                        runawayRequestsGridView.DataSource = null;
                        runawayRequestsGridView.DataBind();
                    }

                    #endregion
                }
                laborerUserControl.ResetUserControl = true;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region بلاغ تغيب معين 

        /// <summary>
        /// delegate user control
        /// </summary>
        protected void laborerUserControl_OnSearchFinished()
        {
            try
            {
                if (laborerUserControl.IsIqamaNumberValid || laborerUserControl.IsBoundaryNumberValid)
                {
                    if (string.IsNullOrEmpty(laborerUserControl.IqamaNumber) &&
                        string.IsNullOrEmpty(laborerUserControl.BorderNumber))
                    {
                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.EmptyMessage };
                        ShowErrorMsg();
                        runawayDetailsDiv.Visible = false;
                        return;
                    }
                    var result = GetRunAwayRequest(laborerUserControl.IqamaNumber, laborerUserControl.BorderNumber);
                    if (result != null)
                    {
                        BindRunAwayRequest(result);
                    }
                    else
                    {
                        var message = GetSystemMessage(TypedObjects.RAMSMSG02);
                        ArrMessages = new[] { message.ResponseText };
                        ShowErrorMsg();
                        runawayDetailsDiv.Visible = false;
                        deleteRunAwayDiv.Visible = false;
                    }
                }
                else
                {
                    runawayDetailsDiv.Visible = false;
                    deleteRunAwayDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region Grid Actions  

        /// <summary>
        /// show RunAway Request Details from cached results
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void runawayRequestsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (GetAllRunAwayRequestsSession != null)
                {
                    if (string.IsNullOrEmpty(e.CommandName) ||
                        e.CommandName != StaticBusinessKeys.RequestNumberCommand.ToString())
                        return;
                    if (string.IsNullOrEmpty(e.CommandArgument?.ToString())) return;
                    var request =
                        GetAllRunAwayRequestsSession.FirstOrDefault(
                            x => x.RequestNumber == e.CommandArgument.ToString());
                    if (request != null)
                    {
                        BindRunAwayRequest(request);
                    }
                }
                else
                {
                    ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                    ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement,
                        FailureReasons.GeneralEsbException);
                    ShowErrorMsg();
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// call when select next page index .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void runawayRequestsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                var result = GetAllRunAwayRequestsList(runawayRequestsGridView.PageSize, (e.NewPageIndex + 1));
                if (result != null)
                {
                    //Bind Request data 
                    var runAwayRetrieveRequestInfo = result.FirstOrDefault();
                    if (runAwayRetrieveRequestInfo != null)
                        runawayRequestsGridView.VirtualItemCount = runAwayRetrieveRequestInfo.TotalRowsCount;
                    //next page index 
                    runawayRequestsGridView.PageIndex = e.NewPageIndex;
                    //cach result 
                    GetAllRunAwayRequestsSession = result.ToList();
                    //bind data 
                    runawayRequestsGridView.DataSource = result.ToList();
                    runawayRequestsGridView.DataBind();
                    //hide delete div 
                    deleteRunAwayDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                }
                else
                {
                    ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                    ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement,
                        FailureReasons.GeneralEsbException);
                    ShowErrorMsg();
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// download attached file
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void attachmentsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.CommandName) ||
                    e.CommandName != StaticBusinessKeys.RunAwayFilesPathsFieldCommand.ToString()) return;
                if (!string.IsNullOrEmpty(e.CommandArgument?.ToString()) && GetRunAwayRequestSession != null)
                {
                    DownloadFile(e.CommandArgument.ToString(), GetRunAwayRequestSession.RequestNumber);
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// bind string data to grid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void attachmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }
                var itemIndex = e.Row.RowIndex;
                if (itemIndex < 0 || GetRunAwayRequestSession == null) return;
                var fileItem = GetRunAwayRequestSession.FilesPaths.ToArray()[itemIndex];
                var filePathLinkButton = e.Row.FindControl("filePathLinkButton") as LinkButton;
                if (filePathLinkButton == null) return;
                filePathLinkButton.Text = fileItem;
                filePathLinkButton.CommandArgument = fileItem;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region الملفات

        #region رفع الملفات المطلوبة

        /// <summary>
        /// Upload the needed documents
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Upload(object sender, EventArgs e)
        {
            try
            {
                if (FilesSession == null)
                {
                    FilesSession = new List<FileModel>();
                }
                new FileUtility().UploadFile(neededDocumentFileUpload, FileUploadCustomError, MaxFilesSize, FilesSession);
                BindFilesToGrid();
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void DeleteFile(object sender, EventArgs e)
        {
            try
            {
                var linkButton = sender as LinkButton;
                if (linkButton != null)
                {
                    var fileName = linkButton.CommandArgument;
                    var file = FilesSession.FirstOrDefault(f => f.Name == fileName);
                    if (file != null)
                        FilesSession.Remove(file);
                }
                BindFilesToGrid();
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        /// <summary>
        /// delete RunAway Request
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// BindRunAwayRequest
        protected void deleteRunAwayRequest_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            CompleteCancelBusiness();
        }

        #endregion

        #region Cancel Confirmation 

        /// <summary>
        /// Accept Action
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void acceptButton_Click(object sender, EventArgs e)
        {
            IsConfirmed = true;
            CompleteCancelBusiness();
        }

        /// <summary>
        /// Reject Action
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void cancelButton_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            DeleteConfirmationDiv.Visible = false;
        }

        #endregion

        #endregion
    }
}