using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo4;

namespace Presentadores.Modulo4
{
    public class PresentadorListarProyectos
    {
	   private IContratoListarProyectos vista;

	   public PresentadorListarProyectos(IContratoListarProyectos laVista)
	   {
		  this.vista = laVista;
	   }
    }
}
