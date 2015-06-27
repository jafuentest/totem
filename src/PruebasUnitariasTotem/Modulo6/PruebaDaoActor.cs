using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using DAO.DAO.Modulo6;
using DAO.Fabrica;

namespace PruebasUnitariasTotem.Modulo6
{  /// <summary>
    /// Pruebas Unitarias para la Clase DaoActor para la capa DAO
    /// </summary>
    [TestFixture]
    public class PruebaDaoActor
    {
        #region Prueba de Agregar Actor
        /// <summary>
        /// Método para verificar que inserte el actor
        /// </summary>
        [Test]
        public void AgregarActor()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();
            entidad.Id = 6;
            Actor actor = entidad as Actor;
            actor.NombreActor = "Estudiante";
            actor.DescripcionActor = "Presentar parciales";
            Proyecto proyecto = entidadProy as Proyecto;
            proyecto.Codigo = "TOT";
            actor.ProyectoAsociado = proyecto;
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsTrue(daoActor.Agregar(actor));
           
        }

        #endregion

        #region Prueba VerificarLaExistenciaDelActor
        /// <summary>
        /// Método para verificar que  el actor exista
        /// </summary>
        [Test]
        public void VerificarLaExistenciaDelActor()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Actor actor = entidad as Actor;
            actor.NombreActor = "Usuario";
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsTrue(daoActor.VerificarExistenciaActor(actor.NombreActor));

        }
        #endregion

        #region Prueba ConsultaActoresParaCombo
        /// <summary>
        /// Método para verificar que la lista de actores se pueda consultar
        /// </summary>
        [Test]
        public void ConsultaActoresParaCombo()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();
            Proyecto proyecto = entidadProy as Proyecto;
            proyecto.Codigo = "TOT";
            
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsNotNull(daoActor.ConsultarActoresCombo(proyecto.Codigo));

        }
        #endregion

        #region Prueba ConsultarActoresPorCasosDeUso
        /// <summary>
        /// Método para verificar que se pueda consultar los actores de acuerdo al caso de uso
        /// </summary>
        [Test]
        public void ConsultarActoresPorCasosDeUso()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerCasoDeUso();
            CasoDeUso Cuso = entidad as CasoDeUso;       
            Cuso.Id= 6;
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsNotNull(daoActor.ConsultarActoresXCasoDeUso(Cuso.Id));

        }
        #endregion

        #region Prueba ModificarActor
        /// <summary>
        /// Método para verificar que se modifique el actor
        /// </summary>
        [Test]
        public void ModificarActor()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();
            entidad.Id = 6;
            Actor actor = entidad as Actor;
            actor.NombreActor = "Estudiante";
            actor.DescripcionActor = "Presentar";
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsTrue(daoActor.Modificar(actor));

        }
        #endregion

        #region Prueba ConsultarActorPorId
        /// <summary>
        /// Método para consultar un actor de acuerdo al id 
        /// </summary>
        [Test]
        public void ConsultarActorPorId()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Actor actor = entidad as Actor;
            actor.Id = 2;
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsNotNull(daoActor.ConsultarXId(actor));
        }
        #endregion

        #region Prueba ConsultarListarPorActores
        /// <summary>
        /// Método que lista todos los actores 
        /// </summary>
        [Test]
        public void ConsultarListarPorActores()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            Entidad entidadProy = FabricaEntidades.ObtenerProyecto();
            Actor actor = entidad as Actor;
            Proyecto proyecto = entidadProy as Proyecto;
            proyecto.Codigo = "TOT";
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsNotNull(daoActor.ConsultarListarActores(proyecto.Codigo));

        }
        #endregion

        #region Prueba EliminarActor
        /// <summary>
        /// Método para verificar que elimine el actor
        /// </summary>
        [Test]
        public void EliminarActor()
        {
            FabricaEntidades fabrica = new FabricaEntidades();
            Entidad entidad = fabrica.ObtenerActor();
            entidad.Id = 6;
            FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
            DAO.IntefazDAO.Modulo6.IDaoActor daoActor = fabricaDAO.ObtenerDAOActor();
            Assert.IsTrue(daoActor.EliminarActor(entidad.Id));

        }
        #endregion

    }
}
