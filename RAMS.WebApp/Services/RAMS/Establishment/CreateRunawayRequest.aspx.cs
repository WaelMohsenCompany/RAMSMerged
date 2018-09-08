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

namespace RAMS.WebApp.Services.RAMS.Establishment
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
        /// get business service 
        /// </summary>
        /// <summary>
        /// The get business service
        /// </summary>
        private readonly GetBusinessService _getBusinessService = new GetBusinessService();

        /// <summary>
        /// post business service 
        /// </summary>
        /// <summary>
        /// The post business service
        /// </summary>
        private readonly PostBusinessService _postBusinessService = new PostBusinessService();

        #endregion

        #region Properties 

        #region General 

        /// <summary>
        /// Gets or sets the array messages.
        /// </summary>
        /// <value>
        /// رسائل الخطأ أو النجاح
        /// </value>
        /// <summary>
        /// Gets or sets the arr messages.
        /// </summary>
        /// <value>The arr messages.</value>
        public string[] ArrMessages { get; set; }

        #endregion

        #region Business Properties 

        /// <summary>
        /// Gets or sets a value indicating whether this instance is iqama number valid.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is iqama number valid; otherwise, <c>false</c>.
        /// </value>
        /// <summary>
        /// Gets or sets a value indicating whether this instance is iqama number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is iqama number valid; otherwise, <c>false</c>.</value>
        protected bool IsIqamaNumberValid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is Boundary Number valid.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is Boundary Number valid; otherwise, <c>false</c>.
        /// </value>
        /// <summary>
        /// Gets or sets a value indicating whether this instance is boundary number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is boundary number valid; otherwise, <c>false</c>.</value>
        protected bool IsBoundaryNumberValid { get; set; }

        /// <summary>
        /// Gets or Sets a list of uploaded files
        /// </summary>
        /// <summary>
        /// Gets or sets the name of the laborer.
        /// </summary>
        /// <value>The name of the laborer.</value>
        private string LaborerName
        {
            get => ViewState["laborerName"].ToString();
            set => ViewState["laborerName"] = value;
        }

        /// <summary>
        /// Sets a value indicating whether uploaded files section visible or not 
        /// value=true only when the worker Iqama or Boundary number is valid
        /// </summary>
        /// <summary>
        /// Sets a value indicating whether this instance is uploaded files section visible.
        /// </summary>
        /// <value><c>true</c> if this instance is uploaded files section visible; otherwise, <c>false</c>.</value>
        private bool IsUploadedFilesSectionVisible
        {
            set
            {
                fileUploadDiv.Visible = value;
                uploadedDocumentsGrid.Visible = value;
            }
        }

        /// <summary>
        /// Sets a value indicating whether runaway request section visible or not 
        /// </summary>
        /// <summary>
        /// Sets a value indicating whether this instance is runaway request card div visible.
        /// </summary>
        /// <value><c>true</c> if this instance is runaway request card div visible; otherwise, <c>false</c>.</value>
        private bool IsRunawayRequestCardDivVisible
        {
            set => RunawayRequestCardDiv.Visible = value;
        }

        #endregion

        #region View States 

        /// <summary>
        /// Maximum count of files the user can upload
        /// </summary>
        /// <summary>
        /// Gets or sets the maximum files count.
        /// </summary>
        /// <value>The maximum files count.</value>
        public int MaxFilesCount
        {
            get => ViewState["maxFilesCount"] != null ? Convert.ToInt32(ViewState["maxFilesCount"]) : 2;
            set => ViewState["maxFilesCount"] = value;
        }

        /// <summary>
        /// Maximum file size the user can upload in MB
        /// </summary>
        /// <summary>
        /// Gets or sets the maximum size of the files.
        /// </summary>
        /// <value>The maximum size of the files.</value>
        public int MaxFilesSize
        {
            get => ViewState["maxFilesSize"] != null ? Convert.ToInt32(ViewState["maxFilesSize"]) : 2;
            set => ViewState["maxFilesSize"] = value;
        }

        /// <summary>
        /// Min Files Size
        /// </summary>
        /// <summary>
        /// Gets or sets the minimum size of the files.
        /// </summary>
        /// <value>The minimum size of the files.</value>
        public int MinFilesSize
        {
            get => ViewState["MinFilesSize"] != null ? Convert.ToInt32(ViewState["MinFilesSize"]) : 0;
            set => ViewState["MinFilesSize"] = value;
        }

        #endregion

        #region Session 

        /// <value>The complaints session key.</value>
        /// <summary>
        /// Gets or sets the files session key.
        /// </summary>
        /// <value>The files session key.</value>
        private string FilesSessionKey
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
        /// [ERROR: invalid expression PropertyAccessText] [ERROR: invalid expression PropertyName.Words.TheAndAll].
        /// </summary>
        /// <param name="parametersEnumeration">The parameters enumeration.</param>
        /// <value>[ERROR: invalid expression PropertyName.Words.TheAndAllAsSentence].</value>
        protected List<FileModel> FilesSession
        {
            get => Session[FilesSessionKey] as List<FileModel>;
            set => Session[FilesSessionKey] = value;
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
            var minFilesSizeSet = GetSystemSettings(TypedObjects.SystemSettings.MinimumFileSizeInKilo);
            MaxFilesCount = maxFilesCountSet;
            MaxFilesSize = maxFilesSizeSet;
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

        #endregion

        #region Business Service Methods 

        /// <summary>
        /// Check Laborer Create RunAway Business Rules
        /// </summary>
        /// <returns>HashSet&lt;ResponseMsg&gt;.</returns>
        private HashSet<ResponseMsg> CheckEstablishmentCreateRunAwayBusinessRules()
        {
            try
            {
                var user = GetCurrentUser();
                var establishment = GetEstablishment();
                if (user == null || establishment == null) return null;
                if (user.IdNumber != null)
                    return _getBusinessService.CheckCreateRunAwayEstablishmentBusinessRules(
                        Convert.ToInt32(establishment.LaborOfficeId), Convert.ToInt64(establishment.SequenceNumber),
                        user.IdNumber.Value);
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
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        private ActionResults<HashSet<ResponseMsg>> CheckLaborerCreateRunAwayBusinessRules()
        {
            try
            {
                ViewState["laborerIdNumber"] = laborerUserControl.IqamaNumber;
                ViewState["borderNumber"] = laborerUserControl.BorderNumber;
                var establishment = GetEstablishment();
                var user = GetCurrentUser();
                if (user?.IdNumber != null)
                {
                    return _getBusinessService.CheckCreateRunAwayLaborerBusinessRules(
                        !string.IsNullOrEmpty(laborerUserControl.IqamaNumber)
                            ? long.Parse(laborerUserControl.IqamaNumber)
                            : (long?)null,
                        !string.IsNullOrEmpty(laborerUserControl.BorderNumber)
                            ? long.Parse(laborerUserControl.BorderNumber)
                            : (long?)null, true,
                        Convert.ToInt32(establishment.LaborOfficeId), Convert.ToInt64(establishment.SequenceNumber),
                        user.IdNumber.Value);
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
        /// Create Runaway Request
        /// </summary>
        /// <param name="question1">The question1.</param>
        /// <param name="question2">The question2.</param>
        /// <param name="question3">The question3.</param>
        /// <param name="question4">The question4.</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        private ActionResults<HashSet<ResponseMsg>> CreateRunAwayRequest(string question1, string question2,
            string question3, string question4)
        {
            try
            {
                var user = GetCurrentUser();
                var establishment = GetEstablishment();
                if (user.IdNumber != null && establishment != null)
                {
                    return _postBusinessService.CreateRunAwayRequest(new RunAwayCreateRequestInfo
                    {
                        LaborerIdNumber =
                            !string.IsNullOrEmpty(ViewState["laborerIdNumber"].ToString())
                                ? Convert.ToInt64(ViewState["laborerIdNumber"]?.ToString())
                                : (long?)null,
                        LaborerBorderNumber =
                            !string.IsNullOrEmpty(ViewState["borderNumber"].ToString())
                                ? long.Parse(ViewState["borderNumber"].ToString())
                                : (long?)null,
                        LaborerFullName = LaborerName,
                        LaborerOfficeId = int.Parse(establishment.LaborOfficeId),
                        SequenceNumber = long.Parse(establishment.SequenceNumber),
                        EstablishmentId = establishment.PkEstablishmentId.ToString(),
                        EstablishmentTitle = establishment.EstablishmentName,
                        FilesPaths = FilesSession.Select(f => f.Path).ToHashSet(),
                        ApplicantUserIdNumber = user.IdNumber.Value,
                        CreatedByIdNumber = user.IdNumber.Value,
                        IsRequestByEstablishmentAgent = true,
                        CreationQuestion1 = DateTime.Parse(question1),
                        CreationQuestion2 = DateTime.Parse(question2),
                        CreationQuestion3 = DateTime.Parse(question3),
                        CreationQuestion4 = question4,
                        ClientIPAddress = GetClientIpAddress()
                    });
                }
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
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
        /// check establishment business rules
        /// </summary>
        private void CheckEstablishmentBusinessRules()
        {
            // call business service to check establishment business rules  
            var result = CheckEstablishmentCreateRunAwayBusinessRules();
            if (result != null)
            {
                //if we have failure Business rules  , we will show list of failed business rules messages 
                if (result.Any(c => !c.IsSuccess))
                {
                    ArrMessages = result.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                    ShowErrorMsg();
                    IsRunawayRequestCardDivVisible = false;
                }
                else
                {
                    //in case no problem in Business rules  we will complete scenario correctly 
                    IsRunawayRequestCardDivVisible = true;
                }
            }
            else
            {
                // in case we have exception during calling business service layer,
                // we will show general error messages and will hide divs obtain business logic
                IsRunawayRequestCardDivVisible = false;
            }
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg GetSystemMessage(string messageCode)
        {
            try
            {
                var user = GetCurrentUser();
                if (user?.IdNumber != null)
                {
                    return _getBusinessService.GetSystemMessages(messageCode, user.IdNumber.Value);
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
        /// GetSystemSettings
        /// </summary>
        /// <param name="targetSetting">The target setting.</param>
        /// <returns>System.Int32.</returns>
        private int GetSystemSettings(TypedObjects.SystemSettings targetSetting)
        {
            try
            {
                var user = GetCurrentUser();
                return user?.IdNumber != null ? _getBusinessService.GetSystemSettings(targetSetting, user.IdNumber.Value) : 0;
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

        #region PageLoad 

        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SMSConfirmationControl.SMSConfirmationSucceeded += SMSConfirmationControl_Succeeded;
                SMSConfirmationControl.SMSConfirmationValidationError += SMSConfirmationControl_Error;
                neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                if (IsPostBack) return;
                CheckEstablishmentBusinessRules();
                BindFilesToGrid();
                IsUploadedFilesSectionVisible = false;
                LaborerStartWorkDateCalendar.Controls.Clear();
                LaborerEndWorkDateDualSmartCalendar.Controls.Clear();
                LastLaborerSalaryDualSmartCalendar.Controls.Clear();
                reasonEndLaborerRelationShipTextBox.Text = string.Empty;
                requestInfoDiv.Visible = false;
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

        #region Search

        /// <summary>
        /// Search With Iqama Or Boundary Number
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
                        if (!result.IsSuccess)
                        {
                            ArrMessages =
                                result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                            requestInfoDiv.Visible = false;
                            ShowErrorMsg();
                        }
                        else
                        {
                            //Set Laborer Name , send to  create method 
                            var firstOrDefault = result.ResultsList.FirstOrDefault();
                            if (firstOrDefault != null) LaborerName = firstOrDefault.ResponseText ?? "";
                            if (LoadSetting())
                            {
                                laborerNameLiteral.Text = LaborerName;
                                IsUploadedFilesSectionVisible = true;
                                IsRunawayRequestCardDivVisible = true;
                                questionsDiv.Visible = true;
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
                    }
                }
                else
                {
                    BindFilesToGrid();
                    IsUploadedFilesSectionVisible = false;
                    questionsDiv.Visible = false;
                    AgreementDiv.Visible = false;
                    requestInfoDiv.Visible = false;
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

        #region SMS Confirmation

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SMSConfirmation.SMSConfirmationSucceededEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void SMSConfirmationControl_Succeeded(object sender,
            SMSConfirmation.SMSConfirmationSucceededEventArgs e)
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
                var result = CreateRunAwayRequest(
                    LaborerStartWorkDateCalendar.GregorianDate,
                    LaborerEndWorkDateDualSmartCalendar.GregorianDate,
                    LastLaborerSalaryDualSmartCalendar.GregorianDate,
                    Web.CrossCutting.TypedObjects.Base64Encode(reasonEndLaborerRelationShipTextBox.Text));
                if (result != null)
                {
                    //in case true  ,  so request  created successfully .
                    if (result.IsSuccess)
                    {
                        ArrMessages = new[] { result.Description };
                        ShowSuccessMsg();
                        ClearPage();
                        IsRunawayRequestCardDivVisible = false;
                    }
                    else
                    {
                        // we will check reason of error message 
                        //In case we have Failed BR . 
                        switch (result.ResultsCode)
                        {
                            case ResultsCodes.BusinessRulesViolationError:
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                                IsRunawayRequestCardDivVisible = false;
                                break;
                            case ResultsCodes.ActionTransactionError:
                                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayRequest,
                                    FailureReasons.GeneralEsbException);
                                ShowErrorMsg();
                                break;
                            case ResultsCodes.BusinessRulesViolationWarning:
                                break;
                            case ResultsCodes.BusinessRulesSucceeded:
                                break;
                            case ResultsCodes.ActionTransactionSucceeded:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
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

        /// <summary>
        /// failed
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SMSConfirmation.SMSConfirmationValidationErrorEventArgs"/> instance containing the event data.</param>
        private void SMSConfirmationControl_Error(object sender,
            SMSConfirmation.SMSConfirmationValidationErrorEventArgs e)
        {

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
                SMSConfirmationControl.StartSMSConfirmation("CreateRunawayRequest",
                    ServicesList.RAMS_CreateRunawayRequest);
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