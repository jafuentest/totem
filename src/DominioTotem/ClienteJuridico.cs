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








    }
}
