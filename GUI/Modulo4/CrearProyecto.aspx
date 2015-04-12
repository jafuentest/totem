<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master"  AutoEventWireup="true" CodeFile="CrearProyecto.aspx.cs" Inherits="GUI_Modulo4_CrearProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="bootstrap-switch-master/docs/css/highlight.css" rel="stylesheet">
    <link href="bootstrap-switch-master/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet">
    <link href="bootstrap-switch-master/docs/css/main.css" rel="stylesheet">
    <style>
        textarea {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Crear</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    
   
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <form id="register_form" class="form-horizontal" action="#">
            <div class="form-group">
                <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				    <input type="text" id="Nombre" placeholder="Nombre" onblur="fillCodigoTextField()" class="form-control" name="nombre"/>
                   
			    </div>
		        
                &nbsp;
			    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				    <input type="text" id="Codigo" placeholder="Codigo" class="form-control" name="codigo" maxlength="3" minlength="1"/>
			    </div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea placeholder="Descripcion" class="form-control" name="descripcion" rows="3"></textarea>
		        </div>
	        </div>

            <div class="form-group">
                <div class="col-sm-1 col-md-1 col-lg-1">
                      <div class="dropdown">
                          <button id="id-moneda2" class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
                            &#164;
                            <span class="caret"></span>
                          </button>
                          <ul id="dpmoneda2" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                            <li role="presentation"><a role="menuitem" tabindex="-1" >Bs</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" >$</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" >€</a></li>
                          </ul>
                    </div>
                </div>
                <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                       <input type="text" id="Precio" placeholder="Precio" class="form-control" name="precio"/>
                </div>
                
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3 col-md-offset-3">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="switch-disabled" type="checkbox" checked data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" disabled>
                </div>
	        </div>
            <br>
            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-primary" onclick="return checkform()">Crear</button>
			    </div>
                <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-default" onclick="goBack()">Cancelar</button>
			    </div>
	        </div>
        </form>
    </div>
    <script src="js/Validacion.js"></script>
    <script src="bootstrap-switch-master/docs/js/highlight.js"></script>
    <script src="bootstrap-switch-master/dist/js/bootstrap-switch.js"></script>
    <script src="bootstrap-switch-master/docs/js/main.js"></script>
    <script language="javascript">
         function fillCodigoTextField() {
             var codigoTextField = document.getElementById("Codigo");
             var nombreTextField = document.getElementById("Nombre");
             if (nombreTextField.value.length>=1) { //antes de llenar el codigo revisa si al menos tiene un caracter
                 codigoTextField.value = "";
                 var words = nombreTextField.value.split(" ");//crea una array de palabras del nombre del proyecto 
                 for (i in words) {
                     if (i < 3) {
                         temp = words[i];
                         codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase(); // va concatenando cada una de las primeras letras de las palabras en mayuscula.
                     }
                 }

             }
         }
         $("#dpmoneda2 li a").click(function () {

             $("#id-moneda2").html($(this).text() + ' <span class="caret"></span>');

         });
         function goBack() {
             window.history.back();
         }
    </script>

</asp:Content>

