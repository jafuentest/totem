$(document).ready(function () {
    $('#register_form')
       .bootstrapValidator({
           message: 'This value is not valid',
           feedbackIcons: {
               valid: 'glyphicon glyphicon-ok',
               invalid: 'glyphicon glyphicon-remove',
               validating: 'glyphicon glyphicon-refresh'
           },
           fields: {
               codigo: {
                   validators: {
                       notEmpty: {
                           message: 'El codigo es requerido'
                       },
                       regexp: {
                           regexp: /^[ña-zA-Z0-9Ñ]{3}$/,
                           message: 'El codigo del proyecto solo puede ser alfanumerico'
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
               descripcion: {
                   message: 'Por favor introduzca una breve descripcion del Proyecto',
                   validators: {
                       notEmpty: {
                           message: 'Por favor introduzca una breve descripcion del Proyecto'
                       }
                   }
               }
           }
       });
});