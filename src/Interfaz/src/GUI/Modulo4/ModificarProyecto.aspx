<%@ Page Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ModificarProyecto.aspx.cs" Inherits="GUI_Modulo4_ModificarProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
	<link href="bootstrap-toggle-master/css/bootstrap-toggle.css" rel="stylesheet">
    <style>
        textarea {
            resize: none;
        }
    </style>
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
                <asp:Literal runat="server" id="nombreProy"></asp:Literal>
				<%--<input type="text" runat="server" id="nombreProy" placeholder="Nombre" class="form-control" value="" name="nombre"/>--%>
			</div>
		    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
                <asp:Literal runat="server" id="codigoProy"></asp:Literal>
				<%--<input type="text" runat="server" id="codigoProy" placeholder="Codigo" class="form-control" value="" name="codigo"/>--%>
			</div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
                    <asp:Literal runat="server" id="descripcionProy"></asp:Literal>
		            <%--<textarea placeholder="Descripcion" runat="server" id="descripcionProy" class="form-control" name="descripcion" rows="5"></textarea>--%>
		        </div>
	        </div>
            <label>Moneda</label>
            <div class="form-group">
                <div class="col-sm-1 col-md-1 col-lg-1">
                      <div class="dropdown">
                          <button runat="server" id="monedaProy" class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
                            &#164;
                            <span class="caret"></span>
                          </button>
                          <ul id="currencyProy" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                            <li role="presentation"><a role="menuitem" tabindex="-1" >Bs</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" >$</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" >€</a></li>
                          </ul>
                    </div>
                </div>
                <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                    <asp:Literal runat="server" id="precioProy"></asp:Literal>
                    <%--<input type="text" runat="server" id="precioProy" placeholder="Precio" value="" class="form-control" name="precio"/>--%>
                </div>
                
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3">
                    <input checked data-toggle="toggle" data-size="normal" type="checkbox" data-on="Activo" data-off="Inactivo" data-onstyle="success" data-offstyle="warning" data-width="100">
                </div>
	        </div>
            <br>
            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <button runat="Server" type="submit" class="btn btn-primary" onserverclick="ModifyProject_Click">Modificar</button>
			    </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    &nbsp;&nbsp;&nbsp;&nbsp;
				    <a id="btn-eliminar" type="button" class="btn btn-default" href="javascript:history.back()">Cancelar</a>
			    </div>
	        </div>
        </form>
    </div>

    <script src="js/Validacion.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/8.3/highlight.min.js"></script>
	<script src="bootstrap-toggle-master/doc/script.js"></script>
	<script src="bootstrap-toggle-master/js/bootstrap-toggle.js"></script>
	<script>
	    (function (i, s, o, g, r, a, m) {
	        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
	            (i[r].q = i[r].q || []).push(arguments)
	        }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
	    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
	    ga('create', 'UA-55669452-1', 'auto');
	    ga('send', 'pageview');
	</script>

    <script type="text/javascript">
        $("#dpmoneda li a").click(function () {

            $("#id-moneda").html($(this).text() + ' <span class="caret"></span>');

        });
        function goBack() {
            window.history.back();
        }
    </script>

</asp:Content>