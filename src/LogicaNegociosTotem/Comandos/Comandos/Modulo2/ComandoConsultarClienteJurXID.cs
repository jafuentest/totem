using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para consultar los datos de un cliente juridico
    /// </summary>
    public class ComandoConsultarClienteJurXID : Comando<Entidad, Entidad>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">entidad que posee el id del que se desean conocer sus datos</param>
        /// <returns>el cliente juridico con todos sus datos</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.ConsultarXId(parametro);
            }
            #region Catches
            catch (ClienteInexistenteException ex)
            {
                Logger.EscribirWarning(Convert.ToString(this.GetType()), ex.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
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
