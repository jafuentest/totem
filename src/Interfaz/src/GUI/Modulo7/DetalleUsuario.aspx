<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetalleUsuario.aspx.cs" Inherits="GUI_Modulo7_DetalleUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Detalle de Usuario
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
        <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
            <form id="detalle-form" class="form-horizontal" action="#">
            <div class="form-group">
		        <div  class="col-sm-10 col-md-10 col-lg-10">
                    <label>Nombre de Usuario: </label>
                    <input type="text" value="aaciti" class="form-control" name="usuario" />
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-5 col-md-5 col-lg-10">
				    <label>Nombre:</label>
                    <input type="text" value="Luis" class="form-control" name="nombre"/>
			    </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Apellido: </label>
                    <input type="text" value="Perez" class="form-control" name="apellido"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Correo: </label>
                    <input type="text" value="aaciti@totem.com" class="form-control" name="correo"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Contrase&ntilde;a: </label>
                    <input type="password" value="1234567" class="form-control" name="pswd"/>
		        </div>
            </div>
            <div class="form-group">
	            <div  class="col-sm-10 col-md-10 col-lg-10">
		            <label>Confirmar Contrase&ntilde;a: </label>
                    <input type="password" value="1234567" class="form-control" name="confirm-pswd"/>
		        </div>
            </div>
                <div class="form-group">
            <div class="col-sm-10 col-md-10 col-lg-10">
                <label>Rol: </label>
            <div class="dropdown">
              <button id="id-rol" class="btn btn-default dropdown-toggle" type="button" id="dropdownRol" data-toggle="dropdown" aria-expanded="true">
                Seleccione un Rol
                <span class="caret"></span>
              </button>
              <ul id="dprol" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                <li role="presentation"><a role="menuitem" tabindex="-1" >Usuario</a></li>
                <li role="presentation"><a role="menuitem" tabindex="-1" >Admin</a></li>
              </ul>
            </div>
            </div>
        </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-5 col-lg-5">
				    <label>Cargo:</label>
                    <input type="text" value="Desarrollador" class="form-control" name="cargo" />
			    </div>
            </div>
            <div class="form-group">
			    <div  class="col-sm-10 col-md-10 col-lg-10">
				    <label>Pregunta de Seguridad:</label>
                    <input type="text" value="Cual es el apellido de soltera de tu mama?" class="form-control" name="pregunta"/>
			    </div>
            </div>
            <div class="form-group">
			    <div class="col-sm-10 col-md-10 col-lg-10">
				    <label>Respuesta: </label>
                    <input type="text" value="Jimenez" class="form-control" name="respuesta" />
			    </div>
            </div>
                <br />
                <div class="form-group col-lg-10" id="accordion2" role="tablist">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="casosDeUso">
                        <h3 class="panel-title">
                            <a href="#collapseCasosDeUso" data-toggle="collapse" data-parent="#accordion">
                                Proyectos
                            </a>
                        </h3>
                    </div>
                    <div id="collapseCasosDeUso" class="panel-collpase collapse">
                        <div class="panel-body">
                            <div class="">
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
				                            </tr><tr>
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
                </div>
                    </div>
                    </div>
                    &nbsp;&nbsp;<br />
                    <br />
                <div class="form-group col-sm-10 col-md-10 col-lg-10">
                         &nbsp; &nbsp;
				            <a class="btn btn-primary" href="ListarUsuarios.aspx?success=edit">Modificar</a>
                        &nbsp;
				            <a class="btn btn-default" href="ListarUsuarios.aspx">Cancelar</a>
                         &nbsp;
                            <a class="btn btn-danger col-md-offset-6"  href="ListarUsuarios.aspx?success=elim">Eliminar</a>
		        </div>
            </form>
        </div>
    <script src="js/Validacion.js"></script>
    <script>
        $(document).ready(function () {
            $('#table-projects').DataTable();
            $("#dprol li a").click(function () {

                $("#id-rol").html($(this).text() + ' <span class="caret"></span>');

            });
        });
    </script>
</asp:Content>

