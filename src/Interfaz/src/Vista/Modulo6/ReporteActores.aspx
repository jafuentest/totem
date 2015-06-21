<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteActores.aspx.cs" Inherits="Vista.Modulo6.ReporteActores" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestión de Actores
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Reporte de Actores
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
<div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
		 <asp:Label ID="labelMensajeExito" Visible="false"  class="alert alert-sucess" runat="server"></asp:Label>
    <asp:Label ID="labelMensajeError" Visible="false"  class="alert alert-danger alert-dismissible" runat="server"></asp:Label>
    <br />
    <br />		
     <form id="reporte_actor" class="form-horizontal" action="#" method="post" runat="Server">
		 <div class="form-group">
                            <div id="div_actor" class="col-sm-15 col-md-15 col-lg-15">
                                <div class="dropdown " runat="server" id="Div1">
                                <asp:DropDownList ID="comboActores"  class="btn btn-default dropdown-toggle col-sm-10 col-md-10 col-lg-10" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                     </div>
		
						<div class="table-responsive">
							<table class="table table-striped table-hover">
								<thead>
									<tr>
										<th>ID</th>
										<th>Nombre</th>
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
		</form>
		</div>
	
</asp:Content>
