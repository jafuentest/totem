using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo8;
using System.Data;
using System.Data;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using System.Data.SqlClient;

namespace DAO.DAO.Modulo8
{
    public class DaoMinuta : DAO, IntefazDAO.Modulo8.IDaoMinuta
    {
        #region Agregar
        public bool Agregar(Entidad parametro)
        {
            Minuta laMinuta = (Minuta)parametro;

          
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime,
                laMinuta.Fecha.ToShortDateString(), false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar,
                laMinuta.Motivo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar,
                laMinuta.Observaciones, false);
            parametros.Add(elParametro);
            

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarMinuta, parametros);
                return (tmp.ToArray().Length > 0);
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

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
            
            Minuta laMinuta = (Minuta)parametro;
           
           
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                laMinuta.Codigo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime,
                 laMinuta.Fecha.ToShortDateString(), false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar,
                laMinuta.Motivo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar,
                laMinuta.Observaciones, false);
            parametros.Add(elParametro);
           
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoModificarMinuta,
                    parametros);
                return (tmp.ToArray().Length > 0);
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

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
        #region ConsultarXId
        public Entidad ConsultarXId(Entidad parametro)
        {
            
            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta,
                SqlDbType.Int, parametro.Id.ToString(), false);
            parametros.Add(parametroStored);
            Minuta laMinuta = (Minuta)laFabrica.ObtenerMinuta();
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarMinuta, parametros);

                foreach (DataRow row in resultado.Rows)
                {

                    laMinuta.Codigo = row[RecursosBDModulo8.AtributoIDMinuta].ToString();
                    laMinuta.Fecha = DateTime.Parse(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta.Motivo = row[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                    laMinuta.Observaciones = row[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();
                   

                }
                return laMinuta;
            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

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
        #region ConsultarTodos
        
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();

        }
        #endregion
        #region Consultar Minutas de Proyecto
        public List<Entidad> ConsultarMinutasProyecto(string idProyecto) 
        {
            

            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroProyectoMinuta,
                SqlDbType.VarChar, idProyecto, false);
            parametros.Add(parametroStored);
            
            Minuta laMinuta;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarListaMinutas, parametros);

                foreach (DataRow row in resultado.Rows)
                {


                    laMinuta = (Minuta)laFabrica.ObtenerMinuta();
                    laMinuta.Codigo = row[RecursosBDModulo8.AtributoIDMinuta].ToString();
                    laMinuta.Fecha = DateTime.Parse(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta.Motivo = row[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                    laMinuta.Observaciones = row[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();
                    laLista.Add(laMinuta);
                }

                return laLista;

            }
            catch (NullReferenceException ex)
            {

                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

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