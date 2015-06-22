using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo6;
using DAO.IntefazDAO.Modulo6;
using Dominio;
using System.Data.SqlClient;
using System.Data;
using Dominio.Entidades.Modulo5; 
using System.Data.Sql;

using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem; 

namespace DAO.DAO.Modulo6
{
   public class DAOCasoDeUso: DAO, IDaoCasoDeUso
    {
        /// <summary>
        /// Método de Dao que se conecta a Base de Datos
        /// para agregar un Caso de Uso
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad Caso de Uso
        /// con los datos del caso de uso a ser agregado</param>
        /// <returns>True si lo agregó, false en caso contrario</returns>
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Método de DAO que accede a la Base de Datos 
        /// para actualizar los datos de un Caso de Uso
        /// </summary>
        /// <param name="parametro">Objeto Entidad de tipo Caso de Uso</param>
        /// <returns>True si modificó, false en 
        /// caso contrario</returns>
        public bool Modificar(Entidad parametro)
        {
            return false;
        }

        /// <summary>
        /// Método que accede a Base de Datos para
        /// consultar los datos específicos de un caso de uso.
        /// </summary>
        /// <param name="parametro">El Caso de Uso a consultar</param>
        /// <returns>Los datos específicos del Actor</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Entidad laEntidad;
            laEntidad = FabricaEntidades.ObtenerCasoDeUso();
            return laEntidad;
        }

        /// <summary>
        /// Método de DAO que accede a la Base de Datos
        /// para traer una lista de todos los casos de usos registrados
        /// en Base de Datos.
        /// </summary>
        /// <returns>Lista de todos los casos de uso</returns>
        public List<Entidad> ConsultarTodos()
        {
            return new List<Entidad>();
        }


        #region Casos de Uso por Actor
        /// <summary>
       /// Método que accede a la base de Datos
       /// para consultar un listado de Casos de Uso dado un Actor
       /// </summary>
       /// <param name="actor">Actor asociado con los casos de uso</param>
       /// <returns>Listas de Casos de Uso asociado al actor</returns>
        public List<Entidad> ConsultarCasosDeUsoPorActor(Entidad actor) 
        {
            List<Entidad> listadoCasosDeUso = new List<Entidad>();
            DataTable resultado = new DataTable();
            Actor elActor = (Actor) actor;
            
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo6.ID_ACTOR, SqlDbType.Int,elActor.Id.ToString(), false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursosDAOModulo6.CodigoProyecto, SqlDbType.VarChar, elActor.ProyectoAsociado.Codigo, false);
            parametros.Add(parametro);

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosDAOModulo6.CasoDeUsosPorActor,parametros); 
       

                foreach (DataRow row in resultado.Rows)
                {
                    Entidad laEntidad = FabricaEntidades.ObtenerCasoDeUso();
                    CasoDeUso casoUso = (CasoDeUso)laEntidad;
                    casoUso.Id = Convert.ToInt32(row[RecursosDAOModulo6.AliasIdCasoDeUso].ToString());
                    casoUso.IdentificadorCasoUso = row[RecursosDAOModulo6.AliasIdentificadorCasoDeUso].ToString();
                    casoUso.TituloCasoUso = row[RecursosDAOModulo6.AliasTituloCasoDeUso].ToString();
                    casoUso.CondicionExito = row[RecursosDAOModulo6.AliasCondicionExito].ToString();
                    casoUso.CondicionFallo = row[RecursosDAOModulo6.AliasCondicionFallo].ToString();
                    casoUso.DisparadorCasoUso = row[RecursosDAOModulo6.AliasDisparadorCU].ToString();
                    listadoCasosDeUso.Add(casoUso); 
                   
                }

            }
            catch (SqlException e)
            {


                BDDAOException exDaoCasoUso = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                    exDaoCasoUso);

                throw exDaoCasoUso;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoCasoUso = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                       exDaoCasoUso);

                throw exDaoCasoUso;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoCasoUso = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                       exDaoCasoUso);

                throw exDaoCasoUso;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoCasoUso = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                      exDaoCasoUso);

                throw exDaoCasoUso;
            }
            return listadoCasosDeUso;

        }

       /// <summary>
       /// Método que accede a Base de Datos para consultar la lista
       /// de requerimientos asociados con un caso de uso
       /// </summary>
       /// <param name="idCasoDeUso">Id del Caso de Uso</param>
       /// <returns>Lista de Requerimientos asociados al caso de uso</returns>
        public List<Entidad> ConsultarRequerimientosXCasoDeUso(int idCasoDeUso) 
        {
            List<Entidad> listaRequerimientos = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo6.ID_CU, SqlDbType.Int, idCasoDeUso.ToString(), false);
            parametros.Add(parametro);
            
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosDAOModulo6.PROCEDURE_LEER_REQUERIMIENTO_DEL_CU,parametros); 
       

                foreach (DataRow row in resultado.Rows)
                {
                    Entidad laEntidad = FabricaEntidades.ObtenerRequerimiento();
                    Requerimiento req = (Requerimiento)laEntidad;                   
                    req.Descripcion = row[RecursosDAOModulo6.AliasRequerimiento].ToString();
                    listaRequerimientos.Add(req);                    
                }
            }
            catch (SqlException e)
            {


                BDDAOException exDaoCasoUso = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                    exDaoCasoUso);

                throw exDaoCasoUso;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoCasoUso = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                       exDaoCasoUso);

                throw exDaoCasoUso;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoCasoUso = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                       exDaoCasoUso);

                throw exDaoCasoUso;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoCasoUso = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOCasoDeUso,
                      exDaoCasoUso);

                throw exDaoCasoUso;
            }
            return listaRequerimientos;


        }


        #endregion
    }
}
