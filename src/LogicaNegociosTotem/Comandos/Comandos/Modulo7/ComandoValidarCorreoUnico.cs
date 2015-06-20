using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.DAO.Modulo7;
using DAO.IntefazDAO.Modulo7;

namespace Comandos.Comandos.Modulo7
{
    /// <summary>
    /// Comando para validar si el correo ingresado existe o no
    /// </summary>
    public class ComandoValidarCorreoUnico : Comando <String,bool>
    {
        /// <summary>
        /// Metodo para validar si el correo existe o no
        /// </summary>
        /// <param name="parametro">el correo que se desea registrar</param>
        /// <returns>Verdadero si es valido, falso si ya esta registrado en la BD</returns>
        public override bool Ejecutar(String parametro)
        {
            //Instanciamos la fabrica concreta SQLServer
            FabricaAbstractaDAO correoValido = FabricaAbstractaDAO.ObtenerFabricaSqlServer();

            //Instanciamos el DAOUsuario
            IDaoUsuario daoUsuario = correoValido.ObtenerDAOUsuario();

            //Ejecutamos la instruccion pertinente y esperamos la respuesta
            bool valido = daoUsuario.ValidarCorreoUnico(parametro);

            //Retornamos la respuesta
            return valido;
        }
    }
}
