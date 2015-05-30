using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DominioTotem;
using LogicaNegociosTotem.Modulo2;
using ExcepcionesTotem.Modulo2; 

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
            ((MasterPage)Page.Master).IdModulo = "2";

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
        }

    /// <summary>
    /// Evento que se dispara cuando 
    /// se genera presiona agregar cliente
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AgregarCliente_Click(object sender, EventArgs e) 
    {
        bool agrego = false;
        int existe = 0; 
        
        string nombre = nombreNatural.Value;
        string apellido = apellidoNatural.Value;
        string correo = correoCliente.Value;
        string cedula = cedulaNatural.Value; 
        LogicaCliente logica = new LogicaCliente();
        int ciudad = Convert.ToInt32(comboCiudad.Items[comboCiudad.SelectedIndex].Value);
        string direccion = direccionCliente.Value;
        string telefono = telefonoCliente.Value;

        existe = logicaCliente.VerificarExistenciaNatural(cedula);

        if (existe == 0)
        {
            agrego = logicaCliente.AgregarClienteNatural(cedula, nombre,
                apellido, ciudad, direccion, correo, telefono);
            if (agrego)
            {
                alert.Attributes["class"] = "alert alert-success alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente agregado éxitosamente</div>";
                this.botonAgregar.Disabled = true;
            }
            else
            {
                alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                alert.Attributes["role"] = "alert";
                alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>No se pudo agregar el cliente</div>";
            }
        }
        else 
        {
            alert.Attributes["class"] = "alert alert-danger alert-dismissible";
            alert.Attributes["role"] = "alert";
            alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Cliente ya existente</div>";
        }
    
    }

   
             

           
        


    /*
         /// <summary>
         /// Método que extrae la información de los paises para el
         /// combo
         /// </summary>
         private void LlenarPaises()
         {
             try
             {
                 LogicaLugar logica = new LogicaLugar();
                 List<Lugar> paises = logica.LlenarComboPaises();

                 string prueba = "Seleccione Pais";
                 string nombreEvento = "CbCambioAEstado";
                 this.contenedorComboPais.InnerHtml = "<select runat=\"server\" id=\"comboPais\" class=\"btn btn-default dropdown-toggle\""
                                                    + "onchange=\" " + nombreEvento + "\">" +
                                                     "<option id=\"opcionPais" + "0" + "\" runat=\"server\" value=\"0\">" +
                                                      prueba +
                                                     "</option>"
                                                     ;


                 foreach (Lugar objetoPais in paises)
                 {
                     this.contenedorComboPais.InnerHtml = contenedorComboPais.InnerHtml +
                                                          "<option id=\"opcionPais" + objetoPais.IdLugar.ToString() + "\" runat=\"server\" value=\"" + objetoPais.IdLugar.ToString() + "\">" +
                                                           objetoPais.NombreLugar +
                                                          "</option>";
                 }

                 this.contenedorComboPais.InnerHtml = this.contenedorComboPais.InnerHtml + "</select>";
             }
             catch (ClienteDatosException e)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa de datos</div>";
             }
             catch (ClienteLogicaException e)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa lógica</div>";
             }

         }

         /// <summary>
         /// Método que extrae la información de los 
         /// estados para el combo
         /// </summary>
         private void LlenarEstados(int idPais)
         {
             try
             {
                 LogicaLugar logica = new LogicaLugar();
                 List<Lugar> estados = logica.LlenarComboEstados(idPais);
                 string prueba = "Seleccione Estado";
                 string nombreEvento = "CbCambioACiudad";
                 this.contenedorComboEstado.InnerHtml = "<select runat=\"server\" id=\"comboEstado\" class=\"btn btn-default dropdown-toggle\""
                                                    + "onchange=\"" + nombreEvento + "\">" +
                                                     "<option id=\"opcionEstado" + "0" + "\" runat=\"server\" value=\"0\">" +
                                                      prueba +
                                                     "</option>";


                 foreach (Lugar objetoEstado in estados)
                 {

                     this.contenedorComboEstado.InnerHtml = contenedorComboEstado.InnerHtml +
                                                          "<option id=\"opcionEstado" + objetoEstado.IdLugar.ToString() + "\" runat=\"server\" value=\"" + objetoEstado.IdLugar.ToString() + "\">" +
                                                           objetoEstado.NombreLugar +
                                                          "</option>";
                 }

                 this.contenedorComboEstado.InnerHtml = this.contenedorComboEstado.InnerHtml + "</select>";

             }
             catch (ClienteDatosException e)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa de datos</div>";
             }
             catch (ClienteLogicaException e)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa lógica</div>";
             }
         }


         /// <summary>
         /// Método que extrae la información de las 
         /// ciudades para el combo
         /// </summary>
         private void LlenarCiudades(int idEstado)
         {
             try
             {
                 LogicaLugar logica = new LogicaLugar();
                 List<Lugar> ciudades = logica.LlenarComboCiudades(idEstado);


                 string prueba = "Seleccione Ciudad";

                 this.contenedorComboCiudad.InnerHtml = "<select runat=\"server\" id=\"comboCiudad\" class=\"btn btn-default dropdown-toggle\">" +
                                                     "<option id=\"opcionCiudad" + "0" + "\" runat=\"server\" value=\"0\">" +
                                                      prueba +
                                                     "</option>";

                 foreach (Lugar objetoCiudad in ciudades)
                 {

                     this.contenedorComboCiudad.InnerHtml = contenedorComboCiudad.InnerHtml +
                                                          "<option id=\"opcionCiudad" + objetoCiudad.IdLugar.ToString() + "\" runat=\"server\" value=\"" + objetoCiudad.IdLugar.ToString() + "\">" +
                                                           objetoCiudad.NombreLugar +
                                                          "</option>";
                 }
                 this.contenedorComboCiudad.InnerHtml = this.contenedorComboCiudad.InnerHtml + "</select>";
             }
             catch (ClienteDatosException e)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa de datos</div>";
             }
             catch (ClienteLogicaException e)
             {
                 alert.Attributes["class"] = "alert alert-danger alert-dismissible";
                 alert.Attributes["role"] = "alert";
                 alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Error en la capa lógica</div>";
             }
         }*/




    
    
}