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
                HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
                //string codigoProyecto =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
                string codigoProyecto = "TOT"; //Cableado
                Comandos.Comando<String, List<Dominio.Entidad>> comandoListarRequerimientos;
                comandoListarRequerimientos =
                    Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimientosProyecto();
                List<Dominio.Entidad> listaRequerimientos = comandoListarRequerimientos.Ejecutar(codigoProyecto);
                vista.RepeaterRequerimiento.DataSource = listaRequerimientos;
                vista.RepeaterRequerimiento.DataBind();
                EstatusDelProyecto(listaRequerimientos);
            }
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
        }

        /// <summary>
        /// Metodo que calcula el porcentaje de finalizado del proyecto
        /// </summary>
        /// <param name="requerimientos">Lista de requirimentos del proyecto</param>
        public void EstatusDelProyecto(List<Dominio.Entidad> requerimientos)
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
            vista.Estatus = "Porcentaje Finalizado: " + 
                ((int)Math.Round((double)(100 * requerimientosFinalizados) / requerimientos.Count)).ToString()
                + "%";
        }
        /// <summary>
        /// Metodo encargado de eliminar un requerimiento particular
        /// </summary>
        public void EliminarRequerimiento() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de modificar un requerimiento particular
        /// </summary>
        public void ModificarRequerimiento() {

            throw new NotImplementedException();
        
        }
    }
}
