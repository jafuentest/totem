<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarEmpresa.aspx.cs" Inherits="GUI_Modulo2_AgregarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/src/GUI/Modulo2/css/agregar-empresa.css") %>" rel="stylesheet" />

    <!-- Custom JS for image preview -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/image-preview.js") %>"></script>

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/dropdown-ae.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Gestión de empresas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar empresa
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                <h2>Datos básicos</h2>
                <div class="form-group">
                    <div id="div_rsocial" class="col-sm-2 col-md-2 col-lg-2">
                        <div class="dropdown">
                            <button id="rsocial" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                J
                                <span class="caret"></span>
                            </button>
                            <ul id="rsocial-dd" class="dropdown-menu" role="menu" aria-labelledby="rsocial">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >J</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >G</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_rif" class="col-sm-10 col-md-10 col-lg-10">
                        <input id="rifEmpresa" runat="server" name="rif" type="text" class="form-control" placeholder="RIF" value="000012595" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombreEmpresa" runat="server" name="nombre" type="text" class="form-control" placeholder="Nombre" value="Alimentos Ronald, C.A." />
                    </div>
                </div>
               

                <h2>Datos de localización</h2>
                <div class="form-group">
                   
                        
                            <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboPais">
                            <select id="comboPais" runat="server"  onchange="CbCambioAEstado"></select>
                        </div>
                    </div>
                        </div>
                    
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboEstado">
                            
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="dropdown">
                    <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                         <div class="dropdown" runat="server" id="Div1">
                            
                        </div>
                    </div>
                   </div>
                </div>


                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionEmpresa" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" value="Las Delicias, Maracay" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigopostalEmpresa" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" value="1040" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="telefonoEmpresa" runat="server" name="telefono" type="text" class="form-control" placeholder="Teléfono" value="2125896412" />
                    </div>
                </div>

                <h2>Contactos</h2>

                <!--Contactos-->

                     <div class="table-responsive">
            <table id="table-users" class="table table-striped table-hover">
                <thead>
                    <tr>
                        
                        <th>Nombres y Apellidos</th>
                        <th>Cargo</th>
                        
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        
                        <td>Pedro Perez</td>
                        <td>Gerente de Proyectos</td>
                       
                        <td>                         
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo2/DetallarCliente.aspx") %>"></a>
                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                        </td>
                    </tr>
                    <tr>
                       
                        <td>Erika Rodríguez</td>
                        
                        <td>Director de Relaciones Exteriores</td>
                        <td>                         
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo2/DetallarCliente.aspx") %>"></a>
                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                        </td>
                    </tr><tr>
                        
                        <td>Nestor Osorio</td>
                       
                        <td>Gerente de Talento Humano</td>
                        <td>                         
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo2/DetallarCliente.aspx") %>"></a>
                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                        </td>
                    </tr>
                    <tr>
                        
                        <td>Seth Cursus</td>
                        
                        <td>Arquitecto del Software</td>
                        <td>                         
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo2/DetallarCliente.aspx") %>"></a>
                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                        </td>
                    </tr>
                    <tr>
                        
                        <td>Liam Nisi</td>
                        
                        <td>Analista de Desarrollo</td>
                        <td>                         
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo2/DetallarCliente.aspx") %>"></a>
                            <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                        </td>
                    </tr>
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
                                    <p>¿Está seguro que desea eliminar al contacto? </p><p id="modal-rif"></p>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button runat="server" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <button id="btn_eliminar" runat="server" type="button" class="btn btn-primary" onclick="EliminarUsuario()">Eliminar</button>
                        </div>
                    </div> <!-- /.modal-content -->
                </div> <!-- /.modal-dialog -->
            </div> <!-- /.modal -->
        </div> <!-- /.table-responsive -->
    



                <!--Botones-->
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="botonEditar" runat="server" class="btn btn-primary" onserverclick="EditarEmpresa_Click" >Editar</button>
                        <a class="btn btn-default" href="ListarEmpresas.aspx">Cancelar</a>
                    </div>
                </div>
            </form>
            </div>

        
    
</asp:Content>

