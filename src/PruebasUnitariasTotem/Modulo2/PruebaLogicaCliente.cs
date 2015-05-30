using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using LogicaNegociosTotem.Modulo2;

namespace PruebasUnitariasTotem.Modulo2
{

    /// <summary>
    /// Prueba unitaria sobre la clase Logica Cliente
    /// </summary>
    [TestFixture]
    public class PruebaLogicaCliente
    {
        LogicaCliente logicaCliente;
        ClienteJuridico clienteJ; 

        /// <summary>
        /// Método que inicializa 
        /// la clase a probar
        /// </summary>
        [SetUp]
        public void Init() 
        {
            logicaCliente = new LogicaCliente();
            
            ClienteJuridico clienteJ = new ClienteJuridico(); 
        }

        
        /// <summary>
        /// Se prueba que la clase pueda agregar 
        /// a los clientes jurídicos
        /// </summary>
        /// 
        [Test]
        public void PruebaAgregarClienteJuridicoLogica() 
        {
            
            string nombreCliente = "Venetur"; 
            string rif = "J-2389183-5"; 

            int fkLugar = 26;
            string direccion ="La Rue dsjakd AV. dksajdkja";
            string contactoNombre="Petronila";
            string contactoApellido="Bustillo";
            Assert.IsTrue(logicaCliente.AgregarClienteJuridico(rif,nombreCliente,fkLugar,
                direccion,contactoNombre,contactoApellido,4,"412768906","20645890"));
        }


        /// <summary>
        /// Se prueba que la clase pueda agregar 
        /// a los clientes naturales
        /// </summary>
        /// 
        [Test]
        public void PruebaAgregarClienteNaturalLogica()
        {

            string nombreCliente = "Minerva";
            string identificador = "18039228";
            string apellido = "Lopez";
            int fkLugar = 16;
            string direccion = "Av. Las Piedras, con calle El Prado";
            string correo = "minerva10@gmail.com";
            string telefono = "02124567890";
            

            Assert.IsTrue(logicaCliente.AgregarClienteNatural(identificador, nombreCliente,apellido,
                fkLugar, direccion, correo, telefono));
        }


        /// <summary>
        /// Se prueba que la clase pueda modificar 
        /// tanto clientes naturales como jurídicos
        /// </summary>
        public void PruebaModificar() 
        { 
        
        }


        /// <summary>
        /// Se prueba el método que elimina clientes naturales
        /// </summary>
        /// 
        [Test]
        public void PruebaEliminarClienteNatural() 
        {
            string cedula = "33333333";
            Assert.IsTrue(logicaCliente.EliminarClienteNatural(cedula));
        }

        /// <summary>
        /// Se prueba el método que lista todos los clientes
        /// naturales registrados en la Base de Datos
        /// </summary>
        public void PruebaListarClientesNaturales() { }

        /// <summary>
        /// Se prueba el método que lista a todos los clientes
        /// jurídicos registrados en la Base de Datos
        /// </summary>
        public void PruebaListarClientesJuridicos() { }


        /// <summary>
        /// Se prueba el método que prueba
        /// consultar a un cliente natural dado su id
        /// </summary>
        /// 
        [Test]
        public void PruebaConsultarClienteNaturalLogica() 
        {
            bool sonIguales = false;
            ClienteNatural cliente = new ClienteNatural();
            Lugar lugar = new Lugar();
            string telefono = "2121111111";
            List<string> telefonos = new List<string>();
            telefonos.Add(telefono);
            lugar.NombreLugar = "Caracas";
            lugar.CodigoPostal = "1020";
            int id = 1;
            cliente.Nat_Id = "11111111";
            cliente.Nat_Nombre = "Valentina";
            cliente.Nat_Apellido = "Scioli";
            cliente.Nat_Correo = "Gerente de Proyectos";
            cliente.Nat_Pais = "Venezuela";
            cliente.Nat_Estado = "Dtto Capital";
            cliente.Nat_Ciudad = lugar;

            cliente.Nat_Telefonos = telefonos;

            ClienteNatural clienteActual = logicaCliente.ConsultarClienteNatural(id);
            sonIguales = cliente.Equals(clienteActual);

            Assert.IsTrue(sonIguales); 
        }

        /// <summary>
        /// Se prueba el método que prueba
        /// consultar a un cliente jurídico dado su id
        /// </summary>
        public void PruebaConsultarClienteJuridico() 
        {
            
        }
/*
        /// <summary>
        /// Prueba del llenado del Combo de Pais
        /// </summary>
        /// 
        [Test]
        public void PruebaLlenarComboPais() 
        {
            List<Lugar> paises = new List<Lugar>();
            paises.Add(new Lugar(1,"Venezuela"));
            paises.Add(new Lugar(18, "Estados Unidos"));

            //List<Lugar> paisesObtenidos = logicaCliente.LlenarCBPaises();

            //Assert.AreEqual(paises,paisesObtenidos); 

        }*/

        /// <summary>
        /// Método que vacía el objeto utilizado durante 
        /// todas las pruebas para ser limpiado por el 
        /// Recolector de Basura
        /// </summary>
        /// 
        [TearDown]
        public void Limpiar() 
        {
            logicaCliente = null; 
        }

    }
}
