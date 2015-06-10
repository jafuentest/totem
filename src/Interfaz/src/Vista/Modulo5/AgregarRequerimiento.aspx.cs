using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo5
{
    public partial class AgregarRequerimiento : System.Web.UI.Page, 
        Contratos.Modulo_5.IContratoAgregarRequerimiento
{
        private Presentadores.Modulo_5.PresentadorAgregarRequerimiento presentador;

        public AgregarRequerimiento()
        {
            presentador = new Presentadores.Modulo_5.PresentadorAgregarRequerimiento(this);
        }

        #region Contrato
        string Contratos.Modulo_5.IContratoAgregarRequerimiento.idRequerimiento
        {
            get { return inputIdRequerimiento.Value; }
            set { inputIdRequerimiento.Value = value; }
        }

        bool Contratos.Modulo_5.IContratoAgregarRequerimiento.funcional
        {
            get
            {
                if (inputFuncional.Checked)
                    return true;
                else
                    return false;
            }
        }

        string Contratos.Modulo_5.IContratoAgregarRequerimiento.requerimiento
        {
            get { return inputRequerimiento.InnerText; }
        }

        string Contratos.Modulo_5.IContratoAgregarRequerimiento.prioridad
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

        bool Contratos.Modulo_5.IContratoAgregarRequerimiento.finalizado
        {
            get { return false; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "5";
            this.Master.presentador.CargarMenuLateral();
        }
    }
}