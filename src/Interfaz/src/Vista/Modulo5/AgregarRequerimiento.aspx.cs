using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo5
{
    public partial class AgregarRequerimiento : System.Web.UI.Page, 
        Contratos.Modulo5.IContratoAgregarRequerimiento
    {
        private Presentadores.Modulo5.PresentadorAgregarRequerimiento presentador;

        public AgregarRequerimiento()
        {
            presentador = new Presentadores.Modulo5.PresentadorAgregarRequerimiento(this);
        }

        #region Contrato
        string Contratos.Modulo5.IContratoAgregarRequerimiento.idRequerimiento
        {
            get { return inputIdRequerimiento.Value; }
            set { inputIdRequerimiento.Value = value; }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.funcional
        {
            get
            {
                if (inputFuncional.Checked)
                    return "Funcional";
                else
                    return "No Funcional";
            }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.requerimiento
        {
            get { return inputRequerimiento.InnerText; }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.prioridad
        {
            get
            {
                if (inputPrioridadAlta.Checked)
                {
                    return "alta";
                }
                if (inputPrioridadMedia.Checked)
                {
                    return "media";
                }
               return "baja";
            }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.finalizado
        {
            get { return "No Finalizado"; }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.alertaClase
        {
            set { alert.Attributes["class"] = value; }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.alertaRol
        {
            set { alert.Attributes["role"] = value; }
        }

        string Contratos.Modulo5.IContratoAgregarRequerimiento.alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.idModulo = "5";
                this.Master.presentador.CargarMenuLateral();
                presentador.ObtenerUsuarioLogeado();
            }

        }

        protected void AgregarRequerimiento_Click(object sender, EventArgs e)
        {
            presentador.AgregarRequerimiento();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
        
    }
}