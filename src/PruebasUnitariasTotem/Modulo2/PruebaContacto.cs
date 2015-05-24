using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using NUnit.Framework;
using NUnit.Mocks;

namespace PruebasUnitariasTotem.Modulo2
{

    /// <summary>
    /// Clase que realiza pruebas unitarias 
    /// a la Clase Contacto
    /// </summary>
    /// 
    [TestFixture]
   public class PruebaContacto
    {

        private Contacto contacto;
        private List<string> telefonos; 
        /// <summary>
        /// Método que inicializa el objeto de la
        /// clase a probar
        /// </summary>
        [SetUp]
        public void Init() 
        {
            contacto = new Contacto();
            telefonos = new List<string>(); 
        }

        #region Constructores

        /// <summary>
        /// Prueba para el constructor sin parámetros
        /// </summary>
        [Test]
        public void PruebaCtorVacio() 
        {
            Assert.IsNotNull(contacto); 
        }

        /// <summary>
        /// Pruebas para los constructores con parámetros
        /// de Contacto
        /// </summary>
        /// 
        [Test]
        public void PruebaCtorConParametrosContacto() 
        {
            //Con parámetro Id
            int id = 1;
            contacto = new Contacto(id);
            Assert.IsNotNull(contacto); 

            // Nombre y Apellido
            string nombre = "Mario";
            string apellido = "Gonzalez";
            contacto = new Contacto(nombre, apellido);
            Assert.IsNotNull(contacto);

            //Id, Nombre y Apellido
            contacto = new Contacto(id,nombre,apellido);
            Assert.IsNotNull(contacto);

            //Id, Nombre, Apellido y Cargo
            string cargo = "Gerente de Ventas";
            contacto = new Contacto(id, nombre, apellido,cargo);
            Assert.IsNotNull(contacto);
            
            //Id,Nombre,Apellido, Cargo y Teléfonos
            telefonos.Add("04123089765");
            telefonos.Add("02124568907");
            contacto = new Contacto(id, nombre, apellido, cargo,telefonos);
            Assert.IsNotNull(contacto); 
        }
        
        #endregion

        /// <summary>
        /// Método que limpia el objeto 
        /// utilizado en las pruebas unitarias 
        /// para
        ///  ser recolectado por el Recolector de Basura
        /// </summary>
        [TearDown]
        public void Limpiar() 
        {
            contacto = null; 
            telefonos = null;
        }

    }
}
