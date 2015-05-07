﻿<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_PreguntaSeguridad.aspx.cs" Inherits="M1_PreguntaSeguridad" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
   Pregunta de Seguridad
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <form id="preguntaSeguridad"  class="form-horizontal" method="post" action="M1_RecuperacionClave.aspx">

                <div  class="login-form"> 
                    
                  <div id="login-form-name" class="form-group">
                      
                        <label>¿Cu&aacute;l es al apellido materno del padre?</label>
                        <input type="text" class="form-control >login-field" style="width:70%;" value=""  placeholder="Apellido materno del padre" id="login-name" name="respuestaSeguridad" />
                      
                  </div>

                  <div class="form-group">
		               <div class="form-group">
                         &nbsp; &nbsp;
				            <button class="btn btn-primary" type="submit" onclick="return checkform()">Continuar</button>
                        &nbsp; 
				            <a class="btn btn-default" href="M1_login.aspx">Cancelar</a>
                       </div>  
                  </div>
                 </div>
              </form>
            </div>
        <script src="js/Login.js"></script>
    
</asp:Content>

