using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.IntefazDAO;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo8;
using Dominio.Entidades.Modulo2;
using System.Data;
using System.Data;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo8;

using ExcepcionesTotem.Modulo8.ExcepcionesDeDatos;
using System.Data.SqlClient;

namespace DAO.DAO.Modulo8
{
    public class DaoInvolucradosMinuta : DAO, IntefazDAO.Modulo8.IDaoInvolucradosMinuta
    {

        public bool Agregar(Entidad parametro)
        {
           throw new NotImplementedException();
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
        /// Metodo para eliminar involucrados de una minuta
        /// </summary>
        /// <param name="idMinuta">minuta a eliminar involucrados</param>
        /// <returns>Retorna un Boolean para saber si se realizo con exito la operación</returns>
        public bool EliminarInvolucradoEnMinuta(int idMinuta)
        {
           

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroStored = new Parametro(RecursosBDModulo8.ParametroIDMinuta, SqlDbType.Int, idMinuta.ToString(), false);
            parametros.Add(parametroStored);
            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosBDModulo8.ProcedureEliminarInvolucradoMinuta, parametros);
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