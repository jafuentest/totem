using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Contratos.Modulo2
{
    public interface IContratoAgregarEmpresa
    {
        string rifEmpresa { get; set; }
        string nombreEmpresa { get; set; }
        DropDownList comboPais { get; set; }
        DropDownList comboEstado { get; set; }
        DropDownList comboCiudad { get; set; }
        string direccionEmpresa { get; set; }
        string codigoPostalEmpresa { get; set; }
        string cedulaContacto { get; set; }
        string nombreContacto { get; set; }
        string apellidoContacto { get; set; }
        DropDownList comboCargo { get; set; }
        string codTelefono { get; set; }
        string telefonoCliente { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
