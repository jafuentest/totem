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
    /// Clase que prueba la clase Lugar
    /// </summary>
    /// 
    [TestFixture]
   public class PruebaLugar
    {
        private Lugar lugar;

        /// <summary>
        /// Método que inicializa el objeto
        /// que va a ser utilizado durante toda 
        /// la prueba unitaria
        /// </summary>
        public void Init() 
        {
            lugar = new Lugar();
        }

        /// <summary>
        /// Prueba del Constructor Vacío de Lugar
        /// </summary>
        public void PruebaCtorVacioLugar() 
        {
            Assert.IsNotNull(lugar); 
        }

        /// <summary>
        /// Prueba de los Constructores con Parámetros de Lugar
        /// </summary>
        /// 
        [Test]
        public void PruebaCtresConParametrosLugar() 
        {
            //Constructor con Id y Nombre
            int id = 10;
            string nombre = "Nueva York";
            lugar = new Lugar(id,nombre);
            Assert.IsNotNull(id,nombre);

            //Id,Nombre del Lugar y Tipo de Lugar
            string tipo = "Ciudad";
            lugar = new Lugar(id,nombre,tipo);
            Assert.IsNotNull(lugar);


            //Id,Nombre del Lugar, Tipo de Lugar y el Id del Lugar al que pertenece
            int fkLugar = 2;
            lugar = new Lugar(id,nombre,tipo,fkLugar);
            Assert.IsNotNull(lugar);

            //Id,Nombre del Lugar, Tipo de Lugar, Código Postal y el Id del Lugar al que pertenece
            string codigoPrueba = "1020";
            lugar = new Lugar(id, nombre, tipo, codigoPrueba,fkLugar);
            Assert.IsNotNull(lugar);
        }

    }
}
