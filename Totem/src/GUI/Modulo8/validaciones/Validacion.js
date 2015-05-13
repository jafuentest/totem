$(document).ready(function () {
    $('#crearMinuta_form')
       .bootstrapValidator({
           message: 'This value is not valid',
           feedbackIcons: {
               valid: 'glyphicon glyphicon-ok',
               invalid: 'glyphicon glyphicon-remove',
               validating: 'glyphicon glyphicon-refresh'
           },
           fields: {
               fechaReunion: {
                   validators: {
                       notEmpty: {
                           message: 'La Fecha es requerida'
                       }
                   }
               },
               motivo: {
                   validators: {
                       notEmpty: {
                           message: 'El motivo es requerido'
                       }
                   }
               },
               puntos: {
                   validators: {
                       notEmpty: {
                           message: 'Los puntos tratados son requeridos'
                       }
                   }
               },
               desarrollo: {
                   validators: {
                       notEmpty: {
                           message: 'El desarrollo de los puntos es requerido'
                       }
                   }
               },
               observaciones: {
                   validators: {
                       notEmpty: {
                           message: 'Las observaciones son requeridas'
                       }
                   }
               },
               compromisos: {
                   validators: {
                       notEmpty: {
                           message: 'Los acuerdos y compromisos son requeridos'
                       }
                   }
               },
               Fecha: {
                   validators: {
                       notEmpty: {
                           message: 'La fecha del compromiso es requerida'
                       }
                   }
               }
           }
       });
});