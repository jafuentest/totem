using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorModificarCliente
    {
        private IContratoModificarCliente vista;
        public PresentadorModificarCliente(IContratoModificarCliente laVista)
        {
            vista = laVista;
        }
    }
}
