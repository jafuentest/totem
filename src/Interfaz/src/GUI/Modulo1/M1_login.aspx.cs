using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";
        Master.ShowDiv = false;
        Master.MostrarMenuLateral = false;

       

        HttpCookie aCookie = new HttpCookie("userInfo");
        aCookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(aCookie);

        String log = Request.QueryString["logout"];
        if (log != null)
        {
            if (log.Equals("true"))
            {
                HttpCookie myCookie = new HttpCookie("userInfo");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
        }
        if (Request.Cookies["userInfo"] != null)
        {
            if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" && Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (input_usuario.Value == "user")
        {
            HttpCookie aCookie = new HttpCookie("userInfo");
            aCookie.Values["usuario"] = "user";
            aCookie.Values["clave"] = input_pswd.Value;
            aCookie.Values["rol"] = "usuario";
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
                Response.Redirect("Default.aspx");
        }
        if (input_usuario.Value == "admin")
        {
            HttpCookie aCookie = new HttpCookie("userInfo");
            aCookie.Values["usuario"] = "admin";
            aCookie.Values["clave"] = input_pswd.Value;
            aCookie.Values["rol"] = "administrador";
            aCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(aCookie);
                Response.Redirect("Default.aspx");
        }
    }
}