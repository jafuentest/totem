<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarEmpresa.aspx.cs" Inherits="GUI_Modulo2_AgregarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/GUI/Modulo2/css/agregar-empresa.css") %>" rel="stylesheet" />

    <!-- Custom JS for image preview -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/image-preview.js") %>"></script>

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/dropdown-ae.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Detallar empresa
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="form-group">
                <h3>Datos básicos</h3>
                <div class="row col-sm-5 col-md-5 col-lg-5">
                    <div class="form-group">
                        <div id="div_rsocial" class="col-sm-3 col-md-3 col-lg-3">
                            <div class="dropdown">
                                <button id="rsocial-id" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                    J
                                    <span class="caret"></span>
                                </button>
                                <ul id="rsocial-dd" class="dropdown-menu" role="menu" aria-labelledby="rsocial-id">
                                    <li role="presentation"><a role="menuitem" tabindex="-1" >J</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" >G</a></li>
                                </ul>
                            </div>
                        </div>
                        <div id="div_rif" class="col-sm-9 col-md-9 col-lg-9">
                            <input id="rif" name="rif" type="text" class="form-control" placeholder="RIF" value="000012595" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                            <input id="nombre" name="nombre" type="text" class="form-control" placeholder="Nombre" value="Alimentos Ronald, C.A." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div id="div_imagen_control" class="col-sm-12 col-md-12 col-lg-12">
                            <div class="input-group">
                                <span class="input-group-btn">
                                    <span class="btn btn-default btn-file">
                                        Explorar <input type="file" class="imagen-url" name="imagentype" />
                                    </span>
                                </span>
                                <input id="imagen-url" name="imagenurl" type="text" class="form-control" readonly="true" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row col-sm-5 col-md-5 col-lg-5">
                    <div id="div_imagen" class="col-sm-11 col-md-11 col-lg-11">
                        &nbsp;&nbsp;&nbsp;
                        <img data-src="holder.js/133x133" style="width: 133px; height: 133px;" src="css/Penguins.jpg" alt="Logo" class="img-thumbnail" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <h3>Datos de localización</h3>
                <div class="row">
                    <div id="div_pais" class="col-sm-5 col-md-5 col-lg-5">
                        <div class="dropdown">
                            <button id="pais-id" class="btn btn-default dropdown-toggle" name="pais-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Venezuela
                                <span class="caret"></span>
                            </button>
                            <ul id="pais-dd" class="dropdown-menu" role="menu" aria-labelledby="pais-id">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Venezuela</a></li>
                            </ul>
                        </div>
                    </div>
                    &nbsp;
                    <div id="div_estado" class="col-sm-5 col-md-5 col-lg-5">
                        <div class="dropdown">
                            <button id="estado-id" class="btn btn-default dropdown-toggle" name="estado-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Aragua
                                <span class="caret"></span>
                            </button>
                            <ul id="estado-dd" class="dropdown-menu" role="menu" aria-labelledby="estado-id">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Aragua</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Carabobo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Distrito Capital</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Maracaibo</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div id="div_direccion" class="col-sm-10 col-md-10 col-lg-10">
                        <input id="direccion" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" value="Las Delicias" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div id="div_cpostal" class="col-sm-5 col-md-5 col-lg-5">
                        <input id="codigopostal" name="codigopostal" type="text" class="form-control" placeholder="Código postal" value="1040" />
                    </div>
                    &nbsp;
                    <div id="div_telefono" class="col-sm-5 col-md-5 col-lg-5">
                        <input id="telefono" name="telefono" type="text" class="form-control" placeholder="Teléfono" value="2125896412" />
                    </div>
                </div>
            </div>

            <div class="form-group">
                <a class="btn btn-primary" href="ListarEmpresas.aspx?success=edit">Editar</a>
                <a class="btn btn-default" href="ListarEmpresas.aspx">Cancelar</a>
            </div>

        </form>
    </div>

</asp:Content>

