<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarEmpresa.aspx.cs" Inherits="GUI_Modulo2_AgregarEmpresa" %>

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
    Gestión de empresas
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar empresa
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                <h2>Datos básicos</h2>
                <div class="form-group">
                    <div id="div_rsocial" class="col-sm-2 col-md-2 col-lg-2">
                        <div class="dropdown">
                            <button id="rsocial" class="btn btn-default dropdown-toggle" name="rsocial-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                J
                                <span class="caret"></span>
                            </button>
                            <ul id="rsocial-dd" class="dropdown-menu" role="menu" aria-labelledby="rsocial">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >J</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >G</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_rif" class="col-sm-10 col-md-10 col-lg-10">
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
                                    Seleccionar imagen <input type="file" class="imagen-url" name="imagentype" />
                                </span>
                            </span>
                            <input id="imagen-url" name="imagenurl" type="text" class="form-control" readonly="true" value="Penguins.jpg" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_imagen" class="col-sm-12 col-md-12 col-lg-12">
                        <img data-src="holder.js/150x150" style="width: 133px; height: 133px;" src="css/Penguins.jpg" alt="Logo" class="img-thumbnail" />
                    </div>
                </div>

                <h2>Datos de localización</h2>
                <div class="form-group">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="pais" class="btn btn-default dropdown-toggle" name="pais-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Venezuela
                                <span class="caret"></span>
                            </button>
                            <ul id="pais-dd" class="dropdown-menu" role="menu" aria-labelledby="pais">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Aragua</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="estado" class="btn btn-default dropdown-toggle" name="estado-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Aragua
                                <span class="caret"></span>
                            </button>
                            <ul id="estado-dd" class="dropdown-menu" role="menu" aria-labelledby="estado">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Aragua</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Carabobo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Distrito Capital</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Maracaibo</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccion" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" value="Las Delicias, Maracay" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigopostal" name="codigopostal" type="text" class="form-control" placeholder="Código postal" value="1040" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="telefono" name="telefono" type="text" class="form-control" placeholder="Teléfono" value="2125896412" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <a class="btn btn-primary" href="ListarEmpresas.aspx?success=edit">Editar</a>
                        <a class="btn btn-default" href="ListarEmpresas.aspx">Cancelar</a>
                    </div>
                </div>
            </div>

        </form>
    </div>

</asp:Content>

