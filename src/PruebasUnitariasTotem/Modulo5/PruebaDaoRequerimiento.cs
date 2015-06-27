using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{
    [TestFixture]
    class PruebaDaoRequerimiento
    {
        DAO.Fabrica.FabricaDAOSqlServer fab;
        DAO.DAO.Modulo5.DAORequerimiento DAO;
        private Dominio.Entidades.Modulo5.Requerimiento requerimiento;

        [SetUp]
        public void init() {

            this.fab = new DAO.Fabrica.FabricaDAOSqlServer();
            this.DAO=fab.ObtenerDAORequerimiento() as DAO.DAO.Modulo5.DAORequerimiento;
            Dominio.Fabrica.FabricaEntidades fabrica = new Dominio.Fabrica.FabricaEntidades();
            this.requerimiento = fabrica.ObtenerRequerimiento() as Dominio.Entidades.Modulo5.Requerimiento;
            this.requerimiento.Id = 4;
            this.requerimiento.Codigo = "TOT_RF_2";
            this.requerimiento.Descripcion = "Prueba";
            this.requerimiento.Tipo = "Funcional";
            this.requerimiento.Prioridad = "Alta";
            this.requerimiento.CodigoProyecto = "1";
            this.requerimiento.Estatus = "Finalizado";
        }

        [Test]
        public void PruebaBuscarIdProyecto() {
            try
            {
                DAO.BuscarIdProyecto("TOT");
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD) { 
            }
            catch(ExcepcionesTotem.Modulo1.ParametroInvalidoException){
            }

        }

        [Test]
        public void PruebaVerificarRequerimiento() {
            try {
                DAO.VerificarRequerimiento(this.requerimiento);
            }
            catch(ExcepcionesTotem.Modulo5.RequerimientoInvalidoException){}
            catch(ExcepcionesTotem.ExceptionTotemConexionBD){}
            catch(ExcepcionesTotem.Modulo1.ParametroInvalidoException){}
        }

        [Test]
        public void PruebaEliminarRequerimiento() {

            try {
                DAO.EliminarRequerimiento(this.requerimiento);
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaConsultarRequerimiento() {
            try {
                DAO.ConsultarRequerimientoDeProyecto("TOT");
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        
        }

        [Test]
        public void PruebaObtenerCodigoRequerimiento() {
            try {
                DAO.ObtenerCodigoRequerimiento("TOT_RNF_1");
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaCodigoRequerimientoFuncional() {
            try
            {
                DAO.ObtenerCodigoRequerimientoFuncional(5);
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaCodigoRequerimientoNoFuncional()
        {
            try
            {
                DAO.ObtenerCodigoRequerimientoFuncional(4);
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaAgregar() {
            try
            {
                this.requerimiento.Codigo = "Prueba_01";
                DAO.Agregar(this.requerimiento);
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaModificar()
        {
            try
            {
                this.requerimiento.Codigo = "Prueba_01";
                this.requerimiento.Descripcion = "ModificarPrueba";
                DAO.Modificar(this.requerimiento);
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaConsultar()
        {
            try
            {

                this.requerimiento.Codigo = "TOT_RNF_1";
                DAO.ConsultarXId(this.requerimiento);
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException)
            {
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException)
            {
            }

        }

        [Test]
        public void PruebaConsultarTodos() {

            try {
                DAO.ConsultarTodos();
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD)
            {
            }
            catch (NotImplementedException) {  }

        }
        

    }
}
