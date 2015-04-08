<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
             <div class="col-sm-5 table-responsive">
              <table id="table-example" class=" table table-striped table-hover display">
                <thead>
                  <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Rol</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>Argenis</td>
                    <td>Rodriguez</td>
                    <td>Arguello</td>
                  </tr>
                    <tr>
                    <td>Argenis1</td>
                    <td>Rodriguez</td>
                    <td>Arguello</td>
                  </tr>
                </tbody>
              </table>
            </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#table-example').DataTable();

            $('#table-example tbody').on('click', 'tr', function () {
                if ($(this).hasClass('selected')) {
                    $(this).removeClass('selected');
                }
                else {
                    table.$('tr.selected').removeClass('selected');
                    $(this).addClass('selected');
                }
                if (confirm('Seguro de que deseas deseleccionar a esta persona') == true) {
                    table.row('.selected').remove().draw(false);
                } else {
                    $(this).removeClass('selected');
                }
            });

        });
</script>
</asp:Content>

