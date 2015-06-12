using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoConsultarRequerimientosProyecto : Comando<String,
        List<Dominio.Entidad>>
    {
        /// <summary>
        /// Comando que consulta los requerimientos de un proyecto
        /// </summary>
        /// <param name="parametro">id del proyecto</param>
        /// <returns>Lista de requerimientos asociadas al proyecto</returns>
        public override List<Dominio.Entidad> Ejecutar(string parametro)
        {
            throw new NotImplementedException();
        }
    }
}
