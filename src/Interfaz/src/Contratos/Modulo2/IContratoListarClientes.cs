using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoListarClientes
    {
        string laTabla { get; set; }
        string cliente_cedula { get; set; }
        string cliente_nombreyap { get; set; }
    }
}
