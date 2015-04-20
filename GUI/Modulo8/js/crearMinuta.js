var nroPuntos = 1;

$('#1_par_check').attr('checked', false);
$('#2_par_check').attr('checked', false);
$('#3_par_check').attr('checked', false);
$('#4_par_check').attr('checked', false);

var acuerdos = 1;


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

});


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
        + "     <div class='col-xs-12'><textarea name='desarrollo' placeholder='Desarrollo del Punto' class='form-control' style='text-align:justify; resize:none;' rows=3></textarea></div>"
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