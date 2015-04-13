<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListarActores.aspx.cs" Inherits="GUI_Modulo6_ListarActores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Actores</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Lista</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<div id="alertlocal"></div>
		<div class="panel panel-primary" style="width:auto">
			<div class="panel-heading">
				<h3 class="panel-title">Proyecto</h3>
			</div>
			<div class="panel-body" style="width:auto">
				Nombre del Proyecto: TOTEM<br/>
				Empresa Cliente: UCAB<br/>
				Status del Proyecto: Activo<br/>
			</div>
		</div>
		<div class="table-responsive">
			<table id="table-example" class="table table-striped table-hover">
				<thead>
					<tr>
						<th>Nombre</th>
						<th>Descripción</th>
						<th>Acciones</th>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td>Lorem ipsum</td>
						<td>dolor sit</td>
						<td>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/ModificarActor.aspx?id=1") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>amet consectetur</td>
						<td>Lorem ipsum</td>
						<td>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/ModificarActor.aspx?id=2") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>dolor sit</td>
						<td>amet consectetur</td>
						<td>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/ModificarActor.aspx?id=3") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
				</tbody>
			</table>
			<div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
							<h4 class="modal-title" >Eliminación de Actor</h4>
						</div>
						<div class="modal-body">
							<div class="container-fluid">
								<div class="row">
									<p>Seguro que desea eliminar el actor: </p>
									<p id="user-name"></p>
								</div>
							</div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
							<button id="btn-eliminar" type="button" class="btn btn-primary">Eliminar</button>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<script type="text/javascript">
		<!-- Data tables init -->
		$(document).ready(function () {
			$('#table-example').DataTable();
			var table = $('#table-example').DataTable();
			var user, tr;
			$('#table-example tbody').on('click', 'a', function () {
				if ($(this).parent().hasClass('selected')) {
					user = $(this).parent().prev().prev().prev().prev().text();
					tr = $(this).parents('tr');//se guarda la fila seleccionada
					$(this).parent().removeClass('selected');
				}
				else {
					user = $(this).parent().prev().prev().prev().prev().text();
					tr = $(this).parents('tr');//se guarda la fila seleccionada
					table.$('tr.selected').removeClass('selected');
					$(this).parent().addClass('selected');
				}
			});
			$('#modal-delete').on('show.bs.modal', function (event) {
				var modal = $(this);
				modal.find('.modal-title').text('Eliminar actor: ' + user);
				modal.find('#user-name').text(user);
			})
			//para eliminar la fila
			$('#btn-eliminar').on('click', function () {
				table.row(tr).remove().draw();
				$('#modal-delete').modal('hide');
				$('#alertlocal').addClass("alert alert-success alert-dismissible");
				$('#alertlocal').text("El actor se ha eliminado con éxito");
			});
		});
	</script>
</asp:Content>