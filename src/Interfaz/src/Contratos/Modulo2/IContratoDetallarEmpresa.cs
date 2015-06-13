using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoDetallarEmpresa
    {
        string rifEmpresa { get; set; }
        string nombreEmpresa { get; set; }
        string paisEmpresa { get; set; }
        string estadoEmpresa { get; set; }
        string ciudadEmpresa { get; set; }
        string direccionEmpresa { get; set; }
        string codigoPostal { get; set; }
        string laTabla { get; set; }
    }
}
