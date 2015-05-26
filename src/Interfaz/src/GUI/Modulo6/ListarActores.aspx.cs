using System;
using System.Web;

public partial class GUI_Modulo6_ListarActores : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";

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

        /*
		switch (success)
		{
			case "1":
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
				alert.Attributes["role"] = "alert";
				alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor agregado exitosamente</div>";
				break;

			case "2":
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
				alert.Attributes["role"] = "alert";
				alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor modificado exitosamente</div>";
				break;

			case "3":
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
				alert.Attributes["role"] = "alert";
				alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor eliminado exitosamente</div>";
				break;
		}*/
	}
}
