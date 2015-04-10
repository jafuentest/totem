using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo2_AgregarCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

        /* TB - TextBox */

        TB_Nombre.Attributes["placeholder"] = "Nombre";
        TB_Apellido.Attributes["placeholder"] = "Apellido";
        TB_RIF.Attributes["placeholder"] = "RIF";
        TB_Correo.Attributes["placeholder"] = "Correo electrónico";
        TB_Telefono.Attributes["placeholder"] = "Teléfono";

        /* DD - DropDownList */

        DD_Cargo.Items.Insert(0, new ListItem("-- Cargo empresarial --", "0"));
        DD_Cargo.Items.Insert(1, new ListItem("Director general", "1"));
        DD_Cargo.Items.Insert(2, new ListItem("Director ejecutivo", "2"));
        DD_Cargo.Items.Insert(3, new ListItem("Gerente departamental", "3"));
        DD_RSocial.Items.Insert(0, new ListItem("V", "V") );
        DD_RSocial.Items.Insert(1, new ListItem("E", "E") );
    }
}