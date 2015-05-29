using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcepcionesTotem.Modulo7;
using DominioTotem;

public partial class GUI_Modulo7_Registro : System.Web.UI.Page
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
                this.alert_apellido.Visible = false;
                this.alert_correo.Visible = false;
                this.alert_nombre.Visible = false;
                this.alert_pregunta.Visible = false;
                this.alert_respuesta.Visible = false;
                this.alert_username.Visible = false;
                this.alertlocal.Visible = false;
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
    }

    protected void btn_registrar_Click(object sender, EventArgs e)
    {       
         //falta por seleccionar el cargp, falta por seleccionar el rol y hacer esa validacion
        try
        {
            
            if(this.id_nombre.Value != ""){
                if (this.id_apellido.Value != "")
                {
                    if (this.id_username.Value != "")
                    {
                        if(this.id_correo.Value != ""){
                            if(this.id_pregunta.Value != ""){
                                if(this.id_respuesta.Value != ""){
                                    if(this.password.Value == this.confirm_password.Value ){
                                     LogicaNegociosTotem.Modulo7.LogicaUsuario.agregarUsuario(
                                        new DominioTotem.Usuario(this.id_username.Value,
                                        this.password.Value,
                                        this.id_nombre.Value,
                                        this.id_apellido.Value,
                                        "Usuario",
                                        this.id_correo.Value,
                                        this.id_pregunta.Value,
                                        this.id_respuesta.Value,
                                        "Desarrollador"));
                                     Response.Redirect("../Modulo7/ListarUsuarios.aspx?success=true");
                                     }else{
                                         alert_password.Attributes["class"] = "alert alert-danger alert-dismissible";
                                         alert_password.Attributes["role"] = "alert";
                                         alert_password.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La respuesta de seguridad esta vacia</div>";
                                         alert_password.Visible = true;
                                    }
                                }else{
                                    alert_respuesta.Attributes["class"] = "alert alert-danger alert-dismissible";
                                    alert_respuesta.Attributes["role"] = "alert";
                                    alert_respuesta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La respuesta de seguridad esta vacia</div>";
                                    alert_respuesta.Visible = true;
                                }
                                
                            }else{
                                alert_pregunta.Attributes["class"] = "alert alert-danger alert-dismissible";
                                alert_pregunta.Attributes["role"] = "alert";
                                alert_pregunta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La pregunta de seguridad esta vacia</div>";
                                alert_pregunta.Visible = true;
                            }
                        }else{
                            alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert_correo.Attributes["role"] = "alert";
                            alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debes ingresar el correo</div>";
                            alert_correo.Visible = true;
                        }
                    }
                    else
                    {
                        alert_username.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert_username.Attributes["role"] = "alert";
                        alert_username.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debes ingresar el Nombre de Usuario</div>";
                        alert_username.Visible = true;
                    }
                }
                else
                {
                    alert_apellido.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert_apellido.Attributes["role"] = "alert";
                    alert_apellido.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido esta vacio</div>";
                    alert_apellido.Visible = true;
                }
            }
            else
            {
                alert_apellido.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert_apellido.Attributes["role"] = "alert";
                alert_apellido.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre esta vacio</div>";
                alert_apellido.Visible = true;
            }
            
        }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
            {
                alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                alertlocal.Attributes["role"] = "alert";
                alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>EL registro ha fallado</div>";
                alertlocal.Visible = true;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
                alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                alertlocal.Attributes["role"] = "alert";
                alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error de conexion</div>";
                alertlocal.Visible = true;
            }
            catch (UserNameRepetidoException)
            {
                alert_username.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert_username.Attributes["role"] = "alert";
                alert_username.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre de usuario esta repetido</div>";
                alert_username.Visible = true;
            }
            catch (CorreoRepetidoException)
            {
                alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert_correo.Attributes["role"] = "alert";
                alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Correo Repetido</div>";
                alert_correo.Visible = true;
            }
            catch (RegistroUsuarioFallidoException)
            {
                alertlocal.Attributes["class"] = "alert alert-danger alert-dismissible";
                alertlocal.Attributes["role"] = "alert";
                alertlocal.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>EL registro ha fallado</div>";
                alertlocal.Visible = true;
            }
        
    }
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        this.id_apellido.Value = "";
        this.id_correo.Value = "";
        this.id_nombre.Value = "";
        this.id_otrocargo.Value = "";
        this.id_pregunta.Value = "";
        this.id_username.Value = "";
        this.password.Value = "";
        this.confirm_password.Value = "";
        this.id_respuesta.Value = "";

    }
}