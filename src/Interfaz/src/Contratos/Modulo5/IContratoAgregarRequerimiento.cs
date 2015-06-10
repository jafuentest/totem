using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo_5
{
    public interface IContratoAgregarRequerimiento
    {
        string idRequerimiento { get; set; }
        bool funcional { get; }
        string requerimiento { get; }
        string prioridad { get; }
        bool finalizado { get; }
       
    }
}
