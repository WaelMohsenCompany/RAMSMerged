
function isIdNumberValid(idNo) {
    if (idNo.length != 10 || parseInt(idNo[0]) != 2)
        return false;
    var i;
    var temp;
    var checkSum = 0;
    var charIdNo;
    for (i = 0; i < idNo.length - 1; i++) {
        charIdNo = idNo.substring(i, i + 1);
        if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8) {
            temp = (parseInt(charIdNo) * 2).toString();
            var j;
            for (j = 0; j < temp.length; j++)
                checkSum += parseInt(temp.substring(j, j + 1));
        }
        else
            checkSum += parseInt(charIdNo);
    }
    var strCheckSum = checkSum.toString();
    var checkSumLastDigit = parseInt(strCheckSum.substring(strCheckSum.length - 1, strCheckSum.length));
    var idNumberLastDigit = parseInt(idNo.substring(idNo.length - 1, idNo.length));
    if (checkSumLastDigit == idNumberLastDigit || (idNumberLastDigit == (10 - checkSumLastDigit)))
        return true;
    else
        return false;
}

function isBorderNumberValid(borderNo) {
    if (borderNo.length != 10 || parseInt(borderNo[0]) < 3) return false;
    var i;
    var temp;
    var checkSum = 0;
    var charIdNo;
    for (i = 0; i < borderNo.length - 1; i++) {
        charIdNo = borderNo.substring(i, i + 1);
        if (i == 0 || i == 2 || i == 4 || i == 6 || i == 8) {
            temp = (parseInt(charIdNo) * 2).toString();
            var j;
            for (j = 0; j < temp.length; j++)
                checkSum += parseInt(temp.substring(j, j + 1));
        }
        else
            checkSum += parseInt(charIdNo);
    }
    var strCheckSum = checkSum.toString();
    var checkSumLastDigit = parseInt(strCheckSum.substring(strCheckSum.length - 1, strCheckSum.length));
    var idNumberLastDigit = parseInt(borderNo.substring(borderNo.length - 1, borderNo.length));
    if (checkSumLastDigit == idNumberLastDigit || (idNumberLastDigit == (10 - checkSumLastDigit)))
        return true;
    else
        return false;
}

function CheckFileUploadValidation(fileUploadElement, maxSize, maxCount, currentCount, minFilesSize) {
    if (fileUploadElement.value != '') {
        var fileExtension = ['pdf', 'doc', 'docx', 'ppt', 'pptx', 'txt', 'xls', 'xlsx', "png", 'jpg', 'jpeg'];
        if ($.inArray(fileUploadElement.value.split('.').pop().toLowerCase(), fileExtension) === -1) {

            $('#FileUploadValidationError').html("صيغة ملف الأوراق الثبوتية الذي تم رفعه غير سليمة، برجاء إعادة رفع الملف بصيغة قياسية.");
            $('#FileUploadValidationError').css('display', 'block');
            $('#fileupload_inputText').value = '';
            fileUploadElement.value = '';
            return false;
        }
        else {

            var iSize = (fileUploadElement.files[0].size / 1024);
            iSize = (Math.round((iSize / 1024) * 100) / 100);
            if (iSize > maxSize || iSize <= 0.1) {
                $('#FileUploadValidationError').html("يجب أن يكون حجم الملف بين " + minFilesSize + "KB " + "إلى " + maxSize + "MB");
                $('#FileUploadValidationError').css('display', 'block');
                $('#fileupload_inputText').value = '';
                fileUploadElement.value = '';
                return false;
            }
            else {
                if (currentCount == maxCount) {
                    $('#FileUploadValidationError').html("لا يسمح بعدد أكثر من " + maxCount + " ملفات");
                    $('#FileUploadValidationError').css('display', 'block');
                    $('#fileupload_inputText').value = '';
                    fileUploadElement.value = '';
                    return false;
                } else {
                    $('#FileUploadValidationError').html('');
                    $('#FileUploadValidationError').css('display', 'none');
                }
            }
        }
    }
    else {

        $('#FileUploadValidationError').html("عفوا، يجب إرفاق نسخة إلكترونية من المستندات المطلوبة.");
        $('#FileUploadValidationError').css('display', 'block');
        fileUploadElement.value = '';
        return false;
    }
    return true;
}
