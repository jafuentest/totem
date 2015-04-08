<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="GUI_Modulo6_Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Casos de Uso</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Lista</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
	<div class="table-responsive">
		<table id="table-example" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th>Nombre</th>
					<th>Actor Primario</th>
					<th>Requerimiento Asociado</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Lorem</td>
					<td>ipsum</td>
					<td>dolor</td>
					<td>sit</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=1") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=1") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=1") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>amet</td>
                    <td>consectetur</td>
                    <td>adipiscing</td>
                    <td>elit</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=2") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=2") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=2") %>">Eliminar</a>
                    </td>
				</tr><tr>
                    <td>Integer</td>
                    <td>nec</td>
                    <td>odio</td>
                    <td>Praesent</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=3") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=3") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=3") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>libero</td>
                    <td>Sed</td>
                    <td>cursus</td>
                    <td>ante</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=4") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=4") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=4") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>dapibus</td>
                    <td>diam</td>
                    <td>Sed</td>
                    <td>nisi</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=5") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=5") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=5") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>Nulla</td>
                    <td>quis</td>
                    <td>sem</td>
                    <td>at</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=6") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=6") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=6") %>">Eliminar</a>

                    </td>
                </tr>
                <tr>
                    <td>nibh</td>
                    <td>elementum</td>
                    <td>imperdiet</td>
                    <td>Duis</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=7") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=7") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=7") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>sagittis</td>
                    <td>ipsum</td>
                    <td>Praesent</td>
                    <td>mauris</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=8") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=8") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=8") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>Fusce</td>
                    <td>nec</td>
                    <td>tellus</td>
                    <td>sed</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=9") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=9") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=9") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>augue</td>
                    <td>semper</td>
                    <td>porta</td>
                    <td>Mauris</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=10") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=10") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=10") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>massa</td>
                    <td>Vestibulum</td>
                    <td>lacinia</td>
                    <td>arcu</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=11") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=11") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=11") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>eget</td>
                    <td>nulla</td>
                    <td>Class</td>
                    <td>aptent</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=12") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=12") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=12") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>taciti</td>
                    <td>sociosqu</td>
                    <td>ad</td>
                    <td>litora</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=13") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=13") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=13") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>torquent</td>
                    <td>per</td>
                    <td>conubia</td>
                    <td>nostra</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=14") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=14") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=14") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>per</td>
                    <td>inceptos</td>
                    <td>himenaeos</td>
                    <td>Curabitur</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=15") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=15") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=15") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>sodales</td>
                    <td>ligula</td>
                    <td>in</td>
                    <td>libero</td>
                    <td>
                        <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Detalle.aspx?id=16") %>">Detalle</a>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo6/Modificar.aspx?id=16") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo6/Eliminar.aspx?id=16") %>">Eliminar</a>
                    </td>
                </tr>
			</tbody>
		</table>
	</div>

	<!-- Data tables init -->
	<script type="text/javascript">
		jQuery(function ($) {
			$('#table-example').DataTable();
		});
	</script>
</asp:Content>