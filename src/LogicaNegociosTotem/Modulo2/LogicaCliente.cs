using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using DatosTotem.Modulo2;

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
       
       }

       

       /// <summary>
       /// Método que solicita a acceso a datos que inserte el cliente jurídico nuevo
       /// </summary>
       /// <param name="clienteJuridico">Información del Cliente Jurídico</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool AgregarClienteJuridico(ClienteJuridico clienteJuridico)
       {
           return baseDeDatosCliente.AgregarClienteJuridico(clienteJuridico);
       }


       /// <summary>
       /// Método que solicita a acceso a datos que inserte el cliente natural nuevo
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool AgregarClienteNatural(ClienteNatural clienteNatural)
       {
           return baseDeDatosCliente.AgregarClienteNatural(clienteNatural);
       }


       /// <summary>
       /// Método que le solicita a acceso a datos que borre el cliente natural seleccionado
       /// ,en la Base de Datos
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool EliminarClienteNatural(ClienteNatural clienteNatural)
       {
           return baseDeDatosCliente.EliminarClienteNatural(clienteNatural);
       }


       /// <summary>
       ///  Método que le solicita a acceso a datos que actualice los datos del cliente natural seleccionado, 
       /// en la Base de Datos
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool ModificarClienteNatural(ClienteNatural clienteNatural)
       {
           return baseDeDatosCliente.ModificarClienteNatural(clienteNatural);
       }


       /// <summary>
       ///  Método que le solicita a acceso a datos que actualice los datos del cliente jurídico seleccionado, 
       /// en la Base de Datos
       /// </summary>
       /// <param name="clienteNatural">Información del Cliente Natural</param>
       /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       public bool ModificarClienteJuridico(ClienteNatural clienteNatural)
       {
           return baseDeDatosCliente.ModificarClienteNatural(clienteNatural);
       }


       /// <summary>
       ///  Método que solicita a acceso a datos un cliente juridico en particular
       /// </summary>
       /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
       public ClienteJuridico ConsultarClienteJuridico(ClienteJuridico clienteJuridico)
       {
           return baseDeDatosCliente.ConsultarClienteJuridico(); 
       }


       /// <summary>
       /// Método que solicita a acceso a datos un cliente natural en particular
       /// </summary>
       /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
       public ClienteJuridico ConsultarClienteNatural(ClienteNatural clienteNatural)
       {
           return baseDeDatosCliente.ConsultarClienteNatural(); 
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



    }
}
