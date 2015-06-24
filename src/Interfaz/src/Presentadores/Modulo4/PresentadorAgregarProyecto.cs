using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo4;

namespace Presentadores.Modulo4
{
    class PresentadorAgregarProyecto
    {
	   private IContratoAgregarProyecto vista;

	   public PresentadorAgregarProyecto(IContratoAgregarProyecto laVista)
	   {
		  this.vista = laVista;
	   }
    }
}
