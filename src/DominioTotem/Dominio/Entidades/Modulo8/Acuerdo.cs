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
    public class Acuerdo : Entidad
    {
        #region Atributos

        private DateTime fecha;
        private string compromiso;
        private List<Contacto> listaContacto;
        private List<Usuario> listaUsuario;

        #endregion

        #region Constructores

        public Acuerdo()
        {

        }

        public Acuerdo(int id, DateTime fecha, string compromiso, List<Contacto> listaContacto, List<Usuario> listaUsuario)
        {
            this.Id = id;
            this.fecha = fecha;
            this.compromiso = compromiso;
            this.listaContacto = listaContacto;
            this.listaUsuario = listaUsuario;
        }
        #endregion

        #region Propiedades

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
