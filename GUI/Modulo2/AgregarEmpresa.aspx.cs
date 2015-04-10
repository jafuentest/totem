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

        /* DD - DropDownList */

        DD_Pais.Items.Insert(0, new ListItem("-- País --", "0"));
        DD_Pais.Items.Insert(1, new ListItem("Venezuela", "1"));
        DD_Estado.Items.Insert(0, new ListItem("-- Estado --", "0"));
        DD_Estado.Items.Insert(1, new ListItem("Distrito Capital", "1"));
        DD_Estado.Items.Insert(2, new ListItem("Carabobo", "2"));
        DD_Estado.Items.Insert(3, new ListItem("Aragua", "3"));
        DD_RSocial.Items.Insert(0, new ListItem("J", "J"));
        DD_RSocial.Items.Insert(1, new ListItem("G", "G"));
    }
}