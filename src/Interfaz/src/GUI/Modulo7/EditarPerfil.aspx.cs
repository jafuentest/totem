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
                    this.pswd_nuevo.Value = datoUsuario.clave;
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
        DominioTotem.Usuario usuario = new DominioTotem.Usuario();
        
        if (this.input_usuario.Value != "")
        {
            if (this.input_nombre.Value != "")
            {
                if (this.input_apellido.Value != "")
                {
                    if (this.input_correo.Value != "")
                    {
                        String antiguoCorreo = this.input_correo.Value;
                        if (this.input_pregunta.Value != "")
                        {
                            if (this.input_respuesta.Value != "")
                            {
                                if(this.pswd_viejo.Value != ""){
                                    if (this.pswd_nuevo.Value != null && (this.pswd_nuevo.Value == this.pswd_nuevo_conf.Value))
                                    {
                                        usuario.clave = this.pswd_nuevo.Value;
                                    }
                                    else
                                    {
                                        alert_password.Attributes["class"] = "alert alert-danger alert-dismissible";
                                        alert_password.Attributes["role"] = "alert";
                                        alert_password.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>la nueva contrasena esta vacia, o son distinta  a la de confirmar</div>";
                                        alert_password.Visible = true;
                                    }
                                }
 

                                usuario.username = this.input_usuario.Value;
                                usuario.nombre = this.input_nombre.Value;
                                usuario.apellido = this.input_apellido.Value;
                                usuario.preguntaSeguridad = this.input_pregunta.Value;
                                usuario.respuestaSeguridad = this.input_respuesta.Value;
                                usuario.correo = this.input_correo.Value;
                                LogicaNegociosTotem.Modulo7.LogicaUsuario.ModificarUsuario(usuario,antiguoCorreo,usuario.clave);
                               
                                }else{
                                alert_respuesta.Attributes["class"] = "alert alert-danger alert-dismissible";
                                alert_respuesta.Attributes["role"] = "alert";
                                alert_respuesta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La respuesta de seguridad esta vacia</div>";
                                alert_respuesta.Visible = true;
                            }
                        } else {
                            alert_pregunta.Attributes["class"] = "alert alert-danger alert-dismissible";
                            alert_pregunta.Attributes["role"] = "alert";
                            alert_pregunta.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>La pregunta de seguridad esta vacia</div>";
                            alert_pregunta.Visible = true;
                        }
                    } else {
                        alert_correo.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert_correo.Attributes["role"] = "alert";
                        alert_correo.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Debes ingresar el correo</div>";
                        alert_correo.Visible = true;

                    }
                } else {
                    alert_apellido.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert_apellido.Attributes["role"] = "alert";
                    alert_apellido.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El apellido esta vacio</div>";
                    alert_apellido.Visible = true;
                }
            }else {
                alert_nombre.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert_nombre.Attributes["role"] = "alert";
                alert_nombre.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre esta vacio</div>";
                alert_nombre.Visible = true;
            }

        }
        else
        {
            alert_username.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert_username.Attributes["role"] = "alert";
            alert_username.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>El nombre esta vacio</div>";
            alert_username.Visible = true;
        }
    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
    }
    protected void Unnamed1_Click1(object sender, EventArgs e)
    {
        this.modal_change_pswd.Visible = true;
    }
}