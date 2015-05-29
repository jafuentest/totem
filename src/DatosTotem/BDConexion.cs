using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using ExcepcionesTotem;


namespace DatosTotem
{
    /// <summary>
    /// Clase para el manejo de la conexion a la base de datos
    /// </summary>
    public class BDConexion
    {
        private SqlConnection conexion;
        private string strConexion;
        private SqlCommand comando;
        private string query;


        #region Conectar con la Base de Datos
            /// <summary>
            /// Metodo para realizar la conexion a la base de datos
            /// Excepciones posibles: 
            /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
            /// </summary>
            public SqlConnection Conectar()
            {

                try
                {
                    strConexion = ConfigurationManager.ConnectionStrings[RecursoGeneralBD.NombreBD].ConnectionString;
                    if (conexion == null)
                    {
                        conexion = new SqlConnection(strConexion);
                    }

                }

                catch (Exception ex)
                {

                    ExceptionTotemConexionBD CnBD = new ExceptionTotemConexionBD(
                      RecursoGeneralBD.Codigo,
                      RecursoGeneralBD.Mensaje,
                      ex);

                    throw CnBD;
                }

                    return conexion;
                
            }
        #endregion

        #region Desconectar de la Base de Datos
            /// <summary>
            /// Metodo para cerrar la sesion con la base de datos
            /// Excepciones posibles: 
            /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
            /// </summary>
            public void Desconectar()
            {

                try
                {
                    this.conexion.Close();
                }

                catch (Exception ex)
                {

                    ExceptionTotemConexionBD CnBD = new ExceptionTotemConexionBD(
                      RecursoGeneralBD.Codigo_Error_Desconexion,
                      RecursoGeneralBD.Mensaje_Error_Desconexion,
                      ex);

                    throw CnBD;
                }

            }

            public void Desconectar(SqlConnection conec)
            {

                try
                {
                    conec.Close();
                }

                catch (Exception ex)
                {

                    ExceptionTotemConexionBD CnBD = new ExceptionTotemConexionBD(
                      RecursoGeneralBD.Codigo_Error_Desconexion,
                      RecursoGeneralBD.Mensaje_Error_Desconexion,
                      ex);

                    throw CnBD;
                }

            }
        #endregion

        #region Ejecutar el Query
            /// <summary>
            /// Metodo que manda a ejecutar el query
            /// </summary>
            /// <param name="query">String con el query a ejecutar</param>
            /// <returns>Retorna el data reader con el resultado</returns>
            public SqlDataReader EjecutarQuery(string query)
            {
                try
                {
                    Conectar();

                    using (conexion)
                    {
                        comando = new SqlCommand(query, conexion);
                        SqlDataReader resultado = comando.ExecuteReader();
                        return resultado;
                    }


                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                finally
                {
                    Desconectar();
                }
            }
        #endregion

        #region Ejecutar Stored Procedure
        /// <summary>
        /// Metodo para ejecutar un stored procedure de la base de datos usando parametros
        /// </summary>
        /// <param name="query">El stored procedure a ejecutar</param>
        /// <param name="parametros">lista de los parametros a usar</param>
        /// <returns>List<Resultado>con la informacion obtenida</returns>
            public List<Resultado> EjecutarStoredProcedure(string query, List<Parametro> parametros)
            {
                try
                {
                    Conectar();
                    List<Resultado> resultados = new List<Resultado>();
                    using (conexion)
                    {

                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;


                        AsignarParametros(parametros);


                        conexion.Open();
                        comando.ExecuteNonQuery();
                        if (comando.Parameters != null)
                        {
                            foreach (SqlParameter parameter in comando.Parameters)
                            {
                                if (parameter.Direction.Equals(ParameterDirection.Output))
                                {
                                    Resultado resultado = new Resultado(parameter.ParameterName,
                                        parameter.Value.ToString());
                                    resultados.Add(resultado);
                                }
                            }
                            if (resultados != null)
                            {
                                return resultados;
                            }
                            else
                            {
                                throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                                    RecursoGeneralBD.Codigo_Parametro_Errado,
                                    RecursoGeneralBD.Mensaje_Parametro_Errado,
                                    new ExcepcionesTotem.Modulo1.ParametroInvalidoException());
                            }
                        }
                        return null;
                    }


                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                                    RecursoGeneralBD.Codigo_Parametro_Errado,
                                    RecursoGeneralBD.Mensaje_Parametro_Errado,
                                    ex);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                finally
                {
                  Desconectar();
                }
            }
            /// <summary>
            /// Metodo para asignar los parametros a un comando
            /// </summary>
            /// <param name="parametros">Lista de parametros que se le va a asociar</param>
            public void AsignarParametros(List<Parametro> parametros)
            {
                foreach (Parametro parametro in parametros)
                {
                    if (parametro != null && parametro.etiqueta != null && parametro.tipoDato != null &&
                        parametro.esOutput != null)
                    {
                        if (parametro.esOutput)
                        {
                            comando.Parameters.Add(parametro.etiqueta, parametro.tipoDato, 32000);
                            comando.Parameters[parametro.etiqueta].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            if (parametro.valor != null)
                            {
                                comando.Parameters.Add(new SqlParameter(parametro.etiqueta, parametro.tipoDato, 32000));
                                comando.Parameters[parametro.etiqueta].Value = parametro.valor;
                            }
                            else
                            {
                                throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                                    RecursoGeneralBD.Codigo_Parametro_Errado,
                                    RecursoGeneralBD.Mensaje_Parametro_Errado,
                                    new ExcepcionesTotem.Modulo1.ParametroInvalidoException());
                            }
                        }
                    }
                    else
                    {
                        throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                                     RecursoGeneralBD.Codigo_Parametro_Errado,
                                     RecursoGeneralBD.Mensaje_Parametro_Errado,
                                     new ExcepcionesTotem.Modulo1.ParametroInvalidoException());
                    }

                }
            }
        #endregion

        #region Ejecutar Stored Procedure Multiples Tuplas
            public DataTable EjecutarStoredProcedureTuplas(string query, List<Parametro> parametros)
            {
                try
                {
                    Conectar();
                    DataTable dataTable = new DataTable();
                    using (conexion)
                    {

                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;


                        AsignarParametros(parametros);


                        conexion.Open();
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                        {
                            //SqlDataAdapter dataAdapter = new SqlDataAdapter();
                            //dataAdapter.SelectCommand = comando;
                            dataAdapter.Fill(dataTable);
                            System.Diagnostics.Debug.WriteLine(dataAdapter);
                            System.Diagnostics.Debug.WriteLine(dataTable);
                        }

                        return dataTable;
                    }


                }
                catch (SqlException ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
                {
                    throw new ExcepcionesTotem.Modulo1.ParametroInvalidoException(
                                    RecursoGeneralBD.Codigo_Parametro_Errado,
                                    RecursoGeneralBD.Mensaje_Parametro_Errado,
                                    ex);
                }
                catch (Exception ex)
                {
                    throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                finally
                {
                    Desconectar();
                }
            }
            #endregion




    }

}
