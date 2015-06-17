using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo7;
using Comandos.Fabrica;
using Comandos.Comandos.Modulo7;
using Dominio.Entidades.Modulo7;
using Dominio;
using Comandos;
using Dominio.Fabrica;

namespace Presentadores.Modulo7
{
    public class PresentadorAgregarUsuario
    {
        private IContratoAgregarUsuario vista;

        public PresentadorAgregarUsuario(IContratoAgregarUsuario vista)
        {
            this.vista = vista;
        }

        public bool AgregarUsuario()
        {
            // Instanciamos la entidad Usuario a traves de su fabrica
            Entidad Usuario = FabricaEntidades.ObtenerUsuario(vista.username,vista.clave,vista.nombreUsuario,
                vista.apellidoUsuario,vista.rolUsuario,vista.correoUsuario,vista.preguntaUsuario,vista.respuestaUsuario,
                vista.cargoUsuario);

            //Instanciamos el comando agregarUsuario a traves de la fabrica
            Comando<Entidad, bool> agregarUsuario = FabricaComandos.CrearComandoAgregarUsuario();

            //Realizamos la operacion y retornamos la respuesta
            bool exito = agregarUsuario.Ejecutar(Usuario);

            //Retornamos la respuesta
            return exito;
        }
    }
}
