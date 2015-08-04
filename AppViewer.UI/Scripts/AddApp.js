$(document).ready(function () {

    $('#drpDevices').on('change', function () {
        var device = GetDevice(this.value);
     
        if (device)
        {
            $('#txtDeviceWidth').val(device.Width);
            $('#txtDeviceHeight').val(device.Height);
            $('#txtFull').val(device.FullscreenSize);
        }
    });
});

function GetDevice(DeviceID) {

    var webMethod = "Service/ManagePage.asmx/GetDevice";
    var parameters = "{'deviceID':" + DeviceID + "}";
    var device;

    $.ajax({
        type: "POST",
        async: false,
        url: webMethod,
        data: parameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            device = JSON.parse(data.d);
        },
        error: function (xhr, status, error) {
            device = null;
        }
    });

    return device;
}

function AddApp() {
    var isValid = true;
    var numRegex = new RegExp("^[0-9]+$");

    if ($('#txtAppName').val().length == 0) {
        $('#lblAppName').show();
        isValid = false;
    }
    else {
        $('#lblAppName').hide();
    }

    if ($('#txtAppDescription').val().length == 0) {
        $('#lblAppDescription').show();
        isValid = false;
    }
    else {
        $('#lblAppDescription').hide();
    }

    if ($('#txtAppUrl').val().length == 0) {
        $('#lblAppUrl').html("Please enter a url for the new app.");
        $('#lblAppUrl').show();
        isValid = false;
    }
    else if ($('#txtAppUrl').val().indexOf(" ") > -1) {
        $('#lblAppUrl').html("URL cannot contain spaces.");
        $('#lblAppUrl').show();
        isValid = false;
    }
    else {
        $('#lblAppUrl').hide();
    }
    
    if ($('#txtDeviceWidth').val().length == 0) {
        $('#lblWidth').html("Please enter a valid width or select one above.");
        $('#lblWidth').show();
        isValid = false;
    }
    else if (!numRegex.test($('#txtDeviceWidth').val())) {
        $('#lblWidth').html("Width must be numeric only.");
        $('#lblWidth').show();
        isValid = false;
    }
    else {
        $('#lblWidth').hide();
    }
    
    if ($('#txtDeviceHeight').val().length == 0) {
        $('#lblHeight').html("Please enter a valid height or select one above.");
        $('#lblHeight').show();
        isValid = false;
    }
    else if (!numRegex.test($('#txtDeviceHeight').val())) {
        $('#lblHeight').html("Height must be numeric only.");
        $('#lblHeight').show();
        isValid = false;
    }
    else {
        $('#lblHeight').hide();
    }
    
    if ($('#txtFull').val().length == 0) {
        $('#lblFullscreen').html("Please enter a valid fullscreen size or select one above.");
        $('#lblFullscreen').show();
        isValid = false;
    }
    else if (!numRegex.test($('#txtFull').val())) {
        $('#lblFullscreen').html("Fullscreen size must be numeric only.");
        $('#lblFullscreen').show();
        isValid = false;
    }
    else {
        $('#lblFullscreen').hide();
    }

    return isValid;
}