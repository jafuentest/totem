using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    class CLIENTE_JURIDICO
    {


     #region Atributos

     private string Cli_jur_id ;
     private string Cli_jur_nombre;
     private string Cli_jur_direccion;
     private string Cli_jur_codigopostal;

     #endregion



     #region Gets y Sets
     public string Jur_ID
     {
         get { return Cli_jur_id; }
         set { Cli_jur_id = value; }
     }


     public string Jur_NOMBRE
     {
         get { return Cli_jur_nombre; }
         set { Cli_jur_nombre = value; }
     }

     public string Jur_DIRECCION
     {
         get { return Cli_jur_direccion; }
         set { Cli_jur_direccion = value; }
     }

     public string Jur_CODIGOPOSTAL
     {
         get { return Cli_jur_codigopostal; }
         set { Cli_jur_codigopostal = value; }
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










    }
}
