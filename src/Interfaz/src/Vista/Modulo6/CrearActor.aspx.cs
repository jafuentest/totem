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

        Label Contratos.Modulo6.IContratoAgregarActor.mensajeExito
        {
            get { return labelMensajeExito; }
            set { labelMensajeExito = value; }  
        }

        Label Contratos.Modulo6.IContratoAgregarActor.mensajeError
        {
            get { return labelMensajeError; }
            set { labelMensajeError = value; }
        }

        HtmlButton Contratos.Modulo6.IContratoAgregarActor.botonAgregar 
        {
            get { return botonAgregar; }
            set { botonAgregar = value; }
        }

        

        #endregion

        /// <summary>
        /// Evento que se genera al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "6";
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
            }

            if (IsPostBack) 
            {
                this.presentador.LimpiarPagina(); 
            }
                        
        }

        /// <summary>
        /// Evento que se genera al darle click de aceptar, y
        /// llama al método de presentador de agregar click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AgregarActorClick(object sender, EventArgs e)
        {
            
           this.presentador.AgregarActor_Click();

        }
    }
}