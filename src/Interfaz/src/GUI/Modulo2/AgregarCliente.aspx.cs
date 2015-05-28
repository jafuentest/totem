using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegociosTotem.Modulo2;
using DominioTotem;
using ExcepcionesTotem;

public partial class GUI_Modulo2_AgregarCliente : System.Web.UI.Page
{


        string correoS = string.Empty;
        string docIdentidadS = string.Empty;
        string primerNombreS = string.Empty;
        string primerApellidoS = string.Empty;
      //  string direccion = string.Empty;

        ClienteNatural clienteNatural;
        LogicaCliente logicaCliente = new LogicaCliente();

    protected void Page_Load(object sender, EventArgs e)
    {
        //((MasterPage)Page.Master).IdModulo = "2";

        //DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;
        //if (user != null)
       // {
         //   if (user.username != "" &&
          //      user.clave != "")
           // {
            //    ((MasterPage)Page.Master).ShowDiv = true;
           // }
            //else
            //{
            //    ((MasterPage)Page.Master).MostrarMenuLateral = false;
            //    ((MasterPage)Page.Master).ShowDiv = false;
           // }

//        }
  //      else
    //    {
      //      Response.Redirect("../Modulo1/M1_login.aspx");
       }


         public ClienteNatural CreandoClienteNatural()
        {
             

            clienteNatural = new ClienteNatural();
            clienteNatural.Nat_Nombre = TextNombre.Value;
             clienteNatural.Nat_Apellido= TextApellido.Value;
            clienteNatural.Nat_Correo = TextCorreo.Value;
         //    clienteNatural.Nat_Pais= TextPais.;
        //   clienteNatural.Nat_Ciudad = Convert.ToInt32(DropDownListCiudad.SelectedItem.Value);


            return clienteNatural;
        }




         /// <summary>
        /// TextBoxNombre control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox TextBoxNombre;
        
         /// <summary>
        /// TextBoxNombre control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox TextBoxApellido;
        


        /// <summary>
        /// TextBoxNombre control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox TextBoxCorreo;
        
       /// <summary>
        /// TextBoxNombre control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox TextBoxPais;
        

       /// <summary>
        /// TextBoxNombre control.
        /// </summary>
        /// <remarks>
        /// Auto-generated field.
        /// To modify move field declaration from designer file to code-behind file.
        /// </remarks>
        protected global::System.Web.UI.WebControls.TextBox DropDownListCiudad;
        






    
    
}