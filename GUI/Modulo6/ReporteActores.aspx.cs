using System;

public partial class GUI_Modulo6_ReporteActores : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";
		((MasterPage)Page.Master).ShowDiv = true;
		String success = Request.QueryString["success"];

		if (Request.Cookies["userInfo"] == null)
		{
			Response.Redirect("~/GUI/Modulo1/M1_login.aspx");
		}

		switch (success)
		{
			case "1":
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
				alert.Attributes["role"] = "alert";
				alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso agregado exitosamente</div>";
				break;

			case "2":
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
				alert.Attributes["role"] = "alert";
				alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso modificado exitosamente</div>";
				break;

			case "3":
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
				alert.Attributes["role"] = "alert";
				alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso eliminado exitosamente</div>";
				break;
		}
	}
}
