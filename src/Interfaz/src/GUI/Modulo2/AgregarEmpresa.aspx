<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarEmpresa.aspx.cs" Inherits="GUI_Modulo2_AgregarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/src/GUI/Modulo2/css/agregar-empresa.css") %>" rel="stylesheet" />

    <!-- Custom JS for image preview -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/image-preview.js") %>"></script>

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/dropdown-ae.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="Server">
    Gestión de Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="Server">
    Agregar Cliente Juridico
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="Server">

    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" runat="Server">

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
                                <li role="presentation"><a role="menuitem" tabindex="-1">J</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">G</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_rif" class="col-sm-10 col-md-10 col-lg-10">
                        <input id="rif" name="rif" type="text" class="form-control" placeholder="Identificador de la Empresa" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombre" name="nombre" type="text" class="form-control" placeholder="Nombre de la Empresa" />
                    </div>
                </div>

                <h2>Datos de localización</h2>
                <div class="form-group">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="pais" class="btn btn-default dropdown-toggle" name="pais-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                País
                                <span class="caret"></span>
                            </button>
                            <ul id="pais-dd" class="dropdown-menu" role="menu" aria-labelledby="pais">
                                <li role="presentation"><a role="menuitem" tabindex="-1">Venezuela</a></li>
                            </ul>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown">
                            <button id="estado" class="btn btn-default dropdown-toggle" name="estado-dd" type="button" data-toggle="dropdown" aria-expanded="true">
                                Estado
                                <span class="caret"></span>
                            </button>
                            <ul id="estado-dd" class="dropdown-menu" role="menu" aria-labelledby="estado">
                                <li role="presentation"><a role="menuitem" tabindex="-1">Aragua</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Carabobo</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Distrito Capital</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Maracaibo</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="ciudad" class="btn btn-default dropdown-toogle col-sm-12 col-md-12 col-lg-12" name="ciudad-dd" type="button"data-toggle="dropdown" aria-expanded="true">
                            Ciudad
                            <span class="caret"></span>
                        </button>
                        <ul id="ciudad-dd" class="dropdown-menu" role="menu" aria-labelledby="ciudad">
                            <li role="presentation"><a role="menuitem" tabindex="-1">Maracay</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Caracas</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Guarenas</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1">Los Teques</a></li>
                        </ul>
                    </div>
                </div>

                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccion" name="direccion" type="text"  class="form-control" placeholder="Dirección detallada" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigopostal" name="codigopostal" type="text" class="form-control" placeholder="Código postal" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="telefono" name="telefono" type="text" class="form-control" placeholder="Teléfono" />
                    </div>
                </div>

                <h2>Contactos</h2>

                <div class="form-group"></div>

                <div id="contactoEmpresa" class="list-group col-sm-10 col-md-10 col-lg-10">
                    <div id="1-contacto-div" class="panel panel-default panel-punto">
                        <div class="panel-body panel-minuta">
                            <div class="form-group">
                                <div class="col-xs-12">
                                    <button type="button" id="1-contacto" class="close col-md-15" data-dismiss="alert" aria-label="Close" onclick='borrarContacto(this);'><span aria-hidden="true">&times;</span></button>

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-xs-10">
                                    <input class="form-control" placeholder="Nombres del Contacto" type="text" />
                                </div>
                            </div>

                            <div class="col-xs-10 form-group"></div>
                            <div class="form-group">
                                <div class="col-xs-10">
                                    <input class="form-control" placeholder="Apellidos del Contacto" type="text" />
                                </div>

                            </div>
                            <div class="col-xs-12 form-group"></div>


                            <!-- Split button -->
                            <div class="form-group">
                                <div class="btn-group col-sm-10 col-md-10 col-lg-10">
                                    <button type="button" class="btn btn-default col-sm-10 col-md-10 col-lg-10">Seleccione un cargo..</button>
                                    <button type="button" class="btn btn-default dropdown-toggle col-md-2" data-toggle="dropdown" aria-expanded="false">
                                        <span class="caret"></span>
                                        <span class="sr-only">Toggle Dropdown</span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu">


                                        <li><a href="#">Gerente General</a></li>
                                        <li><a href="#">Gerente de Proyectos</a></li>
                                        <li><a href="#">Líder de Proyectos</a></li>

                                    </ul>
                                </div>
                                <div class="col-sm-1 col-md-1 col-lg-1">
                                    <button type="button" class="btn btn-default btn-circle glyphicon glyphicon-plus" onclick="agregarContacto()"></button>

                                </div>
                            </div>

                            <div class="col-xs-10 form-group"></div>
                            <div class="form-group"> 
                                <div class="col-xs-10">
                                    <input class="form-control" placeholder="Teléfono celular " type="text" />
                                </div>
                            </div>
                                <div class="col-xs-10 form-group"></div>
                                <div class="form-group"> 
                                    <div class="col-xs-10">
                                        <input class="form-control" placeholder="Teléfono celular alternativo" type="text" />
                                    </div>
                                </div>

                            

                            </div>



                        
          </div>
</div>

                    <div class="form-group">
                        <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                            <a class="btn btn-primary" href="ListarEmpresas.aspx?success=regis">Agregar</a>
                            <a class="btn btn-default" href="ListarEmpresas.aspx">Cancelar</a>
                        </div>
                    </div>

                </div>
        </form>
    </div>



    <script type="text/javascript" src="js/ValidacionesContacto.js"></script>

</asp:Content>
