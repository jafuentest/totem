using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class DetallarContacto : System.Web.UI.Page, Contratos.Modulo2.IContratoDetallarContacto
    {
        private PresentadorDetallarContacto presentador;

        public DetallarContacto()
        {
            presentador = new PresentadorDetallarContacto(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }

        #region Contrato
        string Contratos.Modulo2.IContratoDetallarContacto.nombreContacto
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

        string Contratos.Modulo2.IContratoDetallarContacto.apellidoContacto
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

        string Contratos.Modulo2.IContratoDetallarContacto.cedulaContacto
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

        string Contratos.Modulo2.IContratoDetallarContacto.codTelefono
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

        string Contratos.Modulo2.IContratoDetallarContacto.telefonoContacto
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