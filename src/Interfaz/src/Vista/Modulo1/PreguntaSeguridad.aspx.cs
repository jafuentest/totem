﻿using System;
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
            presentadorPregunta.CargarPregunta(Request);
        }

        protected void Validar_Pregunta_Click(object sender, EventArgs e)
        {
            presentadorPregunta.ManejarEventoPregunta_Click(Request, Response);
        }


    }
}