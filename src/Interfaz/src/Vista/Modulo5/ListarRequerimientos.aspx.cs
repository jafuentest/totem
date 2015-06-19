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
            this.presentador = new Presentadores.Modulo5.PresentadorListarRequerimientos(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "5";
            this.Master.presentador.CargarMenuLateral();
        }


        public string IdProyecto
        {
            get
            {
                return this.infoproyect.Text;
   
            }
            set
            {
                this.infoproyect.Text = value;
            }
        }


        public string EmpresaCliente
        {
            set { this.infoclient.Text = value; }
        }

        public string Estatus
        {
            set { this.infostatus.Text = value; }
        }
    }
}