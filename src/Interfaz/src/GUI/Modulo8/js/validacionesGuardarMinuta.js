//Función que se activa una vez que el usuario halla confirmado Guardar la Minuta.
function aceptarConfirmacion()
{
    var minuta = new Object();
    minuta.motivo = $('#motivo').val();
    minuta.fecha = $('#fechaReunion').val();
    minuta.observaciones = $('#observaciones').val();
    var involucrado = [];
    var listaPunto = [];
    var listaAcuerdo = [];
    
    $('.participante-check').each(function (i, obj)
    {
        if ($(this).is(':checked'))
        {
            codigo = obj.id;
            codigoUsuario = codigo.replace("user", "");
            codigoUsuario = codigoUsuario.replace("_par_check", "");
            involucrado.push(codigoUsuario);
        }
    });

    $('.codigoPunto').each(function (j, obj)
    {
        codigo = obj.id;
        codigoPunto = codigo.replace("_div", "");
        codigoTitulo = codigoPunto + '_titulo';
        codigoDesarrollo = codigoPunto + '_desarrollo';

        tituloPunto = $('#' + codigoTitulo).val();
        desarrolloPunto = $('#' + codigoDesarrollo).val();
        if (tituloPunto != "")
        {
            punto = new Object();
            punto.titulo = tituloPunto;
            punto.desarrollo = desarrolloPunto;
            listaPunto.push(punto);
        }
    });

    $('.codigoAcuerdo').each(function (j, obj)
    {
        codigo = obj.id;
        codigoAcuerdo = codigo.replace("_div", "");
        
        codigoAcuerdoFecha = codigoAcuerdo + '_fecha';
        codigoAcuerdoCompromiso = codigoAcuerdo + '_compromiso';
        codigoAcuerdoSelect = codigoAcuerdo + '_select';

        fechaAcuerdo = $('#' + codigoAcuerdoFecha).val();
        compromisoAcuerdo = $('#' + codigoAcuerdoCompromiso).val();

        listaInvolucradoAcuerdo = [];
        $('#' + codigoAcuerdoSelect + ' :selected').each(function (i, selected)
        {
            listaInvolucradoAcuerdo.push($(selected).val());
        });

        if ((compromisoAcuerdo != "") && (fechaAcuerdo!=""))
        {
            acuerdo = new Object();
            acuerdo.fecha = fechaAcuerdo;
            acuerdo.compromiso = compromisoAcuerdo;
            acuerdo.involucrado = listaInvolucradoAcuerdo;
            listaAcuerdo.push(acuerdo);
        }


    });

    minuta.involucrado = involucrado;
    minuta.punto = listaPunto;
    minuta.acuerdo = listaAcuerdo;


    var laData = JSON.stringify(minuta);
    $.ajax(
   {
       type: "POST",
       url: "ModificarMinuta.aspx/crearMinuta",
       contentType: "application/json; charset=utf-8",
       data: "{'laMinuta':" + laData +"}",
       dataType: "text"
   }).done(function (data)
   {

   });

    alerta = "<div class='row'><div class='alert alert-success col-xs-12 col-md-push-3 col-md-8 col-lg-6 alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>¡Correcto!</strong> - Se ha Modificado la Minuta Correctamente</div></div>";
    $(".alert").remove();                           //Elimina todas las Alertas
    $(alerta).appendTo("#alertas");                 //Añade la Alerta de Éxito
    $('#confirmacion').modal('toggle');             //Cierra el Modal
}

//Función para validar la minuta
function validar() {
    $(".alert").remove();                           //Función para eliminar las alertas 
    var vacio = false;                              //Variable que se usa para validar si los campos están vacíos
    var error = false;                              //Variable que se usa para validar hay errores en los campos
    var fechaMinuta = $('#fechaReunion').val();
    var motivo = $('#motivo').val();
    var observaciones = $('#observaciones').val();
    var alerta;
    var contadorParticipantes = 0;

    $(".participante-check").each(function (index) {
        if ($(this).is(':checked')) {
            contadorParticipantes++;
        }
    });


    //Validación de la Fecha
    if (fechaMinuta == "") {
        $("#div_fechaReunion").removeClass("has-success");
        $("#div_fechaReunion").addClass("has-error");
        error = true;
        vacio = true;
    }
    else {

        $("#div_fechaReunion").removeClass("has-error");
        $("#div_fechaReunion").addClass("has-success");
        error = false;
        vacio = false;
    }

    //Validación del Motivo
    if (motivo == "") {
        $("#div_motivo").removeClass("has-success");
        $("#div_motivo").addClass("has-error");
        error = true;
        vacio = true;
    }
    else {

        $("#div_motivo").removeClass("has-error");
        $("#div_motivo").addClass("has-success");
        error = false;
        vacio = false;
    }

    //Validación de los Participantes
    if (contadorParticipantes < 2)
    {
        error = true;
        alerta = "<div class='row'><div class='alert alert-danger col-xs-12 col-md-push-3 col-md-8 col-lg-6 alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>¡Error!</strong> - Debe seleccionar por lo menos 2 Participantes</div></div>";
        $(alerta).appendTo("#alertas");
    }

    //Alertas
    if (vacio == true)
    {
        alerta = "<div class='row'><div class='alert alert-danger col-xs-12 col-md-push-3 col-md-8 col-lg-6 alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>¡Error!</strong> - Debe rellenar los campos obligatorios</div></div>";
        $(alerta).appendTo("#alertas");
    }

    //Si no hay error muestra el modal con la confirmación
    if (error == false)
    {
        $('#confirmacion').modal('show');
    }
}
