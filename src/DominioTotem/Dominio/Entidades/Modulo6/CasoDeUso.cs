using System;
using System.Collections.Generic;
using Dominio.Entidades.Modulo5; 

namespace Dominio.Entidades.Modulo6
{
    public class CasoDeUso:Entidad
	{
		#region Atributos
		
        private String _identificadorCasoUso;
        private String _tituloCasoUso;
		private List<Actor> _actores;
        private List<String> _precondicionesCasoUso;
		private List<Requerimiento> _requerimientosAsociado;
        private String _condicionExito;
        private String _condicionFallo;
        private String _disparadorCasoUso;
        private List<Paso> _escenarioExito;
		#endregion

		#region Constructor

        /// <summary>
        /// Constructor vacío de la clase Caso de Uso
        /// </summary>
        public CasoDeUso() 
            :base(0)
        {
            IdentificadorCasoUso = string.Empty;
            TituloCasoUso = string.Empty;
            Actores = null;
            PrecondicionesCasoUso = null;
            RequerimientosAsociados = null; 
            CondicionExito = null;
            CondicionFallo = null;
            DisparadorCasoUso = null;
            EscenarioExito = null; 

        }

        /// <summary>
        /// Constructor de la Clase Caso de Uso
        /// </summary>
        /// <param name="identificadorCasoUso">Id del Caso de Uso</param>
        /// <param name="tituloCasoUso">Título del Caso de Uso</param>
        /// <param name="actoresSecundarios">Principales 
        /// Actores del Caso de Uso
        /// </param>
        /// <param name="precondicionesCasoUso">Precondición 
        /// del Caso de Uso</param>
        /// <param name="requerimientosAsociados">
        /// Requerimientos Asociados del Caso de Uso</param>
        /// <param name="condicionExito">
        /// Condición Final de Éxito del Caso de Uso</param>
        /// <param name="condicionFallo">
        /// Condición Final de Fallo del Caso de Uso</param>
        /// <param name="disparadorCasoUso">
        /// Disparador del Caso de Uso</param>
        /// <param name="escenarioExito">
        /// Escenario de Éxito del Caso de Uso</param>
		public CasoDeUso(String identificadorCasoUso, String tituloCasoUso,
            List<Actor> actoresSecundarios, List<String> precondicionesCasoUso,
            List<Requerimiento> requerimientosAsociados, String condicionExito, String condicionFallo,
            String disparadorCasoUso, List<Paso> escenarioExito)
            :base(0)
		{
			
			IdentificadorCasoUso = identificadorCasoUso;
			TituloCasoUso = tituloCasoUso;
            Actores = actoresSecundarios;
			PrecondicionesCasoUso = precondicionesCasoUso;
            RequerimientosAsociados = requerimientosAsociados;
			CondicionExito = condicionExito;
			CondicionFallo = condicionFallo;
			DisparadorCasoUso = disparadorCasoUso;
			EscenarioExito = escenarioExito;
        }


        /// <summary>
        /// Constructor de la Clase Caso de Uso
        /// </summary>
        /// <param name="identificadorCasoUso">Id del 
        /// Caso de Uso</param>
        /// <param name="tituloCasoUso">Título o nombre
        /// del Caso de Uso</param>
        /// <param name="condicionExito">Condición Final
        /// de Éxito del Caso de Uso</param>
        /// <param name="condicionFallo">
        /// Condición Final de Fallo del Caso de Uso</param>
        /// <param name="disparadorCasoUso">
        /// Disparador del Caso de Uso</param>
		public CasoDeUso( string identificadorCasoUso, string tituloCasoUso, string condicionExito,
			string condicionFallo, string disparadorCasoUso)
            :base(0)
		{
			
			IdentificadorCasoUso = identificadorCasoUso;
			TituloCasoUso = tituloCasoUso;
			CondicionExito = condicionExito;
			CondicionFallo = condicionFallo;
			DisparadorCasoUso = disparadorCasoUso;
		}
		#endregion

		#region Propiedades
		
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

        public List<Paso> EscenarioExito
        {
            get { return _escenarioExito; }
            set { _escenarioExito = value; }
		}
		#endregion

        #region Método Equals
        /// <summary>
        /// Implementación del método Equals
        /// heredado de Object para la clase Caso de Uso
        /// </summary>
        /// <param name="obj">Objeto </param>
        /// <returns>True si es igual, false
        /// si no lo es</returns>
        public override bool Equals(object obj)
        {
            bool esIgual = false;

            try
            {
                if (obj == null)
                    esIgual = false;
                else
                {
                    esIgual = base.Equals(obj);
                    CasoDeUso aux = obj as CasoDeUso;
                    esIgual &= aux.IdentificadorCasoUso.Equals(IdentificadorCasoUso);
                    esIgual &= aux.TituloCasoUso.Equals(TituloCasoUso);
                    esIgual &= aux.Actores.Equals(Actores);
                    esIgual &= aux.PrecondicionesCasoUso.Equals(PrecondicionesCasoUso);
                    esIgual &= aux.RequerimientosAsociados.Equals(RequerimientosAsociados);
                    esIgual &= aux.CondicionExito.Equals(CondicionExito);
                    esIgual &= aux.CondicionFallo.Equals(CondicionFallo);
                    esIgual &= aux.DisparadorCasoUso.Equals(DisparadorCasoUso);
                    esIgual &= aux.EscenarioExito.Equals(EscenarioExito);
                    esIgual &= aux.Id == Id;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return esIgual;
        }
        #endregion
	}
}
