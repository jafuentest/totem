using System;
using System.Web;
using LogicaNegociosTotem.Modulo6;
using DominioTotem;
using System.Collections.Generic;

/// <summary>
/// Clase que contiene toda la logica de la pagina ListarActores
/// </summary>
public partial class GUI_Modulo6_ListarActores : System.Web.UI.Page
{
    //Variable que tendra los actores de un proyecto
    private List<Actor> listaActores;

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

        //Nos indica si hubo alguna accion de agregar, modificar o eliminar
        String success = Request.QueryString["success"];
        
        //Declaramos una variable que almacenara el ID del actor
        int idActor = 0;

        //Declaramos una variable que almacenara el ID del proyecto en String
        String proyecto;

        //Declaramos una variable que almacenara el ID del proyecto en INT
        int proyectoID = 0;

        //Instanciamos la logica de los actores
        LogicaActor logica = new LogicaActor();

        //Obtenemos la cookie que nos indicara el proyecto en el que nos encontramos
        HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");

        //Si ya se ha seleccionado un proyecto
        if (projectCookie != null)
        {
            //Obtenemos el ID del proyecto en string
            proyecto = projectCookie.Values["projectCode"];

            //Nombre del proyecto y usuario
            proyectoPanel.InnerHtml = "Nombre del Proyecto: "+projectCookie.Values["projectName"]+"<br/>Usario: "+ user.username;

            try
            {
                //Casteamos explicitamente el ID del proyecto
                proyectoID = Int32.Parse(proyecto);

                //Obtenemos todos los actores del proyecto
                this.listaActores = logica.ListarActor(proyectoID);

                //Recorremos la lista con los actores del proyecto
                foreach (Actor actorLista in listaActores)
                {
                    //Concatenamos el ID, el nombre y la descripcion del actor para mostrar la tabla
                    cuerpo.InnerHtml = cuerpo.InnerHtml + "<tr id=\"actor-" + actorLista.IdentificacionActor + "\"><td class=\"name\">" + actorLista.NombreActor + "</td><td class=\"desc\">" + actorLista.DescripcionActor + "</td><td class=\"actions\"><a class=\"btn btn-default glyphicon glyphicon-pencil\" data-toggle=\"modal\" data-target=\"#modal-update\" href=\"#\"></a><a class=\"btn btn-danger glyphicon glyphicon-remove-sign\" data-toggle=\"modal\" data-target=\"#modal-delete\" href=\"#\"></a></td></tr>";
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

        //Revisamos si es alguno de los casos a continuacion
		switch (success)
		{
            //Si se viene de un agregar mostrara esta alerta
			case "1":
                //Obtenemos el exito o fracaso del proceso
                String exito4 = Request.QueryString["exito"];

                //Evaluamos la condicion
                if (exito4.Equals("1"))
                {
                    //Si el agregar fue exitoso mostramos esta alerta
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor agregado exitosamente</div>";
                }
                else
                {
                    //Si el agregar fue fallido mostramos esta alerta
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor ya existe</div>";
                }
                break;

            //Si se viene de un modificar se procedera a este y mostrar la alerta correspondiente
			case "2":
                //Casteamos explicitamente el ID del actor proveniente de un GET en la URL
                idActor = Int32.Parse(Request.QueryString["id"]);

                //Casteamos explicitamente el nombre del actor proveniente de un GET en la URL
                String nombreActor = Request.QueryString["nombre"];

                //Casteamos explicitamente la descripcion del actor proveniente de un GET en la URL
                String descripcionActor = Request.QueryString["descripcion"];

                //Obtenemos el exito o fallo del proceso
                bool exito2 = logica.ModificarActor(idActor, nombreActor, descripcionActor, proyectoID);

                //Evaluamos la condicion
                if (exito2)
                {
                    //Si la modificacion fue exitosa mostramos esta alerta
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor modificado exitosamente</div>";
                }
                else
                {
                    //Si la modificacion fue fallida mostramos esta alerta
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Modificacion fallida del actor</div>";
                }
                break;

            //Si se viene de un eliminar se procedera a eliminar y mostrar la alerta correspondiente
			case "3":
                //Casteamos explicitamente el ID del actor proveniente de un GET en la URL
				idActor=Int32.Parse(Request.QueryString["id"]);

                //Obtenemos el exito o fallo del proceso
                bool exito = logica.EliminarActor(idActor, proyectoID);

                //Evaluamos la condicion
                if (exito)
                {
                    //Si la eliminacion fue exitosa mostramos esta alerta
                    alert.Attributes["class"] = "alert alert-success alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Actor eliminado exitosamente</div>";
                }
                else
                {
                    //Si fue fallida mostramos esta alerta
                    alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                    alert.Attributes["role"] = "alert";
                    alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Eliminacion fallida del actor</div>";
                }
				break;
		}
        
	}
}
