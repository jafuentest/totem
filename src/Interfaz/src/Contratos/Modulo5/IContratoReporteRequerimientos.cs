using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Contratos.Modulo5
{
    /// <summary>
    /// Contrato asociado a la vista Reportes
    /// </summary>
    public interface IContratoReporteRequerimientos
    {
        Repeater RepeaterRequerimiento { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
