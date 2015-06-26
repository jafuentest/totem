using DAO.Fabrica;
using DAO.IntefazDAO.Modulo2;
using Dominio;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    public class ComandoModificarContacto : Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.modificarContacto(parametro);

            }
            #region Catches
            catch (CIContactoExistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            #endregion
        }
    }
}
