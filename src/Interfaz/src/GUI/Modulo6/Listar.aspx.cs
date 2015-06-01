using DominioTotem;
using LogicaNegociosTotem.Modulo6;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

public partial class GUI_Modulo6_Listar : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		((MasterPage)Page.Master).IdModulo = "6";

		#region checkLogin
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
		#endregion

		String success = Request.Params["success"];
        if(success != null && !success.Equals(""))
            SetAlert (Int32.Parse(success));
        LlenarLista();
	}

    private void SetAlert(int tipo)
    {
        switch (tipo)
        {
            case 1:
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso agregado exitosamente</div>";
                break;

            case 2:
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso modificado exitosamente</div>";
                break;

            case 3:
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso eliminado exitosamente</div>";
                break;

			case 4:
				alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se encontró el caso de uso</div>";
                break;
        }
    }

	private void LlenarLista()
    {
        using (LogicaCasoUso logica = new LogicaCasoUso())
        {
			//Cable
			int idProyecto = 0;

			List<CasoDeUso> lista = logica.ListarCasosDeUso(idProyecto);
            foreach (CasoDeUso caso in lista)
            {
                TableRow fila = new TableRow();
                TableCell id = new TableCell();
                TableCell titulo = new TableCell();
                TableCell actores = new TableCell();
                TableCell requerimientoAsociados = new TableCell();
                TableCell acciones = new TableCell();

                id.Text = caso.IdentificadorCasoUso;
                titulo.Text = caso.TituloCasoUso;

				String[] strActores = new String[caso.Actores.Count];
				int i = -1;	
				foreach (Actor actor in caso.Actores)
					strActores[++i] = actor.NombreActor;
				actores.Text = String.Join(",", strActores);

				String[] strRequerimientos = new String[caso.RequerimientosAsociados.Count];
				i = -1;
				foreach (Requerimiento requerimiento in caso.RequerimientosAsociados)
					strRequerimientos[++i] = requerimiento.Descripcion;
				requerimientoAsociados.Text = String.Join(",", strRequerimientos);

                acciones.Text = "<a class=\"btn btn-primary glyphicon glyphicon-info-sign\" data-toggle=\"modal\"" +
					" href=\"Listar.aspx?detalle=" + caso.IdCasoUso + "\"></a>" +
					" <a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"Modificar.aspx?id=1\"></a>" +
					" <a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\"" +
					" data-target=\"#modal-delete\" href=\"#\"></a>";

                fila.Cells.Add(id);
                fila.Cells.Add(titulo);
                fila.Cells.Add(actores);
				fila.Cells.Add(requerimientoAsociados);
                fila.Cells.Add(acciones);

				this.table_example.Rows.Add(fila);
			}

			String detalle = Request.Params["detalle"];
			if (detalle != null && !detalle.Equals(""))
			{
				try
				{
					LlenarDetalle(lista, Int32.Parse(detalle));
				}
				catch (FormatException)
				{
					SetAlert(4);
				}
			}
		}
    }

	private void LlenarDetalle(List<CasoDeUso> lista, int id)
	{
		CasoDeUso elCaso = null;

		foreach (CasoDeUso caso in lista)
			if (caso.IdCasoUso == id)
			{
				elCaso = caso;
				break;
			}

		if (elCaso == null)
			SetAlert(4);
		else
		{
			foreach (String strPrecondicion in elCaso.PrecondicionesCasoUso)
			{
				ListItem precondicion = new ListItem(strPrecondicion);
				this.precondiciones.Items.Add(precondicion);
			}

			this.exito.InnerText = elCaso.CondicionExito;
			this.fallo.InnerText = elCaso.CondicionFallo;
			this.disparador.InnerText = elCaso.DisparadorCasoUso;
			String extensiones = "<ul>";
			foreach (Tuple<String, Dictionary<String, List<String>>> paso in elCaso.EscenarioExito)
			{
				extensiones += "<li>" + paso.Item1 + "</li>";
				if (paso.Item2.Count > 0)
				{
					extensiones += "<ul>";

					foreach (KeyValuePair<String, List<String>> extension in paso.Item2)
					{
						extensiones += "<li>" + extension.Key + "</li><ul>";

						foreach (String pasoExtension in extension.Value)
							extensiones += "<li>" + pasoExtension + "</li>";
						extensiones += "</ul>";
					}
					extensiones += "</ul>";
				}
			}
			extensiones += "</ul>";
			this.escenarioPrincipal.InnerHtml = extensiones;
		}
	}
}
