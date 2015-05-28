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
            else
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

        }
        catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
        {

        }
        catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
        {

        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
        {

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
                        Response.Redirect("~/src/GUI/Modulo1/M1_RecuperacionClave.aspx");
                    }
                    else
                    {
                        //Mensaje de respuesta errada
                    }
                }
            }
            else
            {
                //Alerta
            }
        }
        catch (ExcepcionesTotem.Modulo1.RespuestaErradoException ex)
        {
            
        }
        catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
        {
            
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
        {
            
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
        {
            
        }
    }
}