using System;
using System.Collections.Generic;

namespace DominioTotem
{
    /// <summary>
    /// Clase del Dominio
    /// </summary>
    public class Minuta
    {
        #region Atributos
        private string codigo;
        private DateTime fecha;
        private string motivo;
        private string observaciones;
        private List<Usuario> usuario;
        private List<Punto> punto;
        private List<Acuerdo> acuerdo; 
        #endregion

        #region Constructores
        public Minuta()
        {
        }

        public Minuta(DateTime fecha, string motivo, string observaciones)
        {
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
        }

        public Minuta(string codigo, DateTime fecha, string motivo, string observaciones) 
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
        }

        public Minuta(DateTime fecha, string motivo, string observaciones, List<Usuario> usuario,
           List<Punto> punto)
        {
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
            this.usuario = usuario;
            this.punto = punto;
        }

        public Minuta(string codigo, DateTime fecha, string motivo, string observaciones, List<Usuario> usuario, 
            List<Punto> punto, List<Acuerdo> acuerdo)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
            this.usuario = usuario;
            this.punto = punto;
            this.acuerdo = acuerdo;
        }

        #endregion

        #region sets y gets
        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public string Motivo
        {
            get { return this.motivo; }
            set { this.motivo = value; }
        }

        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }

        public List<Usuario> ListaUsuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        public List<Punto> ListaPunto
        {
            get { return this.punto; }
            set { this.punto = value; }
        }

        public List<Acuerdo> ListaAcuerdo
        {
            get { return this.acuerdo; }
            set { this.acuerdo = value; }
        }
        #endregion
    }
}