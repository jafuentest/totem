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
               usuario: {
                   message: 'El nombre de usuario no es valido',
                   validators: {
                       notEmpty: {
                           message: 'El nombre de usuario es requerido'
                       },
                       /*remote: {
                           url: 'remote.php',
                           message: 'The username is not available'
                       },*/
                       regexp: {
                           regexp: /^[a-zA-Z0-9_\.]+$/,
                           message: 'El nombre de usuario solo puede tener letras del abecedario, numeros, piso o punto'
                       }
                   }
               },
               correo: {
                   validators: {
                       notEmpty: {
                           message: 'El correo electr&oacute;nico es requerido'
                       },
                       emailAddress: {
                           message: 'No es un correo electr&oacute;nico v&aacute;lido'
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
               confirm_password: {
                   validators: {
                       notEmpty: {
                           message: 'Se requiere confirmar la contrse&ntilde;a'
                       },
                       identical: {
                           field: 'password',
                           message: 'Las contrase&ntilde;as no coinciden'
                       }
                   }
               },
               cargo: {
                   validators: {
                       notEmpty: {
                           message: 'El cargo es requerido'
                       }
                   }
               },
               pregunta: {
                   validators: {
                       notEmpty: {
                           message: 'La pregunta de recuperaci&oacute;n es requerida'
                       }
                   }
               },
               respuesta: {
                   validators: {
                       notEmpty: {
                           message: 'La respuesta a la pregunta de recuperaci&oacute;n es requerida'
                       }
                   }
               },
           }
       });
    $('#detalle-form')
       .bootstrapValidator({
           message: 'This value is not valid',
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
               usuario: {
                   message: 'El nombre de usuario no es valido',
                   validators: {
                       notEmpty: {
                           message: 'El nombre de usuario es requerido'
                       },
                       /*remote: {
                           url: 'remote.php',
                           message: 'The username is not available'
                       },*/
                       regexp: {
                           regexp: /^[a-zA-Z0-9_\.]+$/,
                           message: 'El nombre de usuario solo puede tener letras del abecedario, numeros, piso o punto'
                       }
                   }
               },
               correo: {
                   validators: {
                       notEmpty: {
                           message: 'El correo electr&oacute;nico es requerido'
                       },
                       emailAddress: {
                           message: 'No es un correo electr&oacute;nico v&aacute;lido'
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
               confirm_password: {
                   validators: {
                       notEmpty: {
                           message: 'Se requiere confirmar la contrse&ntilde;a'
                       },
                       identical: {
                           field: 'password',
                           message: 'Las contrase&ntilde;as no coinciden'
                       }
                   }
               },
               cargo: {
                   validators: {
                       notEmpty: {
                           message: 'El cargo es requerido'
                       }
                   }
               },
               pregunta: {
                   validators: {
                       notEmpty: {
                           message: 'La pregunta de recuperaci&oacute;n es requerida'
                       }
                   }
               },
               respuesta: {
                   validators: {
                       notEmpty: {
                           message: 'La respuesta a la pregunta de recuperaci&oacute;n es requerida'
                       }
                   }
               },
           }
       });
    $('#pswd-form')
      .bootstrapValidator({
          message: 'This value is not valid',
          excluded: [':disabled'],
          feedbackIcons: {
              valid: 'glyphicon glyphicon-ok',
              invalid: 'glyphicon glyphicon-remove',
              validating: 'glyphicon glyphicon-refresh'
          },
          fields: {            
              pswdviejo: {
                  validators: {
                      notEmpty: {
                          message: 'La contrase&ntilde;a vieja es requerida'
                      }
                  }
              },
              pswdnuevo: {
                  validators: {
                      notEmpty: {
                          message: 'La contrase&ntilde;a nueva es requerida'
                      }
                  }
              },
              pswdnuevoconf: {
                  validators: {
                      notEmpty: {
                          message: 'Se requiere confirmar la contrse&ntilde;a'
                      },
                      identical: {
                          field: 'pswdnuevo',
                          message: 'Las contrase&ntilde;as no coinciden'
                      }
                  }
              }
          }
      });
});