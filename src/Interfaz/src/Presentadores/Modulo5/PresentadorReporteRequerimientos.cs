using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo5;

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
         

    }
}
