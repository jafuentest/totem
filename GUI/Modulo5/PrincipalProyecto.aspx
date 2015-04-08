<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="PrincipalProyecto.aspx.cs" Inherits="GUI_Modulo5_PrincipalProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos<br /></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Lista de Requerimiento</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">    
    <div class="panel panel-primary" style="width:auto">
      <div class="panel-heading">
        <h3 class="panel-title" style="align-content:center">Proyecto</h3>
      </div>
      <div class="panel-body" style="width:">
          Nombre del Proyecto: TOTEM<br />
          Empresa Cliente: UCAB<br />
          Status del Proyecto: Activo<br />
      </div>
    </div>
    <br/>
    <h2 style="align-content:center">Requerimientos Asociados</h2>
    <div class="table-responsive">
	    		<table id="table-example" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th style="width: 530px">Requerimiento</th>
					<th>Tipo</th>
					<th style="width: 50px">Prioridad</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>TOT_RF_5_1</td>
					<td>El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=1") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=1") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>TOT_RF_5_2</td>
					<td>El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=2") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=2") %>">Eliminar</a>
                    </td>
				</tr><tr>
                    <td>TOT_RF_5_3</td>
					<td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=3") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=3") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                    <td>TOT_RF_5_4</td>
					<td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=4") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=4") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                <td>TOT_RF_5_5</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=5") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=5") %>">Eliminar</a>
                    </td>
                </tr>
                <tr>
                <td>TOT_RF_5_6</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td>Funcional</td>
					<td>Alta</td>
                    <td>
                        <a class="btn btn-default" href="<%= Page.ResolveUrl("~/GUI/Modulo5/ModificarRequerimiento.aspx?id=6") %>">Modificar</a>
                        <a class="btn btn-danger " href="<%= Page.ResolveUrl("~/GUI/Modulo5/PrincipalProyecto.aspx?id=6") %>">Eliminar</a>

                    </td>
                </tr>
			</tbody>
		</table>
    </div>
    <!-- Data tables init -->
	<script type="text/javascript">
	    jQuery(function ($) {
	        $('#table-example').DataTable();
	    });
	</script>
</asp:Content>

