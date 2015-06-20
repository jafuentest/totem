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
    public class PresentadorAgregarActor
    {
        private IContratoAgregarActor vista;
        private Actor elActor;

        public PresentadorAgregarActor(IContratoAgregarActor vista)
        {
            this.vista = vista;
        }



        /// <summary>
        /// Método que se ejecuta al recargar la página
        /// </summary>
        public void LimpiarPagina()
        {
            vista.mensajeError.Visible = false;
            vista.mensajeExito.Visible = false;

        }

        /// <summary>
        /// Método que se encarga de la lógica 
        /// al generarse el evento para agregar Actor
        /// </summary>
        public void AgregarActor_Click()
        {

            Entidad entidad = FabricaEntidades.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();
            elActor = entidad as Actor;
            elActor.NombreActor = vista.nombreActor;
            elActor.DescripcionActor = vista.descActor;
            Proyecto proyecto = entidadProy as Proyecto;
            proyecto.Codigo = "TOT";
            elActor.ProyectoAsociado = proyecto;


            if (VerificarActor(elActor.NombreActor))
            {
                MostrarMensajeError(RecursosPresentadorModulo6.MensajeActorExistente);
            }

            else
            {

                try
                {

                    Comandos.Comando<Entidad, bool> comandoAgregarActor =
                    FabricaComandos.CrearComandoAgregarActor();

                    if (comandoAgregarActor.Ejecutar(elActor))
                    {
                        MostrarMensajeExito(RecursosPresentadorModulo6.MensajeExitoAgregarActor);
                        vista.botonAgregar.Disabled = true;
                    }
                }

                catch (AgregarActorComandoBDException e)
                {
                    AgregarActorBDPresentadorException exAgregarActorPresentador =
                            new AgregarActorBDPresentadorException(
                                RecursosPresentadorModulo6.CodigoMensajePresentadorBDException,
                                RecursosPresentadorModulo6.MensajePresentadorBDException,
                                e);
                    Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                        , e);

                    MostrarMensajeError(exAgregarActorPresentador.Mensaje);
                }

                catch (AgregarActorComandoNullException e)
                {
                    AgregarActorNuloPresentadorException exAgregarActorPresentador =
                            new AgregarActorNuloPresentadorException(
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
                catch (AgregarActorComandoException e)
                {
                    AgregarActorPresentadorException exAgregarActorPresentador =
                             new AgregarActorPresentadorException(
                                 RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                                 RecursosPresentadorModulo6.MensajePresentadorException,
                                 e);
                    Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                        , e);

                    MostrarMensajeError(exAgregarActorPresentador.Mensaje);
                }
            }
        }


        /// <summary>
        /// Método que llama al comando para ejecutar la verificación
        /// de la existencia del actor
        /// </summary>
        /// <param name="nombre">Nombre del Actor a verificar</param>
        public bool VerificarActor(string nombre)
        {
            bool existe = false;
            try
            {

                Comandos.Comando<string, bool> comandoVerificarActor =
                FabricaComandos.CrearComandoVerificarActor();

                if (comandoVerificarActor.Ejecutar(nombre))
                {
                    existe = true;

                }
            }

            catch (AgregarActorComandoBDException e)
            {
                AgregarActorBDPresentadorException exAgregarActorPresentador =
                        new AgregarActorBDPresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorBDException,
                            RecursosPresentadorModulo6.MensajePresentadorBDException,
                            e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (AgregarActorComandoNullException e)
            {
                AgregarActorNuloPresentadorException exAgregarActorPresentador =
                        new AgregarActorNuloPresentadorException(
                            RecursosPresentadorModulo6.CodigoMensajePresentadorNuloException,
                            RecursosPresentadorModulo6.MensajePresentadorNuloException,
                            e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }

            catch (TipoDeDatoErroneoComandoException e)
            {
                TipoDeDatoErroneoPresentadorException exAgregarActorPresentador =
                       new TipoDeDatoErroneoPresentadorException(
                           RecursosPresentadorModulo6.CodigoMensajePresentadorTipoDeDatoErroneo,
                           RecursosPresentadorModulo6.MensajePresentadorTipoDeDatoErroneoException,
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

            catch (AgregarActorComandoException e)
            {
                AgregarActorPresentadorException exAgregarActorPresentador =
                         new AgregarActorPresentadorException(
                             RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                             RecursosPresentadorModulo6.MensajePresentadorException,
                             e);
                Logger.EscribirError(RecursosPresentadorModulo6.ClaseAgregarActorPresentador
                    , e);

                MostrarMensajeError(exAgregarActorPresentador.Mensaje);
            }
            return existe;

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



    }
}
