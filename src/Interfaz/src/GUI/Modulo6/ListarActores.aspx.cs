using System;
using System.Web;
using LogicaNegociosTotem.Modulo6;
using DominioTotem;
using System.Collections.Generic;

public partial class GUI_Modulo6_ListarActores : System.Web.UI.Page
{

    private List<Actor> listaActores;
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";
        String success = Request.QueryString["success"];

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
		}

        HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");

        if (projectCookie != null)
        {
            string proyecto = projectCookie.Values["projectCode"];
            try
            {
                int proyectoID = Int32.Parse(proyecto);
                LogicaActor logica = new LogicaActor();
                this.listaActores = logica.ListarActor(0);
                foreach (Actor actorLista in listaActores)
                {
                    cuerpo.InnerHtml = cuerpo.InnerHtml + "<tr><td>" + actorLista.NombreActor + "</td><td>" + actorLista.DescripcionActor + "</td><td><a class=\"btn btn-default glyphicon glyphicon-pencil\" data-toggle=\"modal\" data-target=\"#modal-update\" href=\"#\"></a><a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a></td></tr>";
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("La cookie no tiene valor", ex);
            }
            catch (FormatException exe)
            {
                throw new FormatException("La cookie tiene un valor de proyecto no valido", exe);
            }
        }
	}
}
