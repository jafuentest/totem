<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_PreguntaSeguridad.aspx.cs" Inherits="M1_PreguntaSeguridad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
   Pregunta de Seguridad
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <body>
    <form id="login" action="php/inicioSesion.php" method="POST" >

                <div  class="login-form"> 
                    
                  <div id="login-form-name" class="form-group">
                    <input type="password" class="form-control >login-field" value="" placeholder="Apellido materno del padre" id="login-name" name="respuestaSeguridad" />
                  </div>
                  <a class="btn btn-primary " href="M1_RecuperacionClave.aspx">Continuar</a>

                  <a class="btn btn-primary " href="M1_login.aspx">Cancelar</a>
                  
                </div>
              </form>

    </body>
</asp:Content>

