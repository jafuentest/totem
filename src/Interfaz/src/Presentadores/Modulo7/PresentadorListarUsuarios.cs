using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo7;
using Dominio.Entidades.Modulo7;
using Comandos;
using Comandos.Fabrica;
using Dominio;

namespace Presentadores.Modulo7
{
    /// <summary>
    /// Clase que represnta el presentador de la vista Agregar Usuario segun el patron MVP
    /// </summary>
    public class PresentadorListarUsuarios
    {
        //Variable que contiene la vista respectiva de este presentador a ser manipulada
        IContratoListarUsuarios vista;

        /// <summary>
        /// Constructor de esta clase que recibe la vista
        /// </summary>
        /// <param name="vista">La vista que sera manipulada por este presentador</param>
        public PresentadorListarUsuarios(IContratoListarUsuarios vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo que llena el DataTable con los usuarios
        /// </summary>
        public void LlenarTabla()
        {
            //Lista que contendra a todos los usuarios
            List<Entidad> listaUsuario;

            //Instanciamos el comando ListarUsuarios con la fabrica
            Comando<bool, List<Entidad>> comandoUsuarios = FabricaComandos.CrearComandoListarUsuarios();

            listaUsuario = comandoUsuarios.Ejecutar(true);

            //Recorremos la lista para agregar cada entidad (Usuario) al Data Table
            foreach (Entidad entidad in listaUsuario)
            {
                //Casteamos la entidad para ser tratada como un usuario
                Usuario usuario = entidad as Usuario;

                //Lo agregamos a la pagina web
                vista.tablaUsuarios.Text += "<tr>";
                vista.tablaUsuarios.Text += "<td>" + usuario.Username.ToString() + "</td>";
                vista.tablaUsuarios.Text += "<td>" + usuario.Nombre.ToString() + "</td>";
                vista.tablaUsuarios.Text += "<td>" + usuario.Apellido.ToString() + "</td>";
                vista.tablaUsuarios.Text += "<td>" + usuario.Cargo.ToString() + "</td>";
                vista.tablaUsuarios.Text += "<td>";
                vista.tablaUsuarios.Text += "<a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"DetalleUsuario.aspx?username=" + usuario.Username + "\"></a>";
                vista.tablaUsuarios.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"ListarUsuarios.aspx?usernameeliminar=" + usuario.Username + "\"></a>";
                vista.tablaUsuarios.Text += "</td>";
                vista.tablaUsuarios.Text += "</tr>";
            }

        }
    }
}
