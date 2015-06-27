using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo8;


namespace Vista.Modulo8
{
    public partial class ConsultarMinuta : System.Web.UI.Page, Contratos.Modulo8.IContratoConsultarMinuta
    {
        private PresentadorConsultarMinuta presentador;
        public ConsultarMinuta()
        {
            presentador = new PresentadorConsultarMinuta(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "8";
            this.Master.presentador.CargarMenuLateral();
            presentador.consultarMinutas();
            String success = Request.QueryString["success"];
            if (success != null)
            {
                if (success.Equals("1"))
                {
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><strong>¡Correcto!</strong> - Se ha Creado la Minuta Correctamente</div>";

                }
                else
                    if (success.Equals("2"))
                    {
                        alert.Attributes["class"] = "alert alert-success alert-dismissible";
                        alert.Attributes["role"] = "alert";
                        alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button><strong>¡Correcto!</strong> - Se ha Modificado la Minuta Correctamente</div>";

                    }
              
            }

            /*if (Request.Cookies["userInfo"] != null)
            {
                if (Server.HtmlEncode(Request.Cookies["userInfo"]["usuario"]) != "" &&
                    Server.HtmlEncode(Request.Cookies["userInfo"]["clave"]) != "")
                {
                    Master.ShowDiv = true;
                }
                else
                {
                    Master.MostrarMenuLateral = false;
                    Master.ShowDiv = false;
                }

            }*/
            //Master.UsuarioActual();
            String codigoProy = this.Master.CodigoProyectoActual();
            String nombreProy = this.Master.NombreProyectoActual();

            presentador.InfoProyecto(codigoProy, nombreProy);
        }
        #region Contrato

        string Contratos.Modulo8.IContratoConsultarMinuta.laTabla
        {
            get
            {
                return laTabla.Text;
            }
            set
            {
                laTabla.Text = value;
            }
        }
        string Contratos.Modulo8.IContratoConsultarMinuta.nombreProyecto
        {
            get
            {
                return this.nombreProyecto.Text;
            }
            set
            {
                this.nombreProyecto.Text = value;
            }
        }

        string Contratos.Modulo8.IContratoConsultarMinuta.codigoProyecto
        {
            get
            {
                return this.codigoProyecto.Text;
            }
            set
            {
                this.codigoProyecto.Text = value;
            }
        }
        

        #endregion
    }
}