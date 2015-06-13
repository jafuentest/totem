using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class ModificarContacto : System.Web.UI.Page, Contratos.Modulo2.IContratoModificarContacto
    {
        private PresentadorModificarContacto presentador;

        public ModificarContacto()
        {
            presentador = new PresentadorModificarContacto(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }

        #region Contrato
        string Contratos.Modulo2.IContratoModificarContacto.nombreContacto
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

        string Contratos.Modulo2.IContratoModificarContacto.apellidoContacto
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

        string Contratos.Modulo2.IContratoModificarContacto.cedulaContacto
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

        string Contratos.Modulo2.IContratoModificarContacto.comboCargo
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

        string Contratos.Modulo2.IContratoModificarContacto.codTelefono
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

        string Contratos.Modulo2.IContratoModificarContacto.telefonoContacto
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