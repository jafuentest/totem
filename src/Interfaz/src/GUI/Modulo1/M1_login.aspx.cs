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
        if (!LogicaLogin.captchaActivo)
        {
            captchaContainer.Visible = false;
        }

        #region Redireccionamiento a Default
        
        #endregion

        String log = Request.QueryString["logout"];
        if (log != null)
        {
            if (log.Equals("true"))
            {
               

                 HttpContext.Current.Session.Abandon();
                 HttpContext.Current.Response.Redirect("Default.aspx");
            }
        }

        string success = Request.QueryString["success"];
        if (success != null)
        {
            if (success.Equals("2"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";

                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" " + 
                    "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" + 
                    "\"true\">&times;</span></button>Se ha enviado un correo" +
                    " con los pasos a seguir</div>";
          
            }
            if (success.Equals("1"))
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";

                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" " + 
                    "data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=" + 
                    "\"true\">&times;</span></button>Se ha cambiado exitosamente" + 
                    " su clave</div>";
            }
        }

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
                if (!LogicaLogin.captchaActivo)
                {
                    DominioTotem.Usuario usu = new DominioTotem.Usuario();
                    usu.username = "admin";
                    usu.clave = "admin ";
                    HttpContext.Current.Session["Credenciales"] = LogicaLogin.Login(usuario, clave);
                    HttpContext.Current.Session["Credenciales"] = usu;
                    HttpContext.Current.Response.Redirect("Default.aspx");
                
                }
                else {
                    recaptcha.Validate();
                    Page.Validate();
                  
                    if (Page.IsValid)
                    {
                        HttpContext.Current.Session["Credenciales"] = LogicaLogin.Login(usuario, clave);
                        HttpContext.Current.Response.Redirect("Default.aspx");
                    }
                    else{
                        alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ingrese el captcha de forma correcta</div>";
                    }
                
                }
            }

        }
        catch (ExcepcionesTotem.Modulo1.IntentosFallidosException error)
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ya ha tratado de ingresar al sistema 3 veces,Por favor ingrese el captcha correspondiente</div>";
            captchaContainer.Visible = true;
            LogicaLogin.captchaActivo = true;              
                            
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
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Imposible de establecer conexion con la base de datos</div>";

        }    
    }
}