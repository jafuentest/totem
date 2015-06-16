using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Presentadores.Modulo6; 

namespace Vista.Modulo6
{
    public partial class CrearActor : System.Web.UI.Page, Contratos.Modulo6.IContratoAgregarActor
    {
        private PresentadorAgregarActor presentador;

        public CrearActor() 
        {
            presentador = new PresentadorAgregarActor(this);         
        }
        #region Contrato

        string Contratos.Modulo6.IContratoAgregarActor.nombreActor 
        {
            get { return nombre_actor.Value; }
            set { nombre_actor.Value = value; }
        }

        string Contratos.Modulo6.IContratoAgregarActor.descActor 
        {
            get { return descripcion_actor.Value; }
            set { descripcion_actor.Value = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "6";
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
            }
            
        }

        protected void AgregarActorClick(object sender, EventArgs e)
        {
            string dataCruda = nombre_actor.Value;
            string encodedinput = Server.HtmlEncode(dataCruda);
            label.Text = "Hola" + encodedinput;
            // this.presentador.AgregarActor_Click();

        }
    }
}