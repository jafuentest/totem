using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo5
{
   public interface IContratoModificarRequerimiento
    {
        string idRequerimiento { get; set; }
        string funcional { get; set; }
        string requerimiento { get; set; }
        string prioridad { get; set; }
        string finalizado { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    
    }
}
