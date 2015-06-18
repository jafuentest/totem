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
    public class DaoPunto : DAO, IntefazDAO.Modulo8.IDaoPunto
    {

        /// <summary>
        /// Metodo para Agregar un punto en especifico de cualquier Minuta
        /// </summary>
        /// <param name="punto">Objeto Minuta</param>
        /// <param name="idMinuta">Id de la Minuta relcionada</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public bool Agregar(Entidad parametro)
        {
           
            Punto elPunto = (Punto)parametro;

          
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroTituloPunto, SqlDbType.VarChar,
                elPunto.Titulo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroDesarrolloPunto, SqlDbType.VarChar,
                elPunto.Desarrollo, false);
            parametros.Add(elParametro);
            

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoAgregarPunto, parametros);
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
        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        public List<Entidad> ConsultarTodos()
        {
             throw new NotImplementedException();
        }


        /// <summary>
        /// Metodo para Modificar un punto en especifico de cualquier Minuta
        /// </summary>
        /// <param name="punto">Objeto Minuta, con todos los valores a modificar</param>
        /// <param name="idMinuta">Id de la Minuta relcionada</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean ModificarPuntoBD(Entidad punto, int idMinuta)
        { 
          
            Punto elPunto = (Punto)punto;
           
           
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int,
                idMinuta.ToString(), false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroIDPunto, SqlDbType.Int,
                 elPunto.Codigo.ToString(), false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroTituloPunto, SqlDbType.VarChar,
                elPunto.Titulo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosBDModulo8.ParametroDesarrolloPunto, SqlDbType.VarChar,
                elPunto.Desarrollo, false);
            parametros.Add(elParametro);
           
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoModificarPunto,
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

        /// <summary>
        /// Metodo para consultar todos los puntos tratados en una Minuta
        /// </summary>
        /// <param name="idMinuta">Es el id de la Minuta de los puntos a consultar</param>
        /// <returns>Retorna una Lista de todos los punto de la Minuta</returns>
        public List<Entidad> ConsultarPuntoBD(int idMinuta)
        {
          
            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta,
                SqlDbType.Int, idMinuta.ToString(), false);
            parametros.Add(parametroStored);
            
            Punto elPunto;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosBDModulo8.ProcedimientoConsultarListaMinutas, parametros);

                foreach (DataRow row in resultado.Rows)
                {


                    elPunto = (Punto)laFabrica.ObtenerMinuta();
                    elPunto.Codigo =int.Parse( row[RecursosBDModulo8.AtributoIDPunto].ToString());
                    elPunto.Titulo = row[RecursosBDModulo8.AtributoTituloPunto].ToString();
                    elPunto.Desarrollo = row[RecursosBDModulo8.AtributoDesarrolloPunto].ToString();
                    laLista.Add(elPunto);
                }

               
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
         return laLista;
    
        }

        /// <summary>
        /// Metodo para Eliminar un Punto de una Minuta
        /// </summary>
        /// <param name="punto">Objeto Punto</param>
        /// <param name="idMinuta">Id de la Minuta del punto a eliminar</param>
        /// <returns>Retorna un boolean para saber si se realizo con éxito la operación</returns>
        public Boolean EliminarPuntoBD(Entidad punto, int idMinuta)
        {
              
            Punto elPunto=(Punto)punto;
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int, idMinuta.ToString(), false);
            parametros.Add(parametroStored);
            parametroStored = new Parametro(RecursosBDModulo8.ParametroIDPunto, SqlDbType.Int, elPunto.Codigo.ToString(), false);
            parametros.Add(parametroStored);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedimientoEliminarPunto, parametros);
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

    }

}