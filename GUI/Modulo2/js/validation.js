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
            rif: {
                validators: {
                    notEmpty: {
                        message: 'El RIF es requerido'
                    },
                    regexp: {
                        regexp: /^\d{1,8}$/,
                        message: 'El RIF debe de contener un valor numérico comprendido entre 1 y 8 dígitos'
                    }
                }
            },
            telefono: {
                validators: {
                    notEmpty: {
                        message: 'El teléfono es requerido'
                    },
                    regexp: {
                        regexp: /^\d{10}$/,
                        message: 'El teléfono debe de tener 10 dígitos numéricos. <br>Ej. 2121234567'
                    }
                }
            },
            correo: {
                validators: {
                    notEmpty: {
                        message: 'El correo electrónico es requerido'
                    },
                    emailAddress: {
                        message: 'No es un correo electrónico válido'
                    }
                }
            },
        }
    });

    $('#agregar_empresa').bootstrapValidator({
        message: 'El valor no es válido',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            rif: {
                validators: {
                    notEmpty: {
                        message: 'El RIF es requerido'
                    },
                    regexp: {
                        regexp: /^\d{9}$/,
                        message: 'El RIF debe de tener 9 dígitos numéricos'
                    }
                }
            },
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es requerido'
                    }
                }
            },
            imagentype: {
                validators: {
                    notEmpty: {
                        message: 'La imagen es requerida'
                    }
                }
            },
            direccion: {
                validators: {
                    notEmpty: {
                        message: 'La dirección detallada es requerida'
                    }
                }
            },
            codigopostal: {
                validators: {
                    notEmpty: {
                        message: 'El código postal es requerido'
                    },
                    regexp: {
                        regexp: /^\d{4}$/,
                        message: 'El código postal debe de tener 4 dígitos numéricos. <br>Ej. 1040'
                    }
                }
            },
            telefono: {
                validators: {
                    notEmpty: {
                        message: 'El teléfono es requerido'
                    },
                    regexp: {
                        regexp: /^\d{10}$/,
                        message: 'El teléfono debe de tener 10 dígitos numéricos. <br>Ej. 2121234567'
                    }
                }
            }
        }
    });

});