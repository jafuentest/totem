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
    /// Clase para el gestionamiento de los acuerdos establecidos y tratados en las Minutas
    /// de los proyectos
    /// </summary>
    public class BDAcuerdo
    {
        private BDConexion con;
        private BDInvolucrados inv;


        #region Metodos

        #region Metodos de consulta

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

        public Acuerdo ObtenerObjetoAcuerdoBD(SqlDataReader BDAcuerdo)
        {
            Acuerdo acuerdo = new Acuerdo();

            try
            {
                acuerdo.Codigo = int.Parse(BDAcuerdo[RecursosBDModulo8.AtributoIDAcuerdo].ToString());
                acuerdo.Fecha = DateTime.Parse(BDAcuerdo[RecursosBDModulo8.AtributoFechaAcuerdo].ToString());
                acuerdo.Compromiso = BDAcuerdo[RecursosBDModulo8.AtributoDesarrolloAcuerdo].ToString();
                //acuerdo.ListaUsuario = ObtenerUsuarioAcuerdoBD(acuerdo.Codigo);
                //acuerdo.ListaContacto = ObtenerContactoAcuerdoBD(acuerdo.Codigo);

                return acuerdo;
            }

            catch (Exception ex)
            {

                throw ex;

            }
        }

        public List<Usuario> ObtenerUsuarioAcuerdoBD(int IdAcuerdo)
        {
            con = new BDConexion();
            List<Usuario> listaUsuario = new List<Usuario>();
            SqlConnection conect = con.Conectar();

            SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoUsuarioAcuerdo, conect);
            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, IdAcuerdo));
            try
            {
                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();
                while(leer.Read())
                {
                    listaUsuario.Add(inv.ConsultarUsuarioMinutas(int.Parse(leer[RecursosBDModulo8.AtributoAcuerdoUsuario].ToString())));
                    
                }

                return listaUsuario;

            }

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;

            }

        }

        public List<Contacto> ObtenerContactoAcuerdoBD(int IdAcuerdo)
        {
            List<Contacto> listaContacto = new List<Contacto>();
            con = new BDConexion();
            SqlConnection conect = con.Conectar();

                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoContactoAcuerdo, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, IdAcuerdo));
                try
                {

                SqlDataReader leer;
                conect.Open();
                leer = sqlcom.ExecuteReader();
                while (leer.Read())
                {
                    listaContacto.Add(inv.ConsultarContactoMinutas(int.Parse(leer[RecursosBDModulo8.AtributoAcuerdoContacto].ToString())));

                }

                return listaContacto;

            }

            catch (Exception ex)
            {
                //Lanza excepcion logica propia
                throw ex;

            }

        }

        #endregion


        #region Metodo para agregar

        public Boolean AgregarAcuerdosBD(List<Acuerdo> listaAcuerdo, int idMinuta, int idProyecto)
        {
            try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoAgregarAcuerdo, con.Conectar());
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    con.Conectar().Open();

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

                catch (Exception ex)
                {

                    throw ex;

                }

                finally
                {
                    con.Desconectar();

                }
            }
        
        #endregion


        #region Metodo para modificar

        public Boolean ModificarAcuerdosBD(List<Acuerdo> listaAcuerdo, int idMinuta, int idProyecto)
        {
            try
            {
                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientosEliminarAcuerdoUsuario, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                con.Conectar().Open();

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

            catch (Exception ex)
            {

                throw ex;

            }

            finally
            {
                con.Desconectar();

            }
        }
       
        #endregion

        #region Metodo para eliminar

        public Boolean EliminarAcuerdoBD (int idAcuerdo)
        {
            try
            {
                SqlCommand sqlcom = new SqlCommand(RecursosBDModulo8.ProcedimientoEliminarAcuerdo, con.Conectar());
                sqlcom.CommandType = CommandType.StoredProcedure;
                con.Conectar().Open();

                    sqlcom.Parameters.Add(new SqlParameter(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int));

                    sqlcom.Parameters[RecursosBDModulo8.ParametroIDAcuerdo].Value = idAcuerdo;
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

        #endregion

        #endregion
    }
}