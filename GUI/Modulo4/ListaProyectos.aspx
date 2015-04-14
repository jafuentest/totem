<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListaProyectos.aspx.cs" Inherits="GUI_Modulo4_ListaProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="bootstrap-switch-master/docs/css/highlight.css" rel="stylesheet">
    <link href="bootstrap-switch-master/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet">
    <link href="bootstrap-switch-master/docs/css/main.css" rel="stylesheet">
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
                    <input id="switch-disabled" type="checkbox" data-size="mini" data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" data-off-color="warning" checked disabled>
                    <br><br>
                    <p class="sameLine">Cliente: </p><p id="nombreCliente" class="sameLine bootstrapBlue">Carlo Magurno</p>
                    <br>
                    <p class="sameLine">Desarroladora: </p><p id="nombreDesarrolladora" class="sameLine bootstrapBlue">Grupo Desarrollo 2015</p>
                </div>

                <div class="jumbotron">
                    <h2 class="sameLine"><a href="#">Totem02</a></h2> <h5 class="sameLine">COD: </h5> <h5 id="H1" class="sameLine" runat="server">T02</h5>
                    <p class="desc">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pulvinar nisi, in dapibus leo. Aliquam ac gravida sem. Curabitur a aliquet tellus. Curabitur dui felis, luctus quis venenatis non, congue non nunc. Nam quis ipsum in dui egestas rutrum vel quis elit. Proin cursus lectus eget sem interdum tristique. Aliquam convallis elementum metus, eu hendrerit est aliquam vitae. Morbi suscipit sagittis venenatis. Etiam vehicula cursus convallis. Integer ultrices consequat dolor, hendrerit consectetur magna blandit eget. Curabitur nec vestibulum justo, lobortis mattis ipsum. Nullam enim est, placerat efficitur risus a, congue porttitor diam. Proin eget tortor dolor.</p>
                    <input id="switch-disabled1" type="checkbox" data-size="mini" data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" data-off-color="warning" unchecked disabled>
                    <br><br>
                    <p class="sameLine">Cliente: </p><p id="nombreCliente" class="sameLine bootstrapBlue">Carlo Magurno</p>
                    <br>
                    <p class="sameLine">Desarroladora: </p><p id="nombreDesarrolladora" class="sameLine bootstrapBlue">Grupo Desarrollo 2015</p>
                </div>

                <div class="jumbotron">
                    <h2 class="sameLine"><a href="#">Totem03</a></h2> <h5 class="sameLine">COD: </h5> <h5 id="H2" class="sameLine" runat="server">T03</h5>
                    <p class="desc">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent quis pulvinar nisi, in dapibus leo. Aliquam ac gravida sem. Curabitur a aliquet tellus. Curabitur dui felis, luctus quis venenatis non, congue non nunc. Nam quis ipsum in dui egestas rutrum vel quis elit. Proin cursus lectus eget sem interdum tristique. Aliquam convallis elementum metus, eu hendrerit est aliquam vitae. Morbi suscipit sagittis venenatis. Etiam vehicula cursus convallis. Integer ultrices consequat dolor, hendrerit consectetur magna blandit eget. Curabitur nec vestibulum justo, lobortis mattis ipsum. Nullam enim est, placerat efficitur risus a, congue porttitor diam. Proin eget tortor dolor.</p>
                    <input id="switch-disabled2" type="checkbox" data-size="mini" data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" data-off-color="warning" unchecked disabled>
                    <br><br>
                    <p class="sameLine">Cliente: </p><p id="nombreCliente" class="sameLine bootstrapBlue">Carlo Magurno</p>
                    <br>
                    <p class="sameLine">Desarroladora: </p><p id="nombreDesarrolladora" class="sameLine bootstrapBlue">Grupo Desarrollo 2015</p>
                </div>
            </div>
        </div>

    </div>

    <script src="bootstrap-switch-master/docs/js/jquery.min.js"></script>
    <script src="bootstrap-switch-master/docs/js/bootstrap.min.js"></script>
    <script src="bootstrap-switch-master/docs/js/highlight.js"></script>
    <script src="bootstrap-switch-master/dist/js/bootstrap-switch.js"></script>
    <script src="bootstrap-switch-master/docs/js/main.js"></script>

</asp:Content>
