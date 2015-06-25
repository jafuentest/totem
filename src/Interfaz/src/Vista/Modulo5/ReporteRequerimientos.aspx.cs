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
            HttpContext.Current.Session["Credenciales"] = new object();

            presentador.ListarRequerimientosPorProyecto();
           
        
        }

        protected void GenerarDoc_Click(object sender, EventArgs e)
        {
            this.presentador.GenerarDoc("TOT");
            
        }

        Repeater Contratos.Modulo5.IContratoReporteRequerimientos.RepeaterRequerimiento
        {
            get
            {
                return this.RRequerimientos;
            }
            set
            {
                this.RRequerimientos = value;
            }
        }


        public string alertaClase
        {
            set { alert.Attributes["class"] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes["role"] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
    }
}