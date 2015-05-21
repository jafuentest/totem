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
        private String nombreActor;
        private String descripcionActor;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Actor()
        {

        }

        /// <summary>
        /// Constructor que recibe parametros
        /// </summary>
        /// <param name="nombre">El nombre con el que se nombrara el actor</param>
        /// <param name="descripcion">Descripion de que hace o quien es</param>
        public Actor(String nombre, String descripcion)
        {
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

        /*
        /// <summary>
        /// Agrega un actor nuevo al proyecto
        /// </summary>
        /// <param name="actor">El actor que se creara</param>
        /// <param name="proyectoActor">El proyecto asociado al actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool AgregarActor(Actor actor, Proyecto proyectoActor)
        {
            return BDActor.AgregarActor(actor, proyectoActor);

        }

        /// <summary>
        /// Lee todos los actores asociados al proyecto
        /// </summary>
        /// <param name="proyectoActor">El proyecto al que se desea obtener los actor(es)</param>
        /// <returns>Los actores asociados al proyecto</returns>
        public List<Actor> ListarActor(Proyecto proyectoActor)
        {
            return BDActor.ListarActor(proyectoActor);
        }

        /// <summary>
        /// Modifica un actor existente del proyecto
        /// </summary>
        /// <param name="actor">El actor que se modificara</param>
        /// <param name="proyectoActor">El proyecto asociado al actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool ModificarActor(Actor actor, Proyecto proyectoActor)
        {
            return BDActor.ModificarActor(actor, proyectoActor);
        }

        /// <summary>
        /// Elimina un actor existente del proyecto
        /// </summary>
        /// <param name="actor">El actor que se eliminara</param>
        /// <param name="proyectoActor">El proyecto asociado al actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool EliminarActor(Actor actor, Proyecto proyectoActor)
        {
            return BDActor.EliminarActor(actor, proyectoActor);
        }*/

    }

}
