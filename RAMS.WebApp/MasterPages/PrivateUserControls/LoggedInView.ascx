<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedInView.ascx.cs" Inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.LoggedInView" %>

<script type="text/javascript">
    var webApiHost = '<%= ConfigurationManager.AppSettings["TWSLURL"].ToString() %>';
    $(document).ajaxStop($.unblockUI);
    var value = '@Request.RequestContext.HttpContext.Session["someKey"]';
    $(function () {
        var getEstablishmentCount = function () {
            $.ajax({
                url: webApiHost + '/api/EstablishmentMailBox/UnreadedMessageCount?userid=' + $('#masterUserId').val(),
                type: 'GET',
                contentType: 'application/json; charset=utf-8'
            }).success(function (count) {

                if (count > 0) {
				if(count>1000)
				 count="999+";
                    $('#count').show().closest("li").show();
                    $('#count').text(count);

                } else {
                    //   $('#count').hide().closest("li").hide();
                }

            }).error(function (xhr, status, err) {
                $('#count').text('0');
                // $('#count').hide().closest("li").hide();
            });
        }
        getEstablishmentCount();
        setInterval(function () { getEstablishmentCount(); }, 1800000);
    });

</script>

<ul>
    <li>
        <a href="/Services/Twsl/Individual/MailBox.aspx/inbox/0" style="font-size: 1em; vertical-align: middle; display: inline">بوابة الأفراد</a>
    </li>
    <li id="liNotifications" runat="server">
        <asp:HiddenField runat="server" ID="masterUserId" ClientIDMode="Static" />
        <span id="count" style="display: inline;">0</span><a href="/Services/Twsl/Establishment/EstablishmentMaiBox.aspx/inbox/0" style="font-size: 1em; vertical-align: middle; display: inline">التنبيهات</a>
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

