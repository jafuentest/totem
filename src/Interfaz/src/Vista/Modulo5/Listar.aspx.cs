using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo5
{
    public partial class Listar : System.Web.UI.Page,Contratos.Modulo5.IContratoListar
    {
        private Presentadores.Modulo5.PresentadorListar presentador;

        public Listar()
        {
            this.presentador = new Presentadores.Modulo5.PresentadorListar(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.idModulo = "5";
            this.Master.presentador.CargarMenuLateral();
            Dominio.Entidades.Modulo7.Usuario login = HttpContext.Current.Session["Credenciales"] as Dominio.Entidades.Modulo7.Usuario;
            if (login == null)
            {
                Response.Redirect(" ~/src/Interfaz/Vista/Modulo1/M1_Login.aspx");
            }
        }


        public string IdProyecto
        {
            get
            {
                return this.infoproyect.Text;
   
            }
            set
            {
                this.infoproyect.Text = value;
            }
        }


        public string EmpresaCliente
        {
            set { this.infoclient.Text = value; }
        }

        public string Estatus
        {
            set { this.infostatus.Text = value; }
        }
    }
}