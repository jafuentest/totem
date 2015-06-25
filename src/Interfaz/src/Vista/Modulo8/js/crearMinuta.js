//------------------------------------------------------VARIABLES GENERALES------------------------------------------------------------------------
var nroPuntos = 0;          //Número de Puntos Activos 
var nroAcuerdos = 0;        //Número de Acuerdos Activos
var listaUsuario;           //Lista de Usuarios del Proyecto
var StartDate = new Date("March 20, 2015"); //Fecha Mínima Posible para Seleccionar
//-------------------------------------------------------FUNCIONES-------------------------------------------------------------------------------


/// <summary>
/// Función parar agregar la funcionalidad a la Fecha y al Select Multiple de cada Acuerdo
/// </summary>
/// <returns>retorna:
/*
    clase .fechaAcuerdo: Input de las fechas de los acuerdos se le implenta la funcionalidad de la librería Datetimepicker Bootstrap
    clase .seleccionMultiple: Combobox con la lista de los involucrados del Proyecto se le implementa la funcionalidad del SelectMultipleBootstrap.
*/
//</returns>
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
        $('.day').click(function (event)
        {
            event.preventDefault();
            event.stopPropagation();
        });
    });

    $('.seleccionMultiple').multiselect(
    {
        buttonWidth: '100%',
        dropRight: true,
        buttonText: function (options, select)
        {
            if (options.length === 0)
            {
                return 'Seleccionar Responsables...';
            }
            else if (options.length > 3)
            {
                return 'Más de 3 Responsables';
            }
            else {
                var labels = [];
                options.each(function ()
                {
                    if ($(this).attr('label') !== undefined)
                    {
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
function seleccionado(obj)
{
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

// Descripción: Función Para Agregar DIV de un punto de una Minuta
// Retorna: Un DIV con los campos para agregar las minutas usa el ID del
function agregarPunto() {
    idPunto = "punto" + nroPuntos.toString() + "_div";
    idBoton = "punto" + nroPuntos.toString() + "_btn";
    codigoPuntoTitulo = "punto" + nroPuntos.toString() + "_titulo";
    codigoPuntoDesarrollo = "punto" + nroPuntos.toString() + "_desarrollo";
    $('#puntosMinuta').append(
        "<div id='" + idPunto + "' class='panel panel-default panel-punto codigoPunto'>"
        + "  <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input id='" + codigoPuntoTitulo + "' class='form-control' maxlength='100' placeholder='Título del Punto' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12'><textarea id='" + codigoPuntoDesarrollo + "'  name='desarrollo' maxlength='200' placeholder='Desarrollo del Punto' class='form-control' style='text-align: justify;resize:none;' rows=3></textarea></div>"
        + " </div>"
        + "</div>"
    );
    nroPuntos++;
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
// Retorna: Un div con los campos de Acuerdo
function agregarAcuerdo() {
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
        + "         <input id='" + codigoAcuerdoCompromiso + "' class='form-control' maxlength='120' class='tituloReunion' value='' placeholder='Acuerdo o Compromiso' type='text'/>"
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
        var codigoUsuario = listaUsuario[j]["Id"];
        var nombreCompletoUsuario = listaUsuario[j]["Nombre"] + " " + listaUsuario[j]["Apellido"];
        $('#' + codigoAcuerdoSelect).append("<option value = " + codigoUsuario + ">" + nombreCompletoUsuario + "</option>");
    }
    nroAcuerdos++;
    CargaAcuerdo();          //Carga el Diseño MultiSelectBootstrap y DatePickerBootstrap de los Acuerdos
}

// Descripción: Función Para Eliminar DIV de un acuerdo de una Minuta
// Parámetros: obj ->  El objeto que se desea Eliminar
function borrarAcuerdo(obj) {
    if ($('#acuerdosMinuta').find('.panel-punto').length > 1) {
        idBoton = obj.id;
        codigoDIV = idBoton.replace("_btn", "_div");
        $('#' + codigoDIV).remove();
        nroAcuerdos = nroAcuerdos - 1;
    }
}

//----------------------------------------------------------INICIO-----------------------------------------------------------------------------------

$(function ()
{
    //Comunicación con el Servidor para traer los involucrados del Proyecto
    $.ajax(
    {
        type: "POST",
        url: "CrearMinuta.aspx/ListaInvolucrado",
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (data) {
        var str = JSON.stringify(eval("(" + data.d + ")")); //Valida la Data
        json = $.parseJSON(str); //Convierte el String en JSON
        listaUsuario = json;  //Asignación para usarlo en la carga de ComboBoxes de los Acuerdos más adelante

        //Carga de los Involucrados en DIV con ID listaInvolucrado
        for (i = 0; i < json.length; i++) {
            var codigoUsuario = json[i]["Id"];
            var nombreCompletoUsuario = json[i]["Nombre"] + " " + json[i]["Apellido"];
            var cargoUsuario = json[i]["Cargo"];
            var divUsuario = codigoUsuario + "_par";
            var checkUsuario = codigoUsuario + "_par_check";
            document.write('texto');
            window.alert(5 + 6);

            $('#listaInvolucrado').append(
               "<div id='" + divUsuario + "' class='panel panel-default panel-participante col-xs-12 col-sm-6' onclick='seleccionado(this)'>"
               + "   <div class='panel-boddy participante'>"
               + "       <div class='col-xs-1 check-contenedor'><input type='checkbox' class='participante-check' id='" + checkUsuario + "'/></div>"
               + "       <div class='col-xs-2 img-participante-contenedor'><img class='img-participante' src='img/user.png' alt='Participante' /></div>"
               + "       <div class='col-xs-8 nombre-participante'>"
               + "           <p class='participante-nombre'>" + nombreCompletoUsuario + "</p>"
               + "           <p class='participante-rol'><small>" + cargoUsuario + "</small></p>"
               + "       </div>"
               + "   </div>"
               + "</div>"
            );
            $('#' + checkUsuario).attr('checked', false);
        }

        //Se le da Funcionalidad del DatetimePickerBootstrap al campo Fecha de Minuta
        $('#fechaReunion').datetimepicker(
        {
            locale: 'es',
            useCurrent: true,
            minDate: StartDate
        }).on('show', function (e) {
            $('.day').click(function (event) {
                event.preventDefault();
                event.stopPropagation();
            });
        });;

        //Se carga un campo de Punto y Acuerdo
        agregarPunto();
        agregarAcuerdo();
    });

});