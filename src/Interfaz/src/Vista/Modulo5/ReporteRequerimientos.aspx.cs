using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo5
{
    public partial class ReporteRequerimientos : System.Web.UI.Page,Contratos.Modulo5.IContratoReporteRequerimientos
    {
        private Presentadores.Modulo5.PresentadorReporteRequerimientos presentador;

        public ReporteRequerimientos()
        {
            this.presentador = new Presentadores.Modulo5.PresentadorReporteRequerimientos(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "5";
            this.Master.presentador.CargarMenuLateral();      
        }
    }
}