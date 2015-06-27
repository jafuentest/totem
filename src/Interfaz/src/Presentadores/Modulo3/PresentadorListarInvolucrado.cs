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
using System.Web;


namespace Presentadores.Modulo3
{
    public class PresentadorListarInvolucrado
    {
        private IContratoListarInvolucrado vista;
        private static ListaInvolucradoContacto listaContacto;
        private static ListaInvolucradoUsuario listaUsuario;
        private static Proyecto elProyecto;

        /// <summary>
        /// Constructor del presentador listar involucrado
        /// </summary>
        /// <param name="vista">Contrato que va a acceder el presentador listar involucrado</param>
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

        /// <summary>
        /// Metodo para inicializar la lista de contactos y usuarios
        /// </summary>
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
        /// <summary>
        /// Metodo para cargar los usuarios involucrados a la tabla
        /// </summary>
        public void CargarUsuario()
        {
            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarUsuariosInvolucradosPorProyecto();
            ListaInvolucradoUsuario listUsuario = (ListaInvolucradoUsuario)comando.Ejecutar(elProyecto);
            foreach(Usuario user in listUsuario.Lista){
                vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_tr_id + user.Username + RecursosInterfazM3.Cerrar_etiqueta;
                vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + user.Nombre + RecursosInterfazM3.CerrarEtiqueta_td;
                vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + user.Apellido + RecursosInterfazM3.CerrarEtiqueta_td;
                vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + user.Cargo + RecursosInterfazM3.CerrarEtiqueta_td;
                vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + RecursosInterfazM3.Desarrollo_del_software + RecursosInterfazM3.CerrarEtiqueta_td;
                vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td;
                vista.laTabla += RecursosInterfazM3.Abrir_boton_detalleUsuario + user.Username + RecursosInterfazM3.CerrarBoton;
                vista.laTabla += RecursosInterfazM3.Abrir_botoneliminarinvusuario + user.Username + RecursosInterfazM3.CerrarBoton;
                vista.laTabla += RecursosInterfazM3.CerrarEtiqueta_td;
                vista.laTabla += RecursosInterfazM3.CerrarEtiqueta_tr;
            }
        }
        /// <summary>
        /// Metododo para cargar los contactos involucrados a la tabla
        /// </summary>
        public void CargarContacto()
        {
            Comando<Entidad, Entidad> comando = FabricaComandos.CrearComandoConsultarContactosInvolucradosPorProyecto();
            ListaInvolucradoContacto listContacto = (ListaInvolucradoContacto)comando.Ejecutar(elProyecto);
            foreach(Contacto contacto in listContacto.Lista){
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_tr_id + contacto.Id + RecursosInterfazM3.Cerrar_etiqueta;
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + contacto.Con_Nombre + RecursosInterfazM3.CerrarEtiqueta_td;
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + contacto.Con_Apellido + RecursosInterfazM3.CerrarEtiqueta_td;
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + contacto.ConCargo + RecursosInterfazM3.CerrarEtiqueta_td;
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td + RecursosInterfazM3.Cliente_juridico + RecursosInterfazM3.CerrarEtiqueta_td;
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td;
               vista.laTabla += RecursosInterfazM3.Abrir_botondetalleContacto + contacto.Id + RecursosInterfazM3.CerrarBoton;
               vista.laTabla += RecursosInterfazM3.Abrir_botoneliminarinvcontact + contacto.Id + RecursosInterfazM3.CerrarBoton;
               vista.laTabla += RecursosInterfazM3.AbrirEtiqueta_td;
               vista.laTabla += RecursosInterfazM3.CerrarEtiqueta_tr;
            }
        }
        /// <summary>
        /// Metodo para cargar usuarios y contactos involucrados
        /// </summary>
        public void CargarInvolucrados()
        {
            CargarUsuario();
            CargarContacto();
        }
        /// <summary>
        /// Metodo que valida y obtiene las variables de URL
        /// </summary>
        public void ObtenerVariablesURL()
        {
            String error = HttpContext.Current.Request.QueryString["error"];
            if (error != null && error.Equals("input_malicioso"))
            {
                vista.alertClase = RecursosInterfazM3.Alerta_Clase_Error;
                vista.alertRol = RecursosInterfazM3.Alerta_Rol;
                vista.alert = RecursosInterfazM3.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursosInterfazM3.Alerta_Html_Final;
            }

        }
    }
    }
