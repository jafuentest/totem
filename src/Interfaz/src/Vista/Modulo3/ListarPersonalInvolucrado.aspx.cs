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
    public partial class ListarPersonalInvolucrado : System.Web.UI.Page, Contratos.Modulo3.IContratoListarInvolucrado
    {
        private PresentadorListarInvolucrado presentador;
        public ListarPersonalInvolucrado()
        {
            presentador = new PresentadorListarInvolucrado(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "3";
            this.Master.presentador.CargarMenuLateral();
            
        }

        #region contrato
        string Contratos.Modulo3.IContratoListarInvolucrado.laTabla
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
        #endregion contrato


        protected void evento_eliminar(object sender, EventArgs e)
        {
          
        }
    }
}