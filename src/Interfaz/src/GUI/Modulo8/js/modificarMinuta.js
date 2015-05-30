//Variables Generales
var StartDate = new Date("March 20, 2015");  //Fecha Mínima Posible para Seleccionar
var nroPuntos = 0;    //Número de Puntos Activos 
var nroAcuerdos = 0;       //Número de Acuerdos Activos
var listaUsuario;       //Lista de Usuarios del Proyecto

//Función Espera Segundos
$.throttle = function (timeout, callback) { // Añadimos la función al namespace de jQuery
    if ($.throttle.timeout !== false) {
        // Si estamos esperando y volvemos a llamar a la función,
        // borramos el timeout anterior para tener que volver a esperar
        // el tiempo establecido.
        clearTimeout($.throttle.timeout);
    }
    // Aquí si disparamos la función después de pasado el tiempo de espera
    // y siempre y cuando una nueva llamada no lo cancele.
    $.throttle.timeout = setTimeout(function () {
        $.throttle.timeout = false;
        callback(); // Ejecutamos la llamada
    }, timeout);
};
$.throttle.timeout = false; // La variable timeout es nuestra referencia de la función setTimeout


function CargaAcuerdo()
{
    $('.fechaAcuerdo').datetimepicker(
    {
        format: 'DD-MM-YYYY',
        viewMode: 'days',
        locale: 'es',
        useCurrent: true,
        minDate: StartDate
    }).on('show', function (e) {
        $('.day').click(function (event) {
            event.preventDefault();
            event.stopPropagation();
        });
    });

    $('.seleccionMultiple').multiselect(
    {
        buttonWidth: '100%',
        dropRight: true,
        buttonText: function (options, select) {
            if (options.length === 0) {
                return 'Seleccionar Responsables...';
            }
            else if (options.length > 3) {
                return 'Más de 3 Responsables';
            }
            else {
                var labels = [];
                options.each(function () {
                    if ($(this).attr('label') !== undefined) {
                        labels.push($(this).attr('label'));
                    }
                    else {
                        labels.push($(this).html());
                    }
                });
                return labels.join(', ') + '';
            }
        }
    });
}
// Descripción: Función Para darle Funcionalidad a los Verificar de los Participantes
// Parámetros: obj ->  El objeto Check que se ha seleccionado
// Retorna:  el Check lo habilita o deshabilita y cambia el color del DIV
function seleccionado(obj) {

    var id = obj.id;                                            //ID del Div Seleccionado
    var id_check = id + "_check";                               //ID del Check para el div Seleccionado

    if ($('#' + id_check).is(':checked')) {
        $('#' + id_check).removeAttr('checked');
        $('#' + id).removeClass("panel-participante-seleccionado");
    }
    else {
        $('#' + id_check).prop('checked', true);
        $('#' + id).addClass("panel-participante-seleccionado");
    }
}

// Descripción: Función Para cargar los Usuarios Seleccionados
// Parámetros: obj ->  El objeto Check que se ha seleccionado
// Retorna:  el Check lo habilita  y cambia el color del DIV
function cargaSeleccionado(idUsuario)
{
    var id_check = idUsuario + "_par_check";                               //ID del Check para el div Seleccionado
    var id_div = idUsuario + "_par";
    $('#' + id_check).prop('checked', true);
    $('#' + id_div).addClass("panel-participante-seleccionado");
   
}

// Descripción: Función Para Agregar DIV de un punto de una Minuta
function agregarPunto()
{
    idPunto = "punto" + nroPuntos.toString() + "_div";
    idBoton = "punto" + nroPuntos.toString() + "_btn";
    codigoPuntoTitulo = "punto" + nroPuntos.toString() + "_titulo";
    codigoPuntoDesarrollo = "punto" + nroPuntos.toString() + "_desarrollo";
    $('#puntosMinuta').append(
        "<div id='" + idPunto + "' class='panel panel-default panel-punto codigoPunto'>"
        + "  <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input id='" + codigoPuntoTitulo + "' class='form-control' placeholder='Título del Punto' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12'><textarea id='" + codigoPuntoDesarrollo + "'  name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align: justify;resize:none;' rows=3></textarea></div>"
        + " </div>"
        + "</div>"
    );

}
// Descripción: Función Para Eliminar DIV de un punto de una Minuta
// Parámetros: obj ->  El objeto que se desea Eliminar
function borrarPunto(obj)
{
    if ($('#puntosMinuta').find('.panel-punto').length > 1)
    {
        idBoton = obj.id;
        codigoDIV = idBoton.replace("_btn", "_div");
        $('#' + codigoDIV).remove();
        nroPuntos = nroPuntos - 1;
    }

}
// Descripción: Función Para Agregar DIV de un acuerdo de una Minuta
function agregarAcuerdo()
{
    codigoAcuerdoDIV = "acuerdo" + nroAcuerdos.toString() + "_div";
    codigoAcuerdoBTN = "acuerdo" + nroAcuerdos.toString() + "_btn";
    codigoAcuerdoSelect = "acuerdo" + nroAcuerdos.toString() + "_select";
    codigoAcuerdoFecha = "acuerdo" + nroAcuerdos.toString() + "_fecha";
    codigoAcuerdoCompromiso = "acuerdo" + nroAcuerdos.toString() + "_compromiso";

    $('#acuerdosMinuta').append(
        "<div id=" + codigoAcuerdoDIV + " class='panel panel-default panel-punto codigoAcuerdo'>"
        + " <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + codigoAcuerdoBTN + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input id='" + codigoAcuerdoCompromiso + "' class='form-control' class='tituloReunion' value='' placeholder='Acuerdo o Compromiso' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12 col-md-4 date'> "
        + "         <input id='" + codigoAcuerdoFecha + "' type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' />"
        + "     </div>"
        + "     <div class='col-xs-12 visible-xs form-group'></div>"
        + "     <div class='col-xs-12 col-md-8'>"
        + "         <select id='" + codigoAcuerdoSelect + "' class='seleccionMultiple' multiple='multiple'>"
        + "         </select>"
        + "     </div>"
        + " </div>"
        + "</div>"
    );

    //Carga de Usuarios en el ComboBox
    for (j = 0; j < listaUsuario.length; j++) {
        var codigoUsuario = listaUsuario[j]["idUsuario"];
        var nombreCompletoUsuario = listaUsuario[j]["nombre"] + " " + listaUsuario[j]["apellido"];
        $('#' + codigoAcuerdoSelect).append("<option value = " + codigoUsuario + ">" + nombreCompletoUsuario + "</option>");
    }
    nroAcuerdos++;
    CargaAcuerdo();          //Carga el Diseño MultiSelectBootstrap y DatePickerBootstrap de los Acuerdos
}

function borrarAcuerdo(obj)
{
    if ($('#acuerdosMinuta').find('.panel-punto').length > 1)
    {
        idBoton = obj.id;
        codigoDIV = idBoton.replace("_btn", "_div");
        $('#' + codigoDIV).remove();
        nroAcuerdos = nroAcuerdos - 1;
    }
}
//******************************************** INICIO - CARGA MINUTA***************************************************
//Función Inicio de Carga
$(function ()
{

    // Función AJAX Carga de Involucrados del Proyecto
    // Retorna: La lista de Involucrados del Proyecto en un DIV
    $.ajax(
    {
        type: "POST",
        url: "ModificarMinuta.aspx/ListaUsuario",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (data)
    {
       var str = JSON.stringify(eval("(" + data.d + ")")); //Valida el JSON
       json = $.parseJSON(str); //Convierte el String en JSON
       listaUsuario = json;  //Asignación para usarlo en la carga de ComboBoxes más adelante
       //Carga de Participantes
       for (i = 0; i < json.length; i++) {
           var codigoUsuario = "user" + json[i]["idUsuario"];
           var nombreCompletoUsuario = json[i]["nombre"] + " " + json[i]["apellido"];
           var cargoUsuario = json[i]["cargo"];
           var codigoUsuarioDIV = codigoUsuario + "_par";
           var codigoUsuarioCheck = codigoUsuario + "_par_check";

           $('#listaParticipante').append(
              "<div id='" + codigoUsuarioDIV + "' class='panel panel-default panel-participante col-xs-12 col-sm-6' onClick='seleccionado(this)'>"
              +"    <div class='panel-boddy participante'>"
              +"        <div class='col-xs-1 check-contenedor'><input type='checkbox' class='participante-check' id='" + codigoUsuarioCheck + "'/></div>"
              +"        <div class='col-xs-2 img-participante-contenedor'><img class='img-participante' src='img/user.png' alt='Participante' /></div>"
              +"        <div class='col-xs-8 nombre-participante'>"
              +"            <p class='participante-nombre'>" + nombreCompletoUsuario + "</p>"
              +"            <p class='participante-rol'><small>" + cargoUsuario + "</small></p>"
              +"        </div>"
              +"    </div>"
              +"</div>"
           );

           $('#' + codigoUsuarioCheck).attr('checked', false);
       }

   });

    // Función AJAX Carga de los Detalles de la Minúta
    // Retorna: Detalles de la Minuta listo para ser Modificados
    $.throttle(1000, function ()
    {
        $.ajax(
       {
           type: "POST",
           url: "ModificarMinuta.aspx/detalleMinuta",
           contentType: "application/json; charset=utf-8",
           dataType: "json"
       }).done(function (data)
       {
           var str = JSON.stringify(eval("(" + data.d + ")")); //Valida el JSON
           json = $.parseJSON(str); //Convierte el String en JSON

           var fechaCompleta = new Date(json["Fecha"]);
           var mes = fechaCompleta.getMonth() + 1;
           var fecha = fechaCompleta.getDate() + "/" + mes + "/" + fechaCompleta.getFullYear();
           var hora = fechaCompleta.getHours().toString() + ":" + fechaCompleta.getMinutes();
           var motivo = json["Motivo"];
           var observaciones = json["Observaciones"];

           //------------------------------Asignar Fecha--------------------------------------------------------------------------
           $("#fechaReunion").val(fecha + " " + hora);
           $('#fechaReunion').datetimepicker(
           {
               locale: 'es',                    //Idioma Español
               minDate: StartDate               //Variable General StartDate -> Fecha Mínima que se puede seleccionar
           }).on('show', function (e) {
               $('.day').click(function (event) {
                   event.preventDefault();
                   event.stopPropagation();
               });
           });

           //------------------------------Asignar Motivo de la Reunión-----------------------------------------------------------
           $("#motivo").val(motivo);

           //------------------------------Asignar Participantes------------------------------------------------------------------
           for (i = 0; i < json["ListaUsuario"].length; i++)
           {
               var codigoUsuarioSeleccionado = "user" + json["ListaUsuario"][i]["idUsuario"];
               cargaSeleccionado(codigoUsuarioSeleccionado);
           }

           //---------------------------------Asignar Puntos Tratados--------------------------------------------------------------
           for (i = 0; i < json["ListaPunto"].length; i++)
           {
               var codigoPunto = "punto" + json["ListaPunto"][i]["Codigo"];
               var tituloPunto = json["ListaPunto"][i]["Titulo"];
               var desarrolloPunto = json["ListaPunto"][i]["Desarrollo"];

               codigoPuntoDIV = "punto"+ i + "_div";
               codigoPuntoBTN = "punto" + i + "_btn";
               codigoPuntoTitulo = "punto" + i + "_titulo";
               codigoPuntoDesarrollo = "punto" + i + "_desarrollo";
               $('#puntosMinuta').append(
                    "<div id='" + codigoPuntoDIV + "' class='panel panel-default panel-punto codigoPunto'>"
                    + "  <div class='panel-body panel-minuta'>"
                    + "     <div class='col-xs-12'>"
                    + "         <button type='button' id=" + codigoPuntoBTN + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
                    + "         <input id='" + codigoPuntoTitulo + "' class='form-control' placeholder='Título del Punto' value='" + tituloPunto + "' type='text'/>"
                    + "     </div>"
                    + "     <div class='col-xs-12 form-group'></div>"
                    + "     <div class='col-xs-12'><textarea id='" + codigoPuntoDesarrollo + "' name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align:justify; resize:none;' rows=3>" + desarrolloPunto + "</textarea></div>"
                    + " </div>"
                    + "</div>"
                );
               nroPuntos++;
           }
           codigoPuntoDIV = "punto"+ i + "_div";
           codigoPuntoBTN = "punto" + i + "_btn";
           codigoPuntoTitulo = "punto" + i + "_titulo";
           codigoPuntoDesarrollo = "punto" + i + "_desarrollo";
           $('#puntosMinuta').append(
                "<div id='" + codigoPuntoDIV + "' class='panel panel-default panel-punto codigoPunto'>"
                + "  <div class='panel-body panel-minuta'>"
                + "     <div class='col-xs-12'>"
                + "         <button type='button' id=" + codigoPuntoBTN + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
                + "         <input id='" + codigoPuntoTitulo + "' class='form-control' placeholder='Título del Punto' value='' type='text'/>"
                + "     </div>"
                + "     <div class='col-xs-12 form-group'></div>"
                + "     <div class='col-xs-12'><textarea id='" + codigoPuntoDesarrollo + "' name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align:justify; resize:none;' rows=3></textarea></div>"
                + " </div>"
                + "</div>"
           );
           nroPuntos++;

           //------------------------------Asignar Acuerdos y Compromisos------------------------------------------------
           for (i = 0; i < json["ListaAcuerdo"].length; i++)
           {
               var codigoAcuerdo = "acuerdo" + json["ListaAcuerdo"][i]["Codigo"];
               var compromisoAcuerdo = json["ListaAcuerdo"][i]["Compromiso"];
               var fechaCompletaAcuerdo = new Date(json["ListaAcuerdo"][i]["Fecha"]);
               var mes = fechaCompletaAcuerdo.getMonth() + 1;
               var fechaAcuerdo = fechaCompletaAcuerdo.getDate() + "/" + mes + "/" + fechaCompletaAcuerdo.getFullYear();
               codigoAcuerdoDIV = "acuerdo" + i + "_div";
               codigoAcuerdoBTN = "acuerdo" + i + "_btn";
               codigoAcuerdoSelect = "acuerdo" + i + "_select";
               codigoAcuerdoFecha = "acuerdo" + i + "_fecha";
               codigoAcuerdoCompromiso = "acuerdo" + i + "_compromiso";
               codigoAcuerdoSelectDIV = "acuerdo" + i + "_selectDIV";
               $('#acuerdosMinuta').append(
                   "<div id=" + codigoAcuerdoDIV + " class='panel panel-default panel-punto codigoAcuerdo'>"
                   + " <div class='panel-body panel-minuta'>"
                   + "     <div class='col-xs-12'>"
                   + "         <button type='button' id=" + codigoAcuerdoBTN + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
                   + "         <input id='" + codigoAcuerdoCompromiso + "' class='form-control' class='tituloReunion' value='" + compromisoAcuerdo + "' placeholder='Acuerdo o Compromiso' type='text'/>"
                   + "     </div>"
                   + "     <div class='col-xs-12 form-group'></div>"
                   + "     <div class='col-xs-12 col-md-4 date'> "
                   + "         <input id='" + codigoAcuerdoFecha + "' type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' value='" + fechaAcuerdo + "' />"
                   + "     </div>"
                   + "     <div class='col-xs-12 visible-xs form-group'></div>"
                   + "     <div id='" + codigoAcuerdoSelectDIV + "'class='col-xs-12 col-md-8'>"
                   + "         <select id='"+codigoAcuerdoSelect+"' class='seleccionMultiple' multiple='multiple'>"
                   + "         </select>"
                   + "     </div>"
                   + " </div>"
                   + "</div>"
               );
               
               //Carga de Usuarios en el ComboBox
               for (j = 0; j < listaUsuario.length; j++)
               {
                   var codigoUsuario = listaUsuario[j]["idUsuario"];
                   var nombreCompletoUsuario = listaUsuario[j]["nombre"] + " " + listaUsuario[j]["apellido"];
                   $('#' + codigoAcuerdoSelect).append("<option value = " + codigoUsuario + ">" + nombreCompletoUsuario + "</option>");
               }
               
               //Selecciona Usuarios de la Minuta
               for (k = 0; k < json["ListaAcuerdo"][i]["ListaUsuario"].length; k++)
               {
                   var codigoUsuarioAcuerdo = json["ListaAcuerdo"][i]["ListaUsuario"][k]["idUsuario"];
                   $('#' + codigoAcuerdoSelect + " option[value='" + codigoUsuarioAcuerdo + "']").prop("selected", true);
               }

               nroAcuerdos++;
           }
           codigoAcuerdoDIV = "acuerdo" + i + "_div";
           codigoAcuerdoBTN = "acuerdo" + i + "_btn";
           codigoAcuerdoSelect = "acuerdo" + i + "_select";
           codigoAcuerdoFecha = "acuerdo" + i + "_fecha";
           codigoAcuerdoCompromiso = "acuerdo" + i + "_compromiso";
           codigoAcuerdoSelectDIV = "acuerdo" + i + "_selectDIV";
           $('#acuerdosMinuta').append(
               "<div id=" + codigoAcuerdoDIV + " class='panel panel-default panel-punto codigoAcuerdo'>"
               + " <div class='panel-body panel-minuta'>"
               + "     <div class='col-xs-12'>"
               + "         <button type='button' id=" + codigoAcuerdoBTN + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
               + "         <input id='" + codigoAcuerdoCompromiso + "' class='form-control' class='tituloReunion' value='' placeholder='Acuerdo o Compromiso' type='text'/>"
               + "     </div>"
               + "     <div class='col-xs-12 form-group'></div>"
               + "     <div class='col-xs-12 col-md-4 date'> "
               + "         <input id='" + codigoAcuerdoFecha + "' type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' />"
               + "     </div>"
               + "     <div class='col-xs-12 visible-xs form-group'></div>"
               + "     <div id='" + codigoAcuerdoSelectDIV + "'class='col-xs-12 col-md-8'>"
               + "         <select id='" + codigoAcuerdoSelect + "' class='seleccionMultiple' multiple='multiple'>"
               + "         </select>"
               + "     </div>"
               + " </div>"
               + "</div>"
           );

           //Carga de Usuarios en el ComboBox
           for (j = 0; j < listaUsuario.length; j++) {
               var codigoUsuario = listaUsuario[j]["idUsuario"];
               var nombreCompletoUsuario = listaUsuario[j]["nombre"] + " " + listaUsuario[j]["apellido"];
               $('#' + codigoAcuerdoSelect).append("<option value = " + codigoUsuario + ">" + nombreCompletoUsuario + "</option>");
           }
           nroAcuerdos++;
           CargaAcuerdo();          //Carga el Diseño MultiSelectBootstrap y DatePickerBootstrap de los Acuerdos

           //------------------------------Asignar Observaciones------------------------------------------------
           $("#observaciones").val(observaciones);
           
       });// Fin Ajax
        
    });

});
