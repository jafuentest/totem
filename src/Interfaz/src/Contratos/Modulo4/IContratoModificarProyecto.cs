using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo4
{
    public interface IContratoModificarProyecto
    {
        String codigoProyecto { get; set; }
        String nombreProyecto { get; }
        String descripcionProyecto { get; }
        String monedaProyecto { get; }
        String alertaNombre { get; }
        String alertaCodigo { get; }
    }
}
