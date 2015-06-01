using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DominioTotem;
public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    private static ListaInvolucradoUsuario laListaDeUsuarios = new ListaInvolucradoUsuario();

    private static ListaInvolucradoContacto laListaDeContactos = new ListaInvolucradoContacto();

    private Proyecto elProy = new Proyecto();

    private Usuario elUser = new Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
                String alert = Request.QueryString["success"];
                if (alert == "true")
                {
                    this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    this.alert.Attributes["role"] = "alert";
                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Personal agregado exitosamente</div>";
                    this.alert.Visible = true;
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
        //Muetra alerta en caso de que se haya asignado involucrados al proyecto
        String success = Request.QueryString["success"];
        String eliminacionUsuario = Request.QueryString["usuarioaeliminar"];
        String eliminacionContacto = Request.QueryString["contactoaeliminar"];
        String alert_eliminacion = Request.QueryString["success-eliminacion"];
        if (success != null)
        {
            if (success.Equals("1"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Personal agregado exitosamente</div>";

            }
        } if (alert_eliminacion == "true")
        {
            this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
            this.alert.Attributes["role"] = "alert";
            this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se elimino correctamente</div>";
            this.alert.Visible = true;
        }
        if (eliminacionUsuario != null || eliminacionContacto != null)
        {
            if (eliminacionContacto == null)
                this.user_name.InnerText = eliminacionUsuario;
            else
                this.contacto_id.InnerText = eliminacionContacto;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_delete", "$('#modal_delete').modal();", true);
            upModal.Visible = true;
        }

        #region Llenar Data Table Con Usuarios y Contactos Involucrados
        elProy.Codigo = "TOT"; //codigo del proyecto cableado para prueba del metodo
        LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados(elProy);
        
        HttpCookie pcookie = Request.Cookies.Get("selectedProjectCookie");
        //elProy.Codigo =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto

        if (!IsPostBack)
        {
            try
            {
                laListaDeUsuarios = logInv.obtenerUsuariosInvolucradosProyecto(elProy);
                laListaDeContactos = logInv.obtenerContactosInvolucradosProyecto(elProy);
                laListaDeUsuarios.Proyecto = elProy;
                laListaDeContactos.Proyecto = elProy;
                LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();

                foreach (Usuario u in laListaDeUsuarios.Lista)
                {
                    this.laTabla.Text += "<tr>";
                    this.laTabla.Text += "<td>" + u.nombre.ToString() + "</td>";
                    this.laTabla.Text += "<td>" + u.apellido.ToString() + "</td>";
                    this.laTabla.Text += "<td>" + u.cargo.ToString() + "</td>";
                    this.laTabla.Text += "<td>Compañía De Software</td>";
                    this.laTabla.Text += "<td>";
                    this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"ListarPersonalInvolucrado.aspx?usuarioaeliminar=" + u.username + "\"></a>";
                    this.laTabla.Text += "</td>";
                    this.laTabla.Text += "</tr>";
                }
                foreach (Contacto c in laListaDeContactos.Lista)
                {
                    this.laTabla.Text += "<tr>";
                    this.laTabla.Text += "<td>" + c.Con_Nombre.ToString() + "</td>";
                    this.laTabla.Text += "<td>" + c.Con_Apellido.ToString() + "</td>";
                    this.laTabla.Text += "<td>" + c.ConCargo.ToString() + "</td>";

                    if (c.ConClienteJurid != null)
                        this.laTabla.Text += "<td>" + c.ConClienteJurid.Jur_Nombre.ToString() + "</td>";

                    if (c.ConClienteNat != null)
                        this.laTabla.Text += "<td>" + c.ConClienteNat.Nat_Nombre.ToString() + "</td>";

                    this.laTabla.Text += "<td>";
                    this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"ListarPersonalInvolucrado.aspx?contactoaeliminar=" + c.Con_Id + "\"></a>";
                    this.laTabla.Text += "</td>";
                    this.laTabla.Text += "</tr>";
                }
            }
            catch(ExcepcionesTotem.ExceptionTotem ex)
            {

            }
            catch (Exception ex)
            {

            }
        #endregion

        }
    }

    protected void evento_eliminar(object sender, EventArgs e)
    {
        LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados();


        if (!this.user_name.InnerText.Equals(""))
        {
            Usuario user = new Usuario();
            user.username = this.user_name.InnerHtml;
            try
            {
                if (logInv.eliminarUsuarioDeBD(user, laListaDeUsuarios))
                    Response.Redirect("../Modulo3/ListarPersonalInvolucrado.aspx?success-eliminacion=true");
            }
            catch (ExcepcionesTotem.Modulo7.EliminacionUsuarioExcepcion)
            {
                this.alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Eliminación de usuario fallida</div>";
                this.alert.Visible = true;
            }
        }
        else
            if (!this.contacto_id.InnerText.Equals(""))
            {
                Contacto contacto = new Contacto();
                contacto.Con_Id = int.Parse(this.contacto_id.InnerText);
                try
                {
                    if (logInv.eliminarContactoDeBD(contacto, laListaDeContactos))
                        Response.Redirect("../Modulo3/ListarPersonalInvolucrado.aspx?success-eliminacion=true");
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
}