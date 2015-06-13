using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo5;

namespace Presentadores.Modulo5
{
   /// <summary>
   /// Presentadorla de vista ListarRequerimiento 
   /// </summary>
    public class PresentadorListarRequerimiento
    {
        /// <summary>
        /// Vista asociada al presentador
        /// </summary>
        public IContratoListarRequerimientos vista;
        /// <summary>
        /// Constructor del presentador de la vista ListarContratos
        /// </summary>
        /// <param name="vista">vista la cual usuara el presentador</param>
        public PresentadorListarRequerimiento(IContratoListarRequerimientos vista)
        {
            this.vista = vista;
        }
        /// <summary>
        /// Metodo encargado de listar los requerimientos de un proyecto
        /// </summary>
        /// <param name="codigo">
        /// Codigo del proyecto al cual se quieren obtener los requerimientos
        /// </param>
        public void ListarRequerimientosPorProyecto(String codigo) {
            throw new NotImplementedException();
        }
    }
}
