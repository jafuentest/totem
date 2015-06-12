using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoListarEmpresas
    {
        string laTabla { get; set; }
        string empresa_rif { get; set; }
        string empresa_nombre { get; set; }
    }
}
