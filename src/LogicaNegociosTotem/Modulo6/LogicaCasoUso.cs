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
		
		public List<CasoDeUso> ListarCasosDeUso()
        {
            int idCasoUso = 1;
            String identificadorCasoUso = "TOT-CU-1-1-1";
            String tituloCasoUso = "Iniciar Sesión";
            Actor actorPrmario = new Actor("Usuario", "Usuario Comun del sistema");

			List<String> precondicionesCasoUso = new List<string>();
			precondicionesCasoUso.Add("El usuario debe tener una cuenta iniciada");
			precondicionesCasoUso.Add("El usuario debe tener su cuenta habilitada");

            Requerimiento requerimiento = new Requerimiento("REQ-1-1", "El sistema debera hacer algo", "Funcional", "Alta", "Algo");
            List<Requerimiento> requerimientos = new List<Requerimiento>();
            requerimientos.Add(requerimiento);

            String condicionExito = "El usuario accede al sistema";
            String condicionFallo = "El sistema vuelve a mostrar la pantalla de inicio de sesion";
            String disparadorCasoUso = "El usuario intenta acceder a la aplicacion";

			List<String> pasosExtension1 = new List<String>();
			pasosExtension1.Add("Se hace algo");
			pasosExtension1.Add("Se hace otra cosa");

			List<String> pasosExtension2 = new List<String>();
			pasosExtension2.Add("Se hace algo distinta");
			pasosExtension2.Add("Se hace otra cosa diferente");

			Dictionary<string, List<string>> extensiones = new Dictionary<string, List<string>>();
			extensiones.Add("El usuario cometio un error", pasosExtension1);
			extensiones.Add("El usuario cometio un error grave", pasosExtension2);

			Dictionary<String, Dictionary<String, List<String>>> paso1 =
				new Dictionary<String, Dictionary<String, List<String>>>();
			paso1.Add("El usuario ingresa al sistema", null);

			Dictionary<String, Dictionary<String, List<String>>> paso2 =
				new Dictionary<String, Dictionary<String, List<String>>>();
			paso2.Add("El sistema despliega la pantalla de Inicio de Sesion",extensiones);
			
			List<Dictionary<String, Dictionary<String, List<String>>>> escenarioExito =
				new List<Dictionary<String, Dictionary<String, List<String>>>>();
			escenarioExito.Add(paso1);
			escenarioExito.Add(paso2);

			CasoDeUso casoDeUso = new CasoDeUso(idCasoUso, identificadorCasoUso, tituloCasoUso, actorPrmario, null,
                precondicionesCasoUso, requerimientos, condicionExito, condicionFallo, disparadorCasoUso,
                escenarioExito);

			List<CasoDeUso> lista = new List<CasoDeUso>();
			lista.Add(casoDeUso);

			return lista;
        }

		void IDisposable.Dispose()
		{
			
		}
	}
}
