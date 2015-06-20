using System;
using System.Web.UI;
using Contratos.Modulo1;
using Presentadores.Modulo1;

namespace Vista.Modulo1
{
    public partial class PreguntaSeguridad : Page, IContratoPregunta
    {
        private PresentadorPregunta presentadorPregunta;

        public PreguntaSeguridad()
        {
            presentadorPregunta = new PresentadorPregunta(this);
        }

        public string Pregunta
        {
            set { label_pregunta.InnerText = value; }
        }

        public string Respuesta
        {
            get { return input_respuesta.Value; }

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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Validar_Pregunta_Click(object sender, EventArgs e)
        {
            
        }
    }
}