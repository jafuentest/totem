using System;
using System.Web;
using Contratos.Modulo1;
using ExcepcionesTotem.Modulo1;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;
using Comandos;
using Comandos.Fabrica;
using System;
using System.Collections.Generic;


namespace Presentadores.Modulo1
{
    public class PresentadorClave
    {
        private IContratoClave vista;

        /// <summary>
        /// Constructor de PresentadorCalve
        /// </summary>
        /// <param name="laVista">Contrato que se utiliza para tener acceso a algunos componentes
        /// de la interfaz</param>
        public PresentadorClave(IContratoClave laVista)
        {
            vista = laVista;
        }

        /// <summary>
        /// Metodo que maneja el OnClick del boton Cambiar clave
        /// </summary>
        /// <param name="request"></param>
        public void ManejarEventoPassword_Click(HttpRequest request)
        {
            try
            {
                string correo= request.Cookies[RecursosM1.Parametro_userInfo][RecursosM1.Parametro_usuario];
                if (request.Cookies[RecursosM1.Parametro_userInfo] == null)
                    throw new ErrorParametroHttpRequest(RecursosM1.Mensaje_parametroHttp); 
                if (string.IsNullOrEmpty(vista.Password) || string.IsNullOrEmpty(vista.PasswordConfirmar))
                    throw  new Exception(RecursosM1.Mensaje_campoVacio);
                if (!vista.Password.Equals(vista.PasswordConfirmar))
                    throw new Exception(RecursosM1.Mensaje_passwordNoCoincide);
                FabricaEntidades fabricaEntidades = new FabricaEntidades();
                Entidad usuario = fabricaEntidades.ObtenerUsuario();
                Comando<List<string>, string> comandoDesencriptar = FabricaComandos.CrearComandoDesencriptar();
                List<string> lista = new List<string>();
                lista.Add(correo);
                lista.Add(RecursosM1.Passphrase);
                ((Usuario)usuario).Correo = comandoDesencriptar.Ejecutar(lista);
                ((Usuario)usuario).Clave = vista.Password;
                Comando<Entidad, bool> comando = FabricaComandos.CrearComandoCambioDeClave();
                if (comando.Ejecutar(usuario))
                {
                    HttpContext.Current.Response.Redirect(RecursosM1.Ventana_Login);
                }
                else
                {
                    vista.setMensaje(true,RecursosM1.Mensaje_ErrorCambioClave);
                }
            }
            catch (ExcepcionesTotem.Modulo1.UsuarioVacioException ex)
            {
                vista.setMensaje(true, ex.Mensaje);
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                vista.setMensaje(true, ex.Mensaje);
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {
                vista.setMensaje(true, ex.Mensaje);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                vista.setMensaje(true, ex.Mensaje);
            }
            catch (Exception e)
            {
                vista.setMensaje(true, e.Message);
            }
        }

    }

}
