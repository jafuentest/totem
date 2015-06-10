using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo_5;
using System.Web.UI;

namespace Presentadores.Modulo_5
{
    public class PresentadorAgregarRequerimiento
    {
        private IContratoAgregarRequerimiento vista;

        public PresentadorAgregarRequerimiento(IContratoAgregarRequerimiento vista)
        {
            this.vista = vista;
        }

        public void MostrarMenuLateral()
        {
            
        }

    }
}
