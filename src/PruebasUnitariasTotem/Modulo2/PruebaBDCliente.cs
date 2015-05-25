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
       private BDLugar baseDeDatosLugar; 
       private List<Lugar> listaLugares; 

       /// <summary>
       /// Método que inicializa el objeto en que 
       /// se van a realizar las pruebas
       /// </summary>
       [SetUp]
       public void Init() 
       {
           baseDeDatosCliente = new BDCliente();
           baseDeDatosLugar = new BDLugar(); 
       }


        /// <summary>
        /// Prueba el llenado de combo de paises
        /// </summary>
        [Test]
       public void PruebaLlenarCBPais() 
       {
           List<Lugar> lugares = new List<Lugar>();
           Lugar pais1 = new Lugar(1,"Venezuela");
           Lugar pais2 = new Lugar(18, "Estados Unidos");
           bool sonIguales = false; 
           lugares.Add(pais1);
           lugares.Add(pais2);

           Lugar l1;
            

           listaLugares = baseDeDatosLugar.LlenarCBPaisesBD();
           

           for (int i = 0; i < listaLugares.Count;i++ )
           {
               l1 = listaLugares[i];
               sonIguales=lugares[i].Equals(l1);

           }

           Assert.IsTrue(sonIguales);

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
