using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo7_EditarPerfil : System.Web.UI.Page
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

                if (!IsPostBack)
                {
                    DominioTotem.Usuario datoUsuario = LogicaNegociosTotem.Modulo7.LogicaUsuario.ObtenerDatos(user.username);
                    this.input_usuario.Value = datoUsuario.username;
                    this.input_nombre.Value = datoUsuario.nombre;
                    this.input_apellido.Value = datoUsuario.apellido;
                    this.input_correo.Value = datoUsuario.correo;
                    this.input_pregunta.Value = datoUsuario.preguntaSeguridad;
                    this.input_respuesta.Value = datoUsuario.respuestaSeguridad;
                }
                if (IsPostBack)
                {
                    this.alert_apellido.Visible = false;
                    this.alert_correo.Visible = false;
                    this.alert_nombre.Visible = false;
                    this.alert_pregunta.Visible = false;
                    this.alert_respuesta.Visible = false;
                    this.alert_username.Visible = false;
                    this.alert.Visible = false;
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
    }
    protected void btn_editar_Click(object sender, EventArgs e)
    {
        if (this.upModal.Visible == true) { 
            this.upModal.Visible = false;
         }
        string nuevaClave = "";
        DominioTotem.Usuario usuario = new DominioTotem.Usuario();
        try
        {
                if (this.input_nombre.Value != "")
                {
                    if (this.input_apellido.Value != "")
                    {
                        if (this.input_correo.Value != "")
                        {      
                            if (this.input_pregunta.Value != "")
                            {
                                if (this.input_respuesta.Value != "")
                                {
                                    if (this.pswd_viejo.Value != "")
                                    {
                                        usuario.clave = this.pswd_viejo.Value;
                                        if (this.pswd_nuevo.Value != "" && (this.pswd_nuevo.Value == this.pswd_nuevo_conf.Value))
                                        {
                                            nuevaClave = this.pswd_nuevo.Value;
                                        }
                                        else
                                        {
                                            this.alert_password.Attributes["class"] = "alert alert-danger alert-dismissible";
                                            this.alert_password.Attributes["role"] = "alert";
                                            this.alert_password.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>la nueva contrasena esta vacia, o son distinta  a la de confirmar</div>";
                                            this.alert_password.Visible = true;
                                        }
                                    }


                                    usuario.username = this.input_usuario.Value;
                                    usuario.nombre = this.input_nombre.Value;
                                    usuario.apellido = this.input_apellido.Value;
                                    usuario.clave = nuevaClave;
                                    usuario.preguntaSeguridad = this.input_pregunta.Value;
                                    usuario.respuestaSeguridad = this.input_respuesta.Value;
                                    usuario.correo = this.input_correo.Value;
                                    
                                    LogicaNegociosTotem.Modulo7.LogicaUsuario.ModificarUsuario(usuario, nuevaClave);
                                    this.alert.Attributes["class"] = "alert alert-info alert-dismissible";
                                    this.alert.Attributes["role"] = "alert";
                                    this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cambios realizados Exitosamente</div>";
                                    this.alert.Visible = true;

                                }
                                else
                                {
                                    this.alert_respuesta.Attributes["class"] = "alert alert-danger alert-dismissible";
                                    this.alert_respuesta.Attributes["role"] = "alert";
                                    this.alert_respuesta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La respuesta de seguridad esta vacia</div>";
                                    this.alert_respuesta.Visible = true;
                                }
                            }
                            else
                            {
                                this.alert_pregunta.Attributes["class"] = "alert alert-danger alert-dismissible";
                                this.alert_pregunta.Attributes["role"] = "alert";
                                this.alert_pregunta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La pregunta de seguridad esta vacia</div>";
                                this.alert_pregunta.Visible = true;
                            }
                        }
                        else
                        {
                            this.alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
                            this.alert_correo.Attributes["role"] = "alert";
                            this.alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debes ingresar el correo</div>";
                            this.alert_correo.Visible = true;

                        }
                    }
                    else
                    {
                        this.alert_apellido.Attributes["class"] = "alert alert-danger alert-dismissible";
                        this.alert_apellido.Attributes["role"] = "alert";
                        this.alert_apellido.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido esta vacio</div>";
                        this.alert_apellido.Visible = true;
                    }
                }
                else
                {
                    this.alert_nombre.Attributes["class"] = "alert alert-danger alert-dismissible";
                    this.alert_nombre.Attributes["role"] = "alert";
                    this.alert_nombre.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre esta vacio</div>";
                    this.alert_nombre.Visible = true;
                }
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
        {
            this.alert_username.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_username.Attributes["role"] = "alert";
            this.alert_username.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Registro no se completo correctamente. Usuario vacio</div>";
            this.alert_username.Visible = true;
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD)
        {
            this.alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert.Attributes["role"] = "alert";
            this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Imposible conectar a la base de datos</div>";
            this.alert.Visible = true;
        }
        catch (ExcepcionesTotem.Modulo7.CorreoRepetidoException)
        {
            this.alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_correo.Attributes["role"] = "alert";
            this.alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Correo Repetido</div>";
            this.alert_correo.Visible = true;
        }
        catch (ExcepcionesTotem.Modulo7.ClaveNoValidaException)
        {
            this.alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert_correo.Attributes["role"] = "alert";
            this.alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La clave no pudo ser cambiada,la clave antigua introducido, no concuerda con la del sistema</div>";
            this.alert_correo.Visible = true;
        }
        catch (ExcepcionesTotem.Modulo7.RegistroUsuarioFallidoException)
        {
            this.alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            this.alert.Attributes["role"] = "alert";
            this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Registro de usuario fallido</div>";
            this.alert.Visible = true;
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_change_pswd", "$('#modal_change_pswd').modal();", true);
        this.upModal.Visible = true;
    }
}