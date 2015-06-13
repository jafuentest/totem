using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class ModificarCliente : System.Web.UI.Page, Contratos.Modulo2.IContratoModificarCliente
    {
        private PresentadorModificarCliente presentador;
        public ModificarCliente()
        {
            presentador = new PresentadorModificarCliente(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }
        #region Contrato
        string Contratos.Modulo2.IContratoModificarCliente.nombreCliente
        {
            get
            {
                return nombreCliente.Value;
            }
            set
            {
                nombreCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarCliente.apellidoCliente
        {
            get
            {
                return apellidoCliente.Value;
            }
            set
            {
                apellidoCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarCliente.cedulaCliente
        {
            get
            {
                return cedulaCliente.Value;
            }
            set
            {
                cedulaCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarCliente.comboPais
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

        string Contratos.Modulo2.IContratoModificarCliente.comboEstado
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

        string Contratos.Modulo2.IContratoModificarCliente.comboCiudad
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

        string Contratos.Modulo2.IContratoModificarCliente.direccionCliente
        {
            get
            {
                return direccionCliente.Value;
            }
            set
            {
                direccionCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarCliente.codigoPostalCliente
        {
            get
            {
                return codigopostalCliente.Value;
            }
            set
            {
                codigopostalCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarCliente.correoCliente
        {
            get
            {
                return correoCliente.Value;
            }
            set
            {
                correoCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarCliente.codTelefono
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

        string Contratos.Modulo2.IContratoModificarCliente.telefonoCliente
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