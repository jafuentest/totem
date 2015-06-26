using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contratos.Modulo3
{

    /// <summary>
    /// Contrato asociado a la vista Agregar involucrado
    /// </summary>
    public interface IContratoAgregarInvolucrado
    {
        DropDownList comboTipoEmpresa { get; set; }
        DropDownList comboCargo { get; set; }
        DropDownList comboPersonal { get; set; }
        Literal laTabla { get; set; }
        String user_name { get; set; }
        String contacto_id { get; set; }
        String eliminacionUsuario { get; set; }
        String eliminacionContacto { get; set; }
        String alert { set; }
        String alertClase { set; }
        String alertRol { set; }
        String alertaContactoClase { set; }
        String alertaUsuarioClase { set; }
        String alertaUsuarioRol { set; }
        String alertaContactoRol { set; }
        String AlertaContacto  { set; }
        String AlertaUsuario  { set; }
    }
}
