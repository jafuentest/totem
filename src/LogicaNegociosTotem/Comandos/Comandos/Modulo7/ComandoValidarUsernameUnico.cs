using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <param name="parametro"></param>
        /// <returns></returns>
        public override bool Ejecutar(string parametro)
        {
            throw new NotImplementedException();
        }
    }
}
