using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;

public partial class GUI_Modulo4_ModificarProyecto : System.Web.UI.Page
{
    DominioTotem.Proyecto proyecto = new DominioTotem.Proyecto();
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

        if (!IsPostBack)
        {
            LlenaComboMonedas();

            String success = Request.QueryString["success"];
            if (success != null)
            {
                proyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(success);
                this.nombreProy.Value = proyecto.Nombre;
                this.codigoProy.Value = proyecto.Codigo;
                this.precioProy.Value = proyecto.Costo.ToString();
                this.descripcionProy.Value = proyecto.Descripcion;
                this.comboMoneda.Items.FindByText(proyecto.Moneda).Selected = true;
                if (proyecto.Estado == true){
                    this.csEstado.Checked = true;
                    this.csEstado.Text = " Activo";
                }
                else{
                    this.csEstado.Checked = false;
                    this.csEstado.Text = " Inactivo";
                }
            
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
        

    }

    public void ModifyProject(object sender, EventArgs e)
    {
        DominioTotem.Proyecto newProyecto = new DominioTotem.Proyecto();
        newProyecto.Nombre = this.nombreProy.Value;
        newProyecto.Codigo = this.codigoProy.Value;
        newProyecto.Costo = int.Parse(this.precioProy.Value);
        newProyecto.Descripcion = this.descripcionProy.Value;
        newProyecto.Moneda = this.comboMoneda.SelectedItem.ToString();
        if (this.csEstado.Checked)
        {
            newProyecto.Estado = true;
        }
        else
        {
            newProyecto.Estado = false;
        }

        bool modified = LogicaNegociosTotem.Modulo4.LogicaProyecto.ModificarProyecto(newProyecto, newProyecto.Codigo);
        if (modified == true){
            HttpContext.Current.Response.Redirect("PerfilProyecto.aspx?success="+newProyecto.Codigo+"&success=0");
        }
        else{
            alerts.Attributes["class"] = "alert alert-danger alert-dismissible";
            alerts.Attributes["role"] = "alert";
            alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto no pudo ser modificado...</div>";
        }
    }

    public void LlenaComboMonedas()
    {
        comboMoneda.Items.Add("Bs");
        comboMoneda.Items.Add("$");
        comboMoneda.Items.Add("€");
    }
}