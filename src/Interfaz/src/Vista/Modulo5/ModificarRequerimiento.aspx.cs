using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo5
{
    public partial class ModificarRequerimiento : System.Web.UI.Page,Contratos.Modulo5.IContratoModificarRequerimiento
    {
        private Presentadores.Modulo5.PresentadorModificarRequerimiento presentador;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.idModulo = "5";
                this.Master.presentador.CargarMenuLateral();
                presentador.CargarDatos();
            }

        }

        #region Constructor
        public ModificarRequerimiento()
        {
            this.presentador = new Presentadores.Modulo5.PresentadorModificarRequerimiento(this);
        }
        #endregion

        #region Contrato
        public string idRequerimiento
        {
            get
            {
                return this.inputIdRequerimiento.Value;
            }
            set
            {
                this.inputIdRequerimiento.Value = value;
            }
        }

        public bool funcional
        {
            get { return (this.inputNoFuncional.Checked); }
        }

        public string requerimiento
        {
            get { return this.inputIdRequerimiento.Value; }
        }

        public string prioridad
        {
            get
            {
                if (this.inputPrioridadAlta.Checked)
                {
                    return "Alta";
                }
                else if (this.inputPrioridadBaja.Checked)
                {
                    return "Baja";
                }
                return "Media";

            }
        }

        public bool finalizado
        {
            get { return (this.inputStatusFinalizado.Checked); }
        }
        #endregion
        
        #region Metodos
        protected void ModificarRequerimiento_Click(object sender, EventArgs e)
        {

        }

        protected void EliminarRequerimiento_Click(object sender, EventArgs e)
        {

        }
        #endregion

        
    }
}