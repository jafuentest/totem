$(document).ready(function () {
    $('#agregar_cliente')
       .bootstrapValidator({
           message: 'Los valores no son correctos',
           feedbackIcons: {
               valid: 'glyphicon glyphicon-ok',
               invalid: 'glyphicon glyphicon-remove',
               validating: 'glyphicon glyphicon-refresh'
           },
           fields: {
               nombre: {
                    selector: '.nombre',
                    validators: {
                        notEmpty: {
                            message: 'El nombre es requerido'
                        }
                    }
               },
               apellido: {
                   selector: '.apellido',
                   validators: {
                       notEmpty: {
                           message: 'El apellido es requerido'
                       }
                   }
               }
           }
       });
});