using Datos.Fabrica;
using Datos.IntefazDAO.Modulo2;
using Dominio;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para modificar un contacto
    /// </summary>
    public class ComandoModificarContacto : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">Contacto a modificar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoContacto daoContacto = laFabrica.ObtenerDaoContacto();

                return daoContacto.Modificar(parametro);

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
