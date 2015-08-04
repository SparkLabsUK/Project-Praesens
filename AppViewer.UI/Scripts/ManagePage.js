
var _LinkChanged = false;

var lastLinkID;

$(document).ready(function () {
    //$("[id*=btnPopup]").live("click", function () {
    //    $("#dialog").dialog({
    //        title: "Chnages",
    //        width: "900px",
    //        buttons: {
    //            Close: function () {
    //                $(this).dialog('close');
    //            }
    //        },
    //        modal: true
    //    });
    //    return false;
    //});
    $('#lstLinks').change(function () {
        SelectLink(this.value);
    });

    $('#drpTransitionToPage').on('change', function () {
        $('#hdnDrpTranstoPage').val($('#drpTransitionToPage option:selected').val());
        if ($('#hdnSelectedLink').val() != -1) {
            _LinkChanged = true;
        }
    });

    $('#drpTransition').on('change', function () {
        $('#hdnTransition').val($('#drpTransition option:selected').val());
        if ($('#hdnSelectedLink').val() != -1) {
            _LinkChanged = true;
        }
    });

    $('#txtX').on('change', function () {
        if ($('#hdnSelectedLink').val() != -1) {
            $('[id*=LinkDiv' + $('#hdnSelectedLink').val() + ']').css("left", $('#txtX').val() + 'px');
            _LinkChanged = true;
        }
        else if ($('#newLink')) {
            $('#newLink').css("left", $('#txtX').val() + 'px');
        }
    });

    $('#txtY').on('change', function () {
        if ($('#hdnSelectedLink').val() != -1) {
            $('[id*=LinkDiv' + $('#hdnSelectedLink').val() + ']').css("top", $('#txtY').val() + 'px');
            _LinkChanged = true;
        }
        else if ($('#newLink')) {
            $('#newLink').css("top", $('#txtY').val() + 'px');
        }
    });

    $('#txtWidth').on('change', function () {
        if ($('#hdnSelectedLink').val() != -1) {
            $('[id*=LinkDiv' + $('#hdnSelectedLink').val() + ']').css("width", $('#txtWidth').val() + 'px');
            _LinkChanged = true;
        }
        else if ($('#newLink')) {
            $('#newLink').css("width", $('#txtWidth').val() + 'px');
        }
    });

    $('#txtHeight').on('change', function () {
        if ($('#hdnSelectedLink').val() != -1) {
            $('[id*=LinkDiv' + $('#hdnSelectedLink').val() + ']').css("height", $('#txtHeight').val() + 'px');
            _LinkChanged = true;
        }
        else if ($('#newLink')) {
            $('#newLink').css("height", $('#txtHeight').val() + 'px');
        }
    });

    $(".alink").mouseover(function () {
        $(this).stop().animate({ opacity: 0.4 }, 200);
    }).mouseout(function () {
        $(this).stop().animate({ opacity: 0 }, 200);
    });
});

function Opendialog() {
    $(function () {
        $("#dialog").dialog({
            autoOpen: false,
            show: {
                effect: "blind",
                duration: 1000
            },
            hide: {
                effect: "explode",
                duration: 1000
            }
        });

        $("#opener").click(function () {
            $("#dialog").dialog("open");
        });
    });
}

function AddLink() {

    if (_LinkChanged == true) {

        if ($('#hdnSelectedLink').val() != -1) {

            // reset link
            var link = GetLink($('#hdnSelectedLink').val());

            var linkDiv = $('[id*=LinkDiv' + link.LinkID + ']');
            linkDiv.css("left", link.Xcoordinate + 'px');
            linkDiv.css("top", link.Ycoordinate + 'px');
            linkDiv.css("width", link.Width + 'px');
            linkDiv.css("height", link.Height + 'px');
        }
    }

    _LinkChanged = false;

    $('.alinkdiv').css("border-color", "blue");
    $('.alink').css("background-color", "#006EFF");
    $("#lstLinks option").prop("selected", false);
    $('#hdnSelectedLink').val(-1);

    $('#txtX').val('10');
    $('#txtY').val('10');
    $('#txtWidth').val('50');
    $('#txtHeight').val('50');

    
    $("#drpTransitionToPage").prop('selectedIndex', 0);
    $("#drpTransition").prop('selectedIndex', 0);
    $('#hdnDrpTranstoPage').val($('#drpTransitionToPage').val());
    $('#hdnTransition').val($('#drpTransition').val());
    
    var newLinkDiv = $('<div id="newLink"></div>');
    newLinkDiv.attr("style", "display: block; position: absolute; margin: -2px 0 0 -2px; border-width: 2px; border-style: solid; border-color:#00FF00; top: " + $('#txtY').val() + "px; left: " + $('#txtX').val() + "px; width: " + $('#txtWidth').val() + "px; height: " + $('#txtHeight').val() + "px;")

    var newLink = $('<a class="alink"></a>');
    newLink.attr("style", "display: block; width: 100%; height: 100%; background-color: #00FF00; opacity: 0;");
    newLink.mouseover(function () {
        $(this).stop().animate({ opacity: 0.4 }, 200);
    }).mouseout(function () {
        $(this).stop().animate({ opacity: 0 }, 200);
    });

    newLinkDiv.append(newLink);
    $('[id*=imgContainer]').append(newLinkDiv);
}

function PreviewLinkTransition() {
    var PageID = $('#drpTransitionToPage').val();
    var transitionPage = $('<div id="transitionPage"></div>');
    transitionPage.attr("style", "width: 283px; height: 497px; background-image: url(~/GetImage.ashx?Page=" + PageID + "&Size=2); background-size:contain; background-repeat: no-repeat; position: absolute; z-index: 3; top: 497px; left: 300px;");
    $('[id*=imgContainer]').append(transitionPage);
    

}

function SaveLink() {

    if ($('#txtX').val().length == 0 || $('#txtY').val().length == 0 || $('#txtWidth').val().length == 0 || $('#txtHeight').val().length == 0) {
        $('#lblLinkError').show();
        return false;
    }
    else {
        $('#lblLinkError').hide();
        return true;
    }
}

function SelectLink(LinkID) {

    var link;
    var linkEditing = $('[id*=LinkDiv' + LinkID + ']');

    $('.alinkdiv').css("border-color", "blue");
    $('.alink').css("background-color", "#006EFF");

    $(linkEditing).css("border-color", "#00FF00");
    $('#Link' + LinkID).css("background-color", "#00FF00");

    if (!$('#txtX').prop('disabled')) {
        $(linkEditing).draggable({
            containment: "parent",
            drag: function () {
                var leftVal = $(linkEditing).css("left");
                leftVal = leftVal.slice(0, -2);

                var topVal = $(linkEditing).css("top");
                topVal = topVal.slice(0, -2);

                $('#txtX').val(leftVal);
                $('#txtY').val(topVal);

            }
        });
    }

    if ($('#newLink')) {
        $('#newLink').remove();
    }

    if (_LinkChanged == true) {
        if ($('#hdnSelectedLink').val() != -1) {
            // reset link
            link = GetLink($('#hdnSelectedLink').val());

            var linkDiv = $('[id*=LinkDiv' + link.LinkID + ']');
            linkDiv.css("left", link.Xcoordinate + 'px');
            linkDiv.css("top", link.Ycoordinate + 'px');
            linkDiv.css("width", link.Width + 'px');
            linkDiv.css("height", link.Height + 'px');

        }
    }

    _LinkChanged = false;
    $('#hdnSelectedLink').val(LinkID);

    $('#lnkPreviewLinkTransition').disabled = "";
    $('#lnkPreviewLinkTransition').attr('class', 'anchor');
    

    link = GetLink(LinkID);
    if (lastLinkID == LinkID) {
        return;
    }
    else {
        lastLinkID = LinkID;
    }

    if (link != null){
        $('#txtX').val(link.Xcoordinate);
        $('#txtY').val(link.Ycoordinate);
        $('#txtWidth').val(link.Width);
        $('#txtHeight').val(link.Height);
        $('#hdnDrpTranstoPage').val(link.ToPageID);
        $('#drpTransitionToPage').val(link.ToPageID);
        $('#hdnTransition').val(link.TransitionAsInt);
        $('#drpTransition').val(link.TransitionAsInt);
    }
}

function GetLink(LinkID) {
    var webMethod = "Service/ManagePage.asmx/GetLink";
    var parameters = "{'linkID':'" + LinkID + "'}";
    var link;

    $.ajax({
        type: "POST",
        async: false,
        url: webMethod,
        data: parameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            link = JSON.parse(data.d);
        },
        error: function (xhr, status, error) {
            $('.alinkdiv').css("border-color", "blue");
            $('.alink').css("background-color", "#006EFF");
            $("#lstLinks option").prop("selected", false);
            $('#hdnSelectedLink').val(-1);
            link = null;
        }
    });

    return link;
}

function SetThumbPage(PageID, link) {

    if ($(link).text() == 'Current Thumbnail') {
        return;
    }

    var webMethod = "Service/ManagePage.asmx/SetThumbPage";
    var parameters = "{'pageID':'" + PageID + "'}";

    $.ajax({
        type: "POST",
        async: false,
        url: webMethod,
        data: parameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(link).addClass("aspNetDisabled").attr("disabled", "disabled").text('Current Thumbnail');
        },
        error: function (xhr, status, error) {
            
        }
    });
}

function SetFirstPage(PageID, link) {

    if ($(link).text() == 'Current First Page') {
        return;
    }

    var webMethod = "Service/ManagePage.asmx/SetFirstPage";
    var parameters = "{'pageID':'" + PageID + "'}";

    $.ajax({
        type: "POST",
        async: false,
        url: webMethod,
        data: parameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $(link).addClass("aspNetDisabled").attr("disabled", "disabled").text('Current First Page');
        },
        error: function (xhr, status, error) {

        }
    });
}
