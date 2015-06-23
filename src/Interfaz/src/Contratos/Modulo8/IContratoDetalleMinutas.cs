using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo8
{
    public interface IContratoDetalleMinutas
    {
        string nombreProyecto { get; set; }
        string fecha { get; set; }
        string motivo { get; set; }
        string participantes { get; set; }
        string puntos { get; set; }
        string observaciones { get; set; }
        string acuerdos { get; set; }
    }
}
