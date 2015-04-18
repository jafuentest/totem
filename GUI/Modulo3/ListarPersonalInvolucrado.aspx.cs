using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";
        ((MasterPage)Page.Master).ShowDiv = true;
        if (Request.Cookies["userInfo"] != null)
        {
            //Valida que se tenga usuario para entrar a la pagina
            if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
                Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
            }
            else
            {
                //Mostrar menu lateral
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }
        //Muetra alerta en caso de que se haya asignado involucrados al proyecto
         String success = Request.QueryString["success"];
         if (success != null)
         {
             if (success.Equals("1"))
             {
                 alert.Attributes["class"] = "alert alert-success alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Personal agregado exitosamente</div>";
                 
             }
         } 

             
        
  
    }
}