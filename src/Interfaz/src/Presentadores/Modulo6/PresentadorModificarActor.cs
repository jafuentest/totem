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
            string elId = HttpContext.Current.Request.QueryString["id"];
            int idAct = Convert.ToInt32(elId); 
            FabricaEntidades fabrica = new FabricaEntidades(); 
            Entidad laEnti = fabrica.ObtenerActor(); 
            Actor elActor = (Actor)laEnti;
            elActor.Id = idAct; 
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
            #region Captura de Excepciones
            catch (ComandoBDException e)
            {
                PresentadorException exAgregarActorPresentador =
                        new PresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorBDException,
                            RecursosPresentadorModulo6.MensajePresentadorBDException,
                            e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (ComandoNullException e)
            {
                ObjetoNuloPresentadorException exAgregarActorPresentador =
                        new ObjetoNuloPresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorNuloException,
                            RecursosPresentadorModulo6.MensajePresentadorNuloException,
                            e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (HttpRequestValidationException e)
            {
                CaracteresMaliciososException exAgregarActorPresentador =
                        new CaracteresMaliciososException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorMalicioso,
                            RecursosPresentadorModulo6.MensajeCodigoMaliciosoException,
                            e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);

            }
            catch (ComandoException e)
            {
                ErrorGeneralPresentadorException exAgregarActorPresentador =
                         new ErrorGeneralPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (Exception e)
            {
                ErrorGeneralPresentadorException exAgregarActorPresentador =
                         new ErrorGeneralPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }
#endregion

        }

       /// <summary>
       /// Método que llama al comando para modificar los datos de un actor
       /// </summary>
        public void ModificarDatos() 
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad laEnti = fabrica.ObtenerActor();
            Actor elActor = (Actor)laEnti;
            string id = HttpContext.Current.Request.QueryString["id"];
            int idActor = Convert.ToInt32(id);
            elActor.Id = idActor; // falta pasarle el id por la variable de sesión proveniente de lista actores
            elActor.NombreActor = vista.nombreActor;
            elActor.DescripcionActor = vista.descActor;
            try
            {
                Comandos.Comando<Entidad, bool> comandoModificar =
                   FabricaComandos.CrearComandoModificarActor();
                if (comandoModificar.Ejecutar(elActor))
                {
                    string paginaOrigen = HttpContext.Current.Request.QueryString["list"];
                    if (paginaOrigen.Equals("true"))
                    {
                        HttpContext.Current.Session["modificar"] = "modificado";
                        HttpContext.Current.Response.Redirect(
                               RecursosPresentadorModulo6.VentanaListarActores);
                    }
                }
                else
                {
                    throw new ActorNoModificadoPresentadorException(
                        RecursosPresentadorModulo6.CodigoActorNoModificado,
                        RecursosPresentadorModulo6.MensajeActorNoModificado,
                        new ActorNoModificadoPresentadorException());
                }
             }

            
            #region Captura de Excepciones

            catch (ActorNoModificadoPresentadorException e) 
            {
                
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(e.Mensaje); 
            }
            catch (ActorNoModificadoComandoException e)
            {
                ActorNoModificadoPresentadorException exAgregarActorPresentador =
                        new ActorNoModificadoPresentadorException(
                            RecursosPresentadorModulo6.CodigoActorNoModificado,
                            RecursosPresentadorModulo6.MensajeActorNoModificado,
                            e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (ComandoBDException e)
            {
                PresentadorException exAgregarActorPresentador =
                        new PresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorBDException,
                            RecursosPresentadorModulo6.MensajePresentadorBDException,
                            e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (ComandoNullException e)
            {
                ObjetoNuloPresentadorException exAgregarActorPresentador =
                        new ObjetoNuloPresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorNuloException,
                            RecursosPresentadorModulo6.MensajePresentadorNuloException,
                            e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (HttpRequestValidationException e)
            {
                CaracteresMaliciososException exAgregarActorPresentador =
                        new CaracteresMaliciososException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorMalicioso,
                            RecursosPresentadorModulo6.MensajeCodigoMaliciosoException,
                            e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);

            }
            catch (ComandoException e)
            {
                ErrorGeneralPresentadorException exAgregarActorPresentador =
                         new ErrorGeneralPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (Exception e)
            {
                ErrorGeneralPresentadorException exAgregarActorPresentador =
                         new ErrorGeneralPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(this.GetType().Name
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }
            #endregion
        }



    }
}
