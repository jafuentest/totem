using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcepcionesTotem
{
    public class ExceptionTotem : Exception
    {
	   #region Atributos
	   private string _Codigo;
	   private string _Mensaje;
	   private Exception _Excepcion; 
	   #endregion

	   #region Constructores
	   public ExceptionTotem()
		  : base()
	   {
	   }

	   public ExceptionTotem(string message)
		  : base(message)
	   {
	   }

	   public ExceptionTotem(string message, Exception inner)
		  : base(message, inner)
	   {
	   }

	   public ExceptionTotem(string codigo, string message, Exception inner)
		  : base(message, inner)
	   {
		  _Codigo = codigo;
		  _Mensaje = message;
		  _Excepcion = inner;
	   } 
	   #endregion

	   #region Propiedades
	   public string Codigo
	   {
		  get { return _Codigo; }
		  set { _Codigo = value; }
	   }

	   public string Mensaje
	   {
		  get { return _Mensaje; }
		  set { _Mensaje = value; }
	   }

	   public Exception Excepcion
	   {
		  get { return _Excepcion; }
		  set { _Excepcion = value; }
	   } 
	   #endregion
    }

}
