<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarEmpresa.aspx.cs" Inherits="GUI_Modulo2_AgregarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Agregar empresa
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-2">
        <form id="agregar_empresa" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="form-group">
                <h3>Datos básicos</h3>
                <div class="row">
                    <div id="div_rsocial" class="col-sm-1 col-md-1 col-lg-1" style="width: 10%;">
                        <asp:DropDownList ID="DD_RSocial" runat="server" CssClass="form-control rsocial"></asp:DropDownList>
                    </div>
                    <div id="div_rif" class="col-sm-4 col-md-4 col-lg-4" style="width: 31.7%">
                        <asp:TextBox ID="TB_RIF" runat="server" CssClass="form-control rif"></asp:TextBox>
                    </div>
                    &nbsp;
                    <div id="div_nombre" class="col-sm-5 col-md-5 col-lg-5">
                        <asp:TextBox ID="TB_Nombre" runat="server" CssClass="form-control nombre"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <h3>Datos de localización</h3>
                <div class="row">
                    <div id="div_pais" class="col-sm-5 col-md-5 col-lg-5">
                        <asp:DropDownList ID="DD_Pais" runat="server" CssClass="form-control pais"></asp:DropDownList>
                    </div>
                    &nbsp;
                    <div id="div_estado" class="col-sm-5 col-md-5 col-lg-5">
                        <asp:DropDownList ID="DD_Estado" runat="server" CssClass="form-control pais"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div id="div_direccion" class="col-sm-10 col-md-10 col-lg-10">
                        <asp:TextBox ID="TB_Direccion" runat="server" CssClass="form-control direccion"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <div class="row">
                    <div id="div_cpostal" class="col-sm-5 col-md-5 col-lg-5">
                        <asp:TextBox ID="TB_CPostal" runat="server" CssClass="form-control direccion"></asp:TextBox>
                    </div>
                    &nbsp;
                    <div id="div_telefono" class="col-sm-5 col-md-5 col-lg-5">
                        <asp:TextBox ID="TB_Telefono" runat="server" CssClass="form-control direccion"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <button class="btn btn-primary">Registrar</button>
            </div>

        </form>
    </div>

</asp:Content>

