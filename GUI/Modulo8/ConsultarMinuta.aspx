﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarMinuta.aspx.cs" Inherits="GUI_Modulo8_ConsultarMinuta" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Minutas</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">  Consultar</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-xs-12">    
        <ol class="breadcrumb">
            <li><a href="ConsultarMinuta.aspx">Consultar</a></li>
        </ol>
        
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
					    <td>Facebook</td>
					    <td>10-05-15</td>
					    <td>Primer Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-default glyphicon glyphicon-eye-open" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/MINUTA3.doc.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_02</td>
                        <td>Totem</td>
                        <td>10-06-15</td>
                        <td>Segundo Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-default glyphicon glyphicon-eye-open" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-print" onclick="return print()"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_03</td>
                         <td>Word OnLine</td>
                        <td>10-07-15</td>
                        <td>Segundo Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-default glyphicon glyphicon-eye-open" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/MINUTA3.doc.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_04</td>
                        <td>Totem</td>
                        <td>15-08-15</td>
                        <td>Tercer Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-default glyphicon glyphicon-eye-open" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/MINUTA3.doc.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_05</td>
                       <td>Google</td>
                        <td>10-09-15</td>
                        <td>Último Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-default glyphicon glyphicon-eye-open" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/MINUTA3.doc.pdf") %>"></a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_06</td>
                         <td>Comapañia CEL</td>
                        <td>19-07-15</td>
                        <td>Primer Encuentro</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-default glyphicon glyphicon-eye-open" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-pencil" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx") %>"></a>
                            <a class="btn btn-default glyphicon glyphicon-print"  href="<%= Page.ResolveUrl("~/GUI/Modulo8/MINUTA3.doc.pdf") %>"></a>
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

