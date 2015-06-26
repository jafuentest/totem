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
            this.Master.idModulo = "6";

            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                presentador.consultarActores();

            }
            /* String exitoEliminacion = Request.QueryString["success-eliminacion"];
            String eliminarActor = Request.QueryString["clienteaeliminar"];
            if (eliminarActor != null)
                if (presentador.desplegarModal(eliminarActor))
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal-delete", "$('#modal-delete').modal();", true);

            if (eliminarActor == "true")
            {
                this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se elimino correctamente</div>";
                this.alert.Visible = true;
            }*/
            //

        }
        #region Contrato
        string Contratos.Modulo6.IContratoListarActores.laTabla
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