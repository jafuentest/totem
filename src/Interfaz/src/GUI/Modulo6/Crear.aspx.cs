using System;
using System.Web;
using LogicaNegociosTotem.Modulo6;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class GUI_Modulo6_Crear : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";

		DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
		if (user != null)
		{
			if (user.username != "" && user.clave != "")
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

		AsignarID();
	}

	private void AsignarID()
	{
		using (LogicaCasoUso logica = new LogicaCasoUso())
		{
			this.id.Text = logica.ObtenerProximoID();
			this.id.Enabled = false;
		}
	}

	protected void CrearCasoDeUso(object sender, EventArgs e)
	{

	}
	protected void agregarPrecondicion_Click(object sender, EventArgs e)
	{
		
		HtmlGenericControl div = new HtmlGenericControl("div");
		div.Attributes.Add("class", "col-sm-11 col-md-11 col-lg-11");
		TextBox precondicion = new TextBox();
		precondicion.CssClass = "form-control " + this.precondiciones.Controls.Count;
		div.Controls.Add(precondicion);
		this.precondiciones.Controls.Add(new HtmlGenericControl("br"));
		this.precondiciones.Controls.Add(div);
	}
}
