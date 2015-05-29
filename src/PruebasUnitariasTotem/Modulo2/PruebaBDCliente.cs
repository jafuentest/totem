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
       /* [Test]
        public void PruebaAgregarClienteJuridicoBD() 
        {
            ClienteJuridico cliente = new ClienteJuridico();
            cliente.Jur_Id = "J-231425-5";
            cliente.Jur_Nombre = "Venetur";
            
            int fkLugar = 26;

            Assert.IsTrue(baseDeDatosCliente.AgregarClienteJuridico(cliente,fkLugar));
                   
        }*/


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
        /// Prueba del método que consulta a un cliente natural por id
        /// </summary>
        /// 
        [Test]
        public void PruebaConsultarClienteNaturalXId() 
        {
            bool sonIguales = false; 
            ClienteNatural cliente = new ClienteNatural();
            Lugar lugar = new Lugar();
            string telefono = "2121111111";
            List<string> telefonos = new List<string>();
            telefonos.Add(telefono);
            lugar.NombreLugar ="Caracas";
            lugar.CodigoPostal="1020";
            int id = 1;
            cliente.Nat_Id = "11111111";
            cliente.Nat_Nombre = "Valentina";
            cliente.Nat_Apellido = "Scioli";
            cliente.Nat_Correo = "Gerente de Proyectos";
            cliente.Nat_Pais = "Venezuela";
            cliente.Nat_Estado = "Dtto Capital";
            cliente.Nat_Ciudad = lugar;

            cliente.Nat_Telefonos = telefonos;

            ClienteNatural clienteActual = baseDeDatosCliente.ConsultarClienteNatural(id);
            sonIguales = cliente.Equals(clienteActual);
                        
            Assert.IsTrue(sonIguales); 
        }

        /// <summary>
        /// Método que prueba, el método que elimina a un cliente natural de la Base de Datos 
        /// </summary>
        /// 
        [Test]
        public void PruebaEliminarClienteNatural() 
        {
            bool sonIguales = false; 
            ClienteNatural cliente = new ClienteNatural();
            int id = 4; 
            cliente.Nat_Id = "44444444";
            cliente.Nat_Nombre = "Pedro";
            cliente.Nat_Apellido = "De Jesus";
            cliente.Nat_Correo = "pedrdejesus@gmail.com";

            ClienteNatural clienteActual = baseDeDatosCliente.ConsultarClienteNatural(id);
            sonIguales = cliente.Equals(clienteActual);

            Assert.IsTrue(sonIguales); 
        }

        /// <summary>
        /// Método que prueba el método de consultar los datos
        /// detallados de un cliente jurídico dado su id
        /// </summary>
        /// 
        [Test]
        public void PruebaConsultarClienteJuridicoXId() 
        {
            int id = 1; 
            bool sonIguales = false;
            ClienteJuridico clienteJur = new ClienteJuridico();
            Lugar lug = new Lugar();
            lug.NombreLugar = "Caracas";
            lug.CodigoPostal = "1020";
            List<Contacto> contactos = new List<Contacto>();
            List<string> telefonos = new List<string>();
            string telefono = "4126666666";
            telefonos.Add(telefono);
            Contacto contacto = new Contacto("Reinaldo","Cortes");
            contactos.Add(contacto);

            clienteJur.Jur_Id = "J-11111111-1";
            clienteJur.Jur_Nombre = "Locatel";
            clienteJur.Jur_Pais = "Venezuela";
            clienteJur.Jur_Estado = "Dtto Capital";
            clienteJur.Jur_Ciudad = lug;
            clienteJur.Jur_Direccion = "Parroquia Altagracia, Calle Guaicaipuro,"
                                       +"Local 76, Bello Monte";
            clienteJur.Jur_Contactos = contactos;
            clienteJur.Jur_Telefonos = telefonos;

            ClienteJuridico clienteActual = baseDeDatosCliente.ConsultarClienteJuridico(id);
            sonIguales = clienteJur.Equals(clienteActual);
            Assert.IsTrue(sonIguales); 
        
        }
        /// <summary>
        /// Método que prueba el método de probar 
        /// la existencia o no de un Cliente(Natural o Jurídico)
        /// en Base de Datos
        /// </summary>
        /// 
        [Test]
        public void PruebaVerificarExistenciaCliente() 
        {
            string cedulaExistente = "11111111";
            string cedulaNoExistente = "77777777";
            string rifExistente = "J-22222222-2";
            string rifNoExistente = "J-77777777-7";

            Assert.AreEqual(1, 
                baseDeDatosCliente.VerificarExistenciaClienteNatural(cedulaExistente));
            Assert.AreEqual(0, 
                baseDeDatosCliente.VerificarExistenciaClienteNatural(cedulaNoExistente));
            Assert.AreEqual(1,
                baseDeDatosCliente.VerificarExistenciaClienteJuridico(rifExistente));
            Assert.AreEqual(0,
                baseDeDatosCliente.VerificarExistenciaClienteJuridico(rifNoExistente));
        
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
