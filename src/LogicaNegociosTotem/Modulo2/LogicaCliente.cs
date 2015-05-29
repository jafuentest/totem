using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using DatosTotem.Modulo2;
using ExcepcionesTotem.Modulo2;
using DatosTotem;
 

namespace LogicaNegociosTotem.Modulo2
{

    /// <summary>
    /// Clase encargada de gestionar la lógica de negocios relacionada a la gestión 
    /// de Clientes y Empresas
    /// </summary>
   public class LogicaCliente
    {

       private BDCliente baseDeDatosCliente; 
       /// <summary>
       /// Constructor de la Clase LogicaCliente
       /// </summary>
       public LogicaCliente() 
       {
           baseDeDatosCliente = new BDCliente(); 
       }


       /// <summary>
       /// Método de lógica que llama al acceso a datos para
       /// verificar la existencia de un cliente jurídico
       /// </summary>
       /// <param name="rif"></param>
       /// <returns></returns>
       public int VerificarExistenciaJuridico(string rif) 
       {
           return baseDeDatosCliente.VerificarExistenciaClienteJuridico(rif);
       }

       /// <summary>
       /// Método que solicita a acceso a datos que inserte el cliente jurídico nuevo
       /// </summary>
       /// <param name="clienteJuridico">Información del Cliente Jurídico</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool AgregarClienteJuridico(string rif, string nombre, int fkLugar,string direccion,string contactoNombre,
           string apellidoNombre,int idCargo,string telefono,string cedula)
       {
           try
           {
               int codTele = 0;
               int idNumero = 0;

               string contenedorCodigo = string.Empty;
               //Vamos a separar el string de telefono en codTele y IdNumero para 
               //ser insertados como númericos en BD.
               char[] cadena = telefono.ToCharArray();
               char[] codigoAux = new char[4];
               char[] numeroAux = new char[8];
               string codigoSeparado = "";
               string numeroSeparado = "";
               int j = 0; 
               for (int i = 0; i < cadena.Length; i++)
               {
                   //Los 3 primeros indices son para codigo
                   if (i < 3)
                   {
                       codigoAux[i] = cadena[i];
                       codigoSeparado = codigoSeparado + codigoAux[i]; 
                       
                   }
                   //Los demás son para teléfono
                   else
                   {
                       numeroAux[j] = cadena[i];
                       numeroSeparado = numeroSeparado + numeroAux[j];
                       j++; 
                   }
               }
               
               
               codTele = Convert.ToInt32(codigoSeparado);
               idNumero = Convert.ToInt32(numeroSeparado);

               ClienteJuridico clienteJuridico = new ClienteJuridico(rif, nombre);

               return baseDeDatosCliente.AgregarClienteJuridico(clienteJuridico, fkLugar,direccion,contactoNombre ,
                   apellidoNombre, idCargo,codTele, idNumero,cedula);
           }
           catch(Exception e)
           {
               throw new ExcepcionesTotem.Modulo2.ClienteLogicaException("L_02_003","Error dentro de la capa lógica",e);
           }
       }


       /// <summary>
       /// Método que solicita a acceso a datos que inserte el cliente natural nuevo
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool AgregarClienteNatural(string identificador, string nombre, int fkLugar)
       {
           //try
          // {

           
               ClienteNatural clientenatural = new ClienteNatural(identificador, nombre);
               return baseDeDatosCliente.AgregarClienteNatural(clientenatural, fkLugar);
           

           //}
          // catch (ExcepcionesTotem.Modulo2.ExcepcionLogicaClientes)
        //   {
             
             //  throw new ExcepcionesTotem.Modulo2.ExcepcionLogicaClientes();
           //}
                
            //}
            

        }


       /// <summary>
       /// Método que le solicita a acceso a datos que borre el cliente natural seleccionado
       /// ,en la Base de Datos
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool EliminarClienteNatural(string cedula)
       {
           return baseDeDatosCliente.EliminarClienteNatural(cedula);
       }


       /// <summary>
       ///  Método que le solicita a acceso a datos que actualice los datos del cliente natural seleccionado, 
       /// en la Base de Datos
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool ModificarClienteNatural(ClienteNatural clienteNatural,string cargo, string codigo, string numero)
       {
           ClienteNatural cliente = new ClienteNatural();
           cliente = clienteNatural;
           return baseDeDatosCliente.ModificarClienteNatural(cliente, cargo, codigo, numero);
       }


       /// <summary>
       ///  Método que le solicita a acceso a datos que actualice los datos del cliente jurídico seleccionado, 
       /// en la Base de Datos
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool ModificarClienteJuridico(ClienteJuridico clienteJuridico)
       {
           ClienteJuridico cliente = new ClienteJuridico();
           cliente = clienteJuridico;
           return baseDeDatosCliente.ModificarClienteJuridico(cliente);
       }


       /// <summary>
       ///  Método que solicita a acceso a datos un cliente juridico en particular
       /// </summary>
       /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
       public ClienteJuridico ConsultarClienteJuridico(int id)
       {
           return baseDeDatosCliente.ConsultarClienteJuridico( id); 
       }


       /// <summary>
       /// Método que solicita a acceso a datos un cliente natural en particular
       /// </summary>
       /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
       public ClienteNatural ConsultarClienteNatural(int id)
       {
           
           return baseDeDatosCliente.ConsultarClienteNatural(id); 
       }

       /// <summary>
       /// Método que solicita a acceso a datos la lista de todos los clientes juridicos
       /// </summary>
       /// <returns>Retorna una lista de Clientes Juridicos, null si el objeto no existe</returns>
       public List<ClienteJuridico> ConsultarClientesJuridicos()
       {
           return baseDeDatosCliente.ConsultarClientesJuridicos();
       }


       /// <summary>
       /// Método que solicita a acceso a datos la lista de todos los clientes naturales
       /// </summary>
       /// <returns>Retorna una lista de Clientes Naturales, null si el objeto no existe</returns>
       public List<ClienteNatural> ConsultarClientesNaturales()
       {
           return baseDeDatosCliente.ConsultarClientesNaturales();
       }


       /// <summary>
       /// Método que solicita a la capa de datos la información sobre los clientes jurídicos dado 
       /// un parámetro de búsqueda
       /// </summary>
       /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
       /// <returns>Retorna una lista de clientes jurídicos que cumplan con el 
       /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
       public List<ClienteJuridico> ConsultarClientesJuridicosParametrizados(string parametroBusqueda)
       {
           return baseDeDatosCliente.ConsultarClientesJuridicosParametrizados(parametroBusqueda);
       }

       /// <summary>
       /// Método que solicita a la capa de datos la información sobre los clientes naturales dado 
       /// un parámetro de búsqueda
       /// </summary>
       /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
       /// <returns>Retorna una lista de clientes naturales que cumplan con el 
       /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
       public List<ClienteNatural> ConsultarClientesNaturalesParametrizados(string parametroBusqueda)
       {
           return baseDeDatosCliente.ConsultarClientesNaturalesParametrizados(parametroBusqueda);
       }

       /// <summary>
       /// Método que llama acceso a datos para buscar el listado de cargos 
       /// a llenar
       /// </summary>
       /// <returns></returns>
       public List<string> LlenarComboCargo() 
       {
           List<string> cargos = new List<string>();
           cargos = baseDeDatosCliente.LlenarCargoCombo();
           return cargos; 
       }


    }
}
