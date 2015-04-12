<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultarMinuta.aspx.cs" Inherits="GUI_Modulo8_ConsultarMinuta" %>
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
                            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>">Detalle</a>
                            <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=1") %>">Modificar</a>
                        </td>
                    </tr>
                    <tr>
                        <td>Min_02</td>
                        <td>sjkdnfsnd</td>
                        <td>sdnsnd</td>
                        <td>akfsjdf</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>">Detalle</a>
                            <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=2") %>">Modificar</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Min_03</td>
                        <td>sjkdn</td>
                        <td>sdnjjdfsnd</td>
                        <td>akfznx</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>">Detalle</a>
                            <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=3") %>">Modificar</a>

                        </td>
                    </tr>
                           <tr>
                        <td>Min_04</td>
                        <td>sadddn</td>
                        <td>aaaa</td>
                        <td>mmmd</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>">Detalle</a>
                            <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=4") %>">Modificar</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Min_05</td>
                        <td>shhhhn</td>
                        <td>124233gdf</td>
                        <td>jsdhhhdd</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>">Detalle</a>
                            <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=5") %>">Modificar</a>

                        </td>
                    </tr>
                    <tr>
                        <td>Min_06</td>
                        <td>sjkdn</td>
                        <td>ssnd</td>
                        <td>aznx</td>
                        <td>Activo</td>
                        <td>
                            <a class="btn btn-primary" href="<%= Page.ResolveUrl("~/GUI/Modulo8/DetalleMinutas.aspx") %>">Detalle</a>
                            <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo8/ModificarMinuta.aspx?id=6") %>">Modificar</a>

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

