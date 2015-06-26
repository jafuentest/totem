using Dominio.Entidades.Modulo7;
using System;
using System.Web;
using Dominio.Fabrica;


namespace Vista.Modulo1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            HttpCookie aCookie = new HttpCookie("Intento");
            aCookie.Values["inten"] = "0";
            aCookie.Expires = DateTime.Now.AddMinutes(15);
            Response.Cookies.Add(aCookie);

            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            Usuario user = (Usuario) fabricaEntidades.ObtenerUsuario();
            user.Username = (string) HttpContext.Current.Session["LUsuario"];
            user.Rol = (string) HttpContext.Current.Session["LUsuarioRol"];

            if (user.Username != "")
            {

                if (user.Rol == "Administrador")
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
        }
    }
}