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
    public class BDInvolucrados
    {
        private BDConexion con;

        public Usuario ConsultarUsuarioMinutas(int idUsuario)
        {
            Usuario usuario = new Usuario();

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarUsuarios, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDUsuario, idUsuario));

                SqlDataReader leer;
                con.Conectar().Open();
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
                con.Desconectar();

            }

        }

        public Contacto ConsultarContactoMinutas(int idContacto)
        {
            Contacto contacto = new Contacto();

            try
            {

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoConsultarContactos, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDContacto, idContacto));

                SqlDataReader leer;
                con.Conectar().Open();
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
                con.Desconectar();

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

                BDUsuario.Close();
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

                BDContacto.Close();
                return contacto;
            }

            catch (Exception ex)
            {

                throw ex;

            }
        }
    }
}
