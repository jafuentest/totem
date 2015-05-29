using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DominioTotem;
using System.IO;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using ExcepcionesTotem;

namespace DatosTotem.Modulo8
{
    /// <summary>
    /// Clase para el gestionamiento de los acuerdos establecidos y tratados en las Minutas
    /// de los proyectos
    /// </summary>
    public class BDAcuerdo
    {
        private BDConexion con;
        private BDInvolucrados inv;

        #region Metodos

        #region Metodos de consulta

        /// <summary>
        /// Metodo para consultar un Acuerdo vinculado a una minuta es especifico
        /// </summary>
        /// <param name="idMinuta">id de la minuta </param>
        /// <returns>Retorna una Lista de Acuerdos vinculados a la Minuta</returns>
        public List<Acuerdo> ConsultarAcuerdoBD(int idMinuta)
        {
            List<Acuerdo> listaAcuerdo = new List<Acuerdo>();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarAcuerdo, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, idMinuta));
           
                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    listaAcuerdo.Add(ObtenerObjetoAcuerdoBD(leer));
                }
                return listaAcuerdo;

            }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
        /// Metodo para obtener el Objeto tipo Acuerdo
        /// </summary>
        /// <param name="BDAcuerdo">parametro de lectura</param>
        /// <returns>Retorna el Objeto Acuerdo</returns>
        public Acuerdo ObtenerObjetoAcuerdoBD(SqlDataReader BDAcuerdo)
        {
            Acuerdo acuerdo = new Acuerdo();

            try
            {
                acuerdo.Codigo = int.Parse(BDAcuerdo[RecursosBDModulo8.AtributoIDAcuerdo].ToString());
                acuerdo.Fecha = DateTime.Parse(BDAcuerdo[RecursosBDModulo8.AtributoFechaAcuerdo].ToString());
                acuerdo.Compromiso = BDAcuerdo[RecursosBDModulo8.AtributoDesarrolloAcuerdo].ToString();

                return acuerdo;
            }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
        /// Metodo para obtener los responsables Usuarios de un Acuerdo de una Minuta
        /// </summary>
        /// <param name="IdAcuerdo">Id del acuerdo del que se desea consultar</param>
        /// <returns>Retorna una lista de Usuarios</returns>
        public List<Usuario> ObtenerUsuarioAcuerdoBD(int IdAcuerdo)
        {
            con = new BDConexion();
            List<Usuario> listaUsuario = new List<Usuario>();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoUsuarioAcuerdo, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, IdAcuerdo));
            
                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();
                while(leer.Read())
                {
                    listaUsuario.Add(inv.ConsultarUsuarioMinutas(int.Parse(leer[RecursosBDModulo8.AtributoAcuerdoUsuario].ToString())));
                    
                }

                return listaUsuario;

            }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
        /// Metodo para obtener los responsables Contactos de un Acuerdo de una Minuta
        /// </summary>
        /// <param name="IdAcuerdo">Id del acuerdo del que se desea consultar</param>
        /// <returns>Retorna una Lista de Contactos</returns>
        public List<Contacto> ObtenerContactoAcuerdoBD(int IdAcuerdo)
        {
            List<Contacto> listaContacto = new List<Contacto>();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoContactoAcuerdo, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, IdAcuerdo));


                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();
                while (leer.Read())
                {
                    listaContacto.Add(inv.ConsultarContactoMinutas(int.Parse(leer[RecursosBDModulo8.AtributoAcuerdoContacto].ToString())));

                }

                return listaContacto;
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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

        #endregion


        #region Metodo para agregar

        /// <summary>
        /// Metodo para agregar los Acuerdos de una Minuta a la BD
        /// </summary>
        /// <param name="listaAcuerdo">lista de Acuerdos a agregara en la BD</param>
        /// <param name="idMinuta">id de la minuta con la cual se encuentran vinculados los acuerdos </param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>retorna un boolean para saber si se realizo con exito la operación</returns>
        public Boolean AgregarAcuerdosBD(List<Acuerdo> listaAcuerdo, int idMinuta, int idProyecto)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarAcuerdo, conect);
            try
            {
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    conect.Open();

                      foreach (Acuerdo acuerdo in listaAcuerdo)
                         {

                           sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroFechaAcuerdo, SqlDbType.Date));
                           sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroDesarrolloAcuerdo, SqlDbType.VarChar));
                           sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMinuta, SqlDbType.Int));

                           sqlcom.Parameters[RecursosBDModulo8.ParametroFechaAcuerdo].Value = acuerdo.Fecha;
                           sqlcom.Parameters[RecursosBDModulo8.ParametroDesarrolloAcuerdo].Value = acuerdo.Compromiso;
                           sqlcom.Parameters[RecursosBDModulo8.ParametroMinuta].Value = idMinuta;          
                           sqlcom.ExecuteNonQuery();
                           SqlDataReader leer = sqlcom.ExecuteReader();
                           int idAcuerdo= int.Parse(leer[RecursosBDModulo8.AtributoIDAcuerdo].ToString());

                           if (inv.AgregarUsuarioEnAcuerdo(acuerdo.ListaUsuario, idAcuerdo, idProyecto) != true ||
                               inv.AgregarContactoEnAcuerdo(acuerdo.ListaContacto, idAcuerdo, idProyecto) != true)
                           {
                               throw new Exception();
                           }
                           
                         }
                      return true;
                   }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
        
        #endregion


        #region Metodo para modificar

        /// <summary>
        /// Metodo para modificar un acuerdo en la BD
        /// </summary>
        /// <param name="listaAcuerdo">lista de Acuerdos que se desean modificar</param>
        /// <param name="idMinuta">id de la minuta a la cual los acuerdos estan vinculados</param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operacion</returns>
        public Boolean ModificarAcuerdosBD(List<Acuerdo> listaAcuerdo, int idMinuta, int idProyecto)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientosEliminarAcuerdoUsuario, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();

                foreach (Acuerdo acuerdo in listaAcuerdo)
                {

                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroFechaAcuerdo, SqlDbType.Date));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroDesarrolloAcuerdo, SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroMinuta, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDAcuerdo].Value = acuerdo.Codigo;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroFechaAcuerdo].Value = acuerdo.Fecha;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroDesarrolloAcuerdo].Value = acuerdo.Compromiso;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroMinuta].Value = idMinuta;
                    sqlcom.ExecuteNonQuery();


                }
                return true;
            }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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
       
        #endregion

        #region Metodo para eliminar
        /// <summary>
        /// Metodo para eliminar un acuerdo de la BD
        /// </summary>
        /// <param name="idAcuerdo">id del Acuerdo que se desea eliminar</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operacion</returns>
        public Boolean EliminarAcuerdoBD (int idAcuerdo)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoEliminarAcuerdo, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();

                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDAcuerdo].Value = idAcuerdo;
                    sqlcom.ExecuteNonQuery();

                return true;
            }

            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (ExceptionTotemConexionBD ex)
            {

                throw new ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

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

        #endregion

        #endregion
    }
}