using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
   public class ClienteJuridico
    {


     #region Atributos

     private string cliJur_Id ;
     private string cliJur_Nombre;
     private string cliJur_Pais;
     private string cliJur_Estado;
     private Lugar cliJur_Ciudad;
     private string cliJur_Direccion;
     
     private List<string> cliJur_Telefono;
     private List<Contacto> cliJur_Contactos; 

     #endregion



     #region Propiedades
     public string Jur_Id
     {
         get { return cliJur_Id; }
         set { cliJur_Id = value; }
     }

     public string Jur_Pais 
     {
         get { return cliJur_Pais; }
         set { cliJur_Pais = value; }
     }

     public string Jur_Estado 
     {
         get { return cliJur_Estado; }
         set { cliJur_Estado = value; }
     }

     public Lugar Jur_Ciudad
     {
         get { return cliJur_Ciudad; }
         set { cliJur_Ciudad = value; }
     }

     public string Jur_Nombre
     {
         get { return cliJur_Nombre; }
         set { cliJur_Nombre = value; }
     }

     public string Jur_Direccion
     {
         get { return cliJur_Direccion; }
         set { cliJur_Direccion = value; }
     }
    

     public List<string> Jur_Telefonos 
     {
         get { return cliJur_Telefono; }
         set { cliJur_Telefono = value; }
     }

     public List<Contacto> Jur_Contactos
     {
         get { return cliJur_Contactos; }
         set { cliJur_Contactos = value; }
     }

     #endregion


        

      
       
       /// <summary>
       /// Constructor de la clase Cliente Jurídico
       /// </summary>
     public ClienteJuridico() 
     {
         Jur_Id = string.Empty;
         Jur_Nombre = string.Empty;
         Jur_Direccion = string.Empty;
         Jur_Pais = string.Empty;
         Jur_Estado = string.Empty;
         Jur_Ciudad = null;
         Jur_Direccion = string.Empty;
         Jur_Telefonos = null;
         Jur_Contactos = null;

     }

       /// <summary>
       /// Constructor de la clase Cliente Jurídico
       /// </summary>
       /// <param name="nombre">Nombre de la empresa</param>
     public ClienteJuridico(string nombre) 
     {
        
         Jur_Id = string.Empty;
         Jur_Nombre = nombre;
         Jur_Direccion = string.Empty;
         Jur_Pais = string.Empty;
         Jur_Estado = string.Empty;
         Jur_Ciudad = null;
         Jur_Direccion = string.Empty;
         Jur_Telefonos = null;
         Jur_Contactos = null;
       
     }


       /// <summary>
       /// Constructor de la clase Cliente Jurídico
       /// </summary>
       /// <param name="id">RIF o Identificador de la Empresa</param>
       /// <param name="nombre">Nombre de la Empresa</param>
     public ClienteJuridico(string id, string nombre) 
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         
         Jur_Pais = string.Empty;
         Jur_Estado = string.Empty;
         Jur_Ciudad = null;
         Jur_Direccion = string.Empty;
         Jur_Telefonos = null;
         Jur_Contactos = null;
     }


    /// <summary>
    /// Constructor de la clase Cliente Jurídico
    /// </summary>
     /// <param name="id">RIF o Identificador de la Empresa</param>
     /// <param name="nombre">Nombre de la Empresa</param>
    /// <param name="direccion">Dirección de la Empresa</param>
     public ClienteJuridico(string id, string nombre, string direccion) 
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Direccion = direccion;
         Jur_Pais = string.Empty;
         Jur_Estado = string.Empty;
         Jur_Ciudad = null;
        
         Jur_Telefonos = null;
         Jur_Contactos = null;
     }


    /// <summary>
    /// Constructor de la clase Cliente Jurídico
    /// </summary>
     /// <param name="id">RIF o Identificador de la Empresa</param>
    /// <param name="nombre">Npmbre de la Empresa</param>
    /// <param name="direccion">Dirección de la Empresa</param>
    /// <param name="codigoPostal">Código Postal de la Empresa</param>
     public ClienteJuridico(string id, string nombre, string pais, string estado,
         Lugar ciudad,string direccion)
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Direccion = direccion;
         Jur_Pais = pais;
         Jur_Estado = estado;
         Jur_Ciudad = ciudad;
         
         Jur_Telefonos = null;
         Jur_Contactos = null; 
     }


       /// <summary>
       /// Constructor de la Clase Cliente Jurídico
       /// </summary>
       /// <param name="id">RIF o Identificador de la Empresa </param>
       /// <param name="nombre">Nombre de la Empresa</param>
       /// <param name="direccion">Dirección de la Empresa</param>
       /// <param name="codigoPostal">Código Postal de la Empresa</param>
       /// <param name="telefonos">Teléfonos de la Empresa</param>
     public ClienteJuridico(string id, string nombre, string pais, string estado,
         Lugar ciudad, string direccion,
         List<string> telefonos)
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Direccion = direccion;
         Jur_Pais = pais;
         Jur_Estado = estado;
         Jur_Ciudad = ciudad;
         
         Jur_Telefonos = telefonos;
     }

     public ClienteJuridico(string id, string nombre, string pais, string estado,
          Lugar ciudad, string direccion,
          List<string> telefonos,
          List<Contacto> contactos)
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Direccion = direccion;
         Jur_Pais = pais;
         Jur_Estado = estado;
         Jur_Ciudad = ciudad;
    
         Jur_Telefonos = telefonos;
         Jur_Contactos = contactos; 

     }


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
