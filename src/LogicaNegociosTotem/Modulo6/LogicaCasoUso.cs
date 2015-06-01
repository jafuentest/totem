using DatosTotem.Modulo6;
using DominioTotem;
using System;
using System.Collections.Generic;

namespace LogicaNegociosTotem.Modulo6
{
    public class LogicaCasoUso : IDisposable
    {
        public LogicaCasoUso()
		{ }
		
		public String ObtenerProximoID()
		{
			return "TOT-CU-1-1-1";
		}
		
		public List<CasoDeUso> ListarCasosDeUso(int idProyecto)
        {
			return new BDCasoUso().ListarCasosDeUso(idProyecto);
        }

		void IDisposable.Dispose()
		{
			
		}
	}
}
