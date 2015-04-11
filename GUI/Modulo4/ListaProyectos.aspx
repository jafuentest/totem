<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListaProyectos.aspx.cs" Inherits="GUI_Modulo4_ListaProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="bootstrap-switch-master/docs/css/highlight.css" rel="stylesheet">
    <link href="bootstrap-switch-master/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet">
    <link href="bootstrap-switch-master/docs/css/main.css" rel="stylesheet">
    <style>
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
           <div class="col-sm-12 col-md-12 col-lg-12">
            <div class="input-group">
              <span class="input-group-btn">
                <button class="btn btn-default" type="button">Buscar</button>
              </span>
              <input type="text" class="form-control" placeholder="Buscar proyecto...">
            </div><!-- /input-group -->
          </div><!-- /.col-lg-6 -->
        </div>

        <div class="jumbotron col-sm-12 col-md-12 col-lg-12">
            <h2 class="sameLine"><a href="PerfilProyecto.aspx">Twitter</a></h2> <h5 class="sameLine">COD: TWI</h5>
            <p class="desc">Twitter (NYSE: TWTR) es un servicio de microblogging, con sede en San Francisco, California, con filiales en San Antonio (Texas) y Boston (Massachusetts) en Estados Unidos. Twitter, Inc. fue creado originalmente en California, pero está bajo la jurisdicción de Delaware desde 2007...</p>
            <input id="switch-disabled" type="checkbox" data-size="mini" data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" checked disabled>
            <p></p>
            <p>Cliente: <a href="#">Dick Costolo</a></p>
            <p>Desarroladora: <a href="#">Los Andes Coding</a></p>
        </div>

        <div class="jumbotron col-sm-12 col-md-12 col-lg-12">
            <h2 class="sameLine"><a href="#">Facebook</a></h2> <h5 class="sameLine">COD: FAC</h5>
            <p class="desc">Facebook (NASDAQ: FB) es un sitio web de redes sociales creado por Mark Zuckerberg y fundado junto a Eduardo Saverin, Chris Hughes y Dustin Moskovitz. Originalmente era un sitio para estudiantes de la Universidad de Harvard, pero se abrió a cualquier persona con una cuenta de correo electrónico.</p>
            <input id="switch-disabled1" type="checkbox" data-size="mini" data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" checked disabled>
            <p></p>
            <p>Empresa Cliente: <a href="#">Mark Zuckerberg</a></p>
            <p>Desarroladora: <a href="#">Venezuela Web Design</a></p>
        </div>

        <div class="jumbotron col-sm-12 col-md-12 col-lg-12">
            <h2 class="sameLine"><a href="#">Automatizacion de Facturacion Panaderia La Esquina</a></h2> <h5 class="sameLine">COD: AFP</h5>
            <p class="desc">No hay descripcion disponible...</p>
            <input id="switch-disabled2" type="checkbox" data-size="mini" data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" checked disabled>
            <p></p>
            <p>Cliente: <a href="#">Panaderia de La Esquina</a></p>
            <p>Desarrolladora: <a href="#">1Guy Company</a></p>
        </div>

    </div>

    <script src="bootstrap-switch-master/docs/js/jquery.min.js"></script>
    <script src="bootstrap-switch-master/docs/js/bootstrap.min.js"></script>
    <script src="bootstrap-switch-master/docs/js/highlight.js"></script>
    <script src="bootstrap-switch-master/dist/js/bootstrap-switch.js"></script>
    <script src="bootstrap-switch-master/docs/js/main.js"></script>

</asp:Content>
