<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListarUsuarios.aspx.cs" Inherits="GUI_Modulo7_ListarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Usuarios del sistema
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
        <div id="alert" runat="server">
        </div>
        <div id="alertlocal" >
        </div>
         <div id="alert_registro" runat="server">
         </div>
    <div class="table-responsive">
		<table id="table-users" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>Usuario</th>
					<th>Nombre</th>
					<th>Apellido</th>
					<th>Cargo</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="username">totkin</td>
					<td>Pedro</td>
					<td>Perez</td>
					<td>Gerente de Proyecto</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">amet</td>
                    <td>Fulana</td>
                    <td>Rodriguez</td>
                    <td>Dise&ntilde;ador</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>

                    </td>
				</tr><tr>
                    <td class="username">Integer</td>
                    <td>Nestor</td>
                    <td>Osorio</td>
                    <td>Administrador Base de Datos</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">libero</td>
                    <td>Seth</td>
                    <td>Cursus</td>
                    <td>Desarrollador</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">dapibus</td>
                    <td>Liam</td>
                    <td>Nisi</td>
                    <td>Desarrollador</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">Nulla</td>
                    <td>Maria</td>
                    <td>Aguila</td>
                    <td>Gerente de Proyectos</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>

                    </td>
                </tr>
                <tr>
                    <td class="username">nibh</td>
                    <td>Elena</td>
                    <td>Stone</td>
                    <td>Desarrollador</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">sagittis</td>
                    <td>Pietro</td>
                    <td>Santini</td>
                    <td>Desarrollador</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/ DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                   </td>
                </tr>
                <tr>
                    <td class="username">Fusce</td>
                    <td>Armando</td>
                    <td>Reveron</td>
                    <td>Dise&ntilde;ador</td>
                    <td>
                          
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                   </td>
                </tr>
                <tr>
                    <td class="username">augue</td>
                    <td>Juan</td>
                    <td>Porta</td>
                    <td>Gerente de Proyecto</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">lacinia</td>
                    <td>Marcos</td>
                    <td>Macia</td>
                    <td>Administrador Base de Datos</td>
                    <td>
                        
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                 </td>
                </tr>
                <tr>
                    <td class="username">eget</td>
                    <td>Ana</td>
                    <td>Clase</td>
                    <td>Desarrollador</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                    <td class="username">aaciti</td>
                    <td>Luis</td>
                    <td>Perez</td>
                    <td>Desarrollador</td>
                    <td>
                         
                        <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo7/DetalleUsuario.aspx?id=1") %>"></a>
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
          <h4 class="modal-title" >Eliminaci&oacute;n de Usuario</h4>
        </div>
        <div class="modal-body">
          <div class="container-fluid">
            <div class="row">
                <p>Seguro que desea eliminar el usuario:</p>
                <p id="user-name"></p>
            </div>
          </div>
        </div>
        <div class="modal-footer">
            <button id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarUsuario()">Eliminar</button>
          <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>         
        </div>
      </div><!-- /.modal-content -->
    </div><!-- /.modal-dialog -->
  </div><!-- /.modal -->
	</div>
	<!-- Data tables init -->
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('#table-users').DataTable();
	        var table = $('#table-users').DataTable();
	        var user;
	        var tr;

	        $('#table-users tbody').on('click', 'a', function () {
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
	            var modal = $(this)
	            modal.find('.modal-title').text('Eliminar usuario:  ' + user)
	            modal.find('#user-name').text(user)
	        })
            //para eliminar la fila
	        $('#btn-eliminar').on('click', function () {
	            table.row(tr).remove().draw();//se elimina la fila de la tabla
	            $('#modal-delete').modal('hide');//se esconde el modal
	            $('#alertlocal').addClass("alert alert-success alert-dismissible");
	            $('#alertlocal').html("<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Se ha eliminado exitosamente</div>");
	        });
	    });
	</script>
</asp:Content>

