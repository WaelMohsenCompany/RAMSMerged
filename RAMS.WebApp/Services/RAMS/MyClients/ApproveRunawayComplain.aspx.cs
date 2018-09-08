// ***********************************************************************
// Assembly         : RAMS.WebApp
// Author           : WaelMohsen
// Created          : 08-15-2018
//
// Last Modified By : WaelMohsen
// Last Modified On : 09-03-2018
// ***********************************************************************
// <copyright file="ApproveRunawayComplain.aspx.cs" company="">
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
using SOATypedObject = RAMS.CrossCutting.TypedObjects;
using TypedObjects = RAMS.Web.CrossCutting.TypedObjects;

namespace RAMS.WebApp.Services.RAMS.MyClients
{
    /// <inheritdoc />
    /// <summary>
    /// Class ApproveRunawayComplain.
    /// </summary>
    /// <seealso cref="!:RAMS.WebApp.Services.RAMS.Base.RamsBasePage" />
    public partial class ApproveRunawayComplain : RamsBasePage
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
            /// The not processed requests
            /// </summary>
            NotProcessedRequests,
            /// <summary>
            /// The replied by labor office
            /// </summary>
            RepliedByLaborOffice,
            /// <summary>
            /// The accepted requests
            /// </summary>
            AcceptedRequests,
            /// <summary>
            /// The rejected requests
            /// </summary>
            RejectedRequests,
            /// <summary>
            /// The request number command
            /// </summary>
            RequestNumberCommand,
            /// <summary>
            /// The run away files paths field command
            /// </summary>
            RunAwayFilesPathsFieldCommand,
            /// <summary>
            /// The complaint files paths
            /// </summary>
            ComplaintFilesPaths
        }

        /// <summary>
        /// Request status Simulate SOA Keys
        /// </summary>
        protected enum RequestStatus
        {
            /// <summary>
            /// The accept
            /// </summary>
            Accept,
            /// <summary>
            /// The reject
            /// </summary>
            Reject,
            /// <summary>
            /// The sent to labor office
            /// </summary>
            SentToLaborOffice
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

        #region Business Properties 

        /// <summary>
        /// Gets or sets a value indicating whether this instance is iqama number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is iqama number valid; otherwise, <c>false</c>.</value>
        private bool IsIqamaNumberValid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is Boundary Number valid.
        /// </summary>
        /// <value><c>true</c> if this instance is Boundary Number valid; otherwise, <c>false</c>.</value>
        private bool IsBoundaryNumberValid { get; set; }

        #endregion

        #region Sessions

        /// <summary>
        /// Gets the labor office information list key.
        /// </summary>
        /// <value>The complaints session key.</value>
        private string LaborOfficeInfoListKey
        {
            get
            {
                if (ViewState["LaborOfficeInfoListKey"] == null)
                    ViewState["LaborOfficeInfoListKey"] = Guid.NewGuid().ToString();
                return ViewState["LaborOfficeInfoListKey"] as string;
            }
        }

        /// <summary>
        /// Session for List of case model.
        /// </summary>
        /// <value>The complaints session.</value>
        protected List<LaborOfficeInfo> LaborOfficeInfoListSession
        {
            get => Session[LaborOfficeInfoListKey] as List<LaborOfficeInfo>;
            set => Session[LaborOfficeInfoListKey] = value;
        }

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
        protected List<RunAwayApprovalRequestInfo> GetAllRunAwayRequestsSession
        {
            get => Session[GetAllRunAwayRequestsSessionKey] as List<RunAwayApprovalRequestInfo>;
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
        protected RunAwayApprovalRequestInfo GetRunAwayRequestSession
        {
            get => Session[GetRunAwayRequestSessionKey] as RunAwayApprovalRequestInfo;
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

        #region validations 

        /// <summary>
        /// ValidateIqamaNumber
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="ServerValidateEventArgs" /> instance containing the event data.</param>
        protected void ValidateIqamaNumber(object source, ServerValidateEventArgs args)
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

        /// <summary>
        /// ValidateBoundaryNumber
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="ServerValidateEventArgs" /> instance containing the event data.</param>
        protected void ValidateBoundaryNumber(object source, ServerValidateEventArgs args)
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

        #endregion

        #region Business Logic Methods

        /// <summary>
        /// result
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="pageIndex">Index of the page.</param>
        private void BindDataToGrid(HashSet<RunAwayApprovalRequestInfo> result, int pageIndex)
        {
            if (result != null && result.Any())
            {
                //Bind data to grid 
                runawayRequestsGridView.DataSource = result.ToList();
                //set total records
                var awayApprovalRequestsInfo = result.FirstOrDefault();
                if (awayApprovalRequestsInfo != null)
                    runawayRequestsGridView.VirtualItemCount = awayApprovalRequestsInfo.TotalRowsCount;
                //set page index 
                runawayRequestsGridView.PageIndex = pageIndex;
                runawayRequestsGridView.DataBind();
                //cache result 
                GetAllRunAwayRequestsSession = result.ToList();
                //hide  divs
                allRunawayRequestsDiv.Visible = true;
                runawayDetailsDiv.Visible = false;
                actionsButtonsDiv.Visible = false;
                rejectionReasonDiv.Visible = false;
                return;
            }
            ArrMessages = new[] { TypedObjects.GeneralSystemError };
            ShowErrorMsg();
            allRunawayRequestsDiv.Visible = false;
            runawayDetailsDiv.Visible = false;
            actionsButtonsDiv.Visible = false;
            rejectionReasonDiv.Visible = false;
        }

        /// <summary>
        /// bind request to UI
        /// </summary>
        /// <param name="result">The result.</param>
        private void BindRunAwayRequest(RunAwayApprovalRequestInfo result)
        {
            if (result == null) return;
            //cach result
            GetRunAwayRequestSession = result;
            //bind data 
            //رقم البلاغ
            runawayNumberLiteral.Text = result.RunAwayRequestNumber;
            //اسم النشأة
            establismentNameLiteral.Text = result.EstablishmentTitle;
            //رقم المنشأة
            establishmentNumberLiteral.Text = result.LaborOfficeId + " - " + result.SequenceNumber;
            //اسم العامل
            laborNameLiteral.Text = result.LaborerFullName;
            //رقم العامل
            laborIdLiteral.Text = result.LaborerIdNumber.ToString();
            //تاريخ تقديم البلاغ
            runawayDateLiteral.Text = result.RunAwayRequestDate.ToString("yyyy/MM/dd") + " - " +
                                      Utilities.ConvertToHijriFormate(result.RunAwayRequestDate);
            //الوقت
            runawayTimeLiteral.Text = result.RunAwayRequestDate.ToShortTimeString()
                .Replace("AM", "ص")
                .Replace("PM", "م");
            //حالة طلب البلاغ 
            runawayStatusLiteral.Text = !string.IsNullOrEmpty(result.RunAwayRequestStatusName)
                ? result.RunAwayRequestStatusName
                : "لا يوجد";
            //تاريخ تقديم طلب إثبات الكيدية
            runawayComplainDateLiteral.Text = result.ComplaintRequestDate.ToString("yyyy/MM/dd") + " - " +
                                              Utilities.ConvertToHijriFormate(result.ComplaintRequestDate);
            //حالة طلب إثبات الكيدية
            runawayComplainStatusLiteral.Text = !string.IsNullOrEmpty(result.ComplaintRequestStatusId.ToString())
                ? result.ComplaintRequestStatusName
                : "لا يوجد";
            //ملاحظات على طلب الاثبات 
            if (TypedObjects.IsBase64String(result.RejectReason))
            {
                NotesLiteral.Text = TypedObjects.Base64Decode(result.RejectReason);
            }
            else
            {
                NotesLiteral.Text = result.RejectReason;
            }
            //متى بدأ الوافد العمل لديكم
            LaborerStartWorkDateLiteral.Text = !string.IsNullOrEmpty(result.RunAwayQuestion1?.ToString())
                ? result.RunAwayQuestion1.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(result.RunAwayQuestion1.Value) : "لا يوجد";
            //متى كانت نهاية العمل
            LaborerEndWorkDateLiteral.Text = !string.IsNullOrEmpty(result.RunAwayQuestion2?.ToString())
                ? result.RunAwayQuestion2.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(result.RunAwayQuestion2.Value) : "لا يوجد";
            //متى تم تسليم آخر راتب للوافد
            LastLaborerSalaryLiteral.Text = !string.IsNullOrEmpty(result.RunAwayQuestion3?.ToString())
                ? result.RunAwayQuestion3.Value.ToString("yyyy/MM/dd") + " - " +
                  Utilities.ConvertToHijriFormate(result.RunAwayQuestion3.Value) : "لا يوجد";
            //سبب انتهاء العلاقة العمالية
            if (TypedObjects.IsBase64String(result.RunAwayQuestion4))
            {
                reasonEndLaborerRelationShipTextBox.Text = !string.IsNullOrEmpty(result.RunAwayQuestion4)
                    ? TypedObjects.Base64Decode(result.RunAwayQuestion4)
                    : "لا يوجد";
            }
            else
            {
                reasonEndLaborerRelationShipTextBox.Text = !string.IsNullOrEmpty(result.RunAwayQuestion4)
                    ? result.RunAwayQuestion4 : "لا يوجد";
            }


            //تاريخ بدأت العمل
            StartingDateLiteral.Text = !string.IsNullOrEmpty(result.ComplaintQuestion1?.ToString())
                        ? result.ComplaintQuestion1.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(result.ComplaintQuestion1.Value) : "لا يوجد";
            //تاريخ نهاية العمل
            StopingDateLiteral.Text = !string.IsNullOrEmpty(result.ComplaintQuestion2?.ToString())
                        ? result.ComplaintQuestion2.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(result.ComplaintQuestion2.Value) : "لا يوجد";
            //تاريخ آخر راتب تم استلام
            lastSalaryLiteral.Text = !string.IsNullOrEmpty(result.ComplaintQuestion3?.ToString())
                        ? result.ComplaintQuestion3.Value.ToString("yyyy/MM/dd") + " - " +
                          Utilities.ConvertToHijriFormate(result.ComplaintQuestion3.Value) : "لا يوجد";
            //سبب التوقف عن العمل
            if (TypedObjects.IsBase64String(result.ComplaintQuestion4))
            {
                stopWorkingReasonTextBox.Text = !string.IsNullOrEmpty(result.ComplaintQuestion4)
                    ? TypedObjects.Base64Decode(result.ComplaintQuestion4)
                    : "لا يوجد";
            }
            else
            {
                stopWorkingReasonTextBox.Text = !string.IsNullOrEmpty(result.ComplaintQuestion4)
                    ? result.ComplaintQuestion4
                    : "لا يوجد";
            }
            //إفادة مكتب العمل
            if (TypedObjects.IsBase64String(result.LaborOfficeReplyDetails))
            {
                laborOfficeTestimonyTextBox.Text = string.IsNullOrEmpty(result.LaborOfficeReplyDetails)
                    ? "لا يوجد"
                    : TypedObjects.Base64Decode(result.LaborOfficeReplyDetails);
            }
            else
            {
                laborOfficeTestimonyTextBox.Text = string.IsNullOrEmpty(result.LaborOfficeReplyDetails)
                    ? "لا يوجد"
                    : result.LaborOfficeReplyDetails;
            }
            //المرفقات - خدمة بلاغ التغيب عن العمل 
            if (result.RunAwayFilesPaths != null && result.RunAwayFilesPaths.Any())
            {
                runAwayattachmentsGridView.DataSource = result.RunAwayFilesPaths.ToList();
                runAwayattachmentsGridView.DataBind();
            }
            else
            {
                runAwayattachmentsGridView.DataSource = null;
                runAwayattachmentsGridView.DataBind();
            }
            //المرفقات - إثبات كيدية بلاغ التغيب 
            if (result.ComplaintFilesPaths != null && result.ComplaintFilesPaths.Any())
            {
                complaintRequestGridView.DataSource = result.ComplaintFilesPaths.ToList();
                complaintRequestGridView.DataBind();
            }
            else
            {
                complaintRequestGridView.DataSource = null;
                complaintRequestGridView.DataBind();
            }
            //فى حالة ان  الطلب قد تم الموافقة عليه او رفضة من قبل ادارة بلاغات التغيب  من قبل  
            // مجرد عرض لتفاصيل الطلب 
            if (result.RunAwayRequestStatusId == (int)SOATypedObject.RunAwayRequestStatus.Accepted ||
                result.RunAwayRequestStatusId == (int)SOATypedObject.RunAwayRequestStatus.Rejected)
            {
                selectOperationButtonListDiv.Visible = false;
                rejectionReasonDiv.Visible = false;
                actionsButtonsDiv.Visible = false;
                LaboerOfficeDecisionTitleDiv.Visible = false;
            }
            //تمت  الافادة من  مكتب العمل التابع له المنشأة 
            //سوف يتم البت فى الطلب بالقبول او الرفض  من ادارة بلاغات التغيب 
            else if (result.ComplaintRequestStatusId == (int)SOATypedObject.ComplaintRequestStatus.RepliedByLaborOffice)
            {
                selectOperationButtonListDiv.Visible = true;
                selectOperationButtonList.Items[2].Attributes.CssStyle.Add("Visibility", "hidden");
                selectOperationButtonList.SelectedIndex = 0;
                rejectionReasonDiv.Visible = false;
                actionsButtonsDiv.Visible = true;
                LaboerOfficeDecisionTitleDiv.Visible = true;
            }
            //  الطلبات غير المعالجة
            // سوف يتم القبول او الرفض أو  ارسال الطلب الى مكتب العمل لدراسة الطلب 
            else
            {
                selectOperationButtonList.Items[2].Attributes.CssStyle.Add("Visibility", "visible");
                selectOperationButtonListDiv.Visible = true;
                rejectionReasonDiv.Visible = false;
                actionsButtonsDiv.Visible = true;
                selectOperationButtonList.SelectedIndex = 0;
                LaboerOfficeDecisionTitleDiv.Visible = false;
            }
            runawayDetailsDiv.Visible = true;
            ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToRequestDetails", "scrollToRequestDetails()", true);
        }

        /// <summary>
        /// get list of laborer offices
        /// </summary>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <returns>HashSet&lt;LaborOfficeInfo&gt;.</returns>
        protected HashSet<LaborOfficeInfo> GetListOfLaborerOffice(int? laborerOfficeId)
        {
            var user = GetCurrentUser();
            if (user?.IdNumber != null)
            {
                return _getBusinessService.GetRegionLaborerOfficeList(laborerOfficeId, user.IdNumber.Value);
            }
            return null;
        }

        #endregion

        #region Business Service Methods

        /// <summary>
        /// Get List of requestes with specific status
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="requestStatus">The request status.</param>
        /// <param name="laborerOffice">The laborer office.</param>
        /// <param name="laborerOfficeId">The laborer office identifier.</param>
        /// <param name="sequenceNumber">The sequence number.</param>
        /// <returns>HashSet&lt;RunAwayApprovalRequestInfo&gt;.</returns>
        protected HashSet<RunAwayApprovalRequestInfo> GetForApprovalRunAwayRequestsList(int pageSize,
            int currentPage, string requestStatus, string laborerOffice,
            string laborerOfficeId, string sequenceNumber)

        {
            var user = GetCurrentUser();
            if (user?.IdNumber != null)
            {
                return _getBusinessService.GetForApprovalRunAwayRequestsList(
                    (SOATypedObject.ComplaintRequestStatus)
                        Enum.Parse(typeof(SOATypedObject.ComplaintRequestStatus), requestStatus),
                    laborerOffice != "0" ? int.Parse(laborerOffice) : (int?)null,
                    !string.IsNullOrEmpty(laborerOfficeId) ? int.Parse(laborerOfficeId) : (int?)null,
                    !string.IsNullOrEmpty(sequenceNumber) ? int.Parse(sequenceNumber) : (int?)null, pageSize,
                    currentPage, user.IdNumber.Value
                    );
            }
            return null;
        }

        /// <summary>
        /// CreateRunAwayReviewRequest
        /// </summary>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg CreateRunAwayReviewRequest()
        {
            var currentUser = GetCurrentUser();
            return _postBusinessService.CreateRunAwayReviewRequest(
                int.Parse(GetRunAwayRequestSession.RunAwayRequestId.ToString()),
                long.Parse(currentUser.IdNumber.ToString()), GetClientIpAddress());
        }

        /// <summary>
        /// AcceptComplaintRequest
        /// </summary>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg AcceptComplaintRequest()
        {
            var currentUser = GetCurrentUser();
            if (string.IsNullOrEmpty(currentUser?.IdNumber.ToString())) return null;
            return _postBusinessService.AcceptComplaintRequest(
                int.Parse(GetRunAwayRequestSession.RunAwayRequestId.ToString()),
                long.Parse(currentUser.IdNumber.ToString()), GetClientIpAddress());
        }

        /// <summary>
        /// RejectComplaintRequest
        /// </summary>
        /// <param name="rejectionReason">The rejection reason.</param>
        /// <returns>ResponseMsg.</returns>
        protected ResponseMsg RejectComplaintRequest(string rejectionReason)
        {
            var currentUser = GetCurrentUser();
            if (string.IsNullOrEmpty(currentUser?.IdNumber.ToString())) return null;
            return _postBusinessService.RejectComplaintRequest(
                int.Parse(GetRunAwayRequestSession.RunAwayRequestId.ToString()),
                rejectionReason, long.Parse(currentUser.IdNumber.ToString()), GetClientIpAddress());
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
        /// Page Load
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //CultureInfo.CurrentCulture = new CultureInfo("ar-SA");
                if (IsPostBack) return;
                GetAllRunAwayRequestsSession = null;
                GetRunAwayRequestSession = null;
                IsCurrentUserHasPrivilege((long)PrivilegeList.RAMS_ApproveRunawayComplain);
                #region hide divs 
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
                actionsButtonsDiv.Visible = false;
                rejectionReasonDiv.Visible = false;
                RunwayRequestManagmentDiv.Visible = true;
                searchDiv.Visible = true;
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
                actionsButtonsDiv.Visible = false;
                rejectionReasonDiv.Visible = false;
                #endregion
                var laboerList = GetListOfLaborerOffice(GetCurrentUser().LaborOfficeId).ToList();
                if (!laboerList.Any()) return;
                LaborOfficeInfoListSession = laboerList;
                laboerList.Insert(0, new LaborOfficeInfo { Id = 0, Name = "إختر" });
                laborerOfficesDropDownList.DataSource = laboerList;
                laborerOfficesDropDownList.DataBind();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region Search 

        /// <summary>
        /// serach with data entered by user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void SearchRunAwayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(laborerOfficeIdTextBox.Text) &&
                     string.IsNullOrEmpty(sequenceNumberTextBox.Text)) ||
                    (string.IsNullOrEmpty(laborerOfficeIdTextBox.Text) &&
                     !string.IsNullOrEmpty(sequenceNumberTextBox.Text)))
                {
                    ArrMessages = new[] { TypedObjects.EstablishmentNumberMessage };
                    ShowErrorMsg();
                    allRunawayRequestsDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                    return;
                }
                if (!string.IsNullOrEmpty(laborerOfficeIdTextBox.Text) &&
                    !string.IsNullOrEmpty(sequenceNumberTextBox.Text))
                {
                    int.TryParse(sequenceNumberTextBox.Text, out var sequenceNumberValue);
                    int.TryParse(laborerOfficeIdTextBox.Text, out var laborerOfficeIdValue);

                    if (sequenceNumberValue <= 0 || laborerOfficeIdValue <= 0)
                    {
                        ArrMessages = new[] { TypedObjects.EstablishmentNumberMessage };
                        ShowErrorMsg();
                        allRunawayRequestsDiv.Visible = false;
                        runawayDetailsDiv.Visible = false;
                        return;
                    }
                    if (LaborOfficeInfoListSession != null && LaborOfficeInfoListSession.Any())
                    {
                        var laboerOfficeInfoItem =
                            LaborOfficeInfoListSession.FirstOrDefault(
                                x => x.Id == int.Parse(laborerOfficeIdTextBox.Text));
                        if (laboerOfficeInfoItem == null)
                        {
                            //show error div 
                            establishmentNumberErrorMessageLabel.Visible = true;
                            allRunawayRequestsDiv.Visible = false;
                            runawayDetailsDiv.Visible = false;
                            return;
                        }
                        establishmentNumberErrorMessageLabel.Visible = false;
                    }
                }
                var result = GetForApprovalRunAwayRequestsList(runawayRequestsGridView.PageSize, 1,
                    selectRunawayTypeRequestDropDownList.SelectedItem.Value,
                    laborerOfficesDropDownList.SelectedItem.Value,
                    laborerOfficeIdTextBox.Text,
                    sequenceNumberTextBox.Text);
                if (result != null && result.Any())
                {
                    BindDataToGrid(result, 0);
                }
                else
                {
                    var message = GetSystemMessage(SOATypedObject.RAMSMSG02);
                    ArrMessages = new[] { message.ResponseText };
                    ShowErrorMsg();
                    allRunawayRequestsDiv.Visible = false;
                    runawayDetailsDiv.Visible = false;
                    actionsButtonsDiv.Visible = false;
                    rejectionReasonDiv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
                actionsButtonsDiv.Visible = false;
                rejectionReasonDiv.Visible = false;
            }
        }

        #endregion

        #region Grid Actions 

        #region عرض كل الطلبات 

        /// <summary>
        /// called when select any grid item .
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
                if (string.IsNullOrEmpty(e.CommandArgument?.ToString())) return;
                var request =
                    GetAllRunAwayRequestsSession.FirstOrDefault(
                        x => x.RunAwayRequestNumber == e.CommandArgument.ToString());
                if (request != null)
                {
                    BindRunAwayRequest(request);
                    return;
                }
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ShowErrorMsg();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// chnage page index
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
        protected void runawayRequestsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                var result = GetForApprovalRunAwayRequestsList(runawayRequestsGridView.PageSize, (e.NewPageIndex + 1),
                    selectRunawayTypeRequestDropDownList.SelectedItem.Value,
                    laborerOfficesDropDownList.SelectedItem.Value,
                    laborerOfficeIdTextBox.Text,
                    sequenceNumberTextBox.Text);
                BindDataToGrid(result, e.NewPageIndex);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region  المرفقات - خدمة بلاغ التغيب عن العمل

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
                        if (!string.IsNullOrEmpty(e.CommandArgument?.ToString()) && GetRunAwayRequestSession != null)
                        {
                            DownloadFile(e.CommandArgument.ToString(), GetRunAwayRequestSession.RunAwayRequestNumber);
                        }
                    }
                }
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ShowErrorMsg();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
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
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #region المرفقات - إثبات كيدية بلاغ التغيب

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
                        if (!string.IsNullOrEmpty(e.CommandArgument?.ToString()) && GetRunAwayRequestSession != null)
                        {
                            DownloadFile(e.CommandArgument.ToString(), GetRunAwayRequestSession.RunAwayRequestNumber);
                        }
                    }
                }
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ShowErrorMsg();
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
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
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #endregion

        #region Request Actions 

        /// <summary>
        /// select type of Action on request {Accept || reject || Send to  Manpower}
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void SelectOperationButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = selectOperationButtonList.SelectedValue;
                if (selectedValue == RequestStatus.Accept.ToString())
                {
                    rejectionReasonDiv.Visible = false;
                    if (GetRunAwayRequestSession?.ComplaintRequestStatusId ==
                        (int)SOATypedObject.ComplaintRequestStatus.RepliedByLaborOffice)
                        selectOperationButtonList.Items[2].Attributes.CssStyle.Add("Visibility", "hidden");
                }
                else if (selectedValue == RequestStatus.Reject.ToString())
                {
                    rejectionReasonDiv.Visible = true;
                    if (GetRunAwayRequestSession?.ComplaintRequestStatusId ==
                        (int)SOATypedObject.ComplaintRequestStatus.RepliedByLaborOffice)
                    {
                        selectOperationButtonList.Items[2].Attributes.CssStyle.Add("Visibility", "hidden");
                    }
                }
                else if (selectedValue == RequestStatus.SentToLaborOffice.ToString())
                {
                    rejectionReasonDiv.Visible = false;
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "scrollToElement", "scrollToElement()", true);
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                ShowErrorMsg();
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                #region فى حالة الموافقة على الطلب 

                if (selectOperationButtonList.SelectedValue == RequestStatus.Accept.ToString())
                {
                    if (GetRunAwayRequestSession != null)
                    {
                        var response = AcceptComplaintRequest();
                        if (response == null) return;
                        if (response.IsSuccess)
                        {
                            var currentRunAwayRequest =
                                GetAllRunAwayRequestsSession?.FirstOrDefault(
                                    x => x.RunAwayRequestNumber == GetRunAwayRequestSession.RunAwayRequestNumber);
                            if (currentRunAwayRequest != null)
                            {
                                GetAllRunAwayRequestsSession.Remove(currentRunAwayRequest);
                                runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                                runawayRequestsGridView.DataBind();
                            }
                            ArrMessages = new[] { response.ResponseText };
                            ShowSuccessMsg();
                            runawayDetailsDiv.Visible = false;
                        }
                        else
                        {
                            ArrMessages = new[] { response.ResponseText };
                            ShowErrorMsg();
                            runawayDetailsDiv.Visible = false;
                            actionsButtonsDiv.Visible = false;
                        }
                    }
                    else
                    {
                        ArrMessages = new[] { TypedObjects.GeneralSystemError };
                        ShowErrorMsg();
                        ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain,
                            FailureReasons.GeneralEsbException);
                    }
                }

                #endregion

                #region فى حالة رفض الطلب 

                else if (selectOperationButtonList.SelectedValue == RequestStatus.Reject.ToString())
                {
                    if (!string.IsNullOrEmpty(refuseReasonTextBox.Text) && GetRunAwayRequestSession != null)
                    {
                        if (refuseReasonTextBox.Text.Length > 500)
                        {
                            refuseReasonTextBox.BorderColor = Color.Red;
                            ArrMessages = new[] { TypedObjects.MessageSize };
                            ShowErrorMsg();
                            return;
                        }
                        var response = RejectComplaintRequest(TypedObjects.Base64Encode(refuseReasonTextBox.Text));
                        if (response != null)
                        {
                            if (response.IsSuccess)
                            {
                                // update request status on caching list  then update Grid again 
                                var currentRunAwayRequest =
                                    GetAllRunAwayRequestsSession?.FirstOrDefault(
                                        x => x.RunAwayRequestNumber == GetRunAwayRequestSession.RunAwayRequestNumber);
                                if (currentRunAwayRequest != null)
                                {
                                    GetAllRunAwayRequestsSession.Remove(currentRunAwayRequest);
                                    runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                                    runawayRequestsGridView.DataBind();
                                }
                                ArrMessages = new[] { response.ResponseText };
                                ShowSuccessMsg();
                                runawayDetailsDiv.Visible = false;
                            }
                            else
                            {
                                ArrMessages = new[] { response.ResponseText };
                                ShowErrorMsg();
                                runawayDetailsDiv.Visible = false;
                            }
                        }
                        else
                        {
                            ArrMessages = new[] { TypedObjects.GeneralSystemError };
                            ShowErrorMsg();
                            ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain,
                                FailureReasons.GeneralEsbException);
                            runawayDetailsDiv.Visible = false;
                        }
                    }
                    else
                    {
                        ArrMessages = new[] { TypedObjects.RejectionReason };
                        ShowErrorMsg();
                    }
                }

                #endregion

                #region إفادة العامل والمنشأة من مكتب العمل التابع له المنشأة

                else if (selectOperationButtonList.SelectedValue == RequestStatus.SentToLaborOffice.ToString())
                {
                    if (GetRunAwayRequestSession != null)
                    {
                        var response = CreateRunAwayReviewRequest();
                        if (response != null)
                        {
                            if (response.IsSuccess)
                            {
                                // update request status on caching list  then update Grid again 
                                var currentRunAwayRequest =
                                    GetAllRunAwayRequestsSession?.FirstOrDefault(
                                        x => x.RunAwayRequestNumber == GetRunAwayRequestSession.RunAwayRequestNumber);
                                if (currentRunAwayRequest != null)
                                {
                                    GetAllRunAwayRequestsSession.Remove(currentRunAwayRequest);
                                    runawayRequestsGridView.DataSource = GetAllRunAwayRequestsSession.ToList();
                                    runawayRequestsGridView.DataBind();
                                }
                                ArrMessages = new[] { response.ResponseText };
                                ShowSuccessMsg();
                                runawayDetailsDiv.Visible = false;
                            }
                            else
                            {
                                ArrMessages = new[] { response.ResponseText };
                                ShowErrorMsg();
                                runawayDetailsDiv.Visible = false;
                            }
                        }
                        else
                        {
                            ArrMessages = new[] { TypedObjects.GeneralSystemError };
                            ShowErrorMsg();
                        }
                    }
                    else
                    {
                        ArrMessages = new[] { TypedObjects.GeneralSystemError };
                        ShowErrorMsg();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                ArrMessages = new[] { TypedObjects.GeneralSystemError };
                ShowErrorMsg();
                ExceptionHelper.LogError(ServicesList.RAMS_ApproveRunawayComplain, FailureReasons.GeneralEsbException);
                LoggingHelper.Error(ex.Message, ex);
                allRunawayRequestsDiv.Visible = false;
                runawayDetailsDiv.Visible = false;
            }
        }

        #endregion

        #endregion
    }
}