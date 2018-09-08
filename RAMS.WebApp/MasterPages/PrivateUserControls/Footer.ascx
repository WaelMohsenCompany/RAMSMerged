<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.Footer" %>
<%-- <%@ Import Namespace="Mol.Common.Resources" %> --%>

<div class="FooterContainer">
    <!-- -->
    <div class="Footer">
        <div class="CopyRight">
            <asp:Label ID="Label1" runat="server"
                Text="???? ?????? ?????? ?????? ????? ???????? ??????? ????????  "></asp:Label><%=System.DateTime.Now.Year %>
        </div>
        <div style="float: right; margin-right: 8px; margin-top: 7px; color: #FFF;">
            <asp:Label ID="Label2" runat="server"
                Text="<%:GeneralMessages.CallCenter %>"></asp:Label>
        </div>
    </div>
    <!-- -->
</div>
