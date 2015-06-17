using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo7;
using Contratos.Modulo7;

namespace Vista.Modulo7
{
    public partial class Registro : System.Web.UI.Page, IContratoAgregarUsuario
    {
        private PresentadorAgregarUsuario presentador;

        public Registro ()
        {
            presentador = new PresentadorAgregarUsuario(this);
        }

        string username 
        { 
            get ; 
            set; 
        }
        string clave 
        {   
            get; 
            set; 
        }
        string nombreUsuario 
        { 
            get; 
            set; 
        }
        string apellidoUsuario 
        { 
            get; 
            set; 
        }
        string rolUsuario 
        { 
            get; 
            set; 
        }
        string correoUsuario 
        { 
            get; 
            set;
        }
        string preguntaUsuario 
        { 
            get; 
            set; 
        }
        string respuestaUsuario 
        { 
            get; 
            set; 
        }
        string cargoUsuario 
        { 
            get; 
            set; 
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se dispara al agregar un Usuario
        /// </summary>
        /// <param name="sender">Objeto que manda el evento</param>
        /// <param name="e">Clase Base de clases que con tienen la informacion del evento</param>
        protected void Agregar_Usuario(object sender, EventArgs e)
        {
          
        }
    }
}