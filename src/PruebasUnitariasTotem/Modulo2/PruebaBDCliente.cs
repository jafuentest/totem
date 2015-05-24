using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using DatosTotem.Modulo2; 

namespace PruebasUnitariasTotem.Modulo2
{
    /// <summary>
    /// Clase para realizar las pruebas unitarias
    /// sobre la clase que gestiona el acceso a datos
    /// relacionada a la gestión de Clientes y Empresas
    /// </summary>
    [TestFixture]
   public class PruebaBDCliente
    {
       private BDCliente baseDeDatosCliente; 
        

       /// <summary>
       /// Método que inicializa el objeto en que 
       /// se van a realizar las pruebas
       /// </summary>
       [SetUp]
       public void Init() 
       {
           baseDeDatosCliente = new BDCliente(); 
       }


        /// <summary>
        /// Método que limpia el objeto que se probó 
        /// para que el Recolector de Basura lo recolecte
        /// </summary>
        [TearDown]
       public void Limpiar() 
       {
           baseDeDatosCliente = null;  
       }

    }
}
