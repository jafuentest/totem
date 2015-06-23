<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Crear.aspx.cs" Inherits="Vista.Modulo6.Crear" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Casos de Uso
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar Casos de Uso
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">

<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<form runat="server" name="form_casodeuso" id="form_casodeuso" class="form-horizontal" action="Listar.aspx?success=1" method="post">
			<div class="form-group">
				<div id="div-id" class="col-sm-10 col-md-10 col-lg-10">
					<asp:TextBox ID="id" runat="server" CssClass="form-control"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-nombre" class="col-sm-10 col-md-10 col-lg-10">
					<asp:TextBox ID="nombre" runat="server" CssClass="form-control" />
				</div>
			</div>
			<div class="form-group">
				<div class="col-sm-10 col-md-10 col-lg-10">
					<h3>Precondiciones</h3>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<asp:TextBox ID="precondicion_0" runat="server" placeholder="Precondición" CssClass="form-control" />
						</div>
						<asp:PlaceHolder ID="precondiciones" runat="server"></asp:PlaceHolder>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<asp:Button ID="agregarPrecondicion" runat="server" CssClass="btn btn-default btn-circle glyphicon glyphicon-plus"/>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div id="div-condicionExito" class="col-sm-10 col-md-10 col-lg-10">
					<asp:TextBox ID="condicionExito" runat="server" placeholder="Condición Final de Éxito" CssClass="form-control"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-condicionFallo" class="col-sm-10 col-md-10 col-lg-10">
					<asp:TextBox ID="condicionFallo" runat="server" placeholder="Condición Final de Fallo" CssClass="form-control"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-actores" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Actores</h3>
					<select multiple="multiple" name="actores1" size="4" class="form-control select select-primary select-block mbl">
						<option value="Actor 1">Actor 1</option>
						<option value="Actor 2">Actor 2</option>
						<option value="Actor 3">Actor 3</option>
						<option value="Actor 1">Actor 4</option>
						<option value="Actor 2">Actor 5</option>
						<option value="Actor 3">Actor 6</option>
					</select>
					<div class="text-center padding-small">
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarActor()"></button>
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarActor()"></button>
					</div>
					<select multiple="multiple" name="actores2" size="4" class="form-control select select-primary select-block mbl"></select>
				</div>
			</div>
			<div class="form-group">
				<div id="div-requerimientos" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Requerimientos</h3>
					<select multiple="multiple" name="requerimientos1" size="4" class="form-control select select-primary select-block mbl">
						<option value="TOT_1_1">Requerimiento 1</option>
						<option value="TOT_1_2">Requerimiento 2</option>
						<option value="TOT_1_3">Requerimiento 3</option>
						<option value="TOT_1_4">Requerimiento 4</option>
						<option value="TOT_1_5">Requerimiento 5</option>
						<option value="TOT_1_6">Requerimiento 6</option>
					</select>
					<div class="text-center padding-small">
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarRequerimiento()"></button>
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarRequerimiento()"></button>
					</div>
					<select multiple="multiple" name="requerimientos2" size="4" class="form-control select select-primary select-block mbl"></select>
				</div>
			</div>
			<div class="form-group">
				<div id="div-disparador" class="col-sm-10 col-md-10 col-lg-10">
					<input type="text" name="condicionFallo" id="disparador" placeholder="Disparador" class="form-control"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-escenarios" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Escenario Principal de Éxito</h3>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_0" name="escenario_0"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarEscenario()"></button>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div id="div-extensiones" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Extensiones</h3>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<textarea placeholder="Extensión" class="form-control" id="extension_0" name="extension_0"></textarea>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarExtension()"></button>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-6">
					<asp:Button runat="server" CssClass="btn btn-primary" Text="Agregar"/>
					<a class="btn btn-default" href="Listar.aspx">Cancelar</a>
				</div>
			</div>
		</form>
	</div>

</asp:Content>
