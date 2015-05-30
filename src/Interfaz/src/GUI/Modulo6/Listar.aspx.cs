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
            List<CasoDeUso> lista = logica.ListarCasosDeUso();
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
					"data-target=\"#modal-info\" href=\"#\"></a>" +
					" <a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"Modificar.aspx?id=1\"></a>" +
					" <a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a>";

                fila.Cells.Add(id);
                fila.Cells.Add(titulo);
                fila.Cells.Add(actorPrimario);
                fila.Cells.Add(requerimientoAsociado);
                fila.Cells.Add(acciones);

				this.table_example.Rows.Add(fila);
            }
        }
    }
}
