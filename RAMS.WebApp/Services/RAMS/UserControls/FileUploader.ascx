<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUploader.ascx.cs" Inherits="RAMS.WebApp.Services.RAMS.UserControls.FileUploader" %>

<div id="InputFileUpload_div" dir="rtl">
    <%--class="file-field input-field"--%>
    <%--<input class="file-path validate" type="text" id="fileupload_inputText" />--%>

    <label for="fileupload_inputText" id="FileUploader_Label" runat="server" />
    <div>
        <%--class="btn"--%>
        <span>رفع ملف </span>
        <asp:FileUpload runat="server" ID="ElectronicsFileUpload" ClientIDMode="Static" />
    </div>
</div>
<div class="alert-validation">

    <span id="FileUploadValidationError" class="parsley-errors-list filled" style="display: none; color: #FF0000"></span>
    <span id="FileUploadCustomError" runat="server" class="parsley-errors-list filled" style="display: none; color: #FF0000"></span>

</div>

<script type="text/javascript">

    $(document).ready(function () {
        $('#ElectronicsFileUpload').change(function () {
            CheckFileUploadValidation();
        });
    });

    function CheckFileUploadValidation() {


        var fileUploadElement = $('#ElectronicsFileUpload');


        if (fileUploadElement.val() != '') {
            var fileExtension = ['pdf'];
            if ($.inArray(fileUploadElement.val().split('.').pop().toLowerCase(), fileExtension) == -1) {

                $('#FileUploadValidationError').html("صيغة ملف الأوراق الثبوتية الذي تم رفعه غير سليمة، برجاء إعادة رفع الملف بصيغة PDF قياسية.");
                $('#FileUploadValidationError').css('display', 'block');
                $('#fileupload_inputText').val('');
                fileUploadElement.val('');
                return false;
            }
            else {

                var iSize = (fileUploadElement[0].files[0].size / 1024);


                iSize = (Math.round((iSize / 1024) * 100) / 100);


                if (iSize > 5.0 || iSize <= 0.1) {
                    alert(iSize + " MB");

                    $('#FileUploadValidationError').html("يجب ان يكون حجم الملف بين (5MB - 100KB).");
                    $('#FileUploadValidationError').css('display', 'block');
                    $('#fileupload_inputText').val('');
                    fileUploadElement.val('');
                    return false;
                }
                else {

                    $('#FileUploadValidationError').html('');
                    $('#FileUploadValidationError').css('display', 'none');
                }
            }
        }
        else {

            $('#FileUploadValidationError').html("عفوا، يجب إرفاق نسخة إلكترونية من المستندات المطلوبة.");
            $('#FileUploadValidationError').css('display', 'block');
            fileUploadElement.val('');
            return false;

        }


        return true;


    }





</script>
