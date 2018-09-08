<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Individual.Master"
    EnableEventValidation="false" AutoEventWireup="true"
    CodeBehind="CreateRunawayComplain.aspx.cs"
    Inherits="RAMS.WebApp.Services.RAMS.Individual.CreateRunawayComplain" %>

<%@ Register Src="~/UserControls/SMSConfirmation.ascx" TagPrefix="SMSConfirmation" TagName="SMSConfirmationControl" %>
<%@ Register Assembly="Mol.Web.Common.WebControls" Namespace="Mol.Web.Common.WebControls" TagPrefix="DateControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    الخدمات الالكترونية للأفراد - وزارة العمل
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 id="pageTitle" runat="server">طلب إثبات كيدية بلاغ تغيب</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" runat="server">
    <script src="../../../javascript/rams-validations.js"></script>
    <div class="row">
        <div class="col l12 s12">
            <div>
                <div id="error_div" class="alert alert-border-right" style="display: none;"></div>
                <div id="success_div" class="alert green lighten-4 green-text text-darken-2 alert-border-right"
                    style="display: none;">
                </div>
            </div>
            <div id="runawayComplainRequestDiv" class="card" runat="server">
                <div class="title">
                    <div class="row">
                        <div class="col s12 m6 l6">
                            <h5>طلب إثبات كيدية بلاغ تغيب</h5>
                        </div>
                        <div class="col s12 m6 l6">
                            <h5>Runaway Complaint Request</h5>
                        </div>
                    </div>
                </div>
                <div class="OverFS content">
                    <div id="containerDiv" runat="server">
                        <div class="row">
                            <%--رقم البلاغ--%>
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>رقم البلاغ  </b>: </span>
                                </div>
                            </div>
                            <div class="col s12 m3 l3">
                                <span>
                                    <asp:Literal runat="server" ID="runawayNumberLiteral"></asp:Literal>
                                </span>
                            </div>
                            <div class="col s12 m2 l3">
                                <span><b>: Request Number   </b></span>
                            </div>
                        </div>
                        <div class="row">
                            <%--تاريخ تقديم البلاغ--%>
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>تاريخ تقديم البلاغ :</b></span>
                                </div>
                            </div>
                            <div class="col s12 m3 l3">
                                <span>
                                    <asp:Literal runat="server" ID="runawayRequestDateLiteral"></asp:Literal>
                                </span>
                            </div>
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>: Request Date </b></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>تاريخ تقديم طلب إثبات الكيدية :</b></span>
                                </div>
                            </div>
                            <div class="col s12 m3 l3">
                                <span>
                                    <asp:Literal runat="server" ID="runawayComplainDateLiteral"></asp:Literal>
                                </span>
                            </div>
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>: Complaint Date </b></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>حالة طلب إثبات الكيدية :</b></span>
                                </div>
                            </div>
                            <div class="col s12 m3 l3">
                                <span>
                                    <asp:Literal runat="server" ID="runawayRequestStatusLiteral">لا يوجد </asp:Literal>
                                </span>
                            </div>
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>: Complaint Status  </b></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>ملاحظات أخرى :</b></span>
                                </div>
                            </div>
                            <div class="col s12 m3 l3">
                                <span>
                                    <asp:Literal runat="server" ID="NotesInCaseRejectionLiteral">لا يوجد</asp:Literal>
                                </span>
                            </div>
                            <div class="col s12 m2 l3">
                                <div class="label-new">
                                    <span><b>:Complaint Notes </b></span>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div id="requiredDataDiv" runat="server">
                            <div class="title">
                                <div class="row">
                                    <div class="col s12 m6 l6">
                                        <h5>متطلبات تقديم الطلب </h5>
                                    </div>
                                    <div class="col s12 m6 l6">
                                        <h5>Complaint Request Requirements</h5>
                                    </div>
                                </div>
                            </div>
                            <%--المستندات المطلوبة--%>
                            <div class="row" id="fileUploadDiv" runat="server">
                                <div class="col s12 m3 l3">
                                    <div class="label-new">
                                        <span><b>المستندات المطلوبة <b style="color: red">*</b></b></span>
                                    </div>
                                </div>
                                <div class="col s12 m2 l2">
                                    <div class="input-field" id="uploadFileDiv">
                                        <asp:FileUpload ID="neededDocumentFileUpload" runat="server" />
                                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                                    </div>
                                </div>
                                <div class="col s12 m3 l3">
                                    <div class="alert-validation">
                                        <span id="FileUploadValidationError" class="parsley-errors-list filled"
                                            style="display: none; color: #E53935"></span>
                                        <span id="FileUploadCustomError" runat="server" class="parsley-errors-list filled"
                                            style="display: none; color: #E53935"></span>
                                    </div>
                                </div>
                                <div class="col s12 m3 l3">
                                    <div class="label-new">
                                        <span><b><b style="color: red">*</b> Complaint Attachments </b></span>
                                    </div>
                                </div>
                            </div>
                            <div id="pointerDiv" class="row"></div>
                            <%----عرض المستندات --%>
                            <div class="row" runat="server" id="filesUploadingDiv" visible="False">
                                <div class="col s12 m3 l3">
                                    <div class="label-new">
                                    </div>
                                </div>
                                <div class="col s12 m4 l4" runat="server" id="uploadedDocumentsGrid">
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
                                        PageSize="10" EmptyDataText="لا يوجد">
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
                                                    <asp:LinkButton ID="lnkDelete" Text="حذف" CommandArgument='<%# Eval("Name") %>'
                                                        runat="server" OnClick="DeleteFile" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <%--الاسئلة الالزامية --%>
                            <div id="questionsDiv">
                                <%--تاريخ بدأت العمل--%>
                                <div class="row">
                                    <div class="col s12 m3 l3">
                                        <span><b>تاريخ بدأية العمل ؟  <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <DateControl:DualSmartCalendar ID="LaborerStartWorkDateCalendar" runat="server" Visible="True"
                                            ClearButtonImageUrl="~/App_Themes/Green/Images/Clear.png"
                                            CloseButtonImageUrl="~/App_Themes/Green/Images/close.png"
                                            ShowButtonImageUrl="~/App_Themes/Green/Images/Calendar.png"
                                            CellPadding="2" CellSpacing="5" BorderStyle="None"
                                            OtherMonthDayStyle-CssClass="OtherMonthDay" Width="30%"
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
                                            ID="laborerStartWorkDateRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LaborerStartWorkDateCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col s12 m3 l3">
                                        <span><b>؟  <b style="color: red">*</b> Start Date </b></span>
                                    </div>
                                </div>
                                <%--تاريخ نهاية العمل--%>
                                <div class="row">
                                    <div class="col s12 m3 l3">
                                        <span><b>تاريخ نهاية العمل ؟ <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <DateControl:DualSmartCalendar ID="LaborerEndWorkDateDualSmartCalendar" runat="server" Visible="True"
                                            ClearButtonImageUrl="~/App_Themes/Green/Images/Clear.png"
                                            CloseButtonImageUrl="~/App_Themes/Green/Images/close.png"
                                            ShowButtonImageUrl="~/App_Themes/Green/Images/Calendar.png"
                                            CellPadding="2" CellSpacing="5" BorderStyle="None"
                                            OtherMonthDayStyle-CssClass="OtherMonthDay" Width="30%"
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
                                        <asp:RequiredFieldValidator runat="server" ID="laborerEndWorkDateRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LaborerEndWorkDateDualSmartCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col s12 m3 l3">
                                        <span><b>؟ <b style="color: red">*</b> End Date </b></span>
                                    </div>
                                </div>
                                <%--ماهو تاريخ آخر راتب تم استلامه--%>
                                <div class="row">
                                    <div class="col s12 m3 l3">
                                        <span><b>ماهو تاريخ آخر راتب تم استلامه ؟ <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <DateControl:DualSmartCalendar ID="LastLaborerSalaryDualSmartCalendar"
                                            runat="server" Visible="True"
                                            ClearButtonImageUrl="~/App_Themes/Green/Images/Clear.png"
                                            CloseButtonImageUrl="~/App_Themes/Green/Images/close.png"
                                            ShowButtonImageUrl="~/App_Themes/Green/Images/Calendar.png"
                                            CellPadding="2" CellSpacing="5" BorderStyle="None"
                                            OtherMonthDayStyle-CssClass="OtherMonthDay"
                                            CssClass="mol-new-calendar" TextBoxStyle-CssClass="SmartCalendarTextbox"
                                            SelectedDayStyle-CssClass="SelectedDay" Width="30%"
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
                                        <asp:RequiredFieldValidator runat="server" ID="lastLaborerSalaryRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LastLaborerSalaryDualSmartCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col s12 m3 l3">
                                        <span><b>؟ <b style="color: red">*</b> Last Salary Date </b></span>
                                    </div>
                                </div>
                                <%--ماهو سبب التوقف عن العمل--%>
                                <div class="row">
                                    <div class="col s12 m3 l3">
                                        <span><b>ماهو سبب التوقف عن العمل ؟ <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <asp:TextBox ID="reasonEndLaborerRelationShipTextBox" runat="server"
                                            ValidationGroup="save"
                                            TextMode="MultiLine" Height="106" MaxLength="500"></asp:TextBox>
                                    </div>
                                    <div class="col s12 m2 l2">
                                        <span><b>
                                            <asp:RequiredFieldValidator runat="server"
                                                ID="reasonEndLaborerRelationShipRequiredFieldValidator"
                                                ForeColor="Red" 
                                                ValidationGroup="save"
                                                ErrorMessage="*"
                                                ControlToValidate="reasonEndLaborerRelationShipTextBox">
                                            </asp:RequiredFieldValidator>
                                        </b></span>

                                    </div>
                                    <div class="col s12 m3 l3">
                                        <span><b>؟ <b style="color: red">*</b> Stopping Reason </b></span>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3">
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator3"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox"
                                            Text="يجب عدم إدخال أكثر من 500 حرف"
                                            ValidationExpression="^[\s\S]{0,500}$"
                                            runat="server"
                                            ValidationGroup="save"
                                            Display="Dynamic" ForeColor="Red" />
                                    </div>
                                    <div class="col s12 m2 l2">
                                    </div>
                                    <div class="col s12 m3 l3">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3">
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator2"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox"
                                            Text="يجب عدم إدخال حروف خاصة"
                                            ValidationExpression="^[أ-ي0-9a-zA-Z. ءلآآـ]*"
                                            runat="server" Display="Dynamic"
                                            ForeColor="Red"
                                            ValidationGroup="save"
                                            />
                                    </div>
                                    <div class="col s12 m2 l2">
                                    </div>
                                    <div class="col s12 m3 l3">
                                    </div>
                                </div>
                            </div>
                            <%--التعهد--%>
                            <div class="row" id="AgreementDiv">
                                <div class="col s12 m3 l3"></div>
                                <div class="col s12 m7 l7">
                                    <span><b>
                                        <asp:CheckBox runat="server" 
                                            ID="AgreementCheckBox"
                                            ValidationGroup="save"
                                            Text="(أقر بأن جميع المعلومات المقدمة صحيحة ، وفي حال ثبت عكس ذلك فإنني اتحمل ما يترتب عليه من عقوبة)
                                                    -(I acknowledge that all the information provided is correct and, if proven otherwise, I bear the penalty)" />
                                    </b></span>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col s12 m3 l3"></div>
                                <div class="col s12 m2 l2">
                                    <asp:Button runat="server" 
                                        ID="createComplainButton" 
                                        Text="حفظ "
                                        CssClass="btn"
                                        OnClick="CreateComplainButton_Click"
                                        CausesValidation="true" 
                                        ValidationGroup="save" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <div id="displayComplainRequestDetailsDiv" runat="server" visible="False">
                            <div class="title">
                                <div class="row">
                                    <div class="col s12 m6 l6">
                                        <h5>تفاصيل الطلب</h5>
                                    </div>
                                    <div class="col s12 m6 l6">
                                        <h5>Request Details</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s12 m2 l3">
                                    <div class="label-new">
                                        <span><b>مرفقات طلب إثبات الكيدية  </b>: </span>
                                    </div>
                                </div>
                                <div class="col s12 m5 l5">
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
                                                    <asp:LinkButton runat="server" ID="filePathLinkButton"
                                                        CausesValidation="False"
                                                        CommandName="RunAwayFilesCommand">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="col s12 m2 l3">
                                    <div class="label-new">
                                        <span><b>: Complaint Attachments   </b></span>
                                    </div>
                                </div>
                            </div>
                            <%--تاريخ بدأت العمل--%>
                            <div class="row">
                                <div class="col s12 m2 l3">
                                    <span><b>تاريخ بدأية العمل </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:Literal runat="server" ID="StartingDateLiteral"></asp:Literal>
                                </div>
                                <div class="col s12 m2 l3">
                                    <div class="label-new">
                                        <span><b>:  Employment Start Date    </b></span>
                                    </div>
                                </div>
                            </div>
                            <%--تاريخ نهاية العمل--%>
                            <div class="row">
                                <div class="col s12 m2 l3">
                                    <span><b>تاريخ نهاية العمل </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:Literal runat="server" ID="StopingDateLiteral"></asp:Literal>
                                </div>
                                <div class="col s12 m2 l3">
                                    <div class="label-new">
                                        <span><b>:  Employment End Date    </b></span>
                                    </div>
                                </div>
                            </div>
                            <%--ماهو تاريخ آخر راتب تم استلامه--%>
                            <div class="row">
                                <div class="col s12 m2 l3">
                                    <span><b>تاريخ آخر راتب تم استلامه </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:Literal runat="server" ID="lastSalaryLiteral"></asp:Literal>
                                </div>
                                <div class="col s12 m2 l3">
                                    <div class="label-new">
                                        <span><b>:  Last Salary Date    </b></span>
                                    </div>
                                </div>
                            </div>
                            <%--ماهو سبب التوقف عن العمل--%>
                            <div class="row">
                                <div class="col s12 m2 l3">
                                    <span><b>سبب التوقف عن العمل </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:TextBox ID="stopWorkingReasonTextBox" runat="server" Enabled="False"
                                        ValidationGroup="save"
                                        TextMode="MultiLine" Height="106" MaxLength="500"></asp:TextBox>
                                </div>
                                <div class="col s12 m2 l3">
                                    <div class="label-new">
                                        <span><b>:Stopping Reason </b></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <SMSConfirmation:SMSConfirmationControl runat="server" ID="SMSConfirmationControl" />
    <script type="text/javascript">
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
        function hideMsg() {
            $('#success_div').hide();
            $('#error_div').hide();
            setInterval(function () { $('#success_div'); }, 6000);
            setInterval(function () { $('#error_div'); }, 6000);
        }

        function UploadFile(fileUpload) {
            if (fileUpload.value !== '') {
                if(CheckFileUploadValidation(fileUpload,<%=MaxFilesSize%>,<%=MaxFilesCount%>,<%=FilesSession.Count%> ,<%=MinFilesSize%> ))
                    document.getElementById("<%=btnUpload.ClientID %>").click();
            }
        }

        function scrollToElement() {
            var target = document.getElementById('pointerDiv').offsetTop;
            //Scrolls to that target location
            window.scrollTo(0, target);
        }
    </script>
</asp:Content>
