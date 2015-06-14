using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo6; 

namespace Presentadores.Modulo6
{
    public class PresentadorAgregarActor
    {
        private IContratoAgregarActor vista;

        public PresentadorAgregarActor(IContratoAgregarActor vista) 
        {
            this.vista = vista; 
        }
    }
}
