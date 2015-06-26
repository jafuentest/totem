using Dominio;
using Comandos;
using Comandos.Fabrica;
using Dominio.Entidades.Modulo6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo6;
using Presentadores;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Fabrica;
using Comandos.Comandos;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo6.ExcepcionesPresentador;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;

namespace Presentadores.Modulo6
{
    public class PresentadorListarActores
    {

        private IContratoListarActores vista;


        public PresentadorListarActores(IContratoListarActores laVista)
        {
            vista = laVista;
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

        /// <summary>
        /// Método que se ejecuta al recargar la página
        /// </summary>
        public void LimpiarPagina()
        {
            vista.mensajeError.Visible = false;
            vista.mensajeExito.Visible = false;

        }

        public void consultarActores()
        {
            string codigo = "TOT";
            try
            {

                Comando<string, List<Entidad>> comandoListarActores = FabricaComandos.CrearComandoListarActores();

                List<Entidad> laLista = comandoListarActores.Ejecutar(codigo);


                List<Actor> listaRequ = new List<Actor>();


                if (laLista != null && laLista.Count > 0)
                {
                    vista.RActor.DataSource = laLista;
                    vista.RActor.DataBind();
                }


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
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
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
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
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
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }
        }


        /// <summary>
        /// Método que valida y obtiene las variables URL
        /// </summary>
        public void ObtenerVariablesURL()
        {
            string variable = HttpContext.Current.Request.QueryString["success"];

            if (variable != null && variable.Equals("eliminarActor"))
            {
                MostrarMensajeExito(RecursosPresentadorModulo6.MensajeExitoEliminarActor);
            }

            variable = null;
            variable = HttpContext.Current.Request.QueryString["eliminarActor"];
            if (variable != null)
            {
                EliminarActor(variable);
            }

        }



        /// <summary>
        /// Método que elimina un Actor de uso seleccionado
        /// </summary>
        /// <param name="id">Id del Actor</param>
        public void EliminarActor(string id)
        {

            try
            {
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad actor = fabricaEntidades.ObtenerActor();
                actor.Id = Convert.ToInt32(id);
                int idActor = actor.Id;
                Comandos.Comando<int, bool> comandoEliminar;
                comandoEliminar = FabricaComandos.CrearComandoEliminarActor();

                if (comandoEliminar.Ejecutar(idActor))
                {
                    HttpContext.Current.Response.Redirect(
                                   RecursosPresentadorModulo6.VentanaListarActores +
                                   RecursosPresentadorModulo6.CodigoExitoEliminarActor);
                }

                CasoDeUsoInvalidoException exCasoDeUso = new CasoDeUsoInvalidoException(
                    RecursosPresentadorModulo6.CodigoCasoDeUsoInvalidoException,
                    RecursosPresentadorModulo6.MensajeCasoDeUsoInvalido,
                    new CasoDeUsoInvalidoException());
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , exCasoDeUso);

                MostrarMensajeError(exCasoDeUso.Mensaje);

            }
            catch (ComandoBDException e)
            {
                PresentadorException exReporteActoresPresentador =
                        new PresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorBDException,
                            RecursosPresentadorModulo6.MensajePresentadorBDException,
                            e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exReporteActoresPresentador.Mensaje);
            }

            catch (ComandoNullException e)
            {
                ObjetoNuloPresentadorException exReporteActoresPresentador =
                        new ObjetoNuloPresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorNuloException,
                            RecursosPresentadorModulo6.MensajePresentadorNuloException,
                            e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exReporteActoresPresentador.Mensaje);
            }

            catch (TipoDeDatoErroneoComandoException e)
            {
                TipoDeDatoErroneoPresentadorException exReporteActoresPresentador =
                       new TipoDeDatoErroneoPresentadorException(
                           RecursosPresentadorModulo6.CodigoMensajePresentadorTipoDeDatoErroneo,
                           RecursosPresentadorModulo6.MensajePresentadorTipoDeDatoErroneoException,
                           e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exReporteActoresPresentador.Mensaje);

            }

            catch (ComandoException e)
            {
                ErrorGeneralPresentadorException exReporteActoresPresentador =
                         new ErrorGeneralPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exReporteActoresPresentador.Mensaje);
            }
        }


    }
}