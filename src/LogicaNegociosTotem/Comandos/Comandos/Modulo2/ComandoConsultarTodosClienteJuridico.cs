using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using ExcepcionesTotem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarTodosClienteJuridico : Comando<bool, List<Entidad>>
    {
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.ConsultarTodos();
            }
            #region Catches
            catch (ExceptionTotemConexionBD ex)
            {
                Logger.EscribirWarning(Convert.ToString(this.GetType()), ex.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
            catch (ExceptionTotem ex)
            {
                Logger.EscribirWarning(Convert.ToString(this.GetType()), ex.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
            #endregion
        }
    }
}
