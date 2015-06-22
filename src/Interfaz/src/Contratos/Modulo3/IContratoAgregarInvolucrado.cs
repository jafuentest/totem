using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contratos.Modulo3
{
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
    }
}
