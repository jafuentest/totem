using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo8;
using System.Data;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8;
using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using System.Data.SqlClient;

namespace Datos.DAO.Modulo8
{
    public class DaoMinuta : DAOGeneral, IntefazDAO.Modulo8.IDaoMinuta
    {
       
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public bool Modificar(Entidad parametro)
        {
            
            Minuta laMinuta = (Minuta)parametro;
           
           
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                laMinuta.Id.ToString(), false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime,
                 laMinuta.Fecha.ToString("yyyy-MM-dd HH':'mm':'ss"), false);
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
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }

        }
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
                  
                    System.Console.Out.WriteLine(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta.Id = int.Parse(row[RecursosBDModulo8.AtributoIDMinuta].ToString());
                    laMinuta.Fecha = DateTime.Parse(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta.Motivo = row[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                    laMinuta.Observaciones = row[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();
                   

                }
                return laMinuta;
            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
        }
        /// <summary>
        /// Metodo que devuelve una lista de todas las minutas asociadas a un Proyecto
        /// </summary>
        /// <param name="idProyecto">id de proyecto que se desea buscar</param>
        /// <returns>Retorna lista de minutas</returns>
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
                    laMinuta.Id = int.Parse(row[RecursosBDModulo8.AtributoIDMinuta].ToString());
                    laMinuta.Fecha = DateTime.Parse(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta.Motivo = row[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                    laMinuta.Observaciones = row[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();
                    laLista.Add(laMinuta);
                }

                return laLista;

            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }

        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();

        }
        /// <summary>
        /// Método para consultar los datos de una minuta en la BD
        /// </summary>
        /// <param name="id">Se recibe el id de la minuta que se desea consultar</param>
        /// <returns>Retrorna el objeto Minuta</returns>
        public Entidad ConsultarMinutaBD(int id)
        {
            
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta,
                SqlDbType.Int, id.ToString(), false);
            parametros.Add(parametroStored);

            Minuta laMinuta = (Minuta)laFabrica.ObtenerMinuta();
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarMinuta, parametros);

                foreach (DataRow row in resultado.Rows)
                {


                    System.Console.Out.WriteLine(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta = (Minuta)laFabrica.ObtenerMinuta();
                    laMinuta.Id =  int.Parse(row[RecursosBDModulo8.AtributoIDMinuta].ToString());
                    laMinuta.Fecha = DateTime.Parse(row[RecursosBDModulo8.AtributoFechaMinuta].ToString());
                    laMinuta.Motivo = row[RecursosBDModulo8.AtributoMotivoMinuta].ToString();
                    laMinuta.Observaciones = row[RecursosBDModulo8.AtributoObservacionesMinuta].ToString();
                    
                }


            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }

            return laMinuta;
        }

        /// <summary>
        /// Metodo para Eliminar una Minuta
        /// </summary>
        /// <param name="idMinuta">Id de la Minuta a eliminar</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public bool EliminarMinuta(int idMinuta)
        {
            List<Parametro> parametros = new List<Parametro>();
             Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int, idMinuta.ToString(), false);
             parametros.Add(parametroStored); 
            
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoEliminarMinuta, parametros);
             
                if (tmp != null)
                {
                    return true;
                }
                else
                {
                    return false;

                }
            }


            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }


        }

        /// <summary>
        /// Metodo para buscar la ultima minuta en bd
        /// </summary>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public int BuscarUltimaMinuta()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            int result=0;
            Minuta laMinuta = (Minuta)laFabrica.ObtenerMinuta();
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoBuscarUltimaMinuta, parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    result = int.Parse(row[RecursosBDModulo8.AtributoIDMinuta].ToString());
                }


            }
            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
            return result;

        }

        /// <summary>
        /// Metodo para guardar una Minuta en la BD
        /// </summary>
        /// <param name="parametro">Objeto de tipo Minuta</param>
        /// <returns>retorna el id de la minuta insertada en caso contrario retorna 0</returns>
        public int AgregarMinuta(Entidad parametro)
        {
            Minuta laMinuta = (Minuta)parametro;

            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroFechaMinuta, SqlDbType.DateTime,
                laMinuta.Fecha.ToString("yyyy-MM-dd HH':'mm':'ss"), false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroMotivoMinuta, SqlDbType.VarChar,
                laMinuta.Motivo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroObservacionesMinuta, SqlDbType.VarChar,
                laMinuta.Observaciones, false);
            parametros.Add(elParametro);

            DataTable resultado = new DataTable();
            int idMinutaInsert;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoAgregarMinuta, parametros);

                foreach (DataRow row in resultado.Rows)
                {

                    idMinutaInsert = int.Parse(row[RecursosBDModulo8.AtributoIDMinuta].ToString());

                    return idMinutaInsert;

                }
            }

            catch (NullReferenceException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                   ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionNullReference,
                    RecursosBDModulo8.Mensaje_ExcepcionNullReference, ex);

            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionSql,
                    RecursosBDModulo8.Mensaje_ExcepcionSql, ex);

            }
            catch (ParametroIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new ParametroIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionParametro,
                    RecursosBDModulo8.Mensaje__ExcepcionParametro, ex);
            }
            catch (AtributoIncorrectoException ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new AtributoIncorrectoException(RecursosBDModulo8.Codigo_ExcepcionAtributo,
                    RecursosBDModulo8.Mensaje_ExcepcionAtributo, ex);
            }
            catch (Exception ex)
            {
                ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
                      ex);
                throw new BDMinutaException(RecursosBDModulo8.Codigo_ExcepcionGeneral,
                   RecursosBDModulo8.Mensaje_ExcepcionGeneral, ex);

            }
            return 0;
        }
    }

}