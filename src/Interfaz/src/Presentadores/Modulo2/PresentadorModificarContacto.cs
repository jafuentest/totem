using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorModificarContacto
    {
        private IContratoModificarContacto vista;
        public PresentadorModificarContacto(IContratoModificarContacto laVista)
        {
            vista = laVista;
        }
    }
}
