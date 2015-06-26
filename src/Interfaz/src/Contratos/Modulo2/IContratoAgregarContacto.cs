using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Contratos.Modulo2
{
    public interface IContratoAgregarContacto
    {
        string nombreContacto { get; set; }

        string apellidoContacto { get; set; }

        string cedulaContacto { get; set; }

        DropDownList comboCargo { get; set; }

        string codTelefono { get; set; }

        string telefonoContacto { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
