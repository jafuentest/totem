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
					    <th>Proyecto</th>
					    <th>Fecha</th>
					    <th>Motivo</th>
                        <th>Estado Proyecto</th>
					    <th>Acciones</th>
				    </tr>
			    </thead>
			    <tbody>
				    <tr>
					    <td>Min_01</td>
					    <td>Totem</td>
					    <td>10-05-15</td>
					    <td>Primer Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-success glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_02</td>
                        <td>Totem</td>
                        <td>10-06-15</td>
                        <td>Segundo Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-success glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_03</td>
                         <td>Totem</td>
                        <td>10-07-15</td>
                        <td>Segundo Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-success glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_04</td>
                        <td>Totem</td>
                        <td>15-08-15</td>
                        <td>Tercer Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-success glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_05</td>
                       <td>Totem</td>
                        <td>10-09-15</td>
                        <td>Último Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-success glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_06</td>
                         <td>Totem</td>
                        <td>19-07-15</td>
                        <td>Primer Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary glyphicon glyphicon-info-sign" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-success glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/docs/MINUTA3.pdf") %>"></a>
                        </td>
                    </tr>
			    </tbody>
		    </table>
	    </div>
    </div>
    

<script type="text/javascript">
    jQuery(function ($)
    {
        $('#table-example').DataTable();
    });

	</script>
</asp:Content>

