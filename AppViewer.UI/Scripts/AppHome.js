$(document).ready(function () {
    $(".appSelector").mouseover(function () {
        $(this).stop().animate({ backgroundColor: '#E0F4FF' }, 200);
    }).mouseout(function () {
        $(this).stop().animate({ backgroundColor: '#ffffff' }, 200);
    });
});
