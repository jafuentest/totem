using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.DAO.Modulo2;
using DAO.IntefazDAO.Modulo2;
using System.Data.SqlClient;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// comando para agregar un cliente natural
    /// </summary>
    public class ComandoAgregarClienteNatural : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">Cliente a agregar</param>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try 
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.Agregar(parametro);

            }
            #region catches
            catch (ExceptionTotemConexionBD ex)
            {
                Logger.EscribirWarning(Convert.ToString(this.GetType()), ex.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
            catch (CIClienteNatExistenteException ex)
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
