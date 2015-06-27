using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo5
{
    /// <summary>
    /// Clase encargada de probar la clase DAO
    /// </summary>
    [TestFixture]
    class PruebaDaoRequerimiento
    {
        /// <summary>
        /// Atributos
        /// </summary>
        Datos.Fabrica.FabricaDAOSqlServer fab;
        Datos.DAO.Modulo5.DAORequerimiento DAO;
        private Dominio.Entidades.Modulo5.Requerimiento requerimiento;
        
        /// <summary>
        ///Inicializacion de los atributos 
        /// </summary>
        [SetUp]
        public void init() {

            this.fab = new Datos.Fabrica.FabricaDAOSqlServer();
            this.DAO=fab.ObtenerDAORequerimiento() as Datos.DAO.Modulo5.DAORequerimiento;
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
        
        /// <summary>
        /// Prueba de BuscarIdProyecto
        /// </summary>
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


        /// <summary>
        /// Prueba de VerificarRequerimiento
        /// </summary>
        [Test]
        public void PruebaVerificarRequerimiento() {
            try {
                DAO.VerificarRequerimiento(this.requerimiento);
            }
            catch(ExcepcionesTotem.Modulo5.RequerimientoInvalidoException){}
            catch(ExcepcionesTotem.ExceptionTotemConexionBD){}
            catch(ExcepcionesTotem.Modulo1.ParametroInvalidoException){}
        }

        /// <summary>
        /// Prueba de EliminarRequerimiento
        /// </summary>
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

        /// <summary>
        /// Prueba de ConsultarRequerimientoDeProyecto 
        /// </summary>
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

        /// <summary>
        ///Prueba de ObtenerCodigoRequerimiento
        /// </summary>
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

        /// <summary>
        /// Prueba de ObtenerCodigoRequerimientoFuncional
        /// </summary>
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

        /// <summary>
        /// Prueba de ObtenerCodigoRequerimientoFuncional
        /// </summary>
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

        /// <summary>
        /// Prueba de Agregar 
        /// </summary>
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

        /// <summary>
        /// Prueba de Modificar  
        /// </summary>
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

        /// <summary>
        /// Prueba de ConsultarXId
        /// </summary>
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

        /// <summary>
        /// Prueba de ConsultarTodos
        /// </summary>
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
