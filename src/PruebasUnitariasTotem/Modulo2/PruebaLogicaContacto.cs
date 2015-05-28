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
    public class PruebaLogicaContacto
    {
        LogicaContacto logicaContacto;
        Contacto contacto;

        /// <summary>
        /// Método que inicializa 
        /// la clase a probar
        /// </summary>
        [SetUp]
        public void Init()
        {
            logicaContacto = new LogicaContacto();

            Contacto contacto = new Contacto();
        }


        /// <summary>
        /// Se prueba que la clase pueda agregar 
        /// a los clientes jurídicos
        /// </summary>
        /// 
        [Test]
        public void PruebaConsultarContactoLogica()
        {

            string nombre = "Valentina";
            string apellido = "Scioli";
            int cedula = 11111111;


           int  identificador = 6;
            Assert.AreSame(logicaContacto.ConsultarDatosDeContacto(identificador).Con_Nombre, nombre);
            Assert.AreSame(logicaContacto.ConsultarDatosDeContacto(identificador).Con_Apellido, apellido);
            Assert.AreSame(logicaContacto.ConsultarDatosDeContacto(identificador).Con_Id, cedula);
                 
        
        
        
        }

 

         

        /// <summary>
        /// Método que vacía el objeto utilizado durante 
        /// todas las pruebas para ser limpiado por el 
        /// Recolector de Basura
        /// </summary>
        /// 
        [TearDown]
        public void Limpiar()
        {
            logicaContacto = null;
        }

    }
}
