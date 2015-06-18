using Contratos.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentadores.Modulo3
{
    public class PresentadorAgregarInvolucrado
    {
        private IContratoAgregarInvolucrado vista;
        public PresentadorAgregarInvolucrado(IContratoAgregarInvolucrado laVista)
        {
            vista = laVista;
        }
    }

}
