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
                DAO.Fabrica.FabricaDAOSqlServer fabricaDaoSqlServer = new DAO.Fabrica.FabricaDAOSqlServer(); 

                DAO.DAO.Modulo6.DAOActor daoActor = (DAO.DAO.Modulo6.DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
                bool resultado = daoActor.VerificarExistenciaActor(parametro);
                return resultado;
            }

            catch (BDDAOException ex)
            {

                ComandoBDException exComandoAgregarActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
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
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                  exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoAgregarActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoVerificarExistenciaActor,
                   exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
        }
    }
}

