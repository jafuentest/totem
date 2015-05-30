using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo4_ModificarProyecto : System.Web.UI.Page
{
    DominioTotem.Proyecto proyecto = new DominioTotem.Proyecto();
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

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

        if (Request.Cookies["selectedProjectCookie"] == null)
        {

        }

        String success = Request.QueryString["success"];
        if (success != null)
        {
            proyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(success);

        }

        this.nombreProy.Value = proyecto.Nombre;
        this.codigoProy.Value = proyecto.Codigo;
        this.precioProy.Value = proyecto.Costo.ToString();
        this.descripcionProy.Value = proyecto.Descripcion;

    }

    public void ModifyProject_Click(object sender, EventArgs e)
    {
        DominioTotem.Proyecto newProyecto = new DominioTotem.Proyecto();
        newProyecto.Nombre = this.nombreProy.Value;
        newProyecto.Codigo = this.codigoProy.Value;
        newProyecto.Costo = int.Parse(this.precioProy.Value);
        newProyecto.Descripcion = this.descripcionProy.Value;
        newProyecto.Moneda = this.monedaProy.InnerText;
        newProyecto.Estado = true;

        bool modified = LogicaNegociosTotem.Modulo4.LogicaProyecto.ModificarProyecto(newProyecto, proyecto.Codigo);
        if (modified == true){
            HttpContext.Current.Response.Redirect("PerfilProyecto.aspx?success="+newProyecto.Codigo+"&success=0");
        }
        else{
            alerts.Attributes["class"] = "alert alert-danger alert-dismissible";
            alerts.Attributes["role"] = "alert";
            alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto no pudo ser modificado...</div>";
        }
    }
}