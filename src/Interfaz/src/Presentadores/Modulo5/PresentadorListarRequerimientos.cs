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
        /// Metodo encargado de listar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">
        /// Codigo del proyecto al cual se quieren obtener los requerimientos
        /// </param>
        public void ListarRequerimientosPorProyecto() {
            HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
            //string codigoProyecto =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
            string codigoProyecto = "TOT"; //Cableado
            Comandos.Comando<String, List<Dominio.Entidad>> comandoListarRequerimientos;
            comandoListarRequerimientos =
                Comandos.Fabrica.FabricaComandos.CrearComandoConsultarRequerimientosProyecto();
            vista.RepeaterRequerimiento.DataSource = 
                comandoListarRequerimientos.Ejecutar(codigoProyecto);
            vista.RepeaterRequerimiento.DataBind();
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
