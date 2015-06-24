using Comandos;
using Comandos.Fabrica;
using Contratos.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo3;
using Dominio.Entidades.Modulo4;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
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
        public PresentadorAgregarInvolucrado(IContratoAgregarInvolucrado laVista)
        {
               
               vista = laVista;
        }
        public void iniciarlista()
        {
            FabricaEntidades laFabrica = new FabricaEntidades();
            listaContacto = (ListaInvolucradoContacto)laFabrica
                                                 .ObtenetListaInvolucradoContacto();
            listaUsuario = (ListaInvolucradoUsuario)laFabrica
                                                 .ObtenetListaInvolucradoUsuario();
        }

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

        public void ListarCargo(string SelectedValue)
        {
            vista.comboCargo.Enabled = true;
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Seleccionar Cargo");
            if (this.vista.comboCargo.SelectedIndex == 1)
            {
                Comando<bool, List<String>> comando_juridico = FabricaComandos.CrearComandoConsultarListaCargos();
      
                List<String> listCago = comando_juridico.Ejecutar(true);
                foreach (String cargo in listCago)
                {
                    options.Add(cargo, cargo);
                }
            }
            else {
                Comando<bool, List<String>> comando_usuario = FabricaComandos.CrearComandoLeerCargosUsuarios();
                List<String> listCago = comando_usuario.Ejecutar(true);
                foreach (String cargo in listCago)
                {
                    options.Add(cargo,cargo);
                }
            }
            vista.comboCargo.DataSource = options;
            vista.comboCargo.DataTextField = "value";
            vista.comboCargo.DataValueField = "key";
            vista.comboCargo.DataBind();
        }
        public String eliminarusuario()
        {
            return vista.eliminacionUsuario;
        }
        public String eliminarcontacto()
        {
            return vista.eliminacionContacto;
        }
        public void modaleliminar()
        {
            if (vista.eliminacionContacto == null)
                vista.user_name = vista.eliminacionUsuario;
            else
                vista.contacto_id = vista.eliminacionContacto;
        }
        public void ListarUsuarioSegunCargo(string SelectedValue)
        {
            vista.comboPersonal.Enabled = true;
            String cargoSelecionado = vista.comboCargo.SelectedValue;
            Dictionary<String, string> options = new Dictionary<string, string>();
            options.Add("-1","Seleccionar Personal");
            if (vista.comboTipoEmpresa.SelectedValue == "1")
            {
                Comando<Entidad, List<Entidad>> comando = FabricaComandos.CrearComandoListarContactosPorEmpresa();
                ClienteJuridico client = new ClienteJuridico();
                client.Id = 1;
               List<Entidad> listContacto = comando.Ejecutar(client);
                foreach (Entidad contacto in listContacto)
                    if(((Contacto)contacto).ConCargo == cargoSelecionado)
                        options.Add(((Contacto)contacto).Id.ToString(), ((Contacto)contacto).Con_Nombre + " " + ((Contacto)contacto).Con_Apellido);
            }
            if(vista.comboTipoEmpresa.SelectedValue == "2"){
                Comando<String, List<Entidad>> comando = FabricaComandos.CrearComandoListarUsuariosPorCargo();
                List<Entidad> listUsuario = comando.Ejecutar(cargoSelecionado);
               foreach (Entidad usuario in listUsuario)
                  options.Add(((Usuario)usuario).Username, ((Usuario)usuario).Nombre + " " + ((Usuario)usuario).Apellido);
            }
            vista.comboPersonal.DataSource = options;
            vista.comboPersonal.DataTextField = "value";
            vista.comboPersonal.DataValueField = "key";
            vista.comboPersonal.DataBind();
        }

        public void QuitarUsuarioSeleccionado() { 
               
        }

        public void removeropcion()
        {
           int index = vista.comboPersonal.SelectedIndex;
           vista.comboPersonal.Items.RemoveAt(index);
        }

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
                   vista.laTabla.Text += "<tr id=\"" + contacto.Id + "\" >";
                   vista.laTabla.Text += "<td>" + contacto.Con_Nombre + "</td>";
                   vista.laTabla.Text += "<td>" + contacto.Con_Apellido + "</td>";
                   vista.laTabla.Text += "<td>" + contacto.ConCargo + "</td>";
                   vista.laTabla.Text += "<td>" + vista.comboTipoEmpresa.SelectedItem.Text + "</td>";
                   vista.laTabla.Text += "<td>";
                   vista.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrados.aspx?usuarioaeliminar=" + contacto.Id + "\"></a>";
                   vista.laTabla.Text += "</td>";
                   vista.laTabla.Text += "</tr>";
               }
               if (vista.comboTipoEmpresa.SelectedValue == "2")
               {
                   Usuario user = (Usuario)comando_usuario.Ejecutar(seleccion);
                   listaUsuario.Lista.Add(user);
                   vista.laTabla.Text += "<tr id=\"" + user.Username + "\" >";
                   vista.laTabla.Text += "<td>" + user.Nombre + "</td>";
                   vista.laTabla.Text += "<td>" + user.Apellido + "</td>";
                   vista.laTabla.Text += "<td>" + user.Cargo + "</td>";
                   vista.laTabla.Text += "<td>" + vista.comboTipoEmpresa.SelectedItem.Text + "</td>";
                   vista.laTabla.Text += "<td>";
                   vista.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrados.aspx?usuarioaeliminar=" + user.Username + "\"></a>";
                   vista.laTabla.Text += "</td>";
                   vista.laTabla.Text += "</tr>";
               }
           }

        }
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
                     vista.Alerta_AgregarUsuario_Fracaso = RecursosInterfazM3.Alerta_Html +
                      RecursosInterfazM3.Alerta_Seleccion_vacia +
                      RecursosInterfazM3.Alerta_Html_Final;
                 }
           
        }
   /*     public void ObtenerVariablesURL()
        {
            String error = HttpContext.Current.Request.QueryString["error"];
            if (error != null && error.Equals("input_malicioso"))
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursosGeneralPresentadores.Mensaje_Error_InputInvalido +
                    RecursoInterfazM2.Alerta_Html_Final;
            }

        }
    **/
    }

}
