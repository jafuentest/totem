<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="GUI_Modulo5_RFuncionalesID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Reporte de Requerimientos</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="alert" runat="server">
    </div>
    <br />
    <h4>Seleccione el tipo de requerimiento con el cual desea filtrar el reporte</h4>
    <div class="dropdown">
        <button class="btn btn-default dropdown-toggle" type="button" id="tipoid" data-toggle="dropdown" aria-expanded="true">
        Tipo de Requerimiento:
        <span class="caret"></span>
        </button>
        <ul id="tipo-dd" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
            <li id="funcionales" role="presentation"><a role="menuitem" tabindex="-1" href="#" >Requerimientos Funcionales</a></li>
            <li id="nofuncionales" role="presentation"><a role="menuitem" tabindex="-1" href="#" >Requerimientos No Funcionales</a></li>
        </ul>
    </div>
    <br />
    <br />
    <div class="table-responsive">
	    <table id="table-requerimientos" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th>Requerimiento</th>
					<th>Tipo</th>
					<th>Prioridad</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">TOT_RF_1</td>
					<td style="width: 530px">El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td>TOT_RF_2</td>
					<td style="width: 530px">El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
				</tr><tr>
                    <td>TOT_RF_3</td>
					<td style="width: 530px">El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td>TOT_RF_4</td>
					<td style="width: 530px">El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                <td>TOT_RF_5</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td>TOT_RF_6</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                    <td>TOT_RNF_1</td>
					<td style="width: 530px">El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td>TOT_RNF_2</td>
					<td style="width: 530px">El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                <td>TOT_RNF_3</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td>TOT_RNF_4</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
			</tbody>
		</table>
        <br />
        <div class="col-lg-offset-10"\>
            &nbsp;&nbsp;&nbsp;<button id="btn-imprimir" class="btn btn-success" disabled="disabled" onclick="window.location.href='#'">Generar Documento</button>
        </div>
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
    </div><!-- table-responsive -->
    <!-- Data tables init -->
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
<script type="text/javascript">
    $('#funcionales').click(function () {/*metodo para filtrar la tabla de requerimientos para que solo aparezcan los funcionales y
                                           activa el boton de generar documento*/
            var busqueda = 'Funcional';
            $('#btn-imprimir').attr("disabled", false);
            $('#btn-imprimir').attr("onclick", "window.location.href='docs/RequerimientosFuncionales.pdf'");
            $('tr').hide();

            $('tr td.Type').each(function () {

                if ($(this).text() == busqueda) {

                    $(this).parent().show();
                }
            });

        });
        $("#tipo-dd li a").click(function () {//agrega el texto del elemento del dropdown al titulo del mismo

            $("#tipoid").html($(this).text() + ' <span class="caret"></span>');

        });
        $('#nofuncionales').click(function () {/*metodo para filtrar la tabla de requerimientos para que solo aparezcan los no funcionales 
                                                 y activa el boton de generar documento*/
            var busqueda = 'No Funcional';
            $('#btn-imprimir').attr("disabled", false);
            $('#btn-imprimir').attr("onclick", "window.location.href='docs/RequerimientosNoFuncionales.pdf'");
            $('tr').hide();

            $('tr td.Type').each(function () {

                if ($(this).text() == busqueda) {

                    $(this).parent().show();
                }
        });
    });
	</script>
    <script src="js/Validacion.js"></script>
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

