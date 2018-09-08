<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingWebForm.aspx.cs" Inherits="RAMS.SOA.Tester.TestingWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListBox ID="resultsList" runat="server" BackColor="#80FF00" Height="147px" Width="903px" Font-Size="Medium"></asp:ListBox>
        <asp:Button ID="ButtonClear" runat="server" OnClick="ButtonClear_Click" Text="Clear" />
        <br />
        <br />
        <asp:Button ID="CheckCreateRunAwayLaborerBusinessRules" runat="server" OnClick="CheckCreateRunAwayLaborerBusinessRules_Click" Text="CheckCreateRunAwayLaborerBusinessRules" Width="288px" BackColor="#660066" Font-Bold="True" ForeColor="White" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CheckCreateRunAwayEstablishmentBusinessRules" runat="server" BackColor="#660066" Font-Bold="True" ForeColor="White" OnClick="CheckCreateRunAwayEstablishmentBusinessRules_Click" Text="CheckCreateRunAwayEstablishmentBusinessRules" Width="343px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <br />
        <br />
        <asp:Button ID="GetRunAwayRequest" runat="server" BackColor="#660066" Font-Bold="True" ForeColor="White" OnClick="GetRunAwayRequest_Click" Text="GetRunAwayRequest" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="GetAllRunAwayRequestsList" runat="server" BackColor="#660066" Font-Bold="True" ForeColor="White" OnClick="GetAllRunAwayRequestsList_Click" Text="GetAllRunAwayRequestsList" />
        <br />
        <br />
        <asp:Button ID="GetLatestRunAwayOrComplaintRequest" runat="server" BackColor="#660066" Font-Bold="True" ForeColor="White" OnClick="GetLatestRunAwayOrComplaintRequest_Click" Text="GetLatestRunAwayOrComplaintRequest" />
        <br />
        <br />
        <asp:Button ID="GetForApprovalRunAwayRequestsList" runat="server" BackColor="#660066" Font-Bold="True" ForeColor="White" Text="GetForApprovalRunAwayRequestsList" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#FFFFCC" Width="33px">1</asp:TextBox>
&nbsp;<asp:Button ID="ButtonGetRegionLaborerOfficeList" runat="server" OnClick="ButtonGetRegionLaborerOfficeList_Click" Text="GetRegionLaborerOfficeList" Width="182px" />
        <br />
        <br />
        <asp:Button ID="GetForReviewRunAwayRequestsList" runat="server" BackColor="#660066" Font-Bold="True" ForeColor="White" OnClick="GetForReviewRunAwayRequestsList_Click" Text="GetForReviewRunAwayRequestsList" />
        <br />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="New File Name:                         --                                     "></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_FileUpload" runat="server" Text="FileUpload" OnClick="btn_FileUpload_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="DownloadFile" runat="server" Text="Download File" OnClick="DownloadFile_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" Text="Check Parameters" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="IsLaborerHasCase" runat="server" OnClick="IsLaborerHasCase_Click" Text="IsLaborerHasCase" />
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Button ID="ButCreateRunAwayRequest" runat="server" Text="CreateRunAwayRequest" OnClick="ButCreateRunAwayRequest_Click" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Delete Runaway Request" />
    
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonCreateRunAwayComplaintRequest" runat="server" OnClick="ButtonCreateRunAwayComplaintRequest_Click" Text="CreateRunAwayComplaintRequest" />
    
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button11" runat="server" Text="على رأس العمل" Width="106px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        <asp:TextBox ID="TextBoxStatus" runat="server" BackColor="#FFFF66" Font-Bold="True" Font-Size="14pt" Width="73px">1</asp:TextBox>
        &nbsp;
        <asp:Button ID="ButtonGetForApprovalRunAwayRequestsList" runat="server" OnClick="ButtonGetForApprovalRunAwayRequestsList_Click" Text="GetForApprovalRunAwayRequestsList" Width="238px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButtonReview" runat="server" Text="Review" />
&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButtonAccept" runat="server" Text="Accept" />
&nbsp;<asp:RadioButton ID="RadioButtonReject" runat="server" Text="Reject" />
&nbsp;&nbsp;
        <asp:Button ID="ButtonUpdateRunAwayComplaintStatus" runat="server" OnClick="ButtonUpdateRunAwayComplaintStatus_Click" Text="UpdateRunAwayComplaintStatus" Width="212px" />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="ButtonGetForReviewRunAwayRequestsList" runat="server" OnClick="ButtonGetForReviewRunAwayRequestsList_Click" Text="GetForReviewRunAwayRequestsList" Width="245px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonUpdateComplaintRequestByReviewAppointment" runat="server" OnClick="ButtonUpdateComplaintRequestByReviewAppointment_Click" Text="UpdateComplaintRequestByReviewAppointment" Width="291px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonUpdateComplaintRequestByReviewResults" runat="server" Text="UpdateComplaintRequestByReviewResults" Width="259px" OnClick="ButtonUpdateComplaintRequestByReviewResults_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBoxContinue" runat="server" Text="Continue" />
&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBoxClose" runat="server" Text="Close" />
        <br />
        <asp:Button ID="ButtonSecureString" runat="server" OnClick="ButtonSecureString_Click" Text="Secure String" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonSearchNotes" runat="server" OnClick="ButtonSearchNotes_Click" Text="SearchNotes" />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
