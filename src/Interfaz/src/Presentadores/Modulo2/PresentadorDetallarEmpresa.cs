using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorDetallarEmpresa
    {
        private IContratoDetallarEmpresa vista;
        public PresentadorDetallarEmpresa(IContratoDetallarEmpresa lavista)
        {
            vista = lavista;
        }
    }
}
