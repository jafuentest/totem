using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo5_RFuncionalesID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ((MasterPage)Page.Master).IdModulo = "5";

        String success = Request.QueryString["success"];

        if (success != null)
        {
            if (success.Equals("3"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento eliminado exitosamente</div>";
            }
	   else
            if (success.Equals("2"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento modificado exitosamente</div>";
            }
	   }

	   DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

	   if (user != null)
	   {
		  if (user.username != "" &&
			  user.clave != "")
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

    }
}