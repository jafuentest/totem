<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Modificar.aspx.cs" Inherits="GUI_Modulo6_Modificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<link href="<%= Page.ResolveUrl("~/src/GUI/Modulo6/css/modulo6.min.css") %>" rel="stylesheet"/>
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo6/js/modulo6.js") %>"></script>
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo6/js/validaciones.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Casos de Uso</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Modificar caso de uso</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<form name="form_casodeuso" id="form_casodeuso" class="form-horizontal" action="<%= Page.ResolveUrl("~/src/GUI/Modulo6/Listar.aspx?success=2") %>" method="post">
			<div class="form-group">
				<div id="div-id" class="col-sm-10 col-md-10 col-lg-10">
					<input type="text" name="id" id="id" placeholder="ID" class="form-control" disabled="disabled" value="TOT_CU_6_1_1"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-nombre" class="col-sm-10 col-md-10 col-lg-10">
					<label>Nombre:</label>
					<input type="text" name="nombre" id="nombre" placeholder="Nombre" class="form-control" value="Crear caso de uso"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-precondiciones" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Precondiciones</h3>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Precondición" class="form-control" id="precondicion_0" name="precondicion_0" value="Usuario registrado"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Precondición" class="form-control" id="precondicion_1" name="precondicion_1" value="Usuario logeado"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Precondición" class="form-control" id="precondicion_2" name="precondicion_2" value="Proyecto creado"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarPrecondicion()"></button>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div id="div-condicionExito" class="col-sm-10 col-md-10 col-lg-10">
					<label>Condición Final de Éxito:</label>
					<input type="text" name="condicionExito" id="condicionExito" placeholder="Condición Final de Éxito" class="form-control" value="Caso de uso creado"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-condicionFallo" class="col-sm-10 col-md-10 col-lg-10">
					<label>Condición Final de Fallo:</label>
					<input type="text" name="condicionFallo" id="condicionFallo" placeholder="Condición Final de Fallo" class="form-control" value="El caso de uso no pudo ser creado"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-actores" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Actores</h3>
					<select multiple="multiple" name="actores1" size="4" class="form-control select select-primary select-block mbl">
						<option value="Actor 1">Actor 2</option>
						<option value="Actor 1">Actor 4</option>
						<option value="Actor 2">Actor 5</option>
						<option value="Actor 3">Actor 6</option>
					</select>
					<div class="text-center padding-small">
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarActor()"></button>
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarActor()"></button>
					</div>
					<select multiple="multiple" name="actores2" size="4" class="form-control select select-primary select-block mbl">
						<option value="Actor 2">Actor 1</option>
						<option value="Actor 3">Actor 3</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<div id="div-requerimientos" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Requerimientos</h3>
					<select multiple="multiple" name="requerimientos1" size="4" class="form-control select select-primary select-block mbl">
						<option value="TOT_1_1">Requerimiento 1</option>
						<option value="TOT_1_3">Requerimiento 3</option>
						<option value="TOT_1_5">Requerimiento 5</option>
						<option value="TOT_1_6">Requerimiento 6</option>
					</select>
					<div class="text-center padding-small">
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-down" onclick="agregarRequerimiento()"></button>
						<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-chevron-up" onclick="eliminarRequerimiento()"></button>
					</div>
					<select multiple="multiple" name="requerimientos2" size="4" class="form-control select select-primary select-block mbl">
						<option value="TOT_1_2">Requerimiento 2</option>
						<option value="TOT_1_4">Requerimiento 4</option>
					</select>
				</div>
			</div>
			<div class="form-group">
				<div id="div-disparador" class="col-sm-10 col-md-10 col-lg-10">
					<label>Disparador:</label>
					<input type="text" name="condicionFallo" id="disparador" placeholder="Disparador" class="form-control" value="Seleccionar opción &quot;Gestión de Casos de uso&quot; → &quot;Agregar caso de uso&quot; del menú"/>
				</div>
			</div>
			<div class="form-group">
				<div id="div-escenarios" class="col-sm-10 col-md-10 col-lg-10">
					<h3>Escenario Principal de Éxito</h3>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_0" name="escenario_0" value="El usuario o admin selecciona la opción 'Gestión de Casos de uso' → 'Crear caso de uso' del menú"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_1" name="escenario_1" value="El sistema despliega la pantalla de obtener los datos del caso de uso"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_2" name="escenario_2" value="El usuario o admin ingresa los números de los requerimientos asociados"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_3" name="escenario_3" value="El sistema verifica la existencia de esos requerimientos"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_4" name="escenario_4" value="El usuario o admin introduce los datos del caso de uso"/>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-danger btn-circle glyphicon glyphicon-remove" onclick="eliminarCampo(this)"></button>
						</div>
					</div>
					<div class="form-group">
						<div class="col-sm-11 col-md-11 col-lg-11">
							<input type="text" placeholder="Paso" class="form-control" id="escenario_5" name="escenario_5" value="El sistema registra el caso de uso. Volver paso 2. El CU termina"/>
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
							<textarea placeholder="Extensión" class="form-control" id="extension_0" name="extension_0">4-A. El o los requerimientos no existen.
A1. Desplegar mensaje de error.
A2. Volver al paso 2.</textarea>
						</div>
						<div class="col-sm-1 col-md-1 col-lg-1">
							<button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarExtension()"></button>
						</div>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-6">
					<button class="btn btn-primary" type="submit">Modificar</button>
					<a class="btn btn-default" href="Listar.aspx">Cancelar</a>
				</div>
			</div>
		</form>
	</div>
</asp:Content>
