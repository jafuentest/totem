using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo5;
using System.Web;

namespace Presentadores.Modulo5
{
  /// <summary>
  /// Presentador de la vista de reportes
  /// </summary>
    public class PresentadorReporteRequerimientos
    {
        /// <summary>
        /// Presentador de la vista Reportes
        /// </summary>
        private IContratoReporteRequerimientos vista;
        /// <summary>
        /// Contructor del presentador de la vista Reportes
        /// </summary>
        /// <param name="vista">vista la cual usuara el presentador</param>
        public PresentadorReporteRequerimientos(IContratoReporteRequerimientos vista)
        {
            this.vista = vista;
        }

        public void GenerarDoc(String parametro) {
            try
            {
                Comandos.Comando<String, Boolean> Comando;
                Comando = Comandos.Fabrica.FabricaComandos.CrearComandoGenerarArchivoLatex();
                Comando.Ejecutar(parametro);
                HttpContext.Current.Response.Redirect("/Modulo5/docs/Requerimientos.pdf");
            }
            catch (ExcepcionesTotem.Modulo5.ArchivoLatexNoGeneradoException err) {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Archivo_Latext_NoGenerado+
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch(ExcepcionesTotem.Modulo5.ArchivoInexistenteException){
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Archivo_Latext_NoGenerado +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo5.CamposInvalidosException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_BaseDatos +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Invalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (Exception e)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }

        }
        public void ListarRequerimientosPorProyecto()
        {
            try
            {
                HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
                //string codigoProyecto =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
                string codigoProyecto = "TOT"; //Cableado
                Comandos.Comando<String, List<Dominio.Entidad>> comandoListarRequerimientos;
                comandoListarRequerimientos =
                    Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimientosProyecto();
                List<Dominio.Entidad> listaRequerimientos = comandoListarRequerimientos.Ejecutar(codigoProyecto);
                if (listaRequerimientos != null && listaRequerimientos.Count > 0)
                {
                    vista.RepeaterRequerimiento.DataSource = listaRequerimientos;
                    vista.RepeaterRequerimiento.DataBind();
                }
                else
                {
                    vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Info;
                    vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                    vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Info_No_Hay_Requerimientos +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
                }
            }
            #region Mensajes de Error
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_BaseDatos +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (Exception e)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            #endregion
        }


        public void ObtenerVariablesURL()
        {
            string variable = HttpContext.Current.Request.QueryString["error"];
            if (variable != null && variable.Equals("input_malicioso"))
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            variable = HttpContext.Current.Request.QueryString["success"];
            if (variable != null && variable.Equals("agregar"))
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Exito;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Agregado +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            if (variable != null && variable.Equals("modificar"))
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Exito;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Modificado +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            if (variable != null && variable.Equals("eliminar"))
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Exito;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Eliminado +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            variable = null;
            variable = HttpContext.Current.Request.QueryString["eliminar"];
            if (variable != null)
            {
                EliminarRequerimiento(variable);
            }
        }

        public void EliminarRequerimiento(string codigo)
        {
            try
            {
                Dominio.Fabrica.FabricaEntidades fabricaEntidades =
                    new Dominio.Fabrica.FabricaEntidades();
                Dominio.Entidad requerimiento =
                    fabricaEntidades.ObtenerRequerimiento(codigo);
                Comandos.Comando<Dominio.Entidad, bool> comandoEliminar;
                comandoEliminar = Comandos.Fabrica.FabricaComandos.CrearComandoEliminarRequerimiento();
                if (comandoEliminar.Ejecutar(requerimiento))
                {
                    HttpContext.Current.Response.Redirect(
                                RecursosPresentadorModulo5.Ventana_Reporte_Requerimiento +
                                RecursosPresentadorModulo5.Codigo_Exito_Eliminar);

                }

                throw new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException(
                        RecursosPresentadorModulo5.Codigo_Error_Requerimiento_Errado,
                        RecursosPresentadorModulo5.Mensaje_Error_Requerimiento_Errado,
                        new ExcepcionesTotem.Modulo5.RequerimientoInvalidoException());
            }
            #region Capturar Excepcion
            catch (ExcepcionesTotem.Modulo5.CamposInvalidosException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_BaseDatos +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Requerimiento_Invalido +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            catch (Exception e)
            {
                vista.alertaClase = RecursosPresentadorModulo5.Alerta_Clase_Error;
                vista.alertaRol = RecursosPresentadorModulo5.Alerta_Rol;
                vista.alerta = RecursosPresentadorModulo5.Alerta_Html +
                    RecursosPresentadorModulo5.Alerta_Mensaje_Error_General +
                    RecursosPresentadorModulo5.Alerta_Html_Final;
            }
            #endregion
        }

    }
}
