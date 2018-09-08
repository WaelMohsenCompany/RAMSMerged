<%@ control language="C#" autoeventwireup="true" codebehind="SMSConfirmation.ascx.cs" inherits="Mol.Web.Common.UI.UserControls.SMSConfirmation" %>
<script src="/javascript/aspDIalogPlugin.js" language="javascript" type="text/javascript"></script>
<script type="text/javascript">
    //$(document).ready(function () {
    //    $("#divSMSConfirmationContainer").dialog({
    //        autoOpen: false,
    //        height: 250,
    //        width: 400,
    //        modal: false,
    //        open: function (type, data) {
    //            $("#divSMSConfirmationContainer").parent().appendTo($("form:first"));
    //        }
    //    });
    //});

    function ShowSMSConfirmation() {
       // $("#divSMSConfirmationForm").show();
        $("#divSMSConfirmationForm").openModal($(document).ready());
       // $.blockUI({
        //    message: $('#divSMSConfirmationForm'),
         //   css: {
        //        width: '370px',
                //left:'15%',
                //top:'15%',
        //    }
       // });

       // $('#divSMSConfirmationForm').parent().appendTo('form:first');
        //$('.blockOverlay').attr('title','Click to unblock').click($.unblockUI);
        //$('#closeLnk1').click(function(){
        //    $.unblockUI();
    }

    function CloseSMSConfirmationDialog() {
        $('#lean-overlay').hide();
        $("#divSMSConfirmationForm").hide();
        $.unblockUI();
    }
  

<%--$( document ).ready(function() {
  var txt='#<%= txtMobileCode.ClientID %>';
    var btn='#<%= btnSubmit.ClientID %>';
    $(txt).onkeypress(function(e) {
            alert(txt);
        $('#'+btn).focus();
    });
});--%>

</script>
<style>
    .SMSConfirmationStyle {
        background-color: #dcd9d6;
        padding-top: 10px;
        padding-left: 5px;
        padding-right: 5px;
    }
</style>

    <div id="divSMSConfirmationForm" style="display: none;" class="modal" >
      <div id="divSMSError" runat="server" class="alert alert-border-right" visible="false">
                
                <asp:literal id="ltrSMSError" runat="server"></asp:literal>
                                
            </div>
            <div class="row">
                <div class="col s12 l12 m12">
                    <div class="label-new">
                برجاء إدخال كود التحقق المرسل لجوالك المسجل بنظام -أبشر- في وزارة الداخلية:
                <%--<asp:Literal ID="ltrMobileNumber" runat="server"></asp:Literal>--%>
                    </div>
                </div>
            </div>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
       
          
                <div class="row">
                    <div class="col s12 m12 l6">
                       <div class="input-field">
                            <asp:textbox id="txtMobileCode" runat="server" maxlength="6"  />
                                   <label for="<%=txtMobileCode.ClientID %>"> كود التحقق</label>
                     </div>
                       
                   </div>
                </div>

                <div class="row">
            <div class="col s12 m12 l6">
                <div class="alert-validation">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ErrorMessage="حقل إلزامي" ControlToValidate="txtMobileCode"
                        runat="server" ValidationGroup="SMSConfirmationValidationGroup" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                        ErrorMessage="رقم غير صالح" ControlToValidate="txtMobileCode" ValidationGroup="SMSConfirmationValidationGroup"
                        ValidationExpression="^\d+$"></asp:RegularExpressionValidator>

                </div>
            </div>
        </div>


                <div class="row">
                    <div class="col s12 m12 l12">
                        <asp:linkbutton runat="server" onclick="btnResendSMS_Click" id="btnResendSMS">إعادة ارسال</asp:linkbutton>
                    </div>
                </div>

                <div class="row">
                    <div class="col s12 m12 l12">
                        <a onclick=" return OpenMoiHelp();" style="cursor: pointer;">للاطلاع على طريقة التسجيل في نظام -أبشر- وزارة الداخلية
                        </a>
                        
                    </div>
                </div>
         
                <div class="row">
                    <div class="col s12 m12 l12">
                        <asp:button id="btnSubmit" cssclass="btn margin-b-10" runat="server" validationgroup="SMSConfirmationValidationGroup" onclick="btnSubmit_Click" Text="إرسال" UseSubmitBehavior="false"/>
                       <a href="#" id="closeLnk1" onclick="CloseSMSConfirmationDialog();" class="btn">إغلاق</a>
                      </div>

    </div>
            </asp:Panel>
</div>
<script type="text/javascript">
    function OpenMoiHelp() {      
      
        var myWindow = window.open('http://www.moi.gov.sa/wps/portal/!ut/p/b1/04_Sj9Q1MbA0MTIysNCP0I_KSyzLTE8syczPS8wB8aPM4k2dA5w9LXyNDd0DQs0NjNzMTbyczbwtDLxNgAoigQoMcABHA0L6gxOL9MP1o_AqMzGGKnB2d_QwMfcxMLDwcTc18HT0CA2yDDQ2NnCEKcDjDj-P_NxU_dyoHItgT11HAKpK2Ek!/dl4/d5/L2dJQSEvUUt3QS80SmtFL1o2X0dOVlMzR0gzMTBGSUUwSVFJSkozR1YzQ0w2/?WCM_GLOBAL_CONTEXT=/wps/wcm/connect/general/help+ar/registration+and+activation/hlp_portal_+help_registration_activation_default_ar', 'MOIHelp');
        return false;
    }
</script>

