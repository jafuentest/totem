<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarMinuta.aspx.cs" Inherits="GUI_Modulo8_ConsultarMinuta" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Consultar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-xs-12">
       <div id="alert" runat="server">
       </div>
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
		    <table id="table-example" class="table table-striped table-hover">
			    <thead>
				    <tr>
					    <th>ID</th>
					    <th>Fecha</th>
					    <th>Motivo</th>
					    <th>Acciones</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td></td>
					    <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                
			    </tbody>
		    </table>
	    </div>
    </div>
    

<script type="text/javascript" src="js/consultarMinuta.js"></script>
</asp:Content>

