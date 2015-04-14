using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";

        if (Request.Cookies["userInfo"] != null)
        { 
            if(Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"])!="" &&
                Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = true;
            }
            else 
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
            }
        
        }

         String success = Request.QueryString["success"];
         if (success != null)
         {
             if (success.Equals("1"))
             {
                 alert_requerimiento.Attributes["class"] = "alert alert-success alert-dismissible";
                 alert_requerimiento.Attributes["role"] = "alert";
                 alert_requerimiento.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto eliminado exitosamente</div>";

             }
         }

         
    }
}