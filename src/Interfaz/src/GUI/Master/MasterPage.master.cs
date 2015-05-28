using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;



public partial class MasterPage : System.Web.UI.MasterPage
{
	private string idModulo;
	private Dictionary<string, string> opcionesDelMenu = new Dictionary<string, string>();
    private bool showDiv, mostrarMenuLateral = true;

    public bool MostrarMenuLateral
    {
        get { return mostrarMenuLateral; }
        set { mostrarMenuLateral = value; }
    }
    

    public bool ShowDiv
    {
        get { return showDiv; }
        set { showDiv = value; }
    } 

	public string IdModulo
	{
		get { return idModulo; }
		set { idModulo = value; }
	}
	public Dictionary<string, string> OpcionesDelMenu
	{
		get { return opcionesDelMenu; }
		set { opcionesDelMenu = value; }
	}

	protected void Page_Load(object sender, EventArgs e)
	{
        ulNav.Visible = showDiv;
        menuLateral.Visible = mostrarMenuLateral; 
		XmlDocument doc = new XmlDocument();
		doc.Load(Server.MapPath("~/src/GUI/Master/menuLateral.xml"));

		foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			foreach (XmlNode subNode in node.ChildNodes)
				if (!(subNode.Attributes["id"] == null) && subNode.Attributes["id"].InnerText.Equals(IdModulo))
				{
					OpcionesDelMenu[node.Attributes["nombre"].InnerText] = node.Attributes["link"].InnerText;
					break;
				}

        HttpCookie pcookie = Request.Cookies.Get("selectedProjectCookie");

        if (pcookie != null)
        {
            selectedProject.InnerText = "Proyecto Seleccionado: " + pcookie.Values["projectName"].ToString();
        }

        if (HttpContext.Current.Session["Credenciales"] != null)
        {
                ShowDiv = true;

        }

        else
        {
            if ((!HttpContext.Current.Request.Url.AbsolutePath.Equals("/src/GUI/Modulo1/M1_login.aspx"))&&
               (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/src/GUI/Modulo1/M1_IntroducirCorreo.aspx")) &&
               (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/src/GUI/Modulo1/M1_PreguntaSeguridad.aspx")) &&
               (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/src/GUI/Modulo1/M1_RecuperacionClave.aspx")))
            {
                Response.Redirect("~/src/GUI/Modulo1/M1_login.aspx");
            }
        }
	}

}
