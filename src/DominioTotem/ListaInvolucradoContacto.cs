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
        public ListaInvolucradoContacto()
        {
            proyecto = null;
            lista = new List<Contacto>();
        }
        public ListaInvolucradoContacto(Proyecto p)
        {
            proyecto = p;
            lista = new List<Contacto>();
        }
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

        public ListaInvolucradoContacto obtenerContactosInvolucradosProyecto(Proyecto elProyecto)
        {
            throw new NotImplementedException();
        }
        public bool eliminarContactoDeProyecto(Contacto c)
        {
            return lista.Remove(c);   
        }
        public bool agregarContactoAProyecto(Contacto c)
        {
            lista.Add(c);
            if (lista.Last() == c)
                return true;
            else
                return false;
        }
        public bool agregarListaEnBD(ListaInvolucradoContacto laLista)
        {
            throw new NotImplementedException();
        }
    }
}
