using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class M1_IntroducirCorreo : System.Web.UI.Page
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

        
    }

    protected void btn_Enviar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (input_correo.Value != "")
            {
                DominioTotem.Usuario usuario = new DominioTotem.Usuario();
                usuario.correo = input_correo.Value;
                if (LogicaNegociosTotem.Modulo1.LogicaLogin.RecuperacionDeClave(usuario))
                {
                    Response.Redirect("~/src/GUI/Modulo1/M1_login.aspx?success=2");
                }

            }
            else
            {
                serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
                serverAlert.Attributes["role"] = "alert";

                serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                    "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                    "\"true\">&times;</span></button>Porfavor llenar todos los campos" +
                    "</div>";
            }
        }
        catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>El correo electronico ingresado" +
                " es erroneo o no se encuentra registrado</div>";
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
                "\"true\">&times;</span></button>Hubo un problema con la conexion " +
                "al servidor, porfavor intente nuevamente</div>";
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Los datos ingresados son incorrectos" +
                "</div>";
        }
        catch (ExcepcionesTotem.Modulo1.ErrorEnvioDeCorreoException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Hubo un error en el envio del correo," +
                " asegurese que ingreso bien su cuenta e intente nuevamente</div>";
        }
    }
}