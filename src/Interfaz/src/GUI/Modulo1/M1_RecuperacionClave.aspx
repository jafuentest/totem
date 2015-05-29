<%@ Page Title="" Language="C#" MasterPageFile="~/src/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="M1_RecuperacionClave.aspx.cs" Inherits="M1_RecuperacionClave" %>
<%@ MasterType TypeName="MasterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" Runat="Server">
    Recuperación de Clave
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subtitulo" Runat="Server">
    Nueva Contraseña
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div id="serverAlert" runat="server"></div>
   <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
       <div id="alerta"></div>
       
            <form id="recuperarClave" class="form-horizontal"  method="post" runat="server">

                <div  class="cambio_clave"> 
                   

                  <div runat="server" id="pswd_nuevo" class="form-group">
                      <label>Nueva Contraseña:</label>
                     <input type="password" class="form-control" style="width:70%;" 
                         value="" placeholder="Introduzca nueva clave" id="input_clave" runat="server"
                         name="claveNueva" />
                  </div>

                    <div runat="server" id="pswd_confirmacion" class="form-group">
                        <label>Confirme Nueva Contraseña:</label>
                        <input type="password" class="form-control" style="width:70%;" 
                            value="" placeholder="Confirme la nueva clave" id="input_clave_confs" 
                           runat="server" name="confirmaClaveNueva" />
                    </div>


                  <div class="form-group">
		               <div class="form-group">
                         &nbsp; &nbsp;
				            <button class="btn btn-primary" id="btn_Confirmar" type="submit" runat="server" 
                                onserverclick="btn_Confirmar_ServerClick" >Continuar</button>
                        &nbsp;
				            <a class="btn btn-default" href="M1_login.aspx">Cancelar</a
                           <!-- cambiar para asegurar que el cookie se borre -->
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

