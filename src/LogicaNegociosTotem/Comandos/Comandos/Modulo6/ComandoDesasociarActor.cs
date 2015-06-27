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
   public class ComandoDesasociarActor: Comando<Entidad,bool>
    {
        /// <summary>
        /// Método del comando que accede a DAO para 
        /// desasociar un actor de un caso de uso
        /// </summary>
        /// <param name="parametro">Caso de Uso a desasociar</param>
        /// <returns>Si lo desasoció o no</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoCasoDeUso daoCasoDeUso = laFabrica.ObtenerDAOCasoDeUso();

                return daoCasoDeUso.DesasociarCUDelActor(parametro);
            }
            #region Captura de Excepciones
            catch (ActorInexistenteBDException ex)
            {
                ActorInexistenteComandoException exComandoAgregarActor = new
                    ActorInexistenteComandoException(
                     RecursosComandosModulo6.CodigoComandoActorInexistente,
                     RecursosComandosModulo6.MensajeComandoActorInexistente,
                     ex);

                Logger.EscribirError(this.GetType().Name,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
            catch (BDDAOException ex)
            {

                ComandoBDException exComandoAgregarActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoBD,
                     ex);

                Logger.EscribirError(this.GetType().Name,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;

            }


            catch (ObjetoNuloDAOException ex)
            {
                ComandoNullException exComandoAgregarActor = new ComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(this.GetType().Name,
                  exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoAgregarActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(this.GetType().Name,
                   exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
            #endregion
        }
    }
}
