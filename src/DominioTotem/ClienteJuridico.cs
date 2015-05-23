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
     private string cliJur_Direccion;
     private string cliJur_Codigopostal;
     private List<string> cliJur_Telefono;

     #endregion



     #region Propiedades
     public string Jur_Id
     {
         get { return cliJur_Id; }
         set { cliJur_Id = value; }
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

     public string Jur_CodigoPostal
     {
         get { return cliJur_Codigopostal; }
         set { cliJur_Codigopostal = value; }
     }

     public List<string> Jur_Telefonos 
     {
         get { return cliJur_Telefono; }
         set { cliJur_Telefono = value; }
     }

     #endregion


        #region Constructores

        /*
        public ClienteJuridico()
        {
        
            Cli_jur_id = " ";
            Cli_jur_nombre= " ";
            Cli_jur_direccion= " ";
            Cli_jur_codigopostal= " ";
        
        }



         public ClienteJuridico(string nombre)
        {
       
            Cli_jur_nombre= nombre;
                   
        }


        
         public ClienteJuridico(string direccion)
        {
       
            Cli_jur_direccion= direccion;
                   
        }


            
         public ClienteJuridico(string codigopostal)
        {
       
            Cli_jur_codigopostal= codigopostal;
                   
        }



                    
         public ClienteJuridico(string codigopostal, List<TELEFONO> lista_telefono)
        { 
        }

            public List<Contacto> ObtenerContactos(Cliente_Juridico c)
        {
        
        }

              public List<CLIENTE_JURIDICO> ObtenerClienteJuridico(ClienteJuridico c)
        {
        
        }
              public boolean VerificarClienteJuridico(string cli_jur_id c)
        {
        
        }
         
           public boolean VerificarClienteJuridico (string cli_jur_id )
        {
        
        }

         * 
         *     public boolean AgregarClienteJuridico (string cli_jur_id c)
        {
        
        }
         * 
         * 
          public boolean ModificarClienteJuridico (string cli_jur_id c)
        {
        
        }
         * 
          public boolean ConsultarClienteJuridico (string cli_jur_id c)
        {
        
        }
         * 
         * 
         * 
          public List<CLIENTE_JURIDICO> DatosDelCliente ( string cli_jur_id c)
        {
        
        }
         * 
         * 
         * 
         *    public List<CLIENTE_JURIDICO> ClienteConId ( string cli_jur_id c)
        {
        
        }
         * 
         *     * 
         *    public List<string> FiltrarCargosPorEmpresa ( CLIENTE_JURIDICO cj)
        {
        
        }
         * 
         *  *    public List<CONTACTO> FiltrarEmpleadosDeEmpresaXCargo ( CLIENTE_JURIDICO cj, string cargo)
        {
        
        }

   */
     #endregion

      
       
       /// <summary>
       /// Constructor de la clase Cliente Jurídico
       /// </summary>
     public ClienteJuridico() 
     {
         Jur_Id = string.Empty;
         Jur_Nombre = string.Empty;
         Jur_Direccion = string.Empty;
         Jur_CodigoPostal = string.Empty;
         Jur_Telefonos = null;

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
         Jur_CodigoPostal = string.Empty;
         Jur_Telefonos = null;
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
         Jur_Direccion = string.Empty;
         Jur_CodigoPostal = string.Empty;
         Jur_Telefonos = null;
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
         Jur_CodigoPostal = string.Empty;
         Jur_Telefonos = null;
     }


    /// <summary>
    /// Constructor de la clase Cliente Jurídico
    /// </summary>
     /// <param name="id">RIF o Identificador de la Empresa</param>
    /// <param name="nombre">Npmbre de la Empresa</param>
    /// <param name="direccion">Dirección de la Empresa</param>
    /// <param name="codigoPostal">Código Postal de la Empresa</param>
     public ClienteJuridico(string id, string nombre, string direccion,string codigoPostal)
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Direccion = direccion;
         Jur_CodigoPostal = codigoPostal;
         Jur_Telefonos = null;
     }


       /// <summary>
       /// Constructor de la Clase Cliente Jurídico
       /// </summary>
       /// <param name="id">RIF o Identificador de la Empresa </param>
       /// <param name="nombre">Nombre de la Empresa</param>
       /// <param name="direccion">Dirección de la Empresa</param>
       /// <param name="codigoPostal">Código Postal de la Empresa</param>
       /// <param name="telefonos">Teléfonos de la Empresa</param>
     public ClienteJuridico(string id, string nombre, string direccion, string codigoPostal, List<string> telefonos) 
     {
         Jur_Id = id;
         Jur_Nombre = nombre;
         Jur_Direccion = direccion;
         Jur_CodigoPostal = codigoPostal;
         Jur_Telefonos = telefonos;
     }
   }
}
