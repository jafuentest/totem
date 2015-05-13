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
        if (Request.Cookies["userInfo"] != null)
        {
            if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
                Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
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