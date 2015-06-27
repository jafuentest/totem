<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListarProyectos.aspx.cs" Inherits="Vista.Modulo4.ListarProyectos" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" runat="server">
    Gestion de proyectos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" runat="server">
    Listar proyectos
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" runat="server">
    <asp:Label ID="LEstado" runat="server" Text=""></asp:Label>
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
