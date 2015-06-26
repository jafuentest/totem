using System.Data;

namespace Contratos.Modulo7
{
	/// <summary>
	/// Contrato asociado a la vista Modificar Usuario
	/// </summary>
	public interface IContratoModificarUsuario
	{
		string Nombre { get; set; }
		string Apellido { get; set; }
		string Username { get; set; }
		string Correo { get; set; }
		string Clave { get; set; }
		string ConfirmarClave { get; set; }
		string Rol { get; set; }
		string Cargo { get; set; }
		string Pregunta { get; set; }
		string Respuesta { get; set; }
		DataSet Roles { get; set; }
		DataSet Cargos { get; set; }
	}
}
