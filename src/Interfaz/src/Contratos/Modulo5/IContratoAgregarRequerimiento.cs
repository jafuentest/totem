using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo5
{
    public interface IContratoAgregarRequerimiento
    {
        string idRequerimiento { get; set; }
        string funcional { get; }
        string requerimiento { get; }
        string prioridad { get; }
        string finalizado { get; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
