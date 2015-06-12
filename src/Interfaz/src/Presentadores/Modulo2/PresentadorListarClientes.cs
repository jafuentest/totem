using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorListarClientes
    {
        private IContratoListarClientes vista;
        public PresentadorListarClientes(IContratoListarClientes laVista)
        {
            vista = laVista;
        }
    }
}
