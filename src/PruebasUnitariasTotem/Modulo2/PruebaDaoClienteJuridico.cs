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
    [TestFixture]
    class PruebaDaoClienteJuridico
    {
        FabricaDAOSqlServer lafabricaDao;
        IDaoClienteJuridico daoClienteJur;
        FabricaEntidades laFabricaEntidades;
        Entidad elCliente;
        List<Entidad> contactos;
        Entidad elContacto;
        Entidad elTelefono;
        Entidad laDireccion;

        [SetUp]
        public void init()
        {
            contactos = new List<Entidad>();
            lafabricaDao = new FabricaDAOSqlServer();
            laFabricaEntidades = new FabricaEntidades();
            laDireccion = laFabricaEntidades.ObtenerDireccion("Venezuela","Distrito Capital","Caracas","Parroquia Petare, Bloque 16, piso 4, apt 04","1020");
            elTelefono = laFabricaEntidades.ObtenerTelefono("0412", "6666668");
            elContacto = laFabricaEntidades.ObtenerContacto("66666667", "Alejandro", "Cortes", "Gerente General", elTelefono);
            contactos.Add(elContacto);
            elCliente = laFabricaEntidades.ObtenerClienteJuridico("Ados", contactos, laDireccion, "J-32222222-2", null);
        }

        [Test]
        public void pruebaConsultarTodos()
        {
            daoClienteJur = lafabricaDao.ObtenerDaoClienteJuridico();
            Assert.IsNotEmpty(daoClienteJur.ConsultarTodos());
        }

        [Test]
        public void pruebaConsultarPaises()
        {
            daoClienteJur = lafabricaDao.ObtenerDaoClienteJuridico();
            Assert.IsNotEmpty(daoClienteJur.consultarPaises());
        }

        [Test]
        public void pruebaConsultarEdosXPais()
        {
            daoClienteJur = lafabricaDao.ObtenerDaoClienteJuridico();
            Assert.IsNotEmpty(daoClienteJur.consultarEstadosPorPais("Venezuela"));
        }

        [Test]
        public void pruebaConsultarListaDeCargos()
        {
            daoClienteJur = lafabricaDao.ObtenerDaoClienteJuridico();
            Assert.IsNotEmpty(daoClienteJur.consultarListaCargos());
        }


    }
}
