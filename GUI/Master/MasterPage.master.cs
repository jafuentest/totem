using System;
using System.Collections.Generic;
using System.Xml;

public partial class MasterPage : System.Web.UI.MasterPage
{
	private string idModulo;
	private Dictionary<string, string> opcionesDelMenu = new Dictionary<string, string>();

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
		XmlDocument doc = new XmlDocument();
		doc.Load(Server.MapPath("~/GUI/Master/menuLateral.xml"));

		foreach (XmlNode node in doc.DocumentElement.ChildNodes)
			foreach (XmlNode subNode in node.ChildNodes)
				if (subNode.Attributes["id"].InnerText.Equals(IdModulo))
				{
					OpcionesDelMenu[node.Attributes["nombre"].InnerText] = node.Attributes["link"].InnerText;
					break;
				}
	}
}
