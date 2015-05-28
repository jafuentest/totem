using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using DatosTotem.Modulo2;


namespace PruebasUnitariasTotem.Modulo2
{ /// <summary>
    /// Clase para realizar las pruebas unitarias
    /// sobre la clase que gestiona el acceso a datos
    /// relacionada a la gestión de Clientes y Empresas
    /// </summary>
    [TestFixture]
    public class PruebaBDContacto
    {
        private BDContacto baseDeDatosContacto;
        private int identificador;
         

        /// <summary>
        /// Método que inicializa el objeto en que 
        /// se van a realizar las pruebas
        /// </summary>
        [SetUp]
        public void Init()
        {
            baseDeDatosContacto = new BDContacto();
            
        }


      
        /// <summary>
        /// Prueba el agregar un Consultar Contacto en la Base de datos
        /// </summary>
        /// 
        [Test]
        public void PruebaConsultarContactoBD()
        {
             
            string nombre = "Valentina";
            string apellido="Scioli";
            int cedula = 11111111; 
        
            
            identificador = 6;
            Assert.AreSame(baseDeDatosContacto.ConsultarDatosDeContacto(identificador).Con_Nombre, nombre);
            Assert.AreSame(baseDeDatosContacto.ConsultarDatosDeContacto(identificador).Con_Apellido, apellido);
            Assert.AreSame(baseDeDatosContacto.ConsultarDatosDeContacto(identificador).Con_Id, cedula);
                  
        
        }


        
        /// <summary>
        /// Método que limpia el objeto que se probó 
        /// para que el Recolector de Basura lo recolecte
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            baseDeDatosContacto = null;
            identificador = 0;
        }

    }
}
