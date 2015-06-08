using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo2
{
    /// <summary>
    /// Clase telefono
    /// </summary>
    public class Telefono : Entidad
    {
        #region Atributos
        private String codigo;
        private String numero;
        #endregion

        #region Propiedades 
        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        #endregion

        #region Constructores
        public Telefono() : base()
        {
            codigo = null;
            numero = null;
        }
        public Telefono(int elID, String elCodigo, String elNumero) : base(elID)
        {
            codigo = elCodigo;
            numero = elNumero;
        }
        #endregion
    }
}
