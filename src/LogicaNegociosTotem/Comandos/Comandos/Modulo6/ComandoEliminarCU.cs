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
    public class ComandoEliminarCU : Comando<int, bool>
    {
        /// <summary>
        /// Comando que elimina un Caso de Uso
        /// </summary>
        /// <param name="parametro">Id del Caso de uso a eliminar</param>
        /// <returns>true si pudo eliminar</returns>
        public override bool Ejecutar(int parametro)
        {



            DAO.Fabrica.FabricaAbstractaDAO fabricaDAO = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoCasoDeUso daoCasoUso = fabricaDAO.ObtenerDAOCasoDeUso();

            try
            {
                return daoCasoUso.EliminarCasoDeUso(parametro);
            }
            catch (BDDAOException ex)
            {

                ComandoBDException exComandoAgregarActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoBD,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoEliminarCU,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
            catch (TipoDeDatoErroneoDAOException ex)
            {
                TipoDeDatoErroneoComandoException exComandoAgregarActor = new TipoDeDatoErroneoComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoTipoDeDatoErroneo,
                     RecursosComandosModulo6.MensajeTipoDeDatoErroneoComandoExcepcion,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoEliminarCU,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;
            }

            catch (ObjetoNuloDAOException ex)
            {
                ComandoNullException exComandoAgregarActor = new ComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoEliminarCU,
                  exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoAgregarActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoEliminarCU,
                   exComandoAgregarActor);

                throw exComandoAgregarActor;

            }


        }
    }
}
