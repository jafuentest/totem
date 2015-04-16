$(document).ready( function()
{
    $("#rsocial-dd li a").click( function()
    {

        $("#rsocial").html($(this).text() + ' <span class="caret"></span>');

    });
    $("#pais-dd li a").click( function()
    {

        $("#pais").html($(this).text() + ' <span class="caret"></span>');

    });
    $("#estado-dd li a").click( function()
    {

        $("#estado").html($(this).text() + ' <span class="caret"></span>');

    });
});