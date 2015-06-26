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
                <div class="form-group" Runat="Server" ></div>
                <div id="contactoInfoBasica" class="panel panel-default panel-infoBasica">

                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <h4 ID="contactoNombre" runat="server" name="nombreContacto">&nbsp;Nombre: </h4>
                                </div>
                            </div>
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                   <h4 ID="apellidoContacto" runat="server" name="apellidoContacto">&nbsp;Apellido: </h4>
                                </div>
                            </div>                            
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <h4 ID="cedulaContacto" runat="server" name="cedulaContacto">&nbsp;Cedula: </h4>
                                </div>

                            </div>
                            <!-- Split button -->
                            <div class="form-group">
                                    <div class="btn-group col-sm-12 col-md-12 col-lg-12">
                                        <div id="contenedorCargo" runat="server" class="dropdown"> 
                                           <h4 ID="cargoContacto" runat="server" name="cargoContacto">&nbsp;Cargo: </h4>
                                       </div>
                                    </div>
                              </div>
                           <div class="form-group">
                             <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                                <h4 id="telefono" runat="server" name="telefono">&nbsp;Telefono: </h4>
                             </div>
                          </div>
                    </div>
                    <div class="form-group">
                        <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                            <a class="btn btn-default" href="javascript:history.go(-1)" Runat="Server">Volver</a>
                        </div>
                    </div>
        </form>
    </div>

</asp:Content>


