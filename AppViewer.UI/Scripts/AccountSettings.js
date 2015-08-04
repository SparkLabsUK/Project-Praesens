function ChangePassword() {

    var isValid = true;

    if ($('#txtOldPass').val().length == 0) {
        $('#lblOldPass').show();
        isValid = false;
    }
    else {
        $('#lblOldPass').hide();
    }

    if ($('#txtNewPass').val().length == 0) {
        $('#lblNewPass').show();
        isValid = false;
    }
    else {
        $('#lblNewPass').hide();
    }

    if ($('#txtConfirmPass').val() != $('#txtNewPass').val()) {
        $('#lblConfirmPass').show();
        isValid = false;
    }
    else {
        $('#lblConfirmPass').hide();
    }

    return isValid;
}