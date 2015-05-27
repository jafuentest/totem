<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarCliente.aspx.cs" Inherits="GUI_Modulo2_AgregarCliente" %>

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
    Detallar Cliente Natural 
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
                        <input id="rif" runat="server" name="rif" type="text" class="form-control" placeholder="Cédula" value="12452843" />
                    </div>
                </div>

                 <h2>Datos de localización</h2>

                <div class="form-group">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="paisCliente" runat="server" class="btn btn-default dropdown-toggle" name="pais-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                País
                                <span class="caret"></span>
                            </button>
                            <ul id="paisLista" class="dropdown-menu" role="menu" aria-labelledby="pais">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Venezuela</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="estadoCliente" runat="server" class="btn btn-default dropdown-toggle" name="estado-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Estado
                                <span class="caret"></span>
                            </button>
                            <ul id="estadoLista" runat="server" class="dropdown-menu" role="menu" aria-labelledby="estado">
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Aragua</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Carabobo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Distrito Capital</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" >Maracaibo</a></li>
                            </ul>
                        </div>
                    </div>
                    </div>
                    <div class="form-group">
                    <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="ciudadCliente" class="btn btn-default dropdown-toogle"  name="ciudad-dd" type="button"data-toggle="dropdown" aria-expanded="true">
                            Ciudad
                            <span class="caret"></span>
                        </button>
                        <ul id="ciudadLista" runat="server" class="dropdown-menu" role="menu" aria-labelledby="ciudad">
                            <li role="presentation"><a role="menuitem" tabindex="-1">Maracay</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Caracas</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Guarenas</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Los Teques</a></li>
                        </ul>
                    </div>
                </div>

               

                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionCliente" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigopostalCliente" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" />
                    </div>
                </div>
               
                    <div class="form-group">
                        <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12">
                            <input id="correoCliente" runat="server" name="correo" type="text" class="form-control" placeholder="Correo electrónico"  />
                        </div>
                    </div>
                    <div class="form-group">
                        <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                            <input id="telefonoCliente" runat="server"  name="telefono" type="text" class="form-control" placeholder="Teléfono"  />
                    </div>
                    </div>
     
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="botonEditar" runat="server" class="btn btn-primary" >Editar</button>
                        <a class="btn btn-default" href="ListarClientes.aspx">Cancelar</a>
                    </div>
                </div>
            </div>

        </form>
    </div>

</asp:Content>

