using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    /// <summary>
    /// Clase telefono
    /// </summary>
    public class Telefono
    {
        #region Atributos
        private int idTel;
        private String codigo;
        private String numero;
        #endregion
        #region Propiedades 
        public int IdTel
        {
            get { return idTel; }
            set { idTel = value; }
        }
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
        public Telefono()
        {
            codigo = null;
            numero = null;
        }
        public Telefono(int elID, String elCodigo, String elNumero)
        {
            idTel = elID;
            codigo = elCodigo;
            numero = elNumero;
        }
        #endregion
    }
}
