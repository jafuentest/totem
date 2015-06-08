using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GUI_Modulo4_CrearProyecto : System.Web.UI.Page
{

    int contador = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        if (user != null)
        {
            if (user.username != "" &&
                user.clave != "")
            {
                ((MasterPage)Page.Master).ShowDiv = true;
            }
            else
            {
                ((MasterPage)Page.Master).MostrarMenuLateral = false;
                ((MasterPage)Page.Master).ShowDiv = false;
            }

        }
        else
        {
            Response.Redirect("../Modulo1/M1_login.aspx");
        }

        String success = Request.QueryString["success"];
        if (success != null)
        {
            switch (success)
            {
                case "0":
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto no se ha podido agregar...</div>";
                    break;
            }
        }
        
        if (csEstado.Checked)
        {
            csEstado.Text = "  Activo";
        }
        else
        {
            csEstado.Text = "  Inactivo";
        }

        if (!IsPostBack)
        {
            llenarComboTipoCliente();
            LlenaComboMonedas();
        }
    }

    protected void CreateProject_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Input_Nombre.Value.Equals("") || this.Input_Codigo.Value.Equals("") || this.Input_Descripcion.Value.Equals("") || this.Input_Precio.Value.Equals(""))
            {
                //HttpContext.Current.Response.Redirect("CrearProyecto.aspx?success=0");
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Por favor ingrese todos los campos</div>";
            }
            else
            {
                
                DominioTotem.Proyecto proyecto = new DominioTotem.Proyecto();
                proyecto.Codigo = this.Input_Codigo.Value;
                proyecto.Nombre = this.Input_Nombre.Value;
                proyecto.Descripcion = this.Input_Descripcion.Value;
                proyecto.Moneda = this.comboMoneda.SelectedItem.ToString();
                proyecto.Costo = int.Parse(this.Input_Precio.Value);
                proyecto.Estado = true;
                bool saved;

                if (comboTipoCliente.SelectedValue.Equals("1"))
                {
                    int idClienteNatural = LogicaNegociosTotem.Modulo4.LogicaProyecto.ObtenerIDClienteNatural(dpCLientes.SelectedValue);
                    saved = LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyectoClienteNatural(proyecto, idClienteNatural);
                }
                else
                {
                    int idClienteJuridico = LogicaNegociosTotem.Modulo4.LogicaProyecto.ObtenerIDClienteJuridico(dpCLientes.SelectedValue);
                    saved = LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyectoClienteJuridico(proyecto, idClienteJuridico);
                }

                if (saved == true)
                {
                    HttpContext.Current.Response.Redirect("../Modulo1/Default.aspx?success=2");
                    Console.Out.WriteLine("Saved es true");
                }
                else
                {
                    HttpContext.Current.Response.Redirect("CrearProyecto.aspx?success=0");
                    Console.Out.WriteLine("Saved es false");
                }
            }
            
        }
        catch (Exception ex){
            Console.Out.WriteLine(ex.Message);
        }
        

    }

    protected void llenarComboTipoCliente()
    {
        Dictionary<string, string> options = new Dictionary<string, string>();
        options.Add("-1", "Seleccione una opcion...");
        options.Add("1", "Natural");
        options.Add("2", "Juridico");

        comboTipoCliente.DataSource = options;
        comboTipoCliente.DataTextField = "value";
        comboTipoCliente.DataValueField = "key";
        comboTipoCliente.DataBind();
    }

    public void actualizarComboCliente(object sender, EventArgs e)
    {
        if (comboTipoCliente.SelectedValue.Equals("1"))
        {
            dpCLientes.Items.Clear();
            DataTable clientesNatureales = LogicaNegociosTotem.Modulo4.LogicaProyecto.BuscarClientesNaturales();
            Dictionary<string, string> optionsNaturales = new Dictionary<string, string>();
            foreach (DataRow cliente in clientesNatureales.Rows)
            {
                optionsNaturales.Add(cliente["cn_cedula"].ToString(), cliente["cn_nombre"].ToString() + " " + cliente["cn_apellido"].ToString());
                //dpCLientes.Items.Add(cliente["cn_nombre"].ToString() + " " + cliente["cn_apellido"].ToString());
            }
            dpCLientes.DataSource = optionsNaturales;
            dpCLientes.DataTextField = "value";
            dpCLientes.DataValueField = "key";
            dpCLientes.DataBind();

        }
        else
        {
            dpCLientes.Items.Clear();
            DataTable clientesJuridicos = LogicaNegociosTotem.Modulo4.LogicaProyecto.BuscarClientesJuridicos();
            Dictionary<string, string> optionsJuridicos = new Dictionary<string, string>();
            foreach (DataRow cliente in clientesJuridicos.Rows)
            {
                optionsJuridicos.Add(cliente["cj_rif"].ToString(), cliente["cj_nombre"].ToString());
                //dpCLientes.Items.Add(cliente["cj_nombre"].ToString());
            }
            dpCLientes.DataSource = optionsJuridicos;
            dpCLientes.DataTextField = "value";
            dpCLientes.DataValueField = "key";
            dpCLientes.DataBind();
        }
    }

    public void LlenaComboMonedas()
    {
        comboMoneda.Items.Add("Bs");
        comboMoneda.Items.Add("$");
        comboMoneda.Items.Add("€");
    }
}