using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



public partial class GUI_Modulo7_ListarUsuarios : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {


        ((MasterPage)Page.Master).IdModulo = "7";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
                String alert = Request.QueryString["success"];
                if (alert == "true")
                {
                    alert_registro.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert_registro.Attributes["role"] = "alert";
                    alert_registro.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El registro fue completado exitosamente</div>";
                    alert_registro.Visible = true;
                }
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