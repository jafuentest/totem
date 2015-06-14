using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Comandos.Comandos.Modulo6;
using Comandos.Comandos.Modulo2; 

namespace Comandos.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        public static Comando<Entidad, bool> CrearComandoAgregarClienteJuridico()
        {
            return new ComandoAgregarClienteJuridico();
        }
        public static Comando<Entidad, bool> CrearComandoAgregarClienteNatural()
        {
            return new ComandoAgregarClienteNatural();
        }
        public static Comando<String, List<String>> CrearComandoConsultarCiudadPorEstado()
        {
            return new ComandoConsultarCiudadPorEstado();
        }
        public static Comando<Entidad, Entidad> CrearComandoConsultarClienteJurXID()
        {
            return new ComandoConsultarClienteJurXID(); 
        }
        public static Comando<Entidad, Entidad> CrearComandoConsultarDatosContactoID()
        {
            return new ComandoConsultarDatosContactoID();
        }
        public static Comando<String, List<String>> CrearComandoConsultarEstadosPorPais()
        {
            return new ComandoConsultarEstadosPorPais();
        }
        public static Comando<Entidad,List<Entidad>> CrearComandoConsultarListaContactos()
        {
            return new ComandoConsultarListaContactos();
        }
        public static Comando<Boolean,List<String>> CrearComandoConsultarListaPaises()
        {
            return new ComandoConsultarListaPaises();
        } 
        public static Comando<bool, List<Entidad>> CrearComandoConsultarTodosClienteJuridico()
        {
            return new ComandoConsultarTodosClienteJuridico();
        }
        public static Comando<Entidad, List<Entidad>> CrearComandoConsultarTodosClienteNatural()
        {
            return new ComandoConsultarTodosClienteNatural();
        }
        public static Comando<Entidad, Entidad> CrearComandoConsultarXIDClienteNatural()
        {
            return new ComandoConsultarXIDClienteNatural();
        }

        public static Comando<Entidad, bool> CrearComandoEliminarClienteJuridico()
        {
            return new ComandoEliminarClienteJuridico();
        }
        public static Comando<Entidad, bool> CrearComandoEliminarClienteNatural()
        {
            return new ComandoEliminarClienteNatural();
        }
        public static Comando<Entidad,bool> CrearComandoEliminarContacto()
        {
            return new ComandoEliminarContacto();
        }
        public static Comando<Entidad, bool> CrearComandoModificarClienteJuridico()
        {
            return new ComandoModificarClienteJuridico();
        }
        public static Comando<Entidad, bool> CrearComandoModificarClienteNatural()
        {
            return new ComandoModificarClienteNatural();
        }
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoAgregarRequerimiento();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoEliminarRequerimiento();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> 
            CrearComandoConsultarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoConsultarRequerimiento();
        }
        public static Comando<String,
        List<Dominio.Entidad>> CrearComandoConsultarRequerimientosProyecto()
        {
            return new Comandos.Modulo5.ComandoConsultarRequerimientosProyecto();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoModificarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoModificarRequerimiento();
        }
        #endregion

        #region Modulo 6

        public static Comando<Entidad, bool> CrearComandoAgregarActor() 
        {
            return new ComandoAgregarActor(); 
        }

        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion
    }
}
