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
        private List<Contacto> contacto;

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
           List<Contacto> contacto)
        {
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
            this.usuario = usuario;
            this.contacto = contacto;
        }

        public Minuta(string codigo, DateTime fecha, string motivo, string observaciones, List<Usuario> usuario, 
            List<Contacto> contacto)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
            this.usuario = usuario;
            this.contacto = contacto;
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

        #endregion
    }
}