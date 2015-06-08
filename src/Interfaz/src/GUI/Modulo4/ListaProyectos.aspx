<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ListaProyectos.aspx.cs" Inherits="GUI_Modulo4_ListaProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="css/build.css"/>
    <link rel="stylesheet" href="css/Modulo4.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Lista</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div>
        <form runat="server" class="form-horizontal" method="POST">
            <div class="col-sm-7 col-md-7 col-lg-7 col-md-offset-1">
                <asp:TextBox id="tbBusqueda" runat="server" placeholder="Buscar..." class="form-control" style="display: inline"></asp:TextBox>
            </div>
            <div class="col-sm-2 col-md-2 col-lg-2">    
                <asp:DropDownList id="comboFiltro"  class="btn btn-default dropdown-toggle" runat="server" style="display: inline">
                </asp:DropDownList>
            </div>
            <div class="col-sm-1 col-md-1 col-lg-1">
                <button runat="Server" type="submit" class="btn btn-primary" onserverclick="BuscarProyectos">Buscar</button>   
            </div>
        
            <br><br><br>
            <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
                <asp:Literal runat="server" ID="jumbotronProyecto"></asp:Literal>
            </div>
        </form>
    </div>
</asp:Content>
