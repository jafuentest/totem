using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class DetallarEmpresa : System.Web.UI.Page, Contratos.Modulo2.IContratoDetallarEmpresa
    {
        private PresentadorDetallarEmpresa presentador;

        public DetallarEmpresa()
        {
            presentador = new Presentadores.Modulo2.PresentadorDetallarEmpresa(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador.ObtenerVariablesURL();
            this.Master.idModulo = "2";
            if(!IsPostBack)
                this.Master.presentador.CargarMenuLateral();
        }
        #region Contrato
        string Contratos.Modulo2.IContratoDetallarEmpresa.rifEmpresa
        {
            get
            {
                return rifEmpresa.InnerText;
            }
            set
            {
                rifEmpresa.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.nombreEmpresa
        {
            get
            {
                return nombreEmpresa.InnerText;
            }
            set
            {
                nombreEmpresa.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.paisEmpresa
        {
            get
            {
                return paisEmpresa.InnerText;
            }
            set
            {
                paisEmpresa.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.estadoEmpresa
        {
            get
            {
                return estadoEmpresa.InnerText;
            }
            set
            {
                estadoEmpresa.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.ciudadEmpresa
        {
            get
            {
                return ciudadEmpresa.InnerText; 
            }
            set
            {
                ciudadEmpresa.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.direccionEmpresa
        {
            get
            {
                return direccionEmpresa.InnerText;
            }
            set
            {
                direccionEmpresa.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.codigoPostal
        {
            get
            {
                return codigoPostal.InnerText;
            }
            set
            {
                codigoPostal.InnerText += value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.laTabla
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

        public string alertaClase
        {
            set { alert.Attributes["class"] += value; }
        }

        public string alertaRol
        {
            set { alert.Attributes["role"] += value; }
        }

        public string alerta
        {
            set { alert.InnerHtml += value; }
        }
        #endregion
    }
}