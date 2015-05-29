using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    public class Requerimiento
    {
	   #region Atributos
	   private string codigo;
	   private string descripcion;
	   private string tipo;
	   private string prioridad;
	   private string estatus;
	   #endregion

	   #region Constructor
	   public Requerimiento(string codigo, string descripcion, string tipo, string prioridad, string estatus)
	   {
		  Codigo = codigo;
		  Descripcion = descripcion;
		  Tipo = tipo;
		  Prioridad = prioridad;
		  Estatus = estatus;
	   } 
	   #endregion

	   #region Propiedades
	   public string Codigo
	   {
		  get { return codigo; }
		  set { codigo = value; }
	   }
	   public string Descripcion
	   {
		  get { return descripcion; }
		  set { descripcion = value; }
	   }
	   public string Tipo
	   {
		  get { return tipo; }
		  set { tipo = value; }
	   }
	   public string Prioridad
	   {
		  get { return prioridad; }
		  set { prioridad = value; }
	   }
	   public string Estatus
	   {
		  get { return estatus; }
		  set { estatus = value; }
	   } 
	   #endregion
    }
}
