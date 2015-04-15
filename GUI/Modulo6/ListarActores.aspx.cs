using System;

public partial class GUI_Modulo6_ListarActores : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";
		String success = Request.QueryString["success"];

		if ("1".Equals(success))
		{
			alert.Attributes["class"] = "alert alert-success alert-dismissible";
			alert.Attributes["role"] = "alert";
			alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor agregado exitosamente</div>";
		}
		else if ("2".Equals(success))
		{
			alert.Attributes["class"] = "alert alert-success alert-dismissible";
			alert.Attributes["role"] = "alert";
			alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor modificado exitosamente</div>";
		}
		else if ("3".Equals(success))
		{
			alert.Attributes["class"] = "alert alert-success alert-dismissible";
			alert.Attributes["role"] = "alert";
			alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor eliminado exitosamente</div>";
		}

		if (Request.Cookies["userInfo"].Equals(null))
		{
			Response.Redirect("~/GUI/Modulo1/M1_login.aspx");
		}
		else if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
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
}
