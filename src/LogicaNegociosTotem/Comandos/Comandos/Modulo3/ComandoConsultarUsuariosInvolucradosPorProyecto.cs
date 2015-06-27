using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
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
        /// Comando permite consultar los usuarios involucrados de un proyecto
        /// </summary>
        /// <param name="parametro">proyecto</param>
        /// <returns>lista de usuarios involucrados</returns>
        public override Dominio.Entidad Ejecutar(Dominio.Entidad parametro)
        {
            ListaInvolucradoUsuario lista = null;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                lista = (ListaInvolucradoUsuario) daoInvolucrado.ConsultarUsuariosInvolucradosPorProyecto(parametro);
            }catch(Exception ex){
                throw ex;
            }
            return lista;
        }
    }

}