using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem; 

namespace DatosTotem.Modulo2
{

    /// <summary>
    /// Clase encargada de acceder a la base de Datos relacionadas con la información sobre la gestión
    /// de Clientes y Empresas.
    /// </summary>
    public class BDCliente
    {
        /// <summary>
        /// Constructor de la Clase BDCliente
        /// </summary>
        public BDCliente() 
        {
        
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Agregar un Cliente Jurídico
        /// </summary>
        /// <param name="clienteJuridico">Información del Cliente Jurídico</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool AgregarClienteJuridico(ClienteJuridico clienteJuridico) 
        {
            throw new NotImplementedException(); 
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Agregar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool AgregarClienteNatural(ClienteNatural clienteNatural) 
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Eliminar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool EliminarClienteNatural(ClienteNatural clienteNatural)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Modificar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool ModificarClienteNatural(ClienteNatural clienteNatural)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Modificar un Cliente Jurídico
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool ModificarClienteJuridico(ClienteJuridico clienteNatural)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Jurídico en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteJuridico ConsultarClienteJuridico() 
        {
            throw new NotImplementedException();            
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Natural en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteJuridico ConsultarClienteNatural()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que accede a la Base de Datos para consultar una lista de Clientes Jurídicos
        /// </summary>
        /// <returns>Retorna una lista de Clientes Juridicos, null si el objeto no existe</returns>
        public List<ClienteJuridico> ConsultarClientesJuridicos()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Método que accede a la Base de Datos para consultar una lista de Clientes Naturales
        /// </summary>
        /// <returns>Retorna una lista de Clientes Naturales, null si el objeto no existe</returns>
        public List<ClienteNatural> ConsultarClientesNaturales()
        {
            throw new NotImplementedException();
        }


       /// <summary>
       /// Método que retorna una lista de Clientes Jurídicos dado un parámetro de búsqueda
       /// </summary>
       /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
       /// <returns>Retorna una lista de clientes jurídicos que cumplan con el 
       /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
        public List<ClienteJuridico> ConsultarClientesJuridicosParametrizados(string parametroBusqueda)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una lista de Clientes Naturales dado un parámetro de búsqueda
        /// </summary>
        /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
        /// <returns>Retorna una lista de clientes naturales que cumplan con el 
        /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
        public List<ClienteNatural> ConsultarClientesNaturalesParametrizados(string parametroBusqueda)
        {
            throw new NotImplementedException();
        }


    }
}
