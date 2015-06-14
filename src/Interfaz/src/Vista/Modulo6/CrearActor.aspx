<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="CrearActor.aspx.cs" Inherits="Vista.Modulo6.CrearActor" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
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
