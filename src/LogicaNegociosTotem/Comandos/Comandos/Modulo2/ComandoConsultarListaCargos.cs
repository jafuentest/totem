using Dominio;
using Datos;
using Datos.IntefazDAO.Modulo2;
using Datos.Fabrica;
using Datos.DAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ExcepcionesTotem;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para consultar la lista de cargos
    /// </summary>
    public class ComandoConsultarListaCargos : Comando<bool, List<String>>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">true</param>
        /// <returns>lista de cargos</returns>
        public override List<string> Ejecutar(bool parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarListaCargos();
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
