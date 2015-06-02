<%@ Page Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarProyecto.aspx.cs" Inherits="GUI_Modulo4_ModificarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="css/Modulo4.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Modificar</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">

    <div class="form-group">
            <div id="div_alertas" class="col-sm-12 col-md-12 col-lg-12">
                <div id="alerts" runat="server">
                </div>
            </div>
        </div>

    <form runat="server" class="form-horizontal" method="POST">
        <div class="form-group">

            <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				<input type="text" runat="server" id="nombreProy" placeholder="Nombre" class="form-control" value="" name="nombre"/>
			</div>
		    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				<input type="text" runat="server" id="codigoProy" placeholder="Codigo" class="form-control" value="" name="codigo" disabled/>
			</div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea placeholder="Descripcion" runat="server" id="descripcionProy" class="form-control" name="descripcion" rows="5"></textarea>
		        </div>
	        </div>
            <label>Moneda</label>
            <div class="form-group">
                <div class="col-sm-1 col-md-1 col-lg-1">
                    <asp:DropDownList id="comboMoneda"  class="btn btn-default dropdown-toggle" runat="server">
                    </asp:DropDownList>
                </div>
                <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                    <input type="text" runat="server" id="precioProy" placeholder="Precio" value="" class="form-control" name="precio"/>
                </div>
                
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3">
                    <asp:checkbox runat="server" id="csEstado" AutoPostBack="true" Text="" Enabled="true"/>
                </div>
	        </div>
            <br>
            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <button runat="Server" type="submit" class="btn btn-primary" onserverclick="ModifyProject">Modificar</button>
			    </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    &nbsp;&nbsp;&nbsp;&nbsp;
				    <a id="btn-eliminar" type="button" class="btn btn-default" href="javascript:history.back()">Cancelar</a>
			    </div>
	        </div>
        </form>
    </div>

    <script src="js/Validacion.js"></script>

    <script type="text/javascript">
        $("#monedaProy li a").click(function () {
            $("#monedaProy").html($(this).text() + ' <span class="caret"></span>');
        });
        function goBack() {
            window.history.back();
        }
    </script>

</asp:Content>