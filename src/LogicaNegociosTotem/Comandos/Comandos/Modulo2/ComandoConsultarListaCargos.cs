using Dominio;
using DAO;
using DAO.IntefazDAO.Modulo2;
using DAO.Fabrica;
using DAO.DAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ExcepcionesTotem;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoConsultarListaCargos : Comando<bool, List<String>>
    {
        public override List<string> Ejecutar(bool parametro)
        {
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
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
