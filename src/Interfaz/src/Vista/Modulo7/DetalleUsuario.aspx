<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleUsuario.aspx.cs" Inherits="Vista.Modulo7.DetalleUsuario" %>
<%@ MasterType virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Detalle</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
		<div id="alert" runat="server"></div>
		<div class="row col-sm-12 col-md-12 col-lg-12">
			<div class="col-sm-12 col-md-12 col-lg-12" >
				<h4 style="float: left">Nombre:&nbsp;</h4>
				<h4 id="nombre" runat="server"></h4>
			</div>
			<div class="col-sm-12 col-md-12 col-lg-12">
				<h4 style="float: left">Apellido:&nbsp;</h4>
				<h4 id="apellido" runat="server"></h4>
			</div>
			<div class="col-sm-12 col-md-12 col-lg-12">
				<h4 style="float: left">Correo:&nbsp;</h4>
				<h4 id="correo" runat="server"></h4>
			</div>
			<div class="col-sm-12 col-md-12 col-lg-12">
				<h4 style="float: left">Rol:&nbsp;</h4>
				<h4 id="rol" runat="server"></h4>
			</div>
			<div class="col-sm-12 col-md-12 col-lg-12">
				<h4 style="float: left">Nombre de Usuario:&nbsp;</h4>
				<h4 id="username" runat="server"></h4>
			</div>
			<div class="col-sm-12 col-md-12 col-lg-12">
				<h4 style="float: left">Cargo:&nbsp;</h4>
				<h4 id="cargo" runat="server"></h4>
			</div>
			<div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <button id="btn_modUsuario" class="btn btn-primary" type="submit" runat="server" onserverclick="btn_modUsuario_ServerClick">Modificar</button>
                    <a class="btn btn-default" href="ListarUsuarios.aspx">Volver a la lista</a>
                </div>
            </div>
		</div>
	</div>
</asp:Content>
