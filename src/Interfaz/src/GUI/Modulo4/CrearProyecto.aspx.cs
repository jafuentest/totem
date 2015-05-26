using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GUI_Modulo4_CrearProyecto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

        /*DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
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
        }*/
    }

    protected void CreateProject_Click(object sender, EventArgs e)
    {
        String nombre = this.Input_Nombre.Value;
        String codigo = this.Input_Codigo.Value;
        String descripcion = this.Input_Descripcion.Value;
        String moneda = this.Input_Moneda.ToString();
        float costo = float.Parse(this.Input_Precio.Value);
        bool estado = true;
        bool saved;
        try{
            DominioTotem.Proyecto proyecto = new DominioTotem.Proyecto();
            proyecto.Codigo = codigo;
            proyecto.Nombre = nombre;
            proyecto.Descripcion = descripcion;
            proyecto.Moneda = moneda;
            proyecto.Costo = costo;
            proyecto.Estado = estado;
            saved = LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(proyecto);
            if (saved == true){

            }
            else{

            }
        }
        catch (Exception ex){
           
        }
        

    }
}