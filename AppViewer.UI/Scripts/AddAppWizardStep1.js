$(document).ready(function () {
    $('#drpAppType').on('change', function () {
        $('#hdnAppType').val($('#drpAppType option:selected').val());
    });
});

function AddApp() {
    var isValid = true;
    var numRegex = new RegExp("^[0-9]+$");

    if ($('#txtName').val().length == 0) {
        $('#lblName').show();
        isValid = false;
    }
    else {
        $('#lblName').hide();
    }

    if ($('#txtDescription').val().length == 0) {
        $('#lblDescription').show();
        isValid = false;
    }
    else {
        $('#lblDescription').hide();
    }

    if ($('#txtURL').val().length == 0) {
        $('#lblURL').html("Please enter a url for the new app.");
        $('#lblURL').show();
        isValid = false;
    }
    else if ($('#txtURL').val().indexOf(" ") > -1) {
        $('#lblURL').html("URL cannot contain spaces.");
        $('#lblURL').show();
        isValid = false;
    }
    else {
        $('#lblURL').hide();
    }

    if ($('#drpAppType').val() == "-1") {
        $('#lblAppType').show();
        isValid = false;
    }
    else {
        $('#lblAppType').hide();
    }
    return isValid;
}