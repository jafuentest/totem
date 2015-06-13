using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoModificarEmpresa
    {
        string rifEmpresa { get; set; }
        string nombreEmpresa { get; set; }
        string comboPais { get; set; }
        string comboEstado { get; set; }
        string comboCiudad { get; set; }
        string direccionEmpresa { get; set; }
        string codigoPostalEmpresa { get; set; }
        string laTabla { get; set; }
        string contacto_id { get; set; }
        string contacto_nombreyap { get; set; }
    }
}
