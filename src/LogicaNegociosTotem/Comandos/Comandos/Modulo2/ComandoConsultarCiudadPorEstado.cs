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
    /// Comando para consultar todas las ciudades que posee un estado
    /// </summary>
    public class ComandoConsultarCiudadPorEstado : Comando<String,List<String>>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">estado del que se desean conocer sus ciudades</param>
        /// <returns>lista de ciudades</returns>
        public override List<string> Ejecutar(string parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarCiudadesPorEstado(parametro);
            }
            #region Catches
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
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
