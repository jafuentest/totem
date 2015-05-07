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
    <form id="register_form" class="form-horizontal" action="#">
        <div class="form-group">

            <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				<input type="text" placeholder="Nombre" class="form-control" value="Twitter" name="nombre"/>
			</div>
		    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				<input type="text" placeholder="Codigo" class="form-control" value="TWI" name="codigo"/>
			</div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea placeholder="Descripcion" class="form-control" name="descripcion" rows="5">Twitter (NYSE: TWTR) es un servicio de microblogging, con sede en San Francisco, California, con filiales en San Antonio (Texas) y Boston (Massachusetts) en Estados Unidos. Twitter, Inc. fue creado originalmente en California, pero está bajo la jurisdicción de Delaware desde 2007.8 Desde que Jack Dorsey lo creó en marzo de 2006, y lo lanzó en julio del mismo año, la red ha ganado popularidad mundialmente y se estima que tiene más de 500 millones de usuarios, generando 65 millones de tuits al día y maneja más de 800 000 peticiones de búsqueda diarias.1 Ha sido apodado como el "SMS de Internet".9</textarea>
		        </div>
	        </div>
            <label>Moneda</label>
            <div class="form-group">
                <div class="col-sm-1 col-md-1 col-lg-1">
                      <div class="dropdown">
                          <button id="id-moneda" class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown" aria-expanded="true">
                            &#164;
                            <span class="caret"></span>
                          </button>
                          <ul id="dpmoneda" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                            <li role="presentation"><a role="menuitem" tabindex="-1" >Bs</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" >$</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" >€</a></li>
                          </ul>
                    </div>
                </div>
                <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                       <input type="text" id="Precio" placeholder="Precio" value="200000000" class="form-control" name="precio"/>
                </div>
                
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3">
                    <input checked data-toggle="toggle" data-size="normal" type="checkbox" data-on="Activo" data-off="Inactivo" data-onstyle="success" data-offstyle="warning" data-width="100">
                </div>
	        </div>
            <br>
            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <a id="btn-modificar" type="button" class="btn btn-primary" href="PerfilProyecto.aspx?success=0">Modificar</a>
			    </div>
                <div class="col-sm-3 col-md-3 col-lg-3">
                    &nbsp;&nbsp;&nbsp;&nbsp;
				    <a id="btn-eliminar" type="button" class="btn btn-default" href="PerfilProyecto.aspx">Cancelar</a>
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