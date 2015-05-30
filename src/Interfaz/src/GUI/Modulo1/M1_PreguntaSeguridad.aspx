<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_PreguntaSeguridad.aspx.cs" Inherits="M1_PreguntaSeguridad" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
   Pregunta de Seguridad
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">

    <div  class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <div id="serverAlert" runat="server">
        </div>
        <form id="preguntaSeguridad"  class="form-horizontal" method="post" runat="server">

                <div  class="login-form"> 
                    
                  <div id="login-form-name" class="form-group">
                      
                        <label runat="server" id="label_pregunta"></label>
                        <input type="text" class="form-control" style="width:70%;" value=""  
                            id="input_respuesta" name="respuestaSeguridad" runat="server"/>
                      
                  </div>

                  <div class="form-group">
		               <div class="form-group">
                         &nbsp; &nbsp;
				            <button runat="server" class="btn btn-primary" type="submit" 
                                id="btn_validar_respuesta" 
                                onserverclick="btn_validar_respuesta_ServerClick">Continuar</button>
                        &nbsp; 
				            <a class="btn btn-default" href="M1_login.aspx">Cancelar</a>
                       </div>  
                  </div>
                 </div>
              </form>
            </div>
        <script src="js/Login.js"></script>
    
</asp:Content>

