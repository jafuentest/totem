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
        else if (projectCookie.Values["projectCode"] != codigoProyecto.InnerText)
        {
            //ScriptManager.RegisterStartupScript(this,typeof(Page),"CallMyFunction","openModal()",true);
            Response.Cookies.Remove("selectedProjectCookie");
            projectCookie = new HttpCookie("selectedProjectCookie");
            projectCookie.Values["projectCode"] = codigoProyecto.InnerText.ToString();
            projectCookie.Values["projectName"] = nombreProyecto.InnerText.ToString();
            Response.Cookies.Add(projectCookie);
        }

        String success = Request.QueryString["success"];
        if (success != null)
        {
            
        }

        switch (success)
        {
            case "0":
                alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                alerts.Attributes["role"] = "alert";
                alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto modificado exitosamente</div>";
                break;
            case "1":
                alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                alerts.Attributes["role"] = "alert";
                alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento modificado exitosamente</div>";
                break;
            case "2":
                alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                alerts.Attributes["role"] = "alert";
                alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento eliminado exitosamente</div>";
                break;
            case "3":
                alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                alerts.Attributes["role"] = "alert";
                alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso modificado exitosamente</div>";
                break;
            case "4":
                alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                alerts.Attributes["role"] = "alert";
                alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso eliminado exitosamente</div>";
                break;
            case "5":
                alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                alerts.Attributes["role"] = "alert";
                alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Involucrado eliminado exitosamente</div>";
                break;
        }
    }
}