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

        private int codigo;
        private string titulo;
        private string desarrollo;

        #endregion

        #region Constructores

        public Punto()
        {
        }

        public Punto(int codigo, string titulo, string desarrollo)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.desarrollo = desarrollo;
        }

        #endregion

        #region Propiedades

        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

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
