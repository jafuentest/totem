using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosTotem.Modulo2;
using DominioTotem;


public partial class GUI_Modulo2_ListarClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "2";

        String success = Request.QueryString["success"];
        if (success != null)
        {
            if (success.Equals("elim"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";

                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha eliminado exitosamente</div>";

            }
            if (success.Equals("edit"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha editado exitosamente</div>";
            }
            if (success.Equals("regis"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha registrado exitosamente</div>";
            }
        }

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



        LogicaCliente logica = new LogicaCliente();
         List<ClienteNatural> listaClientesNaturales = logica.ConsultarClientesNaturales();

        foreach (ClienteNatural clienteLista in listaClientesNaturales)
        {
            cuerpo.InnerHtml = cuerpo.InnerHtml + "<tr><td>" + clienteLista.Nat_Id + "</td><td>" + clienteLista.Nat_Nombre + "</td><td>" + clienteLista.Nat_Apellido + "</td><td>" + clienteLista.Nat_Correo + "</td><td><a class=\"btn btn-default glyphicon glyphicon-pencil\" data-toggle=\"modal\" data-target=\"#modal-update\" href=\"#\"></a><a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a></td></tr>";
            // cuerpo.InnerHtml = cuerpo.InnerHtml + "<tr id=\"actor-" + actorLista.IdentificacionActor + "\"><td class=\"name\">" + actorLista.NombreActor + "</td><td class=\"desc\">" + actorLista.DescripcionActor + "</td><td class=\"actions\"><a class=\"btn btn-default glyphicon glyphicon-pencil\" data-toggle=\"modal\" data-target=\"#modal-update\" href=\"#\"></a><a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a></td></tr>";


         }
    }

}