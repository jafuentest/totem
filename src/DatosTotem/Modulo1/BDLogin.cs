using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem.Modulo1;
using System.Data;
using System.Data.SqlClient;

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
        /// Excepciones posibles: 
        /// LoginErradoException: Excepcion de login invalido
        /// </summary>
        /// <param name="user">Usuario al que se le va a validar el inicio de sesion
        /// debe tener como minimo el nombre de usuario o email y contrasena</param>
        /// <returns>Retorna el objeto usuario si se pudo validar</returns>
        public static Usuario ValidarLoginBD(Usuario user)
        {
            if (user.username != null && user.clave != null)
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro("@Username",  SqlDbType.VarChar, user.username, false);
                parametros.Add(parametro);
                parametro = new Parametro("@Clave", SqlDbType.VarChar, user.clave, false);
                parametros.Add(parametro);
                parametro = new Parametro("@Usu_nombre", SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro("@Usu_apellido", SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro("@Usu_rol", SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro("@Usu_correo", SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro("@Usu_cargo", SqlDbType.VarChar, true);
                parametros.Add(parametro);
                string query = "validarlogin";
                try
                {
                    BDConexion con = new BDConexion();
                    SqlDataReader oReader = con.EjecutarStoredProcedure(query, parametros);
                    //Console.WriteLine(oReader["@Usu_nombre"].ToString());
                }
                catch (Exception)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD();
                }
                return user;
            }
            else
            {
                throw new UsuarioVacioException(RecursosBDModulo1.Codigo_Usuario_Vacio, RecursosBDModulo1.Mensaje_Usuario_Vacio, new Exception());
            }
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
