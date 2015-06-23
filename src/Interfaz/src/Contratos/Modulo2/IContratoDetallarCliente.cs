using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoDetallarCliente
    {
        string nombreCliente { get; set; }
        string apellidoCliente { get; set; }
        string cedulaCliente { get; set; }
        string pais { get; set; }
        string estado { get; set; }
        string ciudad { get; set; }
        string direccion { get; set; }
        string codpostal { get; set; }
        string correocliente { get; set; }
        string telefono { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
