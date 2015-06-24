using DAO.Fabrica;
using DAO.IntefazDAO.Modulo3;
using Dominio.Entidades.Modulo3;
using ExcepcionesTotem.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoAgregarUsuariosInvolucrados : Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            bool exito = false;
            try
            {
                FabricaAbstractaDAO laFabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
                IDaoInvolucrados daoInvolucrados = laFabrica.ObtenerDaoInvolucrados();
                exito = daoInvolucrados.AgregarUsuariosInvolucrados(parametro);
            }
            catch (ListaSinInvolucradosException)
            {
                exito = true;
            }
            catch (ListaSinProyectoException)
            {
                exito = false;
            }
            return exito;
        }
    }

}