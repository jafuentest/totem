using Datos.Fabrica;
using Datos.IntefazDAO.Modulo2;
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
    /// Comando para consultar lista de paises
    /// </summary>
    public class ComandoConsultarListaPaises : Comando<Boolean,List<String>>
    {
        /// <summary>
        /// metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">true</param>
        /// <returns>lista de paises</returns>
        public override List<string> Ejecutar(bool parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarPaises();
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
