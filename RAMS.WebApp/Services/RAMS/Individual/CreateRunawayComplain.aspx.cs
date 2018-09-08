// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="CreateRunawayComplain.aspx.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoggingUtilities;
using Mol.Common;
using Mol.Web.Common.UI.UserControls;
using RAMS.BusinessServices.Get;
using RAMS.BusinessServices.Post;
using RAMS.CrossCutting;
using RAMS.WebApp.Services.RAMS.Base;
using RAMS.WebApp.Services.RAMS.Models;
using RAMS.WebApp.Services.RAMS.Utility;

namespace RAMS.WebApp.Services.RAMS.Individual
{
    /// <inheritdoc />
    /// <summary>
    /// Class CreateRunawayComplain.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public partial class CreateRunawayComplain : RamsBasePage
    {
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

        #region Properties

        #region General

        /// <summary>
        /// Gets or sets the array messages.
        /// </summary>
        /// <value>The array messages.</value>
        protected string[] ArrMessages { get; set; }

        #endregion

        #region Business 

        /// <summary>
        /// Sets a value indicating whether runawayComplainRequestDiv visible or not
        /// </summary>
        /// <value><c>true</c> if this instance is runaway complain request div visible; otherwise, <c>false</c>.</value>
        private bool IsRunawayComplainRequestDivVisible
        {
            set => runawayComplainRequestDiv.Visible = value;
        }

        /// <summary>
        /// RunAway Request Number
        /// </summary>
        /// <value>The run away request number.</value>
        private string RunAwayRequestNumber
        {
            set => runawayNumberLiteral.Text = value;
        }

        /// <summary>
        /// Complaint Request Date
        /// </summary>
        /// <value>The complaint request date.</value>
        private string ComplaintRequestDate
        {
            set => runawayComplainDateLiteral.Text = value;
        }

        /// <summary>
        /// RunAway Request Date
        /// </summary>
        /// <value>The run away request date.</value>
        private string RunAwayRequestDate
        {
            set => runawayRequestDateLiteral.Text = value;
        }

        /// <summary>
        /// Complaint Request Status Name
        /// </summary>
        /// <value>The name of the complaint request status.</value>
        private string ComplaintRequestStatusName
        {
            set => runawayRequestStatusLiteral.Text = value;
        }

        #endregion

        #region ViewStates 

        /// <summary>
        /// Maximum count of files the user can upload
        /// </summary>
        /// <value>The maximum files count.</value>
        protected int MaxFilesCount
        {
            get => ViewState["maxFilesCount"] != null ? Convert.ToInt32(ViewState["maxFilesCount"]) : 2;
            set => ViewState["maxFilesCount"] = value;
        }

        /// <summary>
        /// Maximum file size the user can upload in mb
        /// </summary>
        /// <value>The maximum size of the files.</value>
        protected int MaxFilesSize
        {
            get => ViewState["maxFilesSize"] != null ? Convert.ToInt32(ViewState["maxFilesSize"]) : 2;
            set => ViewState["maxFilesSize"] = value;
        }

        /// <summary>
        /// Runaway Request Id
        /// </summary>
        /// <value>The state of the run away request number view.</value>
        private string RunAwayRequestNumberViewState
        {
            get => ViewState["RunAwayRequestNumber"].ToString();
            set => ViewState["RunAwayRequestNumber"] = value;
        }

        /// <summary>
        /// Runaway Request Id
        /// </summary>
        /// <value>The run away request identifier.</value>
        private int RunAwayRequestId
        {
            get => Convert.ToInt32(ViewState["RunAwayRequestId"]);
            set => ViewState["RunAwayRequestId"] = value;
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

        #region Sessions 

        /// <summary>
        /// Gets the files session key.
        /// </summary>
        /// <value>The complaints session key.</value>
        private string FilesSessionKey
        {
            get
            {
                if (ViewState["FilesSessionKey"] == null)
                    ViewState["FilesSessionKey"] = Guid.NewGuid().ToString();
                return ViewState["FilesSessionKey"] as string;
            }
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


        /// <summary>
        /// Get All RunAway Requests Session
        /// </summary>
        /// <value>The request files paths key.</value>
        private string RequestFilesPathsKey
        {
            get
            {
                if (ViewState["RequestFilesPathsKey"] == null)
                    ViewState["RequestFilesPathsKey"] = Guid.NewGuid().ToString();
                return ViewState["RequestFilesPathsKey"] as string;
            }
        }

        /// <summary>
        /// Session for List of case model.
        /// </summary>
        /// <value>The complaints session.</value>
        private List<string> RequestFilesPathsSession
        {
            get => Session[RequestFilesPathsKey] as List<string>;
            set => Session[RequestFilesPathsKey] = value;
        }

        #endregion

        #endregion

        #region Methods

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
            //ClearPage();
            ScriptManager.RegisterStartupScript(Page, GetType(), "ShowSuccessMsg", "ShowSuccessMsg();", true);
        }

        /// <summary>
        /// Clear Page Controls
        /// </summary>
        private void ClearPage()
        {
            BindFilesToGrid();
            fileUploadDiv.Visible = false;
            IsRunawayComplainRequestDivVisible = false;
        }

        #endregion

        #region Business Logic Methods

        /// <summary>
        /// Load System Setting/Lookups
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool LoadSetting()
        {
            var maxFilesCountSet = GetSystemSettings(TypedObjects.SystemSettings.MaximumNumberOfFiles);
            var maxFilesSizeSet = GetSystemSettings(TypedObjects.SystemSettings.MaximumFileSizeInMega);
            if (maxFilesCountSet <= 0 || maxFilesSizeSet <= 0) return false;
            MaxFilesCount = maxFilesCountSet;
            MaxFilesSize = maxFilesSizeSet;
            var minFilesSizeSet = GetSystemSettings(TypedObjects.SystemSettings.MinimumFileSizeInKilo);
            MinFilesSize = minFilesSizeSet;
            return true;
        }

        /// <summary>
        /// Bind Uploaded Documents To Document Grid
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
        /// bind  laborer details
        /// </summary>
        private void LoadLaborerData()
        {
            //ClearPage();
            var response = GetLatestRunAwayOrComplaintRequest();
            if (response != null)
            {
                DisplayComplaintData(response);
                // فى حالة ان هناك  طلب بلاغ تغيب ولم يتم تقديم طلب اثبات كيدية له بعد 
                if (response.RunAwayRequestStatusId == TypedObjects.RunAwayRequestStatus.Accepted.GetHashCode()
                    && response.ComplaintRequestId == null)
                {
                    if (LoadSetting())
                        fileUploadDiv.Visible = true;
                    requiredDataDiv.Visible = true;
                    displayComplainRequestDetailsDiv.Visible = false;
                }
                //فى حالة انه مقدم طلب اثبات كيدية ولازال تحت الدراسة 
                else if (response.RunAwayRequestStatusId ==
                         TypedObjects.RunAwayRequestStatus.UnderProcessing.GetHashCode())
                {
                    requiredDataDiv.Visible = false;
                    displayComplainRequestDetailsDiv.Visible = true;
                    if (response.FilesPaths != null && response.FilesPaths.Any())
                    {
                        RequestFilesPathsSession = response.FilesPaths;
                        attachmentsGridView.DataSource = response.FilesPaths;
                        attachmentsGridView.DataBind();
                    }
                    else
                    {
                        RequestFilesPathsSession = null;
                        attachmentsGridView.DataSource = null;
                        attachmentsGridView.DataBind();
                    }
                    StartingDateLiteral.Text = !string.IsNullOrEmpty(response.ComplaintQuestion1?.ToString())
                        ? response.ComplaintQuestion1.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(response.ComplaintQuestion1.Value)
                        : "لا يوجد";
                    StopingDateLiteral.Text = !string.IsNullOrEmpty(response.ComplaintQuestion2?.ToString())
                        ? response.ComplaintQuestion2.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(response.ComplaintQuestion2.Value)
                        : "لا يوجد";
                    lastSalaryLiteral.Text = !string.IsNullOrEmpty(response.ComplaintQuestion3?.ToString())
                        ? response.ComplaintQuestion3.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(response.ComplaintQuestion3.Value)
                        : "لا يوجد";
                    if (Web.CrossCutting.TypedObjects.IsBase64String(response.ComplaintQuestion4))
                    {
                        stopWorkingReasonTextBox.Text = !string.IsNullOrEmpty(response.ComplaintQuestion4)
                            ? Web.CrossCutting.TypedObjects.Base64Decode(response.ComplaintQuestion4)
                            : "لا يوجد";
                    }
                    else
                    {
                        stopWorkingReasonTextBox.Text = !string.IsNullOrEmpty(response.ComplaintQuestion4)
                            ? response.ComplaintQuestion4 : "لا يوجد";
                    }
                }
                // فى حالة ان  تم الغاء الطلب او البت فيه  من قبل موظف مكتب العمل بالرفض 
                else
                {
                    var responseMsg = new ResponseMsg();
                    if (response.RunAwayRequestStatusId ==
                        (int)TypedObjects.RunAwayRequestStatus.Rejected)
                    {
                        responseMsg = GetSystemMessage(TypedObjects.RAMSMSG15);
                    }
                    else if (response.RunAwayRequestStatusId ==
                             (int)TypedObjects.RunAwayRequestStatus.Canceled)
                    {
                        responseMsg = GetSystemMessage(TypedObjects.RAMSMSG28);
                    }
                    if (!string.IsNullOrEmpty(responseMsg.ResponseText))
                    {
                        ArrMessages = new[] { responseMsg.ResponseText };
                        ShowErrorMsg();
                    }
                    requiredDataDiv.Visible = false;
                    displayComplainRequestDetailsDiv.Visible = false;
                }
            }
            else
            {
                var messageResult = GetSystemMessage(TypedObjects.RAMSMSG09);
                if (messageResult == null) return;
                ArrMessages = new[] { messageResult.ResponseText };
                ShowErrorMsg();
                ClearPage();
            }
        }

        /// <summary>
        /// عرض بيانات بلاغ التغيب
        /// </summary>
        /// <param name="result">The result.</param>
        private void DisplayComplaintData(ComplaintRetrieveRequestInfo result)
        {
            IsRunawayComplainRequestDivVisible = true;
            RunAwayRequestNumber = result.RunAwayRequestNumber;
            ComplaintRequestDate =
                (result.ComplaintRequestDate == null ||
                 result.ComplaintRequestDate.Value.ToShortDateString() == "01/01/0001")
                    ? "لا يوجد"
                    : result.ComplaintRequestDate.Value.ToString("yyyy/MM/dd") + " - " +
                      Utilities.ConvertToHijriFormate(result.ComplaintRequestDate.Value);
            RunAwayRequestDate = result.RunAwayRequestDate.ToString("yyyy/MM/dd") + " - " +
                                 Utilities.ConvertToHijriFormate(result.RunAwayRequestDate);
            ComplaintRequestStatusName = !string.IsNullOrEmpty(result.ComplaintRequestStatusName)
                ? result.ComplaintRequestStatusName
                : "لا يوجد";
            if (Web.CrossCutting.TypedObjects.IsBase64String(result.RejectReason))
            {
                NotesInCaseRejectionLiteral.Text =
                    result.ComplaintRequestStatusId == (int)TypedObjects.ComplaintRequestStatus.Rejected
                        ? Web.CrossCutting.TypedObjects.Base64Decode(result.RejectReason)
                        : "لا يوجد";
            }
            else
            {
                NotesInCaseRejectionLiteral.Text =
                    result.ComplaintRequestStatusId == (int)TypedObjects.ComplaintRequestStatus.Rejected
                        ? result.RejectReason
                        : "لا يوجد";
            }
            RunAwayRequestId = result.RunAwayRequestId;
            RunAwayRequestNumberViewState = result.RunAwayRequestNumber;
        }

        #endregion

        #region  Business Service Methods

        /// <summary>
        /// Get latest runAway information
        /// </summary>
        /// <returns>ComplaintRetrieveRequestInfo.</returns>
        private ComplaintRetrieveRequestInfo GetLatestRunAwayOrComplaintRequest()
        {
            var currentUser = GetCurrentUser();
            return currentUser.IdNumber != null
                ? _getBusinessService.GetLatestRunAwayOrComplaintRequest(currentUser.IdNumber.Value, null)
                : null;
        }

        /// <summary>
        /// Create Runaway Request
        /// </summary>
        /// <param name="question1">The question1.</param>
        /// <param name="question2">The question2.</param>
        /// <param name="question3">The question3.</param>
        /// <param name="question4">The question4.</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        private ActionResults<HashSet<ResponseMsg>> CreateRunAwayComplaintRequest(string question1, string question2,
            string question3, string question4)
        {
            //Get Current User
            var currentUser = GetCurrentUser();
            // Prepare header
            if (currentUser.IdNumber != null)
            {
                return _postBusinessService.CreateRunAwayComplaintRequest(new ComplaintCreateRequestInfo
                {
                    ApplicantUserIdNumber = currentUser.IdNumber.Value,
                    CreatedByIdNumber = currentUser.IdNumber.Value,
                    FilesPaths = FilesSession.Select(f => f.Path).ToHashSet(),
                    LaborerIdNumber = currentUser.IdNumber.Value,
                    IsRequestByLaborer = true,
                    RunAwayRequestId = RunAwayRequestId,
                    BorderNumber = null, // لا تستخدم فى بوابة الافراد
                    ComplaintQuestion1 = DateTime.Parse(question1),
                    ComplaintQuestion2 = DateTime.Parse(question2),
                    ComplaintQuestion3 = DateTime.Parse(question3),
                    ComplaintQuestion4 = question4,
                    RequestNumber = RunAwayRequestNumberViewState,
                    ClientIPAddress = GetClientIpAddress()
                });
            }
            ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
            ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
            ShowErrorMsg();
            return null;
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="targetSetting">The target setting.</param>
        /// <returns>System.Int32.</returns>
        private int GetSystemSettings(TypedObjects.SystemSettings targetSetting)
        {
            var user = GetCurrentUser();
            return user?.IdNumber != null
                ? _getBusinessService.GetSystemSettings(targetSetting, user.IdNumber.Value)
                : 0;
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <returns>ResponseMsg.</returns>
        private ResponseMsg GetSystemMessage(string messageCode)
        {
            var user = GetCurrentUser();
            return user?.IdNumber != null
                ? _getBusinessService.GetSystemMessages(messageCode, user.IdNumber.Value)
                : null;
        }

        #endregion

        #endregion

        #region Events

        #region On PreInit

        /// <summary>
        /// change master page
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnPreInit(EventArgs e)
        {
            try
            {
                base.OnPreInit(e);
                MasterPageFile = "~/MasterPages/Individual.Master";
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                runawayComplainRequestDiv.Visible = false;
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region Load

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindFilesToGrid();
                    neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                    //Clean Controls 
                    LaborerStartWorkDateCalendar.Clear();
                    LaborerEndWorkDateDualSmartCalendar.Clear();
                    LastLaborerSalaryDualSmartCalendar.Clear();
                    ViewState["selectedFiles"] = null;
                    reasonEndLaborerRelationShipTextBox.Text = "";
                    requiedFilesGridView.DataSource = null;
                    requiedFilesGridView.DataBind();
                    AgreementCheckBox.Checked = false;
                    FilesSession = new List<FileModel>();
                }
                LoadLaborerData();
                SMSConfirmationControl.SMSConfirmationSucceeded += SMSConfirmationControl_Succeeded;
                SMSConfirmationControl.SMSConfirmationValidationError += SMSConfirmationControl_Error;
            }
            catch (Exception ex)
            {
                runawayComplainRequestDiv.Visible = false;
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                runawayComplainRequestDiv.Visible = false;
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

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
                filesUploadingDiv.Visible = true;
                if (FilesSession != null && FilesSession.Any())
                {
                    fileUploadDiv.Visible = true;
                    uploadedDocumentsGrid.Visible = true;
                }
                else
                {
                    fileUploadDiv.Visible = false;
                    uploadedDocumentsGrid.Visible = false;
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                runawayComplainRequestDiv.Visible = false;
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
                fileUploadDiv.Visible = true;
                BindFilesToGrid();
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                runawayComplainRequestDiv.Visible = false;
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #region Attachment Grid Actions

        /// <summary>
        /// bind data to grid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void attachmentsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.CommandName) || e.CommandName != "RunAwayFilesCommand") return;
                if (!string.IsNullOrEmpty(e.CommandArgument?.ToString()))
                {
                    DownloadFile(e.CommandArgument.ToString(), RunAwayRequestNumberViewState);
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                runawayComplainRequestDiv.Visible = false;
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// bid data to grid
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
                if (itemIndex < 0 || RequestFilesPathsSession == null) return;
                var fileItem = RequestFilesPathsSession.ToArray()[itemIndex];
                var filePathLinkButton = e.Row.FindControl("filePathLinkButton") as LinkButton;
                if (filePathLinkButton == null) return;
                filePathLinkButton.Text = fileItem;
                filePathLinkButton.CommandArgument = fileItem;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                runawayComplainRequestDiv.Visible = false;
                ShowErrorMsg();
            }
        }

        #endregion

        #region SMS Confirmaion

        /// <summary>
        /// Sucess
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SMSConfirmation.SMSConfirmationSucceededEventArgs"/> instance containing the event data.</param>
        protected void SMSConfirmationControl_Succeeded(object sender,
            SMSConfirmation.SMSConfirmationSucceededEventArgs e)
        {
            try
            {
                var validationErrorMessages = new List<string>();
                if (!FilesSession.Any())
                {
                    validationErrorMessages.Add(Web.CrossCutting.TypedObjects.NoFilesFiles);
                }
                //check Questions & Agreement 
                if (string.IsNullOrEmpty(LaborerStartWorkDateCalendar.GregorianDate) ||
                    string.IsNullOrEmpty(LaborerEndWorkDateDualSmartCalendar.GregorianDate) ||
                    string.IsNullOrEmpty(LastLaborerSalaryDualSmartCalendar.GregorianDate) ||
                    string.IsNullOrEmpty(reasonEndLaborerRelationShipTextBox.Text))
                {
                    validationErrorMessages.Add(Web.CrossCutting.TypedObjects.MandatoryFieldMessage);
                }
                //check  dates entered 
                if (!string.IsNullOrEmpty(LaborerStartWorkDateCalendar.GregorianDate) &&
                    DateTime.Parse(LaborerStartWorkDateCalendar.GregorianDate) >= DateTime.Now)
                {
                    validationErrorMessages.Add(Web.CrossCutting.TypedObjects.LaborerStartWorkDateCalendarError);
                    LaborerStartWorkDateCalendar.BorderColor = Color.Red;
                    LaborerStartWorkDateCalendar.BorderColor = Color.Red;
                    LaborerStartWorkDateCalendar.BorderColor = Color.Red;
                }
                if (!string.IsNullOrEmpty(LaborerEndWorkDateDualSmartCalendar.GregorianDate) &&
                    DateTime.Parse(LaborerEndWorkDateDualSmartCalendar.GregorianDate) >= DateTime.Now)
                {
                    validationErrorMessages.Add(
                        Web.CrossCutting.TypedObjects.LaborerEndWorkDateDualSmartCalendarNextDateError);
                    LaborerEndWorkDateDualSmartCalendar.BorderColor = Color.Red;
                    LaborerEndWorkDateDualSmartCalendar.BorderColor = Color.Red;
                    LaborerEndWorkDateDualSmartCalendar.BorderColor = Color.Red;
                }
                if (
                    !string.IsNullOrEmpty(LaborerEndWorkDateDualSmartCalendar.GregorianDate) &&
                    !string.IsNullOrEmpty(LaborerStartWorkDateCalendar.GregorianDate) &&
                    DateTime.Parse(LaborerEndWorkDateDualSmartCalendar.GregorianDate) <=
                    DateTime.Parse(LaborerStartWorkDateCalendar.GregorianDate))
                {
                    validationErrorMessages.Add(
                        Web.CrossCutting.TypedObjects.LaborerEndWorkDateDualSmartCalendarCompareError);
                    LaborerEndWorkDateDualSmartCalendar.BorderColor = Color.Red;
                    LaborerEndWorkDateDualSmartCalendar.BorderColor = Color.Red;
                    LaborerEndWorkDateDualSmartCalendar.BorderColor = Color.Red;
                }
                if (!string.IsNullOrEmpty(LastLaborerSalaryDualSmartCalendar.GregorianDate) &&
                    DateTime.Parse(LastLaborerSalaryDualSmartCalendar.GregorianDate) > DateTime.Now)
                {
                    validationErrorMessages.Add(
                        Web.CrossCutting.TypedObjects.LaborerEndWorkDateDualSmartCalendarNextError);
                    LastLaborerSalaryDualSmartCalendar.BorderColor = Color.Red;
                    LastLaborerSalaryDualSmartCalendar.BorderColor = Color.Red;
                    LastLaborerSalaryDualSmartCalendar.BorderColor = Color.Red;
                }

                //Check Agreement 
                if (!AgreementCheckBox.Checked)
                {
                    validationErrorMessages.Add(Web.CrossCutting.TypedObjects.AgreementFieldMessage);
                }
                if (string.IsNullOrEmpty(reasonEndLaborerRelationShipTextBox.Text) ||
                    reasonEndLaborerRelationShipTextBox.Text.Length > 500)
                {
                    reasonEndLaborerRelationShipTextBox.BorderColor = Color.Red;
                    validationErrorMessages.Add(Web.CrossCutting.TypedObjects.MessageSize);
                }
                if (validationErrorMessages.Any())
                {
                    ArrMessages = validationErrorMessages.ToArray();
                    ShowErrorMsg();
                    return;
                }
                //Create RunAway Request.
                var result = CreateRunAwayComplaintRequest(LaborerStartWorkDateCalendar.GregorianDate,
                    LaborerEndWorkDateDualSmartCalendar.GregorianDate,
                    LastLaborerSalaryDualSmartCalendar.GregorianDate,
                    Web.CrossCutting.TypedObjects.Base64Encode(reasonEndLaborerRelationShipTextBox.Text));
                if (result != null)
                {
                    if (result.IsSuccess)
                    {
                        ArrMessages = new[] { result.Description };
                        ShowSuccessMsg();
                        runawayComplainRequestDiv.Visible = false;
                    }
                    else
                    {
                        switch (result.ResultsCode)
                        {
                            case ResultsCodes.BusinessRulesViolationError:
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                                break;
                            case ResultsCodes.ActionTransactionError:
                                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain,
                                    FailureReasons.GeneralEsbException);
                                ShowErrorMsg();
                                runawayComplainRequestDiv.Visible = false;
                                break;
                        }
                        ClearPage();
                    }
                }
                else
                {
                    ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                    ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                    ShowErrorMsg();
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                runawayComplainRequestDiv.Visible = false;
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        /// <summary>
        /// failed
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SMSConfirmation.SMSConfirmationValidationErrorEventArgs"/> instance containing the event data.</param>
        protected void SMSConfirmationControl_Error(object sender, SMSConfirmation.SMSConfirmationValidationErrorEventArgs e)
        {

        }

        #endregion

        #region إنشاء طلب إثبات الكيدية

        /// <summary>
        /// create  complaint request
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void CreateComplainButton_Click(object sender, EventArgs e)
        {
            try
            {
                SMSConfirmationControl.StartSMSConfirmation("CreateRunawayComplain",
                    ServicesList.RAMS_CreateRunawayComplain);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
            }
        }

        #endregion

        #endregion
    }
}