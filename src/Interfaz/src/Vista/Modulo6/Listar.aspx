<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="Vista.Modulo6.MiLista" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
	   #tablaCasosUso td
	   {
		  vertical-align: middle;
	   }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Casos de Uso
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar Casos de Uso
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
         <asp:Label ID="labelMensajeExito" Visible="false"  class="alert alert-sucess" runat="server"></asp:Label>
    <asp:Label ID="labelMensajeError" Visible="false"  class="alert alert-danger alert-dismissible" runat="server"></asp:Label>
    <br />
    <br />	
        <div class="panel panel-primary" style="width: auto">
	   <div class="panel-heading">
		  <h3 class="panel-title" style="align-content: center">
			 Proyecto seleccionado
		  </h3>
	   </div>
	   <div class="panel-body" style="width: auto" id="infor">
		  <asp:Label ID="infoproyect" runat="server">Nombre del proyecto:</asp:Label> <br />
		  <asp:Label ID="infoclient" runat="server">Empresa cliente:</asp:Label> <br />
		  <asp:Label ID="infostatus" runat="server">Estatus del proyecto:</asp:Label> <br />
	   </div>
    </div>
       <h2>Casos de Uso</h2>
						<div class="table-responsive">
							<% //if ( ListaRequerimientos != null )
	  //{
		 %>
	   <asp:Repeater ID="RCasosDeUso" runat="server">
		  <HeaderTemplate>
			 <table id="tablaCasosUso"
				class="table table-striped table-hover">
				<thead>
				    <tr>
					   <th>ID</th>
					   <th style="width: 50px">Nombre</th>
					   <th>Condición Final de Éxito</th>
					   <th style="width: 50px">Condición Final de Fallo</th>
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
				    <td><%# Eval("IdentificadorCasoUso") %></td>
				    <td><%# Eval("TituloCasoUso") %></td>
                    <td><%# Eval("CondicionExito") %></td>
                    <td><%# Eval("CondicionFallo") %></td>

                     
				    
				    <td>
					   <a class="btn btn-default glyphicon glyphicon-pencil"
					   href="Modificar.aspx?id=<%# Eval("Id") %>"></a>
					   <a class="btn btn-danger glyphicon glyphicon-remove-sign"
					   href="Listar.aspx?eliminar=<%# Eval("Id") %>"></a>
				    </td>
				</tr>
		  </ItemTemplate>
		  <FooterTemplate>
				</tbody>
			 </table>
		  </FooterTemplate>
	   </asp:Repeater>

        </div>
        <div style="text-align:right;">
            <br /><button id="boton" runat="server" class="btn btn-success">Generar Documento</button>
        </div>  	<script type="text/javascript">
	    $(document).ready(function () {
	        $('#tablaCasosUso').DataTable();
	        var table = $('#tablaCasosUso').DataTable();
	        var req;
	        var tr;

	        $('#tablaCasosUso tbody').on('click', 'a', function () {
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
	            modal.find('.modal-title').text('Eliminar caso de uso:  ' + req)
	            modal.find('#casouso').text(req)
	        })
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
        
    </div>




</asp:Content>
