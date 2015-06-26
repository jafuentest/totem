using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Dominio.Entidades.Modulo3;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo2;
using Comandos.Fabrica;
using Comandos;
using Dominio.Entidades.Modulo7;
using Dominio;

namespace PruebasUnitariasTotem.Modulo3
{
    class PruebaComando
    {
        #region Atributos
        private ListaInvolucradoContacto listContacto;
        private ListaInvolucradoUsuario listUsuario;
        #endregion

        #region Inicio y Fin de la Prueba Unitaria
        /// <summary>
        /// Método para Inicializar los atributos de la clase PruebaComando
        /// </summary>
        [SetUp]
        public void Init()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            listContacto = (ListaInvolucradoContacto)laFabrica.ObtenetListaInvolucradoContacto();
            listUsuario = (ListaInvolucradoUsuario)laFabrica.ObtenetListaInvolucradoUsuario();

        }

        #endregion

        #region Pruebas Unitarias ComandoAgregarContactosInvolucrados
        [Test]
        public void PruebaComandoAgregarContactosInvolucrados()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Proyecto elProyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            Contacto contacto = (Contacto)laFabrica.ObtenerContacto();
            Comando<Dominio.Entidad, Boolean> comando = FabricaComandos.CrearComandoAgregarContactosInvolucrados();

            elProyecto.Codigo = "TOT";
            listContacto.Proyecto = elProyecto;
            contacto.Id = 6;
            listContacto.Lista.Add(contacto);

            Assert.IsTrue(comando.Ejecutar(listContacto));
        }
        #endregion

        #region Pruebas Unitarias ComandoAgregarUsuariosInvolucrados
        [Test]
        public void PruebaComandoAgregarUsuariosInvolucrados()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Proyecto elProyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            Usuario usuario = (Usuario)laFabrica.ObtenerUsuario();
            Comando<Dominio.Entidad, Boolean> comando = FabricaComandos.CrearComandoAgregarUsuarioInvolucrados();

            elProyecto.Codigo = "TOT";
            listUsuario.Proyecto = elProyecto;
            usuario.Username = "johan7850";
            listUsuario.Lista.Add(usuario);

            Assert.IsTrue(comando.Ejecutar(listUsuario));
        }
        #endregion

        #region Pruebas Unitarias ComandoConsultarCargosContactos
        [Test]
        public void PruebaComandoConsultarCargosContactos()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Comando<bool, List<String>> comando = FabricaComandos.CrearComandoConsultarListaCargos();

            Assert.IsNotNull(comando.Ejecutar(true));
        }
        #endregion

        #region Pruebas Unitarias ComandoConsultarContactosInvolucradosPorProyecto
        [Test]
        public void PruebaComandoConsultarContactosInvolucradosPorProyecto()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarContactosInvolucradosPorProyecto();
            Proyecto proyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            proyecto.Codigo = "TOT";
            Assert.IsNotNull(comando.Ejecutar(proyecto));
        }
        #endregion

        #region Pruebas Unitarias ComandoConsultarUsuariosInvolucradosPorProyecto
        [Test]
        public void PruebaComandoConsultarusuariosInvolucradosPorProyecto()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarUsuariosInvolucradosPorProyecto();
            Proyecto proyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            proyecto.Codigo = "TOT";
            Assert.IsNotNull(comando.Ejecutar(proyecto));
        }
        #endregion

        #region Pruebas Unitarias ComandoDatosContactoID
        [Test]
        public void PruebaComandoDatosContactoID()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Comando<int, Entidad> comando = FabricaComandos.CrearComandoDatosContactoID();
            Proyecto proyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            Assert.AreEqual("Reinaldo", (comando.Ejecutar(1) as Contacto).Con_Nombre);
        }
        #endregion

        #region Pruebas Unitarias ComandoDatosUsuarioUsername
        [Test]
        public void PruebaComandoDatosUsuarioUsername()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            Comando<string, Entidad> comando = FabricaComandos.CrearComandoDatosUsuariosUsername();
            Proyecto proyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            Assert.AreEqual("Albeto", (comando.Ejecutar("albertods") as Usuario).Nombre);
        }
        #endregion

        #region Pruebas Unitarias ComandoListarContactosPorEmpresa
        [Test]
        public void PruebaComandoListarContactosPorEmpresa()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            ClienteJuridico clientJur = (ClienteJuridico)laFabrica.ObtenerClienteJuridico();
            Comando<Entidad, List<Entidad>> comando = FabricaComandos.CrearComandoListarContactosPorEmpresa();
            Proyecto proyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            clientJur.Id = 1;
            List<Entidad> laLista = comando.Ejecutar(clientJur);
            Assert.IsNotNull(laLista);
        }
        #endregion
    }
}
