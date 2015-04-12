using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";
        Master.ShowDiv = false;
        Master.MostrarMenuLateral = false;

        HttpCookie aCookie = new HttpCookie("userInfo");
        aCookie.Values["usuario"] = "maguca";
        aCookie.Values["clave"] = "maguca10";
        aCookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(aCookie);

    }
}