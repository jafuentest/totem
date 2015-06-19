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
					   data-toggle="modal" data-target="#modal-update"
					   href="ListarRequerimientos.aspx?id=<%# Eval("Id") %>"></a>
					   <a class="btn btn-danger glyphicon glyphicon-remove-sign"
					   data-toggle="modal" data-target="#modal-delete"
					   href="ListarRequerimientos.aspx?id=<%# Eval("Id") %>"></a>
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
    

        <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el requerimiento:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">  
                <a id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarRequerimiento()" href="ListarRequerimientos.aspx?success=3">Eliminar</a>
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
           </div>
          </div><!-- /.modal-delete-content -->
        </div><!-- /.modal-delete-dialog -->
      </div><!-- /.modal-delete -->
      <div id="modal-update" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <form id="modificar_requerimientos" class="form-horizontal" method="post" action="Reportes.aspx?success=2">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Modificaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                <div class="form-group">
				    <div id="div-id" class="col-sm-5 col-md-5 col-lg-5">
					    <input type="text" name="idreq" id="idreq_input" placeholder="ID" class="form-control" disabled="disabled" value="TOT_RF_5_1"/>
				    </div>
			    </div>
                <div class="form-group">
                    <div class="col-sm-10 col-md-10 col-lg-10">
                        <p><b>Tipo de Requerimiento:</b></p>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo" checked="checked" id="input_tipo_funcional" onclick="return fillCodigoTextField();"/>Funcional</label>
                        <label class="radio-inline">
                        <input type="radio" name="radioTipo" id="input_tipo_nofuncional" onclick="return fillCodigoTextField();"/>No Funcional</label>
                    </div>
                </div>
                <br/>                
                <div class="form-group">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <div class="input-group">
                            <span class="input-group-addon">El sistema deberá </span>
                            <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento" id="input_requerimiento">El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</textarea>
                        </div>
                    </div>
                </div>
                    <br />
                    <div class="form-group">
                        <div class="col-sm-10 col-md-10 col-lg-10">
                            <p><b>Prioridad:</b></p>
                            <label class="radio-inline">
                            <input type="radio" name="radioPrioridad" id="input_prioridad_baja"/>Baja</label>
                            <label class="radio-inline">
                            <input type="radio" name="radioPrioridad" checked="checked" id="input_prioridad_media"/>Media</label>
                            <label class="radio-inline">
                            <input type="radio" name="radioPrioridad" id="input_prioridad_alta"/>Alta</label>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <div class="col-sm-10 col-md-10 col-lg-10">
                            <p><b>Status:</b></p>
                            <label class="radio-inline">
                            <input type="radio" name="radioStatus" checked="checked" id="input_status_nofinalizado"/>No Finalizado</label>
                            <label class="radio-inline">
                            <input type="radio" name="radioStatus" id="input_status_finalizado"/>Finalizado</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
              <button id="btn-modificarReq" disabled="disabled" class="btn btn-primary" type="submit" onclick="return checkform();">Modificar</button>
              <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            </div>
          </div><!-- /.modal-update-content -->
        </div><!-- /.modal-update-dialog -->
        </form>
      </div><!-- /.modal-update -->
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
