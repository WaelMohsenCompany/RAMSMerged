// call this function on input key press
function NumbersOnly(e) {

    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        e.preventDefault();
        return false;
    } else
        return true;
}
function FixInputsOverLabbing() {

    $('input[type=text]', '.input-field').each(function () {
        if ($(this).val() != '') {


            $('label[for="' + this.id + '"]').addClass("active");

            $(this).addClass("validate valid");

        }

    });

}

function setYearsNumricFields() {

    $('#yearTextBox').keypress(function (e) {
        NumbersOnly(e);
    });
}

function setLaborerOfficeNumricFields() {

    $('#laborerOfficeTextBox').keypress(function (e) {
        NumbersOnly(e);
    });
}

function setSerialNumberNumricFields() {

    $('#SerialNumberTextBox').keypress(function (e) {
        NumbersOnly(e);
    });
}



function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}




$(document).ready(function () {
    $('input[type=text], textarea').each(function () {

        if ($(this).attr('data-maxChar') != null) {
            var maxChar = $(this).attr('data-maxChar'),
                               current_val = $(this).val();

            if (current_val.length > maxChar) {
                current_val = current_val.substr(0, maxChar);
                $(this).val(current_val);

            }
            $(this).keyup(function (e) {

                var maxChar = $(this).attr('data-maxChar'),
                    current_val = $(this).val();

                if (current_val.length > maxChar) {
                    current_val = current_val.substr(0, maxChar);
                    $(this).val(current_val);
                    e.preventDefault();
                }
            });
        }


    });


    $('input[type=text]').on("copy", function (e) {

        e.preventDefault();
    });
});



