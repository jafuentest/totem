using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo5
{

    /// <summary>
    /// Contrato asociado a la vista ListarRequerimiento
    /// </summary>
    public interface IContratoListar
    {

        string IdProyecto { set; get; }
        string EmpresaCliente { set; }
        string Estatus { set; }
    }
}
