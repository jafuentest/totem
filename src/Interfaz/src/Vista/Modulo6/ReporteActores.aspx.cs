using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Contratos.Modulo6;
using Presentadores.Modulo6;   

namespace Vista.Modulo6
{
    public partial class ReporteActores : System.Web.UI.Page, Contratos.Modulo6.IContratoReporteActores
    {
        private PresentadorReporteActores presentador;

        public ReporteActores() 
        {
            presentador = new PresentadorReporteActores(this);         
        }

        #region Contratos

        string Contratos.Modulo6.IContratoReporteActores.tabla 
        {
            get { return tabla.Text;}
            set { tabla.Text = value;}
        }

        DropDownList Contratos.Modulo6.IContratoReporteActores.comboActores 
        {
            get { return comboActores; }
            set { comboActores = value; }
        }

        HtmlButton Contratos.Modulo6.IContratoReporteActores.boton
        {
            get { return boton; }
            set { boton = value; }
        }

        Label Contratos.Modulo6.IContratoReporteActores.mensajeExito
        {
            get { return labelMensajeExito; }
            set { labelMensajeExito = value; }
        }

        Label Contratos.Modulo6.IContratoReporteActores.mensajeError
        {
            get { return labelMensajeError; }
            set { labelMensajeError = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "6";
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                this.presentador.CargarActores(); 
            }
        }
    }
}