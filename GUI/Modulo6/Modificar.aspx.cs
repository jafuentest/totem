using System;

public partial class GUI_Modulo6_Modificar : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";

		if (Request.Cookies["userInfo"] == null)
		{
			Response.Redirect("~/GUI/Modulo1/M1_login.aspx");
		}
	}
}
