using Comandos;
using Comandos.Fabrica;
using Contratos.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
using Dominio.Entidades.Modulo7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Presentadores.Modulo3
{
    public class PresentadorAgregarInvolucrado
    {
        private IContratoAgregarInvolucrado vista;
        public PresentadorAgregarInvolucrado(IContratoAgregarInvolucrado laVista)
        {
            vista = laVista;
        }

        public void LlenarComboEmpresa (){
            vista.comboTipoEmpresa.Enabled = true;

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("-1", "Selecciona una empresa");
            options.Add("1", "Cliente Juridico");
            options.Add("2", "Desarrollo de Software");
            

            vista.comboTipoEmpresa.DataSource = options;
            vista.comboTipoEmpresa.DataTextField = "value";
            vista.comboTipoEmpresa.DataValueField = "key";
            vista.comboTipoEmpresa.DataBind();
        }

        public void ListarCargo() {
            vista.comboCargo.Enabled = true;
            Dictionary<string, string> options = new Dictionary<string, string>();
            if (vista.comboCargo.SelectedIndex == 1){
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

        public void ListarUsuarioSegunCargo() {
            vista.comboPersonal.Enabled = true;
            String cargoSelecionado = vista.comboCargo.SelectedValue;
            Dictionary<String, string> options = new Dictionary<string, string>();
            Comando<String, List<Entidad>> comando = FabricaComandos.CrearComandoListarUsuariosPorCargo();
            List<Entidad> listUsuario = comando.Ejecutar(cargoSelecionado);
            foreach (Entidad usuario in listUsuario)
            {
                options.Add(((Usuario)usuario).Username, ((Usuario)usuario).Nombre + " " + ((Usuario)usuario).Apellido);
            }
            vista.comboPersonal.DataSource = options;
            vista.comboPersonal.DataTextField = "value";
            vista.comboPersonal.DataValueField = "key";
            vista.comboPersonal.DataBind();
        }

        public void QuitarUsuarioSeleccionado() { 
        
        }

        public void SeleccionarUsuario() {
            String userName = vista.comboPersonal.SelectedValue;
            Comando<String, Entidad> comando = FabricaComandos.CrearComandoDatosUsuariosUsername();
            Usuario user = (Usuario)comando.Ejecutar(userName);
            vista.laTabla.Text += "<tr id=\"" + user.Username + "\" >";
            vista.laTabla.Text += "<td>" + user.Nombre + "</td>";
            vista.laTabla.Text += "<td>" + user.Apellido + "</td>";
            vista.laTabla.Text += "<td>" + user.Cargo + "</td>";
            vista.laTabla.Text += "<td>"+vista.comboTipoEmpresa.SelectedItem.Text+"</td>";
            vista.laTabla.Text += "<td>";
            vista.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" href=\"AgregarInvolucrado.aspx?usuarioaeliminar=" + user.Username + "\"></a>";
            vista.laTabla.Text += "</td>";
            vista.laTabla.Text += "</tr>";
        }
    }

}
