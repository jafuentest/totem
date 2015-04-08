<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Modificar.aspx.cs" Inherits="GUI_Modulo6_Modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Casos de Uso</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Modificar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<form action="Crear.aspx" method="post">
		<div class="form-group">
			<div class="row">
				<div class="col-lg-3">
					<input type="text" name="id" id="id" placeholder="ID" class="form-control" />
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-lg-3">
					<input type="text" name="nombre" id="nombre" placeholder="Nombre" class="form-control" />
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-lg-3">
					<input type="text" name="precondicion" id="precondicion" placeholder="Precondición" class="form-control" />
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-lg-3">
					<input type="text" name="condicionExito" id="condicionExito" placeholder="Condición Final de Éxito" class="form-control" />
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-lg-3">
					<input type="text" name="condicionFallo" id="condicionFallo" placeholder="Condición Final de Fallo" class="form-control" />
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-lg-3">
					<select class="form-control select select-primary select-block mbl">
						<option value="">Actor Primario</option>
						<option value="Actor 1">Actor 1</option>
						<option value="Actor 2">Actor 2</option>
						<option value="Actor 3">Actor 3</option>
					</select>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-lg-3">
					<select multiple="multiple" name="requerimiento" class="form-control select select-primary select-block mbl">
						<option value="TOT_1_1">Requerimiento 1</option>
						<option value="TOT_1_2">Requerimiento 2</option>
						<option value="TOT_1_3">Requerimiento 3</option>
						<option value="TOT_1_4">Requerimiento 4</option>
						<option value="TOT_1_5">Requerimiento 5</option>
						<option value="TOT_1_6">Requerimiento 6</option>
					</select>
				</div>
			</div>
			<br />
			<div id="escenarios">
				<h3>Escenario Principal</h3>
				<div class="row">
					<div class="col-lg-3">
						<input type="text" placeholder="Condición Final de Fallo" class="form-control" />
					</div>
					<div class="col-lg-3">
						<button class="btn btn-default" onclick="agregarEscenario()">Agregar</button>
					</div>
				</div>
			</div>
			<br />
			<div id="extensiones">
				<h3>Extensiones</h3>
				<div class="row">
					<div class="col-lg-3">
						<input type="text" placeholder="Extensión" class="form-control" />
					</div>
					<div class="col-lg-3">
						<button class="btn btn-default" onclick="agregarExtension()">Agregar</button>
					</div>
				</div>
			</div>
			<br />
			<div class="row">
				<div class="col-md-6">
					<button class="btn btn-primary" type="submit">Guardar Cambios</button>
				</div>
			</div>
		</div>
	</form>

	<script type="text/javascript">
		function agregarEscenario() {
			escenarios = document.getElementById("escenarios");
			child = escenarios.lastElementChild.lastElementChild;
			child.innerHTML = '<button class="btn btn-danger" onclick="eliminarCampo(this)">Eliminar</button>';
			codigo = '<div class="row">'
			codigo += '<br/>'
			codigo += '<div class="col-lg-3">';
			codigo += '<input type="text" placeholder="Condición Final de Fallo" class="form-control" />';
			codigo += '</div>'
			codigo += '<div class="col-lg-3">'
			codigo += '<button class="btn btn-default" onclick="agregarEscenario()">Agregar</button>'
			codigo += '</div>'
			codigo += '</div>'
			escenarios.innerHTML += codigo;
		}

		function agregarExtension() {
			escenarios = document.getElementById("extensiones");
			child = escenarios.lastElementChild.lastElementChild;
			child.innerHTML = '<button class="btn btn-danger" onclick="eliminarCampo(this)">Eliminar</button>';
			codigo = '<div class="row">'
			codigo += '<br/>'
			codigo += '<div class="col-lg-3">';
			codigo += '<input type="text" placeholder="Extensión" class="form-control" />';
			codigo += '</div>'
			codigo += '<div class="col-lg-3">'
			codigo += '<button class="btn btn-default" onclick="agregarExtension()">Agregar</button>'
			codigo += '</div>'
			codigo += '</div>'
			escenarios.innerHTML += codigo;
		}

		function eliminarCampo(caller) {
			parent = caller.parentElement.parentElement;
			parent.parentElement.removeChild(parent);
		}
	</script>
</asp:Content>