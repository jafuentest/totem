$(document).ready( function()
{
    $("#rsocial-dd li a").click( function()
    {

        $("#rsocial-id").html($(this).text() + ' <span class="caret"></span>');

    });
    $("#pais-dd li a").click( function()
    {

        $("#pais-id").html($(this).text() + ' <span class="caret"></span>');

    });
    $("#estado-dd li a").click( function()
    {

        $("#estado-id").html($(this).text() + ' <span class="caret"></span>');

    });
});