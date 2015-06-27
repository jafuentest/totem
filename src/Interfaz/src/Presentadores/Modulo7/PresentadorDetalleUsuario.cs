using Comandos.Fabrica;
using Contratos.Modulo7;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo7;
using System;
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
        /// <summary>
        /// Despliega la informacion del usuario actual en la vista 
        /// </summary>
		public void ObtenerUsuarioActual()
		{
			usuarioLogeado = HttpContext.Current.Session[RecursosPresentadorModulo7.RecursoCredenciales] as Usuario;
		}
        /// <summary>
        /// DESUSO
        /// </summary>
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
        /// <summary>
        /// Suministra la informacion detalla del usuario solicitado al sistema
        /// </summary>
		public void DetalleDeUsuario()
		{
			string username = HttpContext.Current.Request.QueryString[RecursosPresentadorModulo7.RecursoUsername];
			string urlListarUsuarios = RecursosPresentadorModulo7.URL_ListarUsuarios + RecursosPresentadorModulo7.Codigo_Error_UsuarioInvalido;
			bool usuarioNull = username == null;
			bool usuarioVacio = username.Equals(string.Empty);
			bool usuarioInvalido = !Regex.IsMatch(username, RecursosPresentadorModulo7.ExpReg_Username, 
                                    RegexOptions.IgnoreCase);
			if (usuarioNull || usuarioVacio || usuarioInvalido)
				HttpContext.Current.Response.Redirect(urlListarUsuarios);
			FabricaEntidades fabricaEntidades = new FabricaEntidades();
			Entidad parametro = fabricaEntidades.ObtenerUsuario(username);
			Comandos.Comando<Entidad, Entidad> comandoDetalle = FabricaComandos.CrearComandoDetalleUsuario();
			try
			{
				parametro = comandoDetalle.Ejecutar(parametro);
				Usuario usuario = parametro as Usuario;
				vista.Nombre = usuario.Nombre;
				vista.Apellido = usuario.Apellido;
				vista.Correo = usuario.Correo;
				vista.Rol = usuario.Rol;
				vista.Username = usuario.Username;
				vista.Cargo = usuario.Cargo;
			}
			catch (UsuarioInvalidoException e)
			{
                Logger.EscribirError(this.GetType().Name, e);
				HttpContext.Current.Response.Redirect(urlListarUsuarios);
			}
            catch (Exception e)
            {
                Logger.EscribirError(this.GetType().Name, e);
                HttpContext.Current.Response.Redirect(urlListarUsuarios);
            }
		}
	}
}
