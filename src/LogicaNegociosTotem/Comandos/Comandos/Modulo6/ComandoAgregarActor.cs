using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem; 
using DAO.DAO.Modulo6;
 
  

namespace Comandos.Comandos.Modulo6
{
   public class ComandoAgregarActor : Comando<Entidad,bool>
    {
       /// <summary>
       /// Comando que se ejecuta para agregar un actor de caso de uso
       /// a Base de Datos, recibe el actor como parámetro y retorna
       /// true si lo insertó y false en caso contrario.
       /// </summary>
       /// <param name="parametro">Entidad de tipo Actor a insertar</param>
       /// <returns>True si la inserción fue éxitosa, false en caso
       /// contrario</returns>
       public override bool Ejecutar(Entidad parametro)
       {
           try
           {
               DAO.Fabrica.FabricaDAOSqlServer fabricaDaoSqlServer = new DAO.Fabrica.FabricaDAOSqlServer(); 

               DAO.DAO.Modulo6.DAOActor daoActor = (DAO.DAO.Modulo6.DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
               bool resultado = daoActor.Agregar(parametro);
               return resultado;
           }

           catch (BDDAOException ex)
           {

              ComandoBDException exComandoAgregarActor = new ComandoBDException(
                   RecursosComandosModulo6.CodigoExcepcionComandoBD,
                   RecursosComandosModulo6.MensajeExcepcionComandoBD,
                   ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoAgregarActor,
                  exComandoAgregarActor);

              throw exComandoAgregarActor; 

           }


           catch (ObjetoNuloDAOException ex) 
           {
               ComandoNullException exComandoAgregarActor = new ComandoNullException(
                   RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                   RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                   ex);

               Logger.EscribirError(RecursosComandosModulo6.ClaseComandoAgregarActor,
                 exComandoAgregarActor);

               throw exComandoAgregarActor; 

           }

           catch (ErrorDesconocidoDAOException ex)
           {
              ComandoException exComandoAgregarActor =  new ComandoException(
                   RecursosComandosModulo6.CodigoExcepcionComandoError,
                   RecursosComandosModulo6.MensajeExcepcionComandoError,
                   ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoAgregarActor,
                 exComandoAgregarActor);

              throw exComandoAgregarActor; 

           }
       }
    }
}
