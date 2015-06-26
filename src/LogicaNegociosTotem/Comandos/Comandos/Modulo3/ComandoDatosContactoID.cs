using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using Dominio.Entidades.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoDatosContactoID : Comando<int, Dominio.Entidad>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override Dominio.Entidad Ejecutar(int parametro)
        {
            Contacto contactoID;
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
                IDaoInvolucrados daoInvolucrados = laFabrica.ObtenerDaoInvolucrados();
                contactoID= (Contacto)daoInvolucrados.DatosContactoID(parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return contactoID;
        }
    }

}