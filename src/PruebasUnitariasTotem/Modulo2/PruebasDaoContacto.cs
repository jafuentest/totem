using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DAO.DAO.Modulo2;
using DAO.Fabrica;
using Dominio.Fabrica;
using DAO.IntefazDAO.Modulo2;
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

        [Test]
        public void pruebaAgregarContacto()
        {
            daocontacto = fabricaDAOContacto.ObtenerDaoContacto();
            Assert.IsTrue(daocontacto.Agregar(elContacto));

        }
        

    }
}
