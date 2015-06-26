using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Contratos
{
    public interface IContratoMasterPage
    {
        bool MenuLateral { set; }

        bool ulNav { set; }

        String opcionesDeMenu { get; set; }

        String idModulo { get; set; }

        String selectedProject { set; }

        String perfilProyecto { set; }

	   String proyectoActual { get; set; }
    }
}
