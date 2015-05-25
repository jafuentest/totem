﻿using System;
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
                    if (conexion == null)
                        conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[RecursoGeneralBD.NombreBD].ConnectionString);

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
            public SqlDataReader EjecutarStoredProcedure(string query, List<Parametro> parametros)
            {
                try
                {
                    Conectar();

                    using (conexion)
                    {
                        comando = new SqlCommand(query, conexion);
                        comando.CommandType = CommandType.StoredProcedure;

                        foreach (Parametro parametro in parametros)
                        {
                            if (parametro != null && parametro.etiqueta != null && parametro.tipoDato != null &&
                                parametro.valor!=null)
                            {
                                comando.Parameters.Add(parametro.etiqueta, parametro.tipoDato).Value = parametro.valor;
                            }
                        }

                        SqlDataReader resultado = comando.ExecuteReader();
                        return resultado;
                    }


                }
                catch (SqlException)
                {
                    //
                }
                catch (Exception)
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
    }

}
