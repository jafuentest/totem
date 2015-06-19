using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contratos.Modulo7;
using Presentadores.Modulo7;

namespace Vista.Modulo7
{
    /// <summary>
    /// CodeBehind de la interfaz ListarUsuario
    /// </summary>
    public partial class ListarUsuarios : System.Web.UI.Page , IContratoListarUsuarios
    {
        //Declaramos el presentador de esta vista
        private PresentadorListarUsuarios presentador;

        /// <summary>
        /// Constructor de la clase que inicializa su respectivo presentador enviandole esta clase
        /// </summary>
        public ListarUsuarios()
        {
            presentador = new PresentadorListarUsuarios(this);
        }

        #region Contrato
        /// <summary>
        /// Implementacion de los metodos de la interfaz IContratoAgregarUsuario
        /// </summary>o
         public Literal tablaUsuarios
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
        #endregion

        /// <summary>
        /// Evento que se dispara al cargar la pagina
        /// </summary>
        /// <param name="sender">Objeto que manda el evento</param>
        /// <param name="e">Clase Base de clases que con tienen la informacion del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "7";

            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                presentador.LlenarTabla();
            }
        }

        protected void evento_eliminar(object sender, EventArgs e)
        {

        }
       
    }
}