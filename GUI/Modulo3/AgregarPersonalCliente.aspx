<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Modulo3/Modulo3.master" AutoEventWireup="true" CodeFile="AgregarPersonalCliente.aspx.cs" Inherits="GUI_Modulo3_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="subtitulo" Runat="Server">
Agregar Empleado de la Empresa Cliente a Proyecto</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenidoCentral" Runat="Server">
              <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
              	 <form class="form-horizontal" action="" method="POST" role="form" runat="server">
                        <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione Proyecto:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_proyecto" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ul id="dp1" class="dropdown-menu" role="menu">
                                    <li><a href="#">Acuario</a></li>
                                    <li><a href="#">Biblioteca</a></li>
                                    <li><a href="#">Anime y Manga</a></li>
                                  </ul>
                                </div>  
                                <a id="error1"></a>          
                              </div>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione Personal:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_personal" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ul id="dp2" class="dropdown-menu" role="menu">
                                    <li><a href="#">Argenis Rodriguez</a></li>
                                    <li><a href="#">Scheryl Palencia</a></li>
                                    <li><a href="#">Rosa Rodriguez</a></li>
                                     <li><a href="#">Akira Toriyama</a></li>
                                  </ul>
                                </div> 
                                <a id="error2"></a>           
                              </div>
                        </div>
                       <div class="form-group">
                            <div class="col-sm-3 col-md-3 col-lg-3">
                                    <label>Seleccione Cargo del personal:</label>  
                             </div>   
                            <div class="col-sm-5 col-md-5 col-lg-5" > 
                                <div class="btn-group">
                                  <button id="id_cargo" type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                    Selecionar...<span class="caret"></span>
                                  </button>
                                  <ul id="dp3" class="dropdown-menu" role="menu">
                                    <li><a href="#">Lider del Proyecto</a></li>
                                    <li><a href="#">Analista</a></li>
                                     <li><a href="#">Programador</a></li>
                                  </ul>
                                </div>
                                <a id="error3"></a>            
                              </div>
                        </div>
                       <br />
                       <div class="form-group" >     
                           <div class="col-sm-3 col-md-2 col-lg-2">
                              <button type="submit" class="btn btn-primary" OnClick="return validar();">Aceptar</button>
                            </div>
                                &nbsp;
                            <div class="col-sm-3 col-md-2 col-lg-2">
                              <button type="submit" class="btn btn-primary">Cancelar</button>
                           </div>
                       </div>
                 </form>
              </div>
        <script type="text/javascript">
            $("#dp1 li a").click(function () {

                $("#id_proyecto").html($(this).text() + ' <span class="caret"></span>');

            });
            $("#dp2 li a").click(function () {

                $("#id_personal").html($(this).text() + ' <span class="caret"></span>');

            });
            $("#dp3 li a").click(function () {

                $("#id_cargo").html($(this).text() + ' <span class="caret"></span>');

            });
            function validar() {
                var proyecto_seleccionado = $("#id_proyecto").text().trim();
                var personal_seleccionado = $("#id_personal").text().trim();
                var rol_seleccionado = $("#id_cargo").text().trim();

                $("#error1").text("");
                $("#error2").text("");
                $("#error3").text("");
                if ((proyecto_seleccionado == "Selecionar...") || (personal_seleccionado == "Selecionar...") || (rol_seleccionado == "Selecionar...")) {
                    if (proyecto_seleccionado == "Selecionar...")
                        $("#error1").text("No seleccionastes el proyecto");
                    if (personal_seleccionado == "Selecionar...")
                        $("#error2").text("No seleccionastes el personal");
                    if (rol_seleccionado == "Selecionar...")
                        $("#error3").text("No seleccionastes el rol");
                    return false;
                } else {
                    return confirm('Seguro de que deseas asignar a este empleado');
                }
            }
       </script>
</asp:Content>

