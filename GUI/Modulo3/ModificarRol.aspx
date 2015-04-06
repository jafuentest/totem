<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Modulo3/Modulo3.master" AutoEventWireup="true" CodeFile="ModificarRol.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
     <div class="col-sm-12">
              	 <form class="form-horizontal" action="" method="POST" role="form" runat="server">
                    <div class="page-header">
                        <h4>Modificar Rol a personal involucrado</h4>
                    </div>
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Proyecto:</label>
                             <div class="col-sm-4">
                                 <asp:DropDownList name="proyecto" id="id_proyecto"  OnSelectedIndexChanged="proyecto_SelectedIndexChanged" class="form-control input-sm" required="required" runat="server" AutoPostBack="True">
                                   <asp:ListItem value="0" Selected="True">Selecionar...</asp:ListItem>
                                   <asp:ListItem value="1">Acuario</asp:ListItem>
                                   <asp:ListItem value="2">Biblioteca</asp:ListItem>
                                   <asp:ListItem value="3">Anime y Manga</asp:ListItem>
                                 </asp:DropDownList>
                                 <a id="error1"></a>
                            </div>
                        </div>
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Seleccione Persona:</label>
                               <div class="col-sm-4">
                                 <asp:DropDownList name="persona" id="id_persona" class="form-control input-sm" required="required" runat="server" AutoPostBack="True" OnSelectedIndexChanged="persona_SelectedIndexChanged">
                                   <asp:ListItem Value="0" Selected="True">Selecione...</asp:ListItem>
                                 </asp:DropDownList>
                                 <a id="error2"></a>
                              </div>
                        </div>
                       <br />
                       <br />
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Rol de la persona:</label>
                              <div class="col-sm-4">
                              <input type="text" class="form-control" id="rolactual" name="id_rolactual" placeholder="Input field" runat="server">


                             </div>
                        </div>
                        <div class="form-group">
                           <label for="" class="col-sm-3 col-sm-offset-2">Nuevo Rol:</label>
                              <div class="col-sm-4">
                                 <asp:DropDownList name="nuevorol" id="id_rol" class="form-control input-sm" required="required" runat="server">
                                     <asp:ListItem value="0">Selecionar...</asp:ListItem>
                                     <asp:ListItem value="1">Lider del Proyecto</asp:ListItem>
                                     <asp:ListItem value="2">Analista</asp:ListItem>
                                     <asp:ListItem value="3">Programador</asp:ListItem>
                                 </asp:DropDownList>
                                  <a id="error3"></a>
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
                var proyecto_seleccionado = document.getElementById('<%=id_proyecto.ClientID%>').value;
                var personal_seleccionado = document.getElementById('<%=id_persona.ClientID%>').value;
                var rol_seleccionado = document.getElementById('<%=id_rol.ClientID%>').value;
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
                } else {
                    return confirm('Seguro de que deseas modificar el rol de este empleado?');
                }
            }
    </script>
</asp:Content>

