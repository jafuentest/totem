<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="GUI_Modulo6_Listar" %>
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
            <asp:Table ID="table_example" runat="server" CssClass="table table-striped table-hover">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Actor Primario</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Requerimiento Asociado</asp:TableHeaderCell>
                    <asp:TableHeaderCell HorizontalAlign="Right">Acciones</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div style="text-align:right;">
            <br /><button id="btn-imprimir" class="btn btn-success">Generar Documento</button>
        </div>
        <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Eliminación de Caso de Uso</h4>
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
                        <a id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarCasoDeUso()" href="Listar.aspx?success=3">Eliminar</a>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Información detallada del Caso de Uso</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid" id="info">
                            <div class="row">
                                <h3>Precondiciones</h3>
                                    <ul>
                                        <li>Usuario registrado</li>
                                        <li>Usuario logeado</li>
                                        <li>Proyecto creado</li>
                                    </ul>
                                <h3>Condición Final de Éxito</h3>
                                <p>
                                    Caso de uso creado
                                </p>
                                <h3>Condición Final de Fallo</h3>
                                <p>
                                    El caso de uso no pudo ser creado
                                </p>
                                <h3>Disparador</h3>
                                <p>
                                    Seleccionar opción "Gestión de Casos de uso" → "Agregar caso de uso" del menú
                                </p>
                                <h3>Escenario Principal de Éxito</h3>
                                    <ol>
                                        <li>El usuario o admin selecciona la opción "Gestión de Casos de uso" → "Agregar caso de uso" del menú.</li>
                                        <li>El sistema despliega la pantalla de obtener los datos del caso de uso.</li>
                                        <li>El usuario o admin ingresa los números de los requerimientos asociados.</li>
                                        <li>El sistema verifica la existencia de esos requerimientos.</li>
                                        <li>El usuario o admin introduce los datos del caso de uso.</li>
                                        <li>El sistema registra el caso de uso. Volver paso 2. El CU termina.</li>
                                    </ol>
                                <h3>Extensiones</h3>
                                <p>
                                    4-A. El o los requerimientos no existen.
                                </p>
                                <p style="text-indent: 5em;">
                                    A1. Desplegar mensaje de error.
                                </p>
                                <p style="text-indent: 5em;">
                                    A2. Volver al paso 2. 
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
    	//Data tables init
    	$(document).ready(function () {
    		$('#table_example').DataTable();
    		var table = $('#table_example').DataTable();
    		var caso_de_uso, tr;
    		$('#table_example tbody').on('click', 'a', function () {
    			if ($(this).parent().hasClass('selected')) {
    				caso_de_uso = $(this).parent().prev().prev().prev().prev().text();
    				tr = $(this).parents('tr'); //Se guarda la fila seleccionada
    				$(this).parent().removeClass('selected');
    			}
    			else {
    				caso_de_uso = $(this).parent().prev().prev().prev().prev().text();
    				tr = $(this).parents('tr'); //Se guarda la fila seleccionada
    				table.$('tr.selected').removeClass('selected');
    				$(this).parent().addClass('selected');
    			}
    		});
    		$('#modal-delete').on('show.bs.modal', function (event) {
    			var modal = $(this)
    			modal.find('.modal-title').text('Eliminar caso de uso: ' + caso_de_uso)
    			modal.find('#caso_de_uso').text(caso_de_uso)
    		})
    		//Para eliminar la fila
    		$('#btn-eliminar').on('click', function () {
    			table.row(tr).remove().draw(); //Se elimina la fila de la tabla
    			$('#modal-delete').modal('hide'); //Se esconde el modal
    		});
    		$('#modal-update').on('show.bs.modal', function (event) {
    			var modal = $(this)
    			modal.find('.modal-title').text('Modificar caso de uso')
    		});
    		$('#btn-imprimir').attr("onclick", "window.location.href='docs/Casos_de_Uso.pdf'");
    	});
    </script>
</asp:Content>
