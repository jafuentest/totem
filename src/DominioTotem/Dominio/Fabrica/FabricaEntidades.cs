using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Entidades.Modulo6; 
using Dominio.Entidades;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using Dominio.Entidades.Modulo2;

namespace Dominio.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        public Entidad ObtenerClienteJuridico()
        {
            return new Entidades.Modulo2.ClienteJuridico();
        }
        public Entidad ObtenerClienteNatural()
        {
            return new Entidades.Modulo2.ClienteNatural();
        }
        public Entidad ObtenerContacto()
        {
            return new Entidades.Modulo2.Contacto();
        }
        public Entidad ObtenerDireccion()
        {
            return new Entidades.Modulo2.Direccion();
        }
        public Entidad ObtenerTelefono()
        {
            return new Entidades.Modulo2.Telefono();
        }
        public Entidad ObtenerDireccion(String pais, String estado, String ciudad, String direccion, String codigop)
        {
            return new Entidades.Modulo2.Direccion(pais, estado, ciudad, direccion, codigop);
        }
        public Entidad ObtenerTelefono(String elCodigo, String elNumero)
        {
            return new Entidades.Modulo2.Telefono(elCodigo, elNumero);
        }
        public Entidad ObtenerContacto(String cedula, String nombre, String apellido, String cargo, Entidad telefono)
        {
            return new Entidades.Modulo2.Contacto(cedula, nombre, apellido, cargo, telefono);
        }
        public Entidad ObtenerClienteJuridico(String nombre, List<Entidad> contactos, Entidad dir,
         String elRif, String logo)
        {
            return new Entidades.Modulo2.ClienteJuridico(nombre, contactos, dir, elRif, logo);
        }

        public Entidad ObtenerClienteNatural(String nombre, String apellido, String correo, Entidad dir, Entidad telefono, String cedula)
        {
            return new Entidades.Modulo2.ClienteNatural(nombre, apellido, correo, dir, telefono, cedula);
        }

        public Entidad ObtenerClienteJuridico(int id)
        {
            return new Entidades.Modulo2.ClienteJuridico(id);
        }
        #endregion

        #region Modulo 3
        public Entidad ObtenetListaInvolucradoContacto()
        {
            return new Entidades.Modulo3.ListaInvolucradoContacto();
        }
        public Entidad ObtenetListaInvolucradoContacto(Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoContacto(p);
        }
        public Entidad ObtenetListaInvolucradoContacto(List<Contacto> laLista, Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoContacto(laLista, p);
        }
        public Entidad ObtenetListaInvolucradoUsuario()
        {
            return new Entidades.Modulo3.ListaInvolucradoUsuario();
        }
        public Entidad ObtenetListaInvolucradoUsuario(Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoUsuario(p);
        }
        public Entidad ObtenetListaInvolucradoUsuario(List<Usuario> laLista, Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoUsuario(laLista, p);
        } 
        #endregion

        #region Modulo 4
        public static Entidad ObtenerProyecto()
        {
	        return new Entidades.Modulo4.Proyecto();
        }
        public static Entidad ObtenerProyecto(String codigo, String nombre, bool estado,
	        String descripcion, String moneda, int costo)
        {
	        return new Entidades.Modulo4.Proyecto(codigo, nombre, estado, descripcion,
		        moneda, costo);
        }
        public static Entidad ObtenerProyecto(int id, String codigo, String nombre, bool estado,
	        String descripcion, String moneda, int costo)
        {
	        return new Entidades.Modulo4.Proyecto(id, codigo, nombre, estado, descripcion,
		        moneda, costo);
        }
        public static Entidad ObtenerProyecto(String codigo, String nombre,
            String descripcion, String moneda)
        {
            return new Entidades.Modulo4.Proyecto(codigo, nombre, descripcion, moneda);
        }
        #endregion

        #region Modulo 5
        public Entidad ObtenerRequerimiento()
        {
            return new Entidades.Modulo5.Requerimiento();
        }

        public Entidad
            ObtenerRequerimiento(string codigo)
        {
            return new Entidades.Modulo5.Requerimiento(codigo);
        }

        public Entidad
            ObtenerRequerimiento(string codigo, string descripcion, string tipo,
            string prioridad, string estatus)
        {
            return new Entidades.Modulo5.Requerimiento(
                codigo, descripcion, tipo, prioridad, estatus);
        }

        public Entidad
            ObtenerRequerimiento(string codigo, string descripcion, string tipo,
            string prioridad, string estatus, string codigoProyecto)
        {
            return new Entidades.Modulo5.Requerimiento(
                codigo, descripcion, tipo, prioridad, estatus, codigoProyecto);
        }
        public Entidad
            ObtenerRequerimiento(int id, string codigo, string descripcion, string tipo,
            string prioridad, string estatus, string codigoProyecto)
        {
            return new Entidades.Modulo5.Requerimiento(
                id, codigo, descripcion, tipo, prioridad, estatus, codigoProyecto);
        }
        #endregion

        #region Modulo 6

        public  Entidad ObtenerActor() 
        {
            return new Actor(); 
        }

        public  Entidad ObtenerCasoDeUso() 
        {
            return new CasoDeUso(); 
        }

        public  Entidad ObtenerExtension() 
        {
            return new Extension(); 
        }

        public  Entidad ObtenerPaso() 
        {
            return new Paso(); 
        }

        #endregion

        #region Modulo 7
        /// <summary>
        /// Metodo que permite instanciar a la clase Usuario con sus atributos vacios
        /// </summary>
        /// <returns>el Usuario con sus atributos vacios</returns>
        public Entidad ObtenerUsuario()
        {
            return new Entidades.Modulo7.Usuario();
        }

        /// <summary>
        /// Metodo que permite instanciar a la clase usuario sin el ID de la base de Datos
        /// </summary>
        /// <param name="username">Username del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="rol">Rol que ocupa</param>
        /// <param name="correo">Correo del Usuario</param>
        /// <param name="preguntaSeguridad">Pregunta de seguridad si olvida su clave</param>
        /// <param name="respuestaSeguridad">Respuesta a la pregunta de seguridad</param>
        /// <param name="cargo">Cargo que ocupa</param>
        /// <returns>El usuario completo sin su ID de Base de Datos</returns>
        public Entidad ObtenerUsuario(String username, String clave, String nombre, String apellido, 
            String rol, String correo, String preguntaSeguridad, String respuestaSeguridad, String cargo )
        {
            return new Entidades.Modulo7.Usuario(username, clave, nombre, apellido, rol, correo, preguntaSeguridad, 
                respuestaSeguridad, cargo);
        }

        /// <summary>
        /// Metodo que instancia el Usuario con sus datos basicos
        /// </summary>
        /// <param name="username">Username del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="cargo">Cargo que ocupa</param>
        /// <returns>El usuario con sus datos basicos</returns>
        public Entidad ObtenerUsuario(String username, String nombre, String apellido, String cargo)
        {
            return new Entidades.Modulo7.Usuario(username, nombre, apellido, cargo);
        }

		public Entidad ObtenerUsuario(string username)
		{
			return new Usuario(username);
		}

		public Entidad ObtenerUsuario(int idUsuario, int idCargo, string username, string clave, string nombre,
			string apellido, string rol, string correo, string preguntaSeguridad, string respuestaSeguridad,
			string cargo)
		{
			return new Usuario(idUsuario, idCargo, username, clave, nombre, apellido, rol, correo, preguntaSeguridad,
				respuestaSeguridad, cargo);
		}
        #endregion

        #region Modulo 8
        /// <summary>
        /// Metodo que permite instanciar Minuta 
        /// </summary>
        /// <returns>La minuta vacia</returns>
        public Entidad ObtenerMinuta()
        {
            return new Entidades.Modulo8.Minuta();
        }
        /// <summary>
        /// Metodo que permite instanciar Acuerdo 
        /// </summary>
        /// <returns>El acuerdo vacio</returns>
        public Entidad ObtenerAcuerdo()
        {
            return new Entidades.Modulo8.Acuerdo();
        }
        /// <summary>
        /// Metodo que permite instanciar Punto 
        /// </summary>
        /// <returns>El punto vacio</returns>
        public Entidad ObtenerPunto()
        {
            return new Entidades.Modulo8.Punto();
        }
        #endregion
    }
}
