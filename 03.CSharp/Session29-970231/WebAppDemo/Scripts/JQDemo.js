'use strict';
(function () {

    //$('body').css('background-color', '#59b');
    //var fullname = document.getElementById("fullname").innerHTML;
    //alert(fullname);

    //$(document).ready(function () {

    //});

    $(function () {
        $('#btn-click').on('click', function () {
            //alert($('#btn-click').html());
            //alert($(this).html());
            $('#red-box').html(
                $('#fullname').val()
            );
            //$(this).hide();
            $(this).toggle();
            setTimeout(function () {
                $('#btn-click').toggle();
            }, 5000);
        });
        //console.log($btn.html());

    });

})();