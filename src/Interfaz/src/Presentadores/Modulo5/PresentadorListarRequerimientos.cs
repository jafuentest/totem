using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo5;
using System.Web;

namespace Presentadores.Modulo5
{
   /// <summary>
   /// Presentadorla de vista ListarRequerimiento 
   /// </summary>
    public class PresentadorListarRequerimientos
    {
        /// <summary>
        /// Vista asociada al presentador
        /// </summary>
        private IContratoListarRequerimientos vista;
        /// <summary>
        /// Constructor del presentador de la vista ListarContratos
        /// </summary>
        /// <param name="vista">vista la cual usuara el presentador</param>
        public PresentadorListarRequerimientos(IContratoListarRequerimientos vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo que valida y obtiene las variables de URL
        /// </summary>
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
        /// <summary>
        /// Metodo encargado de listar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">
        /// Codigo del proyecto al cual se quieren obtener los requerimientos
        /// </param>
        public void ListarRequerimientosPorProyecto() {
            try
            {
               
                string codigoProyecto = 
                    HttpContext.Current.Session[RecursosPresentadorModulo5.LProyectoCodigo].ToString();
                vista.IdProyecto = RecursosPresentadorModulo5.Texto_Nombre_Proyecto +
                    HttpContext.Current.Session[RecursosPresentadorModulo5.LProyectoNombre].ToString();
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
                EstatusDelProyecto(listaRequerimientos);
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

        /// <summary>
        /// Metodo que calcula el porcentaje de finalizado del proyecto
        /// </summary>
        /// <param name="requerimientos">Lista de requirimentos del proyecto</param>
        public void EstatusDelProyecto(List<Dominio.Entidad> requerimientos)
        {
            if (requerimientos.Count > 0)
            {
                int requerimientosFinalizados = 0;
                foreach (Dominio.Entidad entidad in requerimientos)
                {
                    Dominio.Entidades.Modulo5.Requerimiento requerimiento =
                        (Dominio.Entidades.Modulo5.Requerimiento)entidad;
                    if (requerimiento.Estatus.Equals("finalizado",
                        StringComparison.InvariantCultureIgnoreCase))
                    {
                        requerimientosFinalizados++;
                    }
                }
                vista.Estatus = RecursosPresentadorModulo5.Porcentaje_Realizado +
                    ((int)Math.Round((double)(100 * requerimientosFinalizados) / requerimientos.Count)).ToString()
                    + RecursosPresentadorModulo5.Simbolo_Porcentaje;
            }
            else
            {
                vista.Estatus = RecursosPresentadorModulo5.Porcentaje_Realizado + 
                RecursosPresentadorModulo5.Porcentaje_Cero; 
            }
        }
        /// <summary>
        /// Metodo encargado de eliminar un requerimiento particular
        /// </summary>
        public void EliminarRequerimiento(string codigo) {
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
                                    RecursosPresentadorModulo5.Ventana_Listar_Requerimiento +
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
