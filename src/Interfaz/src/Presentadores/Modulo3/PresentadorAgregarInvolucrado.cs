using Comandos;
using Comandos.Fabrica;
using Contratos.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo3;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Presentadores.Modulo3
{
    public class PresentadorAgregarInvolucrado
    {
        private IContratoAgregarInvolucrado vista;
        private static ListaInvolucradoContacto listaContacto;
        private static ListaInvolucradoUsuario listaUsuario;

        /// <summary>
        /// Constructor del presentador agregar involucrado
        /// </summary>
        /// <param name="vista">Contrato que va a acceder el presentador agregar involucrado</param>
        public PresentadorAgregarInvolucrado(IContratoAgregarInvolucrado laVista)
        {
               
               vista = laVista;
        }
        /// <summary>
        /// Metodo que inicializa lista de contactos y usuarios 
        /// </summary>
        public void iniciarlista()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            listaContacto = (ListaInvolucradoContacto)laFabrica
                                                 .ObtenetListaInvolucradoContacto();
            listaUsuario = (ListaInvolucradoUsuario)laFabrica
                                                 .ObtenetListaInvolucradoUsuario();
        }
        /// <summary>
        /// Metodo que llena el comboBox del tipo de empresa 
        /// </summary>
        public void LlenarComboEmpresa (){
            this.vista.comboTipoEmpresa.Enabled = true;

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una empresa");
            options.Add("1", "Cliente Juridico");
            options.Add("2", "Desarrollo de Software");


            vista.comboTipoEmpresa.DataSource = options;
            vista.comboTipoEmpresa.DataTextField = "value";
            vista.comboTipoEmpresa.DataValueField = "key";
            vista.comboTipoEmpresa.DataBind();
        }
        /// <summary>
        /// Metodo que llena el comboBox con los cargos dependiendo del tipo de empresa
        /// </summary>
        /// <param name="codigo">valor seleccionado en el combo tipo empresa</param>
        public void ListarCargo(string SelectedValue)
        {
            vista.comboCargo.Enabled = true;
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Seleccionar Cargo");
            try
            {
                if (this.vista.comboCargo.SelectedIndex == 1)
                {
                    Comando<bool, List<String>> comando_juridico = FabricaComandos.CrearComandoConsultarListaCargos();

                    List<String> listCago = comando_juridico.Ejecutar(true);
                    foreach (String cargo in listCago)
                    {
                        options.Add(cargo, cargo);
                    }
                }
                else
                {
                    Comando<bool, List<String>> comando_usuario = FabricaComandos.CrearComandoLeerCargosUsuarios();
                    List<String> listCago = comando_usuario.Ejecutar(true);
                    foreach (String cargo in listCago)
                    {
                        options.Add(cargo, cargo);
                    }
                }
            } catch (ExceptionTotemConexionBD){
                vista.alertaUsuarioClase = RecursosInterfazM3.Alerta_Clase_Error;
                vista.alertaUsuarioRol = RecursosInterfazM3.Alerta_Rol;
                vista.AlertaUsuario = RecursosInterfazM3.Alerta_Html +
                 RecursosInterfazM3.Alerta_Conexion_Error +
                 RecursosInterfazM3.Alerta_Html_Final;
            }
            catch (ExceptionTotem)
            {
                vista.alertaUsuarioClase = RecursosInterfazM3.Alerta_Clase_Error;
                vista.alertaUsuarioRol = RecursosInterfazM3.Alerta_Rol;
                vista.AlertaUsuario = RecursosInterfazM3.Alerta_Html +
                 RecursosInterfazM3.Alerta_Totem_Error +
                 RecursosInterfazM3.Alerta_Html_Final;
            }

            vista.comboCargo.DataSource = options;
            vista.comboCargo.DataTextField = "value";
            vista.comboCargo.DataValueField = "key";
            vista.comboCargo.DataBind();
        }
        /// <summary>
        /// Metodo para eliminar el usuario
        /// </summary>
        public String eliminarusuario()
        {
            return vista.eliminacionUsuario;
        }
        /// <summary>
        /// Metodo para eliminar el contacto
        /// </summary>
        public String eliminarcontacto()
        {
            return vista.eliminacionContacto;
        }
        /// <summary>
        /// Metodo para el modal eliminar
        /// </summary>
        public void modaleliminar()
        {
            if (vista.eliminacionContacto == null)
                vista.user_name = vista.eliminacionUsuario;
            else
                vista.contacto_id = vista.eliminacionContacto;
        }
        /// <summary>
        /// Metodo para saber que usuarios ya estan involucrados al proyecto
        /// </summary>
        /// <param name="codigo">lista de usuarios, usuario por buscar</param>
        public bool UsuarioEstaEnProyecto(Entidad lista,string buscar)
        {
            bool exito = false;
            ListaInvolucradoUsuario Lalista = (ListaInvolucradoUsuario)lista;
            foreach(Usuario usuario in Lalista.Lista){
                 if (usuario.Username == buscar)
                     exito = true;
             }   
            return exito;
        }
        /// <summary>
        /// Metodo para saber que contactos ya estan involucrados al proyecto
        /// </summary>
        /// <param name="codigo">lista de contactos, contacto por buscar</param>
        public bool ContactoEstaEnProyecto(Entidad lista, string buscar)
        {
            bool exito = false;
            ListaInvolucradoContacto laLista = (ListaInvolucradoContacto)lista;
            foreach (Contacto contacto in laLista.Lista)
            {
                 if (contacto.Id.ToString() == buscar)
                     exito = true;
            }
            return exito;
        }
        /// <summary>
        /// Metodo para llenar el comboBox del personal segun el cargo seleccionado
        /// </summary>
        /// <param name="codigo">cargo seleccionado</param>
        public void ListarUsuarioSegunCargo(string SelectedValue,string proyectoActual)
        {
            vista.comboPersonal.Enabled = true;
            String cargoSelecionado = vista.comboCargo.SelectedValue;
            Dictionary<String, string> options = new Dictionary<string, string>();
            Comando<Entidad, Entidad> comandoUsuario = FabricaComandos.CrearComandoConsultarUsuariosInvolucradosPorProyecto(); 
            Comando<Entidad, Entidad> comandoContacto = FabricaComandos.CrearComandoConsultarContactosInvolucradosPorProyecto(); 
            options.Add("-1","Seleccionar Personal");
            //inicio de l prueba
            Proyecto elProyecto = new Proyecto();
            elProyecto.Codigo = proyectoActual;
            //fin de la prueba
            try
            {
                if (vista.comboTipoEmpresa.SelectedValue == "1")
                {
                    Comando<Entidad, List<Entidad>> comando = FabricaComandos.CrearComandoListarContactosPorEmpresa();
                    //pruebas
                    ClienteJuridico client = new ClienteJuridico();
                    client.Id = 1;
                    //fin de prueba
                    Entidad contactoactual = comandoContacto.Ejecutar(elProyecto);
                    List<Entidad> listContacto = comando.Ejecutar(client);
                    foreach (Entidad contacto in listContacto)
                        if (((Contacto)contacto).ConCargo == cargoSelecionado && ContactoEstaEnProyecto(contactoactual,contacto.Id.ToString()) == false)
                             options.Add(((Contacto)contacto).Id.ToString(), ((Contacto)contacto).Con_Nombre + " " + ((Contacto)contacto).Con_Apellido);
                }
                if (vista.comboTipoEmpresa.SelectedValue == "2")
                {
                    Comando<String, List<Entidad>> comando = FabricaComandos.CrearComandoListarUsuariosPorCargo();
                    List<Entidad> listUsuario = comando.Ejecutar(cargoSelecionado);
                    Entidad usuariosActuales = comandoUsuario.Ejecutar(elProyecto);
                    foreach (Entidad usuario in listUsuario)
                        if (((Usuario)usuario).Cargo == cargoSelecionado && UsuarioEstaEnProyecto(usuariosActuales, ((Usuario)usuario).Username) == false)
                            options.Add(((Usuario)usuario).Username, ((Usuario)usuario).Nombre + " " + ((Usuario)usuario).Apellido);
                }
            }catch(Exception){
                vista.alertaUsuarioClase = RecursosInterfazM3.Alerta_Clase_Error;
                vista.alertaUsuarioRol = RecursosInterfazM3.Alerta_Rol;
                vista.AlertaUsuario = RecursosInterfazM3.Alerta_Html +
                 RecursosInterfazM3.Alerta_Totem_Error +
                 RecursosInterfazM3.Alerta_Html_Final;
            }
            vista.comboPersonal.DataSource = options;
            vista.comboPersonal.DataTextField = "value";
            vista.comboPersonal.DataValueField = "key";
            vista.comboPersonal.DataBind();
        }

        /// <summary>
        /// Metodo que quita lo seleccioado del comboBox
        /// </summary>
        public void removeropcion()
        {
           int index = vista.comboPersonal.SelectedIndex;
           vista.comboPersonal.Items.RemoveAt(index);
        }
        /// <summary>
        /// Metodo para seleccionar el involucrado
        /// </summary>
        public void SeleccionarUsuario() {
            String seleccion = vista.comboPersonal.SelectedValue;
            Comando<String, Entidad> comando_usuario = FabricaComandos.CrearComandoDatosUsuariosUsername();
            Comando<int, Entidad> comando_contacto = FabricaComandos.CrearComandoDatosContactoID();
            if(vista.comboPersonal.SelectedValue != "-1"){
                removeropcion();
               if (vista.comboTipoEmpresa.SelectedValue == "1")
               {
                   Contacto contacto = (Contacto)comando_contacto.Ejecutar(Convert.ToInt32(seleccion));
                   listaContacto.Lista.Add(contacto);
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_tr_id + contacto.Id + RecursosInterfazM3.Cerrar_etiqueta;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + contacto.Con_Nombre + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + contacto.Con_Apellido + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + contacto.ConCargo + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + vista.comboTipoEmpresa.SelectedItem.Text + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.Abrir_boton_eliminar + contacto.Id + RecursosInterfazM3.CerrarBoton;
                   vista.laTabla.Text += RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.CerrarEtiqueta_tr;
               }
               if (vista.comboTipoEmpresa.SelectedValue == "2")
               {
                   Usuario user = (Usuario)comando_usuario.Ejecutar(seleccion);
                   listaUsuario.Lista.Add(user);
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_tr_id + user.Username + RecursosInterfazM3.Cerrar_etiqueta;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + user.Nombre + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + user.Apellido + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + user.Cargo + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td + vista.comboTipoEmpresa.SelectedItem.Text + RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.AbrirEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.Abrir_boton_eliminar + user.Username + RecursosInterfazM3.CerrarBoton;
                   vista.laTabla.Text += RecursosInterfazM3.CerrarEtiqueta_td;
                   vista.laTabla.Text += RecursosInterfazM3.CerrarEtiqueta_tr;
               }
           }

        }
        /// <summary>
        /// Metodo para almacenar los involucrados seleccionados
        /// </summary>
        public void GuardarInvolucrados()
        {
            bool exitoContacto = false;
            bool exitoUsuario = false;
            Comando<Entidad,bool> comando_contacto = FabricaComandos.CrearComandoAgregarContactosInvolucrados();
            Comando<Entidad, bool> comando_usuario = FabricaComandos.CrearComandoAgregarUsuarioInvolucrados();
            Proyecto elProyecto = (Proyecto)FabricaEntidades.ObtenerProyecto();
            elProyecto.Codigo = "TOT";
            listaContacto.Proyecto = elProyecto;
            listaUsuario.Proyecto = elProyecto;

                 if (!(listaUsuario.Lista.Count == 0 && listaContacto.Lista.Count == 0))
                 {

                     exitoContacto = comando_contacto.Ejecutar(listaContacto);
                     exitoUsuario = comando_usuario.Ejecutar(listaUsuario);

                     HttpContext.Current.Response.Redirect(RecursosInterfazM3.ListarInvolucrados +
     RecursosInterfazM3.Codigo_Exito_Agregar);

                 }
                 else
                 {
                     vista.alertaUsuarioClase = RecursosInterfazM3.Alerta_Clase_Error;
                     vista.alertaUsuarioRol = RecursosInterfazM3.Alerta_Rol;
                     vista.AlertaUsuario = RecursosInterfazM3.Alerta_Html +
                      RecursosInterfazM3.Alerta_Seleccion_vacia +
                      RecursosInterfazM3.Alerta_Html_Final;
                 }
           
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
