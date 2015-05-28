using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LogicaNegociosTotem.Modulo6;


public partial class GUI_Modulo6_CrearActor : System.Web.UI.Page
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

    }


    protected void Agregar_Actor(object sender, EventArgs e)
    {
        string nombre = this.nombre_actor.Value;
        string descripcion = this.descripcion_actor.Value;

        if (nombre.Equals(""))
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debe ingresar un nombre para el actor</div>";

        }
        else
        {
            LogicaActor logica = new LogicaActor();
            bool exito = logica.AgregarListarActor(nombre, descripcion, 0);
            HttpContext.Current.Response.Redirect("ListarActores.aspx?success=1");
        }

    }
}
