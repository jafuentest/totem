using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using DatosTotem.Modulo2;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;

namespace LogicaNegociosTotem.Modulo2
{
    /// <summary>
    /// Clase para el manejo de la logica
    /// de clientes juridicos y naturales
    /// con sus contactos
    /// </summary>
    public static class LogicaCliente
    {
        public static void agregarClienteJuridico(ClienteJuridico elCliente)
        {
            try
            {
                BDCliente.agregarClienteJuridico(elCliente);
            }
            catch (Exception ex)
            {

            }
        }
        public static List<ClienteJuridico> consultarListaClientesJuridicos()
        {
            try
            {
                return BDCliente.consultarListaClientesJuridicos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ClienteJuridico consultarDatosClienteJuridicoId(int idClienteJur)
        {
            try
            {
                return BDCliente.consultarDatosClienteJuridicoId(idClienteJur);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Contacto consultarDatosContactoID(int idCon)
        {
            try
            {
                return BDCliente.consultarDatosContactoID(idCon);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Contacto> consultarListaDeContactosJuridico(ClienteJuridico elCliente)
        {
            try
            {
                return BDCliente.consultarListaDeContactosJuridico(elCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void eliminarClienteJuridico(ClienteJuridico elCliente)
        {
            try
            {
                BDCliente.eliminarClienteJuridico(elCliente);
            }
            catch(Exception ex)
            {

            }
        }
        public static void eliminarContacto(Contacto elContacto)
        {
            try
            {
                BDCliente.eliminarContacto(elContacto);
            }
            catch (Exception ex)
            {

            }
        }
        public static void modificarClienteJuridico(ClienteJuridico elCliente)
        {
            try
            {
                BDCliente.modificarClienteJuridico(elCliente);
            }
            catch(Exception ex)
            {

            }
        }
        public static void agregarClienteNatural(ClienteNatural elCliente)
        {
            try
            {
                BDCliente.agregarClienteNatural(elCliente);
            }
            catch(Exception ex)
            {

            }
        }
        public static List<ClienteNatural> consultarListaClientesNaturales()
        {
            try
            {
                return BDCliente.consultarListaClientesNaturales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ClienteNatural consultarDatosClienteNaturalId(int idClienteNat)
        {
            try 
            {
                return BDCliente.consultarDatosClienteNaturalId(idClienteNat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void eliminarClienteNatural(ClienteNatural elCliente)
        {
            try
            {
                BDCliente.eliminarClienteNatural(elCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void modificarClienteNatural(ClienteNatural elCliente)
        {
            try
            {
                BDCliente.modificarClienteNatural(elCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<String> consultarPaises()
        {
            try
            {
                return BDCliente.consultarPaises();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<String> consultarEstadosPorPais(String elPais)
        {
            try
            {
                return BDCliente.consultarEstadosPorPais(elPais); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<String> consultarCiudadesPorEstado(String elEstado)
        {
            try
            {
                return BDCliente.consultarCiudadesPorEstado(elEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
    }
}
