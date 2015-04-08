<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="PerfilProyecto.aspx.cs" Inherits="GUI_Modulo4_PerfilProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Perfil</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="jumbotron col-sm-12 col-md-12 col-lg-12">
        <h2><a href="#">Twitter</a></h2>
        <p>Twitter (NYSE: TWTR) es un servicio de microblogging, con sede en San Francisco, California, con filiales en San Antonio (Texas) y Boston (Massachusetts) en Estados Unidos. Twitter, Inc. fue creado originalmente en California, pero está bajo la jurisdicción de Delaware desde 2007...</p>
        <p>Cliente: <a href="#">Dick Costolo</a></p>
        <p>Desarroladora: <a href="#">Los Andes Coding</a></p>
    </div>

    <div class="panel-group col-sm-12 col-md-12 col-lg-12" id="accordion" role="tablist">
        <div class="panel panel-default">
            <div class="panel-heagin" role="tab" id="heading1">
                <h3 class="panel-title">
                    <a href="#collapse1" data-toggle="collapse" data-parent="#accordion">
                        Prueba 1
                    </a>
                </h3>
            </div>
        </div>
    </div>
</asp:Content>