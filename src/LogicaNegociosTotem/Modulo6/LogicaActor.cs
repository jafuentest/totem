using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosTotem.Modulo6;
using DominioTotem;

namespace LogicaNegociosTotem.Modulo6
{
    /// <summary>
    /// Clase que controla todos procesos en los que los actores estan involucrados
    /// </summary>
    public class LogicaActor
    {
        //Clase que inserta en la Base de Datos
        private BDActor baseDatosActor;

        /// <summary>
        /// Constructor que inicializa la clase que insertara en la Base de Datos
        /// </summary>
        public LogicaActor()
        {
            baseDatosActor = new BDActor();
        }

        /// <summary>
        /// Agrega un actor nuevo al proyecto
        /// </summary>
        /// <param name="nombre">El nombre del actor</param>
        /// <param name="descripcion">La descripcion del actorr</param>
        /// <param name="proyectoActor">El proyecto al que estara asociado el actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool AgregarActor(String nombre, String descripcion, int proyectoActor)
        {
            //Creamos al Actor y lo mandamos a crear
            Actor actor = new Actor(nombre, descripcion);
            return baseDatosActor.AgregarActor(actor, proyectoActor);
        }

        /// <summary>
        /// Lee todos los actores asociados al proyecto
        /// </summary>
        /// <param name="proyectoActor">El proyecto al que se desea obtener los actor(es)</param>
        /// <returns>Los actores asociados al proyecto</returns>
        public List<Actor> ListarActor(int proyectoActor)
        {
            //Mandamos el id del proyecto para buscar sus actores
            return baseDatosActor.ListarActor(proyectoActor);
        }

        /// <summary>
        /// Modifica un actor existente del proyecto
        /// </summary>
        /// <param name="nombre">El nombre del actor</param>
        /// <param name="descripcion">La descripcion del actorr</param>
        /// <param name="proyectoActor">El proyecto al que estara asociado el actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool ModificarActor(int id, String nombre, String descripcion, int proyectoActor)
        {
            //Creamos al Actor y lo mandamos a modificar
            Actor actor = new Actor(id, nombre, descripcion);
            return baseDatosActor.ModificarActor(actor, proyectoActor);
        }

        /// <summary>
        /// Elimina un actor existente del proyecto
        /// </summary>
        /// <param name="nombre">El nombre del actor</param>
        /// <param name="descripcion">La descripcion del actorr</param>
        /// <param name="proyectoActor">El proyecto al que estara asociado el actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool EliminarActor(String nombre, String descripcion, int proyectoActor)
        {
            //Creamos al Actor y lo mandamos a eliminar
            Actor actor = new Actor(nombre, descripcion);
            return baseDatosActor.EliminarActor(actor, proyectoActor);
        }
    }
}
