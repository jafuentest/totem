<%@ Page Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteRequerimientos.aspx.cs" Inherits="Vista.Modulo5.ReporteRequerimientos" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Reporte de Requerimientos</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="alert" runat="server">
    </div>
    <br />
    <h4>Seleccione el tipo de requerimiento con el cual desea filtrar el reporte</h4>
    <div class="dropdown">
        <button class="btn btn-default dropdown-toggle" type="button" id="tipoid" data-toggle="dropdown" aria-expanded="true">
        Tipo de Requerimiento:
        <span class="caret"></span>
        </button>
        <ul id="tipo-dd" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
            <li id="funcionales" role="presentation"><a role="menuitem" tabindex="-1" href="#" >Requerimientos Funcionales</a></li>
            <li id="nofuncionales" role="presentation"><a role="menuitem" tabindex="-1" href="#" >Requerimientos No Funcionales</a></li>
        </ul>
    </div>
    <br />
    <br />
    <div class="table-responsive">
    <% //if ( ListaRequerimientos != null )
	  //{
		 %>
	   <asp:Repeater ID="RRequerimientos" runat="server">
		  <HeaderTemplate>
			 <table id="table-requerimientos"
				class="table table-striped table-hover">
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
		  </HeaderTemplate>
		  <ItemTemplate>
				<%
				   /*
				    * Evaluación de las propiedades pertenecientes
				    * a la clase Requerimiento
				    */
				%>
				<tr>
				    <td><%# Eval("Codigo") %></td>
				    <td><%# Eval("Descripcion") %></td>
				    <td><%# Eval("Tipo") %></td>
				    <td><%# Eval("Prioridad") %></td>
				    <td>
					   <a class="btn btn-default glyphicon glyphicon-pencil"
					   href="ModificarRequerimiento.aspx?id=<%# Eval("Codigo") %>&list=false"></a>
					   <a class="btn btn-danger glyphicon glyphicon-remove-sign"
					   href="ReporteRequerimientos.aspx?eliminar=<%# Eval("Codigo") %>&list=false"></a>
				    </td>
				</tr>
		  </ItemTemplate>
		  <FooterTemplate>
				</tbody>
			 </table>
		  </FooterTemplate>
	   </asp:Repeater>
    <% /*}
	  else
	  {
		 Response.Write("<p>" + MensajeEstado + "</p>");
	  }*/
	  %>
    </div> <!-- .table-responsive -->

    <form runat="server" method="post">
                <div class="col-lg-offset-10"\>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button id="GenerarDoc" class="btn btn-success" runat="server" OnClick="GenerarDoc_Click" Text="Generar Documento"></asp:Button>
                </div>
    </form>
         </div><!-- table-responsive -->
    <!-- Data tables init -->
<script type="text/javascript">
    var busqueda="init";
    var table;

    $.fn.dataTable.ext.search.push(
    function (settings, data, dataIndex) {
        return (data[2].toUpperCase() == busqueda)|| (busqueda == "init");
    });

    $(document).ready(function () {
        table = $('#table-requerimientos').DataTable();
        
    });

    $('#funcionales').click(function () {/*metodo para filtrar la tabla de requerimientos para que solo aparezcan los funcionales y
                                           activa el boton de generar documento*/
        busqueda = 'Funcional'.toUpperCase();
        table.draw();
    });
    $("#tipo-dd li a").click(function () {//agrega el texto del elemento del dropdown al titulo del mismo

        $("#tipoid").html($(this).text() + ' <span class="caret"></span>');

    });
    $('#nofuncionales').click(function () {/*metodo para filtrar la tabla de requerimientos para que solo aparezcan los no funcionales 
                                                 y activa el boton de generar documento*/
        busqueda = 'No Funcional'.toUpperCase();
        table.draw();
    });

	</script>
    
</asp:Content>

