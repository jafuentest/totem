<%@ Page Title="" Language="VB" MasterPageFile="~/GUI/Modulo7/Modulo7.master" AutoEventWireup="false" CodeFile="Registro.aspx.vb" Inherits="GUI_Modulo7_Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">Registro
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <form action="#">
        <div class="form-group  has-feedback">
        <div class="row">
		    <div class="col-lg-3">
				<input type="text" placeholder="Nombre" class="form-control" />
			</div>
			&nbsp;
			<div class="col-lg-3">
				<input type="text" placeholder="Apellido" class="form-control" />
			</div>
		</div>
        <br />
        <div class="row">
	        <div class="col-lg-6">
		        <input type="text" placeholder="Nombre de Usuario" class="form-control" />
		    </div>
	    </div>
        <br />
        <div class="row">
	        <div class="col-lg-6">
		        <input type="text" placeholder="Correo Electr&oacute;nico" class="form-control" />
		    </div>
	    </div>
        <br />
        <div class="row">
		    <div class="col-lg-3">
				<input type="text" placeholder="Contrase&ntilde;a" class="form-control" />
			</div>
        </div>
			<br />
        <div class="row">
			<div class="col-lg-3">
				<input type="text" placeholder="Confirmar Contrase&ntilde;a" class="form-control" />
			</div>
		</div>
        <br />
        <div class="row">
			<div class="col-lg-3">
				<input type="text" placeholder="Cargo en la Empresa" class="form-control" />
			</div>
		</div>
        <br />
        <div class="row">
			<div class="col-lg-6">
				<input type="text" placeholder="Pregunta de Seguridad" class="form-control" />
			</div>
		</div>
        <br />
        <div class="row">
			<div class="col-lg-6">
				<input type="text" placeholder="Respuesta" class="form-control" />
			</div>
		</div>
        <br />
        <div class="row">
		    <div class="col-md-6">
				<button class="btn btn-primary">Registrar</button>
			</div>
	    </div>
        </div>
    </form>
</asp:Content>

