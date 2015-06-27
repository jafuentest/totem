using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;
using Datos.DAO.Modulo6;

namespace Comandos.Comandos.Modulo6
{
   public class ComandoConsultarRequerimientosXCasoDeUso: Comando<int,List<Entidad>>
    {

        /// <summary>
        /// Comando que se ejecuta para cargar el listado de requerimientos asociados a 
        /// un caso de uso
        /// </summary>
        /// <param name="parametro">Id del Caso de Uso</param>
        /// <returns>Lista de Requerimientos asociados al caso de uso</returns>
        public override List<Entidad> Ejecutar(int parametro)
        {
            try
            {
                Datos.Fabrica.FabricaDAOSqlServer fabricaDaoSqlServer = new Datos.Fabrica.FabricaDAOSqlServer(); 

                DAOCasoDeUso daoCasoDeUso = (DAOCasoDeUso)fabricaDaoSqlServer.ObtenerDAOCasoDeUso();
                List<Entidad> resultado = daoCasoDeUso.ConsultarRequerimientosXCasoDeUso(parametro);
                return resultado;
            }

            catch (BDDAOException ex)
            {

                ComandoBDException exComandoCasosDeUsoXActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoBD,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarRequerimientosPorCasoDeUso,
                    exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;

            }
            catch (TipoDeDatoErroneoDAOException ex)
            {
                TipoDeDatoErroneoComandoException exComandoCasosDeUsoXActor = new TipoDeDatoErroneoComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoTipoDeDatoErroneo,
                     RecursosComandosModulo6.MensajeTipoDeDatoErroneoComandoExcepcion,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarRequerimientosPorCasoDeUso,
                    exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;
            }

            catch (ObjetoNuloDAOException ex)
            {
                ComandoNullException exComandoCasosDeUsoXActor = new ComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarRequerimientosPorCasoDeUso,
                  exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoCasosDeUsoXActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarRequerimientosPorCasoDeUso,
                   exComandoCasosDeUsoXActor);

                throw exComandoCasosDeUsoXActor;

            }


        }
    }
}
