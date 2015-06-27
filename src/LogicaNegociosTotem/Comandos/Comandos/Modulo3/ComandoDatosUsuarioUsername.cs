using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
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
        /// Comando para obtener los datos de un usuario 
        /// </summary>
        /// <param name="parametro">el username del usuario</param>
        /// <returns>el usuario solicitado</returns>
        public override Dominio.Entidad Ejecutar(String parametro)
        {
            Usuario usuario;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                usuario = (Usuario) daoInvolucrado.DatosUsuarioUsername(parametro);
            }catch(Exception ex){
                throw ex;
            }
            return usuario;
        }
    }

}