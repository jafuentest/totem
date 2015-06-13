using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class ModificarEmpresa : System.Web.UI.Page, Contratos.Modulo2.IContratoModificarEmpresa
    {
        private PresentadorModificarEmpresa presentador;

        public ModificarEmpresa()
        {
            presentador = new PresentadorModificarEmpresa(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }
        #region Contrato
        string Contratos.Modulo2.IContratoModificarEmpresa.rifEmpresa
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

        string Contratos.Modulo2.IContratoModificarEmpresa.nombreEmpresa
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

        string Contratos.Modulo2.IContratoModificarEmpresa.comboPais
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

        string Contratos.Modulo2.IContratoModificarEmpresa.comboEstado
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

        string Contratos.Modulo2.IContratoModificarEmpresa.comboCiudad
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

        string Contratos.Modulo2.IContratoModificarEmpresa.direccionEmpresa
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

        string Contratos.Modulo2.IContratoModificarEmpresa.codigoPostalEmpresa
        {
            get
            {
                return codigopostalEmpresa.Value;
            }
            set
            {
                codigopostalEmpresa.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.laTabla
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

        string Contratos.Modulo2.IContratoModificarEmpresa.contacto_id
        {
            get
            {
                return contacto_id.InnerText;
            }
            set
            {
                contacto_id.InnerText = value;
            }
        }

        string Contratos.Modulo2.IContratoModificarEmpresa.contacto_nombreyap
        {
            get
            {
                return contacto_nombreyap.InnerText;
            }
            set
            {
                contacto_nombreyap.InnerText = value;
            }
        }
        #endregion
    }
}