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
               throw new AgregarActorBDDAOException(
                   RecursosDAOModulo6.CodigoExcepcionAgregarActorBD,
                   RecursosDAOModulo6.MensajeExcepcionAgregarActorBD, 
                   e);
           }
           catch (NullReferenceException e)
           {
               throw new AgregarActorNuloDAOException(
                   RecursosDAOModulo6.CodigoExcepcionAgregarActorNulo,
                   RecursosDAOModulo6.MensajeExcepcionAgregarActorNulo, 
                   e); 
           }
           catch (Exception e) 
           {
               throw new AgregarActorDAOException(
                   RecursosDAOModulo6.CodigoExcepcionAgregarActorError,
                   RecursosDAOModulo6.MensajeExcepcionAgregarActorError,
                   e);  
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
       public Entidad ConsultarXId(Entidad parametro) 
       {
           Entidad laEntidad;
           laEntidad = FabricaEntidades.ObtenerActor(); 
           return laEntidad; 
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

    }
}
