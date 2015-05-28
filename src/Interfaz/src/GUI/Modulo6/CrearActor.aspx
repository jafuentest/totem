<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="CrearActor.aspx.cs" Inherits="GUI_Modulo6_CrearActor" %>
<asp:Content ID="Content5" ContentPlaceHolderID="head" Runat="Server">
	<link href="<%= Page.ResolveUrl("~/src/GUI/Modulo6/css/modulo6.min.css") %>" rel="stylesheet"/>
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo6/js/modulo6.js") %>"></script>
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo6/js/validaciones.js") %>"></script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="titulo" Runat="Server">Casos de Uso</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="subtitulo" Runat="Server">Agregar</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="alert" runat="server">
                </div>
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<form runat="server" class="form-horizontal" method="POST">
			<div class="form-group">
				<div id="div-nombre" class="col-sm-10 col-md-10 col-lg-10">
					<input id="nombre_actor" type="text" runat="server" name="nombre" placeholder="Nombre" class="form-control"  />
				</div>
			</div>
			<div class="form-group">
				<div id="div-descripcion" class="col-sm-10 col-md-10 col-lg-10">
					<input id="descripcion_actor" runat="server" type="text" name="descripcion" placeholder="Descripcion" class="form-control" />
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-6">
					<button runat="server" class="btn btn-primary" type="submit" onserverclick="Agregar_Actor">Agregar</button>
					<a class="btn btn-default" href="ListarActores.aspx">Cancelar</a>
				</div>
			</div>
		</form>
	</div>
</asp:Content>
