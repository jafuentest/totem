using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoModificarCliente
    {
        string nombreCliente { get; set; }
        string apellidoCliente { get; set; }
        string cedulaCliente { get; set; }
        string comboPais { get; set; }
        string comboEstado { get; set; }
        string comboCiudad { get; set; }
        string direccionCliente { get; set; }
        string codigoPostalCliente { get; set; }
        string correoCliente { get; set; }
        string codTelefono { get; set; }
        string telefonoCliente { get; set; }
    }
}
