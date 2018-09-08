<%@ Page Title="" Language="C#"
    MasterPageFile="~/MasterPages/Private.Master"
    AutoEventWireup="true"
    CodeBehind="CreateRunawayRequest.aspx.cs"
    Inherits="RAMS.WebApp.Services.RAMS.Establishment.CreateRunawayRequest" %>

<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Register Assembly="Mol.Web.Common.WebControls" Namespace="Mol.Web.Common.WebControls" TagPrefix="DateControl" %>
<%@ Register Src="~/UserControls/SMSConfirmation.ascx" TagPrefix="SMSConfirmation" TagName="SMSConfirmationControl" %>
<%@ Register Src="~/Services/RAMS/UserControls/UcSearchingByIqamaOrBorderNumber.ascx" TagPrefix="uc2" TagName="LaborerUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">
    الخدمات الالكترونية للمنشآت - وزارة العمل    
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
            <div id="RunawayRequestCardDiv" class="card" runat="server">
                <div class="title">
                    <h5>تقديم بلاغ تغيب عامل</h5>
                </div>
                <div class="content">
                    <div id="containerDiv" runat="server">
                        <span><b>
                            <uc2:LaborerUserControl runat="server" ID="laborerUserControl"
                                OnOnSearchFinished="laborerUserControl_OnSearchFinished" />
                        </b></span>
                        <br />
                        <div id="requestInfoDiv" runat="server" visible="False">
                            <div class="title">
                                <h5>بيانات الطلب </h5>
                            </div>
                            <%--اسم العامل --%>
                            <div class="row" id="LaborerNameDiv" runat="server">
                                <div class="col s12 m3 l3 bold">
                                    <span><b>إسم العامل  </b></span>
                                </div>
                                <div class="col s12 m12 l4">
                                    <span><b>
                                        <asp:Literal runat="server" ID="laborerNameLiteral"></asp:Literal>
                                    </b></span>
                                </div>
                            </div>
                            <br/>
                            <%--الملفات الثبوتية--%>
                            <div class="row" id="fileUploadDiv" runat="server">
                                <div class="col s12 m3 l3 bold">
                                    <span><b>الملفات الثبوتية <b style="color: red">*</b></b></span>
                                </div>
                                <div class="col s12 m12 l4">
                                    <div class="input-field" id="uploadDiv">
                                        <asp:FileUpload ID="neededDocumentFileUpload" runat="server" />
                                        <asp:Button ID="btnUpload" Text="Upload" runat="server" Style="display: none" OnClick="Upload" />
                                    </div>
                                </div>
                                <div class="col s12 m12 l5">
                                    <div class="alert-validation">
                                        <span><b>
                                            <span id="FileUploadValidationError" class="parsley-errors-list filled"
                                                style="display: none; color: #E53935"></span>
                                            <span id="FileUploadCustomError" runat="server" class="parsley-errors-list filled"
                                                style="display: none; color: #E53935"></span>
                                        </b></span>
                                    </div>
                                </div>
                            </div>
                            <div id="pointerDiv" class="row"></div>
                            <%----عرض المستندات --%>
                            <div class="row">
                                <div class="col s12 m3 l3 ">
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
                            <div id="questionsDiv" runat="server" visible="False">
                                <div class="row">
                                    <div class="col s12 m3 l3 bold">
                                        <span><b>متى بدأ الوافد العمل لديكم ؟   <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <DateControl:DualSmartCalendar ID="LaborerStartWorkDateCalendar" runat="server" Visible="True"
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
                                        <asp:RequiredFieldValidator runat="server" ID="laborerStartWorkDateRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LaborerStartWorkDateCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3 bold">
                                        <span><b>متى كانت نهاية العمل؟    <b style="color: red">*</b></b></span>
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <DateControl:DualSmartCalendar ID="LaborerEndWorkDateDualSmartCalendar" runat="server" Visible="True"
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
                                        <asp:RequiredFieldValidator runat="server" ID="laborerEndWorkDateRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save" ErrorMessage="*"
                                            ControlToValidate="LaborerEndWorkDateDualSmartCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3 bold">
                                        <span><b>متى تم تسليم آخر راتب للوافد ؟    <b style="color: red">*</b></b>  </span>
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <DateControl:DualSmartCalendar ID="LastLaborerSalaryDualSmartCalendar" runat="server" Visible="True"
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
                                            ID="lastLaborerSalaryRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save"
                                            ErrorMessage="*"
                                            ControlToValidate="LastLaborerSalaryDualSmartCalendar">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3 bold">
                                        <span><b>سبب انتهاء العلاقة العمالية ؟  <b style="color: red">*</b></b>  </span>
                                    </div>
                                    <div class="col s12 m5 l5">
                                        <asp:TextBox ID="reasonEndLaborerRelationShipTextBox" runat="server"
                                            ValidationGroup="save"
                                            TextMode="MultiLine"
                                            MaxLength="500" Height="106"></asp:TextBox>
                                    </div>
                                    <div class="col s12 m1 l1">
                                        <asp:RequiredFieldValidator runat="server"
                                            ID="reasonEndLaborerRelationShipRequiredFieldValidator"
                                            ForeColor="Red" ValidationGroup="save"
                                            ErrorMessage="*"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3 bold">
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
                                </div>
                                <div class="row">
                                    <div class="col s12 m3 l3 bold">
                                    </div>
                                    <div class="col s12 m4 l4">
                                        <asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator2"
                                            ControlToValidate="reasonEndLaborerRelationShipTextBox"
                                            Text="يجب عدم إدخال حروف خاصة"
                                            ValidationExpression="^[أ-ي0-9a-zA-Z. ءلآآـ]*"
                                            runat="server" Display="Dynamic"
                                            ForeColor="Red"
                                            ValidationGroup="save" />
                                    </div>
                                </div>
                            </div>
                            <%--التعهد--%>
                            <div class="row" id="AgreementDiv" runat="server" visible="False">
                                <div class="col s12 m3 l3 bold"></div>
                                <div class="input-field ">
                                    <div class="col s12 m7 l7 ">
                                        <span><b>
                                            <asp:CheckBox runat="server" ID="AgreementCheckBox" ValidationGroup="save"
                                                Text="أقر بأن جميع المعلومات المقدمة صحيحة ،
                                                            وفي حال ثبت عكس ذلك فإنني اتحمل ما يترتب عليه من عقوبة" />
                                        </b></span>
                                    </div>
                                </div>
                            </div>
                            <%--حفظ الطلب --%>
                            <div class="row">
                                <div class="col s12 m3 l3 bold"></div>
                                <div class="col s12 m2 l2">
                                    <asp:Button runat="server" ValidationGroup="save"
                                        ID="createRunwayRequestButton" Text="تقديم الطلب"
                                        CssClass="btn" CausesValidation="true"
                                        OnClick="CreateRunwayRequest_Click" />
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
            <% var serializer = new JavaScriptSerializer(); %>
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
            document.getElementById('<%=createRunwayRequestButton.ClientID %>').disabled = true;
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
            var target = document.getElementById('pointerDiv').offsetTop;
            //Scrolls to that target location
            window.scrollTo(0, target);
        }

    </script>
</asp:Content>
