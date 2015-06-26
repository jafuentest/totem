using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo7;
namespace Presentadores.Modulo7
{
	public class PresentadorModificarUsuario
	{
		private IContratoModificarUsuario vista;

		public PresentadorModificarUsuario(IContratoModificarUsuario vista)
		{
			// TODO: Complete member initialization
			this.vista = vista;
		}
		public void CargarDatos()
		{
			throw new NotImplementedException();
		}
	}
}
