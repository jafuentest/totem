using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "9";

        DominioTotem.Usuario user= HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
            if (user.username != "" &&
                user.clave != "")
            {
                Master.ShowDiv = true;
                if (user.rol == "Administrador")
                {
                    div_adminIcons.InnerHtml = "<div class='row jumbotron'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-4'>";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += "<a href='../Modulo2/ListarEmpresas.aspx'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img src='../../../img/Icons/modulo2.png' />";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de empresas</p>";
                    div_adminIcons.InnerHtml += "</a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += " <a href='../Modulo5/ListarRequerimientos.aspx'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img src='../../../img/Icons/modulo5.png' />";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de requerimientos y reportes</p>";
                    div_adminIcons.InnerHtml += "</a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-4'> ";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += "<a href='../Modulo3/ListarPersonalInvolucrado.aspx'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img  src='../../../img/Icons/modulo3.png'>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de involucrados</p>";
                    div_adminIcons.InnerHtml += " </a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += "<a href='../Modulo6/Listar.aspx'>";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img  src='../../../img/Icons/modulo6.png' />";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de casos de uso</p>";
                    div_adminIcons.InnerHtml += " </a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += " <a  href='../Modulo8/ConsultarMinuta.aspx'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img  src='../../../img/Icons/modulo8.png' />";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de minutas</p>";
                    div_adminIcons.InnerHtml += "</a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += " <div class='col-sm-4'>";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += "<a href='../Modulo4/ListaProyectos.aspx'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img  src='../../../img/Icons/modulo4.png' />";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de proyectos</p>";
                    div_adminIcons.InnerHtml += "</a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<br />";
                    div_adminIcons.InnerHtml += "<div>";
                    div_adminIcons.InnerHtml += "<a href='../Modulo7/ListarUsuarios.aspx'>";
                    div_adminIcons.InnerHtml += "<div class='col-sm-offset-5'>";
                    div_adminIcons.InnerHtml += "<img  src='../../../img/Icons/modulo7.png' />";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "<p class='text-center'>Gestión de roles y usuarios</p>";
                    div_adminIcons.InnerHtml += "</a>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "</div>";
                    div_adminIcons.InnerHtml += "</div>";
                }
            }
            else
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
            }

        }

        String success = Request.QueryString["success"];
        if (success != null)
        {
            if (success.Equals("1"))
            {
                alert_requerimiento.Attributes["class"] = "alert alert-success alert-dismissible";
                alert_requerimiento.Attributes["role"] = "alert";
                alert_requerimiento.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto eliminado exitosamente</div>";

            }
            if (success.Equals("2"))
            {
                alert_requerimiento.Attributes["class"] = "alert alert-success alert-dismissible";
                alert_requerimiento.Attributes["role"] = "alert";
                alert_requerimiento.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto creado exitosamente</div>";

            }
        }


    }
}