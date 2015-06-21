using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comandos;
using Dominio;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para listar todos los usuarios segun un cargo en especifico
    /// </summary>
    public class ComandoListarUsuariosPorCargo: Comando<String,List<Entidad>>
    {
        /// <summary>
        /// Metodo sobreescrito que ejecuta la accion del comando
        /// </summary>
        /// <param name="parametro">El cargo que por el cual se desean saber los usuarios</param>
        /// <returns>Todos los usuarios con ese cargo</returns>
        public override List<Entidad> Ejecutar(string parametro)
        {
            
            //Lista que retornara los Usuarios
            List<Entidad> listaUsuarios;

            //Instanciamos la fabrica
            FabricaAbstractaDAO fabrica = FabricaDAOSqlServer.ObtenerFabricaSqlServer();

            //Instanciamos el DAO
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            //Obtenemos la lista con los suarios
            listaUsuarios = daoUsuario.ListarUsuariosPorCargo(parametro);

            //Retornamos la Respuesta
            return listaUsuarios;
        }
    }
}
