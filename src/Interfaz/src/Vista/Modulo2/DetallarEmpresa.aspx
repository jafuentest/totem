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
    
     <div id="alert" runat ="server"> </div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                <h2>Datos Básicos</h2>
                <div id="clienteInfoBasica" class="panel panel-default panel-infoBasica">
                <div class="form-group"> 
                    <div id="div_rif" class="col-sm-12 col-md-12 col-lg-12">
                       <h4 id="rifEmpresa" runat="server" name="rifEmpresa">&nbsp;Identificador: </h4>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <h4 id="nombreEmpresa" runat="server" name="nombreEmpresa">&nbsp;Nombre:</h4>
                    </div>
                </div>
                </div>

                <h2>Datos de localización</h2>
                <div id="clienteInfoLocal" class="panel panel-default panel-infoLocal">
                <div class="form-group">
                            <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboPais">
                                <h4 id="paisEmpresa" runat="server" name="paisEmpresa">&nbsp;Pais: </h4>
                                </div>
                            </div>

                            <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboEstado">
                                <h4 id="estadoEmpresa" runat="server" name="estadoEmpresa">&nbsp;Estado:</h4>
                                </div>
                            </div>
                     </div>
                     <div class="form-group">
                            <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                                <div class="dropdown" runat="server" id="Div1">
                                <h4 id="ciudadEmpresa" runat="server" name="ciudadEmpresa" >&nbsp;Ciudad:</h4>
                                </div>
                            </div>
                     </div>
                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <h4 id="direccionEmpresa" runat="server" name="direccionEmpresa" >&nbsp;Direccion:</h4>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <h4 id="codigoPostal" runat="server" name="codigoPostal">&nbsp;Codigo postal:</h4>
                    </div>
                </div>
                    </div>
                <h2>Contactos</h2>

                <!--Contactos-->

                     <div class="table-responsive" style=" text-align:center;">
                            <table id="table-users" class="table table-striped table-hover">
                                <thead>
                                    <tr>
                                        <th>Nombres y Apellidos</th>
                                        <th>Cargo</th>
                                        <th>Telefono</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody runat ="server" id="cuerpo">
                                    <asp:Literal runat="server" id="laTabla"></asp:Literal>
                                </tbody>
                                <tfoot>
                                </tfoot>
                            </table>
                         <asp:Button ID="btnAgregarNuevoContacto" class="btn btn-primary" runat="server" Text = "Agregar contacto nuevo" OnClick="btnAgregarNuevoContacto_Click"></asp:Button>
                        </div> <!-- /.table-responsive -->
                <!--Botones-->
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <a class="btn btn-default" href="ListarEmpresas.aspx">Volver</a>
                    </div>
                </div>
            </form>
            </div>
        
    
</asp:Content>


