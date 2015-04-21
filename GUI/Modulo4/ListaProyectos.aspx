<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListaProyectos.aspx.cs" Inherits="GUI_Modulo4_ListaProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css" rel="stylesheet">
	<link href="bootstrap-toggle-master/css/bootstrap-toggle.css" rel="stylesheet">
    <style>
        .bootstrapBlue {
            color: #337ab7;
        }
        .sameLine {
            display: inline;
        }
        .desc {
            font-style: italic;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Lista</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">

        <div class="form-group">
            <div id="div_buscar" class="col-sm-12 col-md-12 col-lg-12">
                <div class="row">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Buscar proyecto...">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button">Buscar</button>
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <br><br>

        <div class="form-group">
            <div id="div_perfiles" class="col-sm-12 col-md-12 col-lg-12">
                <div class="jumbotron">
                    <h2 class="sameLine"><a href="PerfilProyecto.aspx">Totem1</a></h2> <h5 class="sameLine">COD: </h5> <h5 id="codigoProyecto" class="sameLine" runat="server">T01</h5>
                    <p class="desc">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pulvinar nisi, in dapibus leo. Aliquam ac gravida sem. Curabitur a aliquet tellus. Curabitur dui felis, luctus quis venenatis non, congue non nunc. Nam quis ipsum in dui egestas rutrum vel quis elit. Proin cursus lectus eget sem interdum tristique. Aliquam convallis elementum metus, eu hendrerit est aliquam vitae. Morbi suscipit sagittis venenatis. Etiam vehicula cursus convallis. Integer ultrices consequat dolor, hendrerit consectetur magna blandit eget. Curabitur nec vestibulum justo, lobortis mattis ipsum. Nullam enim est, placerat efficitur risus a, congue porttitor diam. Proin eget tortor dolor.</p>
                    <input disabled checked data-toggle="toggle" data-size="small" type="checkbox" data-on="Activo" data-off="Inactivo" data-onstyle="success" data-offstyle="warning" data-width="100">
                    <br><br>
                    <p class="sameLine">Cliente: </p><p id="nombreCliente" class="sameLine bootstrapBlue">Carlo Magurno</p>
                    <br>
                    <p class="sameLine">Desarroladora: </p><p id="nombreDesarrolladora" class="sameLine bootstrapBlue">Grupo Desarrollo 2015</p>
                </div>

                <div class="jumbotron">
                    <h2 class="sameLine"><a href="#">Totem02</a></h2> <h5 class="sameLine">COD: </h5> <h5 id="H1" class="sameLine" runat="server">T02</h5>
                    <p class="desc">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pulvinar nisi, in dapibus leo. Aliquam ac gravida sem. Curabitur a aliquet tellus. Curabitur dui felis, luctus quis venenatis non, congue non nunc. Nam quis ipsum in dui egestas rutrum vel quis elit. Proin cursus lectus eget sem interdum tristique. Aliquam convallis elementum metus, eu hendrerit est aliquam vitae. Morbi suscipit sagittis venenatis. Etiam vehicula cursus convallis. Integer ultrices consequat dolor, hendrerit consectetur magna blandit eget. Curabitur nec vestibulum justo, lobortis mattis ipsum. Nullam enim est, placerat efficitur risus a, congue porttitor diam. Proin eget tortor dolor.</p>
                    <input disabled unchecked data-toggle="toggle" data-size="small" type="checkbox" data-on="Activo" data-off="Inactivo" data-onstyle="success" data-offstyle="warning" data-width="100">
                    <br><br>
                    <p class="sameLine">Cliente: </p><p id="nombreCliente" class="sameLine bootstrapBlue">Carlo Magurno</p>
                    <br>
                    <p class="sameLine">Desarroladora: </p><p id="nombreDesarrolladora" class="sameLine bootstrapBlue">Grupo Desarrollo 2015</p>
                </div>

                <div class="jumbotron">
                    <h2 class="sameLine"><a href="#">Totem03</a></h2> <h5 class="sameLine">COD: </h5> <h5 id="H2" class="sameLine" runat="server">T03</h5>
                    <p class="desc">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pulvinar nisi, in dapibus leo. Aliquam ac gravida sem. Curabitur a aliquet tellus. Curabitur dui felis, luctus quis venenatis non, congue non nunc. Nam quis ipsum in dui egestas rutrum vel quis elit. Proin cursus lectus eget sem interdum tristique. Aliquam convallis elementum metus, eu hendrerit est aliquam vitae. Morbi suscipit sagittis venenatis. Etiam vehicula cursus convallis. Integer ultrices consequat dolor, hendrerit consectetur magna blandit eget. Curabitur nec vestibulum justo, lobortis mattis ipsum. Nullam enim est, placerat efficitur risus a, congue porttitor diam. Proin eget tortor dolor.</p>
                    <input disabled unchecked data-toggle="toggle" data-size="small" type="checkbox" data-on="Activo" data-off="Inactivo" data-onstyle="success" data-offstyle="warning" data-width="100">
                    <br><br>
                    <p class="sameLine">Cliente: </p><p id="nombreCliente" class="sameLine bootstrapBlue">Carlo Magurno</p>
                    <br>
                    <p class="sameLine">Desarroladora: </p><p id="nombreDesarrolladora" class="sameLine bootstrapBlue">Grupo Desarrollo 2015</p>
                </div>
            </div>
        </div>

    </div>

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

</asp:Content>
