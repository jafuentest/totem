using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;
namespace Vista.Modulo2
{
    public partial class DetallarCliente : System.Web.UI.Page, Contratos.Modulo2.IContratoDetallarCliente
    {
        private PresentadorDetallarCliente presentador;
        public DetallarCliente()
        {
            presentador = new Presentadores.Modulo2.PresentadorDetallarCliente(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador.ObtenerVariablesURL();
            this.Master.idModulo = "2";
            if(!IsPostBack)
                this.Master.presentador.CargarMenuLateral();
        }

        #region Contratos
        string Contratos.Modulo2.IContratoDetallarCliente.nombreCliente
        {
            get
            {
                return nombreCliente.InnerText;
            }
            set
            {
                nombreCliente.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.apellidoCliente
        {
            get
            {
                return apellidoCliente.InnerText;
            }
            set
            {
                apellidoCliente.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.cedulaCliente
        {
            get
            {
                return cedulaCliente.InnerText;
            }
            set
            {
                cedulaCliente.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.pais
        {
            get
            {
                return pais.InnerText;
            }
            set
            {
                pais.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.estado
        {
            get
            {
                return estado.InnerText;
            }
            set
            {
                estado.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.ciudad
        {
            get
            {
                return ciudad.InnerText;
            }
            set
            {
                ciudad.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.direccion
        {
            get
            {
                return direccion.InnerText;
            }
            set
            {
                direccion.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.codpostal
        {
            get
            {
                return codpostal.InnerText;
            }
            set
            {
                codpostal.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.correocliente
        {
            get
            {
                return correocliente.InnerText;
            }
            set
            {
                correocliente.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.telefono
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
        #endregion
    }
}