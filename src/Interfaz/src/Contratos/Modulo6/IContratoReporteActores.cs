using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo5;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;  

namespace Contratos.Modulo6
{
   public interface IContratoReporteActores
    {
       string tabla { get; set;  }       

       Label mensajeExito { get; set; }

       Label mensajeError { get; set; }

       DropDownList comboActores { get; set; }

       HtmlButton boton { get; set; }

    }
}
