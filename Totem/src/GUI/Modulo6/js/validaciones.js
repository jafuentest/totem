$(document).ready(function ()
{
	$('#form_casodeuso').bootstrapValidator(
	{
		feedbackIcons:
		{
       		valid: 'glyphicon glyphicon-ok',
       		invalid: 'glyphicon glyphicon-remove',
       		validating: 'glyphicon glyphicon-refresh'
		},
		fields:
		{
       		nombre: {
       			validators: {
       				notEmpty: {
       					message: 'Debe especificar el nombre del caso de uso'
       				}
       			}
       		},
       		precondicion_0: {
       			validators: {
       				notEmpty: {
       					message: 'Debe ingresar al menos una pre-condición'
       				}
       			}
       		},
       		condicionExito: {
       			validators: {
       				notEmpty: {
       					message: 'Debe especificar la condición de éxito'
       				}
       			}
       		},
       		condicionFallo: {
       			validators: {
       				notEmpty: {
       					message: 'Debe especificar la condición de fallo'
       				}
       			}
       		},
       		escenario_0: {
       			validators: {
       				notEmpty: {
       					message: 'Debe ingresar al menos un paso en el escenario principal de éxito'
       				}
       			}
       		},
		}
	});
	$('#form_actor').bootstrapValidator(
	{
		feedbackIcons:
		{
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields:
		{
			nombre: {
				validators: {
					notEmpty: {
						message: 'Debe especificar el nombre del actor'
					}
				}
			},
			descripcion: {
				validators: {
					notEmpty: {
						message: 'Debe especificar la descripción del actor'
					}
				}
			},
		}
	});
});