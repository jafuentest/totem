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
   public class ComandoConsultarActoresCombo:Comando<string,List<Entidad>>
    {

        /// <summary>
        /// Comando que se ejecuta para cargar el combo de listado de actores
        /// </summary>
        /// <param name="parametro">Código de Proyecto</param>
        /// <returns>Lista de Actores dado el código de proyecto</returns>
       public override List<Entidad> Ejecutar(string parametro)
       {
           try
           {
               DAO.Fabrica.FabricaAbstractaDAO fabricaDaoSqlServer = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();

               DAOActor daoActor = (DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
               List<Entidad> resultado = daoActor.consultarActoresCombo(parametro);
               return resultado;
           }

           catch (BDDAOException ex)
           {

               ComandoBDException exComandoAgregarActor = new ComandoBDException(
                    RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorBD,
                    RecursosComandosModulo6.MensajeExcepcionComandoBD,
                    ex);

               Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                   exComandoAgregarActor);

               throw exComandoAgregarActor;

           }
           catch (TipoDeDatoErroneoDAOException ex)
           {
               TipoDeDatoErroneoComandoException exComandoAgregarActor = new TipoDeDatoErroneoComandoException(
                    RecursosComandosModulo6.CodigoExcepcionComandoTipoDeDatoErroneo,
                    RecursosComandosModulo6.MensajeTipoDeDatoErroneoComandoExcepcion,
                    ex);

               Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                   exComandoAgregarActor);

               throw exComandoAgregarActor;
           }

           catch (ObjetoNuloDAOException ex)
           {
               ComandoNullException exComandoAgregarActor = new ComandoNullException(
                   RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorNulo,
                   RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                   ex);

               Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                 exComandoAgregarActor);

               throw exComandoAgregarActor;

           }

           catch (ErrorDesconocidoDAOException ex)
           {
               ComandoException exComandoAgregarActor = new ComandoException(
                    RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorError,
                    RecursosComandosModulo6.MensajeExcepcionComandoError,
                    ex);

               Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                  exComandoAgregarActor);

               throw exComandoAgregarActor;

           }
       }
    }
}
