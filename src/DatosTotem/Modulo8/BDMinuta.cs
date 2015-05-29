using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using ExcepcionesTotem;
using System.IO;

namespace DatosTotem.Modulo8
{
    /// <summary>
    /// Clase para el gestionamiento de las minutas, con respecto a las conexiones y llamadas
    /// a la BD
    /// </summary>
    public class BDMinuta
    {

        private BDConexion con;
        private Minuta minuta;

        /// <summary>
        /// Método para consultar los datos de una minuta en la BD
        /// </summary>
        /// <param name="id">Se recibe el id de la minuta que se desea consultar</param>
        /// <returns>Retrorna el objeto Minuta</returns>
        public Minuta ConsultarMinutaBD(int id)
        {
            minuta = new Minuta();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarMinuta, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, id));

                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    minuta = ObtenerObjetoMinutaBD(leer);
                }
                return minuta;

            }

            catch (NullReferenceException ex)
             {

                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                     RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

             }
             catch(ExceptionTotemConexionBD ex)
             {
                
                 throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                     RecursoGeneralBD.Mensaje,ex);

             }
             catch (SqlException ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                     RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

             }
             catch (ParametroIncorrectoException ex)
             {
                 throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                     RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
             }
             catch (AtributoIncorrectoException ex)
             {
                 throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                     RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
             }
             catch (Exception ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                    RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

             }

            finally
            {
                con.Desconectar(conect);
                
            }
            
        }

        /// <summary>
        /// Metodo para crear y obtener el objeto Minuta
        /// </summary>
        /// <param name="BDMinuta"> Objeto SqlDataReader, para leer la data en sql</param>
        /// <returns>Objeto Minuta</returns>
        public Minuta ObtenerObjetoMinutaBD(SqlDataReader BDMinuta)
        {
            minuta = new Minuta();
            con = new BDConexion();
            try
            {
                minuta.Codigo = BDMinuta[RecursosBDModulo8.AtributoIDMinuta].ToString();
                minuta.Fecha = DateTime.Parse(BDMinuta[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                minuta.Motivo = BDMinuta[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                minuta.Observaciones = BDMinuta[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();

                return minuta;
            }

            catch (NullReferenceException ex)
             {

                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                     RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

             }
             catch(ExceptionTotemConexionBD ex)
             {
                
                 throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                     RecursoGeneralBD.Mensaje,ex);

             }
             catch (SqlException ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                     RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

             }
             catch (ParametroIncorrectoException ex)
             {
                 throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                     RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
             }
             catch (AtributoIncorrectoException ex)
             {
                 throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                     RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
             }
             catch (Exception ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                    RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

             }

        }

        /// <summary>
        /// Metodo para modificar los campos más importantes de una Minuta
        /// </summary>
        /// <param name="min">Objeto de tipo Minuta</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean ModificarMinutaBD(Minuta min)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoModificarMinuta, con.Conectar());
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int));
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime));
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar));
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar));

                sqlcom.Parameters[RecursosBDModulo8.ParametroIDMinuta].Value = min.Codigo;
                sqlcom.Parameters[RecursosBDModulo8.ParametroFechaMinuta].Value = min.Fecha;
                sqlcom.Parameters[RecursosBDModulo8.ParametroMotivoMinuta].Value = min.Motivo;
                sqlcom.Parameters[RecursosBDModulo8.ParametroObservacionesMinuta].Value = min.Observaciones;
                con.Conectar().Open();
                sqlcom.ExecuteNonQuery();
                return true;

            }
            catch (NullReferenceException ex)
             {

                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                     RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

             }
             catch(ExceptionTotemConexionBD ex)
             {
                
                 throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                     RecursoGeneralBD.Mensaje,ex);

             }
             catch (SqlException ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                     RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

             }
             catch (ParametroIncorrectoException ex)
             {
                 throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                     RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
             }
             catch (AtributoIncorrectoException ex)
             {
                 throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                     RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
             }
             catch (Exception ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                    RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

             }

            finally
            {
                con.Desconectar(conect);

            }

        }

        /// <summary>
        /// Metodo para guardar una Minuta en la BD
        /// </summary>
        /// <param name="min">Objeto de tipo Minuta</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean AgregarMinuta(Minuta min)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarMinuta, con.Conectar());
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;

                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime));
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar));
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar));

                sqlcom.Parameters[RecursosBDModulo8.ParametroFechaMinuta].Value = min.Fecha;
                sqlcom.Parameters[RecursosBDModulo8.ParametroMotivoMinuta].Value = min.Motivo;
                sqlcom.Parameters[RecursosBDModulo8.ParametroObservacionesMinuta].Value = min.Observaciones;

            
                con.Conectar().Open();
                sqlcom.ExecuteNonQuery();
                return true;

            }
            catch (NullReferenceException ex)
             {

                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                     RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

             }
             catch(ExceptionTotemConexionBD ex)
             {
                
                 throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                     RecursoGeneralBD.Mensaje,ex);

             }
             catch (SqlException ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                     RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

             }
             catch (ParametroIncorrectoException ex)
             {
                 throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                     RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
             }
             catch (AtributoIncorrectoException ex)
             {
                 throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                     RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
             }
             catch (Exception ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                    RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

             }

            finally
            {
                con.Desconectar(conect);

            }
        }

        /// <summary>
        /// Metodo que devuelve una lista de todas las minutas asociadas a un Proyecto
        /// </summary>
        /// <param name="idProyecto">id de proyecto que se desea buscar</param>
        /// <returns>Retorna lista de minutas</returns>
        public List<Minuta> ConsultarMinutasProyecto(int idProyecto)
        {
            con = new BDConexion();
            List<Minuta> listaMinuta = new List<Minuta>();

            SqlConnection conect = con.Conectar();
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarListaMinutas, conect);

             try
              {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroProyectoMinuta, idProyecto));

                SqlDataReader leer;
                con.Conectar().Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    listaMinuta.Add(ObtenerObjetoMinutaBD(leer));

                }

                return listaMinuta;
            }

             catch (NullReferenceException ex)
             {

                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                     RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

             }
             catch(ExceptionTotemConexionBD ex)
             {
                
                 throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                     RecursoGeneralBD.Mensaje,ex);

             }
             catch (SqlException ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                     RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

             }
             catch (ParametroIncorrectoException ex)
             {
                 throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                     RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
             }
             catch (AtributoIncorrectoException ex)
             {
                 throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                     RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
             }
             catch (Exception ex)
             {
                 throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                    RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

             }

            finally
            {
                con.Desconectar(conect);
            }

        }

    }
}
