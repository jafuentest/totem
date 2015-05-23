using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;

namespace DatosTotem.Modulo1
{
    /// <summary>
    /// Clase para el manejo de las conexiones a la base de datos para el login/logout y 
    /// recuperacion de clave
    /// </summary>
    public static class BDLogin
    {
        /// <summary>
        /// Metodo para validar el inicio de sesion en la base de datos
        /// </summary>
        /// <param name="user">Usuario al que se le va a validar el inicio de sesion
        /// debe tener como minimo el nombre de usuario o email y contrasena</param>
        /// <returns>Retorna el objeto usuario si se pudo validar, de lo contrario
        /// retorna null</returns>
        public static Usuario ValidarLoginBD(Usuario user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo para obtener a pregunta de seguridad de un usuario de la base de datos
        /// </summary>
        /// <param name="user">Usuario al que se le va a obtener la pregunta de
        /// seguridad</param>
        /// <returns>Retorna un objeto usuario con su pregunta de seguridad</returns>
        public static Usuario ObtenerPreguntaSeguridad(Usuario user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para validar la respuesta a la pregunta de seguridad en la base de datos
        /// </summary>
        /// <param name="user">Usuario con la respuesta a la pregunta de seguridad cargada
        /// </param>
        /// <returns>Retorna true si es correcto, de lo contrario false</returns>
        public static bool ValidarPreguntaSeguridadBD(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
