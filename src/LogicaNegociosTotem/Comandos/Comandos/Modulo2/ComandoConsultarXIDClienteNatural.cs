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
    /// Comando para consultar datos de cliente natural por id
    /// </summary>
    public class ComandoConsultarXIDClienteNatural : Comando<Entidad, Entidad>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">entidad que contiene el id del que 
        /// se desean saber todos sus datos</param>
        /// <returns>Cliente natural con todos sus datos</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.ConsultarXId(parametro);
            }
            #region catches
            catch (ExceptionTotemConexionBD ex)
            {
                Logger.EscribirWarning(Convert.ToString(this.GetType()), ex.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
            catch (ClienteInexistenteException ex)
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
