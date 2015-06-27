using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Comandos.Comandos.Modulo1;
using Comandos.Comandos.Modulo2;
using Comandos.Comandos.Modulo4;
using Comandos.Comandos.Modulo6;
using Comandos.Comandos.Modulo7;

namespace Comandos.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        public static Comando<Entidad, bool> CrearComandoCambioDeClave()
        {
            return new ComandoCambioDeClave();
        }

        public static Comando<List<string>, string> CrearComandoDesencriptar()
        {
            return new ComandoDesencriptar();
        }

        public static Comando<List<string>, string> CrearComandoEncriptar()
        {
            return new ComandoEncriptar();
        }

        public static Comando<List<string>, Entidad> CrearComandoIniciarSesion()
        {
            return new ComandoIniciarSesion();
        }
        public static Comando<Entidad, Entidad> CrearComandoObtenerPreguntaSeguridad()
        {
            return new ComandoObtenerPreguntaSeguridad();
        }

        public static Comando<Entidad, bool> CrearComandoValidarRespuestaSecreta()
        {
            return new ComandoValidarRespuestaSecreta();
        }

        public static Comando<String, bool> CrearComandoValidarCorreoExistente()
        {
            return new ComandoValidarCorreoExistente();
        }

        public static Comando<List<String>, bool> CrearComandoEnviarEmail()
        {
            return new ComandoEnviarEmail();
        }

        #endregion

        #region Modulo 2
        public static Comando<Entidad, bool> CrearComandoAgregarContacto()
        {
            return new ComandoAgregarContacto();
        }
        public static Comando<Entidad, bool> CrearComandoModificarContacto()
        {
            return new ComandoModificarContacto();
        } 
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
        public static Comando<bool, List<Entidad>> CrearComandoConsultarTodosClienteNatural()
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
        public static Comando<bool, List<String>> CrearComandoConsultarListaCargos()
        {
            return new ComandoConsultarListaCargos();
        }
        #endregion

        #region Modulo 3
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarContactosInvolucrados()
        {
            return new Comandos.Modulo3.ComandoAgregarContactosInvolucrados();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarUsuarioInvolucrados()
        {
            return new Comandos.Modulo3.ComandoAgregarUsuariosInvolucrados();
        }
        public static Comando<Dominio.Entidad, List<String>> CrearComandoConsultarCargosContactos()
        {
            return new Comandos.Modulo3.ComandoConsultarCargosContactos();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> CrearComandoConsultarContactosInvolucradosPorProyecto()
        {
            return new Comandos.Modulo3.ComandoConsultarContactosInvolucradosPorProyecto();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoConsultarContactoInvolucrados()
        {
            return new Comandos.Modulo3.ComandoAgregarContactosInvolucrados();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> CrearComandoConsultarUsuariosInvolucradosPorProyecto()
        {

            return new Comandos.Modulo3.ComandoConsultarUsuariosInvolucradosPorProyecto();
        }
        public static Comando<int, Dominio.Entidad> CrearComandoDatosContactoID()
        {

            return new Comandos.Modulo3.ComandoDatosContactoID();
        }
        public static Comando<String, Dominio.Entidad> CrearComandoDatosUsuariosUsername()
        {

            return new Comandos.Modulo3.ComandoDatosUsuarioUsername();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarContactoDeInvolucradosEnProyecto()
        {

            return new Comandos.Modulo3.ComandoEliminarContactoDeIvolucradosEnProyecto();
        }

        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarUsuariosDeInvolucradosEnProyecto()
        {

            return new Comandos.Modulo3.ComandoEliminarUsuariosDeIvolucradosEnProyecto();
        }
        public static Comando<Entidad, List<Dominio.Entidad>> CrearComandoListarContactosPorCargoEmpresa()
        {

            return new Comandos.Modulo3.ComandoListarContactosPorCargoEmpresa();
        }
        public static Comando<Entidad, List<Dominio.Entidad>> CrearComandoListarContactosPorEmpresa()
        {

            return new Comandos.Modulo3.ComandoListarContactosPorEmpresa();
        }
        #endregion

        #region Modulo 4
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarProyecto()
        {
            return new ComandoAgregarProyecto();
        }
	   public static Comando<String, List<Dominio.Entidad>>
		  CrearComandoConsultarProyectosPorUsuario()
	   {
		  return new ComandoConsultarProyectosPorUsuario();
	   }
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
        public static Comando<String, Boolean> CrearComandoGenerarArchivoLatex()
        {
            return new Comandos.Modulo5.ComandoGenerarArchivoLatex();
        }

        public static Comando<String, List<String>> CrearComandoBuscarCodigoRequerimiento()
        {
            return new Comandos.Modulo5.ComandoBuscarCodigoRequerimiento();
        }
        #endregion

        #region Modulo 6

        public static Comando<Entidad, bool> CrearComandoAgregarActor() 
        {
            return new ComandoAgregarActor(); 
        }

        public static Comando<string, bool> CrearComandoVerificarActor()
        {
            return new ComandoVerificarExistenciaActor();
        }

        public static Comando<string, List<Entidad>> CrearComandoConsultarActoresCB() 
        {
            return new ComandoConsultarActoresCombo();
        }

        public static Comando<Entidad, List<Entidad>> CrearComandoConsultarCasosDeUsoXActor() 
        {
            return new ComandoConsultarCasosDeUsoPorActor(); 
        }

        public static Comando<int, List<Entidad>> CrearComandoConsultarRequerimientosXCasoDeUso() 
        {
            return new ComandoConsultarRequerimientosXCasoDeUso(); 
        }

        public static Comando<string, List<Entidad>> CrearComandoListarCU() 
        {
            return new ComandoListarCU(); 
        }

        public static Comando<int, List<string>> CrearComandoConsultarActoresXCasoDeUso() 
        {
            return new ComandoConsultarActoresXCasoDeUso(); 
        }

        public static Comando<int, bool> CrearComandoEliminarCU() 
        {
            return new ComandoEliminarCU(); 
        }

        public static Comando<string, List<Entidad>> CrearComandoListarActores()
        {
            return new ComandoConsultarActores();
        }

        public static Comando<Entidad, Entidad> CrearComandoConsultarActorXID() 
        {
            return new ComandoConsultarActorXId();
        }

        public static Comando<Entidad, bool> CrearComandoModificarActor() 
        {
            return new ComandoModificarActor(); 
        }

        public static Comando<int, bool> CrearComandoEliminarActor()
        {
            return new ComandoEliminarActor();
        }
        #endregion

        #region Modulo 7
        /// <summary>
        /// Metodo que Instancia el Comando de Agregar Usuario
        /// </summary>
        /// <returns>El comando Agregar Usuario</returns>
        public static Comando<Entidad,bool> CrearComandoAgregarUsuario()
        {
            return new ComandoAgregarUsuario();
        }

        /// <summary>
        /// Metodo que Instancia el comando de validar Username Unico
        /// </summary>
        /// <returns>El comando validar Username unico</returns>
        public static Comando<String,bool> CrearComandoValidarUsernameUnico()
        {
            return new ComandoValidarUsernameUnico();
        }

        /// <summary>
        /// Metodo que instancia el comando de validar Correo unico
        /// </summary>
        /// <returns>El comando validar Correo Unico</returns>
        public static Comando<String, bool> CrearComandoValidarCorreoUnico()
        {
            return new ComandoValidarCorreoUnico();
        }

        /// <summary>
        /// Metodo que instancia el comando de Listar los cargos
        /// </summary>
        /// <returns>El comando Listar Combo cargos</returns>
        public static Comando <bool,List<String>> CrearComandoListarCargos()
        {
            return new ComandoListarCargos();
        }

        /// <summary>
        /// Metodo que instancia el comando de Listar los Usuarios
        /// </summary>
        /// <returns>Todos los Usuarios del sistema</returns>
        public static Comando<bool,List<Entidad>> CrearComandoListarUsuarios()
        {
            return new ComandoListarUsuarios();
        }

        /// <summary>
        /// Metodo que instancia el comando de Listar los Usuarios segun su cargo
        /// </summary>
        /// <returns>Todos los usuarios que tengan ese cargo</returns>
        public static Comando<String, List<Entidad>> CrearComandoListarUsuariosPorCargo()
        {
            return new ComandoListarUsuariosPorCargo();
        }

        /// <summary>
        /// Metodo que instancia el comando de Listar todos los cargos que ya estan en los Usuarios
        /// </summary>
        /// <returns>Todos los cargos que ya estan ocupados por al menos un usuario</returns>
        public static Comando <bool,List<String>> CrearComandoLeerCargosUsuarios()
        {
            return new ComandoLeerCargosUsuarios();
        }

        /// <summary>
        /// Metodo que instancia el comando de eliminar un usuario
        /// </summary>
        /// <returns>Verdadero si se pudo eliminar, falso sino se pudo</returns>
        public static Comando<String, bool> CrearComandoEliminarUsuarios()
        {
            return new ComandoEliminarUsuario();
        }
        /// <summary>
        /// Metodo que instancia el comando de detalle de informacion de usuario
        /// </summary>
        /// <returns></returns>
		public static Comando<Entidad, Entidad> CrearComandoDetalleUsuario()
		{
			return new ComandoDetalleUsuario();
		}
        #endregion

        #region Modulo 8

        public static Comando<String, List<Dominio.Entidad>> CrearComandoComandoListaMinuta()
        {
            return new Comandos.Modulo8.ComandoListaMinuta();
        }

        public static Comando<String, Dominio.Entidad> CrearComandoComandoDetalleMinuta()
        {
            return new Comandos.Modulo8.ComandoDetalleMinuta();
        }
        public static Comando<List<Entidad>, string> CrearComandoGuardarMinuta()
        {
            return new Comandos.Modulo8.ComandoGuardarMinuta();
        }
        public static Comando<List<Entidad>, string> CrearComandoModificarMinuta()
        {
            return new Comandos.Modulo8.ComandoModificarMinuta();
        }

        public static Comando<String, bool> CrearComandoCompilarLatex()
        {
            return new Comandos.Modulo8.ComandoCompilarLatex();
        }

        public static Comando<Entidad, bool> CrearComandoGenerarMinuta()
        {
            return new Comandos.Modulo8.ComandoGenerarMinuta();
        }

        public static Comando<String, List<Dominio.Entidad>> CrearComandoListaContacto()
        {
            return new Comandos.Modulo8.ComandoListaContacto();
        }

        public static Comando<string, List<Dominio.Entidad>> CrearComandoListaUsuario()
        { 
            return new Comandos.Modulo8.ComandoListaUsuario();
        }
        

        #endregion
    }
}
