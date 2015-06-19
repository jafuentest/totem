<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="Vista.Modulo2.AgregarCliente" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
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
     <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat ="server">
        </div>
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12" Runat="Server">
                <!-- SECCION DE DATOS BASICOS -->
                <h2>Datos Básicos</h2>
                <div class="form-group" Runat="Server">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="nombreNatural" name="nombre" type="text" class="form-control" placeholder="Nombre" Runat="Server" maxlength="60"/>
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_apellido" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="apellidoNatural" name="apellido" type="text" class="form-control" placeholder="Apellido" Runat="Server" maxlength="60" />
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_rif" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="cedulaNatural" name="identificador" type="text" class="form-control" placeholder="Identificador" Runat="Server" maxlength="10"/>
                    </div>
                </div>

                <br />
                <!-- SECCION DE DATOS DE LOCALIZACION -->
                <h2>Datos de Localización</h2>
                <div class="form-group">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboPais">
                            <asp:DropDownList ID="comboPais"  class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboPais_SelectedIndexChanged">
                                    </asp:DropDownList>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboEstado">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:DropDownList ID="comboEstado"  class="btn btn-default dropdown-toggle" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="comboEstado_SelectedIndexChanged">
                                    </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                        <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                            <div class="dropdown" runat="server" id="contenedorComboCiudad" >
                                 <asp:DropDownList ID="comboCiudad"  class="btn btn-default dropdown-toggle" runat="server">
                                    </asp:DropDownList>
                            </div>
                        </div>
                </div>
                <div class="form-group">
                    <div id="div_direccionEmpresa" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionCliente" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" maxlength="100" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigoPostalCliente" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" maxlength="8" />
                    </div>
                </div>

                <div class="form-group">
                    <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="correoCliente" runat="server" name="correo" type="text" class="form-control" placeholder="Correo electrónico" maxlength="60" />
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
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                          <asp:Button id="botonAgregar" Text="Agregar" type="submit" class="btn btn-primary" runat="server" OnClick="botonAgregar_Click1"></asp:Button>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>
        </form>
    </div>

</asp:Content>

