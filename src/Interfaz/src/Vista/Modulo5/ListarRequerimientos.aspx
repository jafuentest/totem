<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListarRequerimientos.aspx.cs" Inherits="Vista.Modulo5.ListarRequerimientos" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
	   #table-requerimientos td
	   {
		  vertical-align: middle;
	   }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Gestión de requerimientos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Lista de requerimiento
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral"
    Runat="Server">

    <div id="alert" runat="server">
    </div>

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
    <h2 style="align-content:center">Requerimientos asociados</h2>

    <div class="table-responsive">
    <% //if ( ListaRequerimientos != null )
	  //{
		 %>
	   <asp:Repeater ID="RRequerimientos" runat="server">
		  <HeaderTemplate>
			 <table id="table-requerimientos"
				class="table table-striped table-hover">
				<thead>
				    <tr>
					   <th>ID</th>
					   <th style="width: 530px">Requerimiento</th>
					   <th>Tipo</th>
					   <th style="width: 50px">Prioridad</th>
					   <th>Acciones</th>
				    </tr>
				</thead>
				<tbody>
		  </HeaderTemplate>
		  <ItemTemplate>
				<%
				   /*
				    * Evaluación de las propiedades pertenecientes
				    * a la clase Requerimiento
				    */
				%>
				<tr>
				    <td><%# Eval("Codigo") %></td>
				    <td><%# Eval("Descripcion") %></td>
				    <td><%# Eval("Tipo") %></td>
				    <td><%# Eval("Prioridad") %></td>
				    <td>
					   <a class="btn btn-default glyphicon glyphicon-pencil"
					   href="ModificarRequerimiento.aspx?id=<%# Eval("Codigo") %>"></a>
					   <a class="btn btn-danger glyphicon glyphicon-remove-sign"
					   href="ListarRequerimientos.aspx?eliminar=<%# Eval("Codigo") %>&list=true"></a>
				    </td>
				</tr>
		  </ItemTemplate>
		  <FooterTemplate>
				</tbody>
			 </table>
		  </FooterTemplate>
	   </asp:Repeater>
    <% /*}
	  else
	  {
		 Response.Write("<p>" + MensajeEstado + "</p>");
	  }*/
	  %>
    </div> <!-- .table-responsive -->

     
    <!-- Data tables init -->
    <script src="js/Validacion.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('#table-requerimientos').DataTable();
	        var table = $('#table-requerimientos').DataTable();
	        var req;
	        var tr;

	        $('#table-requerimientos tbody').on('click', 'a', function () {
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
    <script>
        function fillCodigoTextField() {
            var idTextField = document.getElementById("idreq_input");
            var funcionalRadio = document.getElementById("input_tipo_funcional");
            var nofuncionalRadio = document.getElementById("input_tipo_nofuncional");

            if (funcionalRadio.checked) {
                idTextField.value = "TOT_RF_5_1";
            } else
                if (nofuncionalRadio.checked) {
                    idTextField.value = "TOT_RNF_5_1";
                }
        }
    </script>
 
</asp:Content>
