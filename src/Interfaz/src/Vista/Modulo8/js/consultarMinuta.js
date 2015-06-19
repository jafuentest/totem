
$.ajax(
{
    type: "POST",
    url: "ConsultarMinuta.aspx/ListaMinuta",
    contentType: "application/json; charset=utf-8",
    dataType: "json"
}).done(function (data) {
    var obj = jQuery.parseJSON(data.d);
    $('#table-example').dataTable({
        "data": obj.Data
    });
});