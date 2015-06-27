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
    <asp:Label ID="LEstado" runat="server" Text="Label"></asp:Label>
</asp:Content>
