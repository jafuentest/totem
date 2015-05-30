using LogicaNegociosTotem.Modulo6;
using System;
using System.Web;
using System.Web.UI;

/// <summary>
/// Clase que contiene toda la logica de la pagina CrearActor
/// </summary>
public partial class GUI_Modulo6_CrearActor : System.Web.UI.Page
{
    /// <summary>
    /// Metodo que carga las configuraciones por defecto y opciones especiales de su ventana correspondiente
    /// </summary>
    /// <param name="sender">Objeto que ejecuta esta accion</param>
    /// <param name="e">Clase base para las clases que contienen la informacion del evento</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "6";

        //Obtenemos la variable de sesion
        DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
		//if (user != null)
		//{
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
		//}
		//else
		//{
		//	Response.Redirect("../Modulo1/M1_login.aspx");
		//}
    }

    /// <summary>
    /// Evento que se dispara al agregar un actor
    /// </summary>
    /// <param name="sender">Objeto que manda el evento</param>
    /// <param name="e">Clase Base de clases que con tienen la informacion del evento</param>
    protected void Agregar_Actor(object sender, EventArgs e)
    {
        //Nombre y descripcion del Actor
        string nombre = this.nombre_actor.Value;
        string descripcion = this.descripcion_actor.Value;

        //Declaramos una variable que almacenara el ID del proyecto en INT
        int proyectoID = 0;

        //Obtenemos la cookie que nos indicara el proyecto en el que nos encontramos
        HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");

        //Si ya se ha seleccionado un proyecto
        if (projectCookie != null)
        {
            //Obtenemos el ID del proyecto en string
            String proyecto = projectCookie.Values["projectCode"];

            try
            {
                //Casteamos explicitamente el ID del proyecto
                proyectoID = Int32.Parse(proyecto);

                //Si el usuario trata de Agregar un Actor sin nombre
                if (nombre.Equals(""))
                {
                    //Se despliega la advertencia
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\"" +
						" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" +
						"Debe ingresar un nombre para el actor</div>";
                }
                else
                {
                    //Si el proyecto esta seleccionado y el usuario ingresa datos validos
                    LogicaActor logica = new LogicaActor();

                    //Realizamos la operacion y retornamos la respuesta
                    bool exito = logica.AgregarListarActor(nombre, descripcion, proyectoID);

                    //Analizamos las condiciones
                    if (exito)
                        //Si se pudo Agregar
                        HttpContext.Current.Response.Redirect("ListarActores.aspx?success=1&exito=1");
                    else
                        //Sino se pudo agregar
                        HttpContext.Current.Response.Redirect("ListarActores.aspx?success=1&exito=0");
                }
                
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("La cookie no tiene valor", ex);
            }
            catch (FormatException exe)
            {
                throw new FormatException("La cookie tiene un valor de proyecto no valido", exe);
            }
        }
        
    }
}
