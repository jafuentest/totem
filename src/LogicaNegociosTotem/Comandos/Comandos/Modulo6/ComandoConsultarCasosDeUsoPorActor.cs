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
    public class ComandoConsultarCasosDeUsoPorActor : Comando<Entidad, List<Entidad>>
    {

        /// <summary>
        /// Comando que se ejecuta para cargar la lista de casos de uso
        /// en los que participa un actor dado
        /// </summary>
        /// <param name="parametro">Los datos del actor</param>
        /// <returns>Lista de Casos de Uso en los que participa un actor</returns>
        public override List<Entidad> Ejecutar(Entidad parametro)
        {
            try
            {
                DAO.Fabrica.FabricaAbstractaDAO fabricaDaoSqlServer = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();

                DAOCasoDeUso daoCasoDeUso = (DAOCasoDeUso)fabricaDaoSqlServer.ObtenerDAOCasoDeUso();
                List<Entidad> resultado = daoCasoDeUso.ConsultarCasosDeUsoPorActor(parametro);
                return resultado;
            }

            catch (BDDAOException ex)
            {

                ComandoBDException exComandoCasosDeUsoXActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoBD,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarCasosDeUsoPorActor,
                    exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;

            }
            catch (TipoDeDatoErroneoDAOException ex)
            {
                TipoDeDatoErroneoComandoException exComandoCasosDeUsoXActor = new TipoDeDatoErroneoComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoTipoDeDatoErroneo,
                     RecursosComandosModulo6.MensajeTipoDeDatoErroneoComandoExcepcion,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarCasosDeUsoPorActor,
                    exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;
            }

            catch (ObjetoNuloDAOException ex)
            {
                ComandoNullException exComandoCasosDeUsoXActor = new ComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarCasosDeUsoPorActor,
                  exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoCasosDeUsoXActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarCasosDeUsoPorActor,
                   exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;

            }


        }
    }
}
