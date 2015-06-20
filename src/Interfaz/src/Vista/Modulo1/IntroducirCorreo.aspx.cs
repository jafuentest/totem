using System;
using System.Web.UI;
using Contratos.Modulo1;
using Presentadores.Modulo1;

namespace Vista.Modulo1
{
    public partial class IntroducirCorreo : Page, IContratoCorreo
    {
        private PresentadorCorreo presentadorCorreo;

        public IntroducirCorreo()
        {
            presentadorCorreo = new PresentadorCorreo(this);
        }

        public string Correo
        {
            get { return input_correo.Value; }

        }

        public string Mensaje
        {
            set
            {
                alert.Attributes["class"] = "alert alert-info alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + value + "</div>";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Recuperar_Clave_Click(object sender, EventArgs e)
        {
            presentadorCorreo.ManejarEventoCorreo_Click();
        }

    }
}