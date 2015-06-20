using System.Web;
using Contratos.Modulo1;
using Dominio;
using Dominio.Fabrica;

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
                Entidad credenciales = FabricaEntidades.ObtenerUsuario("albertods", "123456", "Alberto", "APELLIDO",
                    "Administrador", "correo", null, null, null);
                HttpContext.Current.Session["Credenciales"] = credenciales;
                HttpContext.Current.Response.Redirect("Default.aspx");
            }

        }

    }
}
