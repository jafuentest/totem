<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListarActores.aspx.cs" Inherits="GUI_Modulo6_ListarActores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Actores</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Lista</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<div id="alert" runat="server"></div>
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
						<td>Usuario</td>
						<td>Usuario común del sitio</td>
						<td>
							<a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>Administrador</td>
						<td>Hereda todos los permisos del Usuario común, además tener permisos totales en el sistema</td>
						<td>
							<a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
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
							<h4 class="modal-title">Eliminación de Actor</h4>
						</div>
						<div class="modal-body">
							<div class="container-fluid">
								<div class="row">
									<p>Seguro que desea eliminar el actor:</p>
									<p id="caso_de_uso"></p>
								</div>
							</div>
						</div>
						<div class="modal-footer">
							<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
							<a id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarCasoDeUso()" href="ListarActores.aspx?success=3">Eliminar</a>
						</div>
					</div>
				</div>
			</div>
			<div id="modal-update" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
				<div class="modal-dialog">
					<div class="modal-content">
						<div class="modal-header">
							<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
							<h4 class="modal-title">Modificación de Caso de Uso</h4>
						</div>
						<form name="form_actor" id="form_actor" class="form-horizontal" action="ListarActores.aspx?success=2" method="post">
							<div class="modal-body">
								<div class="container-fluid">
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
								</div>
							</div>
							<div class="modal-footer">
								<button id="btn-modificarCU" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
								<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
							</div>
						</form>
					</div><!-- /.modal-content -->
				</div><!-- /.modal-dialog -->
			</div><!-- /.modal -->
		</div>
	</div>
	<script type="text/javascript">
		<!-- Data tables init -->
		$(document).ready(function () {
			$('#table-example').DataTable();
			var table = $('#table-example').DataTable();
			var caso_de_uso, tr;
			$('#table-example tbody').on('click', 'a', function () {
				if ($(this).parent().hasClass('selected')) {
					caso_de_uso = $(this).parent().prev().prev().prev().prev().text();
					tr = $(this).parents('tr');//se guarda la fila seleccionada
					$(this).parent().removeClass('selected');
				}
				else {
					caso_de_uso = $(this).parent().prev().prev().prev().prev().text();
					tr = $(this).parents('tr');//se guarda la fila seleccionada
					table.$('tr.selected').removeClass('selected');
					$(this).parent().addClass('selected');
				}
			});
			$('#modal-delete').on('show.bs.modal', function (event) {
				var modal = $(this);
				modal.find('.modal-title').text('Eliminar actor: ' + caso_de_uso);
				modal.find('#caso_de_uso').text(caso_de_uso);
			})
			$('#btn-eliminar').on('click', function () {
				table.row(tr).remove().draw();//se elimina la fila de la tabla
				$('#modal-delete').modal('hide');//se esconde el modal
			});
			$('#modal-update').on('show.bs.modal', function (event) {
				var modal = $(this)
				modal.find('.modal-title').text('Modificar actor')
			});
		});
	</script>
</asp:Content>
