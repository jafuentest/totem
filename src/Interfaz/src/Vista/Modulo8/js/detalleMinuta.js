

var codigoMinuta = 1;

$(document).ready(function() {
    $.ajax(
    {
        type: "POST",
        url: "DetalleMinutas.aspx/detalleMinuta",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function(data) {
        var str = JSON.stringify(eval("(" + data.d + ")")); //Valida el JSON
        json = $.parseJSON(str); //Convierte el String en JSON

        // Código para manejar la fecha
        fechaCompleta = new Date(json["Fecha"]);
        var mes = fechaCompleta.getMonth() + 1;
        var fecha = fechaCompleta.getDate() + "/" + mes + "/" + fechaCompleta.getFullYear();
        var hora = fechaCompleta.getHours().toString() +":" +fechaCompleta.getMinutes();
        // Fin Código manejar fecha

        $('#fechaReunion').text(fecha);             
        $('#horaReunion').text(hora);
        $('#motivo').text(json["Motivo"]);
        $('#observaciones').text(json["Observaciones"]);

        //Carga de Participantes
        for (i = 0; i < json["ListaUsuario"].length; i++)
        {
            var codigoUsuario = "user" + json["ListaUsuario"][i]["idUsuario"];
            var nombreCompletoUsuario = json["ListaUsuario"][i]["nombre"] + " " + json["ListaUsuario"][i]["apellido"];
            var cargoUsuario = json["ListaUsuario"][i]["cargo"];

            $('#listaParticipante').append(
               "<div id='" + codigoUsuario + "' class='panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3'>"
               +     "<div class='panel-boddy participante'>"                                                
               +         "<div class='col-xs-2 img-participante-contenedor'><img class='img-participante' src='img/user.png' alt='Participante' /></div>"
               +         "<div class='col-xs-10 col-sm-8 nombre-participante'>"
               +            "<p class='participante-nombre'>" + nombreCompletoUsuario + "</p>"
               +            "<p class='participante-rol'><small>" + cargoUsuario + "</small></p>"
               +         "</div>"                        
               +     "</div>"
               + "</div>"
            );

        }

        //Carga de Puntos
        for (i = 0; i < json["ListaPunto"].length; i++)
        {
            var codigoPunto = "punto" + json["ListaPunto"][i]["Codigo"];
            var tituloPunto = json["ListaPunto"][i]["Titulo"];
            var desarrolloPunto = json["ListaPunto"][i]["Desarrollo"];
            var collapse = "collapse" + json["ListaPunto"][i]["Codigo"];
            var nroPunto = i + 1;
            $('#listaPunto').append(
                "<div class='panel panel-default' id='"+codigoPunto+"'>"
                +"  <div class='panel-heading'>"
                +"      <h4 class='panel-title'>"
                +"      <a data-toggle='collapse' data-target='#" + collapse + "' href='#" + collapse + "'>"
                +"          Punto " + nroPunto + ": " + tituloPunto
                +"      </a>"
                +"      </h4>"
                +"  </div>"
                +"  <div id='" + collapse + "' class='panel-collapse collapse'>"
                +"      <div class='panel-body'>" + desarrolloPunto + "</div>"
                +"  </div>"
                +"</div>"
            );
        }

        //Carga de Acuerdos
        for (i = 0; i < json["ListaAcuerdo"].length; i++)
        {
            var codigoAcuerdo = "acuerdo" + json["ListaAcuerdo"][i]["Codigo"];
            var compromisoAcuerdo = json["ListaAcuerdo"][i]["Compromiso"];
            var fechaCompletaAcuerdo = new Date(json["ListaAcuerdo"][i]["Fecha"]);
            var mes = fechaCompletaAcuerdo.getMonth() + 1;
            var fechaAcuerdo = fechaCompletaAcuerdo.getDate() + "/" + mes + "/" + fechaCompletaAcuerdo.getFullYear();
            var collapse = "collapseAcuerdo" + json["ListaAcuerdo"][i]["Codigo"];

            $('#listaAcuerdo').append(
                "<div class='panel panel-default'>"
                +"   <div class='panel-heading'>"
                +"       <h4 class='panel-title'>"
                +"           <a data-toggle='collapse' data-target='#" + collapse + "' href='#collapseOne'>"
                +"               " + compromisoAcuerdo
                +"           </a>"
                +"       </h4>"                                   
                +"   </div>"
                +"   <div id='" + collapse + "' class='panel-collapse collapse'>"
                +"      <div class='panel-body'>"
                +"          <label class='col-xs-3 control-label'>Fecha:</label>"
                +"          <label class='col-xs-9 control-label'>" + fechaAcuerdo + "</label>"
                +"          <label for='observacionesReunion' class='control-label col-xs-12'>Involucrados:</label>"
                + "              <div id=" + codigoAcuerdo + "></div>"
                +"      </div>"
                +"   </div>"                    
                +"</div>" 
            );
            
            //Carga de los Usuarios de los Acuerdos
            for (j = 0; j < json["ListaAcuerdo"][i]["ListaUsuario"].length; j++)
            {
                var codigoUsuarioAcuerdo = "userAcuerdo" + json["ListaAcuerdo"][i]["ListaUsuario"][j]["idUsuario"];
                var nombreCompletoUsuarioAcuerdo = json["ListaAcuerdo"][i]["ListaUsuario"][j]["nombre"] + " " + json["ListaAcuerdo"][i]["ListaUsuario"][j]["apellido"];
                var cargoUsuarioAcuerdo = json["ListaAcuerdo"][i]["ListaUsuario"][j]["cargo"];

                $('#'+codigoAcuerdo).append(
                    "<div id='" + codigoUsuarioAcuerdo + "' class='panel panel-default panel-participante col-xs-12 col-sm-6 col-lg-3'>"
                   + "<div class='panel-boddy participante'>"
                   + "<div class='col-xs-2 img-participante-contenedor'><img class='img-participante' src='img/user.png' alt='Participante' /></div>"
                   + "<div class='col-xs-10 col-sm-8 nombre-participante'>"
                   + "<p class='participante-nombre'>" + nombreCompletoUsuarioAcuerdo + "</p>"
                   + "<p class='participante-rol'><small>" + cargoUsuarioAcuerdo + "</small></p>"
                   + "</div>"
                   + "</div>"
                   + "</div>"
                );
            }


            
        }
    });
});