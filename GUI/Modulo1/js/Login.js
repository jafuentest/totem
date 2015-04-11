$(document).ready(function () {
    $('#login')
       .bootstrapValidator({
           message: 'This value is not valid',
           feedbackIcons: {
               valid: 'glyphicon glyphicon-ok',
               invalid: 'glyphicon glyphicon-remove',
               validating: 'glyphicon glyphicon-refresh'
           },
           fields: {
               usuario: {
                   message: 'El nombre de usuario no es valido',
                   validators: {
                       notEmpty: {
                           message: 'El nombre de usuario es requerido'
                       },
                      
                       regexp: {
                           regexp: /^[a-zA-Z0-9_\.]+$/,
                           message: 'El nombre de usuario solo puede tener letras del abecedario, numeros, piso o punto'
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
    $('#recuperarClave')
      .bootstrapValidator({
          message: 'This value is not valid',
          feedbackIcons: {
              valid: 'glyphicon glyphicon-ok',
              invalid: 'glyphicon glyphicon-remove',
              validating: 'glyphicon glyphicon-refresh'
          },
          fields: {
              claveNueva: {
                  validators: {
                      notEmpty: {
                          message: 'La contrase&ntilde;a es requerida'
                      }
                  }
              },
              confirmaClaveNueva: {
                  validators: {
                      notEmpty: {
                          message: 'Se requiere confirmar la contrse&ntilde;a'
                      },
                      identical: {
                          field: 'claveNueva',
                          message: 'Las contrase&ntilde;as no coinciden'
                      }
                  }
              },
          }
      });
    $('#preguntaSeguridad')
      .bootstrapValidator({
          message: 'This value is not valid',
          feedbackIcons: {
              valid: 'glyphicon glyphicon-ok',
              invalid: 'glyphicon glyphicon-remove',
              validating: 'glyphicon glyphicon-refresh'
          },
          fields: {
              respuestaSeguridad: {
                  validators: {
                      notEmpty: {
                          message: 'La respuesta a la pregunta de recuperaci&oacute;n es requerida'
                      }
                  }
              },
          }
      });

    $('#ingresoCorreo')
      .bootstrapValidator({
          message: 'This value is not valid',
          feedbackIcons: {
              valid: 'glyphicon glyphicon-ok',
              invalid: 'glyphicon glyphicon-remove',
              validating: 'glyphicon glyphicon-refresh'
          },
          fields: {
              correo: {
                  validators: {
                      notEmpty: {
                          message: 'El correo es requerido'
                      },
                      emailAddress: {
                          message: 'No es un correo electr&oacute;nico v&aacute;lido'
                      }
                  }
              },
          }
      });
    
  });