using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo5
{
    public partial class ListarRequerimientos : System.Web.UI.Page,Contratos.Modulo5.IContratoListarRequerimientos
    {
        private Presentadores.Modulo5.PresentadorListarRequerimientos presentador;

        public ListarRequerimientos()
        {
            presentador = new Presentadores.Modulo5.PresentadorListarRequerimientos(this);
        }
        #region Contrato
        public string IdProyecto
        {
            get
            { return infoproyect.Text; }

            set
            { infoproyect.Text = value; }
        }       

        public string EmpresaCliente
        {
            set { infoclient.Text = value; }
        }

        public string Estatus
        {
            set { infostatus.Text = value; }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.idModulo = "5";
                this.Master.presentador.CargarMenuLateral();
            }
        }
    }
}