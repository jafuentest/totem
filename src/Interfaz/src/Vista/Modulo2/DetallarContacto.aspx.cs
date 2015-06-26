using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class DetallarContacto : System.Web.UI.Page,Contratos.Modulo2.IContratoDetallarContacto
    {
        private PresentadorDetallarContacto presentador;

        public DetallarContacto()
        {
            presentador = new Presentadores.Modulo2.PresentadorDetallarContacto(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador.ObtenerVariablesURL();
            if (!IsPostBack)
            {
                this.Master.idModulo = "2";
                this.Master.presentador.CargarMenuLateral();
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.contactoNombre
        {
            get
            {
                return contactoNombre.InnerText;
            }
            set
            {
                contactoNombre.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.apellidoContacto
        {
            get
            {
                return apellidoContacto.InnerText;
            }
            set
            {
                apellidoContacto.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.cedulaContacto
        {
            get
            {
                return cedulaContacto.InnerText;
            }
            set
            {
                cedulaContacto.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.cargoContacto
        {
            get
            {
                return cargoContacto.InnerText;
            }
            set
            {
                cargoContacto.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.telefono
        {
            get
            {
                return telefono.InnerText;
            }
            set
            {
                telefono.InnerText += value;
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
    }
}