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

	   public void ListarProyectos(String nombreUsuario)
	   {
		  Comandos.Comando<String, List<Dominio.Entidad>> comandoListarProyectos;

		  comandoListarProyectos = Comandos.Fabrica.FabricaComandos.
			 CrearComandoConsultarProyectosPorUsuario();

		  try
		  {
			 List<Dominio.Entidad> listaProyectos =
				  comandoListarProyectos.Ejecutar(nombreUsuario);

			 foreach (Dominio.Entidades.Modulo4.Proyecto tupla in listaProyectos)
			 {
				vista.jumbotronProyecto += "<div class='form-group'>";
				vista.jumbotronProyecto += "<div class='jumbotron'>";
				vista.jumbotronProyecto += "<h2 class='sameLine'><a href='ListarProyectos.aspx?success=" + tupla.Codigo + "&success=-1'>" + tupla.Nombre + "</a></h2> <h5 class='sameLine'>CÓDIGO - </h5> <h5 id='codigoProyecto' class='sameLine' runat='server'>" + tupla.Codigo + "</h5>";
				vista.jumbotronProyecto += "<p class='desc'>" + tupla.Descripcion + "</p>";

				if (tupla.Estado)
				    vista.jumbotronProyecto += "<input type='checkbox' checked disabled> Activo";
				else
				    vista.jumbotronProyecto += "<input type='checkbox' unchecked disabled> Inactivo";

				vista.jumbotronProyecto += "<br>";
				//vista.jumbotronProyecto += "<p class='sameLine'>Cliente: </p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
				vista.jumbotronProyecto += "</div>";
				vista.jumbotronProyecto += "</div>";
			 }
		  }
		  catch (Exception ex)
		  {
			 vista.jumbotronProyecto += "<div class='form-group'>";
			 vista.jumbotronProyecto += "<div id='div_perfiles' class='col-sm-12 col-md-12 col-lg-12'>";
			 vista.jumbotronProyecto += "<div class='jumbotron'>";
			 vista.jumbotronProyecto += "<h2>T_04_010</h2>";
			 vista.jumbotronProyecto += "<p class='desc'>No hay proyectos asociados para este usuario</p>";
			 vista.jumbotronProyecto += "</div>";
			 vista.jumbotronProyecto += "</div>";
			 vista.jumbotronProyecto += "</div>";
		  }
	   }
    }
}
