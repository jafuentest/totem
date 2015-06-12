using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorDetallarContacto
    {
        private IContratoDetallarContacto vista;
        public PresentadorDetallarContacto(IContratoDetallarContacto laVista)
        {
            vista = laVista;
        }
    }
}
