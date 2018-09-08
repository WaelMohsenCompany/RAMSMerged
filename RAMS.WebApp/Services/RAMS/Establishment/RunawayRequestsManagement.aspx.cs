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
    /// Class RunawayRequestsManagement.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public partial class RunawayRequestsManagement : RamsBasePage
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

        #endregion

        #region Properties

        #region General

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

        #endregion

        #region ViewState

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

        #endregion

        #region Business Logic Methods 

        /// <summary>
        /// bind request to UI
        /// </summary>
        /// <param name="result">The result.</param>
        private void BindRunAwayRequest(RunAwayRetrieveRequestInfo result)
        {
            if (result != null)
            {
                //Clean Controls 
                laborerReturnDateToWorkCalendar.Clear();
                FilesSession = new List<FileModel>();
                reasonsCancelationTextBox.Text = "";
                requiedFilesGridView.DataSource = null;
                requiedFilesGridView.DataBind();
                AgreementCheckBox.Checked = false;
                //cache result
                GetRunAwayRequestSession = result;
                //bind data 
                runawayRequestNumberLiteral.Text = result.RequestNumber;
                establismentNameLiteral.Text = result.EstablishmentTitle;
                establishmentNumberLiteral.Text = GetEstablishment().SequenceNumber + "-" +
                                                  GetEstablishment().LaborOfficeId;
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
                    neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                }
                else
                {
                    runawayDetailsDiv.Visible = true;
                    deleteRunAwayDiv.Visible = false;
                }
            }
            ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToRequestDetails", "scrollToRequestDetails()", true);
        }

        /// <summary>
        /// bind list of Run Away Retrieve Request
        /// </summary>
        /// <param name="getAllRunAwayRequestsListResult">The get all run away requests list result.</param>
        private void BindListOfRunAwayRequest(HashSet<RunAwayRetrieveRequestInfo> getAllRunAwayRequestsListResult)
        {
            if (getAllRunAwayRequestsListResult == null || !getAllRunAwayRequestsListResult.Any()) return;
            //cache data 
            GetAllRunAwayRequestsSession = getAllRunAwayRequestsListResult.ToList();
            //Bind      
            if (getAllRunAwayRequestsListResult.FirstOrDefault() != null)
            {
                var awayRetrieveRequestInfo = getAllRunAwayRequestsListResult.FirstOrDefault();
                if (awayRetrieveRequestInfo != null)
                    runawayRequestsGridView.VirtualItemCount = awayRetrieveRequestInfo.TotalRowsCount;
            }
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
        private void LoadSetting()
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
        }

        #endregion

        #region Business Service Methods

        /// <summary>
        /// Get runaway request .
        /// </summary>
        /// <param name="iqamaNumber">The iqama number.</param>
        /// <param name="borderNumber">The border number.</param>
        /// <returns>RunAwayRetrieveRequestInfo.</returns>
        private RunAwayRetrieveRequestInfo GetRunAwayRequest(string iqamaNumber, string borderNumber)
        {
            var establishmentInfo = GetEstablishment();
            if (establishmentInfo == null) return null;
            var idNumber = GetCurrentUser().IdNumber;
            if (idNumber == null) return null;
            return _getBusinessService.GetRunAwayRequest(long.Parse(idNumber.Value.ToString()),
                int.Parse(establishmentInfo.LaborOfficeId),
                int.Parse(establishmentInfo.SequenceNumber),
                !string.IsNullOrEmpty(iqamaNumber) ? long.Parse(iqamaNumber) : (long?)null,
                !string.IsNullOrEmpty(borderNumber) ? long.Parse(borderNumber) : (long?)null
                );
        }

        /// <summary>
        /// Get All Run Away Requests List
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentPage">The current page.</param>
        /// <returns>HashSet&lt;RunAwayRetrieveRequestInfo&gt;.</returns>
        private HashSet<RunAwayRetrieveRequestInfo> GetAllRunAwayRequestsList(int pageSize, int currentPage)
        {
            var idNumber = GetCurrentUser().IdNumber;
            if (idNumber == null) return null;
            var establishmentInfo = GetEstablishment();
            if (establishmentInfo == null) return null;
            return _getBusinessService.GetAllRunAwayRequestsList(long.Parse(idNumber.ToString()),
                int.Parse(establishmentInfo.LaborOfficeId),
                long.Parse(establishmentInfo.SequenceNumber), pageSize, currentPage);
        }

        /// <summary>
        /// delete runAway request
        /// </summary>
        /// <param name="deleteReason">The delete reason.</param>
        /// <param name="dateTime">The date time.</param>
        /// <returns>ActionResults&lt;HashSet&lt;ResponseMsg&gt;&gt;.</returns>
        private ActionResults<HashSet<ResponseMsg>> DeleteRunAwayRequest(string deleteReason, string dateTime)
        {
            var idNumber = GetCurrentUser().IdNumber;
            if (idNumber == null) return null;
            return _postBusinessService.CancelRunAwayRequest(new RunAwayCancelRequestInfo
            {
                ApplicantUserIdNumber = idNumber.Value,
                CreatedByIdNumber = idNumber.Value,
                CancelReason = deleteReason,
                FilesPaths = FilesSession.Select(f => f.Path).ToHashSet(),
                RequestNumber = GetRunAwayRequestSession.RequestNumber,
                CancelQuestion1 = DateTime.Parse(dateTime),
                ClientIPAddress = GetClientIpAddress()
            });
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="targetSetting">The target setting.</param>
        /// <returns>System.Int32.</returns>
        private int GetSystemSettings(TypedObjects.SystemSettings targetSetting)
        {
            var user = GetCurrentUser();
            return user?.IdNumber != null ? _getBusinessService.GetSystemSettings(targetSetting, user.IdNumber.Value) : 0;
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <returns>ResponseMsg.</returns>
        private ResponseMsg GetSystemMessage(string messageCode)
        {
            var user = GetCurrentUser();
            return user?.IdNumber != null ? _getBusinessService.GetSystemMessages(messageCode, user.IdNumber.Value) : null;
        }

        #endregion

        #endregion

        #region Events

        #region Load

        /// <summary>
        /// Load page
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SMSConfirmationControl.SMSConfirmationSucceeded += SMSConfirmationControl_Succeeded;
                SMSConfirmationControl.SMSConfirmationValidationError += SMSConfirmationControl_Error;
                if (IsPostBack) return;
                IsRunawayDetailsVisible = false;
                IsAllRunawayRequestsVisibles = false;
                deleteRunAwayDiv.Visible = false;
                laborDiv.Visible = true;
                runawayDetailsDiv.Visible = false;
                neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                //get default values from db {Min & Max } numbers of files 
                LoadSetting();
                neededDocumentFileUpload.Attributes["onchange"] = "UploadFile(this)";
                selectRunawayDropDownList.SelectedIndex = 0;
                FilesSession = new List<FileModel>();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        #endregion

        #region طريقة البحث 

        /// <summary>
        /// Search type by select from  DDL
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void selectRunawayDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var control = (DropDownList)sender;
                if (string.IsNullOrEmpty(control.SelectedItem.Value)) return;
                // عامل معين   -  show & hidden Divs 
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
                    //كل الطلبات المقدمة من المؤسسة  
                    var result = GetAllRunAwayRequestsList(runawayRequestsGridView.PageSize, 1);
                    if (result != null)
                    {
                        //bind to grid 
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
                //reset laborer user control  to 
                laborerUserControl.ResetUserControl = true;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
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
                    //fire middle-ware 
                    var result = GetRunAwayRequest(laborerUserControl.IqamaNumber, laborerUserControl.BorderNumber);
                    if (result != null)
                    {
                        //Bind Request data 
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
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
                runawayDetailsDiv.Visible = false;
                deleteRunAwayDiv.Visible = false;
            }
        }

        #endregion

        #region Grid Actions  

        /// <summary>
        /// show RunAway Request Details from cached results
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
        protected void runawayRequestsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (GetAllRunAwayRequestsSession != null)
                {
                    if (string.IsNullOrEmpty(e.CommandName) ||
                        e.CommandName != StaticBusinessKeys.RequestNumberCommand.ToString()) return;
                    if (e.CommandArgument == null || string.IsNullOrEmpty(e.CommandArgument.ToString())) return;
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
                    ShowErrorMsg();
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// call when select next page index .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
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
                    //cache result 
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
                    ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                    ShowErrorMsg();
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// download attached file
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
        protected void attachmentsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.CommandName) ||
                    e.CommandName !=
                    StaticBusinessKeys.RunAwayFilesPathsFieldCommand.ToString())
                    return;
                if (!string.IsNullOrEmpty(e.CommandArgument?.ToString()) && GetRunAwayRequestSession != null)
                {
                    DownloadFile(e.CommandArgument.ToString(), GetRunAwayRequestSession.RequestNumber);
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// bind string data to grid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs" /> instance containing the event data.</param>
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
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        #endregion

        #region رفع الملفات المطلوبة

        /// <summary>
        /// Upload the needed documents
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
            }
        }

        #endregion

        #region SMS Confirmation

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SMSConfirmation.SMSConfirmationSucceededEventArgs" /> instance containing the event data.</param>
        protected void SMSConfirmationControl_Succeeded(object sender, SMSConfirmation.SMSConfirmationSucceededEventArgs e)
        {
            try
            {
                var errorMessages = new List<string>();
                //check FilesSession Uploaded
                if (FilesSession == null || !FilesSession.Any())
                {
                    errorMessages.Add(Web.CrossCutting.TypedObjects.NoFilesFiles);
                }
                //Check Agreement 
                if (!AgreementCheckBox.Checked)
                {
                    errorMessages.Add(Web.CrossCutting.TypedObjects.AgreementFieldMessage);
                }
                //check Cancellation reason entered .
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
                if (!string.IsNullOrEmpty(laborerReturnDateToWorkCalendar.GregorianDate) &&
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
                if (GetRunAwayRequestSession != null && !string.IsNullOrEmpty(reasonsCancelationTextBox.Text))
                {
                    var result =
                        DeleteRunAwayRequest(Web.CrossCutting.TypedObjects.Base64Encode(reasonsCancelationTextBox.Text),
                            laborerReturnDateToWorkCalendar.GregorianDate);
                    if (result != null)
                    {
                        if (!result.IsSuccess)
                        {
                            if (result.ResultsCode == ResultsCodes.BusinessRulesViolationError)
                            {
                                ArrMessages =
                                    result.ResultsList.Where(i => !i.IsSuccess).Select(i => i.ResponseText).ToArray();
                                ShowErrorMsg();
                                deleteRunAwayDiv.Visible = false;
                                runawayDetailsDiv.Visible = false;
                            }
                            else if (result.ResultsCode == ResultsCodes.ActionTransactionError)
                            {
                                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement,
                                    FailureReasons.GeneralEsbException);
                                ShowErrorMsg();
                            }
                        }
                        else
                        {
                            ArrMessages = new[] { result.Description };
                            ShowSuccessMsg();
                            laborerUserControl.ResetUserControl = true;
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
                            GetRunAwayRequestSession = currentRequest;
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
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_RunawayRequestsManagement, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                ShowErrorMsg();
                deleteRunAwayDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// failed
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SMSConfirmation.SMSConfirmationValidationErrorEventArgs" /> instance containing the event data.</param>
        protected void SMSConfirmationControl_Error(object sender, SMSConfirmation.SMSConfirmationValidationErrorEventArgs e)
        {

        }

        #endregion

        #region الغاء الطلب

        /// <summary>
        /// delete RunAway Request
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void deleteRunAwayRequest_Click(object sender, EventArgs e)
        {
            try
            {
                SMSConfirmationControl.StartSMSConfirmation("RunawayRequestsManagement", ServicesList.RAMS_RunawayRequestsManagement);
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