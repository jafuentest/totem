<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_IntroducirCorreo.aspx.cs" Inherits="M1_IntroducirCorreo" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
   Ingrese Correo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    
    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="alerta" >
                </div>
    <form id="ingresoCorreo" class="form-horizontal" method="post" action="https://mail.google.com/mail/u/0/#inbox">

                <div  class="login-form"> 
                    
                  <div id="login-form-name" class="form-group">
                    <label>Introduzca su correo:</label>
                    <input type="text" class="form-control login-field" style="width:70%;" value="" placeholder="ejemplo@dominio.com" id="login-name" name="correo" />
                  </div>
                  <div class="form-group">
		               <div class="form-group">
                         &nbsp; &nbsp;
				            <button class="btn btn-primary" id="btn-Enviar" type="submit" onclick="return checkform()">Continuar</button>
                        &nbsp;
				            <a class="btn btn-default" href="M1_login.aspx">Cancelar</a>
                       </div>  
                  </div>
                  
                </div>
              </form>
        </div>

    <script src="js/Login.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btn-Enviar').on('click', function () {
                $('#alerta').addClass("alert alert-success alert-dismissible");
                $('#alerta').text("Se ha enviado un link al correo, verifique para poder recuperar su clave");
            });
        });

    </script>
   
</asp:Content>

