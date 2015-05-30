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
    private ListaInvolucradoContacto listaContactos = new ListaInvolucradoContacto();
    private ListaInvolucradoUsuario listaUsuarios = new ListaInvolucradoUsuario();
    private Proyecto elProyecto = new Proyecto();
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "3";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        #region redireccion a login
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
        #endregion
        if (!IsPostBack) // verificar si la pagina se muestra por primera vez
        {            
            comboCargo.Enabled = false;
            comboPersonal.Enabled = false;
            llenarComboTipoEmpresas();
            LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new
                LogicaNegociosTotem.Modulo3.LogicaInvolucrados();

        }

        elProyecto.Codigo = "TOT"; //codigo del proyecto cableado para prueba del metodo
        listaContactos.Proyecto = elProyecto;
        listaUsuarios.Proyecto = elProyecto;
        HttpCookie pcookie = Request.Cookies.Get("selectedProjectCookie");
        //elProy.Codigo =  pcookie.Values["projectCode"].ToString(); //De aqui se debe extraer el codigo del proyecto
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
        Dictionary<string, string> options = new Dictionary<string, string>();

        options.Add("-1", "Selecciona un personal");

        comboPersonal.Enabled = true;
        if (comboTipoEmpresa.SelectedIndex == 2 && comboCargo.SelectedIndex != -1)
        {
            LogicaNegociosTotem.Modulo7.ManejadorUsuario mU = new LogicaNegociosTotem.Modulo7.ManejadorUsuario();
            List<Usuario> listaUsuarios = new List<Usuario>();
            listaUsuarios = mU.ListarUsuariosCargo(comboCargo.SelectedItem.ToString());
            foreach (Usuario u in listaUsuarios)
            {
                options.Add(u.username, u.nombre + " " + u.apellido);
            }
            comboPersonal.DataSource = options;
            comboPersonal.DataTextField = "value";
            comboPersonal.DataValueField = "key";
            comboPersonal.DataBind();
        }
    }

    protected void AgregarInvolucrados_Click(object sender, EventArgs e)
    {
        LogicaNegociosTotem.Modulo3.LogicaInvolucrados logInv = new LogicaNegociosTotem.Modulo3.LogicaInvolucrados();
            Usuario elUsuario = logInv.obtenerDatosUsuarioUsername(comboPersonal.SelectedValue);
            elUsuario.username = comboPersonal.SelectedValue;
            #region agregar usuario en tabla y en bd
            if (listaUsuarios.agregarUsuarioAProyecto(elUsuario))
            {
                try {

                    if(logInv.agregarUsuariosEnBD(listaUsuarios))
                    {
                        this.laTabla.Text += "<tr id=\"" + elUsuario.username + "\" >";
                        this.laTabla.Text += "<td>" + elUsuario.nombre + "</td>";
                        this.laTabla.Text += "<td>" + elUsuario.apellido + "</td>";
                        this.laTabla.Text += "<td>" + elUsuario.cargo + "</td>";
                        this.laTabla.Text += "<td>Compañía De Software</td>";
                        this.laTabla.Text += "<td>";
                        this.laTabla.Text += "<a class=\"btn btn-default glyphicon glyphicon-pencil\" href=\"<%= Page.ResolveUrl(\"~/GUI/Modulo2/DetallarCliente.aspx\") % ></a>";
                        this.laTabla.Text += "<a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"  runat=\"server\"></a>";
                        this.laTabla.Text += "</td>";
                        this.laTabla.Text += "</tr>";

                        comboCargo.SelectedIndex = 0;
                        comboPersonal.SelectedIndex = 0;
                        Dictionary<string, string> options = new Dictionary<string, string>();
                        options.Add("-1", "Seleccione una opcion");
                        comboCargo.Items.Clear();
                        comboCargo.DataSource = options;
                        comboCargo.DataTextField = "value";
                        comboCargo.DataValueField = "key";
                        comboCargo.DataBind();

                        comboPersonal.Items.Clear();
                        comboPersonal.DataSource = options;
                        comboPersonal.DataTextField = "value";
                        comboPersonal.DataValueField = "key";
                        comboPersonal.DataBind();
                    }
                    else
                    {
                        
                    }
                }
                catch(ExcepcionesTotem.Modulo3.InvolucradoRepetidoException ex)
                {
                }
                catch (Exception ex)
                {
                }
            }
            #endregion

            }
    //protected void btn_enviar_Click(object sender, EventArgs e)
    //{

    //}
}