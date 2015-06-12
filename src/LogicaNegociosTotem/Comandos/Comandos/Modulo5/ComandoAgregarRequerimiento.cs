using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoAgregarRequerimiento: Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando para ejecutar un requerimiento, recibe un requerimiento
        /// de entrada y retorna el requerimiento de salida
        /// </summary>
        /// <param name="parametro">Requerimiento a Agregar</param>
        /// <returns>true si se pudo realizar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}
