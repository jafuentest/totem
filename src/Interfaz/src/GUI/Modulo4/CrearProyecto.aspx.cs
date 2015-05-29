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
        ((MasterPage)Page.Master).ShowDiv = true;

        //LogicaNegociosTotem.Modulo2.LogicaCliente

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
        
    }

    protected void CreateProject_Click(object sender, EventArgs e)
    {
        try
        {
            String nombre = this.Input_Nombre.Value;
            String codigo = this.Input_Codigo.Value;
            String descripcion = this.Input_Descripcion.Value;
            String moneda = this.Input_Moneda.ToString();
            int costo = int.Parse(this.Input_Precio.Value);
            bool estado = true;
            bool saved;
            if (nombre.Equals("") || codigo.Equals("") || descripcion.Equals("") || costo.Equals("") || moneda.Equals(""))
            {
                //HttpContext.Current.Response.Redirect("CrearProyecto.aspx?success=0");
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Por favor ingrese todos los campos</div>";
            }
            else
            {
                DominioTotem.Proyecto proyecto = new DominioTotem.Proyecto();
                proyecto.Codigo = codigo;
                proyecto.Nombre = nombre;
                proyecto.Descripcion = descripcion;
                proyecto.Moneda = moneda;
                proyecto.Costo = costo;
                proyecto.Estado = estado;
                saved = LogicaNegociosTotem.Modulo4.LogicaProyecto.CrearProyecto(proyecto);
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
}