<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="IntroducirCorreo.aspx.cs" Inherits="Vista.Modulo1.IntroducirCorreo" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server"> 
    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
    <div id="alert" runat="server">
    </div>
        <form runat="server" class="form-horizontal" method="POST" >
            <div  class="login-form"> 
                <div id="login-form-name" class="form-group">
                    <label>Introduzca su correo:</label>
                    <input runat="server" id="input_correo" type="text" class="form-control login-field" style="width:70%;" value="" placeholder="ejemplo@dominio.com" name="correo" />
                </div>
                <div class="form-group">
		            <div class="form-group">
				        <button runat="server" class="btn btn-primary"  OnServerClick="Recuperar_Clave_Click" type="submit">Continuar</button>
                        <a class="btn btn-default" href="Login.aspx">Cancelar</a>
                    </div>  
                </div>
            </div>
        </form>
    </div>
</asp:Content>


