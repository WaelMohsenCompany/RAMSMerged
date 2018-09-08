<%@ Page Title="" Language="C#"
    MasterPageFile="~/MasterPages/Private.Master"
    AutoEventWireup="true" CodeBehind="RunawayRequestsManagement.aspx.cs"
    ValidateRequest="false"
    Inherits="RAMS.WebApp.Services.RAMS.MyClients.RunawayRequestsManagement" %>

<%@ Register Src="~/UserControls/ValidateRequesterEstablishmentUsers.ascx" TagPrefix="uc1" TagName="ValidateRequesterEstablishmentUsers" %>
<%@ Register Src="~/Services/RAMS/UserControls/UcSearchingByIqamaOrBorderNumber.ascx" TagPrefix="uc2" TagName="LaborerUserControl" %>
<%@ Register Assembly="Mol.Web.Common.WebControls" Namespace="Mol.Web.Common.WebControls" TagPrefix="DateControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">
    إدارة بلاغات التغيب 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../../javascript/rams-validations.js"></script>

    <%--Error || Sucess Messages Div --%>
    <div class="row">
        <div class="col s12 m12 l12">
            <br />
            <div style="color: red; display: none;" class="alert" id="error_div"></div>
            <div style="color: green; display: none;" class="alert green lighten-4 green-text text-darken-2" id="success_div">
            </div>
        </div>
    </div>

    <div id="DeleteConfirmationDiv" visible="false" runat="server" class="alert alert-border cyan lighten-4 cyan-text text-darken-2">
        <h4>تنبيه !</h4>
        <%-- <span>
                <asp:Literal runat="server" ID="confirmationMsgLiteral"></asp:Literal>
            </span>--%>
        <div style="color: red; display: none;" id="Warning_div"></div>
        <p>
            <asp:Button runat="server" ID="acceptButton" Text="تاكيد"
                CssClass="btn cyan text-darken-2 z-depth-0" OnClick="acceptButton_Click" />
            <asp:Button runat="server" ID="cancelButton" Text="رجوع"
                CssClass="btn white cyan-text text-darken-2 z-depth-0" OnClick="cancelButton_Click" />
        </p>
    </div>

    <%--Mol Control To Check --%>
    <div class="row" id="validateRequesterEstablishmentUsersDiv" runat="server">
        <div class="col s12 m12 l12">
            <uc1:ValidateRequesterEstablishmentUsers runat="server" ID="ucValidateBusinessUser"
                OnRequesterValidated="ucValidateBusinessUser_OnRequesterValidated"
                OnRequesterValidatedCanceled="ucValidateBusinessUser_OnRequesterValidatedCanceled" />
        </div>
    </div>
    <br />
    <%--إدارة بلاغات التغيب--%>
    <div id="RunwayRequestCardDiv" class="card" runat="server" visible="False">
        <div class="title">
            <h5>إدارة بلاغات التغيب  </h5>
        </div>
        <div class="content">
            <%--عملية البحث --%>
            <div id="searchDiv" runat="server">
                <%--محددات البحث--%>
                <div class="row">
                    <div class="col s12 m1 l1">
                        <div class="label-new">
                            <span><b>نطاق البحث  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m3 l3">
                        <span><b>
                            <asp:DropDownList runat="server" ID="selectRunawayDropDownList"
                                DataTextField="Name" Visible="True"
                                DataValueField="Id" ClientIDMode="Static" AutoPostBack="True"
                                OnSelectedIndexChanged="selectRunawayDropDownList_SelectedIndexChanged">
                                <Items>
                                    <asp:ListItem Text="بلاغ تغيب عامل معين" Value="SpecificRunAwayRequest"></asp:ListItem>
                                    <asp:ListItem Text="البلاغات السابقة" Value="AllRunAwayRequests"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                        </b></span>
                    </div>
                </div>
                <%--عامل معين --%>
                <div id="laborDiv" runat="server">
                    <span><b>
                        <uc2:LaborerUserControl runat="server" ID="laborerUserControl" OnOnSearchFinished="laborerUserControl_OnSearchFinished" />
                    </b></span>
                </div>
            </div>
            <br />
            <%--كل  البلاغات السابقة--%>
            <div id="allRunawayRequestsDiv" runat="server">
                <div id="requestDetailsPointer"></div>
                <div class="row">
                    <div class="col l12 s12 m12 ">
                        <div class="row">
                            <div class="col l12 s12 ">
                                <asp:GridView runat="server"
                                    EmptyDataText="لا يوجد أي بلاغات/طلبات توافق معايير البحث."
                                    ID="runawayRequestsGridView"
                                    CssClass="display table table-bordered table-striped table-hover"
                                    PagerStyle-CssClass="grid_footer_paging"
                                    AutoGenerateColumns="False"
                                    DataKeyNames="RequestNumber"
                                    AllowPaging="True"
                                    PageSize="10"
                                    PagerSettings="NextPreviousFirstLast"
                                    BorderWidth="2px"
                                    BackColor="White"
                                    OnRowCommand="runawayRequestsGridView_RowCommand"
                                    OnPageIndexChanging="runawayRequestsGridView_PageIndexChanging"
                                    AllowCustomPaging="True">
                                    <Columns>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="RequestId" Value='<%# Eval("RequestNumber") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="رقم البلاغ">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="runawayNumberLinkButton"
                                                    Text='<%# Eval("RequestNumber") %>'
                                                    CommandArgument='<%# Eval("RequestNumber") %>'
                                                    CommandName="RequestNumberCommand">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="اسم العامل" DataField="LaborerFullName" SortExpression="LaborerFullName" />
                                        <asp:BoundField HeaderText="التاريخ" DataField="RequestDate" SortExpression="RequestDate" />
                                        <asp:BoundField HeaderText="الحالة" DataField="RunAwayRequestStatusName"
                                            SortExpression="RunAwayRequestStatusName" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <%--تفاصيل البلاغ--%>
            <div id="runawayDetailsDiv" runat="server">
                <div class="title">
                    <h5>تفاصيل البلاغ </h5>
                </div>
                <div id="Contentdiv" runat="server">
                    <div class="row">
                        <%--رقم البلاغ المرجعي--%>
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>رقم البلاغ </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayRequestNumberLiteral"></asp:Literal>
                            </span>
                        </div>
                        <%--اسم المنشـأة--%>
                        <div class="col s12 m1 l1"></div>
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>اسم المنشأة  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="establismentNameLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>

                    <%--رقم المنشأة--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>رقم المنشأة  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="establishmentNumberLiteral"></asp:Literal>
                            </span>
                        </div>
                        <div class="col s12 m1 l1"></div>
                        <div class="col s12 m3 l2">
                            <div class="label-new">
                                <span><b>اسم العامل     </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m4 l4">
                            <span>
                                <asp:Literal runat="server" ID="laborNameLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>

                    <%--رقم العامل--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>رقم الاقامة/ الحدود: </b></span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="laborIdLiteral"></asp:Literal>
                            </span>
                        </div>
                        <div class="col s12 m1 l1"></div>
                        <%--التاريخ--%>
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>التاريخ  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayDateLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>

                    <%--الوقت--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>الوقت    </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayTimeLiteral"></asp:Literal>
                            </span>
                        </div>
                        <div class="col s12 m1 l1"></div>
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>حالة البلاغ  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m2 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayStatusLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>

                    <%--المرفقات--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>المرفقات  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:GridView runat="server"
                                ID="attachmentsGridView"
                                CssClass="display table table-bordered table-striped table-hover"
                                PagerStyle-CssClass="grid_footer_paging"
                                AutoGenerateColumns="False"
                                AllowPaging="True"
                                PageSize="15"
                                PagerSettings="NextPreviousFirstLast"
                                BorderWidth="2px"
                                BackColor="White"
                                OnRowCommand="attachmentsGridView_RowCommand"
                                AllowCustomPaging="True"
                                OnRowDataBound="attachmentsGridView_RowDataBound"
                                EmptyDataText="لا يوجد">
                                <Columns>
                                    <asp:TemplateField HeaderText="م">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="اسم الملف">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="filePathLinkButton" CausesValidation="False"
                                                CommandName='<%#StaticBusinessKeys.RunAwayFilesPathsFieldCommand %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <%--متى بدأ الوافد العمل لديكم--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>متى بدأ الوافد العمل لديكم ؟  </b></span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:Literal runat="server" ID="LaborerStartWorkDateLiteral"></asp:Literal>
                        </div>
                    </div>
                    <%--متى كانت نهاية العمل ؟--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>متى كانت نهاية العمل ؟  </b></span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:Literal runat="server" ID="LaborerEndWorkDateLiteral"></asp:Literal>
                        </div>
                    </div>
                    <%--متى تم تسليم آخر راتب للوافد ؟--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>متى تم تسليم آخر راتب للوافد ؟  </b></span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:Literal runat="server" ID="LastLaborerSalaryLiteral"></asp:Literal>
                        </div>
                    </div>
                    <%--سبب انتهاء العلاقة العمالية ؟--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>سبب انتهاء العلاقة العمالية ؟  </b></span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:TextBox ID="reasonEndLaborerRelationShipTextBox" runat="server"
                                Enabled="False"
                                TextMode="MultiLine" MaxLength="500" Height="106"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div id="uploadDiv" class="row"></div>

            <%--الغاء بلاغ هروب --%>
            <div runat="server" id="deleteRunAwayDiv" visible="False">
                <div class="title">
                    <h5>إلغاء بلاغ التغيب </h5>
                </div>
                <br />
                <%--المستندات المطلوبة--%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>المستندات المطلوبة  <b style="color: red"><b style="color: red">*</b></b></b> </span>
                        </div>
                    </div>
                    <div class="col s12 m2 l2">
                        <asp:FileUpload ID="neededDocumentFileUpload" runat="server" />
                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                    </div>
                    <div class="col s12 m2 l2">
                        <div class="alert-validation">
                            <span id="FileUploadValidationError" class="parsley-errors-list filled"
                                style="display: none; color: #E53935"></span>
                            <span id="FileUploadCustomError" runat="server"
                                class="parsley-errors-list filled"
                                style="display: none; color: #E53935"></span>
                        </div>
                    </div>
                </div>

                <%----عرض المستندات --%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                        </div>
                    </div>
                    <div class="col s12 m6 l6">
                        <div runat="server" id="uploadedDocumentsGrid">
                            <asp:GridView runat="server"
                                ID="requiedFilesGridView"
                                AutoGenerateColumns="False"
                                AllowSorting="False"
                                GridLines="None"
                                CellPadding="3"
                                CellSpacing="1"
                                AllowPaging="True"
                                CssClass="display table table-bordered table-striped table-hover"
                                PagerStyle-CssClass="grid_footer_paging"
                                PageSize="15" EmptyDataText="لا يوجد">
                                <Columns>
                                    <asp:TemplateField HeaderText="م">
                                        <ItemTemplate>
                                            <span>
                                                <%#Container.DataItemIndex + 1%>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="اسم الملف">
                                        <ItemTemplate>
                                            <asp:Label ID="fileNameLabel" runat="server"
                                                Text='<%# Eval("Name")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" Text="حذف"
                                                CommandArgument='<%# Eval("Name") %>'
                                                runat="server" OnClick="DeleteFile"
                                                CommandName="DeleteFile" CausesValidation="False" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

                <%--الاسئلة الالزامية --%>
                <div id="questionsDiv">
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <span><b>متى كان تاريخ عودة العامل للعمل ؟ <b style="color: red">*</b></b></span>
                        </div>
                        <div class="col s12 m5 l5">
                            <DateControl:DualSmartCalendar ID="laborerReturnDateToWorkCalendar" runat="server" Visible="True"
                                ClearButtonImageUrl="~/App_Themes/Green/Images/Clear.png"
                                CloseButtonImageUrl="~/App_Themes/Green/Images/close.png"
                                ShowButtonImageUrl="~/App_Themes/Green/Images/Calendar.png"
                                CellPadding="2" CellSpacing="5" BorderStyle="None"
                                OtherMonthDayStyle-CssClass="OtherMonthDay"
                                CssClass="mol-new-calendar" TextBoxStyle-CssClass="SmartCalendarTextbox"
                                SelectedDayStyle-CssClass="SelectedDay"
                                TodayDayStyle-CssClass="TodayDay" monthliststyle-cssclas="MonthDD mol-month-list"
                                TitleStyle-CssClass="SmartCalendarTitle" BackColor="#433b21" ClearLinkText=""
                                ClearLinkToolTip="" Culture="<%$ Resources:ControlsResource, DualSmartCalendarCulture %>"
                                HijriText="<%$ Resources:ControlsResource, DualSmartCalendarHijriText %>"
                                GregorianText="<%$ Resources:ControlsResource, DualSmartCalendarGregorianText %>"
                                FlowDirection="<%$ Resources:ControlsResource, DualSmartCalendarFlowDirection %>"
                                MinSupportedDate="1910-01-01" MonthLabelText=""
                                ShowButtonToolTip="" ShowNextPrevMonth="False"
                                YearLabelText="" YearsToShowOffset="10"
                                ShowTitle="false"
                                OnClientChange="cal1_onClientChange();" ValidateRequestMode="Enabled">
                                <TitleStyle CssClass="mol-calendar-title"></TitleStyle>
                                <YearListStyle CssClass="mol-year-list"></YearListStyle>
                                <MonthListStyle CssClass="mol-month-list" />
                                <OtherMonthDayStyle CssClass="mol-normal-day"></OtherMonthDayStyle>
                                <DayStyle CssClass="mol-normal-day" />
                                <TextBoxStyle CssClass="SmartCalendarTextbox"></TextBoxStyle>
                                <HijriTextBoxStyle CssClass="HijriCalendarTextbox"></HijriTextBoxStyle>
                                <SelectedDayStyle CssClass="SelectedDay"></SelectedDayStyle>
                                <TodayDayStyle CssClass="mol-normal-day"></TodayDayStyle>
                            </DateControl:DualSmartCalendar>
                        </div>
                        <div class="col s12 m2 l2">
                            <asp:RequiredFieldValidator runat="server"
                                ID="laborerReturnDateToWorkRequiredFieldValidator"
                                ForeColor="Red" 
                                ValidationGroup="Cancel"
                                ErrorMessage="*"
                                ControlToValidate="laborerReturnDateToWorkCalendar">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <span><b>ماهي أسباب الغاء بلاغ التغيب ؟ <b style="color: red">*</b></b></span>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:TextBox ID="reasonsCancelationTextBox"
                                runat="server"
                                ValidationGroup="Cancel"
                                TextMode="MultiLine"
                                Height="106"
                                MaxLength="500"></asp:TextBox>
                        </div>
                        <div class="col s12 m2 l2">
                            <asp:RequiredFieldValidator runat="server"
                                ID="reasonsCancelationTextBoxRequiredFieldValidator"
                                ForeColor="Red" ValidationGroup="Cancel" ErrorMessage="*"
                                ControlToValidate="reasonsCancelationTextBox">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator3"
                                ControlToValidate="reasonsCancelationTextBox"
                                Text="يجب عدم إدخال أكثر من 500 حرف"
                                ValidationExpression="^[\s\S]{0,500}$"
                                runat="server"
                                ValidationGroup="Cancel"
                                Display="Dynamic" ForeColor="Red" />
                        </div>
                        <div class="col s12 m2 l2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2"
                                ControlToValidate="reasonsCancelationTextBox"
                                Text="يجب عدم إدخال حروف خاصة"
                                ValidationExpression="^[أ-ي0-9a-zA-Z. ءلآآـ]*"
                                runat="server" Display="Dynamic"
                                ForeColor="Red"
                                ValidationGroup="Cancel" />
                        </div>
                        <div class="col s12 m2 l2">
                        </div>
                    </div>
                </div>
                <%--التعهد--%>
                <div class="row" id="AgreementDiv">
                    <div class="col s12 m2 l2">
                    </div>
                    <div class="col s12 m7 l7">
                        <span><b>
                            <asp:CheckBox runat="server"
                                ID="AgreementCheckBox"
                                ValidationGroup="Cancel"
                                Text="أقر بأن جميع المعلومات المقدمة صحيحة
                                ، وفي حال ثبت عكس ذلك فإنني اتحمل ما يترتب عليه من عقوبة " />
                        </b></span>
                    </div>
                </div>
                <%--حفظ الطلب--%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new"></div>
                    </div>
                    <div class="col s12 m1 l1">
                        <div class="label-new">
                            <asp:Button runat="server"
                                ID="deleteRunAwayRequestButton"
                                CssClass="btn" Text="إلغاء الطلب"
                                OnClick="deleteRunAwayRequest_Click"
                                ValidationGroup="Cancel" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() {
            validateFields();            
        });
        //Set Numric Field
        function validateFields() {
            $('#iqamaNumberTextBox').keypress(function(e) {
                $('#bounderyNumberTextBox').val("");
            });
            $('#bounderyNumberTextBox').keypress(function(e) {
                $('#iqamaNumberTextBox').val("");
            });
            $('#iqamaNumberTextBox').change(function(e) {
                $('#bounderyNumberTextBox').val("");
            });
            $('#bounderyNumberTextBox').change(function(e) {
                $('#iqamaNumberTextBox').val("");
            });
        }

        function errorBuilder() {
            var summary = "";
            <% var serializer = new System.Web.Script.Serialization.JavaScriptSerializer(); %>
            var jsVariable = <%= serializer.Serialize(ArrMessages) %>;
            for (i = 0; i < jsVariable.length; i++) {
                summary += "•  " + jsVariable[i] + "<br/>";
            }
            return summary;
        }
        function ShowErrorMsg() {
            $('#error_div').html(errorBuilder()).show();
            setInterval(function () { $('#error_div'); }, 6000);
        }
        function ShowSuccessMsg() {
            $('#success_div').html(errorBuilder()).show();
            setInterval(function () { $('#success_div'); }, 6000);
        }
        function DeleteConfirmationMsg() {
            
            $('#Warning_div').html(errorBuilder()).show();
            setInterval(function () { $('#Warning_div'); }, 6000);
        }
        function hideMsg() {
            $('#success_div').hide();
            $('#error_div').hide();
            setInterval(function () { $('#success_div'); }, 6000);
            setInterval(function () { $('#error_div'); }, 6000);
        }
        function disabledButton() {
         
            document.getElementById('<%=deleteRunAwayRequestButton.ClientID %>').disabled = true;
        }
        window.onbeforeunload = disabledButton;
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                if(CheckFileUploadValidation(fileUpload,<%=MaxFilesSize%>,<%=MaxFilesCount%>,<%=FilesSession.Count%> ,<%=MinFilesSize%> ))
                {
                    document.getElementById("<%=btnUpload.ClientID %>").click();
                }
            }
        }

        function scrollToElement(){
            var target = document.getElementById('uploadDiv').offsetTop;
            //Scrolls to that target location
            window.scrollTo(0, target);
        }

        function scrollToRequestDetails() {
            var target = document.getElementById('requestDetailsPointer').offsetTop;
            //Scrolls to that target location
            window.scrollTo(0, target);
        }

    </script>
</asp:Content>
