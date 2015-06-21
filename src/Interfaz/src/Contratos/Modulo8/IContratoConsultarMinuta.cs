using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo8
{
    public interface IContratoConsultarMinuta
    {
        string laTabla { get; set; }
        string nombreProyecto { get; set; }
        string nombreEmpresa { get; set; }
        string estadoProyecto { get; set; }
    }
}
