$(document).ready( function()
{
    $("#rsocial-dd li a").click( function()
    {

        $("#rsocial-id").html($(this).text() + ' <span class="caret"></span>');

    });
    $("#cargo-dd li a").click(function () {

        $("#cargo-id").html($(this).text() + ' <span class="caret"></span>');

    });
});