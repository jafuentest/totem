$(document).ready(function () {
    $('#agregar_cliente').bootstrapValidator({
        message: 'El valor no es válido',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es requerido'
                    }
                }
            },
            apellido: {
                validators: {
                    notEmpty: {
                        message: 'El apellido es requerido'
                    }
                }
            },
            cargo: {
                validators: {
                    notEmpty: {
                        message: 'El cargo es requerido'
                    }
                }
            }
        }
    });
});