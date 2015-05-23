using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTotem
{
    public class ListaInvolucradoUsuario
    {
        private Proyecto proyecto;
        private List<Usuario> lista;

        #region Constructores
        /// <summary>
        /// Constructor vacio de la lista de usuarios
        /// </summary>
        public ListaInvolucradoUsuario()
        {
            proyecto = null;
            lista = new List<Usuario>();
        }
        /// <summary>
        /// Constructor que recibe el proyecto al que se asocian usuarios, inicializa la lista en vacio 
        /// </summary>
        /// <param name="p"></param>
        public ListaInvolucradoUsuario(Proyecto p)
        {
            proyecto = p;
            lista = new List<Usuario>();
        }
        /// <summary>
        /// Constructor que recibe el proyecto al que se asocian contactos y la lista
        /// </summary>
        /// <param name="laLista">lista de usuarios involucrados</param>
        /// <param name="p">proyecto al que se involucran los contactos</param>
        public ListaInvolucradoUsuario(List<Usuario> laLista, Proyecto p)
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
        public List<Usuario> Lista
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
        /// Metodo que elimina un usuario de la lista
        /// </summary>
        /// <param name="c">usuario a eliminar</param>
        /// <returns>Valor booleano que refleja el valor de exito de la operacion</returns>
        public bool eliminarUsuarioDeProyecto(Usuario u)
        {
            return lista.Remove(u);
            
            //throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que agrega un usuario al proyecto
        /// </summary>
        /// <param name="c">usuario a agregar</param>
        /// <returns>Valor booleano que flejea el valor de exito de la operacion</returns>
        public bool agregarUsuarioAProyecto(Usuario u)
        {
            lista.Add(u);

            if (lista.Last() == u)
                return true;
            else
                return false;
        }
    }
}
