
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;

namespace LogicaNegociosTotem.Modulo6
{
    class LogicaCasoUso
    {
        public List<CasoDeUso> ListarCasosDeUso()
        {
            int idCasoUso = 1;
            String identificadorCasoUso = "TOT_CU_1_1_1";
            String tituloCasoUso = "Iniciar Sesión";
            
			List<String> precondicionesCasoUso = new List<string>();
			precondicionesCasoUso.Add("El usuario debe tener una cuenta iniciada");
			precondicionesCasoUso.Add("El usuario debe tener su cuenta habilitada");

            String condicionExito = "El usuario accede al sistema";
            String condicionFallo = "El sistema vuelve a mostrar la pantalla de inicio de sesión";
            String disparadorCasoUso = "El usuario intenta acceder a la aplicación";

			List<String> pasosExtension1 = new List<String>();
			pasosExtension1.Add("Se hace algo");
			pasosExtension1.Add("Se hace otra cosa");

			List<String> pasosExtension2 = new List<String>();
			pasosExtension2.Add("Se hace algo distinta");
			pasosExtension2.Add("Se hace otra cosa diferente");

			Dictionary<string, List<string>> extensiones = new Dictionary<string, List<string>>();
			extensiones.Add("El usuario cometió un error", pasosExtension1);
			extensiones.Add("El usuario cometió un error grave", pasosExtension2);

			Dictionary<String, Dictionary<String, List<String>>> paso1 =
				new Dictionary<String, Dictionary<String, List<String>>>();
			paso1.Add("El usuario ingresa al sistema", null);

			Dictionary<String, Dictionary<String, List<String>>> paso2 =
				new Dictionary<String, Dictionary<String, List<String>>>();
			paso2.Add("El sistema despliega la pantalla de Inicio de Sesión",extensiones);
			
			List<Dictionary<String, Dictionary<String, List<String>>>> escenarioExito =
				new List<Dictionary<String, Dictionary<String, List<String>>>>();
			escenarioExito.Add(paso1);
			escenarioExito.Add(paso2);

			CasoDeUso casoDeUso = new CasoDeUso(idCasoUso, identificadorCasoUso, tituloCasoUso, precondicionesCasoUso,
				condicionExito, condicionFallo, disparadorCasoUso, escenarioExito);

			List<CasoDeUso> lista = new List<CasoDeUso>();
			lista.Add(casoDeUso);

			return lista;
        }
    }
}
