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
    class ComandoConsultarActores:Comando<bool, List<Entidad> >
    {
         public override List<Entidad> Ejecutar(Entidad parametro)
        {
          try
            {
                 FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
                IDaoActor daoActor= laFabrica.ObtenerDAOActor();

                return daoActor.consultarListaDeActores(parametro);



            }
          catch (ConsultarTodosActoresBDDAOException ex)
          {

              ConsultarTodosActoresBDDAOException exComandoConsultarActores = new ConsultarTodosActoresBDDAOException(
                   RecursosComandosModulo6.CodigoExcepcionComandoConsultarActoresBD,
                   RecursosComandosModulo6.MensajeExcepcionComandoConsultarActoresBD,
                   ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActores,
                  exComandoConsultarActores);

              throw exComandoConsultarActores;

          }


          catch (ConsultarTodosActoresNuloDAOException ex)
          {
              ConsultarActoresComandoNullException exComandoConsultarActores = new ConsultarActoresComandoNullException(
                  RecursosComandosModulo6.CodigoExcepcionComandoConsultarActoresNulo,
                  RecursosComandosModulo6.MensajeExcepcionComandoConsultarActoresNulo,
                  ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActores,
                exComandoConsultarActores);

              throw exComandoConsultarActores;

          }

          catch (ConsultarTodosActoresDAOException ex)
          {
              ConsultarActoresComandoException exComandoConsultarActores = new ConsultarActoresComandoException(
                   RecursosComandosModulo6.MensajeExcepcionComandoConsultarActoresError,
                   RecursosComandosModulo6.MensajeExcepcionComandoConsultarActoresError,
                   ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActores,
                 exComandoConsultarActores);

              throw exComandoConsultarActores;

          }

        }

    }
}
