$(document).ready(function () {
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
       .on('success.field.fv', function(e, data){
           if (data.fv.getInvalidFields().length < 0){
                data.data.fv.disableSubmitButtons(true);
           }
           });
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
        .on('success.field.fv', function (e, data) {
            if (data.fv.getInvalidFields().length > 0) {
                data.data.fv.disableSubmitButtons(true);
            }
        });
});