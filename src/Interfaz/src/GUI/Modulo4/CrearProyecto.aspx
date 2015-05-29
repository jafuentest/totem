<%@ Page Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master"  AutoEventWireup="true" CodeFile="CrearProyecto.aspx.cs" Inherits="GUI_Modulo4_CrearProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
	<link href="bootstrap-toggle-master/css/bootstrap-toggle.css" rel="stylesheet">
    <style>
        textarea {
            resize: none;
        }
        .note{
            font-style: italic;
            color: #5b5b5b;
        }
        .noteLink{
            color: #337ab7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Crear</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    
    <!--ALERTAS-->
    <!--Alertas de modificacion y eliminacion de requerimientos en la lista de requerimientos en el 1er acordeon-->
    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat="server">
        </div>
    </div>

   <form runat="server" class="form-horizontal" method="POST">
        <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
            <div class="form-group">
                <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				    <input runat="server" type="text" id="Input_Nombre" placeholder="Nombre" onblur="fillCodigoTextField()" class="form-control" name="nombre"/>
                   
			    </div>
		        
                &nbsp;
			    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				    <input runat="server" type="text" id="Input_Codigo" placeholder="Codigo" class="form-control" name="codigo" maxlength="3" minlength="1"/>
			    </div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea runat="server" id="Input_Descripcion" placeholder="Descripcion" class="form-control" name="descripcion" rows="3"></textarea>
		        </div>
	        </div>
            <label>Moneda</label>
            <div class="form-group">
                <div class="col-sm-1 col-md-1 col-lg-1">
                    <div class="dropdown">
                          <button runat="server" id="Input_Moneda" class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
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
                       <input runat="server" type="text" id="Input_Precio" placeholder="Precio" class="form-control" name="precio"/>
                </div>
                
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3">
                    <input disabled checked data-toggle="toggle" data-size="normal" type="checkbox" data-on="Activo" data-off="Inactivo" data-onstyle="success" data-offstyle="warning" data-width="100">
                </div>
	        </div>

            <div class="form-group">
	            <div id="div_cliente" class="col-sm-12 col-md-12 col-lg-12">
                    <label>Cliente</label>
                    <br>
                    <label class="radio-inline">
                        <input type="radio" name="radioStatus" checked="checked"/> Juridico</label>
                    <label class="radio-inline">
                        <input type="radio" name="radioStatus"/> Natural</label>
                </div>
            </div>
            <div class="form-group">
	            <div id="div_clientes" class="col-sm-12 col-md-12 col-lg-12">
                    <div class="dropdown">
                          <button runat="server" id="btn_cliente" class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
                            Seleccionar cliente...
                            <span class="caret"></span>
                          </button>
                          <ul id="cliente" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu2">
                            <li role="presentation"><a role="menuitem" tabindex="-1" >List</a></li>
                          </ul>
                    </div>
                </div>
            </div>

            <div class="form-group">
	            <div id="div_nota" class="col-sm-12 col-md-12 col-lg-12">
                    <label class="note">¿No encuentra el cliente que busca? <a class="noteLink" href="../Modulo2/AgregarCliente.aspx">Haz click aqui para agregarlo.</a></label>
                </div>
            </div>

            <br>
            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <button runat="Server" type="submit" class="btn btn-primary" onserverclick="CreateProject_Click">Crear</button>
			    </div>
                <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-default" onclick="goBack()">Cancelar</button>
			    </div>
	        </div>
        </div>
   </form>
    
    <script src="~/src/GUI/Modulo4/js/Validacion.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/8.3/highlight.min.js"></script>
	<script src="bootstrap-toggle-master/doc/script.js"></script>
	<script src="bootstrap-toggle-master/js/bootstrap-toggle.js"></script>
	<script>
	    (function (i, s, o, g, r, a, m) {
	        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
	            (i[r].q = i[r].q || []).push(arguments)
	        }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
	    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
	    ga('create', 'UA-55669452-1', 'auto');
	    ga('send', 'pageview');
	</script>

    <script language="javascript">
         function fillCodigoTextField() {
             var codigoTextField = document.getElementById("Codigo");
             var nombreTextField = document.getElementById("Nombre");

             var text = nombreTextField.value.trim(); // se eliminan los espacios innecesarios del comienzo y final del string
             nombreTextField.value = text;

             if (nombreTextField.value.length>=1) { //antes de llenar el codigo revisa si al menos tiene un caracter
                 codigoTextField.value = "";
                 var words = text.split(" ");//crea una array de palabras del nombre del proyecto 

                 switch (words.length) { //dependiendo de la cantidad de palabras...
                     case 1: // Agarra las 3 primeras letras de la palabra 
                         for (i=0;i<3;i++) {
                             temp = words[0];
                             codigoTextField.value = codigoTextField.value + temp.charAt(i).toUpperCase(); // va concatenando cada una de las primeras letras mayuscula.    
                         }
                         break 
                     case 2: // Toma las dos primeras letras de la primera palabra y la primera de la segunda palabra
                         for (i = 0; i < 2; i++) {
                             temp = words[0];
                             codigoTextField.value = codigoTextField.value + temp.charAt(i).toUpperCase(); // va concatenando cada una de las primeras letras en mayuscula.    
                         }
                         temp = words[1];
                         codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase();

                         break 
                     case 3: //toma la primera letra de cada palabra 
                         for (i in words) {
                             if (i < 3) {
                                 temp = words[i];
                                 codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase(); // va concatenando cada una de las primeras letras de cada palabra en mayuscula.
                             }
                         }
                         break 
                     default: //por defecto usa el algoritmo del caso 3: toma la primera letra de cada palabra 
                         for (i in words) {
                             if (i < 3) {
                                 temp = words[i];
                                 codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase(); // va concatenando cada una de las primeras letras de cada palabra en mayuscula.
                             }
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

