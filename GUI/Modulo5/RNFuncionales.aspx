<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="RNFuncionales.aspx.cs" Inherits="GUI_Modulo5_RNFuncionalesID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos<br /></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Reporte de Requerimientos No Funcionales Organizada por ID</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-lg-offset-11">
        <button class="btn btn-default">Imprimir</button>
    </div>
    <br />
    <div class="col-lg-12">
    <div class="table-responsive">
	    		<table id="table-example" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th>Requerimiento</th>
					<th>Tipo</th>
					<th>Prioridad</th>
				</tr>
			</thead>
			<tbody>
				<tr>
                    <td>TOT_RNF_1</td>
					<td>El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                </tr>
                <tr>
                    <td>TOT_RNF_2</td>
					<td>El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                </tr>
                <tr>
                <td>TOT_RNF_3</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                </tr>
                <tr>
                <td>TOT_RNF_4</td>
					<td>El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td>No Funcional</td>
					<td>Alta</td>
                </tr>
			</tbody>
		</table>
        <!-- Data tables init -->
	    <script type="text/javascript">
	        jQuery(function ($) {
	            $('#table-example').DataTable();
	        });
	    </script>
        </div>
        </div>
</asp:Content>

