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
            else
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
                    Response.Redirect("~/src/GUI/Modulo1/M1_login.aspx?success=1");
                }
               
            }
        }
        catch (ExcepcionesTotem.ExceptionTotem ex)
        {

        }
    }
}