<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ManpowerMenu.ascx.cs"
    Inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.ManpowerMenu" %>
<div class="StaticPartsContainer">
    <div class="StaticPartsHeader">
        <div class="StaticPartsFooter">
            <div class="AboutMinistry">
                <h3 style="cursor: pointer;">
                    <span id="ctl00_Menu1_label43">
                        <asp:Literal ID="Literal2" runat="server" Text="القوى العاملة" meta:resourcekey="ManPower" />
                    </span>
                </h3>
                <div id="MP" style="display: none;">
                </div>
                <div class="SideNavigationTitle">
                    <a href="javascript: void(0);" class="MneuToggleLinks" onclick="ToggleMenu('image1', 'image2' , 'Estb')"
                        id="lnkManageEstablishments" runat="server">
                        <img src="/ManPower/UI/Images/AR/Icons/expand.gif" id="image1" />
                        <img src="/ManPower/UI/Images/AR/Icons/contract.gif" id="image2" style="display: none;" />
                        <strong>
                            <asp:Literal ID="Literal3" runat="server" Text="إدارة بيانات المنشآت" meta:resourcekey="ManageEstablishments" />
                        </strong>
                    </a>
                </div>
                <ul id="Estb" style="display: none;">
                    <li>
                        <asp:LinkButton ID="lbEstablishmentEvaluation"
                            CausesValidation="false" runat="server" Text="تقييم منشأة"
                            OnClick="lbEstablishmentEvaluation_Click"></asp:LinkButton>
                    </li>

                    <li>
                        <asp:LinkButton ID="lbEstablishmentSearch" navigateurl='<%$ appSettings:Manpower_SearchEstablishment %>'
                            CausesValidation="false" runat="server" Text="البحث عن منشأة" meta:resourcekey="hlnkEstablishmentSearchResource1"
                            OnClick="lbEstablishmentSearch_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="hlnkEstablishmentAdd" OnClick="hlnkEstablishmentAdd_Click" CausesValidation="false"
                            runat="server" meta:resourcekey="AddEstablishment">تعريف منشأة</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="hlnkEstablishmentEdit" runat="server" OnClick="hlnkEstablishmentEdit_Click"
                            CausesValidation="false" Text="التحقق من بيانات ملف جديد"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="hlnkEstablishmentView" runat="server" OnClick="hlnkEstablishmentView_Click"
                            CausesValidation="false" Text="عرض بيانات ملف جديد"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="hlnkEditEstablishemntFile" runat="server" OnClick="hlnkEditEstablishemntFile_Click"
                            CausesValidation="false" Text="تعديل بيانات ملف منشأة"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkEstablishmentEditStatus" NavigateUrl='<%$ appSettings:Manpower_EstablishmentEditStatus %>'
                            runat="server" meta:resourcekey="hlnkEstablishmentEditStatusResource1"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbNoteSearch" navigateurl='<%$ appSettings:Manpower_NoteSearch %>'
                            CausesValidation="false" runat="server" Text="البحث عن ملاحظة" meta:resourcekey="hlnkNoteSearchResource1"
                            OnClick="lbNoteSearch_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkNoteAdd" NavigateUrl='<%$ appSettings:Manpower_NoteAdd %>'
                            runat="server" Text="إضافة ملاحظة" meta:resourcekey="hlnkNoteAddResource1"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkNoteCancel" NavigateUrl='<%$ appSettings:Manpower_NoteStop %>'
                            runat="server" Text="إنهاء ملاحظة"></asp:HyperLink>
                    </li>
                </ul>
                <div class="SideNavigationTitle">
                    <a href="javascript: void(0);" class="MneuToggleLinks" onclick="ToggleMenu('Img1', 'Img2' , 'Reps')"
                        id="lnkManageBusinessUsers" runat="server">
                        <img src="/ManPower/UI/Images/AR/Icons/expand.gif" id="Img1" onclick="return Img1_onclick()" /><img
                            src="/ManPower/UI/Images/AR/Icons/contract.gif" id="Img2" style="display: none;" />
                        <strong>
                            <asp:Literal ID="Literal8" runat="server" Text="إدارة بيانات ممثلي المنشأة" meta:resourcekey="ManageBusinessUsers" />
                        </strong></a>
                </div>
                <ul id="Reps" style="display: none;">
                    <li>
                        <asp:LinkButton ID="lbAgentSearch" navigateurl='<%$ appSettings:Manpower_AgentSearch %>'
                            CausesValidation="false" runat="server" Text="البحث عن وكيل" meta:resourcekey="hlnkAgentSearchResource1"
                            OnClick="lbAgentSearch_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkAgentAdd" NavigateUrl='<%$ appSettings:Manpower_AgentAdd %>'
                            runat="server" Text="إضافة وكيل" meta:resourcekey="hlnkAgentAddResource1"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkAgentUpdate" NavigateUrl='<%$ appSettings:Manpower_AgentUpdate %>'
                            runat="server" Text="تعديل بيانات الوكيل" meta:resourcekey="hlnkAgentUpdateResource1"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbCommissionerSearch" runat="server" Text="البحث عن مفوض" meta:resourcekey="hlnkCommissionerSearchResource1"
                            CausesValidation="false" navigateurl='<%$ appSettings:Manpower_CommissionerSearch %>'
                            OnClick="lbCommissionerSearch_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbCommissionerAdd" runat="server" Text="إضافة مفوض" meta:resourcekey="hlnkCommissionerAddResource1"
                            CausesValidation="false" navigateurl='<%$ appSettings:Manpower_CommissionerAdd %>'
                            OnClick="lbCommissionerAdd_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkCommissionerUpdate" runat="server" Text="تعديل بيانات مفوض"
                            meta:resourcekey="hlnkCommissionerUpdateResource1" NavigateUrl='<%$ appSettings:Manpower_CommissionerUpdateURL %>'></asp:HyperLink>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbOwnerSearch" navigateurl='<%$ appSettings:Manpower_SearchOwner %>'
                            CausesValidation="false" runat="server" Text="البحث عن صاحب منشأة" meta:resourcekey="hlnkOwnerSearchResource1"
                            OnClick="lbkOwnerSearch_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkOwnerUpdate" NavigateUrl='<%$ appSettings:Manpower_UpdateOwner %>'
                            runat="server" Text="تعديل بيانات صاحب منشأة" meta:resourcekey="hlnkOwnerUpdateResource1" />
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkListSerivesOffice" NavigateUrl='<%$ appSettings:Manpower_ViewServiceOffice %>'
                            runat="server" Text="عرض مكتب خدمات/ استقدام" meta:resourcekey="hlnkListSerivesOfficeResource1"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:LinkButton ID="lbAddSerivesOffice" navigateurl='<%$ appSettings:Manpower_AddServiceOffice %>'
                            CausesValidation="false" runat="server" Text="إضافة مكتب خدمات/ استقدام" meta:resourcekey="hlnkAddSerivesOfficeResource1"
                            OnClick="lbAddSerivesOffice_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkUpdateSerivesOffice" NavigateUrl='<%$ appSettings:Manpower_EditServiceOffice %>'
                            runat="server" Text="تعديل بيانات مكتب خدمات/ استقدام" meta:resourcekey="hlnkUpdateSerivesOfficeResource1"></asp:HyperLink>
                    </li>
                </ul>
                <div style="display: none;">
                    <div id="divManpowerReports" runat="server">
                        <div class="SideNavigationTitle">
                            <a href="javascript: void(0);" class="MneuToggleLinks" onclick="ToggleMenu('Img41', 'Img42' , 'Reports')"
                                id="aManpowerAuditReports" runat="server">
                                <img src="/ManPower/UI/Images/AR/Icons/expand.gif" id="Img41" onclick="return Img1_onclick()" /><img
                                    src="/ManPower/UI/Images/AR/Icons/contract.gif" id="Img42" style="display: none;" />
                                <strong>
                                    <asp:Literal ID="Literal1" runat="server" Text="تقارير المستخدمين" meta:resourcekey="ManPowerReports" />
                                </strong></a>
                        </div>
                        <ul id="Reports" style="display: none;">
                            <li>
                                <asp:LinkButton ID="lnkBtnChangeJobReport" CausesValidation="false" runat="server"
                                    Text="تقرير خدمه تغيير المهنه" meta:resourcekey="lnkBtnChangeJobReportResource1"
                                    OnClick="lnkBtnChangeJobReport_Click" Enabled="false"></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="hlnkEmailChangeReport" CausesValidation="false" runat="server"
                                    Text="تقرير تغيير البريد الالكترونى" meta:resourcekey="hlnkEmailChangeReportResource1"
                                    OnClick="hlnkEmailChangeReport_Click" Enabled="false"></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkBtnLicenseIssueReport" CausesValidation="false" runat="server"
                                    Text="تقرير خدمه اصدار رخصه عمل" meta:resourcekey="lnkBtnLicenseIssueReportResource1"
                                    OnClick="lnkBtnLicenseIssueReport_Click" Enabled="false"></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkBtnServiceChangeReport" CausesValidation="false" runat="server"
                                    Text="تقرير خدمه نقل الخدمه" meta:resourcekey="lnkBtnServiceChangeReportResource1"
                                    OnClick="lnkBtnServiceChangeReport_Click" Enabled="false"></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnkBtnSrvUserStatisticsReport" CausesValidation="false" runat="server"
                                    Text="تقرير اداء مستخدمى النظام" meta:resourcekey="lnkBtnSrvUserStatisticsReportResource1"
                                    OnClick="lnkBtnSrvUserStatisticsReport_Click" Enabled="false"></asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="SideNavigationTitle">
                    <a href="javascript: void(0);" class="MneuToggleLinks" onclick="ToggleMenu('Img3', 'Img4' , 'Labors')"
                        id="lnkManageLaborers" runat="server">
                        <img src="/ManPower/UI/Images/AR/Icons/expand.gif" id="Img3" />
                        <img src="/ManPower/UI/Images/AR/Icons/contract.gif" id="Img4" style="display: none;" />
                        <strong>
                            <asp:Literal ID="Literal17" runat="server" Text="إدارة بيانات العاملين" meta:resourcekey="ManageLaborers" />
                        </strong>
                    </a>
                </div>
                <ul id="Labors" style="display: none;">
                    <li>
                        <asp:LinkButton ID="lbLaborerSearch" navigateurl='<%$ appSettings:Manpower_LaborerSearch %>'
                            CausesValidation="false" runat="server" Text="البحث عن عامل" meta:resourcekey="hlnkLaborerSearchResource1"
                            OnClick="lbLaborerSearch_Click"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkLaborerEdit" NavigateUrl='<%$ appSettings:Manpower_LaborerEditURL %>'
                            runat="server" Text="تعديل بيانات عامل" meta:resourcekey="hlnkLaborerEdit"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkLaborerUpload" NavigateUrl='<%$ appSettings:Manpower_LaborersImport  %>'
                            runat="server" meta:resourcekey="UploadLaborerTitle">تحميل بيانات العاملين</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkLaborerExport" NavigateUrl='<%$ appSettings:Manpower_LaborersExport %>'
                            runat="server" Text="تصدير بيانات العاملين" meta:resourcekey="hlnkLaborerExportResource1"></asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkLaborersUpdate" NavigateUrl='<%$ appSettings:Manpower_LaborersEdit %>'
                            runat="server" Text="تعديل بيانات العاملين" meta:resourcekey="hlnkLaborersUpdateResource1"></asp:HyperLink>
                    </li>
                </ul>
                <div class="SideNavigationTitle">
                    <a href="javascript: void(0);" class="MneuToggleLinks" onclick="ToggleMenu('Img5', 'Img6' , 'LaborsMove')"
                        id="lnkManageLaborerTransfer" runat="server">
                        <img src="/ManPower/UI/Images/AR/Icons/expand.gif" id="Img5" />
                        <img src="/ManPower/UI/Images/AR/Icons/contract.gif" id="Img6" style="display: none;" />
                        <strong>
                            <asp:Literal ID="Literal23" runat="server" Text="نقل العاملين" meta:resourcekey="MoveLaborers" />
                        </strong>
                    </a>
                </div>
                <ul id="LaborsMove" style="display: none;">
                    <li>
                        <asp:HyperLink ID="hlnkTransferInUnified" NavigateUrl='<%$ appSettings:Manpower_LaborerMoveInUnified %>'
                            runat="server" meta:resourcekey="IntoUnifiedNumber">داخل الرقم الموحد</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkTransferOutUnified" NavigateUrl='<%$ appSettings:Manpower_LaborerMoveOutUnified %>'
                            runat="server" meta:resourcekey="NonSaudiOutNuifiedNumber">الوافدين خارج الرقم الموحد</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlnkTransferSaudian" NavigateUrl='<%$ appSettings:Manpower_LaborerMoveSaudian %>'
                            runat="server" meta:resourcekey="LMSTitle">نقل عامل سعودى</asp:HyperLink>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>

<%--<asp:Repeater ID="rp_Groups" runat="server" OnItemDataBound="rp_Groups_OnItemDataBound">
    <ItemTemplate>
        <div class="StaticPartsContainer" id="divServices" runat="server">
            <div class="StaticPartsHeader">
                <div class="StaticPartsFooter">
                    <div class="AboutMinistry">
                        <h3 style="cursor: pointer;">
                            <span id="ctl00_Menu1_Label4">
                                <asp:Label runat="server" ID="lblServices" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
                            </span>
                        </h3>
                        <asp:Repeater ID="rp_ServicesTitles" runat="server" OnItemDataBound="rp_ServicesTitles_OnItemDataBound">
                            <ItemTemplate>
                                <div class="SideNavigationTitle">
                                    <a id="lnk_ServiceToggler" href="javascript: void(0);" class="MneuToggleLinks"
                                        onclick="ToggleMenu('ImgExpand<%# Container.ItemIndex + 1 %>_<%# DataBinder.Eval(Container.DataItem, "ID") %>',
                             'ImgCollapse<%# Container.ItemIndex + 1 %>_<%# DataBinder.Eval(Container.DataItem, "ID") %>',
                             'Service<%# Container.ItemIndex + 1 %>_<%# DataBinder.Eval(Container.DataItem, "ID") %>')">
                                        <img src="/ManPower/UI/Images/AR/Icons/expand.gif" id="ImgExpand<%# Container.ItemIndex + 1 %>_<%# DataBinder.Eval(Container.DataItem, "ID") %>" />
                                        <img src="/ManPower/UI/Images/AR/Icons/contract.gif" id="ImgCollapse<%# Container.ItemIndex + 1 %>_<%# DataBinder.Eval(Container.DataItem, "ID") %>" style="display: none;" />
                                        <strong>
                                            <span meta:resourcekey="<%# DataBinder.Eval(Container.DataItem, "Name") %>"><%# DataBinder.Eval(Container.DataItem, "Name") %></span>
                                        </strong></a>
                                </div>
                                <ul id='Service<%# Container.ItemIndex + 1 %>_<%# DataBinder.Eval(Container.DataItem, "ID") %>' style="display: none;">
                                    <asp:Repeater ID="rp_ServicesPrivileges" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <asp:HyperLink ID="hlnk_item" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "URL") %>'>
                                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                                </asp:HyperLink>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>--%>

<script language="javascript" type="text/javascript">

    function HideAll() {
        if (document.getElementById("MP")) {
            document.getElementById("MP").style.display = "none";
        }
        if (document.getElementById("UM")) {
            document.getElementById("UM").style.display = "none";
        }
        if (document.getElementById("Services")) {
            document.getElementById("Services").style.display = "none";
        }
    }
    function Show(ulID) {
        document.getElementById(ulID).style.display = "block"
    }
    function ToggleMenu(img1, img2, divID) {
        if (document.getElementById(img2).style.display == "none") {
            document.getElementById(img1).style.display = "none";
            document.getElementById(img2).style.display = "";
            document.getElementById(divID).style.display = "block";
        }
        else {
            document.getElementById(img1).style.display = "";
            document.getElementById(img2).style.display = "none";
            document.getElementById(divID).style.display = "none";
        }
    }
    function getUrlVars() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) { hash = hashes[i].split('='); vars.push(hash[0]); vars[hash[0]] = hash[1]; }

        return vars;
    }
    // Checking which submenu shall we open
    var hash = '<%= qsSm %>';
    if (hash == 1) {
        document.getElementById("Estb").style.display = "";
        document.getElementById("image1").style.display = "none";
        document.getElementById("image2").style.display = "";
    }
    else if (hash == 2) {
        document.getElementById("Reps").style.display = "";
        document.getElementById("Img1").style.display = "none";
        document.getElementById("Img2").style.display = "";
    }
    else if (hash == 3) {
        document.getElementById("Labors").style.display = "";
        document.getElementById("Img3").style.display = "none";
        document.getElementById("Img4").style.display = "";
    }
    else if (hash == 4) {
        document.getElementById("LaborsMove").style.display = "";
        document.getElementById("Img5").style.display = "none";
        document.getElementById("Img6").style.display = "";
    }

    function Img1_onclick() {

    }

</script>

