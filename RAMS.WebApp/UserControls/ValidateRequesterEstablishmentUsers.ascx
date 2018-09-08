<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ValidateRequesterEstablishmentUsers.ascx.cs" Inherits="Mol.Web.Common.UI.UserControls.ValidateRequesterEstablishmentUsers" %>

<script>
    function ValidateEstInfo() {
        if ((document.getElementById('<%=txtEstSequenceNo.ClientID %>').value == "") || (document.getElementById('<%=txtReuesterIdNo.ClientID %>').value == "")) {
            $('#divClientError').show();
            $('#divClientError').html('برجاء إدخال بيانات البحث');
            return false;
        }
        else {
            return true;
        }
    }

    function validateNumber(event) {
        var key = window.event ? event.keyCode : event.which;

        if (event.keyCode == 8 || event.keyCode == 46
     || event.keyCode == 37 || event.keyCode == 39) {
            return true;
        }
        else if (key < 48 || key > 57) {
            return false;
        }
        else return true;
    }



</script>
<div class="alert alert-border-right" id="divClientError" style="display:none;"></div>
<div class="row">
    <div class="col s12 m12 l12">
<div class="card">
    <div id="divError" runat="server" visible="false" class="alert alert-border-right">
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </div>
    <div class="title">
        <h5>
        التحقق من بيانات ممثل المنشأة</h5>
    </div>
    <div class="content">
        <div class="row">
            <div class="col s12 m3 l2 label-new">
                <asp:Label ID="lblEstablishmentNumber" runat="server" Text="رقم المنشأة :" /><em class="required-star">*</em>
            </div>
            <div class="col s12 m9 l2 relative width-80-on-large">
                <asp:DropDownList runat="server" ID="ddlLabOffice" Visible="false" />
                <asp:TextBox ID="txtEstOfficeId" runat="server" MaxLength="2"></asp:TextBox>
                <div class="dash-style hide-on-med-and-down">-</div>
            </div>
            <div class="col s12 m9 l2 offset-m3">
                <asp:TextBox ID="txtEstSequenceNo" runat="server" MaxLength="7"></asp:TextBox>
            </div>
            <div class="col s12 m3 l2 label-new center right-on-med-and-down">
                <asp:Label ID="lblRequester" runat="server" Text="رقم بطاقة طالب الخدمة:" /><em class="required-star">*</em>
            </div>
            <div class="col s12 m9 l3 ">
                <asp:TextBox ID="txtReuesterIdNo" runat="server" MaxLength="10"></asp:TextBox>
            </div>
                <div class="col s12 m9 l1 offset-m3">
                <asp:Image ID="imgStatus" runat="server" ImageUrl="~/Services/UserControls/UI/Images/AR/Icons/wrong.jpg"
                    Visible="false" Width="20px" Height="20px" />
                </div>
        </div>
        <div class="row">
            <div class="col s12 m12 l12">
                <asp:Button ID="btnValidate" runat="server" Text="تحقق" OnClientClick="return ValidateEstInfo();"
                    OnClick="btnValidate_Click" CssClass="btn " />
                <asp:Button ID="btnCancelValidation" runat="server" Text="إلغاء التحقق" CssClass="btn "
                    OnClick="btnCancelValidation_Click" Visible="false" />
            </div>
        </div>
    </div>
</div>
    </div>
</div>
<div class="row" runat="server" id="establishmnetRepInfo" visible="false">
    <div class="col s12 m12 l12">
    <div class="card">
    <div class="title"><h5>
        بيانات ممثل المنشأه</h5>
    </div>
    <div class="content">
        <div class="row">
            <div class="col s12 m12 l4 label-new">
                <asp:Label ID="lblEstName" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            <div class="col s12 m12 l4 label-new">
                <asp:Label ID="lblReuesterName" runat="server" Text="" Visible="false"></asp:Label>
            <div class="alert-validation">
                <asp:Label ID="lblEstInfoNotValid" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            </div>
        </div>
    </div>
    </div>
    </div>
</div>

