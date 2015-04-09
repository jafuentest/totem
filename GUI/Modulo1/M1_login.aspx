<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_login.aspx.cs" Inherits="login" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Inicio de Sesión
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    
                <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
                   <form id="login" class="form-horizontal">

                    <div id="login-form-name" class="form-group">
                            <input type="text" class="form-control login-field" value="" placeholder="Ingrese nombre de usuario" id="login-name" name="usuario" />
                    </div>

                    <div id="login-form-pass" class="form-group">
                             <input type="password" class="form-control login-field" value="" placeholder="Contrase&ntilde;a" id="login-pass" name="password"/>
                    </div>

                    <div id="botones" class ="form-group">
                            <button class="btn btn-primary "  type="submit" onclick="return checkform()">Iniciar de Sesi&oacute;n</button>
                    <br />
                                            
                    <a class="login-link" href="M1_IntroducirCorreo.aspx">¿Olvid&oacute; su contrase&ntilde;a?</a>
                    
                    </div>
                   </form>                    
             </div>
    
        <script src="js/Login.js"></script>

    
    
</asp:Content>


      

