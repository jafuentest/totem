using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoEliminarUsuariosDeIvolucradosEnProyecto : Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que elimina un usuario involucrado en un proyecto
        /// </summary>
        /// <param name="parametro1">usuario a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro1)
        {
            //recibe:Ejecutar(Dominio.Entidad parametro1,Dominio.Entidad parametro2) 
            /*
            try{
                FabricaAbstractaDAO laFabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
                IDaoInvolucrados daoInvolucrado = laFabrica.ObtenerDaoInvolucrados();
                return daoInvolucrado.EliminarUsuariosDeIvolucradosEnProyecto(parametro1, parametro2);
            }catch(Exception ex){
                throw ex;
            }
            */
            throw new NotImplementedException();
        }
    }

}