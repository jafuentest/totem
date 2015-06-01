using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosTotem;
using DatosTotem.Modulo3;
using DominioTotem;
using ExcepcionesTotem.Modulo3;
using LogicaNegociosTotem.Modulo3;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo3
{
    [TestFixture]
    public class PruebaExcepcionesInvolucrados
    {
        [Test]
        [ExpectedException( typeof( ListaSinProyectoException ) )]
        public void listaSinProyectoAgregarUsuInv()
        {
            ListaInvolucradoUsuario lista = new ListaInvolucradoUsuario();
            Usuario usu = new Usuario();
            usu.idUsuario = 100;
            usu.username = "asd";
            lista.agregarUsuarioAProyecto(usu);

            BDInvolucrados.agregarUsuariosInvolucrados(lista);
        }

        [Test]
        [ExpectedException( typeof( ListaSinInvolucradosException ) )]
        public void listaSinInvolucradosAgregarUsu()
        {
            ListaInvolucradoUsuario lista = new ListaInvolucradoUsuario();
            lista.Lista = new List<Usuario>();
            Proyecto pro = new Proyecto();
            pro.Codigo = "ASD";

            lista.Proyecto = pro;
            BDInvolucrados.agregarUsuariosInvolucrados(lista);
        }

        [Test]
        [ExpectedException( typeof( ProyectoSinCodigoException ) )]
        public void listaConProyectoSinCodAgregarUsu()
        {
            ListaInvolucradoUsuario lista = new ListaInvolucradoUsuario();
            Usuario usu = new Usuario();
            usu.idUsuario = 100;
            usu.username = "asd";

            Proyecto pro = new Proyecto();
            pro.Codigo = null;

            lista.agregarUsuarioAProyecto(usu);
            lista.Proyecto = pro;

            BDInvolucrados.agregarUsuariosInvolucrados(lista);
        }

        [Test]
        [ExpectedException(typeof(UsuarioSinUsernameException))]
        public void usuarioSinUsernameAgregarUsu()
        {
            ListaInvolucradoUsuario lista = new ListaInvolucradoUsuario();
            Usuario usu = new Usuario();
            Proyecto pro = new Proyecto();
            pro.Codigo = "ASD";

            lista.agregarUsuarioAProyecto(usu);
            lista.Proyecto = pro;

            BDInvolucrados.agregarUsuariosInvolucrados(lista);
        }

        [Test]
        [ExpectedException(typeof(InvolucradoRepetidoException))]
        public void usuarioRepetidoAgregarUsu()
        {
            ListaInvolucradoUsuario lista = new ListaInvolucradoUsuario();
            Usuario usu = new Usuario();
            usu.idUsuario = 1;
            usu.username = "albertods";
            lista.agregarUsuarioAProyecto(usu);
            Proyecto pro = new Proyecto();
            pro.Codigo = "TOT";
            lista.Proyecto = pro;
            BDInvolucrados.agregarUsuariosInvolucrados(lista);
        }


    }
}
