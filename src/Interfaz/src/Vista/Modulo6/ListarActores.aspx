<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListarActores.aspx.cs" Inherits="Vista.Modulo6.ListarActores" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
	   #actores td
	   {
		  vertical-align: middle;
	   }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
     Gestión de Actores
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar Actores
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
				<% //if ( ListaRequerimientos != null )
	  //{
		 %>
	   <asp:Repeater ID="RActor" runat="server">
		  <HeaderTemplate>
			 <table id="actores"
				class="table table-striped table-hover">
				<thead>
				    <tr>
					   <th>Nombre</th>
					   <th style="width: 50px">Descripcion</th>

					   <th>Acciones</th>
				    </tr>
				</thead>
				<tbody>
		  </HeaderTemplate>
		  <ItemTemplate>
				<%
				   /*
				    * Evaluación de las propiedades pertenecientes
				    * a la clase Caso de Uso
				    */
				%>
				<tr>
				    <td><%# Eval("NombreActor") %></td>
				    <td><%# Eval("DescripcionActor") %></td>
                    

                     
				    
				    <td>
					   <a class="btn btn-default glyphicon glyphicon-pencil"
					   href="Modificar.aspx?id=<%# Eval("Id") %>"></a>
					   <a class="btn btn-danger glyphicon glyphicon-remove-sign"
					   href="ListarActores.aspx?eliminarActor=<%# Eval("Id") %>"></a>
				    </td>
				</tr>
		  </ItemTemplate>
		  <FooterTemplate>
				</tbody>
			 </table>
		  </FooterTemplate>
	   </asp:Repeater>        </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#actores').DataTable();
            var table = $('#actores').DataTable();
            var req;
            var tr;

            $('#actores tbody').on('click', 'a', function () {
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
                modal.find('.modal-title').text('Eliminar actor:  ' + req)
                modal.find('#actor').text(req)
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

	</div>
</asp:Content>
