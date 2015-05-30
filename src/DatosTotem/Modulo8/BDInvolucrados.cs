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
    /// 
    /// </summary>
    public class BDInvolucrados
    {
        private BDConexion con;

        /// <summary>
        /// Metodo para consultar los datos de Usuario
        /// </summary>
        /// <param name="idUsuario">id del Usuarios</param>
        /// <returns>Retorna el Objeto Usuario</returns>
        public Usuario ConsultarUsuarioMinutas(int idUsuario)
        {
            Usuario usuario = new Usuario();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarUsuarios,conect );
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDUsuario, idUsuario));
            
                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    usuario =ObtenerObjetoUsuarioBD(leer);
                }
                return usuario;

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
        /// Metodo para consultar los datos de contacto
        /// </summary>
        /// <param name="idContacto">id del Contacto</param>
        /// <returns>Retorna el Objeto Contacto</returns>
        public Contacto ConsultarContactoMinutas(int idContacto)
        {
            Contacto contacto = new Contacto();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarContactos, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDContacto, idContacto));
            
                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    contacto = ObtenerObjetoContactoBD(leer);
                }
                return contacto;

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
        /// Metodo que para la consulta de todos los involucrados en una Minuta o los responsables de un Acuerdo
        /// </summary>
        /// <param name="procedure">Es el nombre del procedimiento que se ejecutara</param>
        /// <param name="atributoInvo">Es el id del Contacto o Usuario segun sea el caso que el procedimiento
        /// retornara</param>
        /// <param name="parametro">Es el nombre del parametro minuta que que ejecuta en la BD el 
        /// procedimiento</param>
        /// <param name="id">Es el id del Acuerdo o Minuta que se encuentra vinculado con los 
        /// Involucrados</param>
        /// <returns></returns>
        public List<int> ConsultarInvolucrado(string procedure, string atributoInvo, string parametro, int id)
        {
            List<int> i = new List<int>();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            SqlCommand sqlcom = new SqlCommand(procedure, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(parametro, id));

                SqlDataReader leer;
                conect.Open();
            
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    i.Add(int.Parse(leer[atributoInvo].ToString()));
                }
                return i;
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
        /// Metodo para agregar un Usuario a la BD
        /// </summary>
        /// <param name="listaUsuario">lista de Usuario a agregar</param>
        /// <param name="idAcuerdo">id de Acuerdo vinculado</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean AgregarUsuarioEnAcuerdo(List<Usuario> listaUsuario, int idAcuerdo, int idProyecto)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarUsuarioAcuerdo, conect);

            try
             {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();
                foreach (Usuario usuario in listaUsuario)
                {
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDUsuario, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDAcuerdo].Value = idAcuerdo;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDUsuario].Value = usuario.idUsuario;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDProyecto].Value = idProyecto;
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

        /// <summary>
        /// Metodo para Agregar un Contacto a un Acuerdo a la BD
        /// </summary>
        /// <param name="listaContacto">lista de Contactos a agregar</param>
        /// <param name="idAcuerdo">id del Acuerdo vinculado</param>
        /// <param name="idProyecto">id de Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean AgregarContactoEnAcuerdo(List<Contacto> listaContacto, int idAcuerdo, int idProyecto)
        {

            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarContactoAcuerdo, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();

                foreach (Contacto contacto in listaContacto)
                {
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDContacto, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDAcuerdo].Value = idAcuerdo;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDContacto].Value = contacto.Con_Id;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDProyecto].Value = idProyecto;
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

        /// <summary>
        /// Metodo para eliminar un Usuario de un Acuerdo
        /// </summary>
        /// <param name="listaUsuario">lista de Usuario que se desea eliminar</param>
        /// <param name="idAcuerdo">id de Acuerdo vinculado</param>
        /// <param name="idProyecto">id del Proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo la operación con éxito</returns>
        public Boolean EliminarUsuarioEnAcuerdo(List<Usuario> listaUsuario, int idAcuerdo, int idProyecto)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientosEliminarAcuerdoUsuario, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();

                foreach (Usuario usuario in listaUsuario)
                {
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDUsuario, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDUsuario].Value = idAcuerdo;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDUsuario].Value = usuario.idUsuario;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDProyecto].Value = idProyecto;
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

        /// <summary>
        /// Metodo para eliminar un Contacto de un Acuerdo
        /// </summary>
        /// <param name="listaContacto">lista de Contactos a eliminar</param>
        /// <param name="idAcuerdo">id del acuerdo vinculado</param>
        /// <param name="idProyecto">id del proyecto</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operación</returns>
        public Boolean EliminarContactoEnAcuerdo(List<Contacto> listaContacto, int idAcuerdo, int idProyecto)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoEliminarAcuerdoContacto, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();

                foreach (Contacto contacto in listaContacto)
                {
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDContacto, SqlDbType.Int));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDProyecto, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDUsuario].Value = idAcuerdo;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDContacto].Value = contacto.Con_Id;
                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDProyecto].Value = idProyecto;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMinuta"></param>
        /// <returns></returns>
        public Boolean EliminarInvolucradoEnMinuta(int idMinuta)
        {
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedureEliminarInvolucradoMinuta, conect);
            try
            {
                sqlcom.CommandType = CommandType.StoredProcedure;
                conect.Open();

                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDMinuta].Value = idMinuta;

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

        /// <summary>
        /// Metodo para obtener un Objeto tipo Usuario
        /// </summary>
        /// <param name="BDUsuario">parametro de lectura sql</param>
        /// <returns>Retorna El Objeto Usuario</returns>
        public Usuario ObtenerObjetoUsuarioBD(SqlDataReader BDUsuario)
        {
            Usuario usuario = new Usuario();

            try
            {
                usuario.clave = BDUsuario[RecursosBDModulo8.AtributoIDUsuario].ToString();
                usuario.nombre = BDUsuario[RecursosBDModulo8.AtributoNombreUsuario].ToString();
                usuario.apellido = BDUsuario[RecursosBDModulo8.AtributoApellidoUsuario].ToString();
                usuario.cargo = BDUsuario[RecursosBDModulo8.AtributoCargoUsuario].ToString();
                return usuario;
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
        /// Metodo para obtener Un Objeto tipo Contacto
        /// </summary>
        /// <param name="BDContacto">parametro de lectura sql</param>
        /// <returns>Retorna el Objeto Contacto</returns>
        public Contacto ObtenerObjetoContactoBD(SqlDataReader BDContacto)
        {
            Contacto contacto = new Contacto();

            try
            {
                contacto.Con_Id = int.Parse(BDContacto[RecursosBDModulo8.AtributoIDContacto].ToString());
                contacto.Con_Nombre = BDContacto[RecursosBDModulo8.AtributoNombreContacto].ToString();
                contacto.Con_Apellido = BDContacto[RecursosBDModulo8.AtributoApellidoContacto].ToString();
                contacto.ConCargo = BDContacto[RecursosBDModulo8.AtributoCargoContacto].ToString();
                return contacto;
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
    }
}
