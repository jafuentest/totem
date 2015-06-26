using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class ModificarEmpresa : System.Web.UI.Page, Contratos.Modulo2.IContratoModificarEmpresa
    {
        private PresentadorModificarEmpresa presentador;

        public ModificarEmpresa()
        {
            presentador = new PresentadorModificarEmpresa(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            presentador.ObtenerVariablesURL();
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                presentador.llenarComboPais();

            }

        }
        #region Contrato
        string Contratos.Modulo2.IContratoModificarEmpresa.rifEmpresa
        {
            get
            {
                return rifEmpresa.Value;
            }
            set
            {
                rifEmpresa.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.nombreEmpresa
        {
            get
            {
                return nombreEmpresa.Value;
            }
            set
            {
                nombreEmpresa.Value = value;
            }
        }

        DropDownList Contratos.Modulo2.IContratoModificarEmpresa.comboPais
        {
            get
            {
                return comboPais;
            }
            set
            {
                comboPais = value;
            }
        }

        DropDownList Contratos.Modulo2.IContratoModificarEmpresa.comboEstado
        {
            get
            {
                return comboEstado;
            }
            set
            {
                comboEstado = value;
            }
        }

        DropDownList Contratos.Modulo2.IContratoModificarEmpresa.comboCiudad
        {
            get
            {
                return comboCiudad;
            }
            set
            {
                comboCiudad = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.direccionEmpresa
        {
            get
            {
                return direccionEmpresa.Value;
            }
            set
            {
                direccionEmpresa.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.codigoPostalEmpresa
        {
            get
            {
                return codigopostalEmpresa.Value;
            }
            set
            {
                codigopostalEmpresa.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.laTabla
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

        string Contratos.Modulo2.IContratoModificarEmpresa.contacto_id
        {
            get
            {
                return contacto_id.InnerText;
            }
            set
            {
                contacto_id.InnerText = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.contacto_nombreyap
        {
            get
            {
                return contacto_nombreyap.InnerText;
            }
            set
            {
                contacto_nombreyap.InnerText = value;
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

        protected void comboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.llenarComboEstadosXPais(comboPais.SelectedValue);
        }

        protected void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.llenarComboCiudadXEstado(comboEstado.SelectedValue);
        }
        protected void EditarEmpresa_Click(object sender, EventArgs e)
        {
            String edicionEmpresa = Request.QueryString["id"];
            presentador.modificarEmpresa(edicionEmpresa);

        }

        protected void btnAgregarNuevoContacto_Click(object sender, EventArgs e)
        {
            presentador.redirAgregarContacto();
        }
    }
}