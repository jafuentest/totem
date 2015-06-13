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
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }

        string Contratos.Modulo2.IContratoDetallarContacto.contactoNombre
        {
            get
            {
                return contactoNombre.Text;
            }
            set
            {
                contactoNombre.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.apellidoContacto
        {
            get
            {
                return apellidoContacto.Text;
            }
            set
            {
                apellidoContacto.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.cedulaContacto
        {
            get
            {
                return cedulaContacto.Text;
            }
            set
            {
                cedulaContacto.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.cargoContacto
        {
            get
            {
                return cargoContacto.Text;
            }
            set
            {
                cargoContacto.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarContacto.telefono
        {
            get
            {
                return telefono.Text;
            }
            set
            {
                telefono.Text = value;
            }
        }
    }
}