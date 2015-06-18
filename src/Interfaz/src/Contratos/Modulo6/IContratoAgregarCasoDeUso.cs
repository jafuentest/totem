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
    public interface IContratoAgregarCasoDeUso
    {
        string codigoCasoDeUso { get; set; }

        string tituloCasoDeUso { get; set; }

        string precondicion { get; set;  }

        string condicionFinalExito { get; set; }

        string condicionFinalFallo { get; set; }

        List<Actor> listaActoresAgregados { get; set; }

        List<Actor> listaActoresPorAgregar { get; set; }

        List<Requerimiento> listaRequerimientosAgregados { get; set; }

        List<Requerimiento> listaRequerimientosPorAgregar { get; set; }

        string disparador {get; set;}

        List<Paso> escenarioExito {get; set;}

        List<Extension> escenarioFallo {get; set;}

        Label mensajeExito { get; set; }

        Label mensajeError { get; set; }

        HtmlButton boton { get; set; }
                
    }
}
