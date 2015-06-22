<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListarClientes.aspx.cs" Inherits="Vista.Modulo2.ListarClientes" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
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
    <form runat="server" class="form-horizontal" method="POST">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody runat ="server" id="cuerpo">
                    <asp:Literal runat="server" ID="laTabla"></asp:Literal>
                </tbody>
            </table>
            
        </div> <!-- /.table-responsive -->
    </div> <!-- /.col-10 -->
        </form>
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

