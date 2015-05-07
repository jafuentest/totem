$(document).ready(function () {
    //metodos para aplicar bootstrap validator al formulario de agregar requerimientos.
    $('#agregar_requerimientos')
       .bootstrapValidator({
           message: 'This value is not valid',
           feedbackIcons: {
               valid: 'glyphicon glyphicon-ok',
               invalid: 'glyphicon glyphicon-remove',
               validating: 'glyphicon glyphicon-refresh'
           },
           fields: {
               requerimiento: {
                   validators: {
                       notEmpty: {
                           message: 'El requerimiento no debe estar vacío'
                       }
                   }
               }
           }
       })
       .on('success.field.fv', function(e, data){//en caso de que haya problema con los campos del formulario, deshabilita el boton
           if (data.fv.getInvalidFields().length < 0){
                data.data.fv.disableSubmitButtons(true);
           }
       });
    //metodos para aplicar bootstrap validator al formulario de modificar requerimientos.
    $('#modificar_requerimientos')
        .bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                requerimiento: {
                    validators: {
                        notEmpty: {
                            message: 'El requerimiento no debe estar vacío'
                        }
                    }
                }
            }
        })
        .on('success.field.fv', function (e, data) {//en caso de que haya problema con los campos del formulario, deshabilita el boton
            if (data.fv.getInvalidFields().length > 0) {
                data.data.fv.disableSubmitButtons(true);
            }
        });
});