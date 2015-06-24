using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using System.Data;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using ExcepcionesTotem;
using System.Data.SqlClient;
using Dominio.Entidades.Modulo8;
using Dominio.Entidades.Modulo7;

namespace DAO.DAO.Modulo8
{
    /// <summary>
    /// Clase para el gestionamiento en BD de los acuerdos establecidos y tratados en las Minutas
    /// de los proyectos
    /// </summary>
    public class DaoAcuerdo : DAO, IntefazDAO.Modulo8.IDaoAcuerdo
    {
        #region Agregar

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para agregar los Acuerdos de una Minuta a la BD
        /// </summary>
        /// <param name="paramtreo">Parametro del tipo generico (clase Entidad) que representa el acuerdo a agregar</param>
        /// <returns>Retorna un boolean para saber si se realizo con exito o no la operación</returns>
        public bool AgregarAcuerdo(Entidad parametro, int idMinuta, string idProyecto)
        {
            Acuerdo elAcuerdo = (Acuerdo)parametro;
            Fabrica.FabricaAbstractaDAO laFabrica = Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();
            IntefazDAO.Modulo8.IDaoInvolucradosMinuta DAOInvolucradosMinuta = laFabrica.ObtenerDAOInvolucradosMinuta();
            bool success = false;
            
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroFechaAcuerdo, SqlDbType.DateTime,
                elAcuerdo.Fecha.ToShortDateString(), false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroDesarrolloAcuerdo, SqlDbType.VarChar,
                elAcuerdo.Compromiso, false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                idMinuta.ToString(), false);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarAcuerdo, parametros);
                if (tmp.ToArray().Length > 0)
                {
                    foreach (Contacto contacto in elAcuerdo.ListaContacto)
                    {
                        bool contactoBool = DAOInvolucradosMinuta.AgregarContactoEnAcuerdo(contacto,tmp[0].valor,idProyecto);
                    }
                    foreach (Usuario usuario in elAcuerdo.ListaUsuario)
                    {
                        bool usuarioBool = DAOInvolucradosMinuta.AgregarUsuarioEnAcuerdo(usuario, tmp[0].valor, idProyecto);
                    }
                    success = true;
                }
            }

            catch (NullReferenceException ex)
            {
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);
            }
            catch (ExceptionTotemConexionBD ex)
            {
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
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
            return success;
        }

        #endregion

        #region Modificar

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para modificar un acuerdo de la BD
        /// </summary>
        /// <param name="parametro">Parametro del tipo generico (clase Entidad) que representa el acuerdo a modificar</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operacion</returns>
        public bool ModificarAcuerdo (Entidad parametro, String codigoProyecto)
        {
            Acuerdo elAcuerdo = (Acuerdo)parametro;
            bool successEliminar = false;
            bool successAgregar = false;
            bool success = false;

            /*List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                elAcuerdo.Fecha.ToShortDateString(), false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroFechaAcuerdo, SqlDbType.Date,
                elAcuerdo.Compromiso, false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroDesarrolloAcuerdo, SqlDbType.VarChar,
                elAcuerdo.Compromiso, false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroMinuta, SqlDbType.Int,
                elAcuerdo.Compromiso, false);*/

            try
            {
                successEliminar = Eliminar(elAcuerdo, codigoProyecto);
                successAgregar = Agregar(elAcuerdo);
                if ((successEliminar == true) && (successAgregar))
                {
                    success = true;
                }
                //List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarAcuerdo /*FALTA EL PROCEDURE DE MODIFICAR ACUERDO*/, parametros);
                //return (tmp.ToArray().Length > 0);
            }

            catch (NullReferenceException ex)
            {
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);
            }
            catch (ExceptionTotemConexionBD ex)
            {
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
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

            return success;
        }

        #endregion

        #region Consultar

        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar los Acuerdos vinculados a una minuta es especifico
        /// </summary>
        /// <param name="idMinuta">id de la minuta </param>
        /// <returns>Retorna un DataTable de Acuerdos vinculados a la Minuta</returns>
        public List<Entidad> ConsultarTodos(int idMinuta)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                idMinuta.ToString(), false);
            parametros.Add(elParametro);

            Acuerdo elAcuerdo;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarAcuerdo, parametros);
                if (resultado.Rows.Count > 0)
                {
                    foreach (DataRow row in resultado.Rows)
                    {
                        elAcuerdo = (Acuerdo)laFabrica.ObtenerAcuerdo();
                        elAcuerdo.Id = int.Parse(row[RecursosBDModulo8.AtributoIDPunto].ToString());
                        elAcuerdo.Fecha = DateTime.Parse(row[RecursosBDModulo8.AtributoTituloPunto].ToString());
                        elAcuerdo.Compromiso = row[RecursosBDModulo8.AtributoDesarrolloPunto].ToString();
                        elAcuerdo.ListaContacto = ObtenerContactoAcuerdo(elAcuerdo.Id).Cast<Contacto>().ToList();
                        elAcuerdo.ListaUsuario = ObtenerUsuarioAcuerdo(elAcuerdo.Id).Cast<Usuario>().ToList();
                        laLista.Add(elAcuerdo);
                    }
                }
                else
                {
                    laLista = null;
                }
            }

            catch (NullReferenceException ex)
            {
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);
            }
            catch (ExceptionTotemConexionBD ex)
            {
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
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

            return laLista;
        }

        /// <summary>
        /// Metodo para obtener los responsables Usuarios de un Acuerdo de una Minuta
        /// </summary>
        /// <param name="IdAcuerdo">Id del acuerdo del que se desea consultar</param>
        /// <returns>Retorna un DataTable de Usuarios</returns>
        public List<Entidad> ObtenerUsuarioAcuerdo (int IdAcuerdo)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            List<Resultado> usuario = new List<Resultado>();
            DataTable idUsuarios = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                IdAcuerdo.ToString(), false);
            parametros.Add(elParametro);

            Usuario elUsuario;
            List<Parametro> parametros2 = new List<Parametro>();
            Parametro elParametro2;
            try
            {
                idUsuarios = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoUsuarioAcuerdo, parametros);
                if (idUsuarios.Rows.Count > 0)
                {
                    foreach (DataRow row in idUsuarios.Rows)
                    {
                        parametros2 = new List<Parametro>();
                        elParametro2 = new Parametro(RecursosBDModulo8.ParametroIDUsuario, SqlDbType.Int, 
                            row[RecursosBDModulo8.ParametroIDUsuario].ToString(), false);
                        parametros2.Add(elParametro2);

                        usuario = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoConsultarUsuarios, parametros2);

                        elUsuario = (Usuario)laFabrica.ObtenerUsuario();
                        elUsuario.Id = int.Parse(usuario[0].valor);
                        elUsuario.Nombre = usuario[1].valor;
                        elUsuario.Apellido = usuario[2].valor;
                        elUsuario.Rol = usuario[3].valor;

                        laLista.Add(elUsuario);
                    }
                }
                else
                {
                    idUsuarios = null;
                }

            }

            catch (NullReferenceException ex)
            {
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);
            }
            catch (ExceptionTotemConexionBD ex)
            {
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
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

            return laLista;
        }

        /// <summary>
        /// Metodo para obtener los responsables Contactos de un Acuerdo de una Minuta
        /// </summary>
        /// <param name="IdAcuerdo">Id del acuerdo del que se desea consultar</param>
        /// <returns>Retorna un DataTable de Contactos</returns>
        public List<Entidad> ObtenerContactoAcuerdo (int IdAcuerdo)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            List<Resultado> contacto = new List<Resultado>();
            DataTable idContactos = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                IdAcuerdo.ToString(), false);
            parametros.Add(elParametro);

            Contacto elContacto;
            List<Parametro> parametros2;
            Parametro elParametro2;
            try
            {
                idContactos = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoUsuarioAcuerdo, parametros);
                if (idContactos.Rows.Count > 0)
                {
                    foreach (DataRow row in idContactos.Rows)
                    {
                        parametros2 = new List<Parametro>();
                        elParametro2 = new Parametro(RecursosBDModulo8.ParametroIDUsuario, SqlDbType.Int,
                            row[RecursosBDModulo8.ParametroIDUsuario].ToString(), false);
                        parametros2.Add(elParametro2);

                        contacto = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoConsultarUsuarios, parametros2);

                        elContacto = (Contacto)laFabrica.ObtenerContacto();
                        elContacto.Id = int.Parse(contacto[0].valor);
                        elContacto.Con_Nombre = contacto[1].valor;
                        elContacto.Con_Apellido = contacto[2].valor;
                        elContacto.ConCargo = contacto[3].valor;

                        laLista.Add(elContacto);
                    }
                }
                else
                {
                    laLista = null;
                }

            }

            catch (NullReferenceException ex)
            {
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);
            }
            catch (ExceptionTotemConexionBD ex)
            {
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
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

            return laLista;
        }
        #endregion

        #region Eliminar

        /// <summary>
        /// Metodo para eliminar un acuerdo de la BD
        /// </summary>
        /// <param name="idAcuerdo">ID del Acuerdo que se desea eliminar</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito o no la operacion</returns>
        public bool Eliminar(Entidad parametro, String codigoProyecto)
        {
            bool contactoBool = false;
            bool usuarioBool = false;
            bool success = false;
            Acuerdo acuerdo = (Acuerdo)parametro;
            Fabrica.FabricaAbstractaDAO laFabrica = Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();
            IntefazDAO.Modulo8.IDaoInvolucradosMinuta DAOInvolucradosMinuta = laFabrica.ObtenerDAOInvolucradosMinuta();

            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                acuerdo.Id.ToString(), false);

            try
            {
                foreach (Contacto contacto in acuerdo.ListaContacto)
                {
                    contactoBool = DAOInvolucradosMinuta.EliminarContactoEnAcuerdo(contacto,acuerdo.Id,codigoProyecto);
                }
                foreach (Usuario usuario in acuerdo.ListaUsuario)
                {
                    usuarioBool = DAOInvolucradosMinuta.EliminarUsuarioEnAcuerdo(usuario, acuerdo.Id, codigoProyecto);
                }
                if ((contactoBool == true) && (usuarioBool == true))
                {
                    List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoEliminarAcuerdo, parametros);
                    if (tmp.ToArray().Length > 0)
                    {
                        success = true;
                    }
                }
            }

            catch (NullReferenceException ex)
            {
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);
            }
            catch (ExceptionTotemConexionBD ex)
            {
                throw new ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
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

            return success;
        }

        #endregion

    }

}