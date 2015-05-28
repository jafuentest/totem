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
                <div class="form-group" Runat="Server">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6" Runat="Server">
                        <div class="dropdown" Runat="Server">
                            <button id="pais" class="btn btn-default dropdown-toggle" name="pais-dd" type="button" data-toggle="dropdown" aria-expanded="true" Runat="Server">
                                País
                                <span class="caret" Runat="Server"></span>
                            </button>
                            <ul id="paisNatural" class="dropdown-menu" role="menu" aria-labelledby="pais" Runat="Server">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Venezuela</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6" Runat="Server">
                        <div class="dropdown">
                            <button id="Estado" class="btn btn-default dropdown-toggle" name="estado-dd" type="button" data-toggle="dropdown" aria-expanded="true" Runat="Server">
                                Estado
                                <span class="caret" Runat="Server"></span>
                            </button>
                            <ul id="estadoNatural" class="dropdown-menu" role="menu" aria-labelledby="estado" Runat="Server">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Aragua</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Carabobo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Distrito Capital</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Maracaibo</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="ciudadNatural" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <button id="ciudad" class="btn btn-default dropdown-toogle col-sm-12 col-md-12 col-lg-12" name="ciudad-dd" type="button"data-toggle="dropdown" aria-expanded="true" >
                            Ciudad
                            <span class="caret" Runat="Server"></span>
                        </button>
                        <ul id="ciudad-dd" class="dropdown-menu" role="menu" aria-labelledby="ciudad" >
                            <li role="presentation"><a role="menuitem" tabindex="-1">Maracay</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Caracas</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Guarenas</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Los Teques</a></li>
                        </ul>
                    </div>
                </div>

                <div class="form-group">
                    <div id="direccion" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="direccionNatural" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" Runat="Server"/>
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="codigopostalNatural" name="codigopostal" type="text" class="form-control" placeholder="Código postal" Runat="Server"/>
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="correoNatural" name="correo" type="text" class="form-control" placeholder="Correo electrónico" Runat="Server"/>
                    </div>
                </div>
                <div class="form-group" Runat="Server">
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <input id="telefonoNatural" name="telefono" type="text" class="form-control" placeholder="Teléfono" Runat="Server"/>
                    </div>
                </div>

                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                        <a class="btn btn-primary" href="ListarClientes.aspx?success=regis">Agregar</a>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>

        </form>
    </div>

</asp:Content>

