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
                Comando<string, List<Entidad>> comandoListarActores =
                    FabricaComandos.CrearComandoListarActores();

                List<Entidad> laLista = comandoListarActores.Ejecutar(codigo);

                foreach (Actor elActor in laLista)
                {
                    /// Atributos que vienen de la vistaconsultaractores

                    vista.laTabla += RecursosPresentadorModulo6.AbrirEtiquetaTr;
                    vista.laTabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + elActor.Id
                        + RecursosPresentadorModulo6.CerrarEtiquetaTd;
                    vista.laTabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + elActor.NombreActor
                        + RecursosPresentadorModulo6.CerrarEtiquetaTd;
                    vista.laTabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + elActor.DescripcionActor
                       + RecursosPresentadorModulo6.CerrarEtiquetaTd;


                    /// acciones permitidas para un actor en especifico

                    vista.laTabla += RecursosPresentadorModulo6.AbrirEtiquetaTd;
                    vista.laTabla += RecursosPresentadorModulo6.AbrirBotonModificarCasoUso +
                        RecursosPresentadorModulo6.CerrarBoton;

                    vista.laTabla += RecursosPresentadorModulo6.AbrirBotonEliminarCasoUso +
                        RecursosPresentadorModulo6.CerrarBoton;
                    vista.laTabla += RecursosPresentadorModulo6.CerrarEtiquetaTd;
                    vista.laTabla += RecursosPresentadorModulo6.CerrarEtiquetaTr;
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
    }
}