<%@ Page Title="" Language="C#" MasterPageFile="../Master/MasterPage.master" AutoEventWireup="true" CodeFile="QuitarPersonalSoftware.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
      <div class="col-sm-12">
              	 <form class="form-horizontal" action="" method="POST" role="form" runat="server">
                    <legend>Quitar Empleado de Empresa de Software a Proyecto</legend>
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Proyecto:</label>
                             <div class="col-sm-4">
                                 <asp:DropDownList name="proyecto" id="id_proyecto" class="form-control" required="required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="proyecto_SelectedIndexChanged">
                                     <asp:ListItem Value="0" Selected="True">Selecionar...</asp:ListItem>
                                     <asp:ListItem Value="1">Acuario</asp:ListItem>
                                     <asp:ListItem Value="2">Biblioteca</asp:ListItem>
                                     <asp:ListItem Value="3">Anime y Manga</asp:ListItem>
                                 </asp:DropDownList>
                                 <a id="error1"></a>  
                            </div>
                        </div>
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Persona:</label>
                               <div class="col-sm-4">
                                 <asp:DropDownList name="persona" id="id_persona" class="form-control" required="required" runat="server">
                                   <asp:ListItem value="0">Seleccionar...</asp:ListItem>
                                 </asp:DropDownList>
                                   <a id="error2"></a>
                              </div>
                        </div>

                       <div class="col-sm-12" >     
                           <div class="col-sm-5 col-sm-offset-4">
                              <button type="submit" class="btn btn-primary" onclick="return validar();">Aceptar</button>
                              <button type="submit" class="btn btn-primary">Cancelar</button>
                           </div>
                       </div>
                 </form>
              </div>
    <script lenguaje="javascript" type="text/javascript">
        function validar() {
            var proyecto_seleccionado = document.getElementById('<%=id_proyecto.ClientID%>').value;
            var personal_seleccionado = document.getElementById('<%=id_persona.ClientID%>').value;

            $("#error1").text("");
            $("#error2").text("");
            if ((proyecto_seleccionado == 0) || (personal_seleccionado == 0)) {
                if (proyecto_seleccionado == 0)
                    $("#error1").text("No seleccionastes el proyecto");
                if (personal_seleccionado == 0)
                    $("#error2").text("No seleccionastes el personal");
                return false;
            } else {
                return confirm('Seguro de que deseas quitar a este personal del proyecto');
            }
        }
    </script>
</asp:Content>

