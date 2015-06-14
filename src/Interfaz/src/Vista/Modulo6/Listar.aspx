<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="Vista.Modulo6.Listar" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alertlocal"></div>
        <div id="alert" runat="server"></div>
        <div class="panel panel-primary" style="width:auto">
            <div class="panel-heading">
                <h3 class="panel-title">Proyecto</h3>
            </div>
            <div class="panel-body" style="width:auto">
                Nombre del Proyecto: TOTEM<br/>
                Empresa Cliente: UCAB<br/>
                Status del Proyecto: Activo<br/>
            </div>
        </div>
        <div class="table-responsive">
            <asp:Table ID="table_example" runat="server" CssClass="table table-striped table-hover">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Actores</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Requerimiento Asociado</asp:TableHeaderCell>
                    <asp:TableHeaderCell HorizontalAlign="Right">Acciones</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div style="text-align:right;">
            <br /><button id="btn-imprimir" class="btn btn-success">Generar Documento</button>
        </div>
        <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Eliminación de Caso de Uso</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid">
                            <div class="row">
                                <p>Seguro que desea eliminar el caso de uso: </p>
                                <p id="caso_de_uso"></p>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarCasoDeUso()" href="Listar.aspx?success=3">Eliminar</a>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
        <div id="modal-info" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Información detallada del Caso de Uso</h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid" id="info">
                            <div class="row">
								<form runat="server">
									<h3>Precondiciones</h3>
									<asp:BulletedList ID="precondiciones" runat="server"></asp:BulletedList>    
									<h3>Condición Final de Éxito</h3>
									<ul><li id="exito" runat="server"></li></ul>
									<h3>Condición Final de Fallo</h3>
									<ul><li id="fallo" runat="server"></li></ul>
									<h3>Disparador</h3>
									<ul><li id="disparador" runat="server"></li></ul>
									<h3>Escenario Principal de Éxito</h3>
									<div id="escenarioPrincipal" runat="server"></div>
								</form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
