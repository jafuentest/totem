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
                      RecursoGeneralBD.Codigo,
                      RecursoGeneralBD.Mensaje,
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
                    //
                }
                catch (Exception ex)
                {
                    //
                }
                finally
                {
                    Desconectar();
                }
                return null;
            }
        #endregion

        #region Ejecutar Stored Procedure
        /// <summary>
        /// Metodo para ejecutar un stored procedure de la base de datos usando parametros
        /// </summary>
        /// <param name="query">El stored procedure a ejecutar</param>
        /// <param name="parametros">lista de los parametros a usar</param>
        /// <returns>SqlDataReader con la informacion obtenida</returns>
            public DataTable EjecutarStoredProcedure(string query, List<Parametro> parametros)
            {
                try
                {
                    Conectar();
                    DataTable data = new DataTable();
                    using (conexion)
                    {
                        
                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;

                        foreach (Parametro parametro in parametros)
                        {
                            if (parametro != null && parametro.etiqueta != null && parametro.tipoDato != null &&
                                parametro.esOutput != null)
                            {
                                if (parametro.esOutput)
                                {
                                    comando.Parameters.Add(parametro.etiqueta, parametro.tipoDato, 500).Direction = ParameterDirection.Output;
                                }
                                else
                                {
                                    if (parametro.valor != null)
                                    {
                                        if (parametro.tipoDato.Equals(SqlDbType.VarChar))
                                        {
                                            comando.Parameters.Add(new SqlParameter(parametro.etiqueta, parametro.tipoDato, 500)).Value = parametro.valor;
                                        }
                                        else
                                        {
                                            comando.Parameters.Add(new SqlParameter(parametro.etiqueta, parametro.tipoDato, 500)).Value = parametro.valor;
                                        }
                                    }
                                    else
                                    {
                                        //Lanza excepcion
                                    }
                                }
                            }
                            else
                            {
                                //Lanza excepcion
                            }
                            
                        }

                        //conexion.Open();
                        
                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                          {
                              dataAdapter.Fill(data);                           
                          }
                        return data;
                    }


                }
                catch (SqlException)
                {
                    throw new Exception();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
                finally
                {
                   Desconectar();
                }
            }
        #endregion


    }

}
