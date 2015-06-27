﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dominio.Entidades.Modulo4;
//using Datos; 

namespace PruebasUnitariasTotem.Modulo4
{
    class PruebasDAOProyecto
    {

        [TestFixture]
        class PruebaDaoProyecto
        {
            #region Atributos
            private String elNombre;
            private String elCodigo;
            private String laMoneda;
            private String laDescripcion;
           // private List<Requerimiento> listaRequerimientos =
              // new List<Requerimiento>();
            #endregion

            #region SetUp & TearDown
            [SetUp]
            public void init()
            {
                elNombre = "ProyectoPrueba";
                elCodigo = "PRU";
                laMoneda = "$";
                laDescripcion = "Descripcion Prueba";
                //listaRequerimientos =
                  // new List<Requerimiento>();
            }
            [TearDown]
            public void clean()
            {
                elNombre = "";
                elCodigo = "";
                laMoneda = "";
                laDescripcion = "";
                //listaRequerimientos = null;
            }
            #endregion

            #region Pruebas unitarias
            [Test]
            public void PruebaExiste()
            {
                int id=1;
                //id = DatosTotem.Modulo5.BDRequerimiento.
                //   RetornarIdPorCodigoProyecto(elCodigo);
              //  Assert.IsTrue(DAO.DAO.Modulo4.DAOProyecto.existeProyecto(id));
            }
            [Test]
            public void PruebaAgregarProyecto()
            {
                Proyecto proyecto_prueba = new Proyecto(elCodigo, elNombre, laDescripcion, laMoneda);
               // Assert.IsTrue(DAO.DAO.Modulo4.DAOProyecto.Agregar(proyecto_prueba));
            }
            #endregion
        }
    }
}