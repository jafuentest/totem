using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.UI.WebControls;
using Contratos.Modulo6;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo5;
using Dominio.Entidades.Modulo4;
using Dominio.Fabrica;
using Dominio;
using Comandos; 
using Comandos.Comandos;
using Comandos.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo6.ExcepcionesPresentador;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;

namespace Presentadores.Modulo6
{
   public class PresentadorReporteActores
    {
       private IContratoReporteActores vista;
       List<Entidad> _listaDesdeComando;

       public PresentadorReporteActores(IContratoReporteActores vista) 
       {
           this.vista = vista;        
       }


       /// <summary>
       /// Método que despliega en un ComboBox una lista de actores 
       /// a ser seleccionados para luego mostrarse en una tabla con 
       /// la información de los casos de uso en el que participa. 
       /// </summary>
       public void CargarActores() 
       {
           string codigo = "TOT";
           llenadoComboBoxActor(codigo);
          
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
       /// Método que se encarga de cargar la tabla de casos de uso,
       /// al seleccionar un actor
       /// </summary>
       public void CargarTablaCasosDeUso() 
       {
           int idActor = Convert.ToInt32(vista.comboActores.SelectedValue);
           FabricaEntidades fabrica = new FabricaEntidades();
           Entidad entidadAct = fabrica.ObtenerActor();
           Entidad entidadProy = FabricaEntidades.ObtenerProyecto();

           Actor actor = (Actor)entidadAct;
           
           Proyecto proy = (Proyecto)entidadProy;
           proy.Codigo = "TOT";
           string codigoProy = proy.Codigo;
           actor.Id = idActor;

           actor.ProyectoAsociado = proy;
           actor.ProyectoAsociado.Codigo = codigoProy; 

           try
           {
               Comando<Entidad, List<Entidad>> comandoCasosUsoPorActor =
                        FabricaComandos.CrearComandoConsultarCasosDeUsoXActor();

               List<Entidad> laLista = comandoCasosUsoPorActor.Ejecutar(actor);

               if (laLista != null && laLista.Count > 0)
               {
                   vista.RCasosDeUso.DataSource = laLista;
                   vista.RCasosDeUso.DataBind();
               }
               
/*
               foreach (CasoDeUso caso in laLista)
               {
                   vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTr;
                   vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + caso.IdentificadorCasoUso
                                + RecursosPresentadorModulo6.CerrarEtiquetaTd;
                   vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd + caso.TituloCasoUso
                               + RecursosPresentadorModulo6.CerrarEtiquetaTd;
                   
                   vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd;

                   foreach (Requerimiento req in ListadoDeRequerimientos(caso.Id)) 
                   {
                       vista.tabla += req.Descripcion + "\n"; 
                   }
                   vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTd;
                   vista.tabla += RecursosPresentadorModulo6.AbrirEtiquetaTd;
                   vista.tabla += RecursosPresentadorModulo6.AbrirBotonModificarCasoUso;
                   vista.tabla += RecursosPresentadorModulo6.CerrarBoton;
                   vista.tabla += RecursosPresentadorModulo6.AbrirBotonEliminarCasoUso;
                   vista.tabla += RecursosPresentadorModulo6.CerrarBoton;
                   vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTd; 
                   vista.tabla += RecursosPresentadorModulo6.CerrarEtiquetaTr;
               }*/
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
       /// Método para llenar el Combo box de los países
       /// </summary>
       private void llenadoComboBoxActor(string codigoProyecto)
       {
           try
           {
               List<Actor> actores = CBActor(codigoProyecto);
               ListItem _itemActor;

               vista.comboActores.Items.Clear();

               _itemActor = new ListItem();
               _itemActor.Text = "Seleccione un actor";
               _itemActor.Value = "0";
               vista.comboActores.Items.Add(_itemActor);

               foreach (Actor elActor in actores)
               {
                   _itemActor = new ListItem();
                   _itemActor.Text = elActor.NombreActor;
                   _itemActor.Value = elActor.Id.ToString();
                  vista.comboActores.Items.Add(_itemActor);
               }
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



       /// <summary>
       /// Llama al comando de Llenar CB Actores y retorna la lista de actores para ser llenados en el DropDownList de Actores
       /// </summary>
       /// <param name="parametro">Recibe el código de proyecto</param>
       /// <returns>Lista de Actores</returns>
       private List<Actor> CBActor(string parametro)
       {
           Comando<string, List<Entidad>> comandoLlenarCBActores; 
           try
           {
               comandoLlenarCBActores = FabricaComandos.CrearComandoConsultarActoresCB();
               _listaDesdeComando = comandoLlenarCBActores.Ejecutar(parametro);
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


           return ConvertirListaActores(_listaDesdeComando);
       }



       /// <summary>
       /// Método que recibe una Lista de tipo Entidad y la transforma en una tipo Actor
       /// </summary>
       /// <param name="lista">La lista de tipo Entidad</param>
       /// <returns>Retorna la lista de tipo Actor</returns>
       private List<Actor> ConvertirListaActores(List<Entidad> lista)
       {
           List<Actor> listaActor = new List<Actor>();

           try
           {
               foreach (Actor entidad in lista)
               {
                   listaActor.Add(entidad as Actor);
               }
           }
           catch (NullReferenceException e)
           {
               ObjetoNuloPresentadorException exPresentadorReporteActores = new ObjetoNuloPresentadorException(
                   RecursosPresentadorModulo6.CodigoMensajePresentadorNuloException,
                   RecursosPresentadorModulo6.MensajePresentadorNuloException,e);

               Logger.EscribirError(RecursosPresentadorModulo6.ClaseReporteActoresPresentador,exPresentadorReporteActores);

               MostrarMensajeError(exPresentadorReporteActores.Mensaje);
           }
           catch (Exception e)
           {
               PresentadorException exPresentadorReporteActores = new PresentadorException(
                   RecursosPresentadorModulo6.CodigoMensajePresentadorException,
                   RecursosPresentadorModulo6.MensajePresentadorException, e);

               Logger.EscribirError(RecursosPresentadorModulo6.ClaseReporteActoresPresentador, exPresentadorReporteActores);

               MostrarMensajeError(exPresentadorReporteActores.Mensaje);
           }
           return listaActor;
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
