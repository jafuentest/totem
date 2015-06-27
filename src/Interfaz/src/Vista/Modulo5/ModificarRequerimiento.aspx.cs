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
                presentador.CargarDatos(); //aqui tiene asignado id 
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

        public string funcional
        {
            get
            {
                if (inputFuncional.Checked)
                    return "Funcional";
                else
                    return "No Funcional";
            }
            set
            {
                if (value.Equals("Funcional", StringComparison.InvariantCultureIgnoreCase))
                {
                    inputFuncional.Checked = true;
                }
                else
                {
                    inputNoFuncional.Checked = true;
                }
            }
        }

        public string requerimiento
        {
            get { return inputRequerimiento.Value; }
            set { inputRequerimiento.Value = value; }
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
            set
            {
                if (value.Equals("Alta", StringComparison.InvariantCultureIgnoreCase))
                {
                    inputPrioridadAlta.Checked = true;
                }
                if (value.Equals("Media", StringComparison.InvariantCultureIgnoreCase))
                {
                    inputPrioridadMedia.Checked = true;
                }
                if (value.Equals("Baja", StringComparison.InvariantCultureIgnoreCase))
                {
                    inputPrioridadBaja.Checked = true;
                }
            }
        }

        public string finalizado
        {
            get
            {
                if (inputStatusFinalizado.Checked)
                {
                    return "Finalizado";
                }
                return "No Finalizado";
            }
            set
            {
                if (value.Equals("Finalizado", StringComparison.InvariantCultureIgnoreCase))
                {
                    inputStatusNoFinalizado.Checked = false;
                    inputStatusFinalizado.Checked = true;
                }
                else
                {
                    inputStatusNoFinalizado.Checked = true;
                    inputStatusFinalizado.Checked = false;
                }
            }
        }
        public string alertaClase
        {
            set { alert.Attributes["class"] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes["role"] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion
        
        #region Metodos
        protected void ModificarRequerimiento_Click(object sender, EventArgs e)
        {
            presentador.ModificarRequerimiento(); //aqui se le borra el id
        }

        protected void EliminarRequerimiento_Click(object sender, EventArgs e)
        {
            presentador.EliminarRequerimiento();           
        }
        protected void AsignarCodigoFuncional(object sender, EventArgs e)
        {
            presentador.ObtenerCodigoRequerimiento();
        }
        #endregion

        
    }
}