using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo2_AgregarEmpresa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

        /* TB - TextBox */

        TB_Nombre.Attributes["placeholder"] = "Nombre";
        TB_RIF.Attributes["placeholder"] = "RIF";
        TB_Direccion.Attributes["placeholder"] = "Dirección detallada";
        TB_CPostal.Attributes["placeholder"] = "Código postal";
        TB_Telefono.Attributes["placeholder"] = "Teléfono";
    }
}