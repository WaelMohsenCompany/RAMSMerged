// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="ReviewRunawayComplain.aspx.cs" company="">
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
using RAMS.BusinessServices.Get;
using RAMS.BusinessServices.Post;
using RAMS.CrossCutting;
using RAMS.WebApp.Services.RAMS.Base;
using CommonUtilities = Mol.Common.CommonUtilities;

namespace RAMS.WebApp.Services.RAMS.MyClients
{
    /// <inheritdoc />
    /// <summary>
    /// Class ReviewRunawayComplain.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public partial class ReviewRunawayComplain : RamsBasePage
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
            /// All requests
            /// </summary>
            AllRequests, //ddl option 
            /// <summary>
            /// The specific request
            /// </summary>
            SpecificRequest, //ddl  option 
            /// <summary>
            /// The request number command
            /// </summary>
            RequestNumberCommand, //grid command 
            /// <summary>
            /// The make appointment
            /// </summary>
            MakeAppointment, //تحديد موعد
            /// <summary>
            /// The register statement
            /// </summary>
            RegisterStatement, //  تسجيل إفادة مكتب العمل
            /// <summary>
            /// The laborer appointment
            /// </summary>
            LaborerAppointment,
            /// <summary>
            /// The establishment appointment
            /// </summary>
            EstablishmentAppointment,
            /// <summary>
            /// The laborer and establishment appointment
            /// </summary>
            LaborerAndEstablishmentAppointment,
            /// <summary>
            /// The run away files paths field command
            /// </summary>
            RunAwayFilesPathsFieldCommand,
            /// <summary>
            /// The complaint files paths
            /// </summary>
            ComplaintFilesPaths
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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is iqama number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is iqama number valid; otherwise, <c>false</c>.</value>
        protected bool IsIqamaNumberValid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is Boundary Number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is Boundary Number valid; otherwise, <c>false</c>.</value>
        protected bool IsBoundaryNumberValid { get; set; }

        /// <summary>
        /// return Laborer  Office Id
        /// </summary>
        /// <value>The state of the laborer office identifier view.</value>
        protected string LaborerOfficeIdViewState
        {
            get => ViewState["LaborerOfficeId"].ToString();
            set => ViewState["LaborerOfficeId"] = value;
        }

        #endregion

        #region Sessions 

        /// <summary>
        /// Gets the get all run away requests session key.
        /// </summary>
        /// <value>The complaints session key.</value>
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
        private List<RunAwayReviewRequestsInfo> GetAllRunAwayRequestsSession
        {
            get => Session[GetAllRunAwayRequestsSessionKey] as List<RunAwayReviewRequestsInfo>;
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
        private RunAwayReviewRequestsInfo GetRunAwayRequestSession
        {
            get => Session[GetRunAwayRequestSessionKey] as RunAwayReviewRequestsInfo;
            set => Session[GetRunAwayRequestSessionKey] = value;
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
        /// Get list of
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="requestStatus">The request status.</param>
        /// <param name="userLaborerOfficeId">The user laborer office identifier.</param>
        /// <param name="establishmentLaborerOfficeId">The establishment laborer office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="requestNumber">The request number.</param>
        /// <param name="iqamaNumber">The iqama number.</param>
        /// <param name="bounderyNumber">The boundary number.</param>
        private void GetReviewRunAwayRequestsList(int pageIndex, string requestStatus,
            string userLaborerOfficeId, string establishmentLaborerOfficeId, string establishmentSequenceNumber
            , string requestNumber, string iqamaNumber, string bounderyNumber)
        {
            var response = GetForReviewRunAwayRequestsList(runawayRequestsGridView.PageSize, pageIndex,
                requestStatus, userLaborerOfficeId, establishmentLaborerOfficeId,
                establishmentSequenceNumber, requestNumber, iqamaNumber, bounderyNumber);
            if (response != null && response.Any())
            {
                BindDataToGrid(response, pageIndex - 1);
            }
            else
            {
                var message = GetSystemMessage(TypedObjects.RAMSMSG02);
                if (message != null)
                {
                    ArrMessages = new[] { message.ResponseText };
                    ShowErrorMsg();
                    ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                }
                allRunawayRequestsDiv.Visible = false;
            }
            runawayDetailsDiv.Visible = false;
        }

        /// <summary>
        /// set list of result objects  to  grid
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="pageIndex">Index of the page.</param>
        private void BindDataToGrid(HashSet<RunAwayReviewRequestsInfo> response, int pageIndex)
        {
            if (response.Any())
            {
                //total rows 
                var runAwayReviewRequestsInfo = response.FirstOrDefault();
                if (runAwayReviewRequestsInfo != null)
                    runawayRequestsGridView.VirtualItemCount = runAwayReviewRequestsInfo.TotalRowsCount;
                //current page index
                runawayRequestsGridView.PageIndex = pageIndex;
                //Bind data to grid 
                runawayRequestsGridView.DataSource = response.ToList();
                runawayRequestsGridView.DataBind();
                //cache result 
                GetAllRunAwayRequestsSession = response.ToList();
                GetRunAwayRequestSession = null;
                //hide divs 
                runawayDetailsDiv.Visible = false;
                allRunawayRequestsDiv.Visible = true;
            }
            else
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
            }
        }

        /// <summary>
        /// bind data to request details div
        /// </summary>
        /// <param name="response">The response.</param>
        private void BindRunAwayRequest(RunAwayReviewRequestsInfo response)
        {
            if (response == null) return;
            GetRunAwayRequestSession = response;
            makeAppointmentDiv.Visible = false;
            registerStatementDiv.Visible = false;
            actionButtonsDiv.Visible = false;
            laborOfficeResponseTextBox.Text = "";
            #region bind data 
            // رقم البلاغ المرجعي
            runawayRequestNumberLiteral.Text = response.RunAwayRequestNumber;
            //اسم النشأة
            establismentNameLiteral.Text = response.EstablishmentTitle;
            //رقم المنشأة
            establishmentNumberLiteral.Text = response.LaborOfficeId + "-" + response.SequenceNumber;
            //اسم العامل
            laborNameLiteral.Text = response.LaborerFullName;
            //رقم العامل
            laborIdLiteral.Text = response.LaborerIdNumber.ToString();
            //تاريخ تقديم البلاغ
            runawayDateLiteral.Text = response.RunAwayRequestDate.ToShortDateString() + " - " +
                                      Utilities.ConvertToHijriFormate(response.RunAwayRequestDate);
            //الوقت
            runawayTimeLiteral.Text = response.RunAwayRequestDate.ToShortTimeString();
            //تاريخ تقديم طلب إثبات الكيدية
            runawayComplainDateLiteral.Text = response.ComplaintRequestDate.ToShortDateString() + " - " +
                                      Utilities.ConvertToHijriFormate(response.ComplaintRequestDate);
            //متى بدأ الوافد العمل لديكم
            LaborerStartWorkDateLiteral.Text = !string.IsNullOrEmpty(response.RunAwayQuestion1?.ToString())
                ? response.RunAwayQuestion1.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(response.RunAwayQuestion1.Value)
                : "لا يوجد";
            //متى كانت نهاية العمل
            LaborerEndWorkDateLiteral.Text = !string.IsNullOrEmpty(response.RunAwayQuestion2?.ToString())
                ? response.RunAwayQuestion2.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(response.RunAwayQuestion2.Value)
                : "لا يوجد";
            //متى تم تسليم آخر راتب للوافد
            LastLaborerSalaryLiteral.Text = !string.IsNullOrEmpty(response.RunAwayQuestion3?.ToString())
                ? response.RunAwayQuestion3.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(response.RunAwayQuestion3.Value)
                : "لا يوجد";
            //سبب انتهاء العلاقة العمالية
            if (Web.CrossCutting.TypedObjects.IsBase64String(response.RunAwayQuestion4))
            {
                reasonEndLaborerRelationShipTextBox.Text = !string.IsNullOrEmpty(response.RunAwayQuestion4)
                    ? Web.CrossCutting.TypedObjects.Base64Decode(response.RunAwayQuestion4)
                    : "لا يوجد";
            }
            else
            {
                reasonEndLaborerRelationShipTextBox.Text = !string.IsNullOrEmpty(response.RunAwayQuestion4)
                    ? response.RunAwayQuestion4
                    : "لا يوجد";
            }
            //تاريخ بدأت العمل
            StartingDateLiteral.Text = !string.IsNullOrEmpty(response.ComplaintQuestion1?.ToString())
                ? response.ComplaintQuestion1.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(response.ComplaintQuestion1.Value)
                : "لا يوجد";
            //تاريخ نهاية العمل
            StopingDateLiteral.Text = !string.IsNullOrEmpty(response.ComplaintQuestion2?.ToString())
                ? response.ComplaintQuestion2.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(response.ComplaintQuestion2.Value)
                : "لا يوجد";
            //تاريخ آخر راتب تم استلام
            lastSalaryLiteral.Text = !string.IsNullOrEmpty(response.ComplaintQuestion3?.ToString())
                ? response.ComplaintQuestion3.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(response.ComplaintQuestion3.Value)
                : "لا يوجد";
            //سبب التوقف عن العمل
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
            //المرفقات - خدمة بلاغ التغيب عن العمل 
            if (response.RunAwayFilesPaths != null && response.RunAwayFilesPaths.Any())
            {
                runAwayattachmentsGridView.DataSource = response.RunAwayFilesPaths.ToList();
                runAwayattachmentsGridView.DataBind();
            }
            else
            {
                runAwayattachmentsGridView.DataSource = null;
                runAwayattachmentsGridView.DataBind();
            }
            //المرفقات - إثبات كيدية بلاغ التغيب 
            if (response.ComplaintFilesPaths != null && response.ComplaintFilesPaths.Any())
            {
                complaintRequestGridView.DataSource = response.ComplaintFilesPaths.ToList();
                complaintRequestGridView.DataBind();
            }
            else
            {
                complaintRequestGridView.DataSource = null;
                complaintRequestGridView.DataBind();
            }
            if (!string.IsNullOrEmpty(response.LaborOfficeReplyDetails))
            {
                if (Web.CrossCutting.TypedObjects.IsBase64String(response.LaborOfficeReplyDetails))
                {
                    laborOfficeResponseTextBox.Text =
                        !string.IsNullOrEmpty(response.LaborOfficeReplyDetails)
                            ? Web.CrossCutting.TypedObjects.Base64Decode(response.LaborOfficeReplyDetails)
                            : "";
                }
                else
                {
                    laborOfficeResponseTextBox.Text =
                        !string.IsNullOrEmpty(response.LaborOfficeReplyDetails)
                            ? response.LaborOfficeReplyDetails
                            : "";
                }
            }
            //  بنفتح الطلب مرة تانية بعد تحديد معاد فى المرة الاولى 
            if (response.ComplaintRequestStatusId ==
                (int)TypedObjects.ComplaintRequestStatus.ReviewAppointmentTime)
            {
                decisionOptionsDiv.Visible = false;
                makeAppointmentDiv.Visible = false;
                registerStatementDiv.Visible = true;
                decisionOptionsRadioButtonList.SelectedIndex = 1;
                followButton.Visible = true;
            }
            else
            {
                // الطلب يفتح اول مرة من مكتب العمل 
                decisionOptionsDiv.Visible = true;
                makeAppointmentDiv.Visible = true;
                registerStatementDiv.Visible = false;
                decisionOptionsRadioButtonList.SelectedIndex = 0;
                followButton.Visible = false;
            }
            actionButtonsDiv.Visible = true;
            runawayDetailsDiv.Visible = true;
            ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToRequestDetails", "scrollToRequestDetails()", true);
            #endregion
        }

        #endregion

        #region  Business Service Methods

        /// <summary>
        /// Get List Of Review Requests
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="requestStatus">The request status.</param>
        /// <param name="userLaborerOfficeId">The user laborer office identifier.</param>
        /// <param name="establishmentLaborerOfficeId">The establishment laborer office identifier.</param>
        /// <param name="establishmentSequenceNumber">The establishment sequence number.</param>
        /// <param name="requestNumber">The request number.</param>
        /// <param name="iqamaNumber">The iqama number.</param>
        /// <param name="bounderyNumber">The boundery number.</param>
        /// <returns>HashSet&lt;RunAwayReviewRequestsInfo&gt;.</returns>
        protected HashSet<RunAwayReviewRequestsInfo> GetForReviewRunAwayRequestsList(int pageSize, int currentPage,
            string requestStatus,
            string userLaborerOfficeId, string establishmentLaborerOfficeId, string establishmentSequenceNumber,
            string requestNumber, string iqamaNumber, string bounderyNumber)
        {
            var currentUser = GetCurrentUser();
            if (string.IsNullOrEmpty(currentUser?.LaborOfficeId.ToString()) || currentUser.IdNumber == null) return null;
            return _getBusinessService.GetForReviewRunAwayRequestsList(
                !string.IsNullOrEmpty(userLaborerOfficeId) ? int.Parse(userLaborerOfficeId) : 0,
                (TypedObjects.ComplaintRequestStatus)
                    Enum.Parse(typeof(TypedObjects.ComplaintRequestStatus), requestStatus),
                !string.IsNullOrEmpty(establishmentLaborerOfficeId)
                    ? int.Parse(establishmentLaborerOfficeId)
                    : (int?)null,
                !string.IsNullOrEmpty(establishmentSequenceNumber)
                    ? int.Parse(establishmentSequenceNumber)
                    : (long?)null,
                !string.IsNullOrEmpty(iqamaNumber) ? long.Parse(iqamaNumber) : (long?)null,
                !string.IsNullOrEmpty(bounderyNumber) ? long.Parse(bounderyNumber) : (long?)null,
                !string.IsNullOrEmpty(requestNumber) ? requestNumber : "", pageSize, currentPage,
                currentUser.IdNumber.Value);
        }

        /// <summary>
        /// تحديد موعد
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="requestContextType">Type of the request context.</param>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg UpdateComplaintRequestByReviewAppointment(int runAwayRequestId, string requestContextType)
        {
            var currentUser = GetCurrentUser();
            if (string.IsNullOrEmpty(currentUser?.LaborOfficeId.ToString())) return null;
            if (makeAppointmentRadioButtonList.SelectedValue == "") return null;
            return _postBusinessService.UpdateComplaintRequestByReviewAppointment(runAwayRequestId,
                long.Parse(currentUser.IdNumber.ToString()),
                requestContextType ==
                TypedObjects.ReviewAppointmentType.EstablishmentAppointment.ToString()
                    ? TypedObjects.ReviewAppointmentType.EstablishmentAppointment
                    : requestContextType ==
                      TypedObjects.ReviewAppointmentType.LaborerAndEstablishmentAppointment
                          .ToString()
                        ? TypedObjects.ReviewAppointmentType.LaborerAndEstablishmentAppointment
                        : TypedObjects.ReviewAppointmentType.LaborerAppointment, GetClientIpAddress());
        }

        /// <summary>
        /// تسجيل إفادة مكتب العمل
        /// </summary>
        /// <param name="runAwayRequestId">The run away request identifier.</param>
        /// <param name="reviewResult">The review result.</param>
        /// <param name="reviewResultsType">Type of the review results.</param>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg UpdateComplaintRequestWithReviewResults(int runAwayRequestId,
            string reviewResult, TypedObjects.ReviewResultsType reviewResultsType)
        {
            var currentUser = GetCurrentUser();
            if (string.IsNullOrEmpty(currentUser?.LaborOfficeId.ToString())) return null;
            return _postBusinessService.UpdateComplaintRequestByReviewResults(runAwayRequestId, reviewResult,
                long.Parse(currentUser.IdNumber.ToString()), reviewResultsType, GetClientIpAddress());
        }

        /// <summary>
        /// GetSystemSettings
        /// </summary>
        /// <param name="messageCode">The message code.</param>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg GetSystemMessage(string messageCode)
        {
            var user = GetCurrentUser();
            return user?.IdNumber != null ? _getBusinessService.GetSystemMessages(messageCode, user.IdNumber.Value) : null;
        }

        #endregion

        #endregion

        #region Events

        #region Page Load 

        /// <summary>
        /// Load Page .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IsCurrentUserHasPrivilege((long)PrivilegeList.RAMS_ReviewRunawayComplain);
                //CultureInfo.CurrentCulture = new CultureInfo("ar-SA");
                if (IsPostBack) return;
                #region Clean cached data 
                GetAllRunAwayRequestsSession = null;
                GetRunAwayRequestSession = null;
                #endregion

                #region Get Review RunAway Requests List 
                reviewRunawayComplaintDiv.Visible = true;
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
                sequenceNumberTextBox.Text = "";
                laborerOfficeIdTextBox.Text = "";
                LaborerOfficeIdViewState = null;
                requestNumberPart1TextBox.Text = "";
                requestNumberPart3TextBox.Text = "";
                iqamaNumberTextBox.Text = "";
                bounderyNumberTextBox.Text = "";
                #endregion
                #region Privllages
                if (GetCurrentUser().LaborOfficeId != null &&
                    !string.IsNullOrEmpty(GetCurrentUser().LaborOfficeId.ToString()))
                {
                    //Set Current Laborer Office Id
                    laborerOfficeIdTextBox.Text = GetCurrentUser().LaborOfficeId.ToString();
                    laborerOfficeIdTextBox.Enabled = false;
                }
                else
                {
                    laborerOfficeIdTextBox.Enabled = true;
                }
                #endregion
                //fill laborer office number into  request number  text box .
                requestNumberPart2Literal.Text = CurrentUser.LaborOfficeId.ToString();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region Search

        /// <summary>
        /// select by iqama number or  border  number .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void LaborerRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = laborerRadioButtonList.SelectedValue;
                //تحديد موعد
                if (selectedValue == "IqamaNumber")
                {
                    iqamaNumberDiv.Visible = true;
                    borderNumberDiv.Visible = false;
                    iqamaNumberTextBox.Text = string.Empty;
                    bounderyNumberTextBox.Text = string.Empty;
                }
                else
                {
                    iqamaNumberDiv.Visible = false;
                    borderNumberDiv.Visible = true;
                    iqamaNumberTextBox.Text = string.Empty;
                    bounderyNumberTextBox.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// search criteria
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void SearchRunAwayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(iqamaNumberTextBox.Text) && !IsIqamaNumberValid))
                {
                    allRunawayRequestsDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                    return;
                }
                if ((!string.IsNullOrEmpty(bounderyNumberTextBox.Text) && !IsBoundaryNumberValid))
                {
                    allRunawayRequestsDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                    return;
                }
                if (!string.IsNullOrEmpty(sequenceNumberTextBox.Text))
                {
                    int.TryParse(sequenceNumberTextBox.Text, out var value);
                    if (value == 0)
                    {
                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.EstablishmentNumberMessage };
                        ShowErrorMsg();
                        allRunawayRequestsDiv.Visible = false;
                        runawayDetailsDiv.Visible = false;
                        return;
                    }
                }
                LaborerOfficeIdViewState = laborerOfficeIdTextBox.Text;
                //in case of we set laborer office to  textbox from base page  , 
                // we will use laborer office in our code from base page again [ Security Point]
                var isRequestNumverValid = !string.IsNullOrEmpty(requestNumberPart1TextBox.Text) &&
                                            !string.IsNullOrEmpty(requestNumberPart2Literal.Text) &&
                                            !string.IsNullOrEmpty(requestNumberPart3TextBox.Text);
                GetReviewRunAwayRequestsList(1, selectRequestStatusDropDownList.SelectedItem.Value,
                    CurrentUser.LaborOfficeId.ToString(),
                    (GetCurrentUser().LaborOfficeId != null &&
                     !string.IsNullOrEmpty(GetCurrentUser().LaborOfficeId.ToString()))
                        ? GetCurrentUser().LaborOfficeId.ToString()
                        : LaborerOfficeIdViewState,
                    sequenceNumberTextBox.Text,
                    isRequestNumverValid
                        ? (requestNumberPart3TextBox.Text + "-" + CurrentUser.LaborOfficeId + "-" +
                           requestNumberPart1TextBox.Text)
                        : "", iqamaNumberTextBox.Text,
                    bounderyNumberTextBox.Text);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region Grid Actions 

        /// <summary>
        /// show specific request from grid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void runawayRequestsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (GetAllRunAwayRequestsSession == null) return;
                if (string.IsNullOrEmpty(e.CommandName) ||
                    e.CommandName != StaticBusinessKeys.RequestNumberCommand.ToString()) return;
                if (e.CommandArgument == null || string.IsNullOrEmpty(e.CommandArgument.ToString())) return;
                var request =
                    GetAllRunAwayRequestsSession.FirstOrDefault(
                        x => x.RunAwayRequestNumber == e.CommandArgument.ToString());
                if (request != null)
                {
                    BindRunAwayRequest(request);
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
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// change page index
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void runawayRequestsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //in case of we set laborer office to  textbox from base page  , 
                // we will use laborer office in our coe from base page again [ Security Point]
                GetReviewRunAwayRequestsList(e.NewPageIndex + 1, selectRequestStatusDropDownList.SelectedValue,
                    CurrentUser.LaborOfficeId.ToString(),
                    (GetCurrentUser().LaborOfficeId != null &&
                     !string.IsNullOrEmpty(GetCurrentUser().LaborOfficeId.ToString()))
                        ? GetCurrentUser().LaborOfficeId.ToString()
                        : LaborerOfficeIdViewState,
                    sequenceNumberTextBox.Text, requestNumberPart3TextBox.Text + "-" + CurrentUser.LaborOfficeId + "-" +
                                                requestNumberPart1TextBox.Text, iqamaNumberTextBox.Text,
                    bounderyNumberTextBox.Text);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #region المرفقات - خدمة بلاغ التغيب عن العمل

        /// <summary>
        /// المرفقات - خدمة بلاغ التغيب عن العمل
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void runAwayattachmentsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (GetAllRunAwayRequestsSession != null)
                {
                    if (!string.IsNullOrEmpty(e.CommandName) &&
                        e.CommandName == StaticBusinessKeys.RunAwayFilesPathsFieldCommand.ToString())
                    {
                        if (e.CommandArgument != null && !string.IsNullOrEmpty(e.CommandArgument.ToString()) &&
                            GetRunAwayRequestSession != null)
                        {
                            DownloadFile(e.CommandArgument.ToString(), GetRunAwayRequestSession.RunAwayRequestNumber);
                        }
                    }
                }
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ShowErrorMsg();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// during data binding .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void runAwayattachmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }
                var itemIndex = e.Row.RowIndex;
                if (itemIndex < 0 || GetRunAwayRequestSession == null) return;
                var fileItem = GetRunAwayRequestSession.RunAwayFilesPaths.ToArray()[itemIndex];
                var filePathLinkButton = e.Row.FindControl("filePathLinkButton") as LinkButton;
                if (filePathLinkButton == null) return;
                filePathLinkButton.Text = fileItem;
                filePathLinkButton.CommandArgument = fileItem;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region  المرفقات - إثبات كيدية بلاغ التغيب

        /// <summary>
        /// المرفقات - إثبات كيدية بلاغ التغيب
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
        protected void complaintRequestGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (GetAllRunAwayRequestsSession != null)
                {
                    if (!string.IsNullOrEmpty(e.CommandName) &&
                        e.CommandName == StaticBusinessKeys.ComplaintFilesPaths.ToString())
                    {
                        if (e.CommandArgument != null && !string.IsNullOrEmpty(e.CommandArgument.ToString()) &&
                            GetRunAwayRequestSession != null)
                        {
                            DownloadFile(e.CommandArgument.ToString(), GetRunAwayRequestSession.RunAwayRequestNumber);
                        }
                    }
                }
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ShowErrorMsg();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// during data bind
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
        protected void complaintRequestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.DataRow)
                {
                    return;
                }
                var itemIndex = e.Row.RowIndex;
                if (itemIndex < 0 || GetRunAwayRequestSession == null) return;
                var fileItem = GetRunAwayRequestSession.ComplaintFilesPaths.ToArray()[itemIndex];
                var filePathLinkButton = e.Row.FindControl("filePathLinkButton") as LinkButton;
                if (filePathLinkButton == null) return;
                filePathLinkButton.Text = fileItem;
                filePathLinkButton.CommandArgument = fileItem;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #endregion

        #region Server validations 

        /// <summary>
        /// ValidateIqamaNumber
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="ServerValidateEventArgs" /> instance containing the event data.</param>
        protected void ValidateIqamaNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = true;
                if (CommonUtilities.IsIDNumberValid(args.Value))
                {
                    IsIqamaNumberValid = true;
                    return;
                }
                args.IsValid = false;
                IsIqamaNumberValid = false;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// ValidateBoundaryNumber
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="ServerValidateEventArgs" /> instance containing the event data.</param>
        protected void validateBoundaryNumber_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                args.IsValid = true;
                if (CommonUtilities.IsIDNumberValid(args.Value))
                {
                    IsBoundaryNumberValid = true;
                    return;
                }
                args.IsValid = false;
                IsBoundaryNumberValid = false;
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region Actions

        /// <summary>
        /// select saving Options
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void DecisionOptionsRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = decisionOptionsRadioButtonList.SelectedValue;
                //تحديد موعد
                if (selectedValue == StaticBusinessKeys.MakeAppointment.ToString())
                {
                    makeAppointmentDiv.Visible = true;
                    registerStatementDiv.Visible = false;
                    actionButtonsDiv.Visible = true;
                    followButton.Visible = false;
                }
                else
                {
                    makeAppointmentDiv.Visible = false;
                    registerStatementDiv.Visible = true;
                    actionButtonsDiv.Visible = true;
                    laborOfficeResponseTextBox.Text = "";
                    if (GetRunAwayRequestSession != null)
                    {
                        if (!string.IsNullOrEmpty(GetRunAwayRequestSession.LaborOfficeReplyDetails))
                        {
                            if (
                                Web.CrossCutting.TypedObjects.IsBase64String(
                                    GetRunAwayRequestSession.LaborOfficeReplyDetails))
                            {
                                laborOfficeResponseTextBox.Text =
                                    Web.CrossCutting.TypedObjects.Base64Decode(
                                        GetRunAwayRequestSession.LaborOfficeReplyDetails);
                            }
                            else
                            {
                                laborOfficeResponseTextBox.Text =
                                        GetRunAwayRequestSession.LaborOfficeReplyDetails;
                            }
                        }
                    }
                    else
                    {
                        laborOfficeResponseTextBox.Text = "";
                    }
                    followButton.Visible = true;
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// save request
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetRunAwayRequestSession != null)
                {
                    //بنفتح الطلب اول مرة 
                    var selectedValue = decisionOptionsRadioButtonList.SelectedValue;
                    #region تحديد موعد
                    if (selectedValue == StaticBusinessKeys.MakeAppointment.ToString())
                    {
                        //  تحديد الموعد لاى فئه العامل ام المؤسسة ام الاتنين  
                        var result = UpdateComplaintRequestByReviewAppointment(GetRunAwayRequestSession.RunAwayRequestId,
                            makeAppointmentRadioButtonList.SelectedValue);
                        if (result != null)
                        {
                            // Sucess Path :  Update request status & Send to TWSL Engine.
                            if (result.IsSuccess)
                            {
                                ArrMessages = new[] { result.ResponseText };
                                ShowSuccessMsg();
                                actionButtonsDiv.Visible = false;
                                registerStatementDiv.Visible = false;
                                makeAppointmentDiv.Visible = false;
                                decisionOptionsDiv.Visible = false;
                                runawayDetailsDiv.Visible = false;
                                //Remove request from list and bind again 
                                var currentRequest = GetAllRunAwayRequestsSession.FirstOrDefault(
                                    x => x.RunAwayRequestId == GetRunAwayRequestSession.RunAwayRequestId);
                                if (currentRequest == null) return;
                                GetAllRunAwayRequestsSession.Remove(currentRequest);
                                runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                                runawayRequestsGridView.DataBind();
                                return;
                            }
                            //Request status not changed 
                            ArrMessages = new[] { result.ResponseText };
                            ShowErrorMsg();
                            actionButtonsDiv.Visible = false;
                            registerStatementDiv.Visible = false;
                            makeAppointmentDiv.Visible = false;
                            decisionOptionsDiv.Visible = false;
                            runawayDetailsDiv.Visible = false;
                            return;
                        }
                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                        ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain,
                            FailureReasons.GeneralEsbException);
                        ShowErrorMsg();
                    }
                    #endregion

                    #region تسجيل إفادة مكتب العمل

                    else
                    {
                        if (!string.IsNullOrEmpty(laborOfficeResponseTextBox.Text))
                        {
                            if (laborOfficeResponseTextBox.Text.Length > 500)
                            {
                                laborOfficeResponseTextBox.BorderColor = Color.Red;
                                ArrMessages = new[] { Web.CrossCutting.TypedObjects.MessageSize };
                                ShowErrorMsg();
                                return;
                            }
                            var response =
                                UpdateComplaintRequestWithReviewResults(GetRunAwayRequestSession.RunAwayRequestId,
                                    Web.CrossCutting.TypedObjects.Base64Encode(laborOfficeResponseTextBox.Text),
                                    TypedObjects.ReviewResultsType.FinalResult);
                            if (response != null)
                            {
                                ArrMessages = new[] { response.ResponseText };
                                if (response.IsSuccess)
                                {
                                    ShowSuccessMsg();
                                    //Remove request from list and bind again 
                                    var currentRequest = GetAllRunAwayRequestsSession.FirstOrDefault(
                                        x => x.RunAwayRequestId == GetRunAwayRequestSession.RunAwayRequestId);
                                    if (currentRequest != null)
                                    {
                                        GetAllRunAwayRequestsSession.Remove(currentRequest);
                                        runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                                        runawayRequestsGridView.DataBind();
                                    }
                                }
                                else
                                    ShowErrorMsg();
                                runawayDetailsDiv.Visible = false;
                                return;
                            }
                        }
                        else
                        {
                            ArrMessages = new[] { Web.CrossCutting.TypedObjects.LaborOfficeResponseMessage };
                            ShowErrorMsg();
                            return;
                        }
                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                        ShowErrorMsg();
                    }

                    #endregion
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
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// Follow Request  , request we again opened to  update
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void followButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetRunAwayRequestSession != null)
                {
                    #region تسجيل إفادة مكتب العمل

                    if (!string.IsNullOrEmpty(laborOfficeResponseTextBox.Text))
                    {
                        if (laborOfficeResponseTextBox.Text.Length > 500)
                        {
                            laborOfficeResponseTextBox.BorderColor = Color.Red;
                            ArrMessages = new[] { Web.CrossCutting.TypedObjects.MessageSize };
                            ShowErrorMsg();
                            return;
                        }
                        var response =
                            UpdateComplaintRequestWithReviewResults(GetRunAwayRequestSession.RunAwayRequestId,
                                Web.CrossCutting.TypedObjects.Base64Encode(laborOfficeResponseTextBox.Text),
                                TypedObjects.ReviewResultsType.InProgressResult);
                        if (response != null)
                        {
                            ArrMessages = new[] { response.ResponseText };
                            if (response.IsSuccess)
                            {
                                //Remove request from list and bind again 
                                var currentRequest = GetAllRunAwayRequestsSession.FirstOrDefault(
                                    x => x.RunAwayRequestId == GetRunAwayRequestSession.RunAwayRequestId);
                                if (currentRequest != null)
                                {

                                    GetAllRunAwayRequestsSession.Remove(currentRequest);
                                    if (!string.IsNullOrEmpty(laborOfficeResponseTextBox.Text))
                                    {
                                        currentRequest.LaborOfficeReplyDetails =
                                            Web.CrossCutting.TypedObjects.Base64Encode(laborOfficeResponseTextBox.Text);
                                    }
                                    GetAllRunAwayRequestsSession.Add(currentRequest);
                                    runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                                    runawayRequestsGridView.DataBind();
                                }
                                ShowSuccessMsg();
                            }
                            else
                                ShowErrorMsg();
                            runawayDetailsDiv.Visible = false;
                            return;
                        }
                    }
                    else
                    {
                        ArrMessages = new[] { Web.CrossCutting.TypedObjects.LaborOfficeResponseMessage };
                        ShowErrorMsg();
                        return;
                    }
                    ArrMessages = new[] { Web.CrossCutting.TypedObjects.GeneralSystemError };
                    ShowErrorMsg();
                    #endregion
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
                ExceptionHelper.LogError(ServicesList.RAMS_CreateRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}