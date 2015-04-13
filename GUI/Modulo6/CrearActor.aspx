<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="CrearActor.aspx.cs" Inherits="GUI_Modulo6_CrearActor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<link href="<%= Page.ResolveUrl("~/GUI/Modulo6/css/modulo6.min.css") %>" rel="stylesheet"/>
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo6/js/modulo6.js") %>"></script>
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo6/js/validaciones.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Casos de Uso</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<form name="form_actor" id="form_actor" class="form-horizontal" action="#" method="post">
			<div class="form-group">
				<div id="div-nombre" class="col-sm-10 col-md-10 col-lg-10">
					<input type="text" name="nombre" id="nombre" placeholder="Nombre" class="form-control"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-descripcion" class="col-sm-10 col-md-10 col-lg-10">
					<input type="text" name="descripcion" id="descripcion" placeholder="Descripcion" class="form-control"/>
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-6">
					<button class="btn btn-primary" type="submit">Guardar Actor</button>
				</div>
			</div>
		</form>
	</div>
</asp:Content>
