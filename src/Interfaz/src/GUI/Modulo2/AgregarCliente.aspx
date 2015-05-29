<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarCliente.aspx.cs" Inherits="GUI_Modulo2_AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/src/GUI/Modulo2/css/agregar-cliente.css") %>" rel="stylesheet" />

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/dropdown-ac.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Gestión de Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Agregar Cliente Natural 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="alert" runat ="server"> </div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2" Runat="Server">
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12" Runat="Server">
                <h2>Datos básicos</h2>
                <div class="form-group" Runat="Server">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="nombreNatural" name="nombre" type="text" class="form-control" placeholder="Nombre" Runat="Server" />
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_apellido" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="apellidoNatural" name="apellido" type="text" class="form-control" placeholder="Apellido" Runat="Server" />
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_rsocial" class="col-sm-2 col-md-2 col-lg-2" Runat="Server">
                        <div class="dropdown" Runat="Server">
                            <button id="rsocial" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true" Runat="Server">
                                
                                <span class="caret" Runat="Server"></span>
                            </button>
                            <ul id="rsocial-dd" class="dropdown-menu" role="menu" aria-labelledby="rsocial" >
                                <li role="presentation"><a role="menuitem" tabindex="-1" >V</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >E</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_rif" class="col-sm-10 col-md-10 col-lg-10">
                        <input id="rif" name="identificador" type="text" class="form-control" placeholder="Identificador" Runat="Server"/>
                    </div>
                </div>
                
                <div class="form-group">
                </div>
                
                <h2>Datos de localización</h2>
                <div class="form-group">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboPais">
                            <select id="comboPais" runat="server"  onchange="CbCambioAEstado"></select>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboEstado">
                            <select id="comboEstado" runat="server" onchange="CbCambioACiudad"></select>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    
                        <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                            <div class="dropdown" runat="server" id="contenedorComboCiudad" >
                                <select id="comboCiudad" runat="server" ></select>
                            </div>
                        </div>
                    
                </div>

                <div class="form-group">
                    <div id="div_direccionEmpresa" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionCliente" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigoPostalCliente" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" />
                    </div>
                </div>

                <div class="form-group">
                    <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="correoCliente" runat="server" name="correo" type="text" class="form-control" placeholder="Correo electrónico" />
                    </div>
                </div>

                <div class="form-group">
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="telefonoCliente" runat="server" name="telefono" type="text" class="form-control" placeholder="Teléfono" />
                    </div>
                </div>

                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                          <button type="submit" class="btn btn-primary" runat="server" onserverclick="AgregarCliente_Click">Agregar</button>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>
    
        </form>
    </div>

</asp:Content>

