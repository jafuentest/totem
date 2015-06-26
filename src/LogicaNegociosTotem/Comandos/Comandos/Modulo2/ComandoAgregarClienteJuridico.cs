using Dominio;
using DAO;
using DAO.IntefazDAO.Modulo2;
using DAO.Fabrica;
using DAO.DAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System.Data.SqlClient;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoAgregarClienteJuridico : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.Agregar(parametro);
            }
            #region Catches
            catch (ExceptionTotemConexionBD ex)
            {
                Logger.EscribirWarning(Convert.ToString(this.GetType()), ex.Message,
                    System.Reflection.MethodBase.GetCurrentMethod().Name);

                throw ex;
            }
            catch (RifClienteJuridicoExistenteException ex)
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
