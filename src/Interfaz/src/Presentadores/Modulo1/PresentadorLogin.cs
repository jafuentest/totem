using System.Web;
using Contratos.Modulo1;
using Dominio.Entidades.Modulo7;

namespace Presentadores.Modulo1
{
    public class PresentadorLogin
    {
        private IContratoLogin vista;

        public PresentadorLogin(IContratoLogin laVista)
        {
            vista = laVista;
        }

        public void ManejarEventoLogin_Click()
        {
            string usuario = vista.Usuario;
            string clave = vista.Clave;

           if (usuario.Equals(""))
            {
                vista.Mensaje = "Ingrese un Username";
            }
            else if (clave.Equals(""))
            {
                vista.Mensaje = "Ingrese una Contraseña";
            }
            else
            {
                HttpContext.Current.Session["Credenciales"] = new Usuario("albertods", "123456", "Alberto", "APELLIDO",
                    "Administrador", "correo", null, null, null);
                HttpContext.Current.Response.Redirect("Default.aspx");
            }

        }

    }
}
