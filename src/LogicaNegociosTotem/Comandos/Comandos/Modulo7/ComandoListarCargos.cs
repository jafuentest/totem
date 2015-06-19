using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Comandos;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para listar todos los cargos de la Base de Datos
    /// </summary>
    public class ComandoListarCargos: Comando<bool,List<String>>
    {
        /// <summary>
        /// Este metodo se utiliza para crear un nuevo usuario
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Lista de strings que tienen el nombre del cargo</returns>
        public override List<string> Ejecutar(bool parametro)
        {
 	        //throw new NotImplementedException();

            //Respuesta de la consulta;
            List<String> listaCargos = new List<String>();

            //Instanciamos la fabrica concreta SQLServer
            FabricaAbstractaDAO fabrica = FabricaAbstractaDAO.ObtenerFabricaSqlServer();

            //Obtenemos el DAO del usuario
            IDaoUsuario daoUsuario = fabrica.ObtenerDAOUsuario();

            //Consultamos en la BD
            listaCargos = daoUsuario.ListarCargos();

            //Retornamos la respuesta
            return listaCargos;
            
        }
        
    }
}
