using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo6
{
   public class Extension:Entidad
   {
       #region Atributos

       private string descripcion;
       private List<Paso> pasos;
#endregion

       #region Propiedades
       public string Descripcion
       {
           get { return descripcion; }
           set { descripcion = value; }
       }
       

       public List<Paso> Pasos
       {
           get { return pasos; }
           set { pasos = value; }
       } 
       #endregion

       #region Constructores
       public Extension() 
           :base(0)
       {
           Descripcion = string.Empty;
           Pasos = null; 
       }

       public Extension(string descripcion, List<Paso> losPasos) 
        :base(0)
       {
           Descripcion = descripcion;
           Pasos = losPasos;
       }
       #endregion

       #region Método Equals
       /// <summary>
       /// Implementación del método Equals
       /// heredado de Object para la clase Extensión
       /// </summary>
       /// <param name="obj">Objeto </param>
       /// <returns>True si es igual, false
       /// si no lo es</returns>
       public override bool Equals(object obj)
       {
           bool esIgual = false;

           try
           {
               if (obj == null)
                   esIgual = false;
               else
               {
                   esIgual = base.Equals(obj);
                   Extension aux = obj as Extension;
                   esIgual &= aux.Descripcion.Equals(Descripcion);
                   esIgual &= aux.Pasos.Equals(Pasos); 
                   esIgual &= aux.Id == Id;
               }

           }
           catch (Exception)
           {
               throw;
           }

           return esIgual;
       }
       #endregion

   }
}
