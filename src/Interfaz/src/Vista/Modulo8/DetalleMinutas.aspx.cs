using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Versioning;
using System.Web.Services;
using Newtonsoft.Json;
using Presentadores;
using System.Linq;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo8;
namespace Vista.Modulo8
{
    public partial class DetalleMinutas : System.Web.UI.Page/*, Contratos.Modulo8.IContratoDetalleMinutas*/
    {
        private static string codigoProyecto;
        private static string codigoMinuta = "";
        private Presentadores.Modulo8.PresentadorCrearMinuta presentador = new Presentadores.Modulo8.PresentadorCrearMinuta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.idModulo = "8";
                this.Master.presentador.CargarMenuLateral();
                presentador.ObtenerUsuarioLogeado();
            }
            codigoMinuta = Request.QueryString["idMinuta"];
            codigoProyecto = this.Master.CodigoProyectoActual();
        }


        /// <summary>
        /// Método parar cargar los Detalles de la Minuta
        /// </summary>
        /// <returns>Retorna un String con JSON para poder cargar los Detalles de la Minuta</returns>
        [WebMethod]
        public static string detalleMinuta()
        {
            string aux = "";
            for (int i = 0; i <= codigoMinuta.Length-1; i++)
            { 
                if ((codigoMinuta[i].ToString()!="{") && (codigoMinuta[i].ToString()!="}") )
                {
                    aux = aux +codigoMinuta[i];
                }
            }
            string idminuta = aux;



            Console.WriteLine(idminuta);
            int codMinuta = Int32.Parse(idminuta);
            Presentadores.Modulo8.PresentadorDetalleMinuta presentador = new Presentadores.Modulo8.PresentadorDetalleMinuta();
            //Proyecto elProyecto = new Proyecto() { Codigo = codigoProyecto };
            Minuta minuta = (Minuta)presentador.DetalleMinuta(codMinuta.ToString());
            var output = JsonConvert.SerializeObject(minuta);
            return output;
        }

        protected void ImprimirMinuta(object sender, EventArgs e)
        {
            string aux = "";
            for (int i = 0; i <= codigoMinuta.Length - 1; i++)
            {
                if ((codigoMinuta[i].ToString() != "{") && (codigoMinuta[i].ToString() != "}"))
                {
                    aux = aux + codigoMinuta[i];
                }
            }
            string idminuta = aux;
            Presentadores.Modulo8.PresentadorDetalleMinuta presentador = new Presentadores.Modulo8.PresentadorDetalleMinuta();
            presentador.GenerarMinuta(idminuta);
        }


    }
}







