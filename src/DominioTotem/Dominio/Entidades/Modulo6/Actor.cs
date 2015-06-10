using System;


namespace Dominio.Entidades.Modulo6
{
    /// <summary>
    /// Actor del Caso de Uso
    /// </summary>
    public class Actor:Entidad
    {
        #region Atributos
        
        private String nombreActor;
        private String descripcionActor;
        #endregion


        #region Propiedades
        /// <summary>
        /// Retorna el nombre del actor y tambien permite asignarle un nombre nuevo
        /// </summary>
        public String NombreActor
        {
            get { return this.nombreActor; }
			set { this.nombreActor = value; }
        }

        /// <summary>
        /// Retorna la descripcion del actor y tambien permite asignarle una descripcion nueva 
        /// </summary>
        public String DescripcionActor
        {
            get { return this.descripcionActor; }
            set { this.descripcionActor = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Actor()
            :base(0)
        {
            NombreActor = string.Empty;
            DescripcionActor = string.Empty; 
        }

        /// <summary>
        /// Constructor que recibe nombre y descripcion del actor
        /// </summary>
        /// <param name="nombre">El nombre con el que se nombrara el actor</param>
        /// <param name="descripcion">Descripion de que hace o quien es</param>
        public Actor(String nombre, String descripcion)
            :base(0)
        {
            NombreActor = nombre;
            DescripcionActor = descripcion;
        }
        #endregion

        #region Método Equals
        /// <summary>
        /// Implementación del método Equals
        /// heredado de Object para la clase Actor
        /// </summary>
        /// <param name="obj">Objeto </param>
        /// <returns>True si es igual, false
        /// si no lo es</returns>
        public override bool Equals(object obj)
        {
            bool esIgual = false;

            try
            {
                if (obj == null)
                    esIgual = false;
                else
                {
                    esIgual = base.Equals(obj);
                    Actor aux = obj as Actor;
                    esIgual &= aux.NombreActor.Equals(NombreActor);
                    esIgual &= aux.DescripcionActor.Equals(DescripcionActor);
                    esIgual &= aux.Id == Id;
                }
                
            }
            catch (Exception) 
            {
                throw; 
            }

            return esIgual;
        }
        #endregion
    }

}
