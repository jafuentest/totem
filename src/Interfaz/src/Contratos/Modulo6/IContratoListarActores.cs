using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Contratos.Modulo6
{
    public interface IContratoListarActores
    {
        Label mensajeExito { get; set; }
        Label mensajeError { get; set; }
        Repeater RActor { get; set; }



    }
}
