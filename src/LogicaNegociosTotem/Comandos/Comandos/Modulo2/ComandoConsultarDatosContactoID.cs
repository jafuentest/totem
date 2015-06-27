using Datos.Fabrica;
using Datos.IntefazDAO.Modulo2;
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
    /// Comando para consultar los datos de un contacto dado su id
    /// </summary>
    public class ComandoConsultarDatosContactoID : Comando<Entidad, Entidad>
    {
        /// <summary>
        /// metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">entidad que contiene el id del 
        /// que se desean saber todos sus datos</param>
        /// <returns>el contacto con todos sus datos</returns>
        public override Entidad Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoContacto daoContacto = laFabrica.ObtenerDaoContacto();

                return daoContacto.ConsultarXId(parametro);
            }
            #region Catches
            catch (ContactoInexistenteException ex)
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
