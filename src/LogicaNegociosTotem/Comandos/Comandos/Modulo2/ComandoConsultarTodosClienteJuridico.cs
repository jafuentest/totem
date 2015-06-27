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
    /// <summary>
    /// Comando para consultar la lista de clientes juridicos
    /// </summary>
    public class ComandoConsultarTodosClienteJuridico : Comando<bool, List<Entidad>>
    {
        /// <summary>
        /// metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">true</param>
        /// <returns>lista de clientes juridicos</returns>
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
