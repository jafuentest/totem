using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo6
{
    public interface IContratoListarActores
    {
        string laTabla { get; set; }
        string actor_id { get; set; }
        string actor_nombre { get; set; }
        string actor_descripcion { get; set; }
    }
}
