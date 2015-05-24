using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
    /// <summary>
    /// Actor del Caso de Uso
    /// </summary>
    public class Actor
    {
        //Nombre y descripcion del actor
        private int idenficacionActor;
        private String nombreActor;
        private String descripcionActor;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Actor()
        {

        }

        /// <summary>
        /// Constructor que recibe nombre y descripcion del actor
        /// </summary>
        /// <param name="nombre">El nombre con el que se nombrara el actor</param>
        /// <param name="descripcion">Descripion de que hace o quien es</param>
        public Actor(String nombre, String descripcion)
        {
            this.nombreActor = nombre;
            this.descripcionActor = descripcion;
        }

        /// <summary>
        /// Constructor que recibe el id del actor, nombre y descripcion e 
        /// </summary>
        /// <param name="id">Su id en la Base de Datos</param>
        /// <param name="nombre">El nombre con el que se nombrara el actor</param>
        /// <param name="descripcion">Descripion de que hace o quien es</param>
        public Actor(int id, String nombre, String descripcion)
        {
            this.idenficacionActor = id;
            this.nombreActor = nombre;
            this.descripcionActor = descripcion;
        }

        /// <summary>
        /// Retorna el nombre del actor y tambien permite asignarle un nombre nuevo
        /// </summary>
        public String NombreActor
        {
            get
            {
                return this.nombreActor;
            }

            set
            {
                this.nombreActor = value;
            }
        }

        /// <summary>
        /// Retorna la descripcion del actor y tambien permite asignarle una descripcion nueva 
        /// </summary>
        public String DescripcionActor
        {
            get
            {
                return this.descripcionActor;
            }

            set
            {
                this.descripcionActor = value;
            }
        }

        /// <summary>
        /// Retorna el id del actor en la Base de Datos y tambien permite asignarselo 
        /// </summary>
        public int IdentificacionActor
        {
            get
            {
                return this.idenficacionActor;
            }

            set
            {
                this.idenficacionActor = value;
            }
        }
    }

}
