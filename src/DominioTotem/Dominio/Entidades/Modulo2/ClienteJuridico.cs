using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Entidades.Modulo2
{
   public class ClienteJuridico : Entidad
    {
     #region Atributos

     private String cliJur_Nombre;
     private String cliJur_Rif;
     private String cliJur_Logo;

     private List<Contacto> cliJur_Contactos;
     private Direccion cliJur_Direccion;

     #endregion
       
     #region Propiedades

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
     public ClienteJuridico() : base()
     {
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
     public ClienteJuridico(int id, String nombre) : base(id)
     {
         Jur_Nombre = nombre;
         Jur_Rif = String.Empty;
         Jur_Contactos = null;
         Jur_Direccion = null;
     }

     public ClienteJuridico(int id, String nombre, List<Contacto> contactos, Direccion dir, 
         String elRif, String elLogo) : base(id)
     {
         Jur_Nombre = nombre;
         Jur_Rif = elRif;
         Jur_Contactos = contactos;
         Jur_Direccion = dir;
         Jur_Logo = elLogo;
     }
     public ClienteJuridico(String nombre, List<Entidad> contactos, Entidad dir,
         String elRif, String logo):base()
     {
         List<Contacto> c = new List<Contacto>();
         Jur_Nombre = nombre;
         Jur_Rif = elRif;
         foreach (Entidad e in contactos)
         {
             c.Add((Contacto)e);
         }
         Jur_Contactos = c;
         Jur_Direccion = (Direccion)dir;
         Jur_Logo = logo;
     }
     #endregion
     public override bool Equals(object obj)
     {
         bool esIgual = false;
         ClienteJuridico client = (obj as ClienteJuridico);

         if (this.Id == (client).Id
             && this.Jur_Nombre == (client).Jur_Nombre
             )
             esIgual = true;

         return esIgual;
     }
   }
}
