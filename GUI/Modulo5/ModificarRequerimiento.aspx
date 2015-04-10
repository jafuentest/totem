<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarRequerimiento.aspx.cs" Inherits="GUI_Modulo5_ModificarRequerimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos<br /></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Modificar Requerimiento</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="formularioModificar" class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">    
        <div id="alertlocal">
        </div>
        <form id="modificar_requerimientos" class="form-horizontal" method="post">
            <div class="form-group">
                <p>&nbsp;&nbsp;&nbsp;&nbsp;Tipo de Requerimiento:</p>
                &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline"><input type="radio" name="optradio1" checked="checked"/>Funcional</label>
                <label class="radio-inline">
                <input type="radio" name="optradio1"/>No Funcional</label>
            </div>
            <br/>
            <div class="row">
                <div class="col-lg-9">
                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon">El sistema deberá </span>
                            <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento">agregar usuarios</textarea>
                        </div>
                    </div>
                </div>
            </div>
            <br />
                <div class="form-group">
                    <p>&nbsp;&nbsp;&nbsp;&nbsp;Prioridad:</p>
                    &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline"><input type="radio" name="optradio"/>Baja</label>
                    <label class="radio-inline">
                    <input type="radio" name="optradio" checked="checked"/>Media</label>
                    <label class="radio-inline">
                    <input type="radio" name="optradio"/>Alta</label>
                </div>
            <br />
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <%--<button id="btn-modificarReq" disabled="disabled" class="btn btn-primary" type="submit" data-toggle="modal" data-target="#modal-update" onclick="return checkform();">Modificar</button>--%>
                    <a id="btn-modificarReq" class="btn btn-primary" data-toggle="modal" data-target="#modal-update" onclick="return checkform();" href="#">Modifcar</a>
                </div>
            </div>
        </form>
        <div id="modal-update" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" >Modificaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
                <div class="container-fluid">
                <div class="row">
                    <p>¿Seguro que desea modificar el requerimiento?</p>
                </div>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                <a id="btn-modificar" class="btn btn-primary" onclick="ModificarRequerimiento()" href="ListarRequerimientos.aspx?success=2">Modificar</a>
            </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->
        </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#modal-update').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Eliminar requerimiento')
            });
        });
	</script>
        <script src="js/Validacion.js"></script>
</asp:Content>
