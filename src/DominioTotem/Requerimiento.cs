using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    class Requerimiento
    {
	   #region Atributos
	   private string id;
	   private string descripcion;
	   private string tipo;
	   private string prioridad;
	   private string estatus;
	   #endregion

	   #region Propiedades
	   public string Id
	   {
		  get { return id; }
		  set { id = value; }
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
