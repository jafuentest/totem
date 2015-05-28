<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="DetallarContacto.aspx.cs" Inherits="src_GUI_DetallarContacto" %>

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
    Gestión de Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar Contacto
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2" Runat="Server">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12" Runat="Server">      
                

                

                <div class="form-group" Runat="Server" ></div>

                <div id="contactoEmpresa" class="list-group col-sm-12 col-md-12 col-lg-12" Runat="Server">
                    
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <input class="form-control" placeholder="Nombres del Contacto" type="text" Runat ="Server" />
                                </div>
                            </div>

                            <div class="col-xs-12 form-group" Runat="Server"></div>
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <input class="form-control" placeholder="Apellidos del Contacto" type="text" Runat="Server"/>
                                </div>

                            </div>
                            <div class="col-xs-12 form-group" Runat="Server"></div>


                            <!-- Split button -->
                            <div class="form-group">
                                <div class="btn-group col-sm-12 col-md-12 col-lg-12" Runat="Server">
                                     <button type="button" class="btn btn-default col-sm-11 col-md-11 col-lg-11" Runat="Server">Seleccione un cargo..</button>
                                    <button type="button" class="btn btn-default dropdown-toggle col-md-1" data-toggle="dropdown" aria-expanded="false"     Runat="Server">
                                        <span class="caret" Runat="Server"></span>
                                        <span class="sr-only" Runat="Server">Toggle Dropdown</span>
                                    </button>
                                    <ul class="dropdown-menu" role="menu" Runat="Server">


                                        <li><a href="#">Gerente General</a></li>
                                        <li><a href="#">Gerente de Proyectos</a></li>
                                        <li><a href="#">Líder de Proyectos</a></li>

                                    </ul>
                                </div>
                               
                            </div>

                            <div class="col-xs-12 form-group" Runat="Server"></div>
                            <div class="form-group" Runat="Server"> 
                                <div class="col-xs-12" Runat="Server">
                                    <input class="form-control" placeholder="Teléfono celular " type="text" Runat="Server" />
                                </div>
                            </div>
                                <div class="col-xs-12 form-group" Runat="Server"></div>
                                <div class="form-group" Runat="Server"> 
                                    <div class="col-xs-12" Runat="Server">
                                        <input class="form-control" placeholder="Teléfono celular alternativo" type="text" Runat="Server"/>
                                    </div>
                                </div>

                            

                            </div>



                        


                    <div class="form-group">
                        <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                            <a class="btn btn-primary" href="ListarEmpresas.aspx?success=regis" Runat="Server">Editar</a>
                            <a class="btn btn-default" href="ListarEmpresas.aspx" Runat="Server">Cancelar</a>
                        </div>
                    </div>

                </div>
        </form>
    </div>

</asp:Content>

