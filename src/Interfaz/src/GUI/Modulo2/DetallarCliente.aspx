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
     <div id="alert" runat ="server"> </div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                
                <h2>Datos Básicos</h2>
                
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombreCliente"  runat="server" name="nombre" type="text" class="form-control" placeholder="Nombre" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_apellido" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="apellidoCliente" runat="server" name="apellido" type="text" class="form-control" placeholder="Apellido" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_rif" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="cedulaCliente" runat="server" name="rif" type="text" class="form-control" placeholder="Cédula" maxlength="10"/>
                    </div>
                </div>

                 <h2>Datos De Localización</h2>

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
                    <div id="div_cod_telefono" class="col-sm-4 col-md-4 col-lg-4">
                        <input id="codTelefono" runat="server" name="codigoTELF" type="text" class="form-control" placeholder="+(cod)" maxlength="4" />
                    </div>
                    <div id="div_telefono" class="col-sm-8 col-md-8 col-lg-8">
                        <input id="telefonoCliente" runat="server" name="telefono" type="text" class="form-control" placeholder="Teléfono" maxlength="7" />
                    </div>
                </div>
     
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="botonEditar" runat="server" class="btn btn-primary" onserverclick="EditarCliente_Click" type="submit">Editar</button>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>
            </form>
</div>
</asp:Content>

