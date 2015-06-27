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
    public class ComandoEliminarActor : Comando<int, bool>
    {
        /// <summary>
        /// Comando que elimina un Actor
        /// </summary>
        /// <param name="parametro">Id del Actor a eliminar</param>
        /// <returns>Retorna true si pudo eliminar</returns>
        public override bool Ejecutar(int parametro)
        {



            Datos.Fabrica.FabricaDAOSqlServer fabricaDaoSqlServer = new Datos.Fabrica.FabricaDAOSqlServer();
            Datos.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDaoSqlServer.ObtenerDAOActor();

            try
            {
                return daoActor.EliminarActor(parametro);
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
