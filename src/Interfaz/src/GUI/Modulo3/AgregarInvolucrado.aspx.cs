using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DominioTotem;

public partial class GUI_Modulo3_Default : System.Web.UI.Page
{
    private ListaInvolucradoContacto listaContactos;
    private ListaInvolucradoUsuario listaUsuarios;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        comboCargo.SelectedIndexChanged +=
                       new EventHandler(actualizarComboCargos); 
        comboPersonal.SelectedIndexChanged +=
                new EventHandler(actualizarComboPersonal);
        
        if (user != null)
        {
            if (user.username != "" && user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
            }
            else
            {
                //Mostrar menu lateral
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }
        comboCargo.Enabled = false;
        comboPersonal.Enabled = false;
        if (!IsPostBack) // verificar si la pagina se muestra por primera vez
        {
            llenarComboTipoEmpresas();
        }
    }

    protected void llenarComboTipoEmpresas()
    {
        Dictionary<string, string> options = new Dictionary<string, string>();
        options.Add("-1", "Selecciona una opcion");
        options.Add("1", "Cliente");
        options.Add("2", "Compañia de Software");

        comboTipoEmpresa.DataSource = options;
        comboTipoEmpresa.DataTextField = "value";
        comboTipoEmpresa.DataValueField = "key";
        comboTipoEmpresa.DataBind();
    }
    protected void actualizarComboCargos(object sender, EventArgs e)
    {
        Dictionary<string, string> options = new Dictionary<string, string>();

        options.Add("-1", "Selecciona un cargo");

        comboCargo.Items.Clear();
        if (!comboTipoEmpresa.SelectedValue.Equals("-1"))
        {
            comboCargo.Enabled = true;
            if (comboTipoEmpresa.SelectedValue.Equals("1"))
            {
                ClienteJuridico cli = new ClienteJuridico();
                cli.Jur_Id = "1";
                LogicaNegociosTotem.Modulo3.LogicaInvolucrados lInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados();
                List<String> listaCargos = new List<String>();
                listaCargos = lInv.ListarCargosEmpleados(cli);

                try
                {
                    foreach (String cargo in listaCargos)
                    {
                        options.Add(cargo, cargo);
                    }
                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();
                List<String> listaCargos = new List<String>();
                listaCargos = mU.ListarCargosUsuarios();

                try
                {
                    foreach (String cargo in listaCargos)
                    {
                        options.Add(cargo, cargo);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        comboCargo.DataSource = options;
        comboCargo.DataTextField = "value";
        comboCargo.DataValueField = "key";
        comboCargo.DataBind();
    }

    protected void actualizarComboPersonal(object sender, EventArgs e)
    {

    }

    protected void AgregarInvolucrados_Click(object sender, EventArgs e)
    {
        // Falta implementar jalando los comoboboxes
    }


}