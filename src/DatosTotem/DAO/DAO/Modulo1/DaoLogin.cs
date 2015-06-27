using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;
using Datos.IntefazDAO.Modulo1;


namespace Datos.DAO.Modulo1
{
    public class DaoLogin : DAOGeneral,IDaoLogin
    {
        private FabricaEntidades fabricaEntidades = new FabricaEntidades();
        private Entidad _usuario;

        #region Metodos IDAOLogin
        /// <summary>
        /// Metodo que se utiliza para validar el login de un usuario
        /// </summary>
        /// <param name="parametro">Entidad de tipo usuario que recibe el login del mismo</param>
        /// <returns>Retorna el usuario con los datos completos.
        /// En caso de que el login no sea correcto devuelve nulo</returns>
        public Entidad ValidarUsuarioLogin(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            SqlConnection conect = Conectar();
            if (usuario.Username != null && usuario.Clave != null && usuario.Username != "" && usuario.Clave != "")
            {
                try
                {
                    
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_ValidarLogin, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Username, usuario.Username));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Clave, usuario.Clave));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            usuario.Nombre = leer[RecursosDaoModulo1.Parametro_Output_Usu_nombre].ToString();
                            usuario.Apellido = leer[RecursosDaoModulo1.Parametro_Output_Usu_apellido].ToString();
                            usuario.Rol = leer[RecursosDaoModulo1.Parametro_Output_Usu_rol].ToString();
                            usuario.Correo = leer[RecursosDaoModulo1.Parametro_Output_Usu_correo].ToString();
                            usuario.Cargo = leer[RecursosDaoModulo1.Parametro_Output_Usu_cargo].ToString();

                            return usuario;
                        }

                        return null;
                    }
                    else
                    {
                        ExcepcionesTotem.Modulo1.LoginErradoException excep = new ExcepcionesTotem.Modulo1.LoginErradoException(
                            RecursosDaoModulo1.Codigo_Login_Errado,
                            RecursosDaoModulo1.Mensaje_Login_Errado, new Exception());
                        ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                        throw excep;
                    }
                }
                 catch (ExcepcionesTotem.Modulo1.LoginErradoException ex)
                {
                    ExcepcionesTotem.Modulo1.LoginErradoException excep= new ExcepcionesTotem.Modulo1.LoginErradoException(
                        ex.Codigo,
                        ex.Mensaje, ex);

                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (SqlException ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                        RecursoGeneralDAO.Codigo_Error_BaseDatos,
                        RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ParametroInvalidoException ex)
                {
                    ParametroInvalidoException excep= new ParametroInvalidoException(
                        RecursoGeneralDAO.Codigo_Parametro_Errado,
                        RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                finally
                {
                    Desconectar(conect);
                }
            }
            else
            {
                UsuarioVacioException excep=  new UsuarioVacioException(
                    RecursosDaoModulo1.Codigo_Usuario_Vacio, 
                    RecursosDaoModulo1.Mensaje_Usuario_Vacio, new Exception());
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
        }

        /// <summary>
        /// Metodo que se utiliza para obtener la pregunta de seguridad de un usuario
        /// </summary>
        /// <param name="parametro">Entidad de tipo usuario que recibe el emai del usuario</param>
        /// <returns>Retorna el usuario con la pregunta de segurida que le pertenece</returns>
        public Entidad ObtenerPreguntaSeguridad(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            SqlConnection conect = Conectar();
            if (usuario != null && usuario.Correo != null && usuario.Correo != "")
            {
                try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Obtener_Pregunta_Seguridad, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, usuario.Correo));

                    SqlDataReader leer;
                    conect.Open();
                    leer = sqlcom.ExecuteReader();
                    while (leer.Read())
                    {
                            usuario.PreguntaSeguridad = leer[RecursosDaoModulo1.Parametro_Output_PreguntaSeguridad].ToString();
                        
                    }
                    return usuario;
                }
                catch (SqlException ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                        RecursoGeneralDAO.Codigo_Error_BaseDatos,
                        RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                        ex.Codigo, ex.Mensaje, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
                {
                    ExcepcionesTotem.Modulo1.EmailErradoException excep= new ExcepcionesTotem.Modulo1.EmailErradoException(
                        ex.Codigo, ex.Mensaje, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ParametroInvalidoException ex)
                {
                    ParametroInvalidoException excep= new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                        RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                finally
                {
                    Desconectar(conect);
                }
            }
            else
            {
                UsuarioVacioException excep= new UsuarioVacioException(RecursosDaoModulo1.Codigo_Usuario_Vacio,
                    RecursosDaoModulo1.Mensaje_Usuario_Vacio,
                    new UsuarioVacioException());
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            
        }

        /// <summary>
        /// Metodo que valida la respuesta de un usuario dada una pregunta
        /// </summary>
        /// <param name="parametro">Entidad de tipo Usuario que recibe la respuesta dada por el usuario</param>
        /// <returns>Retorna true, si la respuesta que dio el usuario es igual a la registrada en la BD</returns>
        public bool ValidarRespuestaSeguridad(Entidad parametro)
        {
            SqlConnection conect = Conectar();
            try
            {
                Usuario usuario = (Usuario)parametro;
                var correo = usuario.Correo;
                if (string.IsNullOrEmpty(usuario.Correo))
                {
                    throw new UsuarioVacioException();
                }
                
                SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Validar_Pregunta_Seguridad, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, correo));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {

                        if (leer[RecursosDaoModulo1.Parametro_Output_RespuestaSeguridad].ToString() ==
                            ((Usuario)parametro).RespuestaSeguridad)
                        {
                            return true;
                        }
                        else
                        {
                            RespuestaErradoException excep = new RespuestaErradoException(RecursosDaoModulo1.Codigo_Respuesta_Errada,
                                RecursosDaoModulo1.Mensaje_Respuesta_Errada,
                                new RespuestaErradoException());
                            ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                            throw excep;
                        }
                    }
                    return false;
                }
                else
                {
                    EmailErradoException excep = new EmailErradoException(RecursosDaoModulo1.Codigo_Email_Errado,
                        RecursosDaoModulo1.Mensaje_Email_errado,
                        new EmailErradoException());
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (EmailErradoException ex)
            {
                EmailErradoException excep = new EmailErradoException(ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;

            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep = new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }

        /// <summary>
        /// Metodo que se utiliza para validar si un correo dado está registrado en la BD
        /// </summary>
        /// <param name="correo">Correo que se requiere validar</param>
        /// <returns>Retorna true si el correo existe y falso en caso contrario</returns>
        public bool ValidarCorreoExistente(string correo)
        {
            SqlConnection conect = Conectar();
            try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_ValidarCorreo, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, correo));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    while (leer.Read())
                    {
                        if (leer != null)
                        {
                            if (leer[RecursosDaoModulo1.Parametro_Output_Usu_correo1].ToString()==correo)
                            {
                                return true;
                            }
                            else
                            {
                                EmailErradoException excep = new EmailErradoException(
                                      RecursosDaoModulo1.Codigo_Email_Errado,
                                      RecursosDaoModulo1.Mensaje_Email_errado,
                                      new EmailErradoException());
                                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                                throw excep;
                            }
                        }
                        else
                        {
                            EmailErradoException excep = new EmailErradoException(
                                RecursosDaoModulo1.Codigo_Email_Errado,
                                RecursosDaoModulo1.Mensaje_Email_errado,
                                new EmailErradoException());
                            ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                            throw excep;
                        }
                    }
                    return false;
                }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (EmailErradoException ex)
            {
                EmailErradoException excep = new EmailErradoException(ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep = new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }
        #endregion

        #region Metodos IDao

        public bool Modificar(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            SqlConnection conect = Conectar();
            try
            {
                if (usuario != null && usuario.Clave != null && usuario.Correo
                    != "" && usuario.Clave != "" && usuario.Correo != "")
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Cambiar_Clave, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo,
                        SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Clave,
                        SqlDbType.VarChar));

                    sqlcom.Parameters[RecursosDaoModulo1.Parametro_Input_Correo].Value = usuario.Correo;
                    sqlcom.Parameters[RecursosDaoModulo1.Parametro_Input_Clave].Value = usuario.Clave;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
             else
                {
                    ExcepcionesTotem.Modulo1.UsuarioVacioException excep= new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosDaoModulo1.Codigo_Usuario_Vacio,
                        RecursosDaoModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());

                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                ExcepcionesTotem.Modulo1.EmailErradoException excep= new ExcepcionesTotem.Modulo1.EmailErradoException(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep= new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}

