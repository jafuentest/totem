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
    class ComandoValidarUsernameUnico : Comando <String,bool>
    {
        /// <summary>
        /// Metodo para validar si el username existe o no
        /// </summary>
        /// <param name="parametro">el username del usuario nuevo</param>
        /// <returns>Verdadero si es valido, falso sino es valido</returns>
        public override bool Ejecutar(String parametro)
        {
            Console.WriteLine("ENTRE EN EL USERNAME");
            //throw new NotImplementedException();
            FabricaAbstractaDAO usernameUnico = FabricaDAOSqlServer.ObtenerFabricaSqlServer();
           // IDaoUsuario daoUsuario = usernameUnico.ObtenerDAOUsuario();
            IDaoUsuario daoUsuario = usernameUnico.ObtenerDAOUsuario();
            bool valido = daoUsuario.ValidarUsernameUnico(parametro);
            /*if (valido == false)
                throw new UserNameRepetidoException();*/
            // usernameUnico.ObtenerDAOUsuario();
            //Boolean valido = conexion.usernameUnico(userName);
            return valido;
        }
    }
}
