using Comandos;
using Comandos.Fabrica;
using Contratos.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo3;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Presentadores.Modulo3
{
    public class PresentadorListarInvolucrado
    {
        private IContratoListarInvolucrado vista;
        private static ListaInvolucradoContacto listaContacto;
        private static ListaInvolucradoUsuario listaUsuario;
        private static Proyecto elProyecto;
        public PresentadorListarInvolucrado(IContratoListarInvolucrado laVista)
        {
            vista = laVista;
        }
        public void MostrarModal(String alert){
            if (alert == "true")
            {
                vista.alertClase = RecursosInterfazM3.Alerta_Clase_Exito;
                vista.alertRol = RecursosInterfazM3.Alerta_Rol;
                vista.alert = RecursosInterfazM3.Alerta_Html +
                 RecursosInterfazM3.Alerta_Usuario_Agregado +
                 RecursosInterfazM3.Alerta_Html_Final;
            }
        }
        public void iniciarlista()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            elProyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            elProyecto.Codigo = "TOT";
            listaContacto = (ListaInvolucradoContacto)laFabrica
                                                .ObtenetListaInvolucradoContacto();
            listaUsuario = (ListaInvolucradoUsuario)laFabrica
                                                 .ObtenetListaInvolucradoUsuario();
        }
        public void CargarUsuario()
        {
            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarUsuariosInvolucradosPorProyecto();
            ListaInvolucradoUsuario listUsuario = (ListaInvolucradoUsuario)comando.Ejecutar(elProyecto);
            foreach(Usuario user in listUsuario.Lista){
                vista.laTabla += "<tr id=\"" + user.Username + "\" >";
                vista.laTabla += "<td>" + user.Nombre + "</td>";
                vista.laTabla += "<td>" + user.Apellido + "</td>";
                vista.laTabla += "<td>" + user.Cargo + "</td>";
                vista.laTabla += "<td>" + "Desarrollo del software" + "</td>";
                vista.laTabla += "<td>";
                vista.laTabla += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrados.aspx?usuarioaeliminar=" + user.Username + "\"></a>";
                vista.laTabla += "</td>";
                vista.laTabla += "</tr>";
            }
        }
        public void CargarContacto()
        {
            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarContactosInvolucradosPorProyecto();
            ListaInvolucradoContacto listContacto = (ListaInvolucradoContacto)comando.Ejecutar(elProyecto);
            foreach(Contacto contacto in listContacto.Lista){
               vista.laTabla += "<tr id=\"" + contacto.Id + "\" >";
               vista.laTabla += "<td>" + contacto.Con_Nombre + "</td>";
               vista.laTabla += "<td>" + contacto.Con_Apellido + "</td>";
               vista.laTabla += "<td>" + contacto.ConCargo + "</td>";
               vista.laTabla += "<td>" + "Cliente Juridico" + "</td>";
               vista.laTabla += "<td>";
               vista.laTabla += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrados.aspx?usuarioaeliminar=" + contacto.Id + "\"></a>";
               vista.laTabla += "</td>";
               vista.laTabla += "</tr>";
            }
        }
        public void CargarInvolucrados()
        {
            CargarUsuario();
            CargarContacto();
        }
    }
    }
