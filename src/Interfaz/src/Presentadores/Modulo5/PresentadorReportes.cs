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
    public class PresentadorReportes
    {
        /// <summary>
        /// Presentador de la vista Reportes
        /// </summary>
        private IContratoReportes vista;
        /// <summary>
        /// Contructor del presentador de la vista Reportes
        /// </summary>
        /// <param name="vista">vista la cual usuara el presentador</param>
        public PresentadorReportes(IContratoReportes vista)
        {
            this.vista = vista;
        }
         

    }
}
