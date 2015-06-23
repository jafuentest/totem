<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallarContacto.aspx.cs" Inherits="Vista.Modulo2.DetallarContacto" %>
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
    Gestión De Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar Contacto
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    
     <div id="alert" runat ="server"> </div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2" Runat="Server">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12" Runat="Server">      

                <div class="form-group" Runat="Server" ></div>

                <div id="contactoEmpresa" class="list-group col-sm-12 col-md-12 col-lg-12" Runat="Server">
                    
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <asp:Label ID="contactoNombre" runat="server" name="nombreContacto" class="form-control" ></asp:Label>
                                </div>
                            </div>

                            <div class="col-xs-12 form-group" Runat="Server"></div>
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                   <asp:Label ID="apellidoContacto" runat="server" name="apellidoContacto" class="form-control" ></asp:Label>
                                </div>

                            </div>                            
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <asp:Label ID="cedulaContacto" runat="server" name="cedulaContacto" class="form-control" ></asp:Label>
                                </div>

                            </div>

                            <!-- Split button -->
                            <div class="form-group">
                                    <div class="btn-group col-sm-12 col-md-12 col-lg-12">
                                        <div id="contenedorCargo" runat="server" class="dropdown"> 
                                           <asp:Label ID="cargoContacto" runat="server" name="cargoContacto" class="form-control" ></asp:Label>
                                       </div>
                                    </div>
                              </div>

                           <div class="form-group">
    
                             <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                                <asp:Label id="telefono" runat="server" name="telefono" type="text" class="form-control"/>
                             </div>

                          </div>
                     </div>

                    <div class="form-group">
                        <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                            <a class="btn btn-default" href="ListarEmpresas.aspx" Runat="Server">Volver</a>
                        </div>
                    </div>

                </div>
        </form>
    </div>

</asp:Content>


