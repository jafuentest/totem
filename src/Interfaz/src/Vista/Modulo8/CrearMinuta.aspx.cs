using Contratos.Modulo8;
using Dominio.Entidades.Modulo7;
using Presentadores.Modulo8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo8
{
    public partial class CrearMinuta : System.Web.UI.Page, Contratos.Modulo8.IContratoCrearMinuta
    {
        private PresentadorCrearMinuta presentador;
        private static string codigoProyecto;
        public CrearMinuta()
        {
            presentador = new PresentadorCrearMinuta(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "8";
            this.Master.presentador.CargarMenuLateral();
            codigoProyecto = Server.HtmlEncode(Request.Cookies["selectedProjectCookie"]["projectCode"]);
            presentador.ListaInvolucrado("Tot");
        }



        #region contrato

        string Contratos.Modulo8.IContratoCrearMinuta.FechaMinuta 
        { 
            get
            {
                //return fechaReunion.Value;
                throw new NotImplementedException();
            }
            set
            {
                //fechaReunion.Value = value;
                throw new NotImplementedException();
            }
        
        }
        string Contratos.Modulo8.IContratoCrearMinuta.MotivoMinuta
        {
            get
            {
                //return motivo.Value;
                throw new NotImplementedException();
            }
            set
            {
                //motivo.Value = value;
                throw new NotImplementedException();
            }
        
        }
        string Contratos.Modulo8.IContratoCrearMinuta.Observaciones
        {
            get
            {
                //return observaciones.Value;
                throw new NotImplementedException();
            }
            set
            {
                //observaciones.Value = value;
                throw new NotImplementedException();
            }

        }

        string Contratos.Modulo8.IContratoCrearMinuta.ListaInvolucrado
        {
            get
            {
                return listaInvolucrado.InnerText;

            }
            set
            {
                listaInvolucrado.InnerText = value;
            }

        }
        #endregion
    }
}