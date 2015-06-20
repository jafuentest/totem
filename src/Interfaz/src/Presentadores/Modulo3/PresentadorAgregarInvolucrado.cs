using Comandos;
using Comandos.Fabrica;
using Contratos.Modulo3;
using Dominio;
using Dominio.Entidades.Modulo2;
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
        
        }

        public void QuitarUsuarioSeleccionado() { 
        
        }

        public void SeleccionarUsuario() { 
        
        }
    }

}
