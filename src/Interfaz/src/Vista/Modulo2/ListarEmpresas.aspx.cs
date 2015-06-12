using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contratos.Modulo2;

namespace Vista.Modulo2
{
    public partial class ListarEmpresas : System.Web.UI.Page, IContratoListarEmpresas
    {
        private Presentadores.Modulo2.PresentadorListarEmpresas presentador;

        public ListarEmpresas()
        {
            presentador = new Presentadores.Modulo2.PresentadorListarEmpresas(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }
        #region Contrato
        string Contratos.Modulo2.IContratoListarEmpresas.laTabla
        {
            get
            {
                return laTabla.Text;
            }
            set
            {
                laTabla.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoListarEmpresas.empresa_rif
        {
            get
            {
                return empresa_rif.InnerText;
            }
            set
            {
                empresa_rif.InnerText = value;
            }
        }

        string Contratos.Modulo2.IContratoListarEmpresas.empresa_nombre
        {
            get
            {
                return empresa_nombre.InnerText;
            }
            set
            {
                empresa_nombre.InnerText = value;
            }
        }
        #endregion
    }
}