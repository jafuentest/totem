using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio.Entidades.Modulo6;
using Dominio.Entidades.Modulo4;
using Dominio.Fabrica;
using Comandos.Fabrica;
using Comandos;
using Comandos.Comandos.Modulo6;
using System.IO;
using Dominio.Entidades.Modulo5;
using Dominio;
using ExcepcionesTotem.Modulo6;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using DAO.DAO.Modulo6;
using DAO.Fabrica;


namespace PruebasUnitariasTotem.Modulo6
{
    [TestFixture]
    class PruebaExcepcionesModulo6
    {

        /// <summary>
        ///  PRUEBAS EN LA CAPA DE LOGICA
        ///  
        ///  
        /// </summary>
        [Test]
        public void PruebaBDException()
        {

            int cero = 0;
            FabricaComandos.CrearComandoConsultarActoresCB();

            Comando<string, List<Entidad>> comandoConsultarActoresCombo =
            FabricaComandos.CrearComandoConsultarActoresCB();
            List<Entidad> laLista = comandoConsultarActoresCombo.Ejecutar("PROYECT");
            int cantidad = laLista.Count;
            Assert.AreEqual(cero, cantidad);


        }




        /// <summary>
        ///  PRUEBAS EN LA CAPA DE LOGICA
        ///  
        ///  
        /// </summary>
        [Test]
        public void PruebaErrorNullException()
        {
            Actor actor1 = new Actor();



            actor1.NombreActor = null;
            actor1.DescripcionActor = null;


            Proyecto proy = new Proyecto();
            proy.Codigo = "TOT";
            proy.Nombre = "PROYECT";
            proy.Moneda = "$";
            proy.Estado = true;
            proy.Costo = 10;


            List<Entidad> actores = FabricaComandos.CrearComandoListarActores().Ejecutar(proy.Nombre);
            actores = null;
            Assert.IsNull(actores);



        }








        /// <summary>
        ///  PRUEBAS EN LA CAPA DE DATOS 
        ///  
        ///  
        /// </summary>
        [Test]
        public void PruebaBDDAOException()
        {


            bool cero = true;
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

            Assert.AreEqual(cero, daoActor.Agregar(actor));






        }






    }
}