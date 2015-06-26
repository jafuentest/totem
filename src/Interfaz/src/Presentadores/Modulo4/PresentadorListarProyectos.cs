using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Contratos.Modulo4;

namespace Presentadores.Modulo4
{
    public class PresentadorListarProyectos
    {
	   private IContratoListarProyectos vista;
	   private Dominio.Entidades.Modulo7.Usuario usuario;

	   public Dominio.Entidades.Modulo7.Usuario Usuario
	   {
		  get { return usuario; }
		  set { usuario = value; }
	   }

	   public PresentadorListarProyectos(IContratoListarProyectos laVista)
	   {
		  this.vista = laVista;
	   }

	   public void ObtenerUsuario(String nombreUsuario)
	   {
		  vista.nombreUsuario = nombreUsuario;
	   }
    }
}
