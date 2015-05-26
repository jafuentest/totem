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
        /// Prueba la lista de paises almacenados en BD
        /// para el llenado del Combo Box País
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
        /// Prueba el llenado de los estados almacenados 
        /// dado el id de un país, para el llenado del combo de los estados
        /// </summary>
        /// 
        [Test]
        public void PruebaLlenarCBEstado() 
        {
            List<Lugar> lugares = new List<Lugar>();
            int idPais=18; 
            Lugar pais1 = new Lugar(19, "Florida","Estado",18);
            Lugar pais2 = new Lugar(20, "Georgia","Estado",18);
            bool sonIguales = false;
            lugares.Add(pais1);
            lugares.Add(pais2);

            Lugar l1;


            listaLugares = baseDeDatosLugar.LlenarCBEstadosBD(idPais);


            for (int i = 0; i < listaLugares.Count; i++)
            {
                l1 = listaLugares[i];
                sonIguales = lugares[i].Equals(l1);

            }

            Assert.IsTrue(sonIguales);
            
        }

        /// <summary>
        /// Prueba el llenado de las ciudades almacenadas 
        /// dado el id de un estado, para el llenado de los combo box de ciudades
        /// </summary>
        /// 
        [Test]
        public void PruebaLlenarCBCiudad()
        {
            List<Lugar> lugares = new List<Lugar>();
            int idEstado = 19;
            Lugar pais1 = new Lugar(21, "Jacksonville", "Ciudad",19);
            Lugar pais2 = new Lugar(22, "Miami", "Ciudad",19);
            bool sonIguales = false;
            lugares.Add(pais1);
            lugares.Add(pais2);

            Lugar l1;


            listaLugares = baseDeDatosLugar.LlenarCBCiudadesBD(idEstado);


            for (int i = 0; i < listaLugares.Count; i++)
            {
                l1 = listaLugares[i];
                sonIguales = lugares[i].Equals(l1);

            }

            Assert.IsTrue(sonIguales);

        }
        
        /// <summary>
        /// Prueba el agregar un Cliente Juridico a Base de datos
        /// </summary>
        /// 
        [Test]
        public void PruebaAgregarClienteJuridico() 
        {
            ClienteJuridico cliente = new ClienteJuridico();
            cliente.Jur_Id = "J-231425-5";
            cliente.Jur_Nombre = "Venetur";
            
            int fkLugar = 26;

            Assert.IsTrue(baseDeDatosCliente.AgregarClienteJuridico(cliente,fkLugar));
                   
        }


        /// <summary>
        /// Prueba el agregar un Cliente Natural a Base de datos
        /// </summary>
        /// 
        [Test]
        public void PruebaAgregarClienteNatural()
        {
            ClienteNatural cliente = new ClienteNatural();
            cliente.Nat_Id = "11111111";
            cliente.Nat_Nombre = "Valentina";

            int fkLugar = 16;

            Assert.IsTrue(baseDeDatosCliente.AgregarClienteNatural(cliente, fkLugar));

        }
        /// <summary>
        /// Método que limpia el objeto que se probó 
        /// para que el Recolector de Basura lo recolecte
        /// </summary>
        [TearDown]
       public void Limpiar() 
       {
           baseDeDatosCliente = null;
           baseDeDatosLugar = null; 
       }

    }
}
