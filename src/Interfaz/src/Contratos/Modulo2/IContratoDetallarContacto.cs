using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoDetallarContacto
    {
        string contactoNombre { get; set; }

        string apellidoContacto { get; set; }

        string cedulaContacto { get; set; }

        string cargoContacto { get; set; }

        string telefono { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }

    }
}
