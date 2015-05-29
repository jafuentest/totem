<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListarClientes.aspx.cs" Inherits="GUI_Modulo2_ListarClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for vertical align table -->
    <style type="text/css">
        .table > tbody > tr > td,
        .table > tbody > tr > th,
        .table > tfoot > tr > td,
        .table > tfoot > tr > th,
        .table > thead > tr > td,
        .table > thead > tr > th
        {
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Gestión de Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Listar Clientes Naturales 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat="server">
        </div>
        <div id="alertlocal" >
        </div>
        <div class="table-responsive">
            <table id="table-users" class="table table-striped table-hover">
                <thead>
                    <tr>
                        <th>Identificador</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Empresa</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody runat ="server" id="cuerpo">
                    
                </tbody>
            </table>
            <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" >Eliminación de cliente</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container-fluid">
                                <div class="row">
                                    <p>Seguro que desea eliminar al cliente natutal con Identificador # </p><p id="modal-rif"></p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <button id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarUsuario()">Eliminar</button>
                        </div>
                    </div> <!-- /.modal-content -->
                </div> <!-- /.modal-dialog -->
            </div> <!-- /.modal -->
        </div> <!-- /.table-responsive -->
    </div> <!-- /.col-10 -->

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
                    tr = $(this).parents('tr'); // Se guarda la fila seleccionada
                    $(this).parent().removeClass('selected');

                }
                else {
                    user = $(this).parent().prev().prev().prev().prev().text();
                    tr = $(this).parents('tr'); // Se guarda la fila seleccionada
                    table.$('tr.selected').removeClass('selected');
                    $(this).parent().addClass('selected');
                }
            });
            $('#modal-delete').on('show.bs.modal', function (event) {
                var modal = $(this)
                modal.find('.modal-title').text('Eliminar cliente con RIF # ' + user)
                modal.find('#modal-rif').text(user)
            })
            // Eliminar la fila
            $('#btn-eliminar').on('click', function () {
                table.row(tr).remove().draw(); // Se elimina la fila de la tabla
                $('#modal-delete').modal('hide'); // Se esconde el modal
                $('#alertlocal').addClass("alert alert-success alert-dismissible");
                $('#alertlocal').text("Se ha eliminado con éxito");
            });
        });
    </script>

</asp:Content>

