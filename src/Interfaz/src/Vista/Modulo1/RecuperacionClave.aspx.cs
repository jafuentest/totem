using System;
using System.Web.UI;
using Contratos.Modulo1;
using Presentadores.Modulo1;

namespace Vista.Modulo1
{
    public partial class RecuperacionClave : Page, IContratoClave
    {
        private PresentadorClave presentadorClave;

        public RecuperacionClave()
        {
            presentadorClave = new PresentadorClave(this);
        }

        public string Password
        {
            get { return input_clave.Value; }
        }

        public string PasswordConfirmar
        {
            get { return input_clave_confs.Value; }
        }

        public void setMensaje(bool esError, string mensaje)
        {
            string tipo_alerta;
            if (esError)
                tipo_alerta = "alert-danger";
            else
                tipo_alerta = "alert-info";

            alert.Attributes["class"] = "alert " + tipo_alerta + " alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + mensaje + "</div>";

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Confirmar_ServerClick(object sender, EventArgs e)
        {
            presentadorClave.ManejarEventoPassword_Click(Request);
        }
    }
}