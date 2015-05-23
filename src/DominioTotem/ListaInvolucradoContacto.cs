using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTotem
{
    public class ListaInvolucradoContacto
    {
        private Proyecto proyecto;
        private List<Contacto> lista;

        #region Constructores
        /// <summary>
        /// Constructor vacio de la lista de contactos
        /// </summary>
        public ListaInvolucradoContacto()
        {
            proyecto = null;
            lista = new List<Contacto>();
        }
        /// <summary>
        /// Constructor que recibe el proyecto al que se asocian contactos, inicializa la lista en vacio
        /// </summary>
        /// <param name="p">proyecto al que se involucran los contactos</param>
        public ListaInvolucradoContacto(Proyecto p)
        {
            proyecto = p;
            lista = new List<Contacto>();
        }
        /// <summary>
        /// Constructor que recibe el proyecto al que se asocian contactos y la lista
        /// </summary>
        /// <param name="laLista">lista de contactos involucrados</param>
        /// <param name="p">proyecto al que se involucran los contactos</param>
        public ListaInvolucradoContacto(List<Contacto> laLista, Proyecto p)
        {
            proyecto = p;
            lista = laLista;
        }
        #endregion

        #region Getters y Setters
                public Proyecto Proyecto
                {
                    get 
                    { 
                        return proyecto; 
                    }
                    set 
                    { 
                        proyecto = value; 
                    }
                }
                public List<Contacto> Lista
                {
                    get 
                    { 
                        return lista; 
                    }
                    set 
                    { 
                        lista = value; 
                    }
                }
        #endregion

        /// <summary>
        /// Metodo que elimina un contacto de la lista
        /// </summary>
        /// <param name="c">contacto a eliminar</param>
        /// <returns>Valor booleano que refleja el valor de exito de la operacion</returns>
        public bool eliminarContactoDeProyecto(Contacto c)
        {
            return lista.Remove(c);   
        }
        /// <summary>
        /// Metodo que agrega un contacto al proyecto
        /// </summary>
        /// <param name="c">contacto a agregar</param>
        /// <returns>Valor booleano que flejea el valor de exito de la operacion</returns>
        public bool agregarContactoAProyecto(Contacto c)
        {
            lista.Add(c);
            if (lista.Last() == c)
                return true;
            else
                return false;
        }
    }
}
