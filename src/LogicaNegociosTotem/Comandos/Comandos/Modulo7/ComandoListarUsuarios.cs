using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using Dominio;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para Listar todos los usuarios de Base de Datos
    /// </summary>
    public class ComandoListarUsuarios : Comando<bool,List<Entidad>>
    {
        /// <summary>
        /// Este metodo se utiliza para Listar todos los usuarios
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Lista que contiene todos los usuarios de la Base de Datos</returns>
        public override List<Entidad> Ejecutar(bool parametro)
        {
 	        //throw new NotImplementedException();
            //Lista que contendra todos los usuarios
            List<Entidad> listaUsuarios;

            //Instanciamos la fabrica
            FabricaAbstractaDAO fabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();

            //Instanciamos el DAOUsuario
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            //Obtenemos la lista con los usuarios
            listaUsuarios = daoUsuario.ListarUsuarios();

            //Retornamos la respuesta
            return listaUsuarios;
            

        }
    }
}
