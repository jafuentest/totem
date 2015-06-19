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
    /// <summary>
    /// CodeBehind de la interfaz AgregarUsuario
    /// </summary>
    public partial class AgregarUsuario : System.Web.UI.Page, IContratoAgregarUsuario
    {
        //Declaramos el presentador de esta vista
        private PresentadorAgregarUsuario presentador;

        /// <summary>
        /// Constructor de la clase que inicializa su respectivo presentador enviandole esta clase
        /// </summary>
        public AgregarUsuario ()
        {
           presentador = new PresentadorAgregarUsuario(this);
        }

        #region Contratos
        /// <summary>
        /// Implementacion de los metodos de la interfaz IContratoAgregarUsuario
        /// </summary>
        public string username
        {
            get
            {
                return this.id_username.Value;
            }
           
        }

        public string clave
        {
            get
            {
                return this.password.Value;
            }
           
        }

        public string confirmarClave
        {
            get
            {
                return this.confirm_password.Value;

            }
        }

        public string nombreUsuario
        {
            get
            {
                return this.id_nombre.Value;
            }
            
        }

        public string apellidoUsuario
        {
            get
            {
                return this.id_apellido.Value;
            }
            
        }

        public string correoUsuario
        {
            get
            {
                return this.id_correo.Value;
            }
                  
        }

        public string preguntaUsuario
        {
            get
            {
                return this.id_pregunta.Value;
            }
           
        }

        public string respuestaUsuario
        {
            get
            {
                return this.id_respuesta.Value;
            }
            
        }

        public DropDownList comboTipoRol
        {
            get 
            {
                return this.ComboTipoRol;
            }
            set
            {
                this.ComboTipoRol = value;
            }

        }

        public DropDownList comboTipoCargo
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
        #endregion

        /// <summary>
        /// Evento que se dispara el Agregar un usuario
        /// </summary>
        /// <param name="sender">Objeto que manda el evento</param>
        /// <param name="e">Clase Base de clases que con tienen la informacion del evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "7";
            
            if(!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                presentador.llenarCombos();
            }
                
        }

        /// <summary>
        /// Evento que se dispara al agregar un Usuario
        /// </summary>
        /// <param name="sender">Objeto que manda el evento</param>
        /// <param name="e">Clase Base de clases que con tienen la informacion del evento</param>
        protected void Agregar_Usuario(object sender, EventArgs e)
        {
            bool exito = presentador.AgregarUsuario();
        }
    }
}