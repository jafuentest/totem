using Contratos.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentadores.Modulo3
{
    public class PresentadorListarInvolucrado
    {
        private IContratoListarInvolucrado vista;
        public PresentadorListarInvolucrado(IContratoListarInvolucrado laVista)
        {
            vista = laVista;
        }
    }
    }
