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
    /// 
    /// </summary>
    public class BDInvolucrados
    {
        private BDConexion con;

        public Usuario ConsultarUsuarioMinutas(int idUsuario)
        {
            Usuario usuario = new Usuario();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarUsuarios,conect );
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDUsuario, idUsuario));
            try
              {
                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    usuario =ObtenerObjetoUsuarioBD(leer);
                }
                return usuario;

            }

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;

            }

            finally
            {
                con.Desconectar(conect);

            }

        }

        public Contacto ConsultarContactoMinutas(int idContacto)
        {
            Contacto contacto = new Contacto();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();
            
            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarContactos, conect);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDContacto, idContacto));
            try
              {
                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    contacto = ObtenerObjetoContactoBD(leer);
                }
                return contacto;

            }

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;

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
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(new SqlParameter(parametro, id));

            SqlDataReader leer;
            conect.Open();
            try
            {
                leer = sqlcom.ExecuteReader();

                while (leer.Read())
                {
                    i.Add(int.Parse(leer[atributoInvo].ToString()));
                }
                return i;
            }
            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;

            }

            finally
            {
                con.Desconectar(conect);

            }
        }

        public Boolean AgregarUsuarioEnAcuerdo(List<Usuario> listaUsuario, int idAcuerdo, int idProyecto)
        {
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarUsuarioAcuerdo, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                con.Conectar().Open();

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

        public Boolean AgregarContactoEnAcuerdo(List<Contacto> listaContacto, int idAcuerdo, int idProyecto)
        {
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarContactoAcuerdo, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                con.Conectar().Open();

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

        public Boolean EliminarUsuarioEnAcuerdo(List<Usuario> listaUsuario, int idAcuerdo, int idProyecto)
        {
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientosEliminarAcuerdoUsuario, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                con.Conectar().Open();

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

        public Boolean EliminarContactoEnAcuerdo(List<Contacto> listaContacto, int idAcuerdo, int idProyecto)
        {
            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoEliminarAcuerdoContacto, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                con.Conectar().Open();

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

            catch (Exception ex)
            {

                throw ex;

            }
        }

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

            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}
