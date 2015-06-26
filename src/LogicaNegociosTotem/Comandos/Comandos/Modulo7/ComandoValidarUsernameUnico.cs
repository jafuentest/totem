using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.DAO.Modulo7;
using DAO.Fabrica;
using DAO.IntefazDAO.Modulo7;



namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando para validar si el username ingresado existe o no
    /// </summary>
    public class ComandoValidarUsernameUnico : Comando <String,bool>
    {
        /// <summary>
        /// Metodo para validar si el username existe o no
        /// </summary>
        /// <param name="parametro">el username del usuario nuevo</param>
        /// <returns>Verdadero si es valido, falso sino es valido</returns>
        public override bool Ejecutar(String parametro)
        {
            //Instanciamos la fabrica
            FabricaDAOSqlServer usernameUnico = new FabricaDAOSqlServer();

            //Instanciamos el DAO
            IDaoUsuario daoUsuario = usernameUnico.ObtenerDAOUsuario();

            //Ejecutamos la instruccion y obtenemos la respuesta pertinente
            bool valido = daoUsuario.ValidarUsernameUnico(parametro);
            /*if (valido == false)
                throw new UserNameRepetidoException();*/
            // usernameUnico.ObtenerDAOUsuario();
            //Boolean valido = conexion.usernameUnico(userName);

            //Retornamos la respuesta
            return valido;
        }
    }
}
