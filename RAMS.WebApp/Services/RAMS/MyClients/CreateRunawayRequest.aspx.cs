// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="CreateRunawayRequest.aspx.cs" company="">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Mol.Common;
using Mol.Entities;
using RAMS.BusinessServices.Get;
using RAMS.BusinessServices.Post;
using RAMS.CrossCutting;
using RAMS.WebApp.Services.RAMS.Base;
using RAMS.WebApp.Services.RAMS.Models;
using RAMS.WebApp.Services.RAMS.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoggingUtilities;
using Mol.Web.Common.UI.UserControls;
using CommonUtilities = Mol.Common.CommonUtilities;

namespace RAMS.WebApp.Services.RAMS.MyClients
{
    /// <inheritdoc />
    /// <summary>
    /// Class CreateRunawayRequest.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public partial class CreateRunawayRequest : RamsBasePage
    {
        #region Fields 

        /// <summary>
        /// Get Business service
        /// </summary>
        private readonly GetBusinessService _getBusinessService = new GetBusinessService();

        /// <summary>
        /// post business service
        /// </summary>
        private readonly PostBusinessService _postBusinessService = new PostBusinessService();

        #endregion

        #region Properties 

        /// <summary>
        /// Laborer Name
        /// </summary>
        private string _laborerName;

        /// <summary>
        /// Gets or sets the array messages.
        /// </summary>
        /// <value>The array messages.</value>
        protected string[] ArrMessages { get; set; }

        /// <summary>
        /// Gets or Sets a list of uploaded files
        /// </summary>
        /// <value>The name of the laborer.</value>
        protected string LaborerName
        {
            get => ViewState["laborerName"] == null ? _laborerName : ViewState["laborerName"]?.ToString();
            set => _laborerName = value;
        }

        /// <summary>
        /// Sets a value indicating whether uploaded files section visible or not
        /// value= true only when the worker Iqama or Boundary number is valid
        /// </summary>
        /// <value><c>true</c> if this instance is uploaded files section visible; otherwise, <c>false</c>.</value>
        protected bool IsUploadedFilesSectionVisible
        {
            set
            {
                fileUploadDiv.Visible = value;
                uploadedDocumentsGrid.Visible = value;
            }
        }

        /// <summary>
        /// Sets a value indicating whether this instance is runaway request card div visible.
        /// </summary>
        /// <value><c>true</c> if this instance is runaway request card div visible; otherwise, <c>false</c>.</value>
        protected bool IsRunawayRequestCardDivVisible
        {
            set => mainCardDiv.Visible = value;
        }


        #region Sessions

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

        #region ViewStates

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
            get
            {
                if (ViewState["maxFilesSize"] != null)
                {
                    return Convert.ToInt32(ViewState["maxFilesSize"]);
                }
                return 2;
            }
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
            FilesSession = new List<FileModel>();
            ViewState["iqamaNumber"] = string.Empty;
            ViewState["borderNumber"] = string.Empty;
            FilesSession = new List<FileModel>();
            BindFilesToGrid();
            IsUploadedFilesSectionVisible = false;
            questionsDiv.Visible = false;
            AgreementDiv.Visible = false;
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
            MaxFilesCount = maxFilesCountSet;
            MaxFilesSize = maxFilesSizeSet;
            var minFilesSizeSet = GetSystemSettings(TypedObjects.SystemSettings.MinimumFileSizeInKilo);
            MinFilesSize = minFilesSizeSet;
            return maxFilesCountSet > 0 && maxFilesSizeSet > 0;
        }

        /// <summary>
        /// Bind Uploaded Documents To Document Grid
        /// </summary>
        private void BindFilesToGrid()
        {
            if (FilesSession == null)
            {
                FilesSession = new List<FileModel>();
            }
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
        /// check establishment business rules
        /// </summary>
        private void CheckEstablishmentBusinessRules()
        {
            var result = CheckEstablishmentCreateRunAwayBusinessRules();
            if (result != null)
            {
                if (result.Any(c => !c.IsSuccess))
                {
                    ArrMessages = result.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                    ShowErrorMsg();
                    IsRunawayRequestCardDivVisible = false;
                }
                else
                {
                    IsRunawayRequestCardDivVisible = true;
                }
            }
            else
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                IsRunawayRequestCardDivVisible = false;
            }
        }

        #endregion

        #region Business Service Methods 

        /// <summary>
        /// Check Laborer Create RunAway Business Rules
        /// </summary>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        protected ActionResults<HashSet<ResponseMsg>> CheckLaborerCreateRunAwayBusinessRules()
        {
            try
            {
                ViewState["iqamaNumber"] = laborerUserControl.IqamaNumber;
                ViewState["borderNumber"] = laborerUserControl.BorderNumber;
                if (CurrentUser.IdNumber != null)
                {
                    return _getBusinessService.CheckCreateRunAwayLaborerBusinessRules(
                        !string.IsNullOrEmpty(laborerUserControl.IqamaNumber)
                            ? long.Parse(laborerUserControl.IqamaNumber)
                            : (long?)null,
                        !string.IsNullOrEmpty(laborerUserControl.BorderNumber)
                            ? long.Parse(laborerUserControl.BorderNumber)
                            : (long?)null, false,
                        Convert.ToInt32(ucValidateBusinessUser.LaborOfficeID),
                        Convert.ToInt64(ucValidateBusinessUser.SequenceNo),
                        ucValidateBusinessUser.RequesterIdNo);
                }
                return null;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return null;
            }
        }

        /// <summary>
        /// Check Laborer Create RunAway Business Rules
        /// </summary>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        protected HashSet<ResponseMsg> CheckEstablishmentCreateRunAwayBusinessRules()
        {
            try
            {
                if (CurrentUser.IdNumber != null)
                    return _getBusinessService.CheckCreateRunAwayEstablishmentBusinessRules(
                        Convert.ToInt32(ucValidateBusinessUser.LaborOfficeID),
                        Convert.ToInt64(ucValidateBusinessUser.SequenceNo), ucValidateBusinessUser.RequesterIdNo);
                return null;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return null;
            }
        }

        /// <summary>
        /// Create Runaway Request
        /// </summary>
        /// <param name="question1">The question1.</param>
        /// <param name="question2">The question2.</param>
        /// <param name="question3">The question3.</param>
        /// <param name="question4">The question4.</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        protected ActionResults<HashSet<ResponseMsg>> CreateRunAwayRequest(string question1, string question2,
            string question3, string question4)
        {
            try
            {
                if (CurrentUser.IdNumber != null)
                    return _postBusinessService.CreateRunAwayRequest(
                        new RunAwayCreateRequestInfo
                        {
                            LaborerIdNumber = !string.IsNullOrEmpty(ViewState["iqamaNumber"].ToString())
                                ? Convert.ToInt64(ViewState["iqamaNumber"]?.ToString())
                                : (long?)null,
                            LaborerBorderNumber =
                                !string.IsNullOrEmpty(ViewState["borderNumber"].ToString())
                                    ? long.Parse(ViewState["borderNumber"].ToString())
                                    : (long?)null,
                            LaborerFullName = LaborerName,
                            LaborerOfficeId = ucValidateBusinessUser.LaborOfficeID,
                            SequenceNumber = ucValidateBusinessUser.SequenceNo,
                            EstablishmentId = ucValidateBusinessUser.EstablishmentId.ToString(),
                            EstablishmentTitle = "",
                            FilesPaths = FilesSession.Select(f => f.Path).ToHashSet(),
                            ApplicantUserIdNumber = ucValidateBusinessUser.RequesterIdNo,
                            CreatedByIdNumber = CurrentUser.IdNumber.Value,
                            IsRequestByEstablishmentAgent = false,
                            CreationQuestion1 = DateTime.Parse(question1),
                            CreationQuestion2 = DateTime.Parse(question2),
                            CreationQuestion3 = DateTime.Parse(question3),
                            CreationQuestion4 = question4,
                            ClientIPAddress = GetClientIpAddress()
                        });
                return null;
            }
            catch
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return null;
            }
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="targetSetting">The target setting.</param>
        /// <returns>System.Int32.</returns>
        protected int GetSystemSettings(TypedObjects.SystemSettings targetSetting)
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
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                return 0;
            }
        }

        #endregion

        #endregion

        #region Events

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
                IsCurrentUserHasPrivilege((long)PrivilegeList.LaborRunAwayCreateRequest);
                ucValidateBusinessUser.LoggingService = ServicesList.CreateRunAwayUpdates;
                ucValidateBusinessUser.OriginalService = ServiceList.LaborRunAwayService;
                neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                if (IsPostBack) return;
                IsUploadedFilesSectionVisible = false;
                IsRunawayRequestCardDivVisible = false;
                BindFilesToGrid();
                questionsDiv.Visible = false;
                AgreementDiv.Visible = false;
                requestInfoDiv.Visible = false;
                LaborerStartWorkDateCalendar.Clear();
                LaborerEndWorkDateDualSmartCalendar.Clear();
                LastLaborerSalaryDualSmartCalendar.Clear();
                reasonEndLaborerRelationShipTextBox.Text = string.Empty;
                AgreementCheckBox.Checked = false;
                FilesSession = new List<FileModel>();
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

        #region Privileges Controls

        /// <summary>
        /// success path
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ucValidateBusinessUser_OnRequesterValidated(object sender, EventArgs e)
        {
            try
            {
                IsRunawayRequestCardDivVisible = true;
                CheckEstablishmentBusinessRules();
                requestInfoDiv.Visible = false;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
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
                ClearPage();
                IsRunawayRequestCardDivVisible = false;
                requestInfoDiv.Visible = false;
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

        #region Search

        /// <summary>
        /// Laborers the user control on search finished.
        /// </summary>
        protected void laborerUserControl_OnSearchFinished()
        {
            try
            {
                if (laborerUserControl.IsIqamaNumberValid || laborerUserControl.IsBoundaryNumberValid)
                {
                    var result = CheckLaborerCreateRunAwayBusinessRules();
                    if (result != null)
                    {
                        if (result.IsSuccess)
                        {
                            var firstOrDefault = result.ResultsList.FirstOrDefault();
                            if (firstOrDefault != null) LaborerName = firstOrDefault.ResponseText ?? "";
                            if (LoadSetting())
                            {
                                laborerNameLiteral.Text = LaborerName;
                                IsUploadedFilesSectionVisible = true;
                                questionsDiv.Visible = true;
                                AgreementDiv.Visible = true;
                                AgreementDiv.Visible = true;
                                requestInfoDiv.Visible = true;
                                reasonEndLaborerRelationShipTextBox.Text = string.Empty;
                                AgreementCheckBox.Checked = false;
                                LaborerStartWorkDateCalendar.Clear();
                                LaborerEndWorkDateDualSmartCalendar.Clear();
                                LastLaborerSalaryDualSmartCalendar.Clear();
                                FilesSession = new List<FileModel>();
                                requiedFilesGridView.DataSource = null;
                                requiedFilesGridView.DataBind();
                            }
                        }
                        else
                        {
                            if (result.ResultsCode == ResultsCodes.BusinessRulesViolationWarning)
                            {
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                                var firstOrDefault = result.ResultsList.FirstOrDefault();
                                if (firstOrDefault != null) LaborerName = firstOrDefault.ResponseText ?? "";
                                if (LoadSetting())
                                {
                                    IsUploadedFilesSectionVisible = true;
                                    questionsDiv.Visible = true;
                                    AgreementDiv.Visible = true;
                                    AgreementDiv.Visible = true;
                                    requestInfoDiv.Visible = true;
                                    reasonEndLaborerRelationShipTextBox.Text = string.Empty;
                                    AgreementCheckBox.Checked = false;
                                    LaborerStartWorkDateCalendar.Clear();
                                    LaborerEndWorkDateDualSmartCalendar.Clear();
                                    LastLaborerSalaryDualSmartCalendar.Clear();
                                    FilesSession = new List<FileModel>();
                                    requiedFilesGridView.DataSource = null;
                                    requiedFilesGridView.DataBind();
                                    return;
                                }
                            }
                            if (result.ResultsCode == ResultsCodes.BusinessRulesViolationWarning)
                            {
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                            }
                            if (result.ResultsCode == ResultsCodes.ActionTransactionError)
                            {
                                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest,
                                    FailureReasons.GeneralEsbException);
                                ShowErrorMsg();
                                requestInfoDiv.Visible = false;
                            }
                            if (result.ResultsCode == ResultsCodes.BusinessRulesViolationError)
                            {
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                                questionsDiv.Visible = false;
                                AgreementDiv.Visible = false;
                                requestInfoDiv.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        IsUploadedFilesSectionVisible = false;
                        questionsDiv.Visible = false;
                        AgreementDiv.Visible = false;
                        requestInfoDiv.Visible = false;
                    }
                }
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
                IsUploadedFilesSectionVisible = true;
                BindFilesToGrid();
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
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
                IsUploadedFilesSectionVisible = true;
                BindFilesToGrid();
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
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

        #region إنشاء بلاغ تغيب

        /// <summary>
        /// إنشاء بلاغ التغيب
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void CreateRunwayRequest_Click(object sender, EventArgs e)
        {
            try
            {
                var validationErrorMessages = new List<string>();
                //check files uploaded 
                if (FilesSession == null || FilesSession.Count <= 0)
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
                if (!string.IsNullOrEmpty(LaborerEndWorkDateDualSmartCalendar.GregorianDate) &&
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
                if (reasonEndLaborerRelationShipTextBox.Text.Length > 500)
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
                var result = CreateRunAwayRequest(
                    LaborerStartWorkDateCalendar.GregorianDate,
                    LaborerEndWorkDateDualSmartCalendar.GregorianDate,
                    LastLaborerSalaryDualSmartCalendar.GregorianDate,
                    Web.CrossCutting.TypedObjects.Base64Encode(reasonEndLaborerRelationShipTextBox.Text));
                if (result != null)
                {
                    if (!result.IsSuccess)
                    {
                        switch (result.ResultsCode)
                        {
                            case ResultsCodes.ActionTransactionError:
                                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest,
                                    FailureReasons.GeneralEsbException);
                                ShowErrorMsg();
                                break;
                            case ResultsCodes.BusinessRulesViolationError:
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                                IsUploadedFilesSectionVisible = true;
                                break;
                        }
                    }
                    else
                    {
                        ArrMessages = new[] { result.Description };
                        ShowSuccessMsg();
                        ClearPage();
                        IsRunawayRequestCardDivVisible = true;
                        requestInfoDiv.Visible = false;
                    }
                }
                else
                {
                    IsRunawayRequestCardDivVisible = false;
                }
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