using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Contratos.Modulo5
{

    /// <summary>
    /// Contrato asociado a la vista ListarRequerimiento
    /// </summary>
    public interface IContratoListarRequerimientos
    {

        string IdProyecto { set; get; }
        string EmpresaCliente { set; }
        string Estatus { set; }
        Repeater RepeaterRequerimiento { get; set; }
    }
}
