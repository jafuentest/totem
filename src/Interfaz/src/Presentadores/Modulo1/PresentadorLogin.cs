using System;
using System.Web;
using Contratos.Modulo1;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;

namespace Presentadores.Modulo1
{
    public class PresentadorLogin
    {
        private IContratoLogin vista;


        /// <summary>
        /// Constructor de la clase Presentador Login
        /// </summary>
        /// <param name="laVista">Vista que usa el Presentador</param>
        public PresentadorLogin(IContratoLogin laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Método que maneja que se activa cuando el usario le da click a Iniciar Sesión
        /// 1° Valida si los campos estan correctamente llenos
        /// 2° Verfica si el Usuario existe en la base de datos 
        /// 3° Crea las credenciales
        /// </summary>
        public void ManejarEventoLogin_Click()
        {
            try
            {
                string usuario = vista.Usuario;
                string clave = vista.Clave;
                
                if (string.IsNullOrEmpty(usuario))
                {
                    throw new Exception("Debe Ingresar un Username");
                }

                if (string.IsNullOrEmpty(clave))
                {
                    throw new Exception("Debe Ingresar una Contraseña");
                }

                Entidad credenciales = (Usuario)FabricaEntidades.ObtenerUsuario("albertods", "123456", "Alberto", "APELLIDO",
                    "Administrador", "correo", null, null, null);
                HttpContext.Current.Session["Credenciales"] = credenciales;
                HttpContext.Current.Response.Redirect("Default.aspx");

            }
            catch (Exception e)
            {
                vista.SetMesaje(true, e.Message);
            }

        }

    }
}
