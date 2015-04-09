<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_login.aspx.cs" Inherits="login" %>

<%-- Agregue aquí los controles de contenido --%>

<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Inicio de Sesión
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <body>
    
                <div  class="login-form">
                    <form id="login_form" class="form-horizontal" method="POST">
                  <div id="login-form-name" class="form-group">
                    <input type="text" class="form-control login-field" value="" placeholder="Ingrese nombre de usuario" id="login-name" name="usuario" />
                  </div>

                  <div id="login-form-pass" class="form-group">
                    <input type="password" class="form-control login-field" value="" placeholder="Contrase&ntilde;a" id="login-pass" name="password"/>
                  </div>
                  <a class="btn btn-primary " href="#">Iniciar de Sesi&oacute;n</a>
                    <br />
                    
                  <a class="login-link" href="M1_IntroducirCorreo.aspx">¿Olvid&oacute; su contrase&ntilde;a?</a>
                    </br>
                    <a class="login-link" href="../Modulo7/Registro.aspx">Regístrese</a>
                
              </form>
             </div>
        

    </body>
    
</asp:Content>


      

