using Datos.Fabrica;
using Datos.IntefazDAO.Modulo2;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo2
{
    /// <summary>
    /// Comando para eliminar a un cliente juridico
    /// </summary>
    public class ComandoEliminarClienteJuridico : Comando<Entidad, bool>
    {
        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <param name="parametro">Cliente Juridico a eliminar</param>
        /// <returns>booleano que refleja el exito de la operacion</returns>
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoClienteJuridico daoClienteJur = laFabrica.ObtenerDaoClienteJuridico();

                return daoClienteJur.eliminarClienteJuridico(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
