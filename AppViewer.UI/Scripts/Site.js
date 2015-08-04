$(document).ready(function () {

    $(".buttonlogin").mouseover(function () {
        $(this).stop().animate({ backgroundColor: '#0078BD' }, 200);
    }).mouseout(function () {
        $(this).stop().animate({ backgroundColor: '#0066a1' }, 200);
    });
});

//    $.mobile.ajaxEnabled = false;
//    $.mobile.loading().hide();
//});