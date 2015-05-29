using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GUI_Modulo4_ListaProyectos : System.Web.UI.Page
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

        DataTable proyectos = new DataTable();
        String username = "albertods";
        proyectos = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarTodosLosProyectos(username);
        if (proyectos.Rows.Count > 0)
        {
            foreach (DataRow row in proyectos.Rows)
            {
                this.jumbotronProyecto.Text += "<div class='form-group'>";
                this.jumbotronProyecto.Text += "<div id='div_perfiles' class='col-sm-12 col-md-12 col-lg-12'>";
                this.jumbotronProyecto.Text += "<div class='jumbotron'>";
                this.jumbotronProyecto.Text += "<h2 class='sameLine'><a href='PerfilProyecto.aspx?success="+row["codigo"].ToString()+"&success=-1'>" + row["nombre"].ToString() + "</a></h2> <h5 class='sameLine'>COD: </h5> <h5 id='codigoProyecto' class='sameLine' runat='server'>" + row["codigo"].ToString() + "</h5>";
                this.jumbotronProyecto.Text += "<p class='desc'>" + row["descripcion"].ToString() + "</p>";
                if (bool.Parse(row["estado"].ToString()) == true)
                {
                    this.jumbotronProyecto.Text += "<input disabled checked data-toggle='toggle' data-size='small' type='checkbox' data-on='Activo' data-off='Inactivo' data-onstyle='success' data-offstyle='warning' data-width='100'>";
                }
                else
                {
                    this.jumbotronProyecto.Text += "<input disabled unchecked data-toggle='toggle' data-size='small' type='checkbox' data-on='Activo' data-off='Inactivo' data-onstyle='success' data-offstyle='warning' data-width='100'>";
                }
                this.jumbotronProyecto.Text += "<br><br>";
                this.jumbotronProyecto.Text += "<p class='sameLine'>Cliente: </p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
                this.jumbotronProyecto.Text += "<br>";
                this.jumbotronProyecto.Text += "<p class='sameLine'>Desarroladora: </p><p id='nombreDesarrolladora' class='sameLine bootstrapBlue'>" + "</p>";
                this.jumbotronProyecto.Text += "</div>";
                this.jumbotronProyecto.Text += "</div>";
                this.jumbotronProyecto.Text += "</div>";
            }
        }
    }
}