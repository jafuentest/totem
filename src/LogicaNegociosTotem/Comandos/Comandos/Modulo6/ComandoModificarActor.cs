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
  public class ComandoModificarActor:Comando<Entidad,bool>
    {
        /// <summary>
        /// Comando que se ejecuta para modificar un actor de caso de uso
        /// a Base de Datos, recibe el actor como parámetro y retorna
        /// true si lo insertó y false en caso contrario.
        /// </summary>
        /// <param name="parametro">Entidad de tipo Actor a modificar</param>
        /// <returns>True si la modificación fue éxitosa, false en caso
        /// contrario</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                Datos.Fabrica.FabricaDAOSqlServer fabricaDaoSqlServer = new Datos.Fabrica.FabricaDAOSqlServer();

                Datos.DAO.Modulo6.DAOActor daoActor = (Datos.DAO.Modulo6.DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
                bool resultado = daoActor.Modificar(parametro);
                return resultado;
            }

            catch (ActorNoModificadoBDException e) 
            {
                ActorNoModificadoComandoException exComandoAgregarActor = new 
                    ActorNoModificadoComandoException(
                         RecursosComandosModulo6.CodigoExcepcionComandoBD,
                         RecursosComandosModulo6.MensajeExcepcionComandoBD,
                         e);

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
                ComandoException exComandoAgregarActor = new ComandoException(
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
