using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "1";
        Master.ShowDiv = false;
        Master.MostrarMenuLateral = false;
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
            DominioTotem.Usuario loginUsuario = new DominioTotem.Usuario();
            loginUsuario.username = usuario;
            loginUsuario.clave = clave;
            LogicaNegociosTotem.Modulo1.LogicaLogin miLogica = new LogicaNegociosTotem.Modulo1.LogicaLogin();
            HttpContext.Current.Session["Credenciales"] = miLogica.Login(loginUsuario);
            HttpContext.Current.Response.Redirect("Default.aspx");

        }
        catch (ExcepcionesTotem.Modulo1.IntentosFallidosException error)
        {

        }
        catch (ExcepcionesTotem.Modulo1.LoginErradoException error)
        {

        }    
    }
}