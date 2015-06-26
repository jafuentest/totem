<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListarActores.aspx.cs" Inherits="Vista.Modulo6.ListarActores" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		<asp:Label ID="labelMensajeExito" Visible="false"  class="alert alert-sucess" runat="server"></asp:Label>
    <asp:Label ID="labelMensajeError" Visible="false"  class="alert alert-danger alert-dismissible" runat="server"></asp:Label>
		<div class="panel panel-primary" style="width:auto">
			<div class="panel-heading">
				<h3 class="panel-title">Proyecto</h3>
			</div>
			<div id="proyectoPanel" runat="server"  class="panel-body" style="width:auto">
				
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
					<asp:Literal runat="server" ID="laTabla"></asp:Literal>
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
</asp:Content>
