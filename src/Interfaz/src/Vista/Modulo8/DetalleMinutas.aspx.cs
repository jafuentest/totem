using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Presentadores.Modulo8;
namespace Vista.Modulo8
{
    public partial class DetalleMinutas : System.Web.UI.Page/*, Contratos.Modulo8.IContratoDetalleMinutas*/
    {
        private PresentadorDetalleMinuta presentador;
      /*  public DetalleMinuta()
        {
            presentador = new PresentadorDetalleMinuta(this);
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
          /*  string codigoMinuta = Request.QueryString["idMinuta"];
            this.Master.idModulo = "8";
            this.Master.presentador.CargarMenuLateral();
            presentador.DetalleMinuta(codigoMinuta);
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
              
            }*/

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
            string codigoProyecto = Server.HtmlEncode(Request.Cookies["selectedProjectCookie"]["projectCode"]);

        }/*
        #region Contrato

        string Contratos.Modulo8.IContratoDetalleMinutas.nombreProyecto
        {
            get
            {
                return infoproyect.Text;
            }
            set
            {
                infoproyect.Text = value;
            }
        }
        string Contratos.Modulo8.IContratoConsultarMinuta.fecha
        {
            get
            {
                return fecha.Text;
                
            }
            set
            {
                fecha.Text = value;
            }
        }

        string Contratos.Modulo8.IContratoConsultarMinuta.motivo
        {
            get
            {
                return motivo.Text;
            }
            set
            {
                motivo.Text = value;
            }
        }

        string Contratos.Modulo8.IContratoConsultarMinuta.participantes
        {
            get
            {
                return participantes.Text;
            }
            set
            {
                participantes.Text = value;
            }
        }

         string Contratos.Modulo8.IContratoConsultarMinuta.puntos
        {
            get
            {
                return puntos.Text;
            }
            set
            {
                puntos.Text = value;
            }
        }

         string Contratos.Modulo8.IContratoConsultarMinuta.observaciones
        {
            get
            {
                return observaciones.Text;
            }
            set
            {
                observaciones.Text = value;
            }
        }
        
        string Contratos.Modulo8.IContratoConsultarMinuta.acuerdos
        {
            get
            {
                return acuerdos.Text;
            }
            set
            {
                acuerdos.Text = value;
            }
        }
        #endregion*/
    }
    
}







