<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarContacto.aspx.cs" Inherits="Vista.Modulo2.AgregarContacto" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión De Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Agregar Contacto
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
     <div id="alert" runat ="server"> </div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2" Runat="Server">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12" Runat="Server">      

                <div class="form-group" Runat="Server" ></div>

                <div id="contactoEmpresa" class="list-group col-sm-12 col-md-12 col-lg-12" Runat="Server">
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <input id="contactoNombre" runat="server" class="form-control" placeholder="Nombres del Contacto" type="text" />
                                </div>
                            </div>
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <input runat="server" id="apellidoContacto" class="form-control" placeholder="Apellidos del Contacto" type="text" />
                                </div>
                            </div>                            
                            <div class="form-group" Runat="Server">
                                <div class="col-xs-12" Runat="Server">
                                    <input runat="server" id="cedulaContacto" class="form-control" placeholder="Cedula del Contacto" type="text" maxlength ="10" />
                                </div>

                            </div>

                            <!-- Split button -->
                            <div class="form-group">
                                    <div class="btn-group col-sm-12 col-md-12 col-lg-12">
                                        <div id="contenedorCargo" runat="server" class="dropdown"> 
                                            <asp:DropDownList ID="comboCargo"  class="btn btn-default dropdown-toggle" runat="server"   AutoPostBack="true"></asp:DropDownList>
                                       </div>
                                    </div>
                              </div>

                           <div class="form-group">
                                <div id="div_cod_telefono" class="col-sm-4 col-md-4 col-lg-4">
                                    <input id="codTelefono" runat="server" name="codigoTELF" type="text" class="form-control" placeholder="+(cod)" maxlength="4" />
                                </div>
                                <div id="div_telefono" class="col-sm-8 col-md-8 col-lg-8">
                                    <input id="telefonoCliente" runat="server" name="telefono" type="text" class="form-control" placeholder="Teléfono" maxlength="7" />
                                </div>
                            </div>
                     </div><div class="form-group">
                        <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12" Runat="Server">
                            <asp:Button id="botonAgregar" runat="server" class="btn btn-primary" Text="Agregar" type="submit" OnClick="botonAgregar_Click"></asp:Button>
                            <a class="btn btn-default"  href="javascript:history.go(-1)"  Runat="Server">Cancelar</a>
                        </div>
                    </div>
                </div>
        </form>
    </div>

</asp:Content>
