using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Contratos.Modulo3
{
    public interface IContratoAgregarInvolucrado
    {
        DropDownList comboTipoEmpresa { get; set; }
        DropDownList comboCargo { get; set; }
        DropDownList comboPersonal { get; set; }
        string laTabla { get; set; }

       

    }
}
