using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;  

namespace Contratos.Modulo6
{
   public interface IContratoAgregarActor
    {
       string nombreActor { get; set; }
       string descActor { get; set;  }

       Label  mensajeExito { get; set; }

       Label mensajeError { get; set; }

       HtmlButton botonAgregar { get; set; }
    }
}
