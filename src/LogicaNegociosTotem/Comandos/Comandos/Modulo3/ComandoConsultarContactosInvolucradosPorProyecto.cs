using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoConsultarContactosInvolucradosPorProyecto : Comando<Dominio.Entidad, List<Dominio.Entidad>>
    {
        /// <summary>
        /// Comando que elimina un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a eliminar</param>
        /// <returns>true si se puede eliminar</returns>
        public override List<Dominio.Entidad> Ejecutar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }

}
