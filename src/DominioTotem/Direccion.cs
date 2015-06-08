using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    public class Direccion
    {
        #region Atributos
        private String elPais;
        private String elEstado;
        private String laCiudad;
        private String laDireccion;
        private String codigoPostal;
        #endregion

        #region Constructores
        public Direccion()
        {
            elPais = null;
            elEstado = null;
            laCiudad = null;
            laDireccion = null;
        }
        public Direccion(String pais, String estado, String ciudad, String direccion, String codigop)
        {
            elPais = pais;
            elEstado = estado;
            laCiudad = ciudad;
            laDireccion = direccion;
            codigoPostal = codigop;
        }
        #endregion

        #region Propiedades
        public String ElPais
        {
            get { return elPais; }
            set { elPais = value; }
        }
        public String ElEstado
        {
            get { return elEstado; }
            set { elEstado = value; }
        }
        public String LaCiudad
        {
            get { return laCiudad; }
            set { laCiudad = value; }
        }
        public String LaDireccion
        {
            get { return laDireccion; }
            set { laDireccion = value; }
        }
        public String CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }
        #endregion
    }
}
