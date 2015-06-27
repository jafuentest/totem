using Comandos;
using Comandos.Fabrica;
using Contratos.Modulo7;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using System;
using System.Data;

namespace Presentadores.Modulo7
{
	/// <summary>
	/// Presentador de la ventana de modificar usuario
	/// </summary>
	public class PresentadorModificarUsuario
	{
		private IContratoModificarUsuario vista;

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
				string username = "albertods";// HttpContext.Current.Request.QueryString["username"];
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
			Comando<object, DataSet> comandoCargos = new FabricaComandos().CrearComandoConsultarCargosConId();
			DataSet ds = comandoCargos.Ejecutar(null);
		}
	}
}
