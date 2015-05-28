<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListarActores.aspx.cs" Inherits="GUI_Modulo6_ListarActores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo6/js/validaciones.js") %>"></script>
</asp:Content>
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
			<table id="actores" class="table table-striped table-hover">
				<thead>
					<tr>
						<th>Nombre</th>
						<th>Descripción</th>
						<th>Acciones</th>
					</tr>
				</thead>
				<tbody runat ="server" id="cuerpo">
					
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
							<a id="btn-eliminar" type="button" class="btn btn-primary">Eliminar</a>
							<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
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
        $('#actores').DataTable();
        var table = $('#actores').DataTable();
        var caso_de_uso, tr;
        var row;
        var modal;
        var id;   
        var name;
        var desc;
        $('#modal-delete').on('show.bs.modal', function (event) {
            row = $(event.relatedTarget).closest('tr');
            modal = $(event.currentTarget);
            id = row.attr('id').replace(/^actor\-/, '');
            name = row.find('td.name').text();
            desc = row.find('td.desc').text();

            modal.find('#caso_de_uso').text(name);
        });


        $('#btn-eliminar').on('click', function () {
            window.location.href = 'ListarActores.aspx?success=3&id=' + id; 
        });

        $('#modal-update').on('show.bs.modal', function (event) {
            var row = $(event.relatedTarget).closest('tr');
            var modal = $(event.currentTarget);
            var id = row.attr('id');
            var name = row.find('td.name').text();
            var desc = row.find('td.desc').text();
            window.location.href = 'ListarActores.aspx?success=4&id=' + id;
            modal.find('.modal-title').text('Modificar actor');
        });


    });
	</script>
</asp:Content>
