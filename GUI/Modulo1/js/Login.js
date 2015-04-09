$(document).ready(function () {
    $('#login_form')
       .bootstrapValidator({
           message: 'This value is not valid',
           feedbackIcons: {
               valid: 'glyphicon glyphicon-ok',
               invalid: 'glyphicon glyphicon-remove',
               validating: 'glyphicon glyphicon-refresh'
           },
           fields: {
               usuario: {
                   validators: {
                       notEmpty: {
                           message: 'El usuario no debe estar vacío'
                       }
                   }
               },
               password: {
                   validators: {
                       notEmpty: {
                           message: 'La contrase&ntilde;a es requerida'
                       }
                   }
               },
           }
       });
});