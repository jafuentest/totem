using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LogicaNegociosTotem.Modulo1;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";
        Master.ShowDiv = false;
        Master.MostrarMenuLateral = false;
        captchaContainer.Visible = false;
        #region Redireccionamiento a Default
        if (HttpContext.Current.Session["Credenciales"] != null) {
            HttpContext.Current.Response.Redirect("Default.aspx");
        }
        #endregion

    }
    protected void Login_Click(object sender, EventArgs e) {
        
        try
        {
            
            string usuario = this.input_usuario.Value;
            string clave = this.input_pswd.Value;
            if (usuario.Equals("")) {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ingrese un username</div>";
            }
            else if (clave.Equals("")) {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ingrese una clave</div>";
            }
            else
            {
                HttpContext.Current.Session["Credenciales"] = LogicaLogin.Login(usuario,clave);
                HttpContext.Current.Response.Redirect("Default.aspx");
            }

        }
        catch (ExcepcionesTotem.Modulo1.IntentosFallidosException error)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ya ha tratado de ingresar al sistema 3 veces,Por favor ingrese el captcha correspondiente</div>";
            captchaContainer.Visible = true;
                          
                            
        }
        catch (ExcepcionesTotem.Modulo1.LoginErradoException error)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Credenciales no validas</div>";
           
        }
        catch (ExcepcionesTotem.ExceptionTotemConexionBD error)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Imposible de estamblecer conexion con la base de datos</div>";

        }    
    }
}