using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Contratos.Modulo2
{
    public interface IContratoModificarEmpresa
    {
        string rifEmpresa { get; set; }
        string nombreEmpresa { get; set; }
        DropDownList comboPais { get; set; }
        DropDownList comboEstado { get; set; }
        DropDownList comboCiudad { get; set; }
        string direccionEmpresa { get; set; }
        string codigoPostalEmpresa { get; set; }
        string laTabla { get; set; }
        string contacto_id { get; set; }
        string contacto_nombreyap { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
