using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;
using DAO.DAO.Modulo6;


namespace Comandos.Comandos.Modulo6
{
    public class ComandoVerificarExistenciaActor : Comando<string, bool>
    {
        /// <summary>
        /// Comando que se ejecuta para verificar la existencia de 
        /// un actor de caso de uso
        /// a Base de Datos, recibe el actor como parámetro y retorna
        /// true si lo insertó y false en caso contrario.
        /// </summary>
        /// <param name="parametro">Nombre del Actor a verificar</param>
        /// <returns>True si existe, false en caso
        /// contrario</returns>
        public override bool Ejecutar(string parametro)
        {
            try
            {
                DAO.Fabrica.FabricaAbstractaDAO fabricaDaoSqlServer = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();

                DAO.DAO.Modulo6.DAOActor daoActor = (DAO.DAO.Modulo6.DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
                bool resultado = daoActor.VerificarExistenciaActor(parametro);
                return resultado;
            }

            catch (AgregarActorBDDAOException ex)
            {

                AgregarActorComandoBDException exComandoAgregarActor = new AgregarActorComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoAgregarActorBD,
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

            catch (AgregarActorNuloDAOException ex)
            {
                AgregarActorComandoNullException exComandoAgregarActor = new AgregarActorComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoAgregarActorNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                  exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

            catch (AgregarActorDAOException ex)
            {
                AgregarActorComandoException exComandoAgregarActor = new AgregarActorComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorError,
                     RecursosComandosModulo6.MensajeExcepcionComandoAgregarActorError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                   exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
        }
    }
}

