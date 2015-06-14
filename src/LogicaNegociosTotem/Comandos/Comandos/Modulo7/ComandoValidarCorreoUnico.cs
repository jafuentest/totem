using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <param name="parametro"></param>
        /// <returns></returns>
        public override bool Ejecutar(string parametro)
        {
            throw new NotImplementedException();
        }
    }
}
