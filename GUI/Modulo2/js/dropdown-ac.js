$(document).ready( function()
{

    $("#rsocial-dd li a").click( function()
    {

        $("#rsocial").html($(this).text() + ' <span class="caret"></span>');

    });

    $("#cargo-dd li a").click(function () {

        $("#cargo").html($(this).text() + ' <span class="caret"></span>');

    });

    $("#empresa-dd li a").click(function () {

        $("#empresa").html($(this).text() + ' <span class="caret"></span>');

    });

    $("#cargo-dd li a").click(function () {

        if ($(this).text() == 'Otro') {
            $('#otro-cargo').prop('disabled', false);
        }
        else {
            $('#otro-cargo').prop('disabled', true);
            $('#otro-cargo').val('');
        }
        $("#cargo").html($(this).text() + ' <span class="caret"></span>');

    });

});