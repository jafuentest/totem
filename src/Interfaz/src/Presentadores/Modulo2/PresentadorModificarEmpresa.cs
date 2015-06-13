using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;

namespace Presentadores.Modulo2
{
    public class PresentadorModificarEmpresa
    {
        private IContratoModificarEmpresa vista;
        public PresentadorModificarEmpresa(IContratoModificarEmpresa laVista)
        {
            vista = laVista;
        }
    }
}
