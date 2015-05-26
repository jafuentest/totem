using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem; 

namespace PruebasUnitariasTotem.Modulo2
{

    /// <summary>
    /// Pruebas unitarias sobre las clases
    /// Cliente Juridico y Cliente Natural
    /// </summary>
    /// 
    [TestFixture]
    public class PruebaCliente
    {
        private ClienteJuridico clienteJuridico;
        private ClienteNatural clienteNatural;
        private List<string> telefonos;
        private List<Contacto> contactos; 

        /// <summary>
        /// Método que inicializa los valores 
        /// iniciales de las clases para ser 
        /// probados durante toda esta prueba unitaria
        /// </summary>
        /// 
        [SetUp]
        public void Init() 
        {
            clienteNatural = new ClienteNatural(); 
            clienteJuridico = new ClienteJuridico();
            telefonos = new List<string>();
            contactos = new List<Contacto>(); 

        }

        #region Prueba de los Constructores
        

        /// <summary>
        /// Prueba sobre los constructores vacíos
        /// de la clase Cliente Jurídico y Cliente 
        /// Natural
        /// </summary>
        [Test]
        public void PruebaCtroVacioCliente()
        {
            Assert.IsNotNull(clienteJuridico);
            Assert.IsNotNull(clienteNatural); 
        }


        /// <summary>
        /// Pruebas sobre los constructores con parámetros 
        /// de la Clase Cliente Natural
        /// </summary>
        [Test]
        public void PruebaCtoresClienteNaturalConParametros() 
        {
            //Prueba con parámetros de nombre y apellido
            string nombre = "Alfonso";
            string apellido = "Carrasco";
            clienteNatural = new ClienteNatural(nombre,apellido);
            Assert.IsNotNull(clienteNatural);

            //Nombre, apellido y cédula
            string cedula = "20631987";
            clienteNatural = new ClienteNatural(cedula, nombre, apellido);
            Assert.IsNotNull(clienteNatural);

            //Nombre, Apellido,Cédula y Correo
            string correo = "alfonsocarrasco@gmail.com";
            clienteNatural = new ClienteNatural(cedula,nombre,apellido,correo);
            Assert.IsNotNull(clienteNatural);

            //Nombre, Apellido, Cédula, Correo, País, Estado , Ciudad y Dirección
            string pais = "Venezuela";
            string estado = "Dtto Capital";
            Lugar lugar = new Lugar(21,"Caracas","Ciudad","1020",1);
            string direccion = "Avenida La Salle con cruce calle villaflor, frente al McDonald's" 
                               +",La Florida.Caracas.Venezuela";
            clienteNatural = new ClienteNatural(cedula, nombre, apellido, correo,
                pais,estado,lugar,direccion);
            Assert.IsNotNull(clienteNatural);

            //Nombre, Apellido, Cédula, Correo, País, Estado , Ciudad, Dirección y Teléfonos
            telefonos.Add("04125985004");
            telefonos.Add("04126485404");
            clienteNatural = new ClienteNatural(cedula, nombre, apellido, correo,
                pais, estado, lugar, direccion,telefonos);
            Assert.IsNotNull(clienteNatural);
          
        }


        /// <summary>
        /// Pruebas sobre los constructores de la 
        /// clase Cliente Juridico
        /// </summary>
        [Test]
        public void PruebaCtoresClienteJuridicoConParametros() 
        {
            //Parámetro del constructor que recibe el nombre
            //de la empresa
            string nombre = "Veneden";
            clienteJuridico = new ClienteJuridico(nombre);
            Assert.IsNotNull(clienteJuridico);
 
            //Rif de la Empresa
            string rif = "J-5467901-5";
            clienteJuridico = new ClienteJuridico(rif,nombre);
            Assert.IsNotNull(clienteJuridico);

            //RIF,Nombre y Dirección de la Empresa
            string direccion = "Avenida La Salle con cruce calle villaflor, frente al McDonald's"
                               +",La Florida.Caracas.Venezuela";
            clienteJuridico = new ClienteJuridico(rif, nombre,direccion);
            Assert.IsNotNull(clienteJuridico);

            //RIF,Nombre, Dirección de la Empresa 
            Lugar lugar = new Lugar(22,"Valencia","Ciudad","1012",1);
            clienteJuridico = new ClienteJuridico(rif, nombre,"Venezuela","Carabobo",lugar,direccion);
            Assert.IsNotNull(clienteJuridico);

            //RIF,Nombre, Dirección de la Empresa y telefonos
            telefonos.Add("02127658976");
            telefonos.Add("04127658907");
            clienteJuridico = new ClienteJuridico(rif, nombre,"Venezuela","Carabobo",lugar,
                direccion,telefonos);
            Assert.IsNotNull(clienteJuridico);


            //RIF,Nombre, Dirección de la Empresa, teléfonos y contactos
            Contacto primerContacto = new Contacto(1,"Hector","Rondon","Gerente General",
                                      telefonos);
            Contacto segundoContacto = new Contacto(2, "Roberto", "Dominguez", "Administrador",
                                       telefonos);
            contactos.Add(primerContacto);
            contactos.Add(segundoContacto); 

            clienteJuridico = new ClienteJuridico(rif, nombre,"Venezuela","Carabobo",lugar,
                direccion,telefonos,contactos);
            Assert.IsNotNull(clienteJuridico);
            

        }
        

        #endregion




        /// <summary>
        /// Método que limpia 
        /// los objetos utilizados durante las pruebas
        /// para ser recolectados por el Recolector de Basura
        /// </summary>
        
        [TearDown]
        public void Limpiar() 
        {
            clienteJuridico = null;
            clienteNatural = null; 
        }

    }
}
