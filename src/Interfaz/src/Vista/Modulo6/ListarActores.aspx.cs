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
    public partial class ListarActores : System.Web.UI.Page, Contratos.Modulo6.IContratoListarActores
    {

        private PresentadorListarActores presentador;
        public ListarActores()
        {
            presentador = new PresentadorListarActores(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = this.Master.CodigoProyectoActual();
            this.Master.idModulo = "6";

            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                presentador.ObtenerVariablesURL();
                presentador.consultarActores(codigo);
            }

        }
        #region Contrato

        Repeater Contratos.Modulo6.IContratoListarActores.RActor
        {
            get { return RActor; }
            set { RActor = value; }
        }

        Label Contratos.Modulo6.IContratoListarActores.mensajeError
        {
            get
            {
                return labelMensajeError;
            }
            set
            {
                labelMensajeExito = value;
            }
        }

        Label Contratos.Modulo6.IContratoListarActores.mensajeExito
        {
            get
            {
                return labelMensajeExito;
            }
            set
            {
                labelMensajeExito = value;
            }
        }


        #endregion

    }

}