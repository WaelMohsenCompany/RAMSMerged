<%@ Page Title="" Language="C#"
    MasterPageFile="~/MasterPages/Private.Master"
    AutoEventWireup="true"
    CodeBehind="ApproveRunawayComplain.aspx.cs"
    ValidateRequest="false"
    Inherits="RAMS.WebApp.Services.RAMS.MyClients.ApproveRunawayComplain" %>


<asp:Content ID="Content1" ContentPlaceHolderID="CPHHead" runat="server">
    البت في بلاغ التغيب
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--Error || Sucess Messages Div --%>
    <div class="row">
        <div class="col s12 m12 l12">
            <br />
            <div style="color: red; display: none;" class="alert" id="error_div"></div>
            <div style="color: green; display: none;" class="alert green lighten-4 green-text text-darken-2"
                id="success_div">
            </div>
        </div>
    </div>
    <div id="RunwayRequestManagmentDiv" class="card" runat="server">
        <div class="title">
            <h5>معايير البحث </h5>
        </div>
        <div class="content">
            <%--عملية البحث --%>
            <div id="searchDiv" runat="server">
                <br />
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>حالة الطلب   </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m4 l4">
                        <span>
                            <asp:DropDownList runat="server" ID="selectRunawayTypeRequestDropDownList" Visible="True" ClientIDMode="Static">
                                <Items>
                                    <asp:ListItem Text="الطلبات غير المعالجة" Value="UnderProcessing"></asp:ListItem>
                                    <asp:ListItem Text="الطلبات المردود عليها من مكتب العمل" Value="RepliedByLaborOffice"></asp:ListItem>
                                    <asp:ListItem Text="الطلبات المقبولة" Value="Accepted"></asp:ListItem>
                                    <asp:ListItem Text="الطلبات المرفوضة" Value="Rejected"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="col s12 m1 l1"></div>
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>مكتب العمل   </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m2 l2">
                        <span>
                            <asp:DropDownList runat="server" ID="laborerOfficesDropDownList"
                                DataTextField="Name" DataValueField="Id">
                            </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m2 l2">
                        <div class="label-new">
                            <span><b>رقم المنشأة  </b>: </span>
                        </div>
                    </div>
                    <div class="col s12 m4 l3">
                        <span><b>
                            <asp:TextBox runat="server" ID="laborerOfficeIdTextBox" MaxLength="2" Width="40"></asp:TextBox>
                            - 
                            <asp:TextBox runat="server" ID="sequenceNumberTextBox" MaxLength="7" Width="100"></asp:TextBox>
                        </b></span>
                    </div>
                    <div class="col s12 m4 l4">
                        <asp:Label runat="server" ID="establishmentNumberErrorMessageLabel" Visible="False"
                            ForeColor="Red" Text="عفوا عزيزي المستخدم، رقم المنشأة غير صحيح"></asp:Label>
                    </div>
                </div>
                <%--بحث--%>
                <div class="row">
                    <div class="col s12 m4 l2"></div>
                    <div class="col s12 m2 l2">
                        <asp:Button ID="searchrunawayButton" runat="server" Text="بحث"
                            CssClass="btn" OnClick="SearchRunAwayButton_Click" />
                    </div>
                </div>
            </div>
            <br />
            <br />
            <%--كل  البلاغات السابقة--%>
            <div id="allRunawayRequestsDiv" runat="server">
                <div class="title">
                    <h5>قائمة البلاغات </h5>
                </div>
                <div id="requestDetailsPointer"></div>
                <div class="row">
                    <div class="col l12 s12 m12">
                        <div class="col l12 s12 ">
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
                                    <asp:BoundField HeaderText="اسم العامل" DataField="LaborerFullName" SortExpression="LaborerFullName" />
                                    <asp:BoundField HeaderText="التاريخ" DataField="RunAwayRequestDate" SortExpression="RunAwayRequestDate" />
                                    <asp:BoundField HeaderText="حالة طلب إثبات كيدية البلاغ" DataField="ComplaintRequestStatusName"
                                        SortExpression="ComplaintRequestStatusName" />
                                    <asp:TemplateField HeaderText="تنبية">
                                        <ItemTemplate>
                                            <asp:Label runat="server"
                                                Text='<%# bool.Parse(Eval("IsBeyondInitialActionPeriod").ToString()) ?"تجاوز مدة الإجراء الأولي ":"  " %>'
                                                ForeColor="Red"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
                <div id="Contentdiv" runat="server" class="content">
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>رقم البلاغ </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayNumberLiteral"></asp:Literal>
                            </span>
                        </div>
                        <div class="col s12 m1 l1"></div>
                        <div class="col s12 m2 l2">
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
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>اسم العامل     </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m5 l5">
                            <span>
                                <asp:Literal runat="server" ID="laborNameLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div class="row">
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
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>تاريخ تقديم البلاغ </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayDateLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>
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
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayStatusLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>تاريخ تقديم طلب إثبات الكيدية  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayComplainDateLiteral"></asp:Literal>
                            </span>
                        </div>
                        <div class="col s12 m1 l1"></div>
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>حالة طلب إثبات الكيدية  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m3 l2">
                            <span>
                                <asp:Literal runat="server" ID="runawayComplainStatusLiteral"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>ملاحظات أخرى  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m10 l10">
                            <span>
                                <asp:Literal runat="server" ID="NotesLiteral">لا يوجد</asp:Literal>
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
                                                CommandName="RunAwayFilesPathsFieldCommand"></asp:LinkButton>
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
                                <span><b>سبب التوقف عن العمل  </b></span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <span>
                                <asp:TextBox ID="stopWorkingReasonTextBox"
                                    runat="server"
                                    Enabled="False"
                                    TextMode="MultiLine"
                                    Height="106"
                                    MaxLength="500">
                                </asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class=" row title">
                        <h5>تفاصيل إفادة مكتب العمل    </h5>
                    </div>
                    <br />
                    <%--إفادة مكتب العمل--%>
                    <div class="row">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                                <span><b>إفادة مكتب العمل  </b>: </span>
                            </div>
                        </div>
                        <div class="col s12 m6 l6">
                            <span>
                                <asp:TextBox runat="server" 
                                    ID="laborOfficeTestimonyTextBox" 
                                    TextMode="MultiLine" Enabled="False"
                                    Height="105"></asp:TextBox>
                            </span>
                        </div>
                    </div>
                    <div class=" row title" runat="server" id="LaboerOfficeDecisionTitleDiv">
                        <h5>قرار إدارة بلاغات التغيب   </h5>
                    </div>
                    <br />
                    <div id="pointerDiv" class="row"></div>
                    <div class="row" id="selectOperationButtonListDiv" runat="server">
                        <div class="col s12 m2 l2">
                            <div class="label-new">
                            </div>
                        </div>
                        <div class="col s12 m5 l5">
                            <asp:RadioButtonList runat="server" ID="selectOperationButtonList" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="SelectOperationButtonList_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Text="قبول" Value="Accept" Selected="True" />
                                <asp:ListItem Text="رفض" Value="Reject" />
                                <asp:ListItem Text="طلب إفادة مكتب العمل" Value="SentToLaborOffice">
                                </asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <%--سبب الرفض--%>
                    <div id="rejectionReasonDiv" runat="server">
                        <div class="row">
                            <div class="col s12 m2 l2">
                                <div class="label-new">
                                    <span><b>سبب الرفض  <b style="color: red">*</b></b> </span>
                                </div>
                            </div>
                            <div class="col s12 m6 l6">
                                <asp:TextBox ID="refuseReasonTextBox" runat="server"
                                    ValidationGroup="refuseReasonValidationGroup"
                                    TextMode="MultiLine"
                                    Height="130"
                                    MaxLength="500"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ErrorMessage="عفوا عزيزي المستخدم ، سبب الرفض حقل الزامى"
                                    ForeColor="Red"
                                    ControlToValidate="refuseReasonTextBox"
                                    ValidationGroup="refuseReasonValidationGroup">
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
                                    ID="RegularExpressionValidator3"
                                    ControlToValidate="refuseReasonTextBox"
                                    Text="يجب عدم إدخال أكثر من 500 حرف"
                                    ValidationExpression="^[\s\S]{0,500}$"
                                    runat="server"
                                    ValidationGroup="refuseReasonValidationGroup"
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
                                    ID="RegularExpressionValidator2"
                                    ControlToValidate="refuseReasonTextBox"
                                    Text="يجب عدم إدخال حروف خاصة"
                                    ValidationExpression="^[أ-ي0-9a-zA-Z. ءلآآـ]*"
                                    runat="server" Display="Dynamic"
                                    ForeColor="Red"
                                    ValidationGroup="refuseReasonValidationGroup" />
                            </div>
                        </div>
                    </div>
                    <%--Save Request--%>
                    <div class="row" id="actionsButtonsDiv" runat="server">
                        <div class="col s12 m2 l2">
                            <div class="label-new"></div>
                        </div>
                        <div class="col s1 m1 l1">
                            <asp:Button runat="server" ID="saveButton" Text="حفظ "
                                CssClass="btn" OnClick="SaveButton_Click"
                                ValidationGroup="refuseReasonValidationGroup" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript">
        function errorBuilder() 
        {
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
        function scrollToElement(){
            var target = document.getElementById('pointerDiv').offsetTop;
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
