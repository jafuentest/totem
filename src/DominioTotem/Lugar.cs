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
       private String nombreLugar;       
       private String tipoLugar;
       private int fkLugar;

       #endregion

       #region Propiedades
       public int IdLugar
       {
           get { return idLugar; }
           set { idLugar = value; }
       }
       public String NombreLugar
       {
           get { return nombreLugar; }
           set { nombreLugar = value; }
       }
       public String TipoLugar
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

   }
}
