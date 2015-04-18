<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="GUI_Modulo6_Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Casos de Uso</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Lista</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<div id="alertlocal"></div>
		<div id="alert" runat="server"></div>
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
						<th>ID</th>
						<th>Nombre</th>
						<th>Actor Primario</th>
						<th>Requerimiento Asociado</th>
						<th style="text-align:right;">Acciones</th>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td>TOT_CU_6_1_1</td>
						<td>Crear caso de uso</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_1</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=1") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=1") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_5_2</td>
						<td>Consultar caso de uso clasificado por actor</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_5</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=2") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=2") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_6_3</td>
						<td>Consultar caso de uso Clasificado por ID</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_6</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=3") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=3") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_7_4</td>
						<td>Consultar Listado de actores</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_7</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=4") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=4") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_2_5</td>
						<td>Actualizar datos Caso de Uso</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_2</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=5") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=5") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_3_6</td>
						<td>Eliminar Caso de uso</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_3</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=6") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=6") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_8_7</td>
						<td>Crear actor</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_8</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=7") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=7") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_9_8</td>
						<td>Actualizar datos del actor</td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_9</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=8") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=8") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
					<tr>
						<td>TOT_CU_6_10_9</td>
						<td>Eliminar Actor </td>
						<td>Usuario, Administrador</td>
						<td>TOT_RF_6_1</td>
						<td style="text-align:right;">
							<a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=9") %>"></a>
							<a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=9") %>"></a>
							<a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
			<div class="modal-dialog">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
						<h4 class="modal-title" >Eliminación de Caso de Uso</h4>
					</div>
					<div class="modal-body">
						<div class="container-fluid">
							<div class="row">
								<p>Seguro que desea eliminar el caso de uso: </p>
								<p id="caso_de_uso"></p>
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
						<a id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarCasoDeUso()" href="Listar.aspx?success=3">Eliminar</a>
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
				var modal = $(this)
				modal.find('.modal-title').text('Eliminar caso de uso: ' + caso_de_uso)
				modal.find('#caso_de_uso').text(caso_de_uso)
			})
			//para eliminar la fila
			$('#btn-eliminar').on('click', function () {
				table.row(tr).remove().draw();//se elimina la fila de la tabla
				$('#modal-delete').modal('hide');//se esconde el modal
			});
			$('#modal-update').on('show.bs.modal', function (event) {
				var modal = $(this)
				modal.find('.modal-title').text('Modificar caso de uso')
			});
		});
	</script>
</asp:Content>
