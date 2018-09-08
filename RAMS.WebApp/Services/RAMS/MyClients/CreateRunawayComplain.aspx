<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Private.Master"
    AutoEventWireup="true" CodeBehind="CreateRunawayComplain.aspx.cs"
    ValidateRequest="false"
    Inherits="RAMS.WebApp.Services.RAMS.MyClients.CreateRunawayComplain" %>

<%@ Register Src="~/Services/RAMS/UserControls/UcSearchingByIqamaOrBorderNumber.ascx" TagPrefix="uc2" TagName="LaborerUserControl" %>
<%@ Register Assembly="Mol.Web.Common.WebControls" Namespace="Mol.Web.Common.WebControls" TagPrefix="DateControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">
    طلب إثبات كيدية بلاغ تغيب
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../javascript/rams-validations.js"></script>
    <div class="row">
        <div class="col l12 s12">
            <div>
                <div id="error_div" class="alert alert-border-right" style="display: none;"></div>
                <div id="success_div" class="alert green lighten-4 green-text text-darken-2 alert-border-right"
                    style="display: none;">
                </div>
            </div>
            <div class="row">
                <div class="col s12 m12 l12"></div>
            </div>
            <div id="runawayComplainCardDiv" class="card" runat="server">
                <div class="title">
                    <h5>طلب إثبات كيدية بلاغ تغيب</h5>
                </div>
                <div class="OverFS content">
                    <div id="containerDiv" runat="server">
                        <%--البحث عن طلب الطلب--%>
                        <div id="SearchDiv">
                            <span><b>
                                <uc2:LaborerUserControl runat="server" ID="laborerUserControl"
                                    OnOnSearchFinished="laborerUserControl_OnSearchFinished" />
                            </b></span>
                        </div>
                        <br/>
                        <%--بيانات الطلب--%>
                        <div runat="server" id="laborerDetails">
                            <div class="title">
                                <h5>بيانات الطلب</h5>
                            </div>
                            <div class="row">
                                <div class="col s12 m4 l2">
                                    <div class="label-new">
                                        <span><b>رقم البلاغ  </b>: </span>
                                    </div>
                                </div>
                                <div class="col s12 m8 l3">
                                    <span>
                                        <asp:Literal runat="server" ID="runawayNumberLiteral"></asp:Literal>
                                    </span>
                                </div>
                                <div class="col s12 m12 l1"></div>
                                <div class="col s12 m4 l2">
                                    <div class="label-new">
                                        <span><b>تاريخ تقديم البلاغ :</b></span>
                                    </div>
                                </div>
                                <div class="col s12 m8 l3">
                                    <span>
                                        <asp:Literal runat="server" ID="runawayRequestDateLiteral"></asp:Literal>
                                    </span>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col s12 m4 l2">
                                    <div class="label-new">
                                        <span><b>تاريخ تقديم طلب إثبات الكيدية  </b>: </span>
                                    </div>
                                </div>
                                <div class="col s12 m8 l3">
                                    <span>
                                        <asp:Literal runat="server" ID="runawayComplainDateLiteral"></asp:Literal>
                                    </span>
                                </div>
                                <div class="col s12 m12 l1"></div>
                                <div class="col s12 m4 l2">
                                    <div class="label-new">
                                        <span><b>حالة طلب إثبات الكيدية :</b></span>
                                    </div>
                                </div>
                                <div class="col s12 m8 l3">
                                    <span>
                                        <asp:Literal runat="server" ID="runawayRequestStatusLiteral">لا يوجد </asp:Literal>
                                    </span>
                                </div>
                            </div>
                             <br />
                            <%--سبب الرفض --%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                    <div class="label-new">
                                        <span><b>ملاحظات أخرى  </b>: </span>
                                    </div>
                                </div>
                                <div class="col s12 m10 l10">
                                    <span>
                                        <asp:Literal runat="server" ID="NotesInCaseRejectionLiteral">لا يوجد</asp:Literal>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <br />
                        <%--متطلبات تقديم طلب اثبات كيدية --%>
                        <div id="requiredDataDiv" runat="server" visible="False">
                            <div class="title">
                                <h5>طلب إثبات كيدية بلاغ تغيب</h5>
                            </div>
                            <div class="row" id="fileUploadDiv" runat="server">
                                <div class="col s12 m2 l2">
                                    <div class="label-new">
                                        <span><b>المستندات المطلوبة <b style="color: red">*</b></b></span>
                                    </div>
                                </div>
                                <div class="col s12 m3 l3">
                                    <div class="input-field" id="uploadDiv">
                                        <asp:FileUpload ID="neededDocumentFileUpload" runat="server" />
                                        <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="Upload" Style="display: none" />
                                    </div>
                                </div>
                                <div class="col s12 m2 l2">
                                    <div class="alert-validation">
                                        <span id="FileUploadValidationError" class="parsley-errors-list filled"
                                            style="display: none; color: #E53935"></span>
                                        <span id="FileUploadCustomError" runat="server" class="parsley-errors-list filled"
                                            style="display: none; color: #E53935"></span>
                                    </div>
                                </div>
                            </div>
                            <div id="pointerDiv" class="row"></div>
                            <%----عرض المستندات --%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                </div>
                                <div class="col s12 m5 l5" runat="server" id="uploadedDocumentsGrid">
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
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                        <span><b>تاريخ بدأت العمل ؟  <b style="color: red">*</b> </b></span>
                                    </div>
                                    <div class="col s12 m5 l5">
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
                                        <asp:RequiredFieldValidator runat="server" ID="laborerStartWorkDateRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LaborerStartWorkDateCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                        <span><b>تاريخ نهاية العمل ؟  <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <DateControl:DualSmartCalendar ID="LaborerEndWorkDateDualSmartCalendar"
                                            runat="server" Visible="True"
                                            ClearButtonImageUrl="~/App_Themes/Green/Images/Clear.png"
                                            CloseButtonImageUrl="~/App_Themes/Green/Images/close.png"
                                            ShowButtonImageUrl="~/App_Themes/Green/Images/Calendar.png"
                                            CellPadding="2" CellSpacing="5" BorderStyle="None" Width="30%"
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
                                            ID="laborerEndWorkDateRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LaborerEndWorkDateDualSmartCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                        <span><b>ماهو تاريخ آخر راتب تم استلامه ؟  <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m5 l5">
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
                                </div>
                                <%--رقم الجوال ؟--%>
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                        <span><b>رقم الجوال ؟  <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m2 l2">
                                        <asp:TextBox runat="server" ID="mobileNumberTextbox" ValidationGroup="save"
                                            MaxLength="12">966</asp:TextBox>
                                    </div>
                                    <div class="col s12 m3 l3">
                                        <asp:Label runat="server" ForeColor="Green" Text="مثال "> </asp:Label>
                                        -
                                        <asp:Label runat="server" ForeColor="Green" Text="9665xxxxxxxx"> </asp:Label>

                                    </div>
                                    <div class="col s12 m2 l2">
                                        <asp:RequiredFieldValidator runat="server" ID="mobileNumberRequiredFieldValidator1"
                                            ForeColor="Red" ValidationGroup="save"
                                            ErrorMessage="*" ControlToValidate="mobileNumberTextbox">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                            ControlToValidate="mobileNumberTextbox" runat="server"
                                            ErrorMessage="رقم الجوال غير صحيح "
                                            ValidationExpression="\d+" ForeColor="Red"
                                            ValidationGroup="save">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                        <span><b>ماهو سبب التوقف عن العمل ؟  <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <asp:TextBox ID="reasonEndLaborerRelationShipTextBox"
                                            runat="server"
                                            ValidationGroup="save"
                                            TextMode="MultiLine" MaxLength="500"
                                            Height="106"></asp:TextBox>
                                    </div>
                                    <div class="col s12 m2 l2">
                                        <asp:RequiredFieldValidator runat="server"
                                            ID="reasonEndLaborerRelationShipRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox"
                                            Text="يجب عدم إدخال أكثر من 500 حرف"
                                            ValidationExpression="^[\s\S]{0,500}$"
                                            runat="server"
                                            ValidationGroup="save"
                                            Display="Dynamic" ForeColor="Red" />
                                    </div>
                                    <div class="col s12 m2 l2">
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m2 l2">
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator2"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox"
                                            Text="يجب عدم إدخال حروف خاصة"
                                            ValidationExpression="^[أ-ي0-9a-zA-Z. ءلآآـ]*"
                                            runat="server" Display="Dynamic"
                                            ForeColor="Red"
                                            ValidationGroup="save" />
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
                                        <asp:CheckBox runat="server" ID="AgreementCheckBox"
                                            ValidationGroup="save"
                                            Text="أقر بأن جميع المعلومات المقدمة صحيحة
                                     ، وفي حال ثبت عكس ذلك فإنني اتحمل ما يترتب عليه من عقوبة" />
                                    </b></span>
                                </div>
                            </div>
                            <br />
                            <%--حفظ الطلب--%>
                            <div class="row">
                                <div class="col s12 m2 l2"></div>
                                <div class="col s12 m2 l2">
                                    <asp:Button runat="server" ID="createComplainButton" Text="حفظ "
                                        CssClass="btn"
                                        OnClick="CreateComplainButton_Click" CausesValidation="true"
                                        ValidationGroup="save" />
                                </div>
                            </div>
                        </div>
                        <%--    تفاصيل طلب إثبات الكيدية--%>
                        <div id="displayComplainRequestDetailsDiv" runat="server" visible="False">
                            <div class="title">
                                <h5>تفاصيل الطلب</h5>
                            </div>
                            <div class="row">
                                <div class="col s12 m2 l2">
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
                            </div>
                            <%--تاريخ بدأت العمل--%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                    <span><b>تاريخ بدأية العمل </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:Literal runat="server" ID="StartingDateLiteral"></asp:Literal>
                                </div>
                            </div>
                            <%--تاريخ نهاية العمل--%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                    <span><b>تاريخ نهاية العمل </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:Literal runat="server" ID="StopingDateLiteral"></asp:Literal>
                                </div>
                            </div>
                            <%--ماهو تاريخ آخر راتب تم استلامه--%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                    <span><b>تاريخ آخر راتب تم استلامه </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:Literal runat="server" ID="lastSalaryLiteral"></asp:Literal>
                                </div>
                            </div>
                            <%--رقم الجوال ؟--%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                    <span><b>رقم الجوال  </b></span>
                                </div>
                                <div class="col s12 m2 l2">
                                    <asp:Label runat="server" ID="mobileNumberLabel"></asp:Label>
                                </div>
                            </div>
                            <%--ماهو سبب التوقف عن العمل--%>
                            <div class="row">
                                <div class="col s12 m2 l2">
                                    <span><b>سبب التوقف عن العمل </b></span>
                                </div>
                                <div class="col s12 m5 l5">
                                    <asp:TextBox ID="stopWorkingReasonTextBox" runat="server" Enabled="False"
                                        TextMode="MultiLine" Height="106" MaxLength="500"></asp:TextBox>
                                </div>
                            </div>
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
            $('#mobileNumberTextbox').keypress(function(e) {
            });
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
        function hideMsg() {
            $('#success_div').hide();
            $('#error_div').hide();
            setInterval(function () { $('#success_div'); }, 6000);
            setInterval(function () { $('#error_div'); }, 6000);
        }
        function disabledButton() {
            document.getElementById('<%=createComplainButton.ClientID %>').disabled = true;
        }
        window.onbeforeunload = disabledButton;
        
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
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
