using Comandos.Fabrica;
using Contratos.Modulo7;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo7;
using System.Text.RegularExpressions;
using System.Web;

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
			string urlListarUsuarios = RecursosPresentadorModulo7.URL_ListarUsuarios + RecursosPresentadorModulo7.Codigo_Error_UsuarioInvalido;

			bool usuarioNull = username == null;
			bool usuarioVacio = username.Equals("");
			bool usuarioInvalido = !Regex.IsMatch(
				username, RecursosPresentadorModulo7.ExpReg_Username, RegexOptions.IgnoreCase);

			if (usuarioNull || usuarioVacio || usuarioInvalido)
				HttpContext.Current.Response.Redirect(urlListarUsuarios);

			FabricaEntidades fabricaEntidades = new FabricaEntidades();
			Entidad parametro = fabricaEntidades.ObtenerUsuario(username);
			Comandos.Comando<Entidad, Entidad> comandoDetalle = FabricaComandos.CrearComandoDetalleUsuario();

			try
			{
				parametro = comandoDetalle.Ejecutar(parametro);

				Usuario usuario = (Usuario)parametro;

				vista.Nombre = usuario.Nombre;
				vista.Apellido = usuario.Apellido;
				vista.Correo = usuario.Correo;
				vista.Rol = usuario.Rol;
				vista.Username = usuario.Username;
				vista.Cargo = usuario.Cargo;
			}
			catch (UsuarioInvalidoException e)
			{
				HttpContext.Current.Response.Redirect(urlListarUsuarios);
			}
		}
	}
}
