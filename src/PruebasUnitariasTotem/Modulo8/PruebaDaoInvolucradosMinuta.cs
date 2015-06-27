using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo8;
using Datos.DAO.Modulo8;
using Datos.Fabrica;
using Dominio.Fabrica;

namespace PruebasUnitariasTotem.Modulo8
{
    /// <summary>
    /// Clase que Prueba la Clase DaoInvolucradosMinuta
    /// </summary>
    [TestFixture]
    class PruebaDaoInvolucradosMinuta
    {

        Minuta minuta;
        Datos.IntefazDAO.Modulo8.IDaoInvolucradosMinuta daoInvolucradosMinuta;
        List<Minuta> listaMinuta;
        Usuario usuario;
        Contacto contacto;
        FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
        FabricaEntidades fabricaEntidades = new FabricaEntidades();
       

        /// <summary>
        /// Metodo donde se inicializan todas las variables que se utilizan en la clase
        /// </summary>
        [SetUp]
        public void init()
        {
            listaMinuta = new List<Minuta>();
            minuta = new Minuta();
            daoInvolucradosMinuta = fabricaDAO.ObtenerDAOInvolucradosMinuta();
            usuario = (Usuario)fabricaEntidades.ObtenerUsuario();
            contacto = (Contacto)fabricaEntidades.ObtenerContacto();
        }

        /// <summary>
        /// Metodo que prueba el metodo para agregar un usuario en acuerdo
        /// </summary>
        [Test]
        public void PruebaAgregarUsuarioEnAcuerdo()
        {
           
           usuario =(Usuario) daoInvolucradosMinuta.ConsultarUsuarioMinutas(9);
           Assert.IsTrue(daoInvolucradosMinuta.AgregarUsuarioEnAcuerdo(usuario,"1","TOT"));
           daoInvolucradosMinuta.EliminarUsuarioEnAcuerdo(usuario,1,"TOT");
            
        }
         /// <summary>
        /// Metodo que prueba el metodo para eliminar un usuario en acuerdo 
        /// </summary>
        [Test]
        public void PruebaEliminarUsuarioEnAcuerdo()
        {
           
           usuario =(Usuario) daoInvolucradosMinuta.ConsultarUsuarioMinutas(9);
           daoInvolucradosMinuta.AgregarUsuarioEnAcuerdo(usuario,"1","TOT");
           Assert.IsTrue(daoInvolucradosMinuta.EliminarUsuarioEnAcuerdo(usuario,1,"TOT"));
            
        }

        /// <summary>
        /// Metodo que prueba el metodo para agregar involucrado a la BD
        /// </summary>
        [Test]
        public void PruebaAgregarInvolucradoEnMinuta()
        {
           
           Assert.IsTrue(daoInvolucradosMinuta.AgregarInvolucradoEnMinuta(9,"TOT","Procedure_AgregarInvolucradoUsuario","@usu_id",1));
           daoInvolucradosMinuta.EliminarInvolucradoEnMinuta(1); 
        }
        
        /// <summary>
        /// Metodo que prueba el metodo para Agregar un Contacto a un Acuerdo a la BD
        /// </summary>
        [Test]
        public void PruebaAgregarContactoEnAcuerdo()
        {
           
           contacto =(Contacto) daoInvolucradosMinuta.ConsultarContactoMinutas(1);
           Assert.IsTrue(daoInvolucradosMinuta.AgregarContactoEnAcuerdo(contacto, "1", "TOT"));
           daoInvolucradosMinuta.EliminarContactoEnAcuerdo(contacto, 1, "TOT");
            
        }
        

        /// <summary>
        /// Metodo que prueba el metodo para Agregar un Contacto a un Acuerdo a la BD
        /// </summary>
        [Test]
        public void PruebaEliminarContactoEnAcuerdo()
        {
           
           contacto =(Contacto) daoInvolucradosMinuta.ConsultarContactoMinutas(1);
           daoInvolucradosMinuta.AgregarContactoEnAcuerdo(contacto, "1", "TOT");
           Assert.IsTrue(daoInvolucradosMinuta.EliminarContactoEnAcuerdo(contacto,1,"TOT"));
            
        }

        

        /// <summary>
        /// Metodo que prueba el metodo para eliminar involucrados de una minuta
        /// </summary>
        [Test]
        public void PruebaEliminarInvolucradoEnMinuta()
        {
           Assert.IsTrue(daoInvolucradosMinuta.EliminarInvolucradoEnMinuta(1));
           daoInvolucradosMinuta.AgregarInvolucradoEnMinuta(1, "TOT", "Procedure_AgregarInvolucradoUsuario", "@usu_id", 1);
           daoInvolucradosMinuta.AgregarInvolucradoEnMinuta(2, "TOT", "Procedure_AgregarInvolucradoUsuario", "@usu_id", 1);
          
            
        }
        /// <summary>
        /// Metodo donde se resetean todas las variables
        /// </summary>
        [TearDown]
        public void close()
        {
            minuta = null;
            listaMinuta = null;
            usuario=null; 
            contacto=null;
        }
    }
}

    