using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo1
{
    /// <summary>
    /// Clase para el manejo logico del login/logout y 
    /// recuperacion de clave
    /// </summary>
    public static class LogicaLogin
    {

        /// <summary>
        /// Atributo para el control de los intentos que tendra el usuario para hacer login
        /// </summary>
        private static int intentos=0;

        /// <summary>
        /// Constructor de la clase BDLogin
        /// </summary>
        /// <returns>Retorna el objeto con el numero de intentos inicializado en 0 </returns>
      

        /// <summary>
        /// Metodo para validar el inicio de sesion
        /// </summary>
        /// <param name="usuario">Usuario con atributos username y clave para realizar el Log in
        /// <returns>Retorna el objeto usuario si se pudo validar, de lo contrario
        /// retorna null</returns>
        public static DominioTotem.Usuario Login(string Username, string Clave)
        {
            
            if (intentos < 3)
            {

                try
                {
                    intentos++;
                    DominioTotem.Usuario loginUser = new DominioTotem.Usuario();
                    loginUser.username = Username;
                    loginUser.clave = Clave;
                    DominioTotem.Usuario retornoUser= DatosTotem.Modulo1.BDLogin.ValidarLoginBD(loginUser);
                    intentos = 0;
                    return retornoUser;
                }
                catch (ExcepcionesTotem.Modulo1.LoginErradoException)
                {
                    throw new ExcepcionesTotem.Modulo1.LoginErradoException();
                }
                catch (ExcepcionesTotem.Modulo1.UsuarioVacioException)
                {
                    throw new ExcepcionesTotem.Modulo1.UsuarioVacioException();
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD();
                }
            }
            else 
            {
                throw new ExcepcionesTotem.Modulo1.IntentosFallidosException();
            }


        }

        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le cambiara la clave</param>
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario
        /// retorna False</returns>
        public static bool RecuperacionDeClave(DominioTotem.Usuario usuario){
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de la generacion del link que debe seguir el usuario para
        /// el cambio de su clave
        /// </summary>
        /// <returns>Retorna el URL que debe seguir el usuario para cambiar su clave, de lo contrario
        /// disparara una exception</returns>
        public static string GenerarLink(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Metodo encargado del envio del correo que contenga el link para el cambio de la clave
        /// </summary>
        /// <param name="usuario">Usuario al cual se le enviara el EMAIL</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito, de lo contrario disparara
        /// una exception(EmailErradoException)</returns>
        public static bool EnviarEmail(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }
        
        /// <summary>
        /// Metodo encargado de validar la respuesta de seguridad utilizada por el usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le validara la respuesta</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito, de lo contrario disparara
        /// una exception (RespuestaErradoException)</returns>
        public static bool ValidarRespuestaSecreta(string respuesta)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        ///</summary>
        /// <param name="usuario">Usuario al cual se cambiara la clave de acceso al sistema</param>      
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario retorna False</returns>
        public static bool CambioDeClave(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado del cierre de sesion
        ///</summary>
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario retornara False</returns>
        public static bool CerrarSesion()
        {
            throw new System.NotImplementedException();

        }

    }
}
