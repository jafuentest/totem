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
       List<Actor> actores {get; set;}

       List<CasoDeUso> casosDeUso {get; set;}

       Label mensajeExito { get; set; }

       Label mensajeError { get; set; }

       HtmlButton boton { get; set; }

    }
}
