using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contratos.Modulo6;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo5;
using Dominio.Fabrica;
using Dominio;
using Comandos;
using Comandos.Comandos;
using Comandos.Comandos.Modulo6;
using Comandos.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo6.ExcepcionesPresentador;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;

namespace Presentadores.Modulo6
{
    public class PresentadorListar
    {
        private IContratoListar vista;

        public PresentadorListar(IContratoListar vista)
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


        /// <summary>
        /// Método encargado de desplegar la lista de Casos de Uso
        /// según el proyecto seleccionado
        /// </summary>
        public void CargarListaCasosDeUso()
        {
            string codigo = "TOT";

            try
            {
                Comando<string, List<Entidad>> comandoListarCU =
                        FabricaComandos.CrearComandoListarCU();

                List<Entidad> laLista = comandoListarCU.Ejecutar(codigo);


               
                if (laLista != null && laLista.Count > 0)
                {
                    vista.RCasosDeUso.DataSource = laLista;
                    vista.RCasosDeUso.DataBind();
                }



                /*+= RecursosPresentadorModulo6.AbrirEtiquetaTr;
            vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + caso.IdentificadorCasoUso
                         + RecursosPresentadorModulo6.CerrarEtiquetaTd;
            vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + caso.TituloCasoUso
                        + RecursosPresentadorModulo6.CerrarEtiquetaTd;
                   
            vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd;*/
                /*
                foreach (string actor in ListadoActores(caso.Id)) 
                {
                    vista.tabla += actor + "\n"; 
                }
                vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTd;

                vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd;

                foreach (Requerimiento req in ListadoDeRequerimientos(caso.Id))
                {
                    vista.tabla += req.Descripcion + "\n";
                }
                vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTd;

                vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd;
                vista.tabla += RecursosPresentadorModulo6.AbrirBotonModificarCasoUso;
                vista.tabla += RecursosPresentadorModulo6.CerrarBotonModificar;
                vista.tabla += RecursosPresentadorModulo6.AbrirBotonEliminarCasoUso;
                    
                   
                    
                vista.tabla += RecursosPresentadorModulo6.CerrarBotonEliminar;
                vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTd;
                vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTr;*/

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
        /// Método que llama a Comando para traer la lista de actores
        /// por caso de uso
        /// </summary>
        /// <param name="idCasoUso">Id del Caso de Uso</param>
        /// <returns>Lista de Nombre de los Actores</returns>
        public List<string> ListadoActores(int idCasoUso)
        {
            List<string> listaActores = new List<string>();

            try
            {
                Comando<int, List<string>> comandoListarActores =
                   FabricaComandos.CrearComandoConsultarActoresXCasoDeUso();
                listaActores = comandoListarActores.Ejecutar(idCasoUso);
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
            return listaActores;
        }


        /// <summary>
        /// Método que llama a Comando para traer la lista de requerimientos
        /// por caso de uso
        /// </summary>
        /// <param name="id">Id del Caso de Uso</param>
        /// <returns>Lista de Requerimientos</returns>
        public List<Entidad> ListadoDeRequerimientos(int id)
        {
            List<Entidad> listaReqs = new List<Entidad>(); ;
            try
            {
                Comando<int, List<Entidad>> comandoListarReqsCasoUso =
                    FabricaComandos.CrearComandoConsultarRequerimientosXCasoDeUso();
                listaReqs = comandoListarReqsCasoUso.Ejecutar(id);
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
            return listaReqs;

        }
        /// <summary>
        /// Método que valida y obtiene las variables URL
        /// </summary>
        public void ObtenerVariablesURL()
        {
            string variable = HttpContext.Current.Request.QueryString["success"];

            if (variable != null && variable.Equals("eliminar"))
            {
                MostrarMensajeExito(RecursosPresentadorModulo6.MensajeCasoDeUsoEliminado);
            }

            variable = null;
            variable = HttpContext.Current.Request.QueryString["eliminar"];
            if (variable != null)
            {
                EliminarCasoDeUso(variable);
            }

        }


        /// <summary>
        /// Método que elimina un caso de uso seleccionado
        /// </summary>
        /// <param name="id">Id del Caso de Uso</param>
        public void EliminarCasoDeUso(string id)
        {

            try
            {
                FabricaEntidades fabricaEntidades =
                        new FabricaEntidades();
                Entidad casoDeUso =
                    fabricaEntidades.ObtenerCasoDeUso();
                casoDeUso.Id = Convert.ToInt32(id);
                int idCaso = casoDeUso.Id;
                Comandos.Comando<int, bool> comandoEliminar;
                comandoEliminar = FabricaComandos.CrearComandoEliminarCU();

                if (comandoEliminar.Ejecutar(idCaso))
                {
                    HttpContext.Current.Response.Redirect(
                                   RecursosPresentadorModulo6.VentanaListarCasosDeUso +
                                   RecursosPresentadorModulo6.Codigo_Exito_Eliminar);
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
