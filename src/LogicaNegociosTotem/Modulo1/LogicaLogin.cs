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
    public class LogicaLogin
    {

        /// <summary>
        /// Atributo para el control de los intentos que tendra el usuario para hacer login
        /// </summary>
        private int intentos {

            /// <summary>
            /// Metodo para obtener el numero de intentos que ha realizado el usuario/administrador
            /// </summary>
            /// <returns>Retorna el numero de intentos realizado el usuario</returns>
            private get {
                return this.intentos;}

            /// <summary>
            /// Metodo para la asignacion de los intentos realizados por el usuario/administrador
            /// </summary>
            /// <param name="value">numero de intentos realizados por el usuario</param>
            private set {
                if (this.intentos <=3){
                    this.intentos = value;}
            }
        }

        /// <summary>
        /// Constructor de la clase BDLogin
        /// </summary>
        /// <returns>Retorna el objeto con el numero de intentos inicializado en 0 </returns>
        public LogicaLogin()
        {
            this.intentos = 0;
        }

        /// <summary>
        /// Metodo para validar el inicio de sesion
        /// </summary>
        /// <param name="username">Alias asociado a la cuenta del usuario que se va a validar en el
        /// Login</param>
        /// <param name="clave">Clave utilizado por el usuario que se va a validar en el login</param>
        /// <returns>Retorna el objeto usuario si se pudo validar, de lo contrario
        /// retorna null</returns>
        public DominioTotem.Usuario Login(string username, string clave)
        {
            if (this.intentos <= 3)
            {
                this.intentos++;
                DominioTotem.Usuario auxUsuario = new DominioTotem.Usuario();
                auxUsuario.username = username;
                auxUsuario.clave = clave;
                return DatosTotem.Modulo1.BDLogin.ValidarLoginBD(auxUsuario);
            }
            else {
                throw new Exception();
            }


        }

        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le cambiara la clave</param>
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario
        /// retorna False</returns>
        public bool RecuperacionDeClave(DominioTotem.Usuario usuario){
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado de la generacion del link que debe seguir el usuario para
        /// el cambio de su clave
        /// </summary>
        /// <returns>Retorna el URL que debe seguir el usuario para cambiar su clave, de lo contrario
        /// disparara una exception</returns>
        public string GenerarLink(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }

        /// <summary>
        /// Metodo encargado del envio del correo que contenga el link para el cambio de la clave
        /// </summary>
        /// <param name="usuario">Usuario al cual se le enviara el EMAIL</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito, de lo contrario disparara
        /// una exception(EmailErradoException)</returns>
        public bool EnviarEmail(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();

        }
        
        /// <summary>
        /// Metodo encargado de validar la respuesta de seguridad utilizada por el usuario
        /// </summary>
        /// <param name="usuario">Usuario al cual se le validara la respuesta</param>      
        /// <returns>Retorna True si el correo pudo ser enviado con exito, de lo contrario disparara
        /// una exception (RespuestaErradoException)</returns>
        public bool ValidarRespuestaSecreta(string respuesta)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado del cambio de clave del usuario
        ///</summary>
        /// <param name="usuario">Usuario al cual se cambiara la clave de acceso al sistema</param>      
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario retorna False</returns>
        public bool CambioDeClave(DominioTotem.Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Metodo encargado del cierre de sesion
        ///</summary>
        /// <returns>Retorna True si el cambio de clave fue exitoso, de lo contrario retornara False</returns>
        public bool CerrarSesion()
        {
            throw new System.NotImplementedException();

        }

    }
}
