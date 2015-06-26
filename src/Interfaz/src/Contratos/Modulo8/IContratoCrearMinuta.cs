using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo8
{
    public interface IContratoCrearMinuta
    {
        string FechaMinuta { get; set; }
        string MotivoMinuta { get; set; }
        string Observaciones { get; set; }
        string Involucrados { get; set; }
    }
}
