<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarCliente.aspx.cs" Inherits="GUI_Modulo2_AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/GUI/Modulo2/css/agregar-cliente.css") %>" rel="stylesheet" />

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/dropdown-ac.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Gestión de clientes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar cliente
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                <h2>Datos básicos</h2>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombre" name="nombre" type="text" class="form-control" placeholder="Nombre" value="Pedro" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_apellido" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="apellido" name="apellido" type="text" class="form-control" placeholder="Apellido" value="Pérez" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_rsocial" class="col-sm-2 col-md-2 col-lg-2">
                        <div class="dropdown">
                            <button id="rsocial" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true">
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
                        <input id="rif" name="rif" type="text" class="form-control" placeholder="RIF" value="12452843" />
                    </div>
                </div>
                <h2>Datos empresariales</h2>
                <div class="form-group">
                    <div id="div_cargo" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="cargo" class="btn btn-default dropdown-toggle" name="cargo-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Director general
                                <span class="caret"></span>
                            </button>
                            <ul id="cargo-dd" class="dropdown-menu" role="menu" aria-labelledby="cargo">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Director general</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Director ejecutivo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Gerente departamental</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Otro</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_otro_cargo" class="col-sm-6 col-md-6 col-lg-6">
                        <input id="otro-cargo" name="otrocargo" type="text" class="form-control" placeholder="Otro cargo" disabled="disabled" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_empresa" class="col-sm-12 col-md-12 col-lg-12">
                        <div class="dropdown">
                            <button id="empresa" class="btn btn-default dropdown-toggle" name="empresa-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Alimentos Ronald, C.A.
                                <span class="caret"></span>
                            </button>
                            <ul id="empresa-dd" class="dropdown-menu" role="menu" aria-labelledby="cargo">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Alimentos Ronald, C.A.</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >P&G Venezuela, C.A.</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <h2>Datos de localización</h2>
                <div class="form-group">
                    <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="correo" name="correo" type="text" class="form-control" placeholder="Correo electrónico" value="pedro.perez@alimentosronald.com" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="telefono" name="telefono" type="text" class="form-control" placeholder="Teléfono" value="2124578123" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <a class="btn btn-primary" href="ListarClientes.aspx?success=edit">Editar</a>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>

        </form>
    </div>

</asp:Content>

