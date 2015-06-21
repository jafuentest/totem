<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecuperacionClave.aspx.cs" Inherits="Vista.Modulo1.RecuperacionClave" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Nueva Contraseña
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat="server"></div>
            <form class="form-horizontal"  method="post" runat="server">
                <div  class="cambio_clave">
                     
                    <div runat="server" id="pswd_nuevo" class="form-group">
                        <label>Nueva Contraseña:</label>
                        <input type="password" class="form-control" value="" placeholder="Introduzca nueva clave" id="input_clave" runat="server" name="claveNueva" />
                    </div>

                    <div runat="server" id="pswd_confirmacion" class="form-group">
                        <label>Confirme Nueva Contraseña:</label>
                        <input type="password" class="form-control" value="" placeholder="Confirme la nueva clave" id="input_clave_confs" runat="server" name="confirmaClaveNueva" />
                    </div>

                    <div class="form-group">
                        <button class="btn btn-primary" id="btn_Confirmar" type="submit" runat="server" onserverclick="btn_Confirmar_ServerClick" >Continuar</button>
				        <a class="btn btn-default" href="Login.aspx">Cancelar</a>
                  </div>
                  
                </div>
              </form>
   
        </div>
</asp:Content>

