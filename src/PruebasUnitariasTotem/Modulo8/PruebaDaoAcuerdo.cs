using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dominio.Entidades.Modulo8;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo2;
using DAO.DAO.Modulo8;
using DAO.Fabrica;
using Dominio.Fabrica;
using Dominio;

namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase DAOAcuerdo
    /// </summary>
    [TestFixture]
    class PruebaDaoAcuerdo
    {
        Acuerdo acuerdo;
        FabricaDAOSqlServer fabricaDAO;
        List<Usuario> listaUsuarios;
        List<Contacto> listaContactos;
        DAO.IntefazDAO.Modulo8.IDaoAcuerdo DAOAcuerdo;

        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {
            FabricaEntidades fabricaEntidades = new FabricaEntidades();
            fabricaDAO = new FabricaDAOSqlServer();
            DAOAcuerdo = fabricaDAO.ObtenerDAOAcuerdo();
            acuerdo = (Acuerdo)fabricaEntidades.ObtenerAcuerdo();
            listaUsuarios = new List<Usuario>();
            listaContactos = new List<Contacto>();
            Usuario usuario1 = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuario1.Id = 1;
            usuario1.Nombre = "Alberto";
            usuario1.Apellido = "Da Silva";
            usuario1.Rol = "Administrador";
            usuario1.Cargo = "1";
            Usuario usuario2 = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuario2.Id = 2;
            usuario2.Nombre = "Argenis";
            usuario2.Apellido = "Rodriguez";
            usuario2.Rol = "Administrador";
            usuario2.Cargo = "2";
            Usuario usuario3 = (Usuario)fabricaEntidades.ObtenerUsuario();
            usuario3.Id = 3;
            usuario3.Nombre = "Scheryl";
            usuario3.Apellido = "Palencia";
            usuario3.Rol = "Usuario";
            usuario3.Cargo = "3";
            Contacto contacto1 = (Contacto)fabricaEntidades.ObtenerContacto();
            contacto1.Id = 1;
            contacto1.Con_Nombre = "Reinaldo";
            contacto1.Con_Apellido = "Cortes";
            contacto1.ConCargo = "1";
            Contacto contacto2 = (Contacto)fabricaEntidades.ObtenerContacto();
            contacto2.Id = 2;
            contacto2.Con_Nombre = "Mercedes";
            contacto2.Con_Apellido = "Amilibia";
            contacto2.ConCargo = "2";
            Contacto contacto3 = (Contacto)fabricaEntidades.ObtenerContacto();
            contacto3.Id = 3;
            contacto3.Con_Nombre = "Amaranta";
            contacto3.Con_Apellido = "Ruiz";
            contacto3.ConCargo = "3";
            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
            listaUsuarios.Add(usuario3);
            listaContactos.Add(contacto1);
            listaContactos.Add(contacto2);
            listaContactos.Add(contacto3);
            acuerdo.Fecha = DateTime.Now;
            acuerdo.Compromiso = "Ejemplo de compromiso";
            acuerdo.ListaContacto = listaContactos;
            acuerdo.ListaUsuario = listaUsuarios;
        }

        [Test]
        public void PruebaAgregarAcuerdoBD()
        {
            bool success = DAOAcuerdo.AgregarAcuerdo(acuerdo, 1, "TOT");
            Assert.IsTrue(success);
        }

        [Test]
        public void PruebaModificarAcuerdo()
        {

        }

        [Test]
        public void PruebaConsultarTodosAcuerdos()
        {
            List<Acuerdo> listaAcuerdos = new List<Acuerdo>();
            listaAcuerdos = DAOAcuerdo.ConsultarTodos(1).Cast<Acuerdo>().ToList();
            Assert.IsTrue(listaAcuerdos.ToArray().Length > 0);
        }

        [Test]
        public void PruebaObtenerUsuarioAcuerdo()
        {
            List<Usuario> listaAcuerdos = new List<Usuario>();
            listaAcuerdos = DAOAcuerdo.ObtenerUsuarioAcuerdo(1).Cast<Usuario>().ToList();
            Assert.IsTrue(listaAcuerdos.ToArray().Length > 0);
        }

        [Test]
        public void PruebaObtenerContactoAcuerdo()
        {
            List<Contacto> listaAcuerdos = new List<Contacto>();
            listaAcuerdos = DAOAcuerdo.ObtenerContactoAcuerdo(1).Cast<Contacto>().ToList();
            Assert.IsTrue(listaAcuerdos.ToArray().Length > 0);
        }

        [Test]
        public void PruebaEliminar()
        {
            
        }
    }
}
