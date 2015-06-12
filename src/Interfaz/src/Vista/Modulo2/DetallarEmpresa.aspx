<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallarEmpresa.aspx.cs" Inherits="Vista.Modulo2.DetallarEmpresa" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
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
    Gestión De Empresas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar Empresa
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div id="alert" runat="server">
    </div>
    <div id="alertlocal">
    </div>
    <div id="alertRif" runat="server"> </div>
    <div id="alertNombreEmpresa" runat="server"></div>
    <div id="alertPais" runat="server"></div>
     <div id="alertEstado" runat="server"></div>
     <div id="alertCiudad" runat="server"></div>
    <div id="alertDireccion" runat="server"></div>    
    <div id="alertTelefono" runat="server"></div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                <h2>Datos Básicos</h2>
                <div class="form-group">
                    
                    <div id="div_rif" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="rifEmpresa" runat="server" name="rif" type="text" class="form-control" placeholder="RIF" readonly="true" maxlength="20" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombreEmpresa" runat="server" name="nombre" type="text" class="form-control" placeholder="Nombre" maxlength="60" />
                    </div>
                </div>
               
                <h2>Datos de localización</h2>
                    
                <div class="form-group">
                            <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboPais">
                                <asp:DropDownList ID="comboPais"  class="btn btn-default dropdown-toggle" runat="server"  AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>

                            <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboEstado">
                                <asp:DropDownList ID="comboEstado"  class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                     </div>
                     <div class="form-group">
                            <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                                <div class="dropdown" runat="server" id="Div1">
                                <asp:DropDownList ID="comboCiudad"  class="btn btn-default dropdown-toggle" runat="server"  AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                     </div>
                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionEmpresa" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" maxlength="100" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigopostalEmpresa" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" maxlength="4" readonly="true" />
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
                        
                    </tr>
                </thead>
                <tbody runat ="server" id="cuerpo">
                    <asp:Literal runat="server" ID="laTabla"></asp:Literal>
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
                                    <p>¿Está seguro que desea eliminar al contacto? </p>
                                    <p id="contacto_id" runat="server"></p>
                                    <p id="contacto_nombreyap" runat="server"></p>
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

