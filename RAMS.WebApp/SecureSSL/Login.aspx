<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAMS.WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Label ID="IdLabel" runat="server" Text="رقم المستخدم"></asp:Label><br/>
        <asp:TextBox ID="UserIdTextBox" runat="server"></asp:TextBox><br/>
        
        <asp:Label ID="UserNameLabel" runat="server" Text="اسم المستخدم"></asp:Label><br/>
        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox><br/>

        <asp:Label ID="RedirectLabel" runat="server" Text="الذهاب الى"></asp:Label><br/>
        
        <asp:DropDownList ID="RedirectDropDownList" runat="server">
    
         <asp:ListItem Text="افراد" Value="/Services/Twsl/Individual/Home.aspx"/>
         <asp:ListItem Text="شركات" Value="/Services/Twsl/Establishment/Home.aspx"/>
         <asp:ListItem Text="مدير النظام" Value="/Services/Twsl/ManPower/NotificationsSetting.aspx"/>
         
        <asp:ListItem Text="التنبيهات العامة مدير النظام" Value="/Services/Twsl/ManPower/GeneralNotifications.aspx"/>

        </asp:DropDownList>

        <br/><br/><br/>

        <asp:Button ID="RedirectButton" runat="server" OnClick="RedirectButton_Click" Text="Load User" />
    
    </div>
    </form>
</body>
</html>
