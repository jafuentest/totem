<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarCliente.aspx.cs" Inherits="GUI_Modulo2_AgregarCliente" %>

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
    Detallar Cliente Natural 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                <h2>Datos básicos</h2>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombreCliente"  runat="server" name="nombre" type="text" class="form-control" placeholder="Nombre" value="Pedro" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_apellido" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="apellidoCliente" runat="server" name="apellido" type="text" class="form-control" placeholder="Apellido" value="Pérez" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_rsocial" class="col-sm-2 col-md-2 col-lg-2">
                        <div class="dropdown">
                            <button id="rsocialCliente" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                V
                                <span class="caret"></span>
                            </button>
                            <ul id="rsocial-dd" class="dropdown-menu" role="menu" aria-labelledby="rsocial">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >V</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >E</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_rif" class="col-sm-10 col-md-10 col-lg-10">
                        <input id="cedulaCliente" runat="server" name="rif" type="text" class="form-control" placeholder="Cédula" value="12452843" />
                    </div>
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
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionCliente" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigopostalCliente" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" />
                    </div>
                </div>
               
                    <div class="form-group">
                        <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12">
                            <input id="correoCliente" runat="server" name="correo" type="text" class="form-control" placeholder="Correo electrónico"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                            <input id="telefonoCliente" runat="server"  name="telefono" type="text" class="form-control" placeholder="Teléfono"  />
                    </div>
                    </div>
     
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="botonEditar" runat="server" class="btn btn-primary" onserverclick="EditarCliente_Click" >Editar</button>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>
            </form>
</div>
        
    

</asp:Content>

