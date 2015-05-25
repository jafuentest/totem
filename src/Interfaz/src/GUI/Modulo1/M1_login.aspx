<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_login.aspx.cs" Inherits="login" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<%@ MasterType TypeName="MasterPage" %>
<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Inicio de Sesión
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">
                <div id="alert" runat="server">
                </div>
                <div id="alertlocal" >
                </div>
                <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
                   <form runat="server" class="form-horizontal" method="POST" >

                    <div id="login-form-name" class="form-group">
                        <div class ="col-sm-7 col-md-7 col-lg-7">
                            <label>Nombre de Usuario:</label>
                            <input runat="server" type="text" class="form-control login-field" style="width:100%;" value="" placeholder="Ingrese nombre de usuario" name="usuario" id="input_usuario"/>
                        </div>
                    </div>

                    <div id="login-form-pass" class="form-group">
                         <div class ="col-sm-7 col-md-7 col-lg-7">
                            <label>Contraseña:</label>
                             <input runat="server" type="password" class="form-control login-field" style="width:100%;" value="" placeholder="Contrase&ntilde;a" name="password" id="input_pswd"/>
                    
                         </div>
                    </div>
                    <div id="captchaContainer" runat="server" class="col-lg-6 col-md-6 col-sm-6 col-xs-10 col-lg-offset-1 col-md-offset-1 col-sm-offset-1 col-xs-offset-1 text-center">
                          
                       <!--  <recaptcha:RecaptchaControl  ID="recaptcha" runat="server"  PublicKey="6Ld4WAcTAAAAAKRhx_AOO24ZKYQEHByFgNPmPaJs"   PrivateKey="6Ld4WAcTAAAAAAgYhmDJEUtoht8OIP4Rk8ecxoUs" /> -->
                    </div>
                    <div id="botones" class ="form-group">
                        <div class ="col-sm-10 col-md-10 col-lg-10">
                            <button runat="server" class="btn btn-primary "  style="width:68%;" type="submit" onserverclick="Login_Click">Iniciar Sesi&oacute;n</button>
                    <br />
                                                              
                        <a class="login-link" href="M1_IntroducirCorreo.aspx" style="margin-left:19%; margin-top:20px;">¿Olvid&oacute; su contrase&ntilde;a?</a>
                        </div>
                    </div>
                   </form>                    
             </div>
    
        <script src="js/Login.js"></script>

    
    
</asp:Content>


      

