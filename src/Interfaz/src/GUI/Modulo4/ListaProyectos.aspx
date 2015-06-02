<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListaProyectos.aspx.cs" Inherits="GUI_Modulo4_ListaProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="css/build.css"/>
    <link rel="stylesheet" href="css/Modulo4.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Lista</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <asp:Literal runat="server" ID="jumbotronProyecto"></asp:Literal>
    </div>
    <script type="text/javascript">
        $("#dpmoneda li a").click(function () {

            $("#id-moneda").html($(this).text() + ' <span class="caret"></span>');

        });
        function goBack() {
            window.history.back();
        }
    </script>
</asp:Content>
