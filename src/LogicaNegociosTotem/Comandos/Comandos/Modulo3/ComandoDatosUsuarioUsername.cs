using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using Dominio.Entidades.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoDatosUsuarioUsername : Comando<String, Dominio.Entidad>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override Dominio.Entidad Ejecutar(String parametro)
        {
            Usuario usuario;
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
                IDaoInvolucrados daoInvolucrados = laFabrica.ObtenerDaoInvolucrados();
                usuario = (Usuario) daoInvolucrados.DatosUsuarioUsername(parametro);
            }catch(Exception ex){
                throw ex;
            }
            return usuario;
        }
    }

}