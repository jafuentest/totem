using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.Data;
using System.Data.SqlClient;
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

        /// <summary>
        /// Método para consultar los datos de una minuta en la BD
        /// </summary>
        /// <param name="id">Se recibe el id de la minuta que se desea consultar</param>
        /// <returns>Retrorna el objeto Minuta</returns>
        public Minuta ConsultarMinutaBD(int id)
        {
            Minuta minuta = new Minuta();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarMinuta, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, id));

                SqlDataReader leer;
                con.Conectar().Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    minuta = ObtenerObjetoMinutaBD(leer);
                }
                return minuta;

            }

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;
                
            }

            finally
            {
                con.Desconectar();
                
            }
            
        }

        /// <summary>
        /// Metodo para crear y obtener el objeto Minuta
        /// </summary>
        /// <param name="BDMinuta"> Objeto SqlDataReader, para leer la data en sql</param>
        /// <returns>Objeto Minuta</returns>
        public Minuta ObtenerObjetoMinutaBD(SqlDataReader BDMinuta)
        {
            Minuta minuta = new Minuta();
            try
            {
                minuta.Codigo = BDMinuta[RecursosBDModulo8.AtributoIDMinuta].ToString();
                minuta.Fecha = DateTime.Parse(BDMinuta[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                minuta.Motivo = BDMinuta[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                minuta.Observaciones = BDMinuta[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();

                BDMinuta.Close();
                return minuta;
            }

            catch (Exception ex)
            {
               
                throw ex;

            }

        }

        /// <summary>
        /// Metodo para modificar los campos más importantes de una Minuta
        /// </summary>
        /// <param name="min">Objeto de tipo Minuta</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean ModificarMinutaBD(Minuta min)
        {
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoModificarMinuta, con.Conectar());
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar));

            sqlcom.Parameters[RecursosBDModulo8.ParametroIDMinuta].Value = min.Codigo;
            sqlcom.Parameters[RecursosBDModulo8.ParametroFechaMinuta].Value = min.Fecha;
            sqlcom.Parameters[RecursosBDModulo8.ParametroMotivoMinuta].Value = min.Motivo;
            sqlcom.Parameters[RecursosBDModulo8.ParametroObservacionesMinuta].Value = min.Observaciones;

            try
            {
                con.Conectar().Open();
                sqlcom.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                
                throw ex;

            }

            finally
            {
                con.Desconectar();

            }

        }

        /// <summary>
        /// Metodo para guardar una Minuta en la BD
        /// </summary>
        /// <param name="min">Objeto de tipo Minuta</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean AgregarMinuta(Minuta min)
        {
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarMinuta, con.Conectar());
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar));

            sqlcom.Parameters[RecursosBDModulo8.ParametroFechaMinuta].Value = min.Fecha;
            sqlcom.Parameters[RecursosBDModulo8.ParametroMotivoMinuta].Value = min.Motivo;
            sqlcom.Parameters[RecursosBDModulo8.ParametroObservacionesMinuta].Value = min.Observaciones;

            try
            {
                con.Conectar().Open();
                sqlcom.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {
                con.Desconectar();

            }
        }

        /// <summary>
        /// Metodo que devuelve una lista de todas las minutas asociadas a un Proyecto
        /// </summary>
        /// <param name="idProyecto">id de proyecto que se desea buscar</param>
        /// <returns>Retorna lista de minutas</returns>
        public List<Minuta> ConsultarMinutasProyecto(int idProyecto)
        {
            List<Minuta> listaMinuta = new List<Minuta>();

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarListaMinutas, con.Conectar());
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

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;

            }

            finally
            {
                con.Desconectar();

            }

        }
    }
}
