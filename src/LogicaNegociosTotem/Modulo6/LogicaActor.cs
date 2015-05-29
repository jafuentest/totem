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
        public bool EliminarActor(int idActor, int proyectoActor)
        {
            //Creamos al Actor y lo mandamos a eliminar
            Actor actor = new Actor();
            actor.IdentificacionActor = idActor;
            return baseDatosActor.EliminarActor(actor, proyectoActor);
        }

        /// <summary>
        /// Agrega un actor nuevo si este no existe ya en el proyecto
        /// </summary>
        /// <param name="nombre">El nombre del actor</param>
        /// <param name="descripcion">La descripcion del actor</param>
        /// <param name="proyectoActor">El proyecto al que estara asociado el actor</param>
        /// <returns>El exito o fallo del proceso</returns>
        public bool AgregarListarActor(String nombre, String descripcion, int proyectoActor)
        {
            //Variable que nos indicara si el usuario ya existe o no en la Base de Datos
            bool noExiste = true;

            //Variable que nos indicara si el proceso completo de incersion tuvo exito
            bool exito = false;

            //Buscamos todos los actores pertenecientes al proyecto
            List<Actor> listaActores = ListarActor(proyectoActor);

            //Se recorre la lista para verificar si en efecto existe o no
            foreach (Actor actorLista in listaActores)
            {
                //Si ya existe no se agrega al proyecto
                if (actorLista.NombreActor == nombre)
                    noExiste = false;
            }
            //Sino existe ya en el proyecto se agrega
            if (noExiste == true)
                exito = AgregarActor(nombre, descripcion, proyectoActor);
            return exito;
        }

        /*
        /// <summary>
        /// Lee todos los actores asociados al proyecto con sus Casos de Uso
        /// </summary>
        /// <param name="proyectoActor">El proyecto que se desea buscar los actores y sus CU</param>
        /// <returns>Todos los actores asociados al proyecto con sus Casos de Uso</returns>
        public List<Actor> CasoUsoPorActor (int proyectoActor)
        {
            //Listamos todos los Actores del proyecto
            List<Actor> listaActores = ListarActor(proyectoActor);

            //Recorremos la lista anexandole a cada Actor sus Casos de Usos
            foreach (Actor actorLista in listaActores)
            {
                //Obtenemos los Casos de Uso del Actor en particular los agregamos a este.
                actorLista.CasosDeUsos = baseDatosActor.CasoUsoPorActor(actorLista,proyectoActor);
                 
            }
            return listaActores;
        }*/
    }
}
