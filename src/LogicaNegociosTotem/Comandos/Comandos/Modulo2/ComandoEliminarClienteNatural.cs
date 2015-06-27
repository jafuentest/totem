using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos.Fabrica;
using Datos.DAO.Modulo2;
using Datos.IntefazDAO.Modulo2;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para eliminar a un cliente natural
    /// </summary>
    public class ComandoEliminarClienteNatural : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">Cliente natural que se desea eliminar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteNatural daoClienteNat = laFabrica.ObtenerDaoClienteNatural();

                return daoClienteNat.eliminarClienteNatural(parametro);

            }
            catch (Exception Exception)
            {
                throw new Exception();
            }

        }
    }
}
