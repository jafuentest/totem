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
         <asp:Label ID="labelMensajeExito" Visible="false"  class="alert alert-sucess" runat="server"></asp:Label>
    <asp:Label ID="labelMensajeError" Visible="false"  class="alert alert-danger alert-dismissible" runat="server"></asp:Label>
    <br />
    <br />	
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
       <h2>Casos de Uso</h2>
						<div class="table-responsive">
							<table class="table table-striped table-hover">
								<thead>
									<tr>
										<th>ID</th>
										<th>Nombre</th>
                                        <th>Actores</th>
										<th>Requerimiento Asociado</th>
										<th style="text-align:right;">Acciones</th>
									</tr>
								</thead>
								<tbody runat="server" id="cuerpo">
									<asp:Literal runat="server" ID="tabla"></asp:Literal>
								</tbody>
							</table>
						</div>
        <div style="text-align:right;">
            <br /><button id="boton" runat="server" class="btn btn-success">Generar Documento</button>
        </div>
        
        
    </div>

</asp:Content>
