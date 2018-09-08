<%@ control language="C#" autoeventwireup="true" codebehind="EservicesSideMenu.ascx.cs" inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.EservicesSideMenu" %>


<style>
    li.platinum, li.highgreen, li.midgreen, li.lowgreen, li.nitred ,.EstablishmentName{
    border-bottom: 1px solid rgba(255, 255, 255, 0.35) !important;
    }
    .blackFont {
        color: white !important;
    }

    input[type=text]::-ms-clear {
        display: none !important;
    }

    .PlatinuimColor {
        background-color: #A0A0A0 !important;
        color: #fff !important;
    }

    .GreenHighColor {
        background-color: yellowGreen !important;
        color: #fff !important;
    }

    .GreenMedColor {
        background-color: #74AF27 !important;
        color: #fff !important;
    }

    .GreenSmallColor {
        background-color: #CAD400 !important;
        color: #fff !important;
    }

    .YellowColor {
        background-color: #00853E !important;
        color: #fff !important;
    }

    .RedColor {
        background-color: red !important;
        color: #fff !important;
    }

    .VerySmallGreenColor {
        background-color: green !important;
        color: #fff !important;
    }

    .VerySmallRedColor {
        background-color: red !important;
        color: #fff !important;
    }
</style>

<asp:HiddenField runat="server" ID="hdnSelectedEstablishmentID" Value="0" />
<asp:HiddenField runat="server" ID="hdnGovContractView" Value="0" />


<div class="nano">
    <div class="nano-content">

        <ul id="LoggedInSideMenuView" runat="server" visible="false">
            <li class="" style="line-height: 5.7rem; border-left: 2px solid #e5e5e5; border-bottom: 1px solid #e5e5e5; overflow: hidden;">
                <img src="/assets/_con/images/line-mol.png" alt="" style="width: 170px; vertical-align: middle;" /></li>
            <li>
                <a class="yay-sub-toggle" id="lnkEstablishmentListHeader"><i class="fa fa-cogs"></i>منشآتي<span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                <ul>
                    <input type="text" id="filter" placeholder="ابحث للوصول السريع">
                    <ul>
                        <asp:Repeater runat="server" ID="RP_UserEstablishmentList" OnItemCommand="Repeater_ItemCommand">
                            <ItemTemplate>
                                <li class="EstablishmentName">
                                    <a class="yay-sub-toggle" style='<%# Eval("EstablishmentColor") %>' id="<%# Eval("EstablishmentID") %>"><%# Eval("EstablishmentNumber") %>&nbsp;<%# Eval("EstablishmentName") %> <span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                                    <ul>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkBasicInfo" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",BasicInfo"%>'>المعلومات الأساسية</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="LinkButton3" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",EstablishmentServices"%>'>خدمات المنشأة</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkAddress" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Address" %>'>العنوان</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkLaborers" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Laborers"%>'>بيانات العمالة</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkLicenses" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Licenses" %>'>التراخيص</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkStatistics" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Statistics" %>'>الاحصاءات</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkEstOwner" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",EstablishmentOwner" %>'>صاحب المنشأة</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkAgent" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Agents" %>'>الوكلاء</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkCommissioner" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Commisioners" %>'>المفوضون</asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton CssClass="blackFont" CausesValidation="false" runat="server" ID="lnkNotes" CommandName="Redirect" CommandArgument='<%# Eval("EstablishmentID")+",Notes" %>'>الملاحظات</asp:LinkButton></li>
                                    </ul>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ul>
            </li>
            <li>
                <asp:HyperLink ID="hlnkOpenEstablishmentFile" CssClass="waves-effect waves-green" runat="server"
                    NavigateUrl="<%$ Appsettings:Manpower_EstablishmentAdd %>" ToolTip="هذه الخدمة متاحة لجميع الأفراد"><i class="fa fa-plus-circle"></i>فتح ملف منشأة</asp:HyperLink>
            </li>
            <li id="liAccountManager" runat="server" visible="false">
                    <a href="<%=this.ResolveUrl(GetUrlFromSiteMap(Mol.Common.SiteMapPages.AccountManagerSearch)) %>" title="هذه الخدمة متاحة لمالك المنشأه أو ممثل الرقم الموحد" class="waves-effect waves-green"><i class="mdi-action-account-box"></i>مدير حساب المنشأة</a>
            </li>
            <li>
                <a class="yay-sub-toggle"><i class="fa fa-cogs"></i>الإستعلامات الإلكترونية<span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                <ul>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/SaudiEmpInquiry.aspx">الإستعلام عن موظف سعودي</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NonSaudiEmpInquiry.aspx">الإستعلام عن موظف وافد</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/LaborOfficeServicesInquiry.aspx">الإستعلام عن خدمات مكتب العمل</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/CompanyMainInfoInquiry.aspx">الإستعلام عن البيانات الرئيسية للمنشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/EstablishmentNitaqatInquiry.aspx">الاستعلام عن نطاق منشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NitaqatPointsCalculator.aspx">حاسبة نطاقات الافتراضية</a></li>
                </ul>
            </li>
        </ul>

        <ul id="ReadOnlyAdminView" runat="server" visible="false">
            <li class="" style="line-height: 5.6rem; border-left: 2px solid #e5e5e5; border-bottom: 1px solid #e5e5e5; overflow: hidden;">
                <img src="/assets/_con/images/line-mol.png" alt="" style="width: 170px; vertical-align: middle;" /></li>
            <li>
                <a class="yay-sub-toggle"><i class="fa fa-cogs"></i>الإستعلامات الإلكترونية<span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                <ul>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/SaudiEmpInquiry.aspx">الإستعلام عن موظف سعودي</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NonSaudiEmpInquiry.aspx">الإستعلام عن موظف وافد</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/LaborOfficeServicesInquiry.aspx">الإستعلام عن خدمات مكتب العمل</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/CompanyMainInfoInquiry.aspx">الإستعلام عن البيانات الرئيسية للمنشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/EstablishmentNitaqatInquiry.aspx">الاستعلام عن نطاق منشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NitaqatPointsCalculator.aspx">حاسبة نطاقات الافتراضية</a></li>
                </ul>
            </li>
        </ul>

        <ul id="PublicLogoView" runat="server" visible="false">
            <li class="" style="line-height: 5.6rem; border-left: 2px solid #e5e5e5; border-bottom: 1px solid #e5e5e5; overflow: hidden;">
                <img src="/assets/_con/images/line-mol.png" alt="" style="width: 170px; vertical-align: middle;" /></li>
            <li>
                <a class="yay-sub-toggle"><i class="fa fa-cogs"></i>الإستعلامات الإلكترونية<span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                <ul>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/SaudiEmpInquiry.aspx">الإستعلام عن موظف سعودي</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NonSaudiEmpInquiry.aspx">الإستعلام عن موظف وافد</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/LaborOfficeServicesInquiry.aspx">الإستعلام عن خدمات مكتب العمل</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/CompanyMainInfoInquiry.aspx">الإستعلام عن البيانات الرئيسية للمنشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/EstablishmentNitaqatInquiry.aspx">الاستعلام عن نطاق منشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NitaqatPointsCalculator.aspx">حاسبة نطاقات الافتراضية</a></li>
                </ul>
            </li>
            <li>
                <a class="" href="/SecureSSL/Login.aspx"><i class="mdi-action-exit-to-app"></i>تسجيل الدخول</a>
            </li>
            <li>
                <a class="" href="/IndividualUser/BasicInfo.aspx"><i class="fa fa-plus-circle"></i>إنشاء حساب</a>
            </li>
        </ul>
        <ul id="GovContractView" runat="server" visible="false">
            <li class="" style="line-height: 5.9; border-left: 2px solid #e5e5e5; border-bottom: 1px solid #e5e5e5; overflow: hidden;">
                <img src="/assets/_con/images/line-mol.png" alt="" style="width: 170px; vertical-align: middle;" /></li>
            <li>
                <a class="yay-sub-toggle" id="lnkGovContractTab"><i class="fa fa-cogs"></i>العقود الحكومية<span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                <ul>
                    <li id="liContractSearch" runat="server">
                        <asp:LinkButton runat="server" PostBackUrl="~/GovContractsRoot/Pages/Contracts/ContractSearch.aspx" ID="lnkContractSearch" CausesValidation="False" CssClass="waves-effect waves-green">
                            <asp:Label ID="lblContractSearch" runat="server" Text="البحث">
                            </asp:Label>
                        </asp:LinkButton>
                    </li>
                    <li id="liReviewContracts" runat="server">
                        <asp:LinkButton runat="server" PostBackUrl="~/GovContractsRoot/Pages/Contracts/ContractPendingReviewSearch.aspx" ID="LinkButton2" CausesValidation="False" CssClass="waves-effect waves-green">
                            <asp:Label ID="lblReviewContracts" runat="server" Text="المراجعة"></asp:Label>
                        </asp:LinkButton>
                    </li>
                    <li id="liAddContract" runat="server">
                        <asp:LinkButton runat="server" PostBackUrl="~/GovContractsRoot/Pages/Contracts/Add.aspx" ID="lnkAddContract" CausesValidation="False" CssClass="waves-effect waves-green">
                            <asp:Label ID="lblAddContract" runat="server" Text="إضافة تأييد بعقد"></asp:Label>
                        </asp:LinkButton>
                    </li>
                    <li id="liAssentAdd" runat="server">
                        <asp:LinkButton runat="server" PostBackUrl="~/GovContractsRoot/Pages/Contracts/AssentAdd.aspx" ID="LinkButton1" CausesValidation="False" CssClass="waves-effect waves-green">
                            <asp:Label ID="lblAssentAdd" runat="server" Text="إضافة تأييد بدون عقد"></asp:Label>
                        </asp:LinkButton>
                    </li>
                    <li id="liTransferCredit" runat="server">
                        <asp:LinkButton runat="server" PostBackUrl="~/GovContractsRoot/Pages/Contracts/ContractTransferCredit.aspx" ID="lnkTransferCredit" CausesValidation="False" CssClass="waves-effect waves-green">
                            <asp:Label ID="lblTransferCredit" runat="server" Text="نقل الرصيد">
                            </asp:Label>
                        </asp:LinkButton>
                    </li>
                    <li id="liReviewFinancialNitaqatRequest" runat="server">
                        <asp:LinkButton runat="server" PostBackUrl="~/GovContractsRoot/Pages/FinancialNitaqat/ReviewNitaqatFinancialRquest.aspx" ID="lnkReviewNitaqatFinancialRquest" CausesValidation="False" CssClass="waves-effect waves-green">
                            <asp:Label ID="lblReviewNitaqatFinancialRquest" runat="server" Text="دراسة طلب الالتحاق بنطاقات المساندة">
                            </asp:Label>
                        </asp:LinkButton>
                    </li>
                </ul>
            </li>
            <li>
                <a class="yay-sub-toggle"><i class="fa fa-cogs"></i>الإستعلامات الإلكترونية<span class="yay-collapse-icon mdi-navigation-expand-more"></span></a>
                <ul>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/SaudiEmpInquiry.aspx">الإستعلام عن موظف سعودي</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NonSaudiEmpInquiry.aspx">الإستعلام عن موظف وافد</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/LaborOfficeServicesInquiry.aspx">الإستعلام عن خدمات مكتب العمل</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/CompanyMainInfoInquiry.aspx">الإستعلام عن البيانات الرئيسية للمنشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/EstablishmentNitaqatInquiry.aspx">الاستعلام عن نطاق منشأة</a></li>
                    <li><a class="waves-effect waves-green" href="/Services/Inquiry/NitaqatPointsCalculator.aspx">حاسبة نطاقات الافتراضية</a></li>
                </ul>
            </li>
        </ul>
        <ul>
            <li class="label"><span>أدوات وروابط مهمة</span></li>
            <li>
                <a class="" href="/"><i class="mol-molicon"></i>وزارة العمل</a>
            </li>
            <li>
                <a class="" href="https://portal.mol.gov.sa"><i class="mdi-social-public"></i>موقع بوابة وزارة العمل</a>
            </li>
            <li>
                <a class="" href="http://www.emol.gov.sa/nitaqat"><i class="mdi-image-camera"></i>نطاقات</a>
            </li>
        </ul>

    </div>
</div>

<script>

    $(document).ready(function () {
        var SelectedEstablishmentID = $('#' + '<%= hdnSelectedEstablishmentID.ClientID  %>').val();
        if (SelectedEstablishmentID != 0) {
            $('#lnkEstablishmentListHeader').click();
            $('#' + SelectedEstablishmentID).click();
        }
        <%--   var SelectedEstablishmentID = $('#' + '<%= hdnGovContractView.ClientID  %>').val();
        if (SelectedEstablishmentID != 0) {
            $('#lnkGovContractTab').click();
        }--%>

    })
</script>
