
namespace Contratos.Modulo7
{
	/// <summary>
	/// Contrato asociado a la vista Detalle Usuario
	/// </summary>
	public interface IContratoDetalleUsuario
	{
		string Username { set; }
		string Nombre { set; }
		string Apellido { set; }
		string Rol { set; }
		string Correo { set; }
		string Cargo { set; }
		string MensajeAlerta { set; }
		string TipoAlerta { set; }
	}
}
