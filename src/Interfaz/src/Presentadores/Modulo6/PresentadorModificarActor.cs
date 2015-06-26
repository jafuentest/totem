using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo6;
using Presentadores;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Dominio.Fabrica;
using Dominio;
using Comandos.Comandos;
using Comandos.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo6.ExcepcionesPresentador;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;

namespace Presentadores.Modulo6
{
   public class PresentadorModificarActor
    {
       private IContratoModificarActor vista;
        private Actor elActor;

        public PresentadorModificarActor(IContratoModificarActor vista)
        {
            this.vista = vista;
        }


        /// <summary>
        /// Método que se ejecuta para desplegar un mensaje de 
        /// éxito por pantalla
        /// </summary>
        /// <param name="mensaje"></param>
        public void MostrarMensajeExito(string mensaje)
        {
            vista.mensajeExito.Visible = true;
            vista.mensajeExito.Text = mensaje;
        }


        /// <summary>
        /// Método que se ejecuta para desplegar un mensaje de error 
        /// por pantalla. 
        /// </summary>
        /// <param name="mensaje"></param>
        public void MostrarMensajeError(string mensaje)
        {
            vista.mensajeError.Visible = true;
            vista.mensajeError.Text = mensaje;
        }

        public void CargarDatosActor() 
        {
            FabricaEntidades fabrica = new FabricaEntidades(); 
            Entidad laEnti = fabrica.ObtenerActor(); 
            Actor elActor = (Actor)laEnti; 
            elActor.Id=1; 
            try
            {
                Comandos.Comando<Entidad, Entidad> comandoConsultar =
                    FabricaComandos.CrearComandoConsultarActorXID();
                Entidad entidad = comandoConsultar.Ejecutar(elActor);

                if (entidad != null) 
                {
                    Actor actorADesplegar = (Actor)entidad;
                    vista.nombreActor = actorADesplegar.NombreActor;
                    vista.descActor = actorADesplegar.DescripcionActor; 
                }
                
            }
            catch(Exception e)
            {
                throw e; 
            }

        }

        public void ModificarDatos() 
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad laEnti = fabrica.ObtenerActor();
            Actor elActor = (Actor)laEnti;
            elActor.Id = 1;
            elActor.NombreActor = vista.nombreActor;
            elActor.DescripcionActor = vista.descActor;
            try
            {
                Comandos.Comando<Entidad, bool> comandoModificar =
                   FabricaComandos.CrearComandoModificarActor();
                bool modifico = comandoModificar.Ejecutar(elActor);
                if (modifico) 
                {
                    MostrarMensajeExito(RecursosPresentadorModulo6.MensajeExitoModificarActor);
                }
            }
            catch (Exception e) 
            {
                ErrorGeneralPresentadorException exAgregarActorPresentador =
                         new ErrorGeneralPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }
        }

    }
}
