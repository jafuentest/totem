using Comandos;
using System.Web;
using Comandos.Fabrica;
using Contratos.Modulo7;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using System;
using System.Collections.Generic;
using ExcepcionesTotem.Modulo7;

namespace Presentadores.Modulo7
{
	/// <summary>
	/// Presentador de la ventana de modificar usuario
	/// </summary>
	public class PresentadorModificarUsuario
	{
		private IContratoModificarUsuario vista;
		string username;

		/// <summary>
		/// Constructor que recibe la ventana que va a hacer uso del presentador
		/// </summary>
		/// <param name="vista">ventana que hará uso del presetnador</param>
		public PresentadorModificarUsuario(IContratoModificarUsuario vista)
		{
			this.vista = vista;
		}

		/// <summary>
		/// Método para llenar los campos con la información actual
		/// </summary>
		public void CargarDatos()
		{
			try
			{
				username = "johan7850";// HttpContext.Current.Request.QueryString["username"];
				Entidad parametro =  new FabricaEntidades().ObtenerUsuario(username);

				Comando<Entidad, Entidad> comandoConsultar = FabricaComandos.CrearComandoDetalleUsuario();

				parametro = comandoConsultar.Ejecutar(parametro);

				Usuario usuario = (Usuario)parametro;

				vista.Nombre = usuario.Nombre;
				vista.Apellido = usuario.Apellido;
				vista.Username = usuario.Username;
				vista.Correo = usuario.Correo;
				vista.Clave = "";
				vista.ConfirmarClave = "";
				vista.Rol = usuario.Rol;
				vista.Cargo = usuario.Cargo;
				vista.Pregunta = "";
				vista.Respuesta = "";
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// Método para llenar el drop down con los cargos disponibles
		/// </summary>
		public void ObtenerCargos()
		{
			Comando<bool, List<String>> comandoCargos = FabricaComandos.CrearComandoLeerCargosUsuarios();
			vista.Cargos = comandoCargos.Ejecutar(true);
		}

		/// <summary>
		/// Método para llenar el drop down con los cargos disponibles
		/// </summary>
		public void ObtenerRoles()
		{
			List<string> strings = new List<string>();
			strings.AddRange(RecursosPresentadorModulo7.Roles.Split(','));
			vista.Roles = strings;
		}

		/// <summary>
		/// Método para modificar al usuario
		/// </summary>
		public void ModificarUsuario()
		{
			try
			{
				FabricaEntidades fabricaEntidades = new FabricaEntidades();

				Entidad usuario = fabricaEntidades.ObtenerUsuario(vista.Username, vista.Clave, vista.Nombre, vista.Apellido,
					vista.Rol, vista.Correo, vista.Pregunta, vista.Respuesta, vista.Cargo);

				Comando<Dominio.Entidad, Boolean> comandoModificar =
					FabricaComandos.CrearComandoModificarUsuario();

				if (comandoModificar.Ejecutar(usuario))
				{
					HttpContext.Current.Response.Redirect(
						RecursosPresentadorModulo7.URL_DetalleUsuario +
						RecursosPresentadorModulo7.Param_Username +
						vista.Username);
				}
			}
			catch (Exception)
			{

			}
		}

		/// <summary>
		/// Método para eliminar el usuario
		/// </summary>
		public void EliminarUsuario()
		{
			try
			{
				Comando<string, bool> comandoEliminar = FabricaComandos.CrearComandoEliminarUsuarios();
				if (comandoEliminar.Ejecutar(vista.Username))
				{
					HttpContext.Current.Response.Redirect
					(
						RecursosPresentadorModulo7.URL_ListarUsuarios +
						RecursosPresentadorModulo7.Codigo_Exito_Eliminar
					);
				}
				else
				{
					HttpContext.Current.Response.Redirect
					(
						RecursosPresentadorModulo7.URL_ListarUsuarios +
						RecursosPresentadorModulo7.Codigo_Error_UsuarioInvalido
					);
				}
			}

			catch (ExcepcionesTotem.ExceptionTotemConexionBD)
			{
				
			}
		}

		/// <summary>
		/// Metodo que valida todos los campos de la vista
		/// </summary>
		/// <returns>true si todos los campos son validos</returns>
		public bool ValidarCampos()
		{
			List<String> campos = ListaDeCampos();
			if (Validaciones.ValidarCamposVacios(campos))
			{
				return true;
			}

			ExcepcionesTotem.Logger.EscribirError(this.GetType().Name,
				new CamposInvalidosUsuarioException(
				RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
				RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
				new CamposInvalidosUsuarioException()));

			throw new CamposInvalidosUsuarioException(
				RecursosGeneralPresentadores.Codigo_Error_InputInvalido,
				RecursosGeneralPresentadores.Mensaje_Error_InputInvalido,
				new CamposInvalidosUsuarioException());
		}

		/// <summary>
		/// Metodo que agrega todos los campos en una lista de String
		/// </summary>
		/// <returns>Lista de String con todos los campos</returns>
		public List<String> ListaDeCampos()
		{
			List<String> campos = new List<string>();
			campos.Add(vista.Nombre);
			campos.Add(vista.Apellido);
			campos.Add(vista.Username);
			campos.Add(vista.Correo);
			campos.Add(vista.Clave);
			campos.Add(vista.ConfirmarClave);
			campos.Add(vista.Rol);
			campos.Add(vista.Cargo);
			campos.Add(vista.Pregunta);
			campos.Add(vista.Respuesta);
			return campos;
		}
	}
}
