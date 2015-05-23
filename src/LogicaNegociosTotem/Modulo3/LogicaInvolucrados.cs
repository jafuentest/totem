using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegociosTotem.Modulo3
{
    public class LogicaInvolucrados
    {

        private DominioTotem.ListaInvolucradoContacto contactosInvolucrados;
        private DominioTotem.ListaInvolucradoUsuario usuariosInvolucrados;

        public DominioTotem.ListaInvolucradoContacto ContactosInvolucrados
        {
            get { return contactosInvolucrados; }
            set { contactosInvolucrados = value; }
        }
        public DominioTotem.ListaInvolucradoUsuario UsuariosInvolucrados
        {
            get { return usuariosInvolucrados; }
            set { usuariosInvolucrados = value; }
        }

        public LogicaInvolucrados(DominioTotem.Proyecto elProyecto)
        {
            DominioTotem.ListaInvolucradoContacto listaContactos = new DominioTotem.ListaInvolucradoContacto();
            DominioTotem.ListaInvolucradoUsuario listaUsuarios = new DominioTotem.ListaInvolucradoUsuario();

            contactosInvolucrados = listaContactos.obtenerContactosInvolucradosProyecto(elProyecto);
            usuariosInvolucrados = listaUsuarios.obtenerUsuariosInvolucradosProyecto(elProyecto);
        }
        public void agregarContactoALista(DominioTotem.Contacto elContacto)
        {
            contactosInvolucrados.agregarContactoAProyecto(elContacto);
        }
        public void agregarUsuarioALista(DominioTotem.Usuario elUsuario)
        {
            if (!usuariosInvolucrados.agregarUsuarioAProyecto(elUsuario))
                throw new Exception();
        }


    }
}
