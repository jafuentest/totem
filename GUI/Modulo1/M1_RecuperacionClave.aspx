<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_RecuperacionClave.aspx.cs" Inherits="M1_RecuperacionClave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
    Nueva Contraseña
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <body>
    <form id="login">

                <div  class="login-form"> 
                   

                  <div id="login-form-name1" class="form-group">
                    <input type="password" class="form-control login-field" value="" placeholder="Introduzca nueva clave" id="login-name" name="claveNueva" />
                  </div>

                    <div id="login-form-name" class="form-group">
                    <input type="password" class="form-control login-field" value="" placeholder="Confirme la nueva clave" id="login-name" name="confirmaClaveNueva" />
                  </div>
                  <a class="btn btn-primary " href="M1_login.aspx">Enviar</a>

                  <a class="btn btn-primary " href="#">Cancelar</a>
                  
                </div>
              </form>

    </body>

</asp:Content>

