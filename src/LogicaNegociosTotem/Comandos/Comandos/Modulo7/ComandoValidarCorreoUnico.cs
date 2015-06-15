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
    class ComandoValidarCorreoUnico : Comando <String,bool>
    {
        /// <summary>
        /// Metodo para validar si el correo existe o no
        /// </summary>
        /// <param name="parametro">el correo que se desea registrar</param>
        /// <returns>Verdadero si es valido, falso si ya esta registrado en la BD</returns>
        public override bool Ejecutar(String parametro)
        {
         //   throw new NotImplementedException();
            FabricaAbstractaDAO correoValido = FabricaAbstractaDAO.ObtenerFabricaSqlServer();
            IDaoUsuario daoUsuario = correoValido.ObtenerDAOUsuario();
            bool valido = daoUsuario.ValidarCorreoUnico(parametro);
            return valido;
        }
    }
}
