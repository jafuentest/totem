using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contratos.Modulo7;
using Presentadores.Modulo7;

namespace Vista.Modulo7
{
    /// <summary>
    /// CodeBehind de la interfaz ListarUsuario
    /// </summary>
    public partial class ListarUsuarios : System.Web.UI.Page , IContratoListarUsuarios
    {
        //Declaramos el presentador de esta vista
        private PresentadorListarUsuarios presentador;

        /// <summary>
        /// Constructor de la clase que inicializa su respectivo presentador enviandole esta clase
        /// </summary>
        public ListarUsuarios()
        {
            presentador = new PresentadorListarUsuarios(this);
        }

        #region Contrato
        /// <summary>
        /// Implementacion de los metodos de la interfaz IContratoAgregarUsuario
        /// </summary>o
         public Literal tablaUsuarios
        {
            get
            {
                return this.laTabla;
            }
            set
            {
                this.laTabla = value;
            }
        }
        #endregion

        /// <summary>
        /// Evento que se dispara al cargar la pagina
        /// </summary>
        /// <param name="sender">Objeto que manda el evento</param>
        /// <param name="e">Clase Base de clases que con tienen la informacion del evento</param>
         protected void Page_Load(object sender, EventArgs e)
         {
             this.Master.idModulo = "7";

             if (!IsPostBack)
             {
                 this.Master.presentador.CargarMenuLateral();
                 presentador.LlenarTabla();
             }

             //Nos indica si hubo alguna accion de agregar, modificar o eliminar
             String success = Request.QueryString["success"];

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
                         alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Usuario agregado exitosamente</div>";
                     }
                     else
                     {
                         //Si el agregar fue fallido mostramos esta alerta
                         alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                         alert.Attributes["role"] = "alert";
                         alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Usuario ya existe</div>";
                     }
                     break;

                 //Si se viene de un eliminar se procedera a eliminar y mostrar la alerta correspondiente
                 //case "3":
                 /* //Casteamos explicitamente el ID del actor proveniente de un GET en la URL
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
                  }*/
                 //	break;
             }
         }

        protected void evento_eliminar(object sender, EventArgs e)
        {

        }
       
    }
}