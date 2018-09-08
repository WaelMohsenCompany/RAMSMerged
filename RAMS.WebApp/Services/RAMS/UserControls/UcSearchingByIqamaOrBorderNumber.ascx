<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcSearchingByIqamaOrBorderNumber.ascx.cs"
    Inherits="RAMS.WebApp.Services.RAMS.UserControls.UcSearchingByIqamaOrBorderNumber" %>
<div id="laborDiv" runat="server">

    <div class="row">
        <div class="col s12 m1 l1"></div>
        <div class="col s12 m4 l4">
            <asp:RadioButtonList runat="server" ID="laborerRadioButtonList" AutoPostBack="True" RepeatDirection="Horizontal" CellPadding="100"
                OnSelectedIndexChanged="LaborerRadioButtonList_SelectedIndexChanged">
                <asp:ListItem Text="رقم الهوية" Value="IqamaNumber" Selected="True" />
                <asp:ListItem Text="رقم الحدود" Value="BorderNumber" />
            </asp:RadioButtonList>
        </div>
    </div>

    <div class="row" id="iqamaNumberDiv" runat="server">
        <div class="col s12 m1 l1"></div>
        <div class="col s12 m2 l2">
            <div class="input-field">
                <asp:TextBox ID="iqamaNumberTextBox" CssClass="validate" pattern="(.){10,10}" MaxLength="10"
                    ValidationGroup="save" ClientIDMode="Static" runat="server"></asp:TextBox>
                <label for="<%= iqamaNumberTextBox.ClientID %>">رقم هوية العامل</label>
            </div>
        </div>

        <div class="col s12 m2 l4">
            <div class="alert-validation">
                <asp:RegularExpressionValidator Display="Dynamic" ValidationGroup="save"
                    ID="iqamaNumberRegValidator" ControlToValidate="iqamaNumberTextBox" ValidationExpression="^[\s\S]{10,}$"
                    runat="server">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator ID="iqamaNumberCustomValidator" runat="server"
                    OnServerValidate="ValidateIqamaNumber_ServerValidate"
                    ControlToValidate="iqamaNumberTextBox" Display="Dynamic" ValidationGroup="save"
                    ErrorMessage="عفوا عزيزي العميل، رقم الهوية الذي تم إدخاله غير صحيح.">
                </asp:CustomValidator>
                <div class="alert-validation">
                    <asp:Label ID="iqamaNumberEmptyLabel" Style="display: none" runat="server"
                        ClientIDMode="Static" Text="عفوا عزيزي المستخدم، لابد من ادخال رقم الهوية">                                            
                    </asp:Label>
                    <asp:Label ID="iqamaNumbererrorNumberLabel" Style="display: none" runat="server"
                        ClientIDMode="Static"
                        Text="رقم هوية العامل المدخل غير صحيح">                                             
                    </asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="row" id="borderNumberDiv" runat="server" visible="False">
        <div class="col s12 m1 l1"></div>
        <div class="col s12 m2 l2">
            <div class="input-field">
                <asp:TextBox ID="bounderyNumberTextBox" CssClass="validate" pattern="(.){10,10}"
                    MaxLength="10"
                    ClientIDMode="Static" runat="server" ValidationGroup="save"></asp:TextBox>
                <label for="<%= bounderyNumberTextBox.ClientID %>">رقم الحدود </label>
            </div>
        </div>
        <div class="col s12 m2 l4">
            <div class="alert-validation">
                <asp:RegularExpressionValidator ValidationGroup="save" Display="Dynamic"
                    ID="bounderyNumberRegularExpressionValidator"
                    ControlToValidate="bounderyNumberTextBox" ValidationExpression="^[\s\S]{10,}$" runat="server">
                </asp:RegularExpressionValidator>
                <asp:CustomValidator ID="bounderyNumberCustomValidator" runat="server" ValidationGroup="save"
                    OnServerValidate="validateBoundaryNumber_ServerValidate" ControlToValidate="bounderyNumberTextBox"
                    Display="Dynamic"
                    ErrorMessage="عفوا عزيزي العميل، رقم الحدود الذي تم إدخاله غير صحيح">
                </asp:CustomValidator>
                <div class="alert-validation">
                    <asp:Label ID="bounderyNumberEmptyLabel" Style="display: none" runat="server"
                        ClientIDMode="Static" Text="عفوا عزيزي المستخدم، لابد من ادخال رقم الحدود">                                            
                    </asp:Label>
                    <asp:Label ID="bounderyNumberErrorLabel" Style="display: none" runat="server" ClientIDMode="Static"
                        Text="رقم الحدود الخاص بالعامل غير صحيح">                                             
                    </asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m1 l1"></div>
        <div class="col s12 m2 l2">
            <asp:Button ID="searchrunawayButton" runat="server" Text="بحث" ValidationGroup="save"
                CssClass="btn" OnClick="SearchRunAwayButton_Click"
                CausesValidation="true" OnClientClick="return !checkEmpty();" />
        </div>
    </div>
</div>
<script>

    function checkEmpty() {
        $('#<%= iqamaNumberEmptyLabel.ClientID %>').hide();
        $('#<%= bounderyNumberEmptyLabel.ClientID %>').hide();
        var txtLimitsNum = $("input[id*='bounderyNumberTextBox']").val();
        var txtResidenceNum = $("input[id*='iqamaNumberTextBox']").val();
        if ((txtLimitsNum == null || txtLimitsNum == "")
            && (txtResidenceNum == null || txtResidenceNum == "")) {
            $('#<%= iqamaNumberEmptyLabel.ClientID %>').show();
            $('#<%= bounderyNumberEmptyLabel.ClientID %>').show();
            return true;
        }
        else {
            $('#<%= iqamaNumberEmptyLabel.ClientID %>').hide();
            $('#<%= bounderyNumberEmptyLabel.ClientID %>').hide();

            //check if data entered not valid 
            if (txtLimitsNum != null && txtLimitsNum != "") {
                var check = isBorderNumberValid(txtLimitsNum);
                if (!check) {
                    $('#<%= bounderyNumberErrorLabel.ClientID %>').show();
                    $('#<%= iqamaNumbererrorNumberLabel.ClientID %>').hide();
                    return true;
                }
            }
            if (txtResidenceNum != null && txtResidenceNum != "") {
                var checkIqama = isIdNumberValid(txtResidenceNum);
                if (!checkIqama) {
                    $('#<%= iqamaNumbererrorNumberLabel.ClientID %>').show();
                    $('#<%= bounderyNumberErrorLabel.ClientID %>').hide();
                    return true;
                }
            }
        }
        return false;
    }
</script>
