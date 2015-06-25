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
            Comandos.Comando<String, Boolean> Comando;
            Comando = Comandos.Fabrica.FabricaComandos.CrearComandoGenerarArchivoLatex();
            Comando.Ejecutar(parametro);
            HttpContext.Current.Response.Redirect("/Modulo5/docs/Requerimientos.pdf");
        
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

    }
}
