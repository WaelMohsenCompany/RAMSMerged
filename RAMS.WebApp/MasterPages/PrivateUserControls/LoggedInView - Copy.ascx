<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedInView.ascx.cs" Inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.LoggedInView" %>
<ul>
    <li id="liNotifications" runat="server">
        <a href="/ciw/Notification/UserNotifications.aspx" class="">
            <span class="mdi-social-notifications-none " style="font-size: 1.5em; vertical-align: middle; color: red;"></span>التنبيهات</a>
    </li>
    <li class="user">
        <div class="dropdown-button" data-activates="user-dropdown">
            <asp:Image ID="imgProfileIcon" runat="server" ImageUrl="~/assets/_con/images/loai.jpg" AlternateText="الصورة الشخصية" CssClass="circleimg" /><%= UserDisplayName %><i id="toggle" class="mdi-navigation-expand-more right no-margin"></i>
        </div>

        <ul id="user-dropdown" class="dropdown-content">
            <li>
                <asp:LinkButton ID="lnkbtnMyAccount" runat="server" OnClick="lnkbtnMyAccount_Click" CausesValidation="false">
                <i class="fa fa-user"></i>
                حسابي
                </asp:LinkButton>
            </li>
            <li id="liEditProfile" runat="server">
                <asp:HyperLink ID="hlnkEditProfile" runat="server" CausesValidation="false">
                <i class="fa mdi-editor-mode-edit"></i>
                تعديل بيانات المستخدم
                </asp:HyperLink>
            </li>
            <li id="liChangePassword" runat="server">
                <asp:HyperLink ID="hlnkChangePassword" runat="server" CausesValidation="false">
                <i class="fa mdi-action-settings"></i>
                تغيير كلمة المرور
                </asp:HyperLink>
            </li>
            <li class="divider"></li>
            <li>
                <asp:LinkButton ID="lnkbtnLogout" runat="server" OnClick="lnkbtnLogout_Click" CausesValidation="false">
                <i class="fa fa-sign-out"></i>
                تسجيل الخروج
                </asp:LinkButton>
            </li>
        </ul>
    </li>
</ul>

