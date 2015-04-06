<%@ Page Title="" Language="VB" MasterPageFile="~/GUI/Modulo7/Modulo7.master" AutoEventWireup="false" CodeFile="Registro.aspx.vb" Inherits="GUI_Modulo7_Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">Registro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col=lg-6">
    <form id="register_form" class="form-horizontal" action="#">
        <div class="form-group">
		    <div id="div_nombre" class="col-lg-3">
				<input type="text" placeholder="Nombre" class="form-control" name="nombre"/>
			</div>
			&nbsp;
			<div id="div_apellido" class="col-lg-3">
				<input type="text" placeholder="Apellido" class="form-control" name="apellido"/>
			</div>
		</div>
        <div class="form-group">
	        <div id="div_usuario" class="col-lg-6">
		        <input type="text" placeholder="Nombre de Usuario" class="form-control" name="usuario" />
		    </div>
	    </div>
        <div class="form-group">
	        <div id="div_email" class="col-lg-6">
		        <input type="text" placeholder="Correo Electr&oacute;nico" class="form-control" name="correo"/>
		    </div>
	    </div>
        <div class="form-group">
		    <div id="div_pswd" class="col-lg-3">
                    <input id="password" type="password" placeholder="Contrase&ntilde;a" class="form-control" name="password"/>
			</div>
        </div>
        <div class="form-group">
			<div id="div_confirm_pswd" class="col-lg-3">
				    <input id="confirm_password" type="password" placeholder="Confirmar Contrase&ntilde;a" class="form-control" name="confirm_password" />
            </div>
		</div>
        <div class="form-group">
			<div id="div_cargo" class="col-lg-3">
				<input type="text" placeholder="Cargo en la Empresa" class="form-control" name="cargo" />
			</div>
		</div>
        <div class="form-group">
			<div id="div_pregunta" class="col-lg-6">
				<input type="text" placeholder="Pregunta de Seguridad" class="form-control" name="pregunta"/>
			</div>
		</div>
        <div class="form-group">
			<div id="div_respuesta" class="col-lg-6">
				<input type="text" placeholder="Respuesta" class="form-control" name="respuesta" />
			</div>
		</div>
        <div class="form-group">
		    <div class="col-md-6">
				<button class="btn btn-primary" onclick="return checkform()">Registrar</button>
			</div>
	    </div>
    </form>
        </div>
    <script type="text/javascript" src="js/bootstrapValidator.js"></script>
    <script src="js/Validacion.js"></script>
    
</asp:Content>

