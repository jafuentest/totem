<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Vista.Modulo7.ModificarUsuario" %>
<%@ MasterType virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Usuarios</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Detalle</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="formularioModificar" class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">      
        <div id="alert" runat="server"></div>
        <form id="formulario" class="form-horizontal" method="post" runat="server">
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <input type="text" name="nombre" id="nombre" runat="server" placeholder="Nombre" class="form-control" />
                </div>
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <input type="text" name="apellido" id="apellido" runat="server" placeholder="Apellido" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <input type="text" name="username" id="username" runat="server" placeholder="Nombre de Usuario" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <input type="text" name="correo" id="correo" runat="server" placeholder="Correo" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <input type="password" name="clave" id="clave" runat="server" placeholder="Contraseña" class="form-control" />
                </div>
                <div class="col-sm-5 col-md-5 col-lg-5">
                    <input type="password" name="confirmarClave" id="confirmarClave" runat="server" placeholder="Confirmar contraseña" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <select name="rol" id="rol" runat="server" class="form-control">
                        <option value="" disabled="disabled" selected="selected">Seleccione el rol</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <select name="cargo" id="cargo" runat="server" class="form-control">
                        <option value="" disabled="disabled" selected="selected">Seleccione el cargo</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <input type="text" name="pregunta" id="pregunta" runat="server" placeholder="Pregunta secreta" class="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <input type="text" name="respuesta" id="respuesta" runat="server" placeholder="Respuesta" class="form-control" />
                </div>
            </div>
        </form>
    </div>
</asp:Content>
