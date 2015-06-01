﻿using System;
using System.Collections.Generic;

namespace DominioTotem
{
    public class CasoDeUso
	{
		#region Atributos
		private int _idCasoUso;
        private String _identificadorCasoUso;
        private String _tituloCasoUso;
		private List<Actor> _actores;
        private List<String> _precondicionesCasoUso;
		private List<Requerimiento> _requerimientosAsociado;
        private String _condicionExito;
        private String _condicionFallo;
        private String _disparadorCasoUso;
        private List<Tuple<String, Dictionary<String, List<String>>>> _escenarioExito;
		#endregion

		#region Constructor
		public CasoDeUso(int idCasoUso, String identificadorCasoUso, String tituloCasoUso,
            List<Actor> actoresSecundarios, List<String> precondicionesCasoUso,
            List<Requerimiento> requerimientosAsociados, String condicionExito, String condicionFallo,
            String disparadorCasoUso, List<Tuple<String,Dictionary<String, List<String>>>> escenarioExito)
		{
			this._idCasoUso = idCasoUso;
			this._identificadorCasoUso = identificadorCasoUso;
			this._tituloCasoUso = tituloCasoUso;
            this._actores = actoresSecundarios;
			this._precondicionesCasoUso = precondicionesCasoUso;
            this._requerimientosAsociado = requerimientosAsociados;
			this._condicionExito = condicionExito;
			this._condicionFallo = condicionFallo;
			this._disparadorCasoUso = disparadorCasoUso;
			this._escenarioExito = escenarioExito;
        }

		public CasoDeUso(int idCasoUso, string identificadorCasoUso, string tituloCasoUso, string condicionExito,
			string condicionFallo, string disparadorCasoUso)
		{
			this._idCasoUso = idCasoUso;
			this._identificadorCasoUso = identificadorCasoUso;
			this._tituloCasoUso = tituloCasoUso;
			this._condicionExito = condicionExito;
			this._condicionFallo = condicionFallo;
			this._disparadorCasoUso = disparadorCasoUso;
		}
		#endregion

		#region Propiedades
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

		public List<Actor> Actores
		{
			get { return _actores; }
			set { _actores = value; }
		}

        public List<String> PrecondicionesCasoUso
        {
            get { return _precondicionesCasoUso; }
            set { _precondicionesCasoUso = value; }
        }

		public List<Requerimiento> RequerimientosAsociados
		{
			get { return _requerimientosAsociado; }
			set { _requerimientosAsociado = value; }
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

        public List<Tuple<String, Dictionary<String, List<String>>>> EscenarioExito
        {
            get { return _escenarioExito; }
            set { _escenarioExito = value; }
		}
		#endregion
	}
}
