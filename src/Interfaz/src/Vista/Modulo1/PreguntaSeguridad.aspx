<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="PreguntaSeguridad.aspx.cs" Inherits="Vista.Modulo1.PreguntaSeguridad" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Pregunta de Seguridad
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alert" runat="server">
        </div>
        <form runat="server" class="form-horizontal" method="post">
            <div  class="login-form"> 
                <div id="login-form-name" class="form-group">
                    <label runat="server" id="label_pregunta"></label>
                    <input runat="server" type="text" class="form-control" maxlength="60" value=""  placeholder="" id="input_respuesta" name="respuestaSeguridad" />  
                </div>
                <div class="form-group">
		            <div class="form-group">
				        <button runat="server" class="btn btn-primary" type="submit" OnServerClick="Validar_Pregunta_Click">Continuar</button>
				        <a class="btn btn-default" href="Login.aspx">Cancelar</a>
                    </div>  
                </div>
            </div>
        </form>
    </div> 
</asp:Content>

