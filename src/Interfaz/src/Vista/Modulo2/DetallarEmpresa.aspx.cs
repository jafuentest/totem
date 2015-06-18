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
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
            String detalleEmpresa = Request.QueryString["detalle"];
            presentador.cargarDatos(detalleEmpresa);
        }
        #region Contrato
        string Contratos.Modulo2.IContratoDetallarEmpresa.rifEmpresa
        {
            get
            {
                return rifEmpresa.Text;
            }
            set
            {
                rifEmpresa.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.nombreEmpresa
        {
            get
            {
                return nombreEmpresa.Text;
            }
            set
            {
                nombreEmpresa.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.paisEmpresa
        {
            get
            {
                return paisEmpresa.Text;
            }
            set
            {
                paisEmpresa.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.estadoEmpresa
        {
            get
            {
                return estadoEmpresa.Text;
            }
            set
            {
                estadoEmpresa.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.ciudadEmpresa
        {
            get
            {
                return ciudadEmpresa.Text; 
            }
            set
            {
                ciudadEmpresa.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.direccionEmpresa
        {
            get
            {
                return direccionEmpresa.Text;
            }
            set
            {
                direccionEmpresa.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarEmpresa.codigoPostal
        {
            get
            {
                return codigoPostal.Text;
            }
            set
            {
                codigoPostal.Text = value;
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
        #endregion
    }
}