<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarEmpresa.aspx.cs" Inherits="Vista.Modulo2.AgregarEmpresa" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <%-- <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/css/agregar-empresa.css") %>" rel="stylesheet" />

    <!-- Custom JS for image preview -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/image-preview.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/js/validation.js") %>"></script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="Server">
    Gestión de Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="Server">
    Agregar Cliente Juridico
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="Server">
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat="server">
        </div>
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" runat="Server">
                
                <!-- SECCION DE DATOS BASICOS -->
                <h2>Datos Básicos</h2>
                <div class="form-group">
                    <div id="div_rif" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="rifEmpresa" name="rif" runat="server" type="text" class="form-control" placeholder="Identificador de la Empresa" maxlength="10" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombreEmpresa" runat="server" name="nombre" type="text" class="form-control" placeholder="Nombre de la Empresa" maxlength="20"  />
                    </div>
                </div>

                 <!-- SECCION DE DATOS DE LOCALIZACION -->

                <h2>Datos De Localización</h2>
                    <div class="form-group">
                            <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboPais">
                                <asp:DropDownList ID="comboPais"  class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboPais_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboEstado">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="comboEstado"  class="btn btn-default dropdown-toggle" runat="server" AutoPostBack="true" OnSelectedIndexChanged="comboEstado_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                                <div class="dropdown" runat="server" id="Div1">
                                <asp:DropDownList ID="comboCiudad"  class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                     </div>
              

                <div class="form-group">
                    <div id="div_direccionEmpresa" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionEmpresa" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" maxlength="100" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigoPostalEmpresa" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" maxlength="10" />
                    </div>
                </div>
                 <!-- SECCION DE CONTACTO -->
                <h2>Contactos</h2>

                <div class="form-group"></div>

                <div id="contactoEmpresa" class="list-group col-sm-12 col-md-12 col-lg-12">
                    <div id="1-contacto-div" class="panel panel-default panel-punto">
                        <div class="panel-body panel-minuta">
                     
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <input id="cedulaContacto" runat="server" class="form-control" placeholder="Cédula del Contacto" type="text" maxlength="10" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <input id="nombreContacto" runat="server" class="form-control" placeholder="Nombres del Contacto" type="text" maxlength="20" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-12">
                                    <input id="apellidoContacto" runat="server" class="form-control" placeholder="Apellidos del Contacto" type="text" maxlength="20" />
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
                               
                                    <div class="btn-group col-sm-12 col-md-12 col-lg-12">
                                        <div id="contenedorCargo" runat="server" class="dropdown"> 
                                            <asp:DropDownList ID="comboCargo"  class="btn btn-default dropdown-toggle" runat="server">
                                    </asp:DropDownList>
                                       </div>
                                    </div>
                              </div>
                        </div>
                      </div>
                    </div>
               
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <Asp:Button id="botonAgregar" type="submit" class="btn btn-primary" runat="server" Text="Agregar" OnClick="botonAgregar_Click"></Asp:Button>
                        <a class="btn btn-default" runat="server" href="ListarEmpresas.aspx">Cancelar</a>
                    </div>
                </div>
            </form>
        </div>
    <script type="text/javascript" src="js/ValidacionesContacto.js"></script>

</asp:Content>