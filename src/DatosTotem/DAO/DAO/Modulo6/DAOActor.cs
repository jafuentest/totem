using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Datos.IntefazDAO.Modulo6;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;

namespace Datos.DAO.Modulo6
{
    public class DAOActor : DAOGeneral, IDaoActor
    {

        #region Métodos para Agregar Actor
        /// <summary>
        /// Método de Dao que se conecta a Base de Datos
        /// para agregar un Actor
        /// </summary>
        /// <param name="parametro">Objeto de tipo Entidad Actor
        /// con los datos del actor a ser agregado</param>
        /// <returns>True si lo agregó, false en caso contrario</returns>
        public bool Agregar(Entidad parametro)
        {
            Actor actor = parametro as Actor;

            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosDAOModulo6.NOMBRE_ACTOR,
                SqlDbType.VarChar, actor.NombreActor, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosDAOModulo6.DESC_ACTOR, SqlDbType.VarChar,
                actor.DescripcionActor, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosDAOModulo6.CodigoProyecto, SqlDbType.VarChar,
                actor.ProyectoAsociado.Codigo, false);
            parametros.Add(elParametro);
            elParametro = new Parametro(RecursosDAOModulo6.Output_Afectado, SqlDbType.Int,
                true);
            parametros.Add(elParametro);

            try
            {
                List<Resultado> tmp = EjecutarStoredProcedure(RecursosDAOModulo6.PROCEDURE_INSERTAR_ACTOR,
                    parametros);
                return (tmp.ToArray().Length > 0);

            }
            catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                throw exDaoActor;
            }
        }


        /// <summary>
        /// Método que verifica la existencia de un 
        /// Actor en Base de Datos
        /// </summary>
        /// <param name="nombre">El nombre del actor a verificar</param>
        /// <returns>True si existe, false si no</returns>
        public bool VerificarExistenciaActor(string nombre)
        {
            bool existencia = false;
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametroProc = new Parametro(RecursosDAOModulo6.NOMBRE_ACTOR, SqlDbType.VarChar,
                nombre, false);
            parametros.Add(parametroProc);
            parametroProc = new Parametro(RecursosDAOModulo6.Output_Existe, SqlDbType.Int,
                true);
            parametros.Add(parametroProc);

            try
            {
                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDAOModulo6.ValidarExistenciaActor, parametros);

                foreach (Resultado resultado in resultados)
                {
                    if (resultado != null && resultado.etiqueta != "")
                    {
                        int conteo = Convert.ToInt32(resultado.valor);

                        if (conteo > 0)
                        {
                            existencia = true;
                        }

                    }
                }
            }
            catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoActor = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                throw exDaoActor;
            }
            return existencia;
        }




        #endregion


        #region Métodos para Reporte Actores

        /// <summary>
        /// Método que accede a base de Datos para consultar los actores
        /// para ser cargados en el combo de Reporte Actores
        /// </summary>
        /// <param name="codigoProyecto">Código de proyecto</param>
        /// <returns>Lista de actores asociados al proyecto</returns>
        public List<Entidad> ConsultarActoresCombo(string codigoProyecto) 
        {
            List<Entidad> listadoActores = new List<Entidad>();
            DataTable resultado = new DataTable();
          
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo6.CodigoProyecto, SqlDbType.VarChar,codigoProyecto, false);
            parametros.Add(parametro); 

            try 
            {
                 resultado = EjecutarStoredProcedureTuplas(RecursosDAOModulo6.ProcedureLlenarComboActores,
                    parametros);

                 foreach (DataRow row in resultado.Rows) 
                 {
                     FabricaEntidades fabrica = new FabricaEntidades(); 
                     Entidad laEntidad = fabrica.ObtenerActor();
                     Actor actor = (Actor)laEntidad;
                     laEntidad.Id = Convert.ToInt32(row[RecursosDAOModulo6.AliasIDActor].ToString());
                     actor.NombreActor = row[RecursosDAOModulo6.AliasNombreActor].ToString();
                     listadoActores.Add(actor); 
                 }

            }
            catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoActor = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                throw exDaoActor;
            }

            return listadoActores; 
        }

        #endregion

        #region Método para Listar Casos de Uso 
        /// <summary>
        /// Método que consulta un listado de actores según el 
        /// id del caso de uso
        /// </summary>
        /// <param name="idCasoUso">Id del Caso de Uso</param>
        /// <returns>Lista de Actores según el caso de uso</returns>
        public List<string> ConsultarActoresXCasoDeUso(int idCasoUso) 
        {
            List<string> listadoActores = new List<string>();
            DataTable resultado = new DataTable();

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo6.ID_CU, SqlDbType.Int, idCasoUso.ToString(), false);
            parametros.Add(parametro);

            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosDAOModulo6.PROCEDURE_LEER_ACTOR_DEL_CU,
                   parametros);

                foreach (DataRow row in resultado.Rows)
                {
                    FabricaEntidades fabrica = new FabricaEntidades();
                    Entidad laEntidad = fabrica.ObtenerActor();
                    Actor actor = (Actor)laEntidad;
                    actor.NombreActor = row[RecursosDAOModulo6.AliasNombreActor].ToString();
                    listadoActores.Add(actor.NombreActor);
                }

            }
            catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoActor = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                throw exDaoActor;
            }

            return listadoActores;
        }
        #endregion


        /// <summary>
        /// Método de DAO que accede a la Base de Datos 
        /// para actualizar los datos de un actor
        /// </summary>
        /// <param name="parametro">Objeto Entidad de tipo Actor</param>
        /// <returns>True si modificó, false en 
        /// caso contrario</returns>
        public bool Modificar(Entidad parametro)
        {
            bool actorModificado = false;
            Actor actorAModificar = (Actor)parametro;
            Parametro elParametro;
            List<Parametro> parametros = new List<Parametro>();

            #region Llenado de Parámetros
            elParametro = new Parametro(RecursosDAOModulo6.
               NOMBRE_ACTOR, SqlDbType.VarChar, actorAModificar.NombreActor,
               false);
            parametros.Add(elParametro);

            elParametro = new Parametro(RecursosDAOModulo6.
               DESC_ACTOR, SqlDbType.VarChar, actorAModificar.DescripcionActor,
               false);
            parametros.Add(elParametro);

             elParametro = new Parametro(RecursosDAOModulo6.
               ID_ACTOR, SqlDbType.Int, actorAModificar.Id.ToString(),
               false);
            parametros.Add(elParametro);

#endregion
            try
            {
                List<Resultado> resultados = EjecutarStoredProcedure(
                       RecursosDAOModulo6.PROCEDURE_MODIFICAR_ACTOR,
                       parametros);

                if (resultados != null)
                {
                    actorModificado = true;
                }
                else 
                {
                    Logger.EscribirError(this.GetType().Name,
                   new ActorNoModificadoBDException());

                    throw new ActorNoModificadoBDException(
                                RecursosDAOModulo6.CodigoActorNoModificado,
                                RecursosDAOModulo6.MensajeActorNoModificadoBD,
                                new ActorNoModificadoBDException());
                }

            }
            catch (ActorNoModificadoBDException e)
            {
                Logger.EscribirError(this.GetType().Name,
                    e);

                throw e;
            }
             catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(this.GetType().Name,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(this.GetType().Name,
                       exDaoActor);

                throw exDaoActor;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoActor = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(this.GetType().Name,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(this.GetType().Name,
                      exDaoActor);

                throw exDaoActor;
            }

            return actorModificado; 
        }





        

        /// <summary>
        /// Método que accede a Base de Datos para
        /// consultar los datos específicos de un actor.
        /// </summary>
        /// <param name="parametro">El Actor a consultar</param>
        /// <returns>Los datos específicos del Actor</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Actor elActor;

            try 
            {
                elActor = (Actor)laFabrica.ObtenerActor();
                Parametro parametroStored = new Parametro(RecursosDAOModulo6.ID_ACTOR,
                   SqlDbType.Int, parametro.Id.ToString(), false);
                parametros.Add(parametroStored);
                resultado = EjecutarStoredProcedureTuplas(
                    RecursosDAOModulo6.ProcedureConsultarActorXID, parametros);

                if (resultado == null) 
                {
                    Logger.EscribirError(Convert.ToString(this.GetType()),
                        new ActorInexistenteBDException());

                    throw new ActorInexistenteBDException(RecursosDAOModulo6.CodigoActorInexistente,
                       RecursosDAOModulo6.MensajeActorInexistente, new ActorInexistenteBDException());
                }

                 foreach (DataRow row in resultado.Rows)
                 {
                    
                    elActor = (Actor)laFabrica.ObtenerActor();
                    elActor.Id = Convert.ToInt32(row[RecursosDAOModulo6.AliasIDActor].ToString());
                    
                    elActor.NombreActor = row[RecursosDAOModulo6.AliasNombreActor].ToString();
                    elActor.DescripcionActor = row[RecursosDAOModulo6.AliasDescripcionActor].ToString();

                 }
                
             }
            catch (ActorInexistenteBDException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
             catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoActor = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                throw exDaoActor;
            }
            return elActor;
    }
        

        /// <summary>
        /// Método de DAO que accede a la Base de Datos
        /// para traer una lista de todos los actores registrados
        /// en Base de Datos.
        /// </summary>
        /// <returns>Lista de todos los actores</returns>
        public List<Entidad> ConsultarTodos()
        {
            return new List<Entidad>();
        }

        /// <summary>
        /// Método de DAO que accede a la Base de Datos
        /// para traer una lista de todos los actores registrados
        /// en Base de Datos.
        /// </summary>
        /// <returns>Lista de todos los actores</returns>
        public List<Entidad> ConsultarListarActores(string codigoProy)
        {


            FabricaEntidades laFabrica = new FabricaEntidades();
            List<Entidad> laLista = new List<Entidad>();
            DataTable resultado = new DataTable();
            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro(RecursosDAOModulo6.CodigoProyecto, SqlDbType.VarChar, codigoProy, false);
            parametros.Add(parametro);
            Actor elActor;
            Proyecto elProyecto;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursosDAOModulo6.PROCEDURE_LEER_ACTOR, parametros);

                foreach (DataRow row in resultado.Rows)
                {

                    


                    elProyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
                    elActor = (Actor)laFabrica.ObtenerActor(); ;
                    // Atributos de la tabla Actor
                    elActor.Id = int.Parse(row[RecursosDAOModulo6.AliasIDActor].ToString());
                    elActor.NombreActor = row[RecursosDAOModulo6.AliasNombreActor].ToString();
                    elActor.DescripcionActor = row[RecursosDAOModulo6.AliasDescripcionActor].ToString();
                    elProyecto.Codigo = codigoProy;
                    elActor.ProyectoAsociado = elProyecto;

                   
                    laLista.Add(elActor);
                }
            }
            catch (SqlException e)
            {


                BDDAOException exDaoActor = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                    exDaoActor);

                throw exDaoActor;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoActor = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoActor = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoActor);

                throw exDaoActor;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoActor = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                throw exDaoActor;
            }

            return laLista;
        }

        #region Eliminar Actor
        /// <summary>
        /// Método encargado de acceder a la base de Datos
        /// para eliminar un Actor dado su id y eliminar
        /// sus registros asociados
        /// </summary>
        /// <param name="id">Id del Actor</param>
        /// <returns>True si lo pudo realizar, false en caso contrario</returns>
        public bool EliminarActor(int id)
        {
            bool exito = false;
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro(RecursosDAOModulo6.ID_ACTOR, SqlDbType.Int, id.ToString(), false);
            parametros.Add(elParametro);
            try
            {
                List<Resultado> resultados = EjecutarStoredProcedure(RecursosDAOModulo6.ProcedureEliminarActor, parametros);
                if (resultados != null)
                {
                    exito = true;
                }
            }
            #region Captura de Excepciones 
            catch (SqlException e)
            {


                BDDAOException exDaoCasoUso = new BDDAOException(
                 RecursosDAOModulo6.CodigoExcepcionBDDAO,
                 RecursosDAOModulo6.MensajeExcepcionBD,
                 e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor, exDaoCasoUso);

                throw exDaoCasoUso;

            }
            catch (NullReferenceException e)
            {
                ObjetoNuloDAOException exDaoCasoUso = new ObjetoNuloDAOException(
                    RecursosDAOModulo6.CodigoExcepcionObjetoNuloDAO,
                    RecursosDAOModulo6.MensajeExcepcionObjetoNulo,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoCasoUso);

                throw exDaoCasoUso;

            }

            catch (FormatException e)
            {
                TipoDeDatoErroneoDAOException exDaoCasoUso = new TipoDeDatoErroneoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionTipoDeDatoErroneo,
                    RecursosDAOModulo6.MensajeTipoDeDatoErroneoException,
                    e);
                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                       exDaoCasoUso);

                throw exDaoCasoUso;

            }
            catch (Exception e)
            {
                ErrorDesconocidoDAOException exDaoCasoUso = new ErrorDesconocidoDAOException(
                    RecursosDAOModulo6.CodigoExcepcionErrorDAO,
                    RecursosDAOModulo6.MensajeExcepcionErrorDesconocido,
                    e);

                Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoCasoUso);

                throw exDaoCasoUso;
            }
            #endregion
            return exito;

        }
        #endregion

        

    }
}
