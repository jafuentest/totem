using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Contratos.Modulo6;
using Presentadores.Modulo6;

namespace Vista.Modulo6
{
    public partial class Listar : System.Web.UI.Page, IContratoListar
    {

        private PresentadorListar presentador;

        public Listar() 
        {
            presentador = new PresentadorListar(this);         
        }

        #region Contratos

        string Contratos.Modulo6.IContratoListar.tabla
        {
            get { return tabla.Text; }
            set { tabla.Text = value; }
        }



        HtmlButton Contratos.Modulo6.IContratoListar.boton
        {
            get { return boton; }
            set { boton = value; }
        }

        Label Contratos.Modulo6.IContratoListar.mensajeExito
        {
            get { return labelMensajeExito; }
            set { labelMensajeExito = value; }
        }

        Label Contratos.Modulo6.IContratoListar.mensajeError
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
                this.presentador.CargarListaCasosDeUso(); 
            }

        }
    }
}