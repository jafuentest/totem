using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class GUI_Modulo4_PerfilProyecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

        if (Request.Cookies["userInfo"] != null)
        {
            if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
                Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
            }
            else
            {
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }

        HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");

        if (projectCookie == null)
        {
            projectCookie = new HttpCookie("selectedProjectCookie");
            projectCookie.Values["projectCode"] = codigoProyecto.InnerText.ToString();
            projectCookie.Values["projectName"] = nombreProyecto.InnerText.ToString();
            Response.Cookies.Add(projectCookie);
        }
        else
        {
            Response.Cookies.Remove("selectedProjectCookie");
            projectCookie = new HttpCookie("selectedProjectCookie");
            projectCookie.Values["projectCode"] = codigoProyecto.InnerText.ToString();
            projectCookie.Values["projectName"] = nombreProyecto.InnerText.ToString();
            Response.Cookies.Add(projectCookie);
        }
    }
}