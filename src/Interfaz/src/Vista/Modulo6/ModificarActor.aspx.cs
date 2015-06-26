using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Presentadores.Modulo6;   

namespace Vista.Modulo6
{
    public partial class ModificarActor : System.Web.UI.Page, Contratos.Modulo6.IContratoModificarActor
    {
        private PresentadorModificarActor  presentador;

        public ModificarActor() 
        {
            presentador = new PresentadorModificarActor(this);         
        }
        #region Contrato

        string Contratos.Modulo6.IContratoModificarActor.nombreActor 
        {
            get { return nombre_actor.Value; }
            set { nombre_actor.Value = value; }
        }

        string Contratos.Modulo6.IContratoModificarActor.descActor 
        {
            get { return descripcion_actor.Value; }
            set { descripcion_actor.Value = value; }
        }

        Label Contratos.Modulo6.IContratoModificarActor.mensajeExito
        {
            get { return labelMensajeExito; }
            set { labelMensajeExito = value; }  
        }

        Label Contratos.Modulo6.IContratoModificarActor.mensajeError
        {
            get { return labelMensajeError; }
            set { labelMensajeError = value; }
        }

        HtmlButton Contratos.Modulo6.IContratoModificarActor.botonAgregar 
        {
            get { return botonAgregar; }
            set { botonAgregar = value; }
        }

        

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "6";
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                this.presentador.CargarDatosActor(); 
            }
        }

        protected void botonModificar_ServerClick(object sender, EventArgs e)
        {
            this.presentador.ModificarDatos(); 
        }
    }
}