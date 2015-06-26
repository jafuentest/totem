using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class AgregarContacto : System.Web.UI.Page, Contratos.Modulo2.IContratoAgregarContacto
    {

        private PresentadorAgregarContacto presentador;

        public AgregarContacto()
        {
            presentador = new PresentadorAgregarContacto(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.idModulo = "2";
                this.Master.presentador.CargarMenuLateral();
                presentador.llenarComboCargos();
            }
        }
        protected void botonAgregar_Click(object sender, EventArgs e)
        {
            presentador.agregarContacto();
        }
        #region Contrato
        string Contratos.Modulo2.IContratoAgregarContacto.nombreContacto
        {
            get
            {
                return contactoNombre.Value;
            }
            set
            {
                contactoNombre.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarContacto.apellidoContacto
        {
            get
            {
                return apellidoContacto.Value;
            }
            set
            {
                apellidoContacto.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarContacto.cedulaContacto
        {
            get
            {
                return cedulaContacto.Value;
            }
            set
            {
                cedulaContacto.Value = value;
            }
        }

        DropDownList Contratos.Modulo2.IContratoAgregarContacto.comboCargo
        {
            get
            {
                return comboCargo;
            }
            set
            {
                comboCargo = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarContacto.codTelefono
        {
            get
            {
                return codTelefono.Value;
            }
            set
            {
                codTelefono.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarContacto.telefonoContacto
        {
            get
            {
                return telefonoCliente.Value;
            }
            set
            {
                telefonoCliente.Value = value;
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