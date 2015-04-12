<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarCliente.aspx.cs" Inherits="GUI_Modulo2_AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/GUI/Modulo2/css/agregar-cliente.css") %>" rel="stylesheet" />

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/dropdown-ac.js") %>"></script>

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Agregar cliente
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-2">
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="form-group">
                <h3>Datos básicos</h3>
                <div class="row">
                    <div id="div_nombre" class="col-sm-5 col-md-5 col-lg-5">
                        <input id="nombre" name="nombre" type="text" class="form-control" placeholder="Nombre" />
                    </div>
                    &nbsp;
                    <div id="div_apellido" class="col-sm-5 col-md-5 col-lg-5">
                        <input id="apellido" name="apellido" type="text" class="form-control" placeholder="Apellido" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div id="div_rsocial" class="col-sm-1 col-md-1 col-lg-1">
                        <div class="dropdown">
                            <button id="rsocial-id" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                V
                                <span class="caret"></span>
                            </button>
                            <ul id="rsocial-dd" class="dropdown-menu" role="menu" aria-labelledby="rsocial-id">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >V</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >E</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_rif" class="col-sm-4 col-md-4 col-lg-4">
                        <input id="rif" name="rif" type="text" class="form-control" placeholder="RIF" />
                    </div>
                    &nbsp;
                    <div id="div_cargo" class="col-sm-5 col-md-5 col-lg-5">
                        <div class="dropdown">
                            <button id="cargo-id" class="btn btn-default dropdown-toggle" name="cargo-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Cargo empresarial
                                <span class="caret"></span>
                            </button>
                            <ul id="cargo-dd" class="dropdown-menu" role="menu" aria-labelledby="cargo-id">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Director general</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Director ejecutivo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Gerente departamental</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <h3>Datos de contacto</h3>
                <div class="row">
                    <div id="div_correo" class="col-sm-5 col-md-5 col-lg-5">
                        <input id="correo" name="correo" type="text" class="form-control" placeholder="Correo electrónico" />
                    </div>
                    &nbsp;
                    <div id="div_telefono" class="col-sm-5 col-md-5 col-lg-5">
                        <input id="telefono" name="telefono" type="text" class="form-control" placeholder="Teléfono" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <button class="btn btn-primary">Registrar</button>
            </div>

        </form>
    </div>

</asp:Content>

