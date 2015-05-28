using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    /// <summary>
    /// Clase del Dominio
    /// </summary>
    public class Acuerdo
    {
        #region Atributos
        private int codigo;
        private DateTime fecha;
        private string compromiso;
        private List<Contacto> listaContacto;
        private List<Usuario> listaUsuario;

        #endregion

        #region Constructores 

        public Acuerdo()
        {
        }

        public Acuerdo(DateTime fecha, string compromiso)
        {
            this.fecha = fecha;
            this.compromiso = compromiso;
        }

        public Acuerdo(int codigo, DateTime fecha, string compromiso)
        {
            this.codigo = codigo;
            this.fecha = fecha;
            this.compromiso = compromiso;
        }

        public Acuerdo(DateTime fecha, string compromiso, List<Contacto> listaContacto, List<Usuario> listaUsuario)
        {
            this.fecha = fecha;
            this.compromiso = compromiso;
            this.listaContacto = listaContacto;
            this.listaUsuario = listaUsuario;
        }
        #endregion

        #region sets y gets

        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public string Compromiso
        {
            get { return this.compromiso; }
            set { this.compromiso = value; }
        }

        public List<Contacto> ListaContacto
        {
            get { return this.listaContacto; }
            set { this.listaContacto = value; }
        }

        public List<Usuario> ListaUsuario
        {
            get { return this.listaUsuario; }
            set { this.listaUsuario = value; }
        }

        #endregion
    }
}
