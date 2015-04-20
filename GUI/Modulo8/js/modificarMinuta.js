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


var nroPuntos = 3;                                              //Número de Puntos Tratados
function agregarPunto()
{
    nroPuntos++;
    idPunto = nroPuntos.toString() + "-pun-div";
    idBoton = nroPuntos.toString() + "-pun";
    $('#puntosMinuta').append(
        "<div id='" + idPunto + "' class='panel panel-default panel-punto'>"
        + "  <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' placeholder='Título del Punto' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12'><textarea name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align: justify;resize:none;' rows=3></textarea></div>"
        + " </div>"
        + "</div>"
    );

}

function borrarPunto(obj)
{
    if ($('#puntosMinuta').find('.panel-punto').length > 1)
    {
        idDiv = obj.id + "-div";
        $('#' + idDiv).remove();
        nroPuntos = nroPuntos - 1;
    }

}

var acuerdos = 3;

function agregarAcuerdo()
{
    acuerdos++;
    idDiv = acuerdos.toString() + "-acuerdo-div";
    idBoton = acuerdos.toString() + "-acuerdo";
    $('#acuerdosMinuta').append(
        "<div id=" + idDiv + " class='panel panel-default panel-punto'>"
        + " <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' placeholder='Acuerdo o Compromiso' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12 col-md-4 date'> "
        + "         <input type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' name='1fechaAcuerdo' id='1fechaAcuerdo'/>"
        + "     </div>"
        + "     <div class='col-xs-12 visible-xs form-group'></div>"
        + "     <div class='col-xs-12 col-md-8'>"
        + "         <select class='seleccionMultiple' multiple='multiple'>"
        + "             <option value='1'>César Contreras</option>"
        + "             <option value='2'>Ana Pérez</option>"
        + "             <option value='3'>Daniel Sam</option>"
        + "             <option value='4'>Ramón Quintero</option>"
        + "         </select>"
        + "     </div>"
        + " </div>"
        + "</div>"
    );
    CargaAcuerdo();
}

function borrarAcuerdo(obj)
{
    if ($('#acuerdosMinuta').find('.panel-punto').length > 1)
    {
        idDiv = obj.id + "-div";
        $('#' + idDiv).remove();
        acuerdos = acuerdos - 1;
    }
}


$(function ()
{

    StartDate = new Date("March 20, 2015");
    $('#fechaReunion').datetimepicker(
    {
        locale: 'es',
        useCurrent: true,
        minDate: StartDate
    }).on('show', function (e)
    {
        $('.day').click(function (event)
        {
            event.preventDefault();
            event.stopPropagation();
        });
    });;

    CargaAcuerdo();

    //------------------------------Asignar Fecha--------------------------------------------------------------------------

    $("#fechaReunion").val("15/04/2015 10:05");
    StartDate = new Date("March 20, 2015");
    $('#fechaReunion').datetimepicker(
    {
        locale: 'es',
        minDate: StartDate
    }).on('show', function (e)
    {
        $('.day').click(function (event) {
            event.preventDefault();
            event.stopPropagation();
        });
    });;


    //------------------------------Asignar Motivo de la Reunión-----------------------------------------------------------
    $("#motivo").val("Definición de los Objetivos y Alcance del Proyecto");


    //------------------------------Asignar Participantes------------------------------------------------------------------
    //Función que asigna las clases 
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

    document.getElementById("1_par_check").checked = true;
    $('#1_par').addClass("panel-participante-seleccionado");
    document.getElementById("2_par_check").checked = true;
    $('#2_par').addClass("panel-participante-seleccionado");
    document.getElementById("4_par_check").checked = true;
    $('#4_par').addClass("panel-participante-seleccionado");


    //---------------------------------Asignar Puntos Tratados--------------------------------------------------------------


    idPunto = "1-pun-div";
    idBoton = "1-pun";
    tituloPunto = "Definir Objetivo General";
    desarrolloPunto = "Se acordó que se desarrollará un Portal Web donde se gestionará los servicios de la Empresa de cara al Cliente."

    $('#puntosMinuta').append(
        "<div id='" + idPunto + "' class='panel panel-default panel-punto'>"
        + "  <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' placeholder='Título del Punto' value='" + tituloPunto + "' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12'><textarea name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align:justify; resize:none;' rows=3>" + desarrolloPunto + "</textarea></div>"
        + " </div>"
        + "</div>"
    );

    idPunto = "2-pun-div";
    idBoton = "2-pun";
    tituloPunto = "Definir Alcance";
    desarrolloPunto = "El Sistema sólo se dedicará los servicios de cara al cliente, no es una aplicación backoffice. "

    $('#puntosMinuta').append(
        "<div id='" + idPunto + "' class='panel panel-default panel-punto'>"
        + "  <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' placeholder='Título del Punto' value='" + tituloPunto + "' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12'><textarea name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align:justify; resize:none;' rows=3>" + desarrolloPunto + "</textarea></div>"
        + " </div>"
        + "</div>"
    );

    idPunto = "3-pun-div";
    idBoton = "3-pun";
    $('#puntosMinuta').append(
        "<div id='" + idPunto + "' class='panel panel-default panel-punto'>"
        + "  <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarPunto(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' placeholder='Título del Punto' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12'><textarea name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align:justify; resize:none;' rows=3></textarea></div>"
        + " </div>"
        + "</div>"
    );

   

    //------------------------Asignar Acuerdos y Compromisos---------------------------------------------
    var acuerdos = 3;



    idDiv = "1-acuerdo-div";
    idBoton = "1-acuerdo";
    tituloAcuerdo = "Reunión con los StakeHolders";
    fechaEntrega ="05/05/2015";
    idfechaAcuerdo = "1-fechaAcuerdo";

    $('#acuerdosMinuta').append(
        "<div id=" + idDiv + " class='panel panel-default panel-punto'>"
        + " <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' class='tituloReunion' value='" + tituloAcuerdo + "' placeholder='Acuerdo o Compromiso' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12 col-md-4 date'> "
        + "         <input type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' name='" + idfechaAcuerdo + "' id='" + idfechaAcuerdo + "' value='" + fechaEntrega + "' />"
        + "     </div>"
        + "     <div class='col-xs-12 visible-xs form-group'></div>"
        + "     <div class='col-xs-12 col-md-8'>"
        + "         <select class='seleccionMultiple' multiple='multiple'>"
        + "             <option value='1' selected='selected'>César Contreras</option>"
        + "             <option value='2' selected='selected'>Ana Pérez</option>"
        + "             <option value='3'>Daniel Sam</option>"
        + "             <option value='4'>Ramón Quintero</option>"
        + "         </select>"
        + "     </div>"
        + " </div>"
        + "</div>"
    );

    idDiv = "2-acuerdo-div";
    idBoton = "2-acuerdo";
    tituloAcuerdo = "Levantar Requerimientos";
    fechaEntrega = "10/05/2015";
    idfechaAcuerdo = "2-fechaAcuerdo";

    $('#acuerdosMinuta').append(
        "<div id=" + idDiv + " class='panel panel-default panel-punto'>"
        + " <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' class='tituloReunion' value='" + tituloAcuerdo + "' placeholder='Acuerdo o Compromiso' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12 col-md-4 date'> "
        + "         <input type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' name='" + idfechaAcuerdo + "' id='" + idfechaAcuerdo + "' value='" + fechaEntrega + "' />"
        + "     </div>"
        + "     <div class='col-xs-12 visible-xs form-group'></div>"
        + "     <div class='col-xs-12 col-md-8'>"
        + "         <select class='seleccionMultiple' multiple='multiple'>"
        + "             <option value='1' selected='selected'>César Contreras</option>"
        + "             <option value='2'>Ana Pérez</option>"
        + "             <option value='3'>Daniel Sam</option>"
        + "             <option value='4'>Ramón Quintero</option>"
        + "         </select>"
        + "     </div>"
        + " </div>"
        + "</div>"
    );

    idDiv = "3-acuerdo-div";
    idBoton = "3-acuerdo";
    tituloAcuerdo = "";
    fechaEntrega = "";
    idfechaAcuerdo = "3-fechaAcuerdo";

    $('#acuerdosMinuta').append(
        "<div id=" + idDiv + " class='panel panel-default panel-punto'>"
        + " <div class='panel-body panel-minuta'>"
        + "     <div class='col-xs-12'>"
        + "         <button type='button' id=" + idBoton + " class='close' data-dismiss='alert' onClick='borrarAcuerdo(this);' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"
        + "         <input class='form-control' class='tituloReunion' value='" + tituloAcuerdo + "' placeholder='Acuerdo o Compromiso' type='text'/>"
        + "     </div>"
        + "     <div class='col-xs-12 form-group'></div>"
        + "     <div class='col-xs-12 col-md-4 date'> "
        + "         <input type='text' class='form-control fechaAcuerdo' placeholder='Fecha de Entrega' name='" + idfechaAcuerdo + "' id='" + idfechaAcuerdo + "' value='" + fechaEntrega + "' />"
        + "     </div>"
        + "     <div class='col-xs-12 visible-xs form-group'></div>"
        + "     <div class='col-xs-12 col-md-8'>"
        + "         <select class='seleccionMultiple' multiple='multiple'>"
        + "             <option value='1'>César Contreras</option>"
        + "             <option value='2'>Ana Pérez</option>"
        + "             <option value='3'>Daniel Sam</option>"
        + "             <option value='4'>Ramón Quintero</option>"
        + "         </select>"
        + "     </div>"
        + " </div>"
        + "</div>"
    );

    CargaAcuerdo();
    

});
