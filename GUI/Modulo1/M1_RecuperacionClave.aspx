<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_RecuperacionClave.aspx.cs" Inherits="M1_RecuperacionClave" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
    Nueva Contraseña
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">

   <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
       <div id="alerta"></div>
            <form id="recuperarClave" class="form-horizontal">

                <div  class="login-form"> 
                   

                  <div id="login-form-name1" class="form-group">
                      <label>Nueva Contraseña:</label>
                     <input type="password" class="form-control login-field" style="width:70%;" value="" placeholder="Introduzca nueva clave" id="login-name1" name="claveNueva" />
                  </div>

                    <div id="login-form-name" class="form-group">
                        <label>Confirme Nueva Contraseña:</label>
                        <input type="password" class="form-control login-field" style="width:70%;" value="" placeholder="Confirme la nueva clave" id="login-name2" name="confirmaClaveNueva" />
                    </div>


                  <div class="form-group">
		               <div class="form-group">
                         &nbsp; &nbsp;
				            <button class="btn btn-primary" id="btn-Confirmar" type="submit" onclick="return login()" >Continuar</button>
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
            $('#btn-Confirmar').on('click', function () {
                $('#alerta').addClass("alert alert-success alert-dismissible");
                $('#alerta').text("Se ha cambiado la contraseña éxitosamente");
            });
        });

    </script>

</asp:Content>

