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
    /// Comando para consultar lista de contactos de un cliente juridico
    /// </summary>
    public class ComandoConsultarListaContactos : Comando<Entidad,List<Entidad>>
    {
        /// <summary>
        /// metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">cliente del que se desean saber los contactos</param>
        /// <returns>lista de contactos</returns>
        public override List<Entidad> Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.consultarListaDeContactosJuridico(parametro);
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
