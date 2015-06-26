using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando que se utiliza para eliminar un usuario de la base de datos
    /// </summary>
    public class ComandoEliminarUsuario: Comando<String,bool>
    {
        /// <summary>
        /// Este metodo se utiliza para eliminar los usuarios
        /// </summary>
        /// <param name="parametro">El username que se desea eliminar</param>
        /// <returns>Verdadero si se logro eliminar, falso sino se pudo eliminar</returns>
        public override bool Ejecutar(string parametro)
        {
            //Variable que retornara el exito o fallo del registro
            bool exito = false;

            //Instanciamos la fabrica
            FabricaDAOSqlServer fabrica = new FabricaDAOSqlServer();

            //Instanciamos el DAO
            IDaoUsuario usuario = fabrica.ObtenerDAOUsuario();

            //Obtenemos la respuesta del metodo
            exito = usuario.EliminarUsuario(parametro);

            //Retornamos la respuesta
            return exito;
        }
        

        

    }
}
