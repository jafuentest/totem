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
                TableCell actorPrimario = new TableCell();
                TableCell requerimientoAsociado = new TableCell();
                TableCell acciones = new TableCell();

                id.Text = caso.IdentificadorCasoUso;
                titulo.Text = caso.TituloCasoUso;
                actorPrimario.Text = caso.ActorPrimario.NombreActor;

                String requerimientos = "";
                foreach (Requerimiento req in caso.RequerimientosAsociados)
                {
                    requerimientos += req.Descripcion + " ";
                }

                requerimientoAsociado.Text = requerimientos;
                acciones.Text = "<a class=\"btn btn-primary glyphicon glyphicon-info-sign\" data-toggle=\"modal\"" +
					"data-target=\"#modal-info\" href=\"Listar.aspx?detalle=1\"></a>" +
					" <a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"Modificar.aspx?id=1\"></a>" +
					" <a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a>";

                fila.Cells.Add(id);
                fila.Cells.Add(titulo);
                fila.Cells.Add(actorPrimario);
                fila.Cells.Add(requerimientoAsociado);
                fila.Cells.Add(acciones);

				this.table_example.Rows.Add(fila);
			}

			String detalle = Request.Params["detalle"];
			if (detalle != null && !detalle.Equals(""))
			{
				int i = Int32.Parse(detalle);
				LlenarDetalle(lista, i);
			}
		}

    }

	private void LlenarDetalle(List<CasoDeUso> lista, int id)
	{
		CasoDeUso elCaso = null;

		foreach (CasoDeUso caso in lista)
		{
			if (caso.IdCasoUso == id)
			{
				elCaso = caso;
				break;
			}
		}

		if (elCaso != null)
		{
			foreach (String strPrecondicion in elCaso.PrecondicionesCasoUso)
			{
				ListItem precondicion = new ListItem(strPrecondicion);
				this.precondiciones.Items.Add(precondicion);
			}

			this.exito.InnerText = elCaso.CondicionExito;
			this.fallo.InnerText = elCaso.CondicionFallo;
			this.disparador.InnerText = elCaso.DisparadorCasoUso;
			
			foreach (Dictionary<String, Dictionary<String, List<String>>> dictPaso in elCaso.EscenarioExito)
			{
				foreach (String key in dictPaso.Keys)
				{
					ListItem paso = new ListItem(key);
					this.escenarioExito.Items.Add(paso);
				}
			}
			
			foreach (Dictionary<String, Dictionary<String, List<String>>> dictPaso in elCaso.EscenarioExito)
			{
				foreach (Dictionary<String, List<String>> val in dictPaso.Values)
				{
					foreach (KeyValuePair<String, List<String>> par in val)
					{
						foreach (String laExt in par.Value)
						{
							ListItem laExte = new ListItem(laExt);
							this.extensiones.Items.Add(laExte);
						}
					}
				}
			}
		}
	}
}
