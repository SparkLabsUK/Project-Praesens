function AddPage() {
    if ($('#txtPageName').val().length == 0) {
        $('#lblPageName').show();
    }
    else {
        $('#lblPageName').hide();
    }
    return (
           $('#txtPageName').val().length > 0);
}
