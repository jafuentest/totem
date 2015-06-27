using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DominioTotem;
using Presentadores.Modulo3;
using Contratos.Modulo3;

namespace Vista.Modulo3
{
    public partial class AgregarInvolucrados : System.Web.UI.Page, Contratos.Modulo3.IContratoAgregarInvolucrado
    {
        
        private PresentadorAgregarInvolucrado presentador;
        private static string codigoProyecto;

        public AgregarInvolucrados()
        {
               presentador = new PresentadorAgregarInvolucrado(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            codigoProyecto = this.Master.CodigoProyectoActual();
            if (!IsPostBack)
            {
                Master.idModulo = "3";
                Master.presentador.CargarMenuLateral();
                presentador.LlenarComboEmpresa();
                upModal.Visible = true;
                presentador.iniciarlista();
            }
            if(presentador.eliminarcontacto() != null || presentador.eliminarusuario() != null){
                 presentador.modaleliminar();
                 ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modal_delete", "$('#modal_delete').modal();", true);
                 upModal.Visible = true;
             }
        }

        #region contrato
        DropDownList Contratos.Modulo3.IContratoAgregarInvolucrado.comboTipoEmpresa
        {
            get
            {
                return this.comboTipoEmpresa;
            }
            set
            {
                this.comboTipoEmpresa = value;
            }
        }
        DropDownList Contratos.Modulo3.IContratoAgregarInvolucrado.comboPersonal
        {
            get
            {
                return this.comboPersonal;
            }
            set
            {
                this.comboPersonal = value;
            }
        }
        DropDownList Contratos.Modulo3.IContratoAgregarInvolucrado.comboCargo
        {
            get
            {
                    return this.comboCargo;
            }
            set
            {
                this.comboCargo = value;
            }
        }
        Literal Contratos.Modulo3.IContratoAgregarInvolucrado.laTabla
        {
            get
            {
                return this.laTabla;
            }
            set
            {
                this.laTabla = value;
            }
        }
        String Contratos.Modulo3.IContratoAgregarInvolucrado.user_name
        {
            get
            {
                return this.user_name.InnerText;
            }
            set
            {
                this.user_name.InnerText = value;
            }
        }
        String Contratos.Modulo3.IContratoAgregarInvolucrado.contacto_id
        {
            get
            {
                return this.contacto_id.InnerText;
            }
            set
            {
                this.contacto_id.InnerText = value;
            }
        }
        String Contratos.Modulo3.IContratoAgregarInvolucrado.eliminacionUsuario
        {
            get
            {
                return Request.QueryString["usuarioaeliminar"];
            }
            set
            {
                this.contacto_id.InnerText = Request.QueryString["usuarioaeliminar"]; ;
            }
        }
        String Contratos.Modulo3.IContratoAgregarInvolucrado.eliminacionContacto
        {
            get
            {
                return Request.QueryString["contactoaeliminar"];
            }
            set
            {
                this.contacto_id.InnerText = Request.QueryString["contactoaeliminar"]; ;
            }
        }
        public string alertaContactoClase
        {
            set { alertContacto.Attributes["class"] = value; }
        }

        public string alertaContactoRol
        {
            set { alertContacto.Attributes["role"] = value; }
        }

        public string alertaUsuarioClase
        {
            set { alertUsuario.Attributes["class"] = value; }
        }
        public string alertClase
        {
            set { alert.Attributes["class"] = value; }
        }
        public string alertaUsuarioRol
        {
            set { alertUsuario.Attributes["role"] = value; }
        }
        public string alertRol
        {
            set { alert.Attributes["role"] = value; }
        }
        String Contratos.Modulo3.IContratoAgregarInvolucrado.alert
        {
            set
            {
                alertContacto.InnerHtml = value; ;
            }
        }

        String Contratos.Modulo3.IContratoAgregarInvolucrado.AlertaContacto

        {
            set
            {
                alertContacto.InnerHtml = value; ;
            }
        }
        String Contratos.Modulo3.IContratoAgregarInvolucrado.AlertaUsuario
        {
            set
            {
                alertUsuario.InnerHtml = value; ;
            }
        }
        #endregion contrato


          protected void actualizarComboCargos(object sender, EventArgs e)
          {
              presentador.ListarCargo(comboCargo.SelectedValue);
          }
          protected void actualizarComboPersonal(object sender, EventArgs e)
          {
              presentador.ListarUsuarioSegunCargo(comboPersonal.SelectedValue,codigoProyecto);
          }
          protected void AgregarInvolucrados_Click(object sender, EventArgs e)
          {
              presentador.SeleccionarUsuario();
          }
          protected void btn_enviar_Click(object sender, EventArgs e)
          {
              presentador.GuardarInvolucrados();
          }
          protected void evento_eliminar(object sender, EventArgs e)
          {
      
          }
          protected void evento_modal(object sender, EventArgs e)
          {
              throw new Exception();
          }
       
    }
}