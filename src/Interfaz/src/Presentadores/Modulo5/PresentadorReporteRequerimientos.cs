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

    }
}
