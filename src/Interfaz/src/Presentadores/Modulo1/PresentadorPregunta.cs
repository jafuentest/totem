using System;
using System.Web;
using Contratos.Modulo1;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;

namespace Presentadores.Modulo1
{
    public class PresentadorPregunta
    {
        private IContratoPregunta vista;

        public PresentadorPregunta(IContratoPregunta laVista)
        {
            vista = laVista;
        }

        public void CargarPregunta(HttpRequest request)
        {
            try
            {
                var correo = request.QueryString["usuario"];
                if (string.IsNullOrEmpty(correo))
                    throw new ErrorParametroHttpRequest("Error en el Parámetro Http");

                var credenciales = (Usuario)FabricaEntidades.ObtenerUsuario(null, null, "Alberto", "APELLIDO",
                    "Administrador", "correo", "¿Cómo se llamaba tu primera mascota?", "Fifi", null);

                var pregunta = credenciales.PreguntaSeguridad;
                if (string.IsNullOrEmpty(pregunta))
                    throw new ParametroInvalidoException("Error en la Carga de la Pregunta Secreta");

                vista.Pregunta = pregunta;

            }
            catch (Exception e)
            {
                vista.setMensaje(true, e.Message);
            }
        }

        public void ManejarEventoPregunta_Click(HttpRequest request, HttpResponse response)
        {
            string respuesta = vista.Respuesta;

            if (string.IsNullOrEmpty(respuesta))
            {
                vista.setMensaje(true, "Debe Ingresar una Respuesta");
            }
            else
            {
                try
                {
                    var correo = request.QueryString["usuario"];
                    var credenciales = (Usuario)FabricaEntidades.ObtenerUsuario(null, null, "Alberto", "APELLIDO",
                    "Administrador", "correo", "¿Cómo se llamaba tu primera mascota?", "fifi", null);
                    if (respuesta.Equals(credenciales.RespuestaSeguridad))
                    {
                        HttpCookie aCookie = new HttpCookie("userInfo");
                        aCookie.Values["usuario"] = correo;
                        aCookie.Expires = DateTime.Now.AddMinutes(15);
                        response.Cookies.Add(aCookie);
                        vista.setMensaje(false, "Correcto");
                        HttpContext.Current.Response.Redirect("../Modulo1/RecuperacionClave.aspx");
                    }
                    else
                    {
                        throw new RespuestaErradoException("La Respuesta es Incorrecta");
                    }

                }
                catch (Exception e)
                {
                    vista.setMensaje(true, e.Message);
                }

            }
        }

    }
}
