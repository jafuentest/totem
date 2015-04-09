<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_IntroducirCorreo.aspx.cs" Inherits="M1_IntroducirCorreo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
   Ingrese Correo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <body>
    <form id="login" >

                <div  class="login-form"> 
                    
                  <div id="login-form-name" class="form-group">
                    <input type="text" class="form-control login-field" value="" placeholder="Introduzca su Correo" id="login-name" name="correo" />
                  </div>
                  <a class="btn btn-primary " href="M1_PreguntaSeguridad.aspx">Continuar</a>

                  <a class="btn btn-primary " href="M1_login.aspx">Cancelar</a>
                  
                </div>
              </form>

    </body>
</asp:Content>

