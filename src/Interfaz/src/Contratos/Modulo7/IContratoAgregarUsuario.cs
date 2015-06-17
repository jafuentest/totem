using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo7
{
    public interface IContratoAgregarUsuario
    {
        string username { get; set; }
        string clave { get; set; }
        string nombreUsuario { get; set; }
        string apellidoUsuario { get; set; }
        string rolUsuario { get; set; }
        string correoUsuario { get; set; }
        string preguntaUsuario { get; set; }
        string respuestaUsuario { get; set; }
        string cargoUsuario { get; set; }
    }
}
