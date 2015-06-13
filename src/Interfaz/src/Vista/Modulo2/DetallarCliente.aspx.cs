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
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();

        }

        #region Contratos
        string Contratos.Modulo2.IContratoDetallarCliente.nombreCliente
        {
            get
            {
                return nombreCliente.Text;
            }
            set
            {
                nombreCliente.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.apellidoCliente
        {
            get
            {
                return apellidoCliente.Text;
            }
            set
            {
                apellidoCliente.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.cedulaCliente
        {
            get
            {
                return cedulaCliente.Text;
            }
            set
            {
                cedulaCliente.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.pais
        {
            get
            {
                return pais.Text;
            }
            set
            {
                pais.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.estado
        {
            get
            {
                return estado.Text;
            }
            set
            {
                estado.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.ciudad
        {
            get
            {
                return ciudad.Text;
            }
            set
            {
                ciudad.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.direccion
        {
            get
            {
                return direccion.Text;
            }
            set
            {
                direccion.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.codpostal
        {
            get
            {
                return codpostal.Text;
            }
            set
            {
                codpostal.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.correocliente
        {
            get
            {
                return correocliente.Text;
            }
            set
            {
                correocliente.Text = value;
            }
        }

        string Contratos.Modulo2.IContratoDetallarCliente.telefono
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
        #endregion

    }
}