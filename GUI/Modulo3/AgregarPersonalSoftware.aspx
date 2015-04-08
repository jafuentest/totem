<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarPersonalSoftware.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
              <div class="row">
              	 <form class="form-horizontal" action="" method="POST" role="form" runat="server">
                    <div class="page-header">
                        <h4>Agregar Empleado de la Empresa de Softwae a Proyecto</h4>
                    </div>
                       <div class="col-sm-12">
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Proyecto:</label>
                             <div class="col-sm-4">
                                 <select name="proyecto" id="id_proyecto" class="form-control input-sm" required="required">
                                     <option Value="0">Selecionar...</option>
                                     <option Value="1">Acuario</option>
                                     <option Value="2">Biblioteca</option>
                                     <option Value="3">Anime y Manga</option>
                                 </select>
                                 <a id="error1"></a>
                            </div>
                        </div>
                        </div>
                       <div class="col-sm-12">
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Personal:</label>
                               <div class="col-sm-4">
                                 <select name="personal" id="id_personal" class="form-control input-sm" required="required">
                                     <option value="0">Selecionar...</option>
                                     <option value="1">Argenis Rodriguez</option>
                                     <option value="2">Scheryl Palencia</option>
                                     <option value="3">Rosa Rodriguez</option>
                                     <option value="4">Akira Toriyama</option>
                                 </select>
                                   <a id="error2"></a>
                              </div>
                        </div>
                        </div>
                       <div class="col-sm-12">
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Rol del personal:</label>
                              <div class="col-sm-4">
                                 <select name="rol" id="id_rol" class="form-control input-sm" required="required">
                                     <option Value="0" Selected="True">Selecionar...</option>
                                     <option Value="1">Lider del Proyecto</option>
                                     <option Value="2">Analista</option>
                                     <option Value="3">Programador</option>
                                 </select>
                                  <a id="error3"></a>
                             </div>
                        </div>
                       </div>
                       <div class="col-sm-12" >     
                           <div class="col-sm-5 col-sm-offset-4">
                              <button type="submit" class="btn btn-primary" OnClick="return validar();">Aceptar</button>
                              <button type="submit" class="btn btn-primary">Cancelar</button>
                           </div>
                       </div>
                 </form>
              </div>
    <script lenguaje="javascript" type="text/javascript">
        function validar() {
            var proyecto_seleccionado = $("#id_proyecto").val();
            var personal_seleccionado = $("#id_personal").val();
            
            var rol_seleccionado = $("#id_rol").val();
            $("#error1").text("");
            $("#error2").text("");
            $("#error3").text("");
            if ((proyecto_seleccionado == 0) || (personal_seleccionado == 0) || (rol_seleccionado == 0)) {
                if (proyecto_seleccionado == 0)
                    $("#error1").text("No seleccionastes el proyecto");
                if (personal_seleccionado == 0)
                    $("#error2").text("No seleccionastes el personal");
                if (rol_seleccionado == 0)
                    $("#error3").text("No seleccionastes el rol");
               return false;
            }else{
               return confirm('Seguro de que deseas asignar a este empleado');
            }
        }
    </script>
</asp:Content>





