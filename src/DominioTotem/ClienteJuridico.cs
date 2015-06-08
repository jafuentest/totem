using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
   public class ClienteJuridico
    {
     #region Atributos

     private int cliJur_Id ;
     private String cliJur_Nombre;
     private String cliJur_Rif;
     private String cliJur_Logo;

     private List<Contacto> cliJur_Contactos;
     private Direccion cliJur_Direccion;

     #endregion
       
     #region Propiedades
     public int Jur_Id
     {
         get { return cliJur_Id; }
         set { cliJur_Id = value; }
     }

     public String Jur_Nombre
     {
         get { return cliJur_Nombre; }
         set { cliJur_Nombre = value; }
     }

     public List<Contacto> Jur_Contactos
     {
         get { return cliJur_Contactos; }
         set { cliJur_Contactos = value; }
     }
     public Direccion Jur_Direccion
     {
         get { return cliJur_Direccion; }
         set { cliJur_Direccion = value; }
     }
     public String Jur_Rif
     {
         get { return cliJur_Rif; }
         set { cliJur_Rif = value; }
     }
     public String Jur_Logo
     {
         get { return cliJur_Logo; }
         set { cliJur_Logo = value; }
     }
     #endregion

     #region Constructores
     /// <summary>
       /// Constructor de la clase Cliente Jurídico
       /// </summary>
     public ClienteJuridico() 
     {
         Jur_Id = -1;
         Jur_Nombre = String.Empty;
         Jur_Rif = String.Empty;
         Jur_Contactos = null;
         Jur_Direccion = null;
     }

     /// <summary>
    /// Constructor de la clase Cliente Jurídico
    /// </summary>
    /// <param name="id">RIF o Identificador de la Empresa</param>
    /// <param name="nombre">Nombre de la Empresa</param>
     public ClienteJuridico(int id, String nombre) 
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Rif = String.Empty;
         Jur_Contactos = null;
         Jur_Direccion = null;
     }

     public ClienteJuridico(int id, String nombre, List<Contacto> contactos, Direccion dir, 
         String elRif, String elLogo)
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Rif = elRif;
         Jur_Contactos = contactos;
         Jur_Direccion = dir;
         Jur_Logo = elLogo;
     }
     #endregion
     public override bool Equals(object obj)
     {
         bool esIgual = false;
         ClienteJuridico client = (obj as ClienteJuridico);

         if (this.Jur_Id == (client).Jur_Id
             && this.Jur_Nombre == (client).Jur_Nombre
             )
             esIgual = true;

         return esIgual;
     }
   }
}
