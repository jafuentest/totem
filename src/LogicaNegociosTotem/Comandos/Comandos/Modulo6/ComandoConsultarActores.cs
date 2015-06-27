using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;
using Datos.DAO.Modulo6;
using Datos.Fabrica;
using Datos.IntefazDAO.Modulo6;

namespace Comandos.Comandos.Modulo6
{
    public class ComandoConsultarActores : Comando<string, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(string parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoActor daoActor = laFabrica.ObtenerDAOActor();

                return daoActor.ConsultarListarActores(parametro);



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
