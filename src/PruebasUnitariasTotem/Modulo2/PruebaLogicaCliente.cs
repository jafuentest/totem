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

        //    Assert.IsTrue(logicaCliente.AgregarClienteJuridico(rif,nombreCliente,fkLugar));
        }


        /// <summary>
        /// Se prueba que la clase pueda agregar 
        /// a los clientes naturales
        /// </summary>
        /// 
       /* [Test]
        public void PruebaAgregarClienteNaturalLogica()
        {

            string nombreCliente = "Minerva";
            string identificador = "18039228";

            int fkLugarn = 26;

            Assert.IsTrue(logicaCliente.AgregarClienteNatural(identificador, nombreCliente, fkLugarn));
        }*/


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
        public void PruebaEliminarClienteNatural() 
        {
        
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
        public void PruebaConsultarClienteNatural() { }

        /// <summary>
        /// Se prueba el método que prueba
        /// consultar a un cliente jurídico dado su id
        /// </summary>
        public void PruebaConsultarClienteJuridico() { }
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
