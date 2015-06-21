using System;
using System.Web;
using Contratos.Modulo1;
using ExcepcionesTotem.Modulo1;

namespace Presentadores.Modulo1
{
    public class PresentadorClave
    {
        private IContratoClave vista;

        public PresentadorClave(IContratoClave laVista)
        {
            vista = laVista;
        }

        public void ManejarEventoPassword_Click(HttpRequest request)
        {
            try
            {
                if (request.Cookies["userInfo"] == null)
                    throw new ErrorParametroHttpRequest(RecursosM1.Mensaje_parametroHttp); 
                if (string.IsNullOrEmpty(vista.Password) || string.IsNullOrEmpty(vista.PasswordConfirmar))
                    throw  new Exception(RecursosM1.Mensaje_campoVacio);
                if (!vista.Password.Equals(vista.PasswordConfirmar))
                    throw new Exception(RecursosM1.Mensaje_passwordNoCoincide);
                HttpContext.Current.Response.Redirect("../Modulo1/Login.aspx");
            }
            catch (Exception e)
            {
                vista.setMensaje(true, e.Message);
            }
        }

    }

}
