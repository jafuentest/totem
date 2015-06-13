﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo2;

namespace Vista.Modulo2
{
    public partial class AgregarCliente : System.Web.UI.Page, Contratos.Modulo2.IContratoAgregarCliente
    {
        private PresentadorAgregarCliente presentador;

        public AgregarCliente()
        {
            presentador = new PresentadorAgregarCliente(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "2";
            this.Master.presentador.CargarMenuLateral();
        }
        #region Contrato
        string Contratos.Modulo2.IContratoAgregarCliente.nombreNatural
        {
            get
            {
                return nombreNatural.Value;
            }
            set
            {
                nombreNatural.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarCliente.apellidoNatural
        {
            get
            {
                return apellidoNatural.Value;
            }
            set
            {
                apellidoNatural.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarCliente.comboRSocial
        {
            get
            {
                return comboRSocial.SelectedValue;
            }
            set
            {
                comboRSocial.SelectedValue = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarCliente.cedulaNatural
        {
            get
            {
                return cedulaNatural.Value;
            }
            set
            {
                cedulaNatural.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarCliente.comboPais
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

        string Contratos.Modulo2.IContratoAgregarCliente.comboEstado
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

        string Contratos.Modulo2.IContratoAgregarCliente.comboCiudad
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

        string Contratos.Modulo2.IContratoAgregarCliente.direccionCliente
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

        string Contratos.Modulo2.IContratoAgregarCliente.codigoPostalCliente
        {
            get
            {
                return codigoPostalCliente.Value;
            }
            set
            {
                codigoPostalCliente.Value = value;
            }
        }

        string Contratos.Modulo2.IContratoAgregarCliente.correoCliente
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

        string Contratos.Modulo2.IContratoAgregarCliente.codTelefono
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

        string Contratos.Modulo2.IContratoAgregarCliente.telefonoCliente
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