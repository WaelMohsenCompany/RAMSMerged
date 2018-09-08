<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Private.Master"
    AutoEventWireup="true" CodeBehind="ReviewRunawayComplain.aspx.cs"
    ValidateRequest="false"
    Inherits="RAMS.WebApp.Services.RAMS.MyClients.ReviewRunawayComplain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">
    تدقيق بلاغ التغيب 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../../../javascript/rams-validations.js"></script>
    <div class="row">
        <div class="col s12 m12 l12">
            <br />
            <div style="color: red; display: none;" class="alert" id="error_div"></div>
            <div style="color: green; display: none;"
                class="alert green lighten-4 green-text text-darken-2"
                id="success_div">
            </div>
        </div>
    </div>
    <div id="reviewRunawayComplaintDiv" class="card" runat="server" visible="False">
        <div class="title">
            <h5>معايير البحث </h5>
        </div>
        <div class="content">

            <%--عملية البحث --%>
            <div id="searchDiv" runat="server">
                <br />
                <%--  رقم المنشأة  و حالة الطلب رقم البلاغ --%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>حالة الطلب  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m3 l3">
                        <asp:DropDownList runat="server" ID="selectRequestStatusDropDownList"
                            AppendDataBoundItems="true" TabIndex="0">
                            <Items>
                                <asp:ListItem Text=" تحت الدراسة بمكتب العمل" Value="5"></asp:ListItem>
                                <asp:ListItem Text="تم تحديد موعد للمراجعة " Value="7"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>
                    <div class="col s12 m1 l1"></div>
                    <div class="col s12 m1 l1">
                        <div class="label-new">
                            <span><b>رقم المنشأة  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m3 l3">
                        <asp:TextBox runat="server" ID="laborerOfficeIdTextBox" MaxLength="2"
                            Width="40" TabIndex="1"></asp:TextBox>
                        - 
                        <asp:TextBox runat="server" ID="sequenceNumberTextBox" MaxLength="7"
                            Width="100" ClientIDMode="Static" TabIndex="2"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>رقم البلاغ  </b>: </span>
                        </div>
                    </div>
                    <div class="col s2 m3 l3">
                        <div class="input-field">
                            <asp:TextBox runat="server" ID="requestNumberPart1TextBox" MaxLength="4"
                                ClientIDMode="Static" TabIndex="3" Width="80"> </asp:TextBox>-
                            <asp:Literal runat="server" ID="requestNumberPart2Literal" ClientIDMode="Static"></asp:Literal>-
                            <asp:TextBox runat="server" ID="requestNumberPart3TextBox" MaxLength="4"
                                ClientIDMode="Static" TabIndex="5" Width="60"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col s2 m2 l2">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            ControlToValidate="requestNumberPart1TextBox" runat="server"
                            ErrorMessage="رقم البلاغ أرقام  فقط"
                            ValidationExpression="\d+" ForeColor="Red">
                        </asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                            ControlToValidate="requestNumberPart3TextBox" runat="server"
                            ErrorMessage="رقم البلاغ أرقام  فقط"
                            ValidationExpression="\d+" ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>
            <%--رقم الهوية  & رقم الحدود--%>
            <div class="row">
                <div class="col s12 m2 l2">
                    <div class="label-new">
                        <span><b>طلب بلاغ عامل معين</b>: </span>
                    </div>
                </div>
                <div class="col s12 m4 l4">
                    <asp:RadioButtonList runat="server" ID="laborerRadioButtonList"
                        AutoPostBack="True" RepeatDirection="Horizontal"
                        OnSelectedIndexChanged="LaborerRadioButtonList_SelectedIndexChanged">
                        <asp:ListItem Text="رقم الهوية" Value="IqamaNumber" Selected="True" />
                        <asp:ListItem Text="رقم الحدود" Value="BorderNumber" />
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row" id="iqamaNumberDiv" runat="server">
                <div class="col s12 m2 l2"></div>
                <div class="col s12 m2 l2">
                    <div class="input-field">
                        <asp:TextBox ID="iqamaNumberTextBox" CssClass="validate" pattern="(.){10,10}" MaxLength="10"
                            ValidationGroup="save" ClientIDMode="Static" runat="server"></asp:TextBox>
                        <label for="<%= iqamaNumberTextBox.ClientID %>">رقم هوية العامل</label>
                    </div>
                </div>
                <div class="col s12 m4 l4">
                    <div class="alert-validation">
                        <asp:RegularExpressionValidator Display="Dynamic" ValidationGroup="save"
                            ID="iqamaNumberRegValidator" ControlToValidate="iqamaNumberTextBox"
                            ValidationExpression="^[\s\S]{10,}$"
                            runat="server">
                        </asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="iqamaNumberCustomValidator" runat="server"
                            OnServerValidate="ValidateIqamaNumber_ServerValidate"
                            ControlToValidate="iqamaNumberTextBox" Display="Dynamic" ValidationGroup="save"
                            ErrorMessage="عفوا عزيزي العميل، رقم الهوية الذي تم إدخاله غير صحيح.">
                        </asp:CustomValidator>
                        <div class="alert-validation">
                            <asp:Label ID="iqamaNumberEmptyLabel" Style="display: none" runat="server"
                                ClientIDMode="Static" Text="عفوا عزيزي المستخدم، لابد من ادخال رقم الهوية">                                            
                            </asp:Label>
                            <asp:Label ID="iqamaNumbererrorNumberLabel" Style="display: none" runat="server" ClientIDMode="Static"
                                Text="رقم هوية العامل المدخل غير صحيح">                                             
                            </asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" id="borderNumberDiv" runat="server" visible="False">
                <div class="col s12 m2 l2"></div>
                <div class="col s12 m2 l2">
                    <div class="input-field">
                        <asp:TextBox ID="bounderyNumberTextBox" CssClass="validate"
                            pattern="(.){10,10}" MaxLength="10"
                            ClientIDMode="Static" runat="server"
                            ValidationGroup="save"></asp:TextBox>
                        <label for="<%= bounderyNumberTextBox.ClientID %>">رقم الحدود </label>
                    </div>
                </div>
                <div class="col s12 m4 l4">
                    <div class="alert-validation">
                        <asp:RegularExpressionValidator ValidationGroup="save" Display="Dynamic"
                            ID="bounderyNumberRegularExpressionValidator"
                            ControlToValidate="bounderyNumberTextBox" ValidationExpression="^[\s\S]{10,}$" runat="server">
                        </asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="bounderyNumberCustomValidator" runat="server"
                            ValidationGroup="save"
                            OnServerValidate="validateBoundaryNumber_ServerValidate"
                            ControlToValidate="bounderyNumberTextBox"
                            Display="Dynamic"
                            ErrorMessage="عفوا عزيزي العميل، رقم الحدود الذي تم إدخاله غير صحيح">
                        </asp:CustomValidator>
                        <div class="alert-validation">
                            <asp:Label ID="bounderyNumberEmptyLabel" Style="display: none" runat="server"
                                ClientIDMode="Static" Text="عفوا عزيزي المستخدم، لابد من ادخال رقم الحدود">                                            
                            </asp:Label>
                            <asp:Label ID="bounderyNumberErrorLabel" Style="display: none" runat="server" ClientIDMode="Static"
                                Text="رقم الحدود الخاص بالعامل غير صحيح">                                             
                            </asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <%--بحث--%>
            <div class="row">
                <div class="col s12 m2 l2"></div>
                <div class="col s12 m2 l2">
                    <asp:Button ID="searchrunawayButton" runat="server" Text="بحث"
                        ValidationGroup="save"
                        CssClass="btn" OnClick="SearchRunAwayButton_Click"
                        OnClientClick="return !checkEmpty();"
                        CausesValidation="true" />
                </div>
            </div>
        </div>
        <br />
        <br />
        <%--كل  البلاغات السابقة--%>
        <div id="allRunawayRequestsDiv" runat="server" visible="False" class="content">
            <div class="title">
                <h5>قائمة البلاغات </h5>
            </div>
            <div id="requestDetailsPointer"></div>
            <div class="row">
                <div class="col s12 m12 l12">
                    <asp:GridView runat="server"
                        ID="runawayRequestsGridView"
                        CssClass="display table table-bordered table-striped table-hover"
                        PagerStyle-CssClass="grid_footer_paging"
                        AutoGenerateColumns="False"
                        DataKeyNames="RunAwayRequestNumber"
                        AllowPaging="True"
                        PageSize="10"
                        PagerSettings="NextPreviousFirstLast"
                        BorderWidth="2px"
                        BackColor="White"
                        OnRowCommand="runawayRequestsGridView_RowCommand"
                        OnPageIndexChanging="runawayRequestsGridView_PageIndexChanging"
                        AllowCustomPaging="True"
                        EmptyDataText="لا يوجد أي بلاغات/طلبات توافق معايير البحث. ">
                        <Columns>
                            <asp:TemplateField HeaderText="رقم البلاغ">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="runawayNumberLinkButton"
                                        Text='<%# Eval("RunAwayRequestNumber") %>'
                                        CommandArgument='<%# Eval("RunAwayRequestNumber") %>'
                                        CommandName="RequestNumberCommand" CausesValidation="False">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="اسم العامل" DataField="LaborerFullName"
                                SortExpression="LaborerFullName" />
                            <asp:BoundField HeaderText="اسم المنشأة" DataField="EstablishmentTitle"
                                SortExpression="EstablishmentTitle" />
                            <asp:BoundField HeaderText="تاريخ تقديم البلاغ" DataField="RunAwayRequestDate"
                                SortExpression="RunAwayRequestDate" />
                            <asp:BoundField HeaderText="تاريخ تقديم طلب إثبات الكيدية" DataField="ComplaintRequestDate"
                                SortExpression="ComplaintRequestDate" />
                            <asp:BoundField HeaderText="حالة الطلب" DataField="ComplaintRequestStatusName"
                                SortExpression="ComplaintRequestStatusName" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>

        <%--تفاصيل البلاغ--%>
        <div id="runawayDetailsDiv" runat="server" visible="False" class="content">
            <div class="title">
                <h5>تفاصيل البلاغ </h5>
            </div>
            <div id="Contentdiv" runat="server" class="content">
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
                    <div class="col s12 m3 l3">
                        <div class="label-new">
                            <span><b>اسم المنشأة  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m4 l4">
                        <span>
                            <asp:Literal runat="server" ID="establismentNameLiteral"></asp:Literal>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <%--رقم المنشأة--%>
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
                    <%-- اسم العامل--%>
                    <div class="col s12 m3 l3">
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
                <div class="row">
                    <%--رقم العامل--%>
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>رقم الاقامة/ الحدود : </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="laborIdLiteral"></asp:Literal>
                        </span>
                    </div>
                    <div class="col s12 m1 l1"></div>
                    <%--تاريخ تقديم البلاغ--%>
                    <div class="col s12 m3 l3">
                        <div class="label-new">
                            <span><b>تاريخ تقديم البلاغ  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m4 l4">
                        <span>
                            <asp:Literal runat="server" ID="runawayDateLiteral"></asp:Literal>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <%--الوقت--%>
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
                    <%--تاريخ تقديم البلاغ--%>
                    <div class="col s12 m3 l3">
                        <div class="label-new">
                            <span><b>تاريخ تقديم طلب إثبات الكيدية  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m4 l4">
                        <span>
                            <asp:Literal runat="server" ID="runawayComplainDateLiteral"></asp:Literal>
                        </span>
                    </div>
                </div>

                <%--المرفقات - خدمة بلاغ التغيب عن العمل--%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>المرفقات - خدمة بلاغ التغيب عن العمل   </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m6 l6">
                        <asp:GridView runat="server"
                            ID="runAwayattachmentsGridView"
                            CssClass="display table table-bordered table-striped table-hover"
                            PagerStyle-CssClass="grid_footer_paging"
                            AutoGenerateColumns="False"
                            AllowPaging="True"
                            PageSize="15"
                            PagerSettings="NextPreviousFirstLast"
                            BorderWidth="2px"
                            BackColor="White"
                            OnRowCommand="runAwayattachmentsGridView_RowCommand"
                            OnRowDataBound="runAwayattachmentsGridView_RowDataBound"
                            AllowCustomPaging="True"
                            EmptyDataText="لا يوجد أي مرفقات  - خدمة بلاغ التغيب عن العمل. ">
                            <Columns>
                                <asp:TemplateField HeaderText="م">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم الملف">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="filePathLinkButton" CausesValidation="False"
                                            CommandName="RunAwayFilesPathsFieldCommand">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <%--المرفقات - إثبات كيدية بلاغ التغيب--%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>المرفقات - إثبات كيدية بلاغ التغيب    </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m6 l6">
                        <asp:GridView runat="server"
                            ID="complaintRequestGridView"
                            CssClass="display table table-bordered table-striped table-hover"
                            PagerStyle-CssClass="grid_footer_paging"
                            AutoGenerateColumns="False"
                            AllowPaging="True"
                            PageSize="15"
                            PagerSettings="NextPreviousFirstLast"
                            BorderWidth="2px"
                            BackColor="White"
                            OnRowCommand="complaintRequestGridView_RowCommand"
                            OnRowDataBound="complaintRequestGridView_RowDataBound"
                            AllowCustomPaging="True"
                            EmptyDataText="لا يوجد أي مرفقات - إثبات كيدية بلاغ التغيب  . ">
                            <Columns>
                                <asp:TemplateField HeaderText="م">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم الملف">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="filePathLinkButton" CausesValidation="False"
                                            CommandName='<%#StaticBusinessKeys.ComplaintFilesPaths %>'>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <br />
                <div class=" row title">
                    <h5>أسئلة  - خدمة بلاغ التغيب عن العمل  </h5>
                </div>
                <br />
                <%--الاسئلة --%>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>متى بدأ الوافد العمل لديكم ؟   </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="LaborerStartWorkDateLiteral"></asp:Literal>
                        </span>
                    </div>
                    <div class="col s12 m1 l1"></div>
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>متى كانت نهاية العمل ؟  </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="LaborerEndWorkDateLiteral"></asp:Literal>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>متى تم تسليم آخر راتب للوافد ؟  </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="LastLaborerSalaryLiteral"></asp:Literal>
                        </span>
                    </div>
                    <div class="col s12 m1 l1"></div>
                </div>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>سبب انتهاء العلاقة العمالية ؟  </b></span>
                        </div>
                    </div>
                    <div class="col s12 m6 l6">
                        <span>
                            <asp:TextBox ID="reasonEndLaborerRelationShipTextBox" runat="server"
                                Enabled="False"
                                TextMode="MultiLine" MaxLength="500" Height="106"></asp:TextBox>
                        </span>
                    </div>
                </div>
                <br />
                <div class=" row title">
                    <h5>أسئلة - إثبات كيدية بلاغ التغيب  </h5>
                </div>
                <br />
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>تاريخ بدأية العمل </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="StartingDateLiteral"></asp:Literal>
                        </span>
                    </div>
                    <div class="col s12 m1 l1"></div>
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>تاريخ نهاية العمل </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="StopingDateLiteral"></asp:Literal>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>تاريخ آخر راتب تم استلامه </b></span>
                        </div>
                    </div>
                    <div class="col s12 m3 l2">
                        <span>
                            <asp:Literal runat="server" ID="lastSalaryLiteral"></asp:Literal>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>سبب التوقف عن العمل </b></span>
                        </div>
                    </div>
                    <div class="col s12 m6 l6">
                        <span>
                            <asp:TextBox ID="stopWorkingReasonTextBox" runat="server" Enabled="False"
                                TextMode="MultiLine" Height="106" MaxLength="500"></asp:TextBox>
                        </span>
                    </div>
                </div>
                <div class=" row title">
                    <h5>قرار مكتب العمل  </h5>
                </div>
                <br />
                <%--اختيار نوع القرار --%>
                <div id="decisionOptionsDiv" class="row" runat="server">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                        </div>
                    </div>
                    <div class="col s12 m8 l6">
                        <div class="label-new" id="decisionDiv">
                            <asp:RadioButtonList runat="server"
                                ID="decisionOptionsRadioButtonList"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="DecisionOptionsRadioButtonList_SelectedIndexChanged"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="تحديد موعد" Value="MakeAppointment" Selected="True" />
                                <asp:ListItem Text="تسجيل إفادة مكتب العمل" Value="RegisterStatement" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div id="offsetDiv" class="row"></div>
                <%--تحديد موعد--%>
                <div class="row" id="makeAppointmentDiv" runat="server" visible="False">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                        </div>
                    </div>
                    <div class="col s12 m8 l8">
                        <div class="label-new">
                            <asp:Panel runat="server" BorderStyle="Ridge">
                                <asp:RadioButtonList runat="server" ID="makeAppointmentRadioButtonList" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="تحديد موعد للعامل" Value="LaborerAppointment" Selected="True" />
                                    <asp:ListItem Text="تحديد موعد للمنشأة" Value="EstablishmentAppointment" />
                                    <asp:ListItem Text="تحديد موعد للعامل و المنشأة"
                                        Value="LaborerAndEstablishmentAppointment"></asp:ListItem>
                                </asp:RadioButtonList>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <%--تسجيل إفادة مكتب العمل--%>
                <div id="registerStatementDiv" runat="server" visible="False">
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>إفادة مكتب العمل  <b style="color: red">*</b></b> </span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:TextBox runat="server" ID="laborOfficeResponseTextBox"
                                TextMode="MultiLine" Height="105" MaxLength="500" />
                            <asp:RequiredFieldValidator runat="server"
                                ID="laborOfficeRequiredFieldValidator"
                                ErrorMessage="عفوا عزيزي المستخدم، إفادة مكتب العمل حقل إلزامى "
                                ForeColor="Red"
                                ControlToValidate="laborOfficeResponseTextBox">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2"
                                ControlToValidate="laborOfficeResponseTextBox"
                                Text="يجب عدم إدخال أكثر من 500 حرف"
                                ValidationExpression="^[\s\S]{0,500}$"
                                runat="server"
                                Display="Dynamic" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator4"
                                ControlToValidate="laborOfficeResponseTextBox"
                                Text="يجب عدم إدخال حروف خاصة"
                                ValidationExpression="^[أ-ي0-9a-zA-Z. ءلآآـ]*"
                                runat="server" Display="Dynamic"
                                ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <%--Actions--%>
                <div id="actionButtonsDiv" runat="server" visible="False">
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new"></div>
                        </div>
                        <div class="col s12 m1 l1">
                            <div class="label-new">
                                <asp:Button runat="server" ID="followButton" Text=" حفظ  "
                                    CssClass="btn" ToolTip="حفظ الطلب لتسجيل بيانات أخرى لاحقا"
                                    OnClick="followButton_Click" CausesValidation="true" />
                            </div>
                        </div>
                        <div class="col s12 m1 l1"></div>
                        <div class="col s12 m1 l1">
                            <div class="label-new">
                                <asp:Button runat="server" ID="saveButton" Text=" إرسال   "
                                    CssClass="btn" ToolTip="حفظ الطلب و إعادتة الى لجنة البت "
                                    OnClick="saveButton_Click" CausesValidation="true" />
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

            $('#iqamaNumberTextBox').keypress(function(e) {
                $('#bounderyNumberTextBox').val("");
            });
            $('#bounderyNumberTextBox').keypress(function(e) {
                $('#iqamaNumberTextBox').val("");
            });
            $('#sequenceNumberTextBox').keypress(function(e) {
                NumbersOnly(e);
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

        function scrollToElement() {
            var target = document.getElementById('offsetDiv').offsetTop;
            //Scrolls to that target location
            window.scrollTo(0, target);
        }

        function scrollToRequestDetails() {
            var target = document.getElementById('requestDetailsPointer').offsetTop;
            //Scrolls to that target location
            window.scrollTo(0, target);
        }

        function checkEmpty() {
            var borderNumberTextValue = $("input[id*='bounderyNumberTextBox']").val();
            var iqamaNumberTextValue = $("input[id*='iqamaNumberTextBox']").val();
            //check if data entered not valid 
            if (borderNumberTextValue != null && borderNumberTextValue != "") {
                var check = isBorderNumberValid(borderNumberTextValue);
                if (!check) {
                    $('#<%= bounderyNumberErrorLabel.ClientID %>').show();
                    return true;
                }
            }
            if (iqamaNumberTextValue != null && iqamaNumberTextValue != "") {
                var checkIqama = isIdNumberValid(iqamaNumberTextValue);
                if (!checkIqama) {
                    $('#<%= iqamaNumbererrorNumberLabel.ClientID %>').show();
                    return true;
                }
            }
        }

    </script>
</asp:Content>
