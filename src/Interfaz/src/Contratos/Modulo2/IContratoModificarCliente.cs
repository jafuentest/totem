using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Contratos.Modulo2
{
    public interface IContratoModificarCliente
    {
        string nombreCliente { get; set; }
        string apellidoCliente { get; set; }
        string cedulaCliente { get; set; }
        DropDownList comboPais { get; set; }
        DropDownList comboEstado { get; set; }
        DropDownList comboCiudad { get; set; }
        string direccionCliente { get; set; }
        string codigoPostalCliente { get; set; }
        string correoCliente { get; set; }
        string codTelefono { get; set; }
        string telefonoCliente { get; set; }
    }
}
