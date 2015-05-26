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
        #region Validar Login
        /// <summary>
        /// Metodo para validar el inicio de sesion en la base de datos
        /// Excepciones posibles: 
        /// LoginErradoException: Excepcion de login invalido
        /// ExceptionTotemConexionBD: Excepcion de base de datos sql server
        /// ParametroInvalidoException: Excepcion de parametros erroneos
        /// UsuarioVacioException: Excepcion si alguna de la informacion del usuario
        /// es vacia o incorrecta
        /// </summary>
        /// <param name="user">Usuario al que se le va a validar el inicio de sesion
        /// debe tener como minimo el nombre de usuario o email y contrasena</param>
        /// <returns>Retorna el objeto usuario si se pudo validar</returns>
        public static Usuario ValidarLoginBD(Usuario user)
        {
            if (user.username != null && user.clave != null && user.username!="" &&
                user.clave != "")
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo1.Parametro_Input_Username,  
                    SqlDbType.VarChar, user.username, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Input_Clave, 
                    SqlDbType.VarChar, user.clave, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Output_Usu_nombre, 
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Output_Usu_apellido, 
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Output_Usu_rol, 
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Output_Usu_correo, 
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Output_Usu_cargo, 
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                try
                {
                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(
                        RecursosBDModulo1.Query_ValidarLogin, parametros);
                    if (resultados != null)
                    {
                        foreach (Resultado resultado in resultados)
                        {
                            if (resultado.etiqueta.Equals(RecursosBDModulo1.Parametro_Output_Usu_nombre))
                            {
                                user.nombre = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBDModulo1.Parametro_Output_Usu_apellido))
                            {
                                user.apellido = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBDModulo1.Parametro_Output_Usu_rol))
                            {
                                user.rol = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBDModulo1.Parametro_Output_Usu_correo))
                            {
                                user.correo = resultado.valor;
                            }
                            if (resultado.etiqueta.Equals(RecursosBDModulo1.Parametro_Output_Usu_cargo))
                            {
                                user.cargo = resultado.valor;
                            }
                        }
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.LoginErradoException(RecursosBDModulo1.Codigo_Login_Errado,
                            RecursosBDModulo1.Mensaje_Login_Errado, new Exception());
                    }
                    if (user.nombre != null && user.nombre != "")
                    {
                        return user;
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.LoginErradoException(RecursosBDModulo1.Codigo_Login_Errado,
                            RecursosBDModulo1.Mensaje_Login_Errado, new ExcepcionesTotem.ExceptionTotem());
                    }
                }
                catch (ExcepcionesTotem.Modulo1.LoginErradoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.LoginErradoException(ex.Codigo, ex.Mensaje, ex);
                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (ParametroInvalidoException ex)
                {
                    throw new ParametroInvalidoException(RecursoGeneralBD.Codigo_Parametro_Errado,
                        RecursoGeneralBD.Mensaje_Parametro_Errado, ex);
                }
            }
            else
            {
                throw new UsuarioVacioException(RecursosBDModulo1.Codigo_Usuario_Vacio, 
                    RecursosBDModulo1.Mensaje_Usuario_Vacio, new Exception());
            }
        }
        #endregion

        #region Obtener Pregunta Seguridad
        /// <summary>
        /// Metodo para obtener a pregunta de seguridad de un usuario de la base de datos
        /// Se requiere que el usuario tenga su correo cargado, de lo contrario
        /// se lanza una excepcion
        /// </summary>
        /// <param name="user">Usuario al que se le va a obtener la pregunta de
        /// seguridad</param>
        /// <returns>Retorna un objeto usuario con su pregunta de seguridad</returns>
        public static Usuario ObtenerPreguntaSeguridad(Usuario user)
        {
            if (user != null && user.correo != null && user.correo != "")
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro parametro = new Parametro(RecursosBDModulo1.Parametro_Input_Correo,
                    SqlDbType.VarChar , user.correo, false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursosBDModulo1.Parametro_Output_PreguntaSeguridad, 
                    SqlDbType.VarChar, true);
                parametros.Add(parametro);
                try
                {
                    BDConexion con = new BDConexion();
                    List<Resultado> resultados = con.EjecutarStoredProcedure(
                        RecursosBDModulo1.Query_Obtener_Pregunta_Seguridad, parametros);
                    if (resultados != null)
                    {
                        foreach (Resultado resultado in resultados)
                        {
                            if (resultado != null && resultado.etiqueta != "")
                            {
                                if (resultado.etiqueta.Equals(RecursosBDModulo1.Parametro_Output_PreguntaSeguridad))
                                {
                                    user.preguntaSeguridad = resultado.valor;
                                }
                                else
                                {
                                    throw new EmailErradoException(RecursosBDModulo1.Codigo_Email_Errado,
                                        RecursosBDModulo1.Mensaje_Email_errado,
                                        new EmailErradoException());
                                }
                            }
                            else
                            {
                                throw new EmailErradoException(RecursosBDModulo1.Codigo_Email_Errado,
                                        RecursosBDModulo1.Mensaje_Email_errado,
                                        new EmailErradoException());
                            }
                        }
                        if (user.preguntaSeguridad != "")
                        {
                            return user;
                        }
                        else
                        {
                            throw new EmailErradoException(RecursosBDModulo1.Codigo_Email_Errado,
                                        RecursosBDModulo1.Mensaje_Email_errado,
                                        new EmailErradoException());
                        }
                    }
                    else
                    {
                        throw new EmailErradoException(RecursosBDModulo1.Codigo_Email_Errado,
                            RecursosBDModulo1.Mensaje_Email_errado,
                            new EmailErradoException());
                    }
                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(ex.Codigo, ex.Mensaje, ex);
                }
                catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.EmailErradoException(ex.Codigo, ex.Mensaje, ex);
                }
                catch (ParametroInvalidoException ex)
                {
                    throw new ParametroInvalidoException(RecursoGeneralBD.Codigo_Parametro_Errado,
                        RecursoGeneralBD.Mensaje_Parametro_Errado, ex);
                }
            }
            else
            {
                throw new UsuarioVacioException(RecursosBDModulo1.Codigo_Usuario_Vacio,
                    RecursosBDModulo1.Mensaje_Usuario_Vacio,
                    new UsuarioVacioException());
            }
        }
        #endregion

        #region Validar Pregunta de Seguridad
        /// <summary>
        /// Metodo para validar la respuesta a la pregunta de seguridad en la base de datos
        /// </summary>
        /// <param name="user">Usuario con la respuesta a la pregunta de seguridad cargada
        /// </param>
        /// <returns>Retorna true si es correcto, de lo contrario false</returns>
        public static bool ValidarPreguntaSeguridadBD(Usuario user)
        {
            if (user != null)
            {
                if (user.respuestaSeguridad != null &&
                user.respuestaSeguridad != "")
                {
                    string resultadoDeRespuesta = "";
                    List<Parametro> parametros = new List<Parametro>();
                    Parametro parametro = new Parametro(RecursosBDModulo1.Parametro_Input_Correo,
                        SqlDbType.VarChar, user.correo, false);
                    parametros.Add(parametro);
                    parametro = new Parametro(RecursosBDModulo1.Parametro_Output_RespuestaSeguridad,
                        SqlDbType.VarChar, true);
                    parametros.Add(parametro);
                    try
                    {
                        BDConexion con = new BDConexion();
                        List<Resultado> resultados = con.EjecutarStoredProcedure(
                            RecursosBDModulo1.Query_Validar_Pregunta_Seguridad,
                            parametros);
                        if (resultados != null)
                        {
                            foreach (Resultado resultado in resultados)
                            {
                                if (resultado.valor != null &&
                                    !resultado.valor.Equals(""))
                                {
                                    resultadoDeRespuesta = resultado.valor;
                                }
                                else
                                {
                                    throw new EmailErradoException(RecursosBDModulo1.Codigo_Email_Errado,
                                        RecursosBDModulo1.Mensaje_Email_errado,
                                        new EmailErradoException());
                                }
                            }

                            if (resultadoDeRespuesta.Equals(user.respuestaSeguridad))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            throw new EmailErradoException(RecursosBDModulo1.Codigo_Email_Errado,
                                RecursosBDModulo1.Mensaje_Email_errado,
                                new EmailErradoException());
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                            RecursoGeneralBD.Mensaje, ex);
                    }
                    catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                    {
                        throw new ExcepcionesTotem.ExceptionTotemConexionBD(ex.Codigo, ex.Mensaje, ex);
                    }
                    catch (EmailErradoException ex)
                    {
                        throw new EmailErradoException(ex.Codigo, ex.Mensaje, ex);
                    }
                    catch (ParametroInvalidoException ex)
                    {
                        throw new ParametroInvalidoException(RecursoGeneralBD.Codigo_Parametro_Errado,
                            RecursoGeneralBD.Mensaje_Parametro_Errado, ex);
                    }
                }
                else
                {
                    throw new UsuarioVacioException(RecursosBDModulo1.Codigo_Usuario_Vacio,
                    RecursosBDModulo1.Mensaje_Usuario_Vacio, new UsuarioVacioException());
                }
            }
            else
            {
                throw new UsuarioVacioException(RecursosBDModulo1.Codigo_Usuario_Vacio,
                    RecursosBDModulo1.Mensaje_Usuario_Vacio, new UsuarioVacioException());

            }
        }
        #endregion
    }
}
