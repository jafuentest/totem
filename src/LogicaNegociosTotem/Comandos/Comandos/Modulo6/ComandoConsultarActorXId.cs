using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;
using DAO.DAO.Modulo6;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo6;

namespace Comandos.Comandos.Modulo6
{
   public class ComandoConsultarActorXId: Comando<Entidad,Entidad>
    {

       /// <summary>
       /// Método del comando que accede a DAO para 
       /// retornar un actor según el id
       /// </summary>
       /// <param name="parametro">Actor a buscar</param>
       /// <returns>El actor encontrado</returns>
       public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoActor daoActor = laFabrica.ObtenerDAOActor();

                return daoActor.ConsultarXId(parametro);
            }

            catch (ActorInexistenteBDException ex) 
            {
                ActorInexistenteComandoException exComandoAgregarActor = new 
                    ActorInexistenteComandoException(
                     RecursosComandosModulo6.CodigoComandoActorInexistente,
                     RecursosComandosModulo6.MensajeComandoActorInexistente,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActorXId,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;
            
            }
            catch (BDDAOException ex)
            {

                ComandoBDException exComandoAgregarActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoBD,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActorXId,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;

            }


            catch (ObjetoNuloDAOException ex)
            {
                ComandoNullException exComandoAgregarActor = new ComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActorXId,
                  exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoAgregarActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActorXId,
                   exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

        }
    }
}
