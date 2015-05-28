using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.IO;

namespace DatosTotem.Modulo8
{
    /// <summary>
    /// Clase para el gestionamiento de las puntos tratados en una Minuta, con respecto a las conexiones y llamadas
    /// a la BD
    /// </summary>
    public class BDPunto
    {
        private BDConexion con;

        /// <summary>
        /// Metodo para consultar todos los puntos tratados en una Minuta
        /// </summary>
        /// <param name="idMinuta">Es el id de la Minuta de los puntos a consultar</param>
        /// <returns>Retorna una Lista de todos los punto de la Minuta</returns>
        public List<Punto> ConsultarPuntoBD(int idMinuta)
        {
            List<Punto> listaPunto = new List<Punto>();
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarPuntos, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, idMinuta));

                SqlDataReader leer;
                con.Conectar().Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    listaPunto.Add(ObtenerObjetoPuntoBD(leer));
                }
                return listaPunto;

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
        /// Metodo que construye el Objeto Punto
        /// </summary>
        /// <param name="BDPunto">Objeto SqlDataReader, para leer la data en sql</param>
        /// <returns>Retorna el objeto Punto</returns>
        public Punto ObtenerObjetoPuntoBD(SqlDataReader BDPunto)
        {
            Punto punto = new Punto();

            try
            {
                punto.Codigo = int.Parse(BDPunto[RecursosBDModulo8.AtributoIDPunto].ToString());
                punto.Titulo = BDPunto[RecursosBDModulo8.AtributoTituloPunto].ToString();
                punto.Desarrollo= BDPunto[RecursosBDModulo8.AtributoDesarrolloPunto].ToString();

                BDPunto.Close();
                return punto;
            }

            catch (Exception ex)
            {

                throw ex;

            }
        }

        /// <summary>
        /// Metodo para Modificar un punto en especifico de cualquier Minuta
        /// </summary>
        /// <param name="punto">Objeto Minuta, con todos los valores a modificar</param>
        /// <param name="idMinuta">Id de la Minuta relcionada</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean ModificarPuntoBD(Punto punto, int idMinuta)
        {
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoModificarPunto, con.Conectar());
            sqlcom.CommandType = CommandType.StoredProcedure;

           
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDPunto, SqlDbType.Int));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroTituloPunto, SqlDbType.VarChar));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroDesarrolloPunto, SqlDbType.VarChar));

            sqlcom.Parameters[RecursosBDModulo8.ParametroIDMinuta].Value = idMinuta;
            sqlcom.Parameters[RecursosBDModulo8.ParametroIDPunto].Value = punto.Codigo;
            sqlcom.Parameters[RecursosBDModulo8.ParametroTituloPunto].Value = punto.Titulo;
            sqlcom.Parameters[RecursosBDModulo8.AtributoDesarrolloPunto].Value = punto.Desarrollo;

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
        /// Metodo para Agregar un punto en especifico de cualquier Minuta
        /// </summary>
        /// <param name="punto">Objeto Minuta</param>
        /// <param name="idMinuta">Id de la Minuta relcionada</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean AgregarPuntoBD(Punto punto, int idMinuta)
        {
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarPunto, con.Conectar());
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroTituloPunto, SqlDbType.VarChar));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroDesarrolloPunto, SqlDbType.VarChar));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMinuta, SqlDbType.Int));

            sqlcom.Parameters[RecursosBDModulo8.ParametroTituloPunto].Value = punto.Titulo;
            sqlcom.Parameters[RecursosBDModulo8.AtributoDesarrolloPunto].Value = punto.Desarrollo;
            sqlcom.Parameters[RecursosBDModulo8.ParametroMinuta].Value = idMinuta;

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
        /// Metodo para Eliminar un Punto de una Minuta
        /// </summary>
        /// <param name="punto">Objeto Punto</param>
        /// <param name="idMinuta">Id de la Minuta del punto a eliminar</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean EliminarPuntoBD(Punto punto, int idMinuta)
        {
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoEliminarPunto, con.Conectar());
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int));
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDPunto, SqlDbType.Int));

            sqlcom.Parameters[RecursosBDModulo8.ParametroIDMinuta].Value = idMinuta;
            sqlcom.Parameters[RecursosBDModulo8.ParametroIDPunto].Value = punto.Codigo;

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
    }
}
