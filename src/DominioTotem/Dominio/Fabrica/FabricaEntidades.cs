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
        
        #endregion

        #region Modulo 3
        public static Entidad ObtenetListaInvolucradoContacto()
        {
            return new Entidades.Modulo3.ListaInvolucradoContacto();
        }
        public static Entidad ObtenetListaInvolucradoContacto(Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoContacto(p);
        }
        public static Entidad ObtenetListaInvolucradoContacto(List<Contacto> laLista, Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoContacto(laLista, p);
        }
        public static Entidad ObtenetListaInvolucradoUsuario()
        {
            return new Entidades.Modulo3.ListaInvolucradoUsuario();
        }
        public static Entidad ObtenetListaInvolucradoUsuario(Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoUsuario(p);
        }
        public static Entidad ObtenetListaInvolucradoUsuario(List<Usuario> laLista, Proyecto p)
        {
            return new Entidades.Modulo3.ListaInvolucradoUsuario(laLista, p);
        } 
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public static Entidad ObtenerRequerimiento()
        {
            return new Entidades.Modulo5.Requerimiento();
        }

        public static Entidad
            ObtenerRequerimiento(string codigo, string descripcion, string tipo,
            string prioridad, string estatus)
        {
            return new Entidades.Modulo5.Requerimiento(
                codigo, descripcion, tipo, prioridad, estatus);
        }

        #endregion

        #region Modulo 6

        public static Entidad ObtenerActor() 
        {
            return new Actor(); 
        }

        public static Entidad ObtenerCasoDeUso() 
        {
            return new CasoDeUso(); 
        }

        public static Entidad ObtenerExtension() 
        {
            return new Extension(); 
        }

        public static Entidad ObtenerPaso() 
        {
            return new Paso(); 
        }

        #endregion

        #region Modulo 7
        /// <summary>
        /// Metodo que permite instanciar a la clase Usuario con sus atributos vacios
        /// </summary>
        /// <returns>el Usuario con sus atributos vacios</returns>
        public static Entidad ObtenerUsuario()
        {
            return new Entidades.Modulo7.Usuario();
        }

        public static Entidad ObtenerUsuario(String username, String clave, String nombre, String apellido, 
            String rol, String correo, String preguntaSeguridad, String respuestaSeguridad, String cargo )
        {
            return new Entidades.Modulo7.Usuario(username, clave, nombre, apellido, rol, correo, preguntaSeguridad, 
                respuestaSeguridad, cargo);
        }
        #endregion

        #region Modulo 8

        public Entidad ObtenerMinuta()
        {
            return new Entidades.Modulo8.Minuta();
        }
        public Entidad ObtenerAcuerdo()
        {
            return new Entidades.Modulo8.Acuerdo();
        }
        public Entidad ObtenerPunto()
        {
            return new Entidades.Modulo8.Punto();
        }
        #endregion
    }
}
