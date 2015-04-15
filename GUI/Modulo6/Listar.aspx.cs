using System;

public partial class GUI_Modulo6_Listar : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";
		
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
