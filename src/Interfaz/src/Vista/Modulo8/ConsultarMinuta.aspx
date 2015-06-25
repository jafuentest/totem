<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeFile="ConsultarMinuta.aspx.cs" Inherits="Vista.Modulo8.ConsultarMinuta" %>
<%@ MasterType virtualPath="~/Master/MasterPage.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Consultar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-xs-12">
       <div id="alert" runat="server">
       </div>
        <div class="panel panel-primary" style="width:auto">
			<div class="panel-heading">
				<h3 class="panel-title">Proyecto</h3>
			</div>
			<div class="panel-body" style="width:auto">
                <asp:Label ID="infoproyect" runat="server">Nombre del proyecto:</asp:Label> <br />
		        <asp:Label ID="infoclient" runat="server">Empresa cliente:</asp:Label> <br />
		        <asp:Label ID="infostatus" runat="server">Estatus del proyecto:</asp:Label> <br />
			</div>
		</div>
        <div class="table-responsive">
		    <table id="table-example" class="table table-striped table-hover">
			    <thead>
				    <tr>
					    <th>ID</th>
					    <th>Fecha</th>
					    <th>Motivo</th>
					    <th>Acciones</th>
				    </tr>
			    </thead>
			    <tbody runat ="server" id="cuerpo">
                    <asp:Literal runat="server" ID="laTabla"></asp:Literal>
                </tbody>
		    </table>
	    </div>
    </div>


<script type="text/javascript">
        $(document).ready(function () {
            $('#table-example').DataTable();
            var table = $('#table-example').DataTable();
            var req;
            var tr;

            $('#table-example tbody').on('click', 'a', function () {
                if ($(this).parent().hasClass('selected')) {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                    $(this).parent().removeClass('selected');

                }
                else {
                    req = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr');//se guarda la fila seleccionada
                    table.$('tr.selected').removeClass('selected');
                    $(this).parent().addClass('selected');
                }
            });
            $('#modal-delete').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
                modal.find('#req').text(req)
            })
            $('#btn-eliminar').on('click', function () {
                table.row(tr).remove().draw();//se elimina la fila de la tabla
                $('#modal-delete').modal('hide');//se esconde el modal
            });
            $('#modal-update').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Modificar requerimiento')
            });
        });
	</script>

</asp:Content>

