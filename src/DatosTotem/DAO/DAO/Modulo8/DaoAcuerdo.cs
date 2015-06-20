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

namespace DAO.DAO.Modulo8
{
    public class DaoAcuerdo : DAO, IntefazDAO.Modulo8.IDaoAcuerdo
    {
        #region Agregar

        public bool Agregar(Entidad parametro)
        {
            Acuerdo elAcuerdo = (Acuerdo)parametro;
            
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroFechaAcuerdo, SqlDbType.DateTime,
                elAcuerdo.Fecha.ToShortDateString(), false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroDesarrolloAcuerdo, SqlDbType.VarChar,
                elAcuerdo.Compromiso, false);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarAcuerdo, parametros);
                return (tmp.ToArray().Length > 0);
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

        }

        #endregion

        #region Modificar

        public bool Modificar(Entidad parametro)
        {
            Acuerdo elAcuerdo = (Acuerdo)parametro;

            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                elAcuerdo.Fecha.ToShortDateString(), false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroFechaAcuerdo, SqlDbType.Date,
                elAcuerdo.Compromiso, false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroDesarrolloAcuerdo, SqlDbType.VarChar,
                elAcuerdo.Compromiso, false);
            elParametro = new Parametro(RecursosBDModulo8.ParametroMinuta, SqlDbType.Int,
                elAcuerdo.Compromiso, false);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarAcuerdo /*FALTA EL PROCEDURE DE MODIFICAR ACUERDO*/, parametros);
                return (tmp.ToArray().Length > 0);
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

        public List<Resultado> ConsultarTodos(int idMinuta)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                idMinuta.ToString(), false);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoConsultarAcuerdo, parametros);
                if (tmp.ToArray().Length > 0)
                {
                    return tmp;
                }
                else
                {
                    return null;
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
        }

        #endregion

        #region Eliminar

        public bool Eliminar(int idAcuerdo, int idProyecto, int idUsuario)
        {
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                idAcuerdo.ToString(), false);

            /*List<Parametro> parametros2 = new List<Parametro>();
            Parametro elParametro2 = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                idAcuerdo.ToString(), false);
            elParametro2 = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                idAcuerdo.ToString(), false);
            elParametro2 = new Parametro(RecursosBDModulo8.ParametroIDAcuerdo, SqlDbType.Int,
                idAcuerdo.ToString(), false);*/

            try
            {
                List<Resultado> tmp2 = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientosEliminarAcuerdoUsuario, parametros);
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoEliminarAcuerdo, parametros);
                return ((tmp.ToArray().Length > 0) && (tmp2.ToArray().Length > 0));
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
        }

        #endregion

    }

}