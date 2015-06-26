using Comandos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo7;
using Dominio.Entidades.Modulo7;
using System.Web.UI;
using System.Web;
using Dominio;
using Dominio.Fabrica;

namespace Presentadores.Modulo7
{
	public class PresentadorDetalleUsuario
	{
		private IContratoDetalleUsuario vista;
		private Usuario usuarioLogeado;
		private Usuario usuario;

		/// <summary>
		/// Constructor del presentador Detalle Usuario
		/// </summary>
		/// <param name="vista">El contrato de la ventana que va a mostar el detalle del usuario</param>
		public PresentadorDetalleUsuario(IContratoDetalleUsuario vista)
		{
			this.vista = vista;
		}

		public void ObtenerUsuarioActual()
		{
			usuarioLogeado = HttpContext.Current.Session["Credenciales"] as Usuario;
		}

		public void ObtenerParametrosQueryString()
		{
			//string error = HttpContext.Current.Request.QueryString["error"];
			//if (error != null && error.Equals("input_malicioso"))
			//{
			//	vista.MensajeAlerta = RecursosGeneralPresentadores.Mensaje_Error_InputInvalido;
			//	vista.TipoAlerta = RecursosPresentadorModulo7.Codigo_Error;
			//}
			//if (error)
		}

		public void DetalleDeUsuario()
		{
			string username = HttpContext.Current.Request.QueryString["username"];
			FabricaEntidades fabricaEntidades = new FabricaEntidades();
			Entidad parametro = fabricaEntidades.ObtenerUsuario(username);
			Comandos.Comando<Entidad, Entidad> comandoDetalle = FabricaComandos.CrearComandoDetalleUsuario();
			parametro = comandoDetalle.Ejecutar(parametro);

			Usuario usuario = (Usuario) parametro;

			vista.Nombre = usuario.Nombre;
			vista.Apellido = usuario.Apellido;
			vista.Correo = usuario.Correo;
			vista.Rol = usuario.Rol;
			vista.Username = usuario.Username;
			vista.Cargo = usuario.Cargo;
		}
	}
}
