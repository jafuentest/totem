using Dominio;
using Datos;
using Datos.IntefazDAO.Modulo2;
using Datos.Fabrica;
using Datos.DAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System.Data.SqlClient;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para agregar un contacto
    /// </summary>
    class ComandoAgregarContacto: Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">Contacto a agregar</param>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoContacto daoContacto = laFabrica.ObtenerDaoContacto();

                return daoContacto.Agregar(parametro);
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
