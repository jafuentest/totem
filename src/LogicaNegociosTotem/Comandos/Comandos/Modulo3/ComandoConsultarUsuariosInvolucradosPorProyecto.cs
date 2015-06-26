using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoConsultarUsuariosInvolucradosPorProyecto : Comando<Dominio.Entidad, Dominio.Entidad>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override Dominio.Entidad Ejecutar(Dominio.Entidad parametro)
        {
            ListaInvolucradoUsuario lista = null;
            try
            {
                DAO.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                DAO.Fabrica.FabricaDAOSqlServer fabricaDAO = new DAO.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                lista = (ListaInvolucradoUsuario) daoInvolucrado.ConsultarUsuariosInvolucradosPorProyecto(parametro);
            }catch(Exception ex){
                throw ex;
            }
            return lista;
        }
    }

}