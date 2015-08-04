$(document).ready(function () {

    if (screen.width <= _app.FullscreenSize) {
        $('head').append('<meta id="viewport" name="viewport" content="width=' + _app.ImgWidth + ', user-scalable=0">');
    }
    else {
        $('head').append('<meta id="viewport" name="viewport" content="width=device-width, initial-scale=1">');
    }

    $(window).resize(function () {
        if (screen.width <= _app.FullscreenSize) {
            $("#viewport").attr("content", "width=" + _app.ImgWidth + ", user-scalable=0");
        }
        else {
            $("#viewport").attr("content", "width=device-width, initial-scale=1");
        }
    });

    $("#chkShowLinks").on('change', function () {
        if ($('#chkShowLinks').is(':checked')) {
            $('.alink').css("border", "1px solid #" + _app.LinkColour);
        }
        else {
            $('.alink').css("border", "none");
        }
    });

});

function doTransition(callingPageDivID, toPageID, transitionType) {

    // show overlay div
    showOverlay();

    var callingPageDiv = $('#' + callingPageDivID);
    var newPageDiv = $('#Page' + toPageID);
    callingPageDiv.css("z-index", 1);
    newPageDiv.css("z-index", 2);
    switch (transitionType) {
        case 1: // slide from left
            newPageDiv.css("left", "0px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 2: // slide from right
            newPageDiv.css("left", (_app.ImgWidth * 2) + "px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 3: // slide from top
            newPageDiv.css("top", "0px");
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            newPageDiv.animate({ top: _app.ImgHeight + "px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 4: //slide from bottom
            newPageDiv.css("top", (_app.ImgHeight * 2) + "px");
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            newPageDiv.animate({ top: _app.ImgHeight + "px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 5: // appear
            newPageDiv.css("top", _app.ImgHeight + "px");
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            resetPageDiv(callingPageDiv);
            break;
        case 6: //fade in
        default:
            newPageDiv.css("top", _app.ImgHeight + "px");
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.fadeIn("slow", function () { resetPageDiv(callingPageDiv); })
            break;
        case 7: // Push from left
            newPageDiv.css("left", "0px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px", queue: false }, function () { });
            callingPageDiv.animate({ left: (_app.ImgWidth * 2) + "px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 8: // Push from right
            newPageDiv.css("left", (_app.ImgWidth * 2) + "px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px", queue: false }, function () { });
            callingPageDiv.animate({ left: "0px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 9: // Push Segue Right
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", ((_app.ImgWidth * 3) / 2) + "px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px", queue: false, duration: 'slow' }, function () { });
            callingPageDiv.animate({ left: "0px", queue: false }, function () { resetPageDiv(callingPageDiv); })

            break;
        case 10: // Push Segue Left
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", ((_app.ImgWidth / 3) * 2) + "px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px", queue: false, duration: 'slow' }, function () { });
            callingPageDiv.animate({ left: (_app.ImgWidth * 2) + "px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 11: //Push from top
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.css("top", "0px");
            newPageDiv.show();
            newPageDiv.animate({ top: _app.ImgHeight + "px", queue: false }, function () { });
            callingPageDiv.animate({ top: (_app.ImgHeight * 2) + "px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 12: //Push from bottom
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.css("top", (_app.ImgHeight * 2) + "px");
            newPageDiv.show();
            newPageDiv.animate({ top: _app.ImgHeight + "px", queue: false }, function () { });
            callingPageDiv.animate({ top: "0px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 13: //slide to left
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            callingPageDiv.animate({ left: "0px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 14: //slide to right
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            callingPageDiv.animate({ left: (_app.ImgWidth * 2) + "px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 15: //slide to top
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            callingPageDiv.animate({ top: "0px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 16: //slide to bottom
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.show();
            callingPageDiv.animate({ top: (_app.ImgHeight * 2) + "px" }, 1000, function () { resetPageDiv(callingPageDiv); })
            break;
        case 17: //slide menu left
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", (_app.ImgWidth / 3) + "px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px", queue: false }, function () { });
            callingPageDiv.animate({ left: (_app.ImgWidth * 2) + "px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 18: //slide menu back right
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", ((_app.ImgWidth / 3) * 2) + "px");
            newPageDiv.show();
            newPageDiv.animate({ left: _app.ImgWidth + "px", queue: false }, function () { });
            callingPageDiv.animate({ left: "0px", queue: false }, function () { resetPageDiv(callingPageDiv); })
            break;
        case 19: //flip
            callingPageDiv.css("z-index", 2);
            newPageDiv.css("z-index", 1);
            newPageDiv.css("left", _app.ImgWidth + "px");
            newPageDiv.css("top", _app.ImgHeight + "px");
            newPageDiv.show();
            $.when(callingPageDiv.animate({ borderSpacing: -90 }, {
                step: function (now, fx) {
                    $(this).css('transform', 'rotateY(' + now + 'deg)');
                },
                duration: 'slow'
            })).done(function () { $(this).css('transform', 'rotateY(0deg)'); resetPageDiv(callingPageDiv); })
            break;
    }

    $("hdnPageID").val = toPageID;
}


function resetPageDiv(callingPageDiv) {
    callingPageDiv.hide();
    callingPageDiv.css("left", (_app.ImgWidth * 2) + "px");
    callingPageDiv.css("z-index", 1);
    hideOverlay();
}

function showOverlay() {
    var overlayDiv = $('#OverlayDiv');
    overlayDiv.css("left", _app.ImgWidth + "px");
    overlayDiv.show();
}

function hideOverlay() {
    var overlayDiv = $('#OverlayDiv');
    overlayDiv.css("left", (_app.ImgWidth * 2) + "px")
    overlayDiv.hide();
}

function setPageNotes(pageID) {
    for (var i = 0, len = arrPageNotes.length; i < len; i++) {
        if (arrPageNotes[i].ID == pageID) {
            $('#txtPageNotes').val(arrPageNotes[i].Note);
            return;
        }
        //else {
        //    hidePageNotes();
        //}
    }
    $('#txtPageNotes').val('');
}