using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorAgregarCliente
    {
        private IContratoAgregarCliente vista;

        public PresentadorAgregarCliente(IContratoAgregarCliente laVista)
        {
            vista = laVista;
        }
    }
}
