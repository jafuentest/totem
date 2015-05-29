using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    public class CasoDeUso
    {
        private int _idCasoUso;
        private String _identificadorCasoUso;
        private String _tituloCasoUso;
        private List<String> _precondicionesCasoUso;
        private String _condicionExito;
        private String _condicionFallo;
        private String _disparadorCasoUso;
        private List<Dictionary<String, Dictionary<String, List<String>>>> _escenarioExito;

        public CasoDeUso(int idCasoUso, String identificadorCasoUso, String tituloCasoUso,
			List<String> precondicionesCasoUso, String condicionExito, String condicionFallo, String disparadorCasoUso,
			List<Dictionary<String,Dictionary<String, List<String>>>> escenarioExito)
		{
			this._idCasoUso = idCasoUso;
			this._identificadorCasoUso = identificadorCasoUso;
			this._tituloCasoUso = tituloCasoUso;
			this._precondicionesCasoUso = precondicionesCasoUso;
			this._condicionExito = condicionExito;
			this._condicionFallo = condicionFallo;
			this._disparadorCasoUso = disparadorCasoUso;
			this._escenarioExito = escenarioExito;
        }

        public int IdCasoUso
        {
            get { return _idCasoUso; }
            set { _idCasoUso = value; }
        }

        public String IdentificadorCasoUso
        {
            get { return _identificadorCasoUso; }
            set { _identificadorCasoUso = value; }
        }

        public String TituloCasoUso
        {
            get { return _tituloCasoUso; }
            set { _tituloCasoUso = value; }
        }

        public List<String> PrecondicionesCasoUso
        {
            get { return _precondicionesCasoUso; }
            set { _precondicionesCasoUso = value; }
        }

        public String CondicionExito
        {
            get { return _condicionExito; }
            set { _condicionExito = value; }
        }

        public String CondicionFallo
        {
            get { return _condicionFallo; }
            set { _condicionFallo = value; }
        }

        public String DisparadorCasoUso
        {
            get { return _disparadorCasoUso; }
            set { _disparadorCasoUso = value; }
        }

        public List<Dictionary<String, Dictionary<String, List<String>>>> EscenarioExito
        {
            get { return _escenarioExito; }
            set { _escenarioExito = value; }
        }
    }
}
