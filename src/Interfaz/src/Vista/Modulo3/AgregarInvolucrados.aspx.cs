using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DominioTotem;
using Presentadores.Modulo3;

namespace Vista.Modulo3
{
    public partial class AgregarInvolucrados : System.Web.UI.Page, Contratos.Modulo3.IContratoAgregarInvolucrado
    {
        private PresentadorAgregarInvolucrado presentador;
        public AgregarInvolucrados()
        {
            presentador = new PresentadorAgregarInvolucrado(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "3";
            this.Master.presentador.CargarMenuLateral();
        }

        #region contrato
        string Contratos.Modulo3.IContratoAgregarInvolucrado.comboTipoEmpresa
        {
            get
            {
                return comboTipoEmpresa.SelectedValue;
            }
            set
            {
                comboTipoEmpresa.SelectedValue= value;
            }
        }
        string Contratos.Modulo3.IContratoAgregarInvolucrado.comboPersonal
        {
            get
            {
                return comboPersonal.SelectedValue;
            }
            set
            {
                comboPersonal.SelectedValue = value;
            }
        }
          string Contratos.Modulo3.IContratoAgregarInvolucrado.comboCargo
        {
            get
            {
                    return comboCargo.SelectedValue;
            }
            set
            {
                comboCargo.SelectedValue = value;
            }
        }
         

        #endregion contrato

       
    }
}