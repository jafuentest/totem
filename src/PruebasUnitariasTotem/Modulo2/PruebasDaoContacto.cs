using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Datos.DAO.Modulo2;
using Datos.Fabrica;
using Dominio.Fabrica;
using Datos.IntefazDAO.Modulo2;
using Dominio;
using Dominio.Entidades.Modulo2;

namespace PruebasUnitariasTotem.Modulo2
{
    /// <summary>
    /// Clase que Prueba la clase DaoContacto
    /// </summary>
    [TestFixture]
    class PruebasDaoContacto
    {
        Contacto elContacto;
        Contacto elContactoAuxiliar;
        Contacto elContacto2;
        Telefono elTelefono;
        Direccion laDireccion;
        ClienteJuridico elCliente;
        IDaoContacto daocontacto;
        FabricaDAOSqlServer fabricaDAOContacto;
        FabricaEntidades entidadContacto;
        List<Contacto> laListaDeContactos;


        /// <summary>
        /// Metodo donde se inicializan las variables a usar
        /// </summary>
        [SetUp]
        public void init()
        {
            fabricaDAOContacto = new FabricaDAOSqlServer();
            entidadContacto = new FabricaEntidades();
            elContacto = (Contacto)entidadContacto.ObtenerContacto();
            elContacto2 = (Contacto)entidadContacto.ObtenerContacto();
            elContactoAuxiliar = (Contacto)entidadContacto.ObtenerContacto();
            elCliente = (ClienteJuridico)entidadContacto.ObtenerClienteJuridico();
            elTelefono = (Telefono)entidadContacto.ObtenerTelefono();
            laDireccion = (Direccion)entidadContacto.ObtenerDireccion();
            laListaDeContactos =new List<Contacto>();

            elTelefono.Numero = "5555555";
            elTelefono.Codigo = "0414";
            laDireccion.CodigoPostal = null;
            laDireccion.LaDireccion = "Parroquia Caricuao UD 3, Bloque 6, piso 1, apt 01";
            laDireccion.LaCiudad = "Caracas";
            laDireccion.ElEstado = "Distrito Capital";
            laDireccion.ElPais = "Venezuela";

            elContacto.ConCedula = "1000000";
            elContacto.Con_Nombre = "Prueba";
            elContacto.Con_Apellido = "Unitaria";
            elContacto.ConCargo = "Gerente";

            elContacto.Con_Telefono = elTelefono;
            elContacto.ConClienteJurid = elCliente;
            elContacto.ConClienteNat = null;
          
            elCliente.Id = 1;
            elCliente.Jur_Rif = "J-11111111-1";
            elCliente.Jur_Nombre = "Locatel";
            laListaDeContactos.Add(elContacto);
            elCliente.Jur_Contactos = laListaDeContactos;
            elCliente.Jur_Direccion = laDireccion;
            elCliente.Jur_Logo = null;
            
        }


        /// <summary>
        /// Metodo prueba de agregar contacto
        /// </summary>
        [Test]
        public void pruebaAgregarContacto()
        {
            daocontacto = fabricaDAOContacto.ObtenerDaoContacto();
            Assert.IsTrue(daocontacto.Agregar(elContacto));

        }

        /// <summary>
        /// Metodo prueba de modificar un contacto
        /// </summary>
        [Test]
        public void pruebaModificarContacto()
        {
            daocontacto = fabricaDAOContacto.ObtenerDaoContacto();
            Assert.IsTrue(daocontacto.Modificar(elContacto));
        
        }

        /// <summary>
        /// Metodo prueba de buscar un contacto por cedula
        /// </summary>
        [Test]
        public void pruebaBuscarContactoXCI()
        {
            daocontacto = fabricaDAOContacto.ObtenerDaoContacto();
            Assert.IsTrue(daocontacto.BuscarCIContacto(elContacto));
        }

        /// <summary>
        /// Metodo pueba de consultar un contacto por id
        /// </summary>
        [Test]
        public void pruebaConsultarContactoPorID()
        {
            daocontacto = fabricaDAOContacto.ObtenerDaoContacto();
            elContactoAuxiliar.Id = 1;

            elContacto2 = (Contacto)daocontacto.ConsultarXId(elContactoAuxiliar);
            Assert.AreEqual(elContacto2.ConCedula, "66666666");
            Assert.AreEqual(elContacto2.Con_Nombre, "Reinaldo");
            Assert.AreEqual(elContacto2.Con_Apellido, "Cortes");
            
        }

    }
}
