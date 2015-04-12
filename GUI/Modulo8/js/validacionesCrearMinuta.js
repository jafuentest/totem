//Función que se activa una vez que el usuario halla confirmado Guardar la Minuta.
function aceptarConfirmacion()
{
    alerta = "<div class='alert alert-info col-xs-12 col-md-push-3 col-md-8 col-lg-6 alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>¡Correcto!</strong> - Se ha añadido la Minuta Correctamente</div>";
    $(".alert").remove();
    $(alerta).appendTo("#alertas");
    $('#confirmacion').modal('toggle');
}

//Función para validar la minuta
function validar()
{
    $(".alert").remove();                           //Función para eliminar las alertas 
    var vacio = false;                              //Variable que se usa para validar si los campos están vacíos
    var error = false;                              //Variable que se usa para validar hay errores en los campos
    var fechaMinuta = $('#fechaReunion').val();
    var motivo = $('#motivo').val();
    var observaciones = $('#observaciones').val();
    var alerta;
    var contadorParticipantes = 0;

    $(".participante-check").each(function (index)
    {
        if ($(this).is(':checked'))
        {
            contadorParticipantes++;
        }
    });


    //Validación de la Fecha
    if (fechaMinuta == "")
    {
        $("#div_fechaReunion").removeClass("has-success");
        $("#div_fechaReunion").addClass("has-error");
        error = true;
        vacio = true;
    }
    else
    {

        $("#div_fechaReunion").removeClass("has-error");
        $("#div_fechaReunion").addClass("has-success");
        error = false;
        vacio = false;
    }

    //Validación del Motivo
    if (motivo == "")
    {
        $("#div_motivo").removeClass("has-success");
        $("#div_motivo").addClass("has-error");
        error = true;
        vacio = true;
    }
    else
    {

        $("#div_motivo").removeClass("has-error");
        $("#div_motivo").addClass("has-success");
        error = false;
        vacio = false;
    }

    //Validación de los Participantes
    if (contadorParticipantes<2)
    {
        error = true;
        alerta = "<div class='alert alert-danger col-xs-12 col-md-push-3 col-md-8 col-lg-6 alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>¡Error!</strong> - Debe seleccionar por lo menos 2 Participantes</div>";
        $(alerta).appendTo("#alertas");
    }
    else
    {
        error = false;
    }

    //Alertas
    if (vacio==true)
    {
        alerta = "<div class='alert alert-danger col-xs-12 col-md-push-3 col-md-8 col-lg-6 alert-dismissible' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button><strong>¡Error!</strong> - Debe rellenar los campos obligatorios</div>";
        $(alerta).appendTo("#alertas");
    }

    //Si no hay error muestra el modal con la confirmación
    if (error == false)
    {
        $('#confirmacion').modal('show');
    }
}
