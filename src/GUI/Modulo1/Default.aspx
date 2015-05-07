<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/src/GUI/Master/MasterPage.master"%>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">TOTEM</asp:Content>
<asp:Content ContentPlaceHolderID="subtitulo" runat="server">Bienvenido al Sistema de Documentación</asp:Content>

<asp:Content ContentPlaceHolderID="contenidoCentral" runat="server">


        <!--ALERTAS-->
        <!--Alertas de modificacion y eliminacion de requerimientos en la lista de requerimientos en el 1er acordeon-->
        <div class="form-group">
            <div id="div_alertas" class="col-sm-12 col-md-12 col-lg-12">
                <div id="alert_requerimiento" runat="server">
                </div>
            </div>
        </div>
        <div id="div_adminIcons" runat="server">

        </div>
        <div class="form-group">
            <div id="div_proyectos" class="col-sm-12 col-md-12 col-lg-12">
                <div class="table-responsive">
                    <table id="table-projects" class="table table-striped table-hover">
                        <thead>
                            <tr>
                                <th>Código</th>
                                <th>Nombre</th>
                                <th>Descripción</th>
                                <th>Precio</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="codigoProyecto">123</td>
                                <td>HidroQuest</td>
                                <td>Toma de mediciones mediante una app móvil que serán reflejadas en una app web </td>
                                <td>300.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">345</td>
                                <td>UCABFacturacion</td>
                                <td>Sistema de Facturación encargado de gestionar las inscripciones de alumnos de pregrado y posgrado</td>
                                <td>150.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">678</td>
                                <td>Totem</td>
                                <td>Gestión para la documentación de proyectos TI</td>
                                <td>800.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">247</td>
                                <td>BancaBanesco</td>
                                <td>Gestión de tarjetahabientes y manejo de transacciones bancarias nacionales e internacionales</td>
                                <td>900.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">789</td>
                                <td>ENCBCV</td>
                                <td>Sistema web encargado de gestionar las encuestas realizadas por el Banco Central de Venezuela</td>
                                <td>500.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">455</td>
                                <td>DB</td>
                                <td>Sistema para la gestión de búsqueda y reclutamiento de empleados aptos para una vacante en Dirt Bikes</td>
                                <td>60.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>


                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">655</td>
                                <td>MRW</td>
                                <td>Sistema para la gestión de envíos de encomiendas a nivel nacional</td>
                                <td>800.000.000</td>
                                <td>
                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">190</td>
                                <td>BancoEspiritoSanto</td>
                                <td>Sistema para la gestión de transferencias y remesas internacionales</td>
                                <td>950.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">678</td>
                                <td>CocaCola</td>
                                <td>Sistema de gestión y monitoreo de la calidad de los ingredientes</td>
                                <td>670.000.000</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">432</td>
                                <td>SUBWAYMOVIL</td>
                                <td>Aplicación móvil para la reservación de productos</td>
                                <td>783.000.213</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">543</td>
                                <td>MOVILMDF</td>
                                <td>Sistema de ventas y distribución de artículos telefónicos</td>
                                <td>839.901.786</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">641</td>
                                <td>BOOKFORALL</td>
                                <td>Sistema para la reservación y préstamos de libros en la biblioteca Central</td>
                                <td>345.900.234</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                            <tr>
                                <td class="codigoProyecto">568</td>
                                <td>CEMENTQUALITY</td>
                                <td>Sistema para la gestión de control de calidad del cemento industrial</td>
                                <td>789.636.908</td>
                                <td>

                                    <a class="btn btn-default glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo4/PerfilProyecto.aspx") %>"></a>

                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Eliminaci&oacute;n de Proyecto</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <p>Seguro que desea eliminar el proyecto:</p>
                                <p id="user-name"></p>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-primary" onclick="EliminarUsuario()">Eliminar</button>
                    </div>
                </div>
            </div>
        </div>
    

	<!-- Data tables init -->
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('#table-projects').DataTable();
	        var table = $('#table-projects').DataTable();
	        var user = 'hola'

	        $('#table-projects tbody').on('click', 'a', function () {
	            if ($(this).parent().hasClass('selected')) {
	                user = $(this).parent().prev().prev().prev().prev().text();
	                $(this).parent().removeClass('selected');

	            }
	            else {
	                user = $(this).parent().prev().prev().prev().prev().text();
	                table.$('tr.selected').removeClass('selected');
	                $(this).parent().addClass('selected');
	            }
	        });
	        $('#modal-delete').on('show.bs.modal', function (event) {
	            var modal = $(this)
	            modal.find('.modal-title').text('Eliminar usuario:  ' + user)
	            modal.find('#user-name').text(user)
	        })
	    });
	</script>
</asp:Content>