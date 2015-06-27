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
			 Master.idModulo = "4";
			 Master.presentador.CargarMenuLateral();
			 presentador.ListarProyectos(Master.UsuarioActual().Username);
			 // presentador.ObtenerUsuario(Master.UsuarioActual().Username + Master.UsuarioActual().Rol + Master.CodigoProyectoActual());
		  }
	   }

	   #region Contratos
	   public string nombreUsuario
	   {
		  get { return LEstado.Text; }
		  set { LEstado.Text = value; }
	   }
	   string Contratos.Modulo4.IContratoListarProyectos.jumbotronProyecto
	   {
		  get { return jumbotronProyecto.Text; }
		  set { jumbotronProyecto.Text = value; }
	   } 
	   #endregion
    }
}