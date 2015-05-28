using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class M1_IntroducirCorreo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
            if (user.username != "" &&
                user.clave != "")
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
            }
            else
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
            }

        }

        
    }
}