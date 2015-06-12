using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorListarEmpresas
    {
        private IContratoListarEmpresas vista;
        public PresentadorListarEmpresas(IContratoListarEmpresas laVista)
        {
            vista = laVista;
        }
    }
}
