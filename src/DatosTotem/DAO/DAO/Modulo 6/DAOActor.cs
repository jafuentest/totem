using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo6;
using DAO.IntefazDAO.Modulo6;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;  

namespace DAO.DAO.Modulo6
{
   public class DAOActor:DAO, IDaoActor
    {

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
               SqlDbType.VarChar,actor.NombreActor,false);
           parametros.Add(elParametro); 
           elParametro = new Parametro(RecursosDAOModulo6.DESC_ACTOR,SqlDbType.VarChar,
               actor.DescripcionActor,false);
           parametros.Add(elParametro);
          //falta el id del proyecto

           try
           {
               List<Resultado> tmp = EjecutarStoredProcedure(RecursosDAOModulo6.PROCEDURE_INSERTAR_ACTOR,
                   parametros);
               return (tmp.ToArray().Length > 0);
           }
           catch (SqlException e)
           {
              
                   
                  AgregarActorBDDAOException exDaoActor = new AgregarActorBDDAOException(
                   RecursosDAOModulo6.CodigoExcepcionAgregarActorBD,
                   RecursosDAOModulo6.MensajeExcepcionAgregarActorBD, 
                   e);

                  Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

                  throw exDaoActor; 
               
           }
           catch (NullReferenceException e)
           {
               AgregarActorNuloDAOException exDaoActor = new AgregarActorNuloDAOException(
                   RecursosDAOModulo6.CodigoExcepcionAgregarActorNulo,
                   RecursosDAOModulo6.MensajeExcepcionAgregarActorNulo, 
                   e);
               Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

               throw exDaoActor; 
               
           }
           catch (Exception e) 
           {
               AgregarActorDAOException exDaoActor =  new AgregarActorDAOException(
                   RecursosDAOModulo6.CodigoExcepcionAgregarActorError,
                   RecursosDAOModulo6.MensajeExcepcionAgregarActorError,
                   e);

               Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                     exDaoActor);

               throw exDaoActor; 
           }
       }

       /// <summary>
       /// Método de DAO que accede a la Base de Datos 
       /// para actualizar los datos de un actor
       /// </summary>
       /// <param name="parametro">Objeto Entidad de tipo Actor</param>
       /// <returns>True si modificó, false en 
       /// caso contrario</returns>
       public bool Modificar(Entidad parametro) 
       {
           return false; 
       }

       /// <summary>
       /// Método que accede a Base de Datos para
       /// consultar los datos específicos de un actor.
       /// </summary>
       /// <param name="parametro">El Actor a consultar</param>
       /// <returns>Los datos específicos del Actor</returns>
       //public Entidad ConsultarXId(Entidad parametro) 
      // {
      //     Entidad laEntidad;
           //  laEntidad = laEntidad.FabricaEntidades.ObtenerActor(); 
       //    return laEntidad; 
       // }

       /// <summary>
       /// Método de DAO que accede a la Base de Datos
       /// para traer una lista de todos los actores registrados
       /// en Base de Datos.
       /// </summary>
       /// <returns>Lista de todos los actores</returns>
       public List<Entidad> ConsultarTodos() 
       {


           FabricaEntidades laFabrica = new FabricaEntidades();
           List<Entidad> laLista = new List<Entidad>();
           DataTable resultado = new DataTable();
           List<Parametro> parametros = new List<Parametro>();
           Actor elActor;
           //Direccion laDireccion;
           try
           {
               resultado = EjecutarStoredProcedureTuplas(RecursosDAOModulo6.PROCEDURE_LEER_ACTOR, parametros);

               foreach (DataRow row in resultado.Rows)
               {

                   //FALTA EL ID DEL PROYECTO
                   //  laDireccion = (Direccion)laFabrica.ObtenerDireccion();
                   elActor = (Actor)laFabrica.ObtenerActor();
                   //elProyecto = (Proyecto)laFabrica.ObtenerProyecto();
                   elActor.Id = int.Parse(row[RecursosDAOModulo6.AliasActorID].ToString());
                   //elProyecto = (Proyecto)laFabrica.ObtenerProyecto();
                   elActor.NombreActor = row[RecursosDAOModulo6.AliasActorNombre].ToString();
                   elActor.DescripcionActor = row[RecursosDAOModulo6.AliasActorDescripcion].ToString();
                   
                   // proy_act. = elProyecto;
                   laLista.Add(elActor);
               }

               return laLista;

           }
           catch (SqlException e)
           {


               ConsultarActoresBDDAOException exDaoActor = new ConsultarActoresBDDAOException(
                RecursosDAOModulo6.CodigoExcepcionConsultarActoresBD,
                RecursosDAOModulo6.MensajeExcepcionConsultarActoresBD,
                e);

               Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                   exDaoActor);

               throw exDaoActor;

           }
           catch (NullReferenceException e)
           {
               ConsultarActoresNuloDAOException exDaoActor = new ConsultarActoresNuloDAOException(
                   RecursosDAOModulo6.CodigoExcepcionConsultarActoresNulo,
                   RecursosDAOModulo6.MensajeExcepcionConsultarActoresNulo,
                   e);
               Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                      exDaoActor);

               throw exDaoActor;

           }
           catch (Exception e)
           {
               ConsultarActoresDAOException exDaoActor = new ConsultarActoresDAOException(
                   RecursosDAOModulo6.CodigoExcepcionConsultarActoresError,
                   RecursosDAOModulo6.MensajeExcepcionConsultarActoresError,
                   e);

               Logger.EscribirError(RecursosDAOModulo6.ClaseDAOActor,
                     exDaoActor);

               throw exDaoActor;
           }









           return new List<Entidad>(); 
       }

    }
}
