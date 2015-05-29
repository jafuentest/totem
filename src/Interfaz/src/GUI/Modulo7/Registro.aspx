<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="GUI_Modulo7_Registro" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">Registro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
          <div id="alert_nombre" runat="server">
         </div>
         <div id="alert_apellido" runat="server">
          </div>
          <div id="alert_username" runat="server">
          </div>
          <div id="alert_correo" runat="server">
          </div>
          <div id="alert_pregunta" runat="server">
          </div>
          <div id="alert_respuesta" runat="server">
           </div>
           <div id="alert_password" runat="server">
           </div>

        <div id="alertlocal" runat="server">
        </div>
    <form id="register_form" class="form-horizontal" action="#" runat="server">
        <div class="form-group">
		    <div id="div_nombre" class="col-sm-5 col-md-5 col-lg-5">
				<input id="id_nombre" type="text" placeholder="Nombre" class="form-control" name="nombre" runat="server"/>
			</div>
            &nbsp;
			<div id="div_apellido" class="col-sm-5 col-md-5 col-lg-5">
				<input id="id_apellido" type="text" placeholder="Apellido" class="form-control" name="apellido" runat="server"/>
			</div>
		</div>
        <div class="form-group">
	        <div id="div_usuario" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="id_username" type="text" placeholder="Nombre de Usuario" class="form-control" name="usuario" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_email" class="col-sm-10 col-md-10 col-lg-10">
		        <input id="id_correo" type="text" placeholder="Correo Electr&oacute;nico" class="form-control" name="correo" runat="server"/>
		    </div>
	    </div>
        <div class="form-group">
		    <div id="div_pswd" class="col-sm-10 col-md-5 col-lg-5">
                    <input id="password" type="password" placeholder="Contrase&ntilde;a" class="form-control" name="password" runat="server"/>
			</div>
        </div>
        <div class="form-group">
			<div id="div_confirm_pswd" class="col-sm-10 col-md-5 col-lg-5">
				    <input id="confirm_password" type="password" placeholder="Confirmar Contrase&ntilde;a" class="form-control" name="confirm_password" runat="server"/>
            </div>
		</div>
        <div class="form-group">
            <div class="col-sm-10 col-md-10 col-lg-10">
            <div class="dropdown">
              <button  class="btn btn-default dropdown-toggle" type="button" id="dropdownRol" data-toggle="dropdown" aria-expanded="true" runat="server">
                Seleccione un Rol
                <span class="caret"></span>
              </button>
              <ul id="dprol" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                <li role="presentation"><a role="menuitem" tabindex="-1" >Usuario</a></li>
                <li role="presentation"><a role="menuitem" tabindex="-1" >Admin</a></li>
              </ul>
            </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-10 col-md-10 col-lg-10">
            <div class="dropdown">
              <button id="id-cargo" class="btn btn-default dropdown-toggle" type="button" name="dropdwonCargo" data-toggle="dropdown" aria-expanded="true">
                Seleccione un Cargo
                <span class="caret"></span>
              </button>
              <ul id="dpcargo" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                <li role="presentation"><a role="menuitem" tabindex="-1" >Gerente</a></li>
                <li role="presentation"><a role="menuitem" tabindex="-1" >Desarrollador</a></li>
                  <li role="presentation"><a role="menuitem" tabindex="-1">Diseñador</a></li>
                  <li role="presentation"><a role="menuitem" tabindex="-1" >L&iacute;der de Proyecto</a></li>
                  <li role="presentation"><a role="menuitem" tabindex="-1" >Arquitecto de Soluci&oacute;n</a></li>
                  <li role="presentation"><a role="menuitem" tabindex="-1" >Arquitecto de Base de Datos</a></li>
                  <li role="presentation"><a role="menuitem" tabindex="-1">Documentador</a></li>
                  <li role="presentation"><a role="menuitem" tabindex="-1">Otro</a></li>
              </ul>
            </div>
            </div>
        </div>
         <div class="form-group">
			<div id="div_otrocargo" class="col-sm-10 col-md-10 col-lg-10">
				<input id="id_otrocargo" type="text" placeholder="Otro Cargo" class="form-control" name="otrocargo" runat="server" disabled='true'/>
			</div>
		</div>
        <div class="form-group">
			<div id="div_pregunta" class="col-sm-10 col-md-10 col-lg-10">
				<input type="text" placeholder="Pregunta de Seguridad" class="form-control" name="pregunta" id="id_pregunta" runat="server"/>
			</div>
		</div>
        <div class="form-group">
			<div id="div_respuesta" class="col-sm-10 col-md-10 col-lg-10">
				<input type="text" placeholder="Respuesta" class="form-control" name="respuesta" id="id_respuesta" runat="server"/>
			</div>
		</div>
        <div class="form-group">
		    <div class="col-sm-5 col-md-5 col-lg-5">
				<button  class="btn btn-primary" type="submit" onserverclick="btn_registrar_Click" runat="server">Registrar</button>
                <button  class="btn btn-default"   runat="server" type="submit" onserverclick="Unnamed2_Click">Cancelar</button>
			</div>
	    </div>
    </form>
        </div>
    <script src="js/Validacion.js"></script>
    <script>
        $("#dprol li a").click(function () {

            $("#id-rol").html($(this).text() + ' <span class="caret"></span>');

        });
        $("#dpcargo li a").click(function () {

            if ($(this).text() == 'Otro') {
                $('#input-otrocargo').prop('disabled', false);
            }
            else {
                $('#input-otrocargo').prop('disabled', true);
            }
            $("#id-cargo").html($(this).text() + ' <span class="caret"></span>');           
        });
    </script>
    
</asp:Content>


