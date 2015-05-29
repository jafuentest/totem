using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class M1_PreguntaSeguridad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";
        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
            if (user.username != "" &&
                user.clave != "")
            {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
            }

        }
        try
        {
            string correo = Request.QueryString["usuario"];
            if (correo != null && correo != "")
            {
                DominioTotem.Usuario usuario = new DominioTotem.Usuario();
                usuario.correo = correo;
                usuario =
                    LogicaNegociosTotem.Modulo1.LogicaLogin.ObtenerPreguntaUsuario(usuario);
                label_pregunta.InnerText = usuario.preguntaSeguridad;
            }
            else
            {
                Response.Redirect("~/src/GUI/Modulo1/M1_login.aspx");
            }
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Error con la informacion del usuario, " +
                "ingrese nuevamente al enlace enviado por correo</div>";
        }
        catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Hubo un error con el correo" +
                " del usuario, intente nuevamente</div>";
        }
        catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Hubo un error interno de la aplicacion" +
                ", porfavor intente nuevamente</div>";
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Hubo un error con la conexion al servidor" +
                ", porfavor intente nuevamente</div>";
        }
    }

    protected void btn_validar_respuesta_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (input_respuesta.Value != "" && input_respuesta != null)
            {
                string correo = Request.QueryString["usuario"];
                if (correo != null && correo != "")
                {
                    DominioTotem.Usuario usuario = new DominioTotem.Usuario();
                    usuario.correo = correo;
                    usuario.respuestaSeguridad = input_respuesta.Value;
                    if (LogicaNegociosTotem.Modulo1.LogicaLogin.ValidarRespuestaSecreta(usuario))
                    {
                        HttpCookie aCookie = new HttpCookie("userInfo");
                        aCookie.Values["usuario"] = Request.QueryString["usuario"];
                        aCookie.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Add(aCookie);
                        Response.Redirect("~/src/GUI/Modulo1/M1_RecuperacionClave.aspx");
                    }
                    else
                    {
                        serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        serverAlert.Attributes["role"] = "alert";

                        serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                            "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                            "\"true\">&times;</span></button>La respuesta ingresada " +
                            "no coincide con la registrada, intente nuevamente</div>";
                    }
                }
            }
            else
            {
                serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
                serverAlert.Attributes["role"] = "alert";

                serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                    "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                    "\"true\">&times;</span></button>Porfavor llene los campos " +
                    "obligatorios</div>";
            }
        }
        catch (ExcepcionesTotem.Modulo1.RespuestaErradoException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>La respuesta ingresada " + 
                "no coincide con la registrada, intente nuevamente</div>";
        }
        catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Hubo un error interno de la aplicacion" +
                ", porfavor intente nuevamente</div>";
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Error con la informacion del usuario</div>";
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Hubo un error con la conexion al servidor" +
                ", porfavor intente nuevamente</div>";
        }
    }
}