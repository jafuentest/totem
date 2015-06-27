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
using ExcepcionesTotem.Modulo2;
namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para modificar un cliente natural
    /// </summary>
    public class ComandoModificarClienteNatural : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">Cliente natural a modificar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.Modificar(parametro);
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
