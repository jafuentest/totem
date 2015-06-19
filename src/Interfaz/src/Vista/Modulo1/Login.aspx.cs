using System;
using System.Web.UI;
using Contratos.Modulo1;
using Presentadores.Modulo1;

namespace Vista.Modulo1
{
    public partial class Login : Page, IContratoLogin
    {
        private PresentadorLogin presentador;

        /// <summary>
        /// Constructor de la Clase PresentadorLogin
        /// </summary>
        public Login()
        {
            presentador = new PresentadorLogin(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Usuario
        {
            get { return input_usuario.Value; }

        }

        public string Clave
        {
            get { return input_pswd.Value; }

        }

        public string Mensaje
        {
            set
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + value + "</div>";
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            presentador.ManejarEventoLogin_Click();
        }

    }
}