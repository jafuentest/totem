using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para listar todos los cargos de la Base de Datos si al menos un usuario lo tiene
    /// </summary>
    public class ComandoLeerCargosUsuarios:Comando<bool, List<String>>
    {
        /// <summary>
        /// Metodo que ejecuta la accion del comando
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Lista de strings que tienen el nombre del cargo</returns>
        public override List<string> Ejecutar(bool parametro)
        {
            //Respuesta de la consulta;
            List<String> listaCargos = new List<String>();

            //Instanciamos la fabrica concreta SQLServer
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();

            //Obtenemos el DAO del usuario
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            //Consultamos en la BD
            listaCargos = daoUsuario.LeerCargosUsuarios();

            //Retornamos la respuesta
            return listaCargos;
        }
    }
}
