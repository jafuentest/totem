using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class ListarClientes : System.Web.UI.Page, Contratos.Modulo2.IContratoListarClientes
    {
        private PresentadorListarClientes presentador;
        public ListarClientes()
        {
            presentador = new PresentadorListarClientes(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
            presentador.ObtenerVariablesURL();
            if (!IsPostBack) 
            { 
                presentador.consultarClientes();
            }
           
        }
        #region Contrato
        string Contratos.Modulo2.IContratoListarClientes.laTabla
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
        #endregion
    }
}