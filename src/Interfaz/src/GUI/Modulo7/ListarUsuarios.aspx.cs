using DominioTotem;
using LogicaNegociosTotem.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;



public partial class GUI_Modulo7_ListarUsuarios : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {


        ((MasterPage)Page.Master).IdModulo = "7";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
                String alert_registro = Request.QueryString["success"];
                String alert_eliminacion = Request.QueryString["success-eliminacion"];
                String eliminacionusuario = Request.QueryString["usernameeliminar"];
                if (alert_registro == "true")
                {
                    this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    this.alert.Attributes["role"] = "alert";
                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El registro fue completado exitosamente</div>";
                    this.alert.Visible = true;
                }
                if(alert_eliminacion == "true"){
                    this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    this.alert.Attributes["role"] = "alert";
                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se elimino correctamente</div>";
                    this.alert.Visible = true;
                }
                if (eliminacionusuario != null)
                {
                    this.user_name.InnerText = eliminacionusuario;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_delete", "$('#modal_delete').modal();", true);
                    upModal.Visible = true;
                }
            }
            else
            {
                //Mostrar menu lateral
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }

        #region Llenar Data Table Con Usuarios
        if(!IsPostBack){
            List<Usuario> listaUsuario = LogicaUsuario.listarUsuario();
            foreach (Usuario usuario in listaUsuario)
            {
                this.laTabla.Text += "<tr>";
                this.laTabla.Text += "<td>" + usuario.username.ToString() + "</td>";
                this.laTabla.Text += "<td>" + usuario.nombre.ToString() + "</td>";
                this.laTabla.Text += "<td>" + usuario.apellido.ToString() + "</td>";
                this.laTabla.Text += "<td>" + usuario.cargo.ToString() + "</td>";
                this.laTabla.Text += "<td>";
                this.laTabla.Text += "<a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"DetalleUsuario.aspx?username="+usuario.username+"\"></a>";
                this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"ListarUsuarios.aspx?usernameeliminar=" + usuario.username + "\"></a>";
                this.laTabla.Text += "</td>";
                this.laTabla.Text += "</tr>";
        }
        }
        #endregion
    }
    protected void evento_eliminar(object sender, EventArgs e)
    {
        string userName = this.user_name.InnerText;
        try
        {
            LogicaNegociosTotem.Modulo7.LogicaUsuario.eliminarUsuario(userName);
            Response.Redirect("../Modulo7/ListarUsuarios.aspx?success-eliminacion=true");
        }
        catch (ExcepcionesTotem.Modulo7.EliminacionUsuarioExcepcion)
        {
            this.alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert.Attributes["role"] = "alert";
            this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Eliminación de usuario fallida</div>";
            this.alert.Visible = true;
        }
    }
}