using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Fabrica;
using Datos.DAO.Modulo2;
using Datos.IntefazDAO.Modulo2;
using System.Data.SqlClient;
using ExcepcionesTotem;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para consultar la lista de clientes naturales
    /// </summary>
    public class ComandoConsultarTodosClienteNatural : Comando<bool, List<Entidad>>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">true</param>
        /// <returns>lista de clientes naturales</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.ConsultarTodos();
            }
            #region catches
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
