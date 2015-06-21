using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo8
{
    /// <summary>
    /// Clase del Dominio
    /// </summary>
    public class Punto : Entidad
    {
        #region Atributos

        private string titulo;
        private string desarrollo;

        #endregion

        #region Constructores

        public Punto()
        {
        }

        public Punto(int codigo, string titulo, string desarrollo)
        {
            this.Id = codigo;
            this.titulo = titulo;
            this.desarrollo = desarrollo;
        }

        #endregion

        #region Propiedades

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public string Desarrollo
        {
            get { return this.desarrollo; }
            set { this.desarrollo = value; }
        }

        #endregion
    }
}
