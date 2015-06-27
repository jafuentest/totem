using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dominio.Entidades.Modulo2;
using Dominio.Fabrica;
using Datos.DAO;
using Datos.Fabrica;
using Datos.IntefazDAO.Modulo2;
using Dominio;

namespace PruebasUnitariasTotem.Modulo2
{
    /// <summary>
    /// Declaracion de variables que se van a usar en las pruebas
    /// </summary>
    [TestFixture]
    class PruebaDaoClienteNatural
    {
        FabricaDAOSqlServer lafabricaDao;
        IDaoClienteNatural daoClienteNatural;
        FabricaEntidades laFabricaEntidades;
        Entidad elCliente;
        Entidad laDireccion;
        Entidad elTelefono;
        Entidad elCliente2;
        Entidad laDireccion2;
        Entidad elTelefono2;
        Entidad elCliente3;
        bool resultado;

        /// <summary>
        /// inicializacion de variables a usar en las pruebas
        /// </summary>
        [SetUp]
        public void init()
        {
            lafabricaDao = new FabricaDAOSqlServer();
            laFabricaEntidades = new FabricaEntidades();
            laDireccion = laFabricaEntidades.ObtenerDireccion("Venezuela", "Miranda", "Guarenas", "Nueva Casarapa, Calle 5, Edif Casarapa", "3223");
            elTelefono = laFabricaEntidades.ObtenerTelefono("0424", "1188439");
            elCliente = laFabricaEntidades.ObtenerClienteNatural("Gonzalo", "Machado", "aucb221@gmail.com", laDireccion, elTelefono, "10351484");
            
             laDireccion2 = laFabricaEntidades.ObtenerDireccion("Venezuela", "Miranda", "Guarenas", "La Callena, Calle 3, Edif La Flor", "3293");
            elTelefono2 = laFabricaEntidades.ObtenerTelefono("0424", "1138419");
            elCliente2 = laFabricaEntidades.ObtenerClienteNatural("Jose","Oberto","jmoc23@gmail.com",laDireccion2,elTelefono2,"9381223");

            elCliente3 = laFabricaEntidades.ObtenerClienteNatural();
        }

        /// <summary>
        /// prueba para agregar un cliente natural
        /// </summary>
        [Test]
        public void pruebaAgregarClienteNat()
        {
            daoClienteNatural = lafabricaDao.ObtenerDaoClienteNatural();
            Assert.IsTrue(daoClienteNatural.Agregar(elCliente));

        }

        /// <summary>
        /// prueba para consultar un cliente por id
        /// </summary>
        [Test]
        public void pruebaConsultarXID()
        {
            daoClienteNatural = lafabricaDao.ObtenerDaoClienteNatural();
            daoClienteNatural.Agregar(elCliente2);

            elCliente3 = daoClienteNatural.ConsultarXId(elCliente2);

            Assert.AreEqual(elCliente3.Id, elCliente2.Id);
        }

        /// <summary>
        /// prueba para consultar todos los clientes naturales
        /// </summary>
        [Test]
        public void pruebaConsultarTodos()
        {
            daoClienteNatural = lafabricaDao.ObtenerDaoClienteNatural();
            Assert.IsNotEmpty(daoClienteNatural.ConsultarTodos());
            
        }

        /// <summary>
        /// prueba para modificar un cliente
        /// </summary>
        [Test]
        public void pruebaModificarClienteNat()
        {
            elCliente = laFabricaEntidades.ObtenerClienteNatural("Gonzalo", "Machado", "aucb221@gmail.com", laDireccion, elTelefono, "9881668");
            daoClienteNatural = lafabricaDao.ObtenerDaoClienteNatural();
            Assert.IsTrue(daoClienteNatural.Modificar(elCliente));
            
        }

    }
}
