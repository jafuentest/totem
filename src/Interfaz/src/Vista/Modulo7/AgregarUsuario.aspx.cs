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
    public partial class AgregarUsuario : System.Web.UI.Page, IContratoAgregarUsuario
    {
        private PresentadorAgregarUsuario presentador;

        public AgregarUsuario ()
        {
           presentador = new PresentadorAgregarUsuario(this);
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

        public string username
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string clave
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string nombreUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string apellidoUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string rolUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string correoUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string preguntaUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string respuestaUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string cargoUsuario
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}