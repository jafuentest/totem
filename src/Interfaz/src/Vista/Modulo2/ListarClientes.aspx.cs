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
            if (!IsPostBack) 
                presentador.consultarClientes();
            String exitoEliminacion = Request.QueryString["success-eliminacion"];
            String eliminarCliente = Request.QueryString["clienteaeliminar"];
            if (eliminarCliente != null)
                if (presentador.desplegarModal(eliminarCliente))
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal-delete", "$('#modal-delete').modal();", true);

            if (eliminarCliente == "true")
            {
                this.alert.Attributes["class"] = "alert alert-success alert-dismissible";
                this.alert.Attributes["role"] = "alert";
                this.alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se elimino correctamente</div>";
                this.alert.Visible = true;
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

        string Contratos.Modulo2.IContratoListarClientes.cliente_cedula
        {
            get
            {
                return cliente_cedula.InnerText;
            }
            set
            {
                cliente_cedula.InnerText = value;
            }
        }

        string Contratos.Modulo2.IContratoListarClientes.cliente_nombreyap
        {
            get
            {
                return cliente_nombreyap.InnerText;
            }
            set
            {
                cliente_nombreyap.InnerText = value;
            }
        }
        #endregion

        protected void EliminarClienteNat(object sender, EventArgs e)
        {
            String eliminarCliente = Request.QueryString["clienteaeliminar"];
            if (presentador.eliminarCliente(eliminarCliente))
                Response.Redirect("../Modulo2/ListarClientes.aspx?success-eliminacion=true");
        }
    }
}