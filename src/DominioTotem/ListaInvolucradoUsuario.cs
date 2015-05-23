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
        public ListaInvolucradoUsuario()
        {
            proyecto = null;
            lista = new List<Usuario>();
        }
        public ListaInvolucradoUsuario(Proyecto p)
        {
            proyecto = p;
            lista = new List<Usuario>();
        }
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

        public ListaInvolucradoUsuario obtenerUsuariosInvolucradosProyecto(Proyecto elProyecto)
        {
            throw new NotImplementedException();
        }
        public bool eliminarUsuarioDeProyecto(Usuario u)
        {
            return lista.Remove(u);
            
            //throw new NotImplementedException();
        }
        public bool agregarUsuarioAProyecto(Usuario u)
        {
            lista.Add(u);

            if (lista.Last() == u)
                return true;
            else
                return false;
        }
        public bool agregarListaEnBD(ListaInvolucradoUsuario laLista)
        {
            throw new NotImplementedException();
        }

    }
}
