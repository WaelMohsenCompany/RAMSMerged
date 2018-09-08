<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GovContractsTabs.ascx.cs"
    Inherits="Mol.Web.Common.UI.MasterPages.PrivateUserControls.GovContractsTabs" %>
<div class="row">
    <div class="col l12 m12 s12">
        <ul class="tabs" id="ulGovContractTabs" runat="server">
            <li id="liContractSearch" runat="server" class="tab col l2">
                <asp:LinkButton runat="server" CommandArgument="ContractSearch" OnClick="Redirect"
                    ID="lnkContractSearch" CausesValidation="False">
                    <asp:Label ID="lblContractSearch" runat="server" Text="البحث">
                    </asp:Label>
                </asp:LinkButton>
            </li>
            <li id="liReviewContracts" runat="server" class="tab col l2 m12 s12">
                <asp:LinkButton runat="server" CommandArgument="ContractPendingReviewSearch" OnClick="Redirect"
                    ID="LinkButton2" CausesValidation="False">
                    <asp:Label ID="lblReviewContracts" runat="server" Text="المراجعة"></asp:Label>
                </asp:LinkButton>
            </li>
            <li id="liAddContract" runat="server" class="tab col l3 m12 s12">
                <asp:LinkButton runat="server" CommandArgument="Add" OnClick="Redirect"
                    ID="lnkAddContract" CausesValidation="False">
                    <asp:Label ID="lblAddContract" runat="server" Text="إضافة تأييد بعقد"></asp:Label>
                </asp:LinkButton>
            </li>
            <li id="liAssentAdd" runat="server" class="tab col l3 m12 s12">
                <asp:LinkButton runat="server" CommandArgument="AssentAdd" OnClick="Redirect"
                    ID="LinkButton1" CausesValidation="False">
                    <asp:Label ID="lblAssentAdd" runat="server" Text="إضافة تأييد بدون عقد"></asp:Label>
                </asp:LinkButton>
            </li>
            <li id="liTransferCredit" runat="server" class="tab col l2 m12 s12">
                <asp:LinkButton runat="server" CommandArgument="ContractTransferCredit" OnClick="Redirect"
                    ID="lnkTransferCredit" CausesValidation="False">
                    <asp:Label ID="lblTransferCredit" runat="server" Text="نقل الرصيد">
                    </asp:Label>
                </asp:LinkButton>
            </li>
        </ul>
    </div>
 
</div>
