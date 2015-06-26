using System;
using System.Web;
using System.Web.UI;
using Contratos.Modulo1;
using Presentadores.Modulo1;

namespace Vista.Modulo1
{
    public partial class Login : Page, IContratoLogin
    {
        private PresentadorLogin presentador;
        private bool captchaActivo = false;
        private int intentos = 0;

        /// <summary>
        /// Constructor de la Clase PresentadorLogin
        /// </summary>
        public Login()
        {
            presentador = new PresentadorLogin(this);
        }

        /// <summary>
        /// Método de Inicio de Carga de la Vista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
       {
            try
            {
                intentos = Convert.ToInt32(Request.Cookies["Intento"]["inten"].ToString());
            }
            catch(Exception)
            {
                HttpCookie aCookie = new HttpCookie("Intento");
                        aCookie.Values["inten"] = intentos.ToString();
                        aCookie.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Add(aCookie);
            }
          
            if (!captchaActivo)
            {
                captchaContainer.Visible = false;
            }
            if (intentos > 2)
            {
                captchaActivo = true;
                captchaContainer.Visible = true;
            }
        }

        /// <summary>
        /// Obtiene el usuario escrito por el usuario en la vista
        /// </summary>
        public string Usuario
        {
            get { return input_usuario.Value; }

        }

        /// <summary>
        /// Obtiene la clave escrita por el usuario en la vista
        /// </summary>
        public string Clave
        {
            get { return input_pswd.Value; }

        }

        /// <summary>
        /// Evento que ocurre cuando el usuario le da click al boton de Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Login_Click(object sender, EventArgs e)
        {

            if (!captchaActivo)
            {
                presentador.ManejarEventoLogin_Click();               
                intentos++;
                HttpCookie aCookie = new HttpCookie("Intento");
                        aCookie.Values["inten"] = intentos.ToString();
                        aCookie.Expires = DateTime.Now.AddMinutes(15);
                        Response.Cookies.Add(aCookie);
            }
            else
            {
                recaptcha.Validate();
                Page.Validate();

                if (Page.IsValid)
                {
                    presentador.ManejarEventoLogin_Click();
                }
                else
                {
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Ingrese el captcha de forma correcta</div>";
                }
            }
        }

        /// <summary>
        /// Método para escribir un mensaje de alerta
        /// </summary>
        /// <param name="esError">El tipo de mensaje, si es TRUE significara que es un Error de lo contrario siginificará que es información</param>
        /// <param name="mensaje">El mensaje a mostrar en la alerta</param>
        public void SetMesaje(bool esError, string mensaje)
        {
            string tipoAlerta;
            if (esError)
                tipoAlerta = "alert-danger";
            else
                tipoAlerta = "alert-info";
            alert.Attributes["class"] = "alert " + tipoAlerta + " alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + mensaje + "</div>";     
        }
    }
}