using Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace Presentadores
{
    /// <summary>
    /// Clase presentador del MasterPage
    /// </summary>
    public class PresentadorMasterPage
    {
        /// <summary>
        /// Contrato relacionado con el MasterPage
        /// </summary>
        private IContratoMasterPage vista;

        public PresentadorMasterPage(IContratoMasterPage vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo que carga el menu lateral, revisando el id del modulo y 
        /// buscando a traves de el, en el xml
        /// </summary>
        public void CargarMenuLateral()
        {
            /*if ((!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/M1_login.aspx")) &&
                   (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/M1_IntroducirCorreo.aspx")) &&
                   (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/M1_PreguntaSeguridad.aspx")) &&
                   (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/M1_RecuperacionClave.aspx")))
            {
                vista.ulNav = false;
                vista.menuLateral = false;
            }
            else
            {*/
                XmlDocument doc = new XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath(
                    RecursosGeneralPresentadores.Direccion_XML));

                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                    foreach (XmlNode subNode in node.ChildNodes)
                        if (!(subNode.Attributes["id"] == null) && subNode.Attributes["id"].InnerText.Equals(vista.idModulo))
                        {
                            vista.opcionesDeMenu += "<li><a href='" +
                                  node.Attributes["link"].InnerText + "'>" +
                                  node.Attributes["nombre"].InnerText + "</a></li>";
                            break;
                        }
            //}
  
        }

        /// <summary>
        /// Metodo que revisa la sesion actual del usuario y redirecciona
        /// en el caso de que sea necesario
        /// </summary>
        public void RevisarSession()
        {
            if (HttpContext.Current.Session["Credenciales"] != null)
            {
                vista.ulNav = true;
            }

            else
            {
                vista.ulNav = false;
                if ((!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/Login.aspx")) &&
                   (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/IntroducirCorreo.aspx")) &&
                   (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/PreguntaSeguridad.aspx")) &&
                   (!HttpContext.Current.Request.Url.AbsolutePath.Equals("/Modulo1/RecuperacionClave.aspx")))
                {
                    HttpContext.Current.Response.Redirect("../Modulo1/Login.aspx");
                }
            }
        }

        /// <summary>
        /// Metodo que revisa los cookies
        /// </summary>
        public void RevisarCookies()
        {
            HttpCookie pcookie = HttpContext.Current.Request.Cookies.Get("selectedProjectCookie");
            if (pcookie != null)
            {
                vista.selectedProject = "Proyecto Seleccionado: " + pcookie.Values["projectName"].ToString();
                vista.perfilProyecto = "";
                vista.perfilProyecto = "<a runat='server' href='PerfilProyecto.aspx?success="
                    + pcookie.Values["projectCode"].ToString() + "&success=-1'>Detalle de Proyecto</a>";

            }
            else
            {
                vista.perfilProyecto = "";
                vista.perfilProyecto = "<a runat='server' href='PerfilProyecto.aspx?'>Detalle de Proyecto</a>";
            }
        }

    }
}
