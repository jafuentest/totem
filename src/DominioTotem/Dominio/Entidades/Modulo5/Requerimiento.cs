using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo5
{
    public class Requerimiento:Entidad
    {
	   #region Atributos
	   
	   private string codigo;
	   private string descripcion;
	   private string tipo;
	   private string prioridad;
	   private string estatus;
       private string codigoProyecto;
	   #endregion

	   #region Constructor
       public Requerimiento() 
           :base(0)
       {
           Codigo = string.Empty;
           Descripcion = string.Empty;
           Tipo = string.Empty;
           Prioridad = string.Empty;
           Estatus = string.Empty;

       }

       public Requerimiento(string codigo)
           : base(0)
       {
           Codigo = codigo;
       }

       public Requerimiento(string codigo, string descripcion, string tipo, string prioridad, string estatus)
	    :base(0)
       {
		  Codigo = codigo;
		  Descripcion = descripcion;
		  Tipo = tipo;
		  Prioridad = prioridad;
		  Estatus = estatus;
	   }

       public Requerimiento(string codigo, string descripcion, string tipo, string prioridad, string estatus, 
           string codigoProyecto) : base(0)
       {
           Codigo = codigo;
           Descripcion = descripcion;
           Tipo = tipo;
           Prioridad = prioridad;
           Estatus = estatus;
           CodigoProyecto = codigoProyecto;
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
       public string CodigoProyecto
       {
           get { return codigoProyecto; }
           set { codigoProyecto = value; }
       }
	   #endregion
    }
}
