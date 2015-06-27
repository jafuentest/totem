using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using ExcepcionesTotem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para consultar los estados de un pais
    /// </summary>
    public class ComandoConsultarEstadosPorPais : Comando<String,List<String>>
    {
        /// <summary>
        /// metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">pais del que se desean saber los estaods</param>
        /// <returns>lista de estados</returns>
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarEstadosPorPais(parametro);
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
