using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorDetallarCliente
    {
        private IContratoDetallarCliente vista;
        public PresentadorDetallarCliente(IContratoDetallarCliente laVista)
        {
            vista = laVista;
        }
    }
}
