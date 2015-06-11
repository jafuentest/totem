using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorAgregarEmpresa
    {
        private IContratoAgregarEmpresa vista;

        public PresentadorAgregarEmpresa(IContratoAgregarEmpresa laVista)
        {
            this.vista = laVista;
        }
    }
}
