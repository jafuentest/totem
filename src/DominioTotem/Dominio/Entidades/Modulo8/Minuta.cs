using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo2;

namespace Dominio.Entidades.Modulo8
{
    /// <summary>
    /// Clase del Dominio
    /// </summary>
    public class Minuta : Entidad
    {
        #region Atributos

        private DateTime fecha;
        private string motivo;
        private string observaciones;
        private List<Usuario> usuario;
        private List<Contacto> contacto;
        private List<Punto> punto;
        private List<Acuerdo> acuerdo;

        #endregion

        #region Constructores
        public Minuta()
        {
            
        }

        public Minuta(int codigo, DateTime fecha, string motivo, string observaciones, List<Usuario> usuario,
            List<Contacto> contacto, List<Punto> punto, List<Acuerdo> acuerdo)
        {
            this.contacto = contacto;
            this.Id = codigo;
            this.fecha = fecha;
            this.motivo = motivo;
            this.observaciones = observaciones;
            this.usuario = usuario;
            this.punto = punto;
            this.acuerdo = acuerdo;
        }

        #endregion

        #region Propiedades

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

        public List<Contacto> ListaContacto
        {
            get { return this.contacto; }
            set { this.contacto = value; }
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
