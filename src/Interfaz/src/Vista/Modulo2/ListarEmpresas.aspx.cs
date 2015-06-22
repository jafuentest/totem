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
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                presentador.consultarEmpresas();
            }
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

        #endregion+
    }
}