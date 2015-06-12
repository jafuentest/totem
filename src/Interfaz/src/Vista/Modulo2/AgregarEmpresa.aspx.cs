using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class AgregarEmpresa : System.Web.UI.Page, Contratos.Modulo2.IContratoAgregarEmpresa
    {
        private PresentadorAgregarEmpresa presentador;
        public AgregarEmpresa ()
	    {
            presentador = new Presentadores.Modulo2.PresentadorAgregarEmpresa(this);
	    }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }

        #region Contrato
        string Contratos.Modulo2.IContratoAgregarEmpresa.rifEmpresa
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

        string Contratos.Modulo2.IContratoAgregarEmpresa.nombreEmpresa
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

        string Contratos.Modulo2.IContratoAgregarEmpresa.comboPais
        {
            get
            {
                return comboPais.SelectedValue;
            }
            set
            {
                comboPais.SelectedValue = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarEmpresa.comboEstado
        {
            get
            {
                return comboEstado.SelectedValue;
            }
            set
            {
                comboEstado.SelectedValue = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarEmpresa.comboCiudad
        {
            get
            {
                return comboCiudad.SelectedValue;
            }
            set
            {
                comboCiudad.SelectedValue = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarEmpresa.direccionEmpresa
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

        string Contratos.Modulo2.IContratoAgregarEmpresa.codigoPostalEmpresa
        {
            get
            {
                return codigoPostalEmpresa.Value;
            }
            set
            {
                codigoPostalEmpresa.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarEmpresa.cedulaContacto
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

        string Contratos.Modulo2.IContratoAgregarEmpresa.nombreContacto
        {
            get
            {
                return nombreContacto.Value;
            }
            set
            {
                nombreContacto.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarEmpresa.apellidoContacto
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

        string Contratos.Modulo2.IContratoAgregarEmpresa.comboCargo
        {
            get
            {
                return comboCargo.SelectedValue;
            }
            set
            {
                comboCargo.SelectedValue = value;
            }
        }
        string Contratos.Modulo2.IContratoAgregarEmpresa.codTelefono
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

        string Contratos.Modulo2.IContratoAgregarEmpresa.telefonoCliente
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
        #endregion
    }
}