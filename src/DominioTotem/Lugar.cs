using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
   public class Lugar
   {

       #region Atributos

       private int idLugar;      
       private string nombreLugar;       
       private string tipoLugar;
       private int fkLugar;

       #endregion

       #region Propiedades
       public int IdLugar
       {
           get { return idLugar; }
           set { idLugar = value; }
       }
       public string NombreLugar
       {
           get { return nombreLugar; }
           set { nombreLugar = value; }
       }
       public string TipoLugar
       {
           get { return tipoLugar; }
           set { tipoLugar = value; }
       }
       public int FkLugar
       {
           get { return fkLugar; }
           set { fkLugar = value; }
       }
       #endregion

       #region Constructores


       /// <summary>
       /// Constructor de la clase Lugar
       /// </summary>
       public Lugar() 
       {
           IdLugar = 0;
           NombreLugar = string.Empty;
           TipoLugar = string.Empty;
           FkLugar = 0; 
       }

       /// <summary>
       /// Constructor de la Clase Lugar
       /// </summary>
       /// <param name="nombre">Nombre del Lugar</param>
       public Lugar(int id,string nombre) 
       {
           IdLugar = id;
           NombreLugar = nombre;
           TipoLugar = string.Empty;
           FkLugar = 0; 
       }

       /// <summary>
       /// Constructor de la Clase Lugar
       /// </summary>
       /// <param name="id">Identificador del Lugar</param>
       /// <param name="nombre">Nombre del Lugar</param>
       /// <param name="tipoLugar">Tipo de Lugar (país,estado,ciudad o dirección)</param>
       public Lugar(int id, string nombre, string tipoLugar) 
       {
           IdLugar = id;
           NombreLugar = nombre;
           TipoLugar = tipoLugar;
           FkLugar = 0; 
       }


       /// <summary>
       /// Constructor de la Clase Lugar
       /// </summary>
       /// <param name="id">Identificador del Lugar</param>
       /// <param name="nombre">Nombre del Lugar</param>
       /// <param name="tipoLugar">Tipo de Lugar (país,estado,ciudad o dirección)</param>
       /// <param name="fkLugar">Número identificador que engloba este lugar</param>
       public Lugar(int id, string nombre, string tipoLugar, int fkLugar) 
       {
           IdLugar = id;
           NombreLugar = nombre;
           TipoLugar = tipoLugar;
           FkLugar = fkLugar; 
       }

       #endregion

       public override bool Equals(object obj)
       {
           bool esIgual = false;
           Lugar lug = (obj as Lugar);

           if (this.IdLugar == (lug).IdLugar 
               && this.NombreLugar == (lug).NombreLugar)
               esIgual = true;

           return esIgual;
       }

   }
}
