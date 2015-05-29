using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class M1_RecuperacionClave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";
        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
                Master.MostrarMenuLateral = false;
                Master.ShowDiv = false;
        }
        if (Request.Cookies["userInfo"] == null || 
            Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) == "")
        {
            Response.Redirect("~/src/GUI/Modulo1/M1_login.aspx");
        }
    }
    protected void btn_Confirmar_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (Request.Cookies["userInfo"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "")
                {
                    if (input_clave != null && input_clave.Value != ""
                        && input_clave_confs != null && input_clave_confs.Value != "")
                    {
                        if (input_clave.Value.Equals(input_clave_confs.Value))
                        {
                            DominioTotem.Usuario usuario = new DominioTotem.Usuario();
                            usuario.correo =
                                Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]);
                            usuario.clave = input_clave.Value;
                            LogicaNegociosTotem.Modulo1.LogicaLogin.CambioDeClave(usuario);
                            Request.Cookies["userInfo"]["usuario"] = "";
                            Response.Redirect("~/src/GUI/Modulo1/M1_login.aspx?success=1");
                        }
                        else
                        {
                            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
                            serverAlert.Attributes["role"] = "alert";

                            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" + 
                                "\"true\">&times;</span></button>La clave y su confirmacion" + 
                                " no son iguales</div>";
                            pswd_nuevo.Attributes["class"] += "has-error";
                            pswd_confirmacion.Attributes["class"] += "has-error";
                        }
                    }
                    else
                    {
                        serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        serverAlert.Attributes["role"] = "alert";

                        serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                            "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                            "\"true\">&times;</span></button>Porfavor llene los campos requeridos" +
                            "</div>";
                    }
                }
            }
        }
        catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
        {
            serverAlert.Attributes["class"] = "alert alert-danger alert-dismissible";
            serverAlert.Attributes["role"] = "alert";

            serverAlert.InnerHtml = "<div><button type=\"button\" class=\"close\" " +
                "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" +
                "\"true\">&times;</span></button>Error con la informacion del usuario" +
                " verifique que tenga los cookies activados e intente nuevamente</div>";
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
}