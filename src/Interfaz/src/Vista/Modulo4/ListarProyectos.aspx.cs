using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista.Modulo4
{
    public partial class ListarProyectos : System.Web.UI.Page,
	   Contratos.Modulo4.IContratoListarProyectos
    {

	   private Presentadores.Modulo4.PresentadorListarProyectos presentador;

	   public ListarProyectos()
	   {
		  presentador = new Presentadores.Modulo4.PresentadorListarProyectos(this);
	   }

	   protected void Page_Load(object sender, EventArgs e)
	   {
		  if ( !this.IsPostBack )
		  {
			 this.Master.idModulo = "4";
			 this.Master.presentador.CargarMenuLateral();
		  }
	   }

	   public string codigoProyecto
	   {
		  get { throw new NotImplementedException(); }
	   }
    }
}