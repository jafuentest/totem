using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";
        ((MasterPage)Page.Master).ShowDiv = true;
        
        if (Request.Cookies["userInfo"] != null)
        {    
            //Valida que un solo usuario este entrando a la pagina
            if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
                Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
            {
               
                    ((MasterPage)Page.Master).ShowDiv = true;
                //Valida que el rol sea usuario 
                    if (Server.HtmlEncode(Request.Cookies["userInfo"]["rol"]) == "usuario")
                       Response.Redirect("../Modulo3/ListarPersonalInvolucrado.aspx");
                
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
    }


}