using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoConsultarRequerimiento : Comando<Dominio.Entidad, Dominio.Entidad>
    {
        /// <summary>
        /// Comando para consultar un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento con su codigo
        /// para buscar la informacion en la base de datos</param>
        /// <returns>Requerimiento con los datos cargados</returns>
        public override Dominio.Entidad Ejecutar(Dominio.Entidad parametro)
        {
            throw new NotImplementedException();
        }
    }
}
