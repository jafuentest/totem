<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="GUI_Modulo7_Registro" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="titulo" Runat="Server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">Registro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
    <form id="register_form" class="form-horizontal" action="#">
        <div class="form-group">
		    <div id="div_nombre" class="col-sm-5 col-md-5 col-lg-5">
				<input type="text" placeholder="Nombre" class="form-control" name="nombre"/>
			</div>
            &nbsp;
			<div id="div_apellido" class="col-sm-5 col-md-5 col-lg-5">
				<input type="text" placeholder="Apellido" class="form-control" name="apellido"/>
			</div>
		</div>
        <div class="form-group">
	        <div id="div_usuario" class="col-sm-10 col-md-10 col-lg-10">
		        <input type="text" placeholder="Nombre de Usuario" class="form-control" name="usuario" />
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_email" class="col-sm-10 col-md-10 col-lg-10">
		        <input type="text" placeholder="Correo Electr&oacute;nico" class="form-control" name="correo"/>
		    </div>
	    </div>
        <div class="form-group">
		    <div id="div_pswd" class="col-sm-10 col-md-5 col-lg-5">
                    <input id="password" type="password" placeholder="Contrase&ntilde;a" class="form-control" name="password"/>
			</div>
        </div>
        <div class="form-group">
			<div id="div_confirm_pswd" class="col-sm-10 col-md-5 col-lg-5">
				    <input id="confirm_password" type="password" placeholder="Confirmar Contrase&ntilde;a" class="form-control" name="confirm_password" />
            </div>
		</div>
        <div class="form-group">
			<div id="div_cargo" class="col-sm-10 col-md-5 col-lg-5">
				<input type="text" placeholder="Cargo en la Empresa" class="form-control" name="cargo" />
			</div>
		</div>
        <div class="form-group">
			<div id="div_pregunta" class="col-sm-10 col-md-10 col-lg-10">
				<input type="text" placeholder="Pregunta de Seguridad" class="form-control" name="pregunta"/>
			</div>
		</div>
        <div class="form-group">
			<div id="div_respuesta" class="col-sm-10 col-md-10 col-lg-10">
				<input type="text" placeholder="Respuesta" class="form-control" name="respuesta" />
			</div>
		</div>
        <div class="form-group">
		    <div class="col-sm-5 col-md-5 col-lg-5">
				<button class="btn btn-primary" onclick="return checkform()">Registrar</button>
			</div>
	    </div>
    </form>
        </div>
    <script src="js/Validacion.js"></script>
    
</asp:Content>


