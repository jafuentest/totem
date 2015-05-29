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
    <div id="alert" runat="server">
    </div>
    <div id="alertlocal">
    </div>
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
                        <input id="rifEmpresa" name="rif" runat="server" type="text" class="form-control" placeholder="Identificador de la Empresa" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="nombreEmpresa" runat="server" name="nombre" type="text" class="form-control" placeholder="Nombre de la Empresa" />
                    </div>
                </div>

                <h2>Datos de localización</h2>
                <div class="form-group">
                    <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboPais">
                            <select id="comboPais" runat="server">
                                
                                <option value="0" runat="server" selected="selected">Seleccione País..</option>
                                <option value="1" runat="server">Venezuela</option>
                            </select>
                        </div>
                    </div>
                    <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                        <div class="dropdown" runat="server" id="contenedorComboEstado">
                             <select id="comboEstado" runat="server">
                                
                                <option value="0" runat="server" selected="selected">Seleccione Estado..</option>
                                <option value="2" runat="server">Dtto Capital</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    
                        <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                            <div class="dropdown" runat="server" id="contenedorComboCiudad" >
                                <select id="comboCiudad" runat="server" >
                                
                                <option value="0" runat="server" selected="selected">Seleccione Ciudad..</option>
                                <option value="4" runat="server">Caracas</option>
                            </select>
                            </div>
                        </div>
                    
                </div>

                <div class="form-group">
                    <div id="div_direccionEmpresa" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="direccionEmpresa" runat="server" name="direccion" type="text" class="form-control" placeholder="Dirección detallada" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <input id="codigoPostalEmpresa" runat="server" name="codigopostal" type="text" class="form-control" placeholder="Código postal" />
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
                                    <input id="cedulaContacto" runat="server" class="form-control" placeholder="Cédula del Contacto" type="text" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-xs-10">
                                    <input id="nombreContacto" runat="server" class="form-control" placeholder="Nombres del Contacto" type="text" />
                                </div>
                            </div>

                            <div class="col-xs-10 form-group"></div>
                            <div class="form-group">
                                <div class="col-xs-10">
                                    <input id="apellidoContacto" runat="server" class="form-control" placeholder="Apellidos del Contacto" type="text" />
                                </div>

                            </div>
                            <div class="col-xs-12 form-group"></div>


                            <!-- Split button -->
                            <div class="form-group">
                               
                                    <div class="btn-group col-sm-10 col-md-10 col-lg-10">
                                        <div id="contenedorCargo" runat="server" class="dropdown"> 
                                        <select id="comboCargo" runat="server">
                                              <option runat="server" value="0">Seleccione Cargo..</option>
                                              <option runat="server" value="1">Gerente</option>
                                              <option runat="server" value="2">Desarrollador</option> 
                                            <option runat="server" value="3">Diseñador</option> 
                                            <option runat="server" value="4">Arquitecto de Solucion</option>                                      
                                        </select>
                                       </div>
                                    </div>
                                </div>
                                
                            </div>

                            <div class="col-xs-10 form-group"></div>
                            <div class="form-group">
                                <div class="col-xs-10">
                                    <input id="telefonoContacto" class="form-control" runat="server" placeholder="Teléfono celular " type="text" />
                                </div>
                            </div>
                            <div class="col-xs-10 form-group"></div>
                            



                        </div>




                    </div>
                </div>

                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <button id="botonAgregar" type="submit" class="btn btn-primary" runat="server" onserverclick="AgregarEmpresa_Click">Agregar</button>
                        <a class="btn btn-default" runat="server" href="ListarEmpresas.aspx">Cancelar</a>
                    </div>
                </div>
            </form>
            </div>
  

    <script type="text/javascript" src="js/ValidacionesContacto.js"></script>

</asp:Content>
